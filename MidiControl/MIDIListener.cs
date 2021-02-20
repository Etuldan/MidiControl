using NAudio.Midi;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MidiControl
{
    class MIDIListener
    {
        private List<MidiIn> midiIn = new List<MidiIn>();
        public List<string> midiInStringOptions = new List<string>();
        private MidiOutCustom MidiOutdeviceForward;
        public MidiOutCustom MidiOutdeviceFeedback;
        private List<MidiOut> midiOut = new List<MidiOut>();
        public Dictionary<string, MidiInCustom> midiInInterface = new Dictionary<string, MidiInCustom>();

        private static MIDIListener _instance;
        private readonly Configuration conf;
        private readonly AudioControl audioControl;
        private readonly OptionsManagment options = OptionsManagment.GetInstance();

        public MIDIListener(Configuration conf)
        {
            new OBSControl();
            audioControl = new AudioControl();

            this.conf = conf;
            for (int device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                try
                {
                    if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                        MidiInCustom MidiInForward = new MidiInCustom(device);
                        MidiInForward.MessageReceived += MidiIn_MessageReceivedForwardBack;
                        MidiInForward.Start();
                        midiIn.Add(MidiInForward);
                        Debug.WriteLine("MIDI IN Forward Device " + MidiIn.DeviceInfo(device).ProductName);
                    }
                    else if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward IN")
                    {
                    }
                    else if (!options.options.MIDIInterfaces.Contains(MidiIn.DeviceInfo(device).ProductName))
                    {
                        MidiInCustom MidiIndevice = new MidiInCustom(device);
                        midiInInterface.Add(MidiIn.DeviceInfo(device).ProductName, MidiIndevice);
                        MidiIndevice.Start();
                        midiIn.Add(MidiIndevice);
                        Debug.WriteLine("MIDI IN Device " + MidiIn.DeviceInfo(device).ProductName);
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
                        MidiOutdeviceForward = new MidiOutCustom(device);
                        midiOut.Add(MidiOutdeviceForward);
                        Debug.WriteLine("MIDI OUT Forward Device " + MidiOut.DeviceInfo(device).ProductName);
                    }
                    else if (MidiOut.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                    }
                    else if (MIDIFeedback.FeedBackDevices.Contains(MidiOut.DeviceInfo(device).ProductName))
                    {
                        MidiOutdeviceFeedback = new MidiOutCustom(device);
                        midiOut.Add(MidiOutdeviceFeedback);
                        Debug.WriteLine("MIDI OUT Feedback Device " + MidiOut.DeviceInfo(device).ProductName);
                    }
                }
                catch (NAudio.MmException)
                {
                    // Device already Opened
                }
            }

            EnableListening();
            _instance = this;
        }

        public void ReleaseAll()
        {
            foreach(MidiIn midi in midiIn)
            {
                try
                {
                    midi.Stop();
                    midi.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
            foreach (MidiOut midi in midiOut)
            {
                try
                {
                    midi.Dispose();
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
            Debug.WriteLine("MIDI IN ForwardBack Signal " + e.MidiEvent.GetType() + " | " + e.MidiEvent.ToString());
            if(MidiOutdeviceFeedback != null)
            {
                MidiOutdeviceFeedback.Send(e.RawMessage);
            }
        }
        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            Debug.WriteLine("MIDI IN Signal " + e.MidiEvent.GetType() + " | " + e.MidiEvent.ToString());
            if(MidiOutdeviceForward != null)
            {
                MidiOutdeviceForward.Send(e.RawMessage);
            }

            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && ((NoteEvent)e.MidiEvent).Velocity != 0 && 
                options.options.MidiDeviceStopAllSounds == MidiIn.DeviceInfo(((MidiInCustom)sender).device).ProductName && 
                options.options.NoteNumberStopAllSounds == ((NoteEvent)e.MidiEvent).NoteNumber && 
                options.options.ChannelStopAllSounds == ((NoteEvent)e.MidiEvent).Channel)
            {
                this.StopAllSounds();
            }

            foreach (KeyValuePair<string, KeyBindEntry> entry in conf.Config)
            {
                var type = e.MidiEvent.GetType();
                if (type.Name == "ControlChangeEvent" && entry.Value.Input == Event.Slider && ((int)((ControlChangeEvent)e.MidiEvent).Controller != entry.Value.NoteNumber ||
                    ((ControlChangeEvent)e.MidiEvent).Channel != entry.Value.Channel || MidiIn.DeviceInfo(((MidiInCustom)sender).device).ProductName != entry.Value.Mididevice)) continue;

                if ((type.Name == "NoteEvent" || type.Name == "NoteOnEvent") && entry.Value.Input == Event.Note && (((NoteEvent)e.MidiEvent).NoteNumber != entry.Value.NoteNumber ||
                    ((NoteEvent)e.MidiEvent).Channel != entry.Value.Channel || MidiIn.DeviceInfo(((MidiInCustom)sender).device).ProductName != entry.Value.Mididevice)) continue;

                if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && entry.Value.Input == Event.Note && ((NoteEvent)e.MidiEvent).Velocity != 0)
                {
                    Debug.WriteLine("KeyBind NoteON");
                    foreach (OBSCallBack callback in entry.Value.OBSCallBacksON)
                    {
                        callback.Start(entry.Value);
                    }
                    if(entry.Value.SoundCallBack != null)
                    {
                        audioControl.PlaySound(entry.Value, entry.Value.SoundCallBack.File, entry.Value.SoundCallBack.Device, entry.Value.SoundCallBack.Loop, entry.Value.SoundCallBack.Volume);
                    }
                }
                else if (((e.MidiEvent.CommandCode == MidiCommandCode.NoteOff || e.MidiEvent.CommandCode == MidiCommandCode.NoteOn) && entry.Value.Input == Event.Note && ((NoteEvent)e.MidiEvent).Velocity == 0))
                {
                    Debug.WriteLine("KeyBind NoteOFF");
                    foreach (OBSCallBack callback in entry.Value.OBSCallBacksOFF)
                    {
                        callback.Start(entry.Value);
                    }
                    if (entry.Value.SoundCallBack != null && entry.Value.SoundCallBack.StopWhenReleased == true)
                    {
                        audioControl.StopSound(entry.Value);
                    }
                }
                else if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange && entry.Value.Input == Event.Slider)
                {
                    Debug.WriteLine("KeyBind ControlChange");
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
