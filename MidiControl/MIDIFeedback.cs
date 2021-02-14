using NAudio.Midi;

namespace MidiControl
{
    public class MIDIFeedback
    {
        private int channel = 0;
        private int note = 0;
        private MidiOutCustom MidiOutdeviceFeedback;
        private string device;
        public MIDIFeedback(KeyBindEntry keybind)
        {
            device = keybind.Mididevice;
            channel = keybind.Channel;
            note = keybind.NoteNumber;
            MidiOutdeviceFeedback = MIDIListener.GetInstance().MidiOutdeviceFeedback;
        }
        public void SendOn()
        {
            MidiEvent me = new NoteOnEvent(0, channel, note, 01, 0);
            Send(me);
        }

        public void SendOff()

        {
            MidiEvent me = new NoteOnEvent(0, channel, note, 00, 0);
            Send(me);
        }
        public void SendIn()
        {
            MidiEvent me = new NoteOnEvent(0, channel, note, 02, 0);
            Send(me);
        }

        private void Send(MidiEvent me)
        {
            if (MidiOut.DeviceInfo(MidiOutdeviceFeedback.device).ProductName == device)
            {
                MidiOutdeviceFeedback.Send(me.GetAsShortMessage());
            }
        }
    }
}
