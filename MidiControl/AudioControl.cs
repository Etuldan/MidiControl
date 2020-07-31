using NAudio.Wave;
using System;
using System.Collections.Generic;
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
        private readonly Dictionary<KeyBindEntry, List<WaveOut>> WaveOuts = new Dictionary<KeyBindEntry, List<WaveOut>>();

        public AudioControl()
        {

        }

        public void PlaySound(KeyBindEntry keybind, string File, int Device, bool Loop, float volume = 1.0f)
        {
            try
            {
                MediaFoundationReader waveReader = new MediaFoundationReader(File);
                LoopStream loop = new LoopStream(waveReader)
                {
                    EnableLooping = Loop
                };

                WaveChannel32 channel = new WaveChannel32(loop) { PadWithZeroes = false };
                channel.Volume = volume;

                WaveOut waveOut = new WaveOut();

                void PlaybackStopped(object sender, EventArgs e, KeyBindEntry bind)
                {
                    WaveOuts.Remove(bind);
                }
                waveOut.PlaybackStopped += (sender, e) => PlaybackStopped(sender, e, keybind);
                waveOut.DeviceNumber = Device;
                waveOut.Init(channel);
                waveOut.Play();
                try
                {
                    List<WaveOut> list = new List<WaveOut> { waveOut };
                    WaveOuts.Add(keybind, list);
                }
                catch (ArgumentException)
                {
                    WaveOuts[keybind].Add(waveOut);
                }

            }
            catch (COMException)
            {

            }
            catch (ArgumentException)
            {

            }
        }

        public void StopSound(KeyBindEntry keybind)
        {
            if (WaveOuts.TryGetValue(keybind, out List<WaveOut> waveOuts) == true)
            {
                foreach (WaveOut waveOut in waveOuts)
                {
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
