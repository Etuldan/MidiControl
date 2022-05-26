using NAudio.Wave;
using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Runtime.InteropServices;

namespace MidiControl
{
    public class LoopStream : WaveStream
    {
        readonly WaveStream sourceStream;

        public LoopStream(WaveStream sourceStream)
        {
            this.sourceStream = sourceStream;
            this.EnableLooping = true;
        }

        public bool EnableLooping { get; set; }

        public override WaveFormat WaveFormat
        {
            get { return sourceStream.WaveFormat; }
        }

        public override long Length
        {
            get { return sourceStream.Length; }
        }

        public override long Position
        {
            get { return sourceStream.Position; }
            set { sourceStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    if (sourceStream.Position == 0 || !EnableLooping)
                    {
                        // something wrong with the source stream
                        break;
                    }
                    // loop
                    sourceStream.Position = 0;
                }
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }
    }

    public class AudioControl : IExternalControl
    {
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        private readonly Dictionary<KeyBindEntry, List<WaveOut>> WaveOuts = new Dictionary<KeyBindEntry, List<WaveOut>>();

        public void MediaKey(MediaType type)
        {
            byte key;
            switch (type)
            {
                case MediaType.PLAY:
                    key = VK_MEDIA_PLAY_PAUSE;
                    break;
                case MediaType.PREVIOUS:
                    key = VK_MEDIA_PREV_TRACK;
                    break;
                case MediaType.NEXT:
                    key = VK_MEDIA_NEXT_TRACK;
                    break;
                default:
                    return;
            }
            keybd_event(key, 0, 1, IntPtr.Zero);
        }

        public void PlaySound(KeyBindEntry keybind, string File, int Device, bool Loop, float volume = 1.0f)
        {
            try
            {
#if DEBUG
                Debug.WriteLine("AudioControl : play");
#endif
                MIDIFeedback feedback = new MIDIFeedback(keybind);
                MediaFoundationReader waveReader = new MediaFoundationReader(File);
                LoopStream loop = new LoopStream(waveReader)
                {
                    EnableLooping = Loop
                };

                WaveChannel32 channel = new WaveChannel32(loop)
                {
                    PadWithZeroes = false,
                    Volume = volume
                };

                WaveOut waveOut = new WaveOut();

                void PlaybackStopped(object sender, EventArgs e, KeyBindEntry bind)
                {
#if DEBUG
                    Debug.WriteLine("AudioControl : Stop");
#endif
                    WaveOuts.Remove(bind);
                    MIDIFeedback feedbackOff = new MIDIFeedback(bind); ;
                    feedbackOff.SendOff();
#if DEBUG
                    Debug.WriteLine("AudioControl : StopEnd");
#endif
                }
                waveOut.PlaybackStopped += (sender, e) => PlaybackStopped(sender, e, keybind);
                waveOut.DeviceNumber = Device;
                waveOut.Init(channel);
                waveOut.Play();
                feedback.SendIn();
                try
                {
                    List<WaveOut> list = new List<WaveOut> { waveOut };
                    WaveOuts.Add(keybind, list);
                }
                catch (ArgumentException)
                {
                    WaveOuts[keybind].Add(waveOut);
                }
#if DEBUG
                Debug.WriteLine("AudioControl : playEnd");
#endif

            }
            catch (COMException
#if DEBUG
e
#endif
            )
            {
#if DEBUG
                Debug.WriteLine("AudioControl : COMException" + e);
#endif
            }
            catch (ArgumentException
#if DEBUG
e
#endif
            )
            {
#if DEBUG
                Debug.WriteLine("AudioControl : ArgumentException" + e);
#endif
            }
        }

        public void StopSound(KeyBindEntry keybind)
        {
            if (WaveOuts.TryGetValue(keybind, out List<WaveOut> waveOuts) == true)
            {
                MIDIFeedback feedback = new MIDIFeedback(keybind);
                foreach (WaveOut waveOut in waveOuts)
                {
                    feedback.SendOff();
                    waveOut.Stop();
                    waveOut.Dispose();
                }
            }
        }

        public void StopAll()
        {
            List<WaveOut> list = new List<WaveOut>();
            foreach (KeyValuePair<KeyBindEntry, List<WaveOut>> entry in WaveOuts)
            {
                foreach (WaveOut waveOut in entry.Value)
                {
                    list.Add(waveOut);
                    MIDIFeedback feedback = new MIDIFeedback(entry.Key); ;
                    feedback.SendOff();
                }
            }

            foreach (WaveOut waveout in list)
            {
                waveout.Dispose();
            }
        }

        public bool IsEnabled()
        {
            return true;
        }
    }
}
