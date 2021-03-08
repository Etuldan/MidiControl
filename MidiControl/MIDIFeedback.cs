using NAudio.Midi;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif

namespace MidiControl
{
    public class MIDIFeedback
    {
        public static readonly IEnumerable<string> FeedBackDevices = new List<string> { "APC MINI", "Launchpad Mini" };

        private enum Devices
        {
            NONE,
            APC_MINI,
            Launchpad
        }

        private readonly Devices deviceType = Devices.NONE;
        private readonly int channel = 0;
        private readonly int note = 0;
        private readonly MidiOutCustom MidiOutdeviceFeedback;
        public MIDIFeedback(KeyBindEntry keybind)
        {
            channel = keybind.Channel;
            note = keybind.NoteNumber;
            foreach (KeyValuePair<string, MidiOutCustom> entry in MIDIListener.GetInstance().midiOutInterface)
            {
                if (MidiOut.DeviceInfo(entry.Value.device).ProductName == "APC MINI" && keybind.Mididevice == "APC MINI")
                {
                    MidiOutdeviceFeedback = entry.Value;
                    deviceType = Devices.APC_MINI;
                }
                else if (MidiOut.DeviceInfo(entry.Value.device).ProductName == "Launchpad Mini" && keybind.Mididevice == "Launchpad Mini")
                {
                    MidiOutdeviceFeedback = entry.Value;
                    deviceType = Devices.Launchpad;
                }
            }
        }
        public void SendOn()
        {
#if DEBUG
            Debug.WriteLine("MIDIFeedback : SendOn");
#endif
            MidiEvent me;
            switch (deviceType)
            {
                case Devices.APC_MINI:
                    me = new NoteOnEvent(0, channel, note, 01, 0);
                    break;
                case Devices.Launchpad:
                    me = new NoteOnEvent(0, channel, note, 60, 0);
                    break;
                default:
                    return;
            }
            Send(me);
        }

        public void SendOff()
        {
#if DEBUG
            Debug.WriteLine("MIDIFeedback : SendOff");
#endif
            MidiEvent me;
            switch(deviceType)
            {
                case Devices.APC_MINI:
                    me = new NoteOnEvent(0, channel, note, 00, 0);
                    break;
                case Devices.Launchpad:
                    me = new NoteOnEvent(0, channel, note, 12, 0);
                    break;
                default:
                    return;
            }
            Send(me);
        }
        public void SendIn()
        {
#if DEBUG
            Debug.WriteLine("MIDIFeedback : SendIn");
#endif
            MidiEvent me;
            switch (deviceType)
            {
                case Devices.APC_MINI:
                    me = new NoteOnEvent(0, channel, note, 02, 0);
                    break;
                case Devices.Launchpad:
                    me = new NoteOnEvent(0, channel, note, 56, 0);
                    break;
                default:
                    return;
            }
            Send(me);
        }

        private void Send(MidiEvent me)
        {
#if DEBUG
            Debug.WriteLine("MIDIFeedback : Send " + me.GetAsShortMessage());
#endif
            MidiOutdeviceFeedback.Send(me.GetAsShortMessage());
#if DEBUG
            Debug.WriteLine("MIDIFeedback : SendEnd");
#endif
        }
    }
}
