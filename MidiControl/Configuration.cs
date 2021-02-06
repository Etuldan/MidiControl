using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MidiControl
{
    class Configuration
    {
        public Dictionary<string, KeyBindEntry> Config { get; set; }
        private static Configuration _instance;
        private readonly string ConfFile;

        public Configuration()
        {
            _instance = this;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ConfFolder = Path.Combine(folder, "MIDIControl");
            ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
            Directory.CreateDirectory(ConfFolder);
            Load();
        }

        public static Configuration GetInstance()
        {
            return _instance;
        }

        private void Load()
        {
            try
            {
                string json = File.ReadAllText(ConfFile);
                Config = JsonConvert.DeserializeObject<Dictionary<string, KeyBindEntry>>(json);
                if (Config == null)
                {
                    Config = new Dictionary<string, KeyBindEntry>();
                }
            }
            catch (FileNotFoundException)
            {
                Config = new Dictionary<string, KeyBindEntry>();
                return;
            }
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(Config);
            File.WriteAllText(ConfFile, json);
        }
    }

    public enum Event
    {
        Note,
        Slider
    }
    public class KeyBindEntry
    {
        public string Mididevice { get; set; }
        public int NoteNumber { get; set; }
        public int Channel { get; set; }
        public Event Input { get; set; }

        public List<OBSCallBack> OBSCallBacksON = new List<OBSCallBack>();
        public List<OBSCallBack> OBSCallBacksOFF = new List<OBSCallBack>();
        public List<OBSCallBack> OBSCallBacksSlider = new List<OBSCallBack>();
        public SoundCallBack SoundCallBack;
    }

    public class SoundCallBack
    {
        public string File { get; }
        public string DeviceName { get; }
        public bool StopWhenReleased { get; }
        public bool Loop { get; }
        public float Volume { get; }

        public int Device { get; }

        [JsonConstructor]
        public SoundCallBack(string File, string DeviceName, bool StopWhenReleased, bool Loop, float Volume)
        {
            this.File = File;
            this.DeviceName = DeviceName;
            this.StopWhenReleased = StopWhenReleased;
            this.Loop = Loop;
            this.Volume = Volume;
            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities WOC = WaveOut.GetCapabilities(i);
                if(WOC.ProductName == DeviceName)
                {
                    Device = i;
                    return;
                }
            }
            Device = -1;
        }
    }

    public class OBSCallBack
    {
        private OBSControl obs;
        public string Action { get; set; }
        public List<string> Args { get; set; }
        public OBSCallBack()
        {
            obs = OBSControl.GetInstance();
        }

        public void Start(KeyBindEntry midiDevice)
        {
            if (obs == null)
            {
                obs = OBSControl.GetInstance();
            }
            var t = Task.Run(async delegate
            {
                await Task.Delay(obs.options.options.Delay);
                obs.DoAction(midiDevice, Action, Args);
            });
        }

        public void Start(KeyBindEntry midiDevice, float value)
        {
            if (obs == null)
            {
                obs = OBSControl.GetInstance();
            }
            var t = Task.Run(async delegate
            {
                await Task.Delay(obs.options.options.Delay);
                obs.DoAction(midiDevice, Action, Args, value);
            });
        }
    }
}
