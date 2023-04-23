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
		public bool Unsaved = false;
        private readonly MIDIControlGUI gui;
        private static readonly Regex removeInvalidChars = new Regex($"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Configuration(MIDIControlGUI gui, string initialProfile)
        {
            _instance = this;
            this.gui = gui;
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ConfFolder = Path.Combine(folder, "MIDIControl");

			CurrentProfile = initialProfile; // "Default";
			if(initialProfile == "Default" || initialProfile == null) {
				CurrentProfile = "Default";
				ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
			} else {
				ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(initialProfile, "_") + ".json"));

				if(!File.Exists(ConfFile)) {
					CurrentProfile = "Default";
					ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
				}
			}

            Directory.CreateDirectory(ConfFolder);
            LoadCurrentProfile();
        }

        public static Configuration GetInstance()
        {
            return _instance;
        }

        public string[] GetAllProfiles()
        {
            var output = new List<string>
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
            var FileToDelete = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(ProfileToRemove, "_") + ".json"));
            File.Delete(FileToDelete);
            return GetAllProfiles();
        }

		public bool DoesProfileExist(string profile) {
			var FileToSearch = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(profile, "_") + ".json"));
			return File.Exists(FileToSearch);
		}

        public bool DoesKeybindExist(string key)
        {
            return this.Config.ContainsKey(key);
        }

        private void LoadCurrentProfile()
        {
            try
            {
				Unsaved = false;
				var json = File.ReadAllText(ConfFile);
                Config = JsonConvert.DeserializeObject<Dictionary<string, KeyBindEntry>>(json);
                Config ??= new Dictionary<string, KeyBindEntry>();
            }
            catch (FileNotFoundException)
            {
                Config = new Dictionary<string, KeyBindEntry>();
                return;
            }
        }

        public void LoadProfile(string profile = "Default")
        {
            CurrentProfile = profile;
            if (profile == "Default")
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
				var json = JsonConvert.SerializeObject(Config);
				File.WriteAllText(ConfFile, json);

				Unsaved = false;

				//MessageBox.Show("Configuration '" + CurrentProfile + "' saved successfully!");
			} catch(Exception ex) {
				MessageBox.Show("Error occurred while saving: " + ex.ToString());
			}
        }

		public void SaveCurrentProfileAs(string newname)
		{
			if(newname == "Default") {
				ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds.json"));
			} else {
				ConfFile = Path.Combine(ConfFolder, Path.GetFileName("keybinds-" + removeInvalidChars.Replace(newname, "_") + ".json"));
			}
			
			try {
				var json = JsonConvert.SerializeObject(Config);
				File.WriteAllText(ConfFile, json);

				Unsaved = false;

				CurrentProfile = newname;
				//MessageBox.Show("Configuration '" + CurrentProfile + "' saved successfully!");
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

		public string Summarize() {
			var summary = new List<string>();
			if(OBSCallBacksON.Count > 0) {
				var items = new List<string>();
				foreach(var item in OBSCallBacksON) {
                    if(item.Args != null)
                        items.Add(item.Action + ": " + string.Join(", ", item.Args.ToArray()));
                    else
                        items.Add(item.Action);
				}
				summary.Add("OBS (on): " + string.Join("; ", items));
				
			}
			if(OBSCallBacksOFF.Count > 0) {
				var items = new List<string>();
				foreach(var item in OBSCallBacksOFF) {
                    if(item.Args != null)
                        items.Add(item.Action + ": " + string.Join(", ", item.Args.ToArray()));
                    else
                        items.Add(item.Action);
                }
				summary.Add("OBS (off): " + string.Join("; ", items));
			}
			if(OBSCallBacksSlider.Count > 0) {
				var items = new List<string>();
				foreach(var item in OBSCallBacksSlider) {
                    if(item.Args != null)
                        items.Add(item.Action + ": " + string.Join(", ", item.Args.ToArray()));
                    else
                        items.Add(item.Action);
                }
				summary.Add("(adjust) " + string.Join("; ", items));
			}
			if(SoundCallBack != null) {
				var soundFile = Path.GetFileName(SoundCallBack.File);
				var action = "Play '" + soundFile + "' on " + SoundCallBack.DeviceName;
				summary.Add("Sound: " + action);
			}
			if(MediaCallBack != null) {
				var action = MediaCallBack.MediaType.ToString();
				summary.Add("Media (on): " + action);
			}
			if(MediaCallBackOFF != null) {
				var action = MediaCallBackOFF.MediaType.ToString();
				summary.Add("Media (off): " + action);
			}
			if(TwitchCallBackON != null) {
				var action = "Send message on channel " + TwitchCallBackON.Channel;
				summary.Add("Twitch (on): " + action);
			}
			if(TwitchCallBackOFF != null) {
				var action = "Send message on channel " + TwitchCallBackOFF.Channel;
				summary.Add("Twitch (off): " + action);
			}
			if(MIDIControlCallBackON != null) {
				var action = new List<string>();
				if(MIDIControlCallBackON.StopAllSound)
					action.Add("Stop all sounds");
				if(MIDIControlCallBackON.SwitchToProfile != null)
					action.Add("Switch to profile '" + MIDIControlCallBackON.SwitchToProfile);

				summary.Add("MIDIControl (on): " + string.Join("; ", action));
			}
			if(MIDIControlCallBackOFF != null) {
				var action = new List<string>();
				if(MIDIControlCallBackOFF.StopAllSound)
					action.Add("Stop all sounds");
				if(MIDIControlCallBackOFF.SwitchToProfile != null)
					action.Add("Switch to profile '" + MIDIControlCallBackOFF.SwitchToProfile);

				summary.Add("MIDIControl (on): " + string.Join("; ", action));
			}
			if(GoXLRCallBackON != null) {
				var action = string.Empty;
				switch(GoXLRCallBackON.Action) {
					case 0: action = "Mute: "; break;
					case 1: action = "Unmute: "; break;
					case 2: action = "Toggle: "; break;
				}
				action += "Input " + GoXLRCallBackON.Input + ", Output " + GoXLRCallBackON.Output;
				summary.Add("GoXLR (on): " + action);
			}
			if(GoXLRCallBackOFF != null) {
				var action = string.Empty;
				switch(GoXLRCallBackOFF.Action) {
					case 0: action = "Mute: "; break;
					case 1: action = "Unmute: "; break;
					case 2: action = "Toggle: "; break;
				}
				action += "Input " + GoXLRCallBackOFF.Input + ", Output " + GoXLRCallBackOFF.Output;
				summary.Add("GoXLR (off): " + action);
			}

			return string.Join(" / ", summary);
		}
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
		public bool StopAllOtherSounds { get; }

        public int Device { get; }

        [JsonConstructor]
        public SoundCallBack(string File, string DeviceName, bool StopWhenReleased, bool Loop, float Volume, bool StopAllOtherSounds)
        {
            this.File = File;
            this.DeviceName = DeviceName;
            this.StopWhenReleased = StopWhenReleased;
            this.Loop = Loop;
            this.Volume = Volume;
			this.StopAllOtherSounds = StopAllOtherSounds;

            for (var i = 0; i < WaveOut.DeviceCount; i++)
            {
                var WOC = WaveOut.GetCapabilities(i);
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
            obs ??= OBSControl.GetInstance();
            var t = Task.Run(async delegate
            {
                await Task.Delay(obs.options.options.Delay);
                obs.DoAction(midiDevice, Action, Args);
            });
        }

        public void Start(KeyBindEntry midiDevice, float value)
        {
            obs ??= OBSControl.GetInstance();
            var t = Task.Run(async delegate
            {
                await Task.Delay(obs.options.options.Delay);
                obs.DoAction(midiDevice, Action, Args, value);
            });
        }
    }
}
