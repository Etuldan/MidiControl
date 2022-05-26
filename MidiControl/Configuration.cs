using NAudio.Wave;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiControl
{
    class Configuration
    {
        public Dictionary<string, KeyBindEntry> Config { get; set; }
        private static Configuration _instance;
        private readonly string ConfFolder;
        private string ConfFile;
        public string CurrentProfile;
        private readonly MIDIControlGUI gui;
        private static readonly Regex removeInvalidChars = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Configuration(MIDIControlGUI gui)
        {
            _instance = this;
            this.gui = gui;
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ConfFolder = Path.Combine(folder, "MIDIControl");
            CurrentProfile = "Default";
            ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
            Directory.CreateDirectory(ConfFolder);
            LoadCurrentProfile();
        }

        public static Configuration GetInstance()
        {
            return _instance;
        }

        public string[] GetAllProfiles()
        {
            List<string> output = new List<string>
            {
                "Default"
            };

            var filesEndingIn = Directory.EnumerateFiles(ConfFolder).Where(f => f.EndsWith(".json") && f.Contains("keybinds-"));
            foreach(var item in filesEndingIn)
            {
                string test = Path.GetFileNameWithoutExtension(item).Substring("keybinds-".Length);
                output.Add(test);
            }

            return output.ToArray();
        }

        public string[] RemoveProfile(string ProfileToRemove)
        {
            string FileToDelete = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(ProfileToRemove, "_") + ".json"));
            File.Delete(FileToDelete);
            return GetAllProfiles();
        }

        private void LoadCurrentProfile()
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

        public void LoadProfile(string profile = null)
        {
            CurrentProfile = profile;
            if (profile == null || profile == "Default")
            {
                ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
            } 
            else
            {
                ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(profile, "_") + ".json"));
            }
            LoadCurrentProfile();
            try
            {
                gui.Invoke(gui.SwitchProfileControlDelegate);
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void SaveCurrentProfile()
        {
			try {
				string json = JsonConvert.SerializeObject(Config);
				File.WriteAllText(ConfFile, json);

				MessageBox.Show("Configuration '" + CurrentProfile + "' saved successfully!");
			} catch(Exception ex) {
				MessageBox.Show("Error occurred while saving: " + ex.ToString());
			}
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
        public MediaCallBack MediaCallBack;
        public MediaCallBack MediaCallBackOFF;
        public TwitchCallBack TwitchCallBackON;
        public TwitchCallBack TwitchCallBackOFF;
        public MIDIControlCallBack MIDIControlCallBackON;
        public MIDIControlCallBack MIDIControlCallBackOFF;
        public GoXLRCallBack GoXLRCallBackON;
        public GoXLRCallBack GoXLRCallBackOFF;
    }

    public enum MediaType
    {
        PLAY,
        PREVIOUS,
        NEXT
    }

    public class MediaCallBack
    {
        public MediaType MediaType { get; set; }

        public MediaCallBack(MediaType type)
        {
            this.MediaType = type;
        }
    }

    public class TwitchCallBack
    {
        public string Channel { get; set; }
        public string Messsage { get; set; }
    }

    public class GoXLRCallBack
    {
        public int Action { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
    }

    public class MIDIControlCallBack
    {
        public bool StopAllSound { get; set; }
        public string SwitchToProfile { get; set; }
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
