using NAudio.Midi;

namespace MidiControl
{
    class MidiInCustom : MidiIn
    {
        public int device = 0;

        public MidiInCustom(int deviceNo) : base(deviceNo)
        {
            device = deviceNo;
        }

    }
    class MidiOutCustom : MidiOut
    {
        public int device = 0;

        public MidiOutCustom(int deviceNo) : base(deviceNo)
        {
            device = deviceNo;
        }
    }
}
