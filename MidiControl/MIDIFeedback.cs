using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiControl
{
    public class MIDIFeedback
    {
        private int channel = 0;
        private int note = 0;
        private List<MidiOut> midiOut;
        private string device;
        public MIDIFeedback(KeyBindEntry keybind)
        {
            device = keybind.Mididevice;
            channel = keybind.Channel;
            note = keybind.NoteNumber;
            midiOut = MIDIListener.GetInstance().midiOut;
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
            foreach (MidiOutCustom outDevice in midiOut)
            {
                if (MidiOut.DeviceInfo(outDevice.device).ProductName == device)
                {
                    outDevice.Send(me.GetAsShortMessage());
                }
            }
        }
    }
}
