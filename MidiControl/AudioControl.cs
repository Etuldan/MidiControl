﻿using NAudio.Wave;
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
            var totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                var bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
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

        private readonly Dictionary<KeyBindEntry, List<WaveOut>> WaveOuts = new();

        public static void MediaKey(MediaType type)
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
                var feedback = new MIDIFeedback(keybind);
                var waveReader = new MediaFoundationReader(File);
                var loop = new LoopStream(waveReader)
                {
                    EnableLooping = Loop
                };

                var channel = new WaveChannel32(loop)
                {
                    PadWithZeroes = false,
                    Volume = volume
                };

                var waveOut = new WaveOut();

                void PlaybackStopped(object sender, EventArgs e, KeyBindEntry bind)
                {
                    WaveOuts.Remove(bind);
                    var feedbackOff = new MIDIFeedback(bind); ;
                    feedbackOff.SendOff();
                }
                waveOut.PlaybackStopped += (sender, e) => PlaybackStopped(sender, e, keybind);
                waveOut.DeviceNumber = Device;
                waveOut.Init(channel);
                waveOut.Play();
                feedback.SendIn();
                try
                {
                    var list = new List<WaveOut> { waveOut };
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
                var feedback = new MIDIFeedback(keybind);
                foreach (var waveOut in waveOuts)
                {
                    feedback.SendOff();
                    waveOut.Stop();
                    waveOut.Dispose();
                }
            }
        }

        public void StopAll()
        {
            var list = new List<WaveOut>();
            foreach (var entry in WaveOuts)
            {
                foreach (var waveOut in entry.Value)
                {
                    list.Add(waveOut);
                    var feedback = new MIDIFeedback(entry.Key); ;
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
