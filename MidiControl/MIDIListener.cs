using NAudio.Midi;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Linq;

namespace MidiControl
{
    class MIDIListener
    {
        public List<string> midiInStringOptions = new List<string>();
        private MidiInCustom MidiInForward;
        private MidiOutCustom MidiOutForward;
        public Dictionary<string, MidiInCustom> midiInInterface = new Dictionary<string, MidiInCustom>();
        public Dictionary<string, MidiOutCustom> midiOutInterface = new Dictionary<string, MidiOutCustom>();

        private static MIDIListener _instance;
        private readonly Configuration conf;
        private readonly AudioControl audioControl;
        private readonly TwitchChatControl twitchControl;

        private readonly OptionsManagment options = OptionsManagment.GetInstance();

        public MIDIListener(Configuration conf)
        {
            new OBSControl();
            audioControl = new AudioControl();
            twitchControl = new TwitchChatControl(options.options, conf.Config);

            this.conf = conf;

            RefeshMIDIDevices();

            _instance = this;
        }

        public void RefeshMIDIDevices()
        {
            ReleaseAll();
            midiInStringOptions.Clear();
            midiInInterface.Clear();
            midiOutInterface.Clear();
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                try
                {
                    if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                        MidiInForward = new MidiInCustom(device);
                        MidiInForward.MessageReceived += MidiIn_MessageReceivedForwardBack;
                        MidiInForward.Start();
#if DEBUG
                        Debug.WriteLine("MIDI IN Forward Device " + MidiIn.DeviceInfo(device).ProductName);
#endif
                    }
                    else if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward IN")
                    {
                    }
                    else if (!options.options.MIDIInterfaces.Contains(MidiIn.DeviceInfo(device).ProductName))
                    {
                        MidiInCustom MidiIndevice = new MidiInCustom(device);
                        midiInInterface.Add(MidiIn.DeviceInfo(device).ProductName, MidiIndevice);
                        MidiIndevice.Start();
#if DEBUG
                        Debug.WriteLine("MIDI IN Device " + MidiIn.DeviceInfo(device).ProductName);
#endif
                    }

                    midiInStringOptions.Add(MidiIn.DeviceInfo(device).ProductName);
                }
                catch (NAudio.MmException)
                {
                    // Device already Opened
                }
            }

            for (int device = 0; device < MidiOut.NumberOfDevices; device++)
            {
                try
                {
                    if (MidiOut.DeviceInfo(device).ProductName == "MIDIControl Forward IN")
                    {
                        MidiOutForward = new MidiOutCustom(device);
#if DEBUG
                        Debug.WriteLine("MIDI OUT Forward Device " + MidiOut.DeviceInfo(device).ProductName);
#endif
                    }
                    else if (MidiOut.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                    }
                    else if (MIDIFeedback.FeedBackDevices.Contains(MidiOut.DeviceInfo(device).ProductName))
                    {
                        midiOutInterface.Add(MidiOut.DeviceInfo(device).ProductName, new MidiOutCustom(device));
#if DEBUG
                        Debug.WriteLine("MIDI OUT Feedback Device " + MidiOut.DeviceInfo(device).ProductName);
#endif
                    }
                }
                catch (NAudio.MmException)
                {
                    // Device already Opened
                }
            }
            EnableListening();
        }

        public List<string> GetMIDIINDevices()
        {
            List<string> list = new List<string>();
            foreach (KeyValuePair<string, MidiInCustom> entry in midiInInterface)
            {
                list.Add(entry.Key);
            }
            return list;
        }

        public void ReleaseAll()
        {
            if (MidiInForward != null)
            {
                try
                {
                    MidiInForward.Stop();
                    MidiInForward.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
            if (MidiOutForward != null)
            {
                try
                {
                    MidiOutForward.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
            foreach (KeyValuePair<string, MidiInCustom> entry in midiInInterface)
            {
                try
                {
                    entry.Value.Stop();
                    entry.Value.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
            foreach (KeyValuePair<string, MidiOutCustom> entry in midiOutInterface)
            {
                try
                {
                    entry.Value.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
        }

        public void EnableListening()
        {
            foreach (KeyValuePair<string, MidiInCustom> entry in midiInInterface)
            {
                entry.Value.MessageReceived += MidiIn_MessageReceived;
            }
        }

        public void DisableListening()
        {
            foreach (KeyValuePair<string, MidiInCustom> entry in midiInInterface)
            {
                entry.Value.MessageReceived -= MidiIn_MessageReceived;
            }
        }

        private void MidiIn_MessageReceivedForwardBack(object sender, MidiInMessageEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("MIDI IN ForwardBack Signal " + e.MidiEvent.GetType() + " | " + e.MidiEvent.ToString());
#endif
            foreach (KeyValuePair<string, MidiOutCustom> entry in midiOutInterface)
            {
                entry.Value.Send(e.RawMessage);
            }
        }   
        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
#if DEBUG
            Debug.WriteLine("MIDI IN Signal " + e.MidiEvent.GetType() + " | " + e.MidiEvent.ToString());
#endif
            if(MidiOutForward != null)
            {
                MidiOutForward.Send(e.RawMessage);
            }

            foreach (KeyValuePair<string, KeyBindEntry> entry in conf.Config)
            {
                if(e.MidiEvent.CommandCode == MidiCommandCode.ControlChange && entry.Value.Input == Event.Slider && ((int)((ControlChangeEvent)e.MidiEvent).Controller != entry.Value.NoteNumber ||
                    ((ControlChangeEvent)e.MidiEvent).Channel != entry.Value.Channel || MidiIn.DeviceInfo(((MidiInCustom)sender).device).ProductName != entry.Value.Mididevice)) continue;
                if ((e.MidiEvent.CommandCode == MidiCommandCode.NoteOn || e.MidiEvent.CommandCode == MidiCommandCode.NoteOff) && entry.Value.Input == Event.Note && (((NoteEvent)e.MidiEvent).NoteNumber != entry.Value.NoteNumber ||
                    ((NoteEvent)e.MidiEvent).Channel != entry.Value.Channel || MidiIn.DeviceInfo(((MidiInCustom)sender).device).ProductName != entry.Value.Mididevice)) continue;

                if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && entry.Value.Input == Event.Note && ((NoteEvent)e.MidiEvent).Velocity != 0)
                {
#if DEBUG
                    Debug.WriteLine("KeyBind NoteON");
#endif
                    foreach (OBSCallBack callback in entry.Value.OBSCallBacksON)
                    {
                        callback.Start(entry.Value);
                    }
                    if(entry.Value.SoundCallBack != null)
                    {
                        audioControl.PlaySound(entry.Value, entry.Value.SoundCallBack.File, entry.Value.SoundCallBack.Device, entry.Value.SoundCallBack.Loop, entry.Value.SoundCallBack.Volume);
                    }
                    if(entry.Value.MediaCallBack != null)
                    {
                        audioControl.MediaKey(entry.Value.MediaCallBack.MediaType);
                    }
                    if (entry.Value.TwitchCallBackON != null)
                    {
                        twitchControl.SendMessage(entry.Value.TwitchCallBackON.Channel, entry.Value.TwitchCallBackON.Messsage);
                    }
                    if (entry.Value.MIDIControlCallBackON != null)
                    {
                        if(entry.Value.MIDIControlCallBackON.StopAllSound == true)
                        {
                            audioControl.StopAll();
                        }
                        if(entry.Value.MIDIControlCallBackON.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackON.SwitchToProfile);
                        }
                    }
                }
                else if (((e.MidiEvent.CommandCode == MidiCommandCode.NoteOff || (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && ((NoteEvent)e.MidiEvent).Velocity == 0))) && entry.Value.Input == Event.Note )
                {
#if DEBUG
                    Debug.WriteLine("KeyBind NoteOFF");
#endif
                    foreach (OBSCallBack callback in entry.Value.OBSCallBacksOFF)
                    {
                        callback.Start(entry.Value);
                    }
                    if (entry.Value.MediaCallBackOFF != null)
                    {
                        audioControl.MediaKey(entry.Value.MediaCallBackOFF.MediaType);
                    }
                    if (entry.Value.SoundCallBack != null && entry.Value.SoundCallBack.StopWhenReleased == true)
                    {
                        audioControl.StopSound(entry.Value);
                    }
                    if (entry.Value.TwitchCallBackOFF != null)
                    {
                        twitchControl.SendMessage(entry.Value.TwitchCallBackOFF.Channel, entry.Value.TwitchCallBackOFF.Messsage);
                    }
                    if (entry.Value.MIDIControlCallBackOFF != null)
                    {
                        if (entry.Value.MIDIControlCallBackOFF.StopAllSound == true)
                        {
                            audioControl.StopAll();
                        }
                        if (entry.Value.MIDIControlCallBackOFF.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackOFF.SwitchToProfile);
                        }
                    }
                }
                else if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange && entry.Value.Input == Event.Slider)
                {
#if DEBUG
                    Debug.WriteLine("KeyBind ControlChange");
#endif
                    if (((ControlChangeEvent)e.MidiEvent).ControllerValue != 0)
                    {
                        foreach (OBSCallBack callback in entry.Value.OBSCallBacksON)
                        {
                            callback.Start(entry.Value);
                        }
                        if (entry.Value.SoundCallBack != null)
                        {
                            audioControl.PlaySound(entry.Value, entry.Value.SoundCallBack.File, entry.Value.SoundCallBack.Device, entry.Value.SoundCallBack.Loop, entry.Value.SoundCallBack.Volume);
                        }
                    }
                    else
                    {
                        foreach (OBSCallBack callback in entry.Value.OBSCallBacksOFF)
                        {
                            callback.Start(entry.Value);
                        }
                        if (entry.Value.SoundCallBack != null && entry.Value.SoundCallBack.StopWhenReleased == true)
                        {
                            audioControl.StopSound(entry.Value);
                        }
                    }
                    foreach (OBSCallBack callback in entry.Value.OBSCallBacksSlider)
                    {
                        callback.Start(entry.Value, (float)((ControlChangeEvent)e.MidiEvent).ControllerValue / 127);
                    }
                }
            }
        }

        public void StopAllSounds()
        {
            audioControl.StopAll();
        }

        public static MIDIListener GetInstance()
        {
            return _instance;
        }
    }
}
