using NAudio.Midi;
using System.Collections.Generic;

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
            if(MidiIn.DeviceInfo(MidiOutdeviceFeedback.device).ProductName == "APC MINI")
            {
                deviceType = Devices.APC_MINI;
            }
        }
        public void SendOn()
        {
            MidiEvent me = null;
            if (deviceType == Devices.APC_MINI)
            {
                me = new NoteOnEvent(0, channel, note, 01, 0);
            }
            Send(me);
        }

        public void SendOff()

        {
            MidiEvent me = null;
            if (deviceType == Devices.APC_MINI)
            {
                me = new NoteOnEvent(0, channel, note, 00, 0);
            }
            Send(me);
        }
        public void SendIn()
        {
            MidiEvent me = null;
            if (deviceType == Devices.APC_MINI)
            {
                me = new NoteOnEvent(0, channel, note, 02, 0);
            }
            Send(me);
        }

        private void Send(MidiEvent me)
        {
            if(me != null)
            {
                MidiOutdeviceFeedback.Send(me.GetAsShortMessage());
            }
        }
    }
}
