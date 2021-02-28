using NAudio.Midi;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif

namespace MidiControl
{
    public class MIDIFeedback
    {
        public static readonly IEnumerable<string> FeedBackDevices = new List<string> { "APC MINI" };

        private enum Devices
        {
            NONE,
            APC_MINI,
            Launchpad
        }

        private Devices deviceType = Devices.NONE;
        private int channel = 0;
        private int note = 0;
        private MidiOutCustom MidiOutdeviceFeedback;
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
