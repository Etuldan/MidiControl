using MidiControl.Control;
using NAudio.Midi;
using System.Collections.Generic;
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
        private readonly GoXLRControl goXLRControl;

        private readonly OptionsManagment options = OptionsManagment.GetInstance();

        public MIDIListener(Configuration conf)
        {
            new OBSControl();
            audioControl = new AudioControl();
            goXLRControl = new GoXLRControl();
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
            for (var device = 0; device < MidiIn.NumberOfDevices; device++)
            {
                try
                {
                    if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                        MidiInForward = new MidiInCustom(device);
                        MidiInForward.MessageReceived += MidiIn_MessageReceivedForwardBack;
                        MidiInForward.Start();
                    }
                    else if (MidiIn.DeviceInfo(device).ProductName == "MIDIControl Forward IN")
                    {
                    }
                    else if (!options.options.MIDIInterfaces.Contains(MidiIn.DeviceInfo(device).ProductName))
                    {
                        MidiInCustom MidiIndevice = new MidiInCustom(device);
                        midiInInterface.Add(MidiIn.DeviceInfo(device).ProductName, MidiIndevice);
                        MidiIndevice.Start();
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
                    }
                    else if (MidiOut.DeviceInfo(device).ProductName == "MIDIControl Forward OUT")
                    {
                    }
                    else if (MIDIFeedback.FeedBackDevices.Contains(MidiOut.DeviceInfo(device).ProductName))
                    {
                        midiOutInterface.Add(MidiOut.DeviceInfo(device).ProductName, new MidiOutCustom(device));
                    }
                    if (MidiOut.DeviceInfo(device).ProductName == "MIDIOUT2 (Launchkey Mini)")
                    {
                        MidiOut m = midiOutInterface["MIDIOUT2 (Launchkey Mini)"];
                        MidiEvent me;
                        me = new NoteOnEvent(0, 1, 12, 127, 0);
                        m.Send(me.GetAsShortMessage());
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
            var list = new List<string>();
            foreach (var entry in midiInInterface)
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
            foreach (var entry in midiInInterface)
            {
                try
                {
                    // if the device is no longer connected, this will get stuck
                    //string devName = MidiIn.DeviceInfo(entry.Value.device).ProductName;
                    // if that works, does the device name match what the program thinks it is?
                    //if(entry.Key == devName) {
                    //
                    //}
                    entry.Value.Stop();
                    entry.Value.Dispose();
                }
                catch (NAudio.MmException)
                {
                }
            }
            foreach (var entry in midiOutInterface)
            {
                if (entry.Key == "MIDIOUT2 (Launchkey Mini)")
                {
                    var m = midiOutInterface["MIDIOUT2 (Launchkey Mini)"];
                    MidiEvent me;
                    me = new NoteOnEvent(0, 1, 12, 0, 0);
                    m.Send(me.GetAsShortMessage());
                }
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
            foreach (var entry in midiInInterface)
            {
                entry.Value.MessageReceived += MidiIn_MessageReceived;
            }
        }

        public void DisableListening()
        {
            foreach (var entry in midiInInterface)
            {
                entry.Value.MessageReceived -= MidiIn_MessageReceived;
            }
        }

        private void MidiIn_MessageReceivedForwardBack(object sender, MidiInMessageEventArgs e)
        {
            foreach (var entry in midiOutInterface)
            {
                entry.Value.Send(e.RawMessage);
            }
        }

        private int ValidateSenderDeviceInt(MidiInCustom dev) {
            var device = dev.device;
            var assumed = device;
            var adjusted = false;
            var correct = false;
            var devName = "null";

            while(!correct && device >= 0) {
                try {
                    devName = MidiIn.DeviceInfo(device).ProductName;
                    correct = true;
                } catch(NAudio.MmException) {
                    // device id was invalid; this happens if devices with lower ids are no longer connected and the connected devices list hasn't been refreshed
                    // need to shift the assumed device down until we find a device that exists
                    device--;
                    adjusted = true;
                }
            }

            if(device < 0) device = 0;

            if(adjusted) {
                var gui = MIDIControlGUI.GetInstance();
                gui.Invoke(gui.MidiInStatusDelegate, new object[] { true });
            }

            return device;
        }

        // sender = MidiInCustom object
        // ((MidiInCustom)sender).device = int: numeric device index
        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            int deviceId = this.ValidateSenderDeviceInt((MidiInCustom)sender);
            MidiOutForward?.Send(e.RawMessage);

            foreach (var entry in conf.Config)
            {
                if(e.MidiEvent.CommandCode == MidiCommandCode.ControlChange && entry.Value.Input == Event.Slider && ((int)((ControlChangeEvent)e.MidiEvent).Controller != entry.Value.NoteNumber ||
                    ((ControlChangeEvent)e.MidiEvent).Channel != entry.Value.Channel || MidiIn.DeviceInfo(deviceId).ProductName != entry.Value.Mididevice)) continue;

                try {
                    if (
                        (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn || e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
                        && entry.Value.Input == Event.Note
                        && (
                            ((NoteEvent)e.MidiEvent).NoteNumber != entry.Value.NoteNumber
                            || ((NoteEvent)e.MidiEvent).Channel != entry.Value.Channel
                            || MidiIn.DeviceInfo(deviceId).ProductName != entry.Value.Mididevice
                        )
                    ) continue;
                } catch (NAudio.MmException ex) {
                    // NAudio.MmException: 'BadDeviceId calling midiInGetDevCaps'
                    // occurs if a MIDI device present on app launch is disconnected
                    //
                    // TODO: this causes nothing to work and crashes the program; need to RefreshMIDIDevices() while not trying to stop the one that is no longer present (because this causes a hang). throwing it again for now
                    throw ex;
                }


                if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && entry.Value.Input == Event.Note && ((NoteEvent)e.MidiEvent).Velocity != 0)
                {
                    foreach (var callback in entry.Value.OBSCallBacksON)
                    {
                        callback.Start(entry.Value);
                    }
                    if(entry.Value.SoundCallBack != null)
                    {
						if(entry.Value.SoundCallBack.StopAllOtherSounds)
                        {
                            audioControl.StopAll();
                        }
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
                        if(entry.Value.MIDIControlCallBackON.StopAllSound)
                        {
                            audioControl.StopAll();
                        }
                        if(entry.Value.MIDIControlCallBackON.SwitchToProfile != null &&
							entry.Value.MIDIControlCallBackON.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackON.SwitchToProfile);
                        }
                    }
                    if (entry.Value.GoXLRCallBackON != null)
                    {
                        if (entry.Value.GoXLRCallBackON.Action == (int)GoXLRControl.Action.Mute)
                        {
                            goXLRControl.Mute(entry.Value.GoXLRCallBackON.Input, entry.Value.GoXLRCallBackON.Output, entry.Value);
                        }
                        if (entry.Value.GoXLRCallBackON.Action == (int)GoXLRControl.Action.UnMute)
                        {
                            goXLRControl.UnMute(entry.Value.GoXLRCallBackON.Input, entry.Value.GoXLRCallBackON.Output, entry.Value);
                        }
                        if (entry.Value.GoXLRCallBackON.Action == (int)GoXLRControl.Action.Toggle)
                        {
                            goXLRControl.Toggle(entry.Value.GoXLRCallBackON.Input, entry.Value.GoXLRCallBackON.Output, entry.Value);
                        }
                    }
                }
                else if (((e.MidiEvent.CommandCode == MidiCommandCode.NoteOff || (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn && ((NoteEvent)e.MidiEvent).Velocity == 0))) && entry.Value.Input == Event.Note )
                {
                    foreach (var callback in entry.Value.OBSCallBacksOFF)
                    {
                        callback.Start(entry.Value);
                    }
                    if (entry.Value.MediaCallBackOFF != null)
                    {
                        audioControl.MediaKey(entry.Value.MediaCallBackOFF.MediaType);
                    }
                    if (entry.Value.SoundCallBack != null && entry.Value.SoundCallBack.StopWhenReleased)
                    {
                        audioControl.StopSound(entry.Value);
                    }
                    if (entry.Value.TwitchCallBackOFF != null)
                    {
                        twitchControl.SendMessage(entry.Value.TwitchCallBackOFF.Channel, entry.Value.TwitchCallBackOFF.Messsage);
                    }
                    if (entry.Value.MIDIControlCallBackOFF != null)
                    {
                        if (entry.Value.MIDIControlCallBackOFF.StopAllSound)
                        {
                            audioControl.StopAll();
                        }
                        if (entry.Value.MIDIControlCallBackOFF.SwitchToProfile != null && 
                            entry.Value.MIDIControlCallBackOFF?.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackOFF.SwitchToProfile);
                        }
                    }
                    if (entry.Value.GoXLRCallBackOFF != null)
                    {
                        if (entry.Value.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.Mute)
                        {
                            goXLRControl.Mute(entry.Value.GoXLRCallBackOFF.Input, entry.Value.GoXLRCallBackOFF.Output, entry.Value);
                        }
                        if (entry.Value.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.UnMute)
                        {
                            goXLRControl.UnMute(entry.Value.GoXLRCallBackOFF.Input, entry.Value.GoXLRCallBackOFF.Output, entry.Value);
                        }
                        if (entry.Value.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.Toggle)
                        {
                            goXLRControl.Toggle(entry.Value.GoXLRCallBackOFF.Input, entry.Value.GoXLRCallBackOFF.Output, entry.Value);
                        }
                    }
                }
                else if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange && entry.Value.Input == Event.Slider)
                {
                    if (entry.Value.MIDIControlCallBackON != null)
                    {
                        if (entry.Value.MIDIControlCallBackON.StopAllSound)
                        {
                            audioControl.StopAll();
                        }
                        if (entry.Value.MIDIControlCallBackON.SwitchToProfile != null &&
                            entry.Value.MIDIControlCallBackON.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackON.SwitchToProfile);
                        }
                    }
                    if (entry.Value.MIDIControlCallBackOFF != null)
                    {
                        if (entry.Value.MIDIControlCallBackOFF.StopAllSound)
                        {
                            audioControl.StopAll();
                        }
                        if (entry.Value.MIDIControlCallBackOFF.SwitchToProfile != null &&
                            entry.Value.MIDIControlCallBackOFF.SwitchToProfile != "")
                        {
                            conf.LoadProfile(entry.Value.MIDIControlCallBackOFF.SwitchToProfile);
                        }
                    }
                    if (((ControlChangeEvent)e.MidiEvent).ControllerValue != 0)
                    {
                        foreach (var callback in entry.Value.OBSCallBacksON)
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
                        foreach (var callback in entry.Value.OBSCallBacksOFF)
                        {
                            callback.Start(entry.Value);
                        }
                        if (entry.Value.SoundCallBack != null && entry.Value.SoundCallBack.StopWhenReleased)
                        {
                            audioControl.StopSound(entry.Value);
                        }
                    }
                    foreach (var callback in entry.Value.OBSCallBacksSlider)
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

        // for convenience on EntryGUI
        private static readonly string[] noteMap = {
            "C-2", "C#-2", "D-2", "D#-2", "E-2", "F-2", "F#-2", "G-2", "G#-2", "A-2", "A#-2", "B-2",
            "C-1", "C#-1", "D-1", "D#-1", "E-1", "F-1", "F#-1", "G-1", "G#-1", "A-1", "A#-1", "B-1",
            "C0", "C#0", "D0", "D#0", "E0", "F0", "F#0", "G0", "G#0", "A0", "A#0", "B0",
            "C1", "C#1", "D1", "D#1", "E1", "F1", "F#1", "G1", "G#1", "A1", "A#1", "B1",
            "C2", "C#2", "D2", "D#2", "E2", "F2", "F#2", "G2", "G#2", "A2", "A#2", "B2",
            "C3", "C#3", "D3", "D#3", "E3", "F3", "F#3", "G3", "G#3", "A3", "A#3", "B3",
            "C4", "C#4", "D4", "D#4", "E4", "F4", "F#4", "G4", "G#4", "A4", "A#4", "B4",
            "C5", "C#5", "D5", "D#5", "E5", "F5", "F#5", "G5", "G#5", "A5", "A#5", "B5",
            "C6", "C#6", "D6", "D#6", "E6", "F6", "F#6", "G6", "G#6", "A6", "A#6", "B6",
            "C7", "C#7", "D7", "D#7", "E7", "F7", "F#7", "G7", "G#7", "A7", "A#7", "B7",
            "C8", "C#8", "D8", "D#8", "E8", "F8", "F#8", "G8"
        };

        public static string GetNoteString(int pitch) { return noteMap[pitch]; }
    }
}
