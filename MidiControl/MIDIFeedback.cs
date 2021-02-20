using NAudio.Midi;
using System.Collections.Generic;
using System.Diagnostics;

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
            MidiOutdeviceFeedback = MIDIListener.GetInstance().MidiOutdeviceFeedback;
            if(MidiOut.DeviceInfo(MidiOutdeviceFeedback.device).ProductName == "APC MINI")
            {
                deviceType = Devices.APC_MINI;
            }
        }
        public void SendOn()
        {
            Debug.WriteLine("MIDIFeedback : SendOn");

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
            Debug.WriteLine("MIDIFeedback : SendOff");

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
            Debug.WriteLine("MIDIFeedback : SendIn");

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
            Debug.WriteLine("MIDIFeedback : Send " + me.GetAsShortMessage());
            MidiOutdeviceFeedback.Send(me.GetAsShortMessage());
            Debug.WriteLine("MIDIFeedback : SendEnd");
        }
    }
}
