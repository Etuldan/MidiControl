using Newtonsoft.Json.Linq;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Linq;
using System.Timers;
using Microsoft.VisualBasic.FileIO;
using System.Threading.Tasks;
using System.IO;

namespace MidiControl
{
    public class OBSControl : IExternalControl
    {
        private readonly OBSWebsocket obs;
        private readonly MIDIControlGUI gui;
        private static OBSControl _instance;
        private readonly Dictionary<string, float[]> FiltersMinMaxValues = new Dictionary<string, float[]>();
        public readonly Dictionary<string, string> Hotkeys = new Dictionary<string, string>();
        public readonly OptionsManagment options;
        private Timer timer;
        private readonly Dictionary<string, MIDIFeedback> feedbackScenes = new Dictionary<string, MIDIFeedback>();
        private List<FilterSettingsScene> filterSettings;
        private bool isConnected = true;
        private readonly string FilterLog;

        public OBSControl()
        {
            _instance = this;
            isConnected = false;
            obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;
            obs.Disconnected += Obs_Disconnected;
            obs.SourceFilterAdded += Obs_SourceFilterAdded;
            obs.SourceFilterRemoved += Obs_SourceFilteRemoved;

            gui = MIDIControlGUI.GetInstance();
            options = OptionsManagment.GetInstance();

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ConfFolder = Path.Combine(folder, "MIDIControl");
            FilterLog = Path.Combine(ConfFolder, Path.GetFileName("FilterLog.log"));

            string pathFilters = Path.Combine(ConfFolder, Path.GetFileName("filterminmax.csv"));
            try
            {
                using (TextFieldParser csvParser = new TextFieldParser(pathFilters))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    while (!csvParser.EndOfData)
                    {
                        string[] fields = csvParser.ReadFields();
                        FiltersMinMaxValues.Add(fields[0], new float[] { float.Parse(fields[1]), float.Parse(fields[2]) });
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
            }

            string pathHotkeys = Path.Combine(ConfFolder, Path.GetFileName("hotkeys.csv"));
            try
            {
                using (TextFieldParser csvParser = new TextFieldParser(pathHotkeys))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    while (!csvParser.EndOfData)
                    {
                        string[] fields = csvParser.ReadFields();
                        Hotkeys.Add(fields[0], fields[1]);
                    }
                }
            }
            catch (System.IO.FileNotFoundException)
            {
            }

            InitTimer();
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            timer.Interval = 10000;
        }
        public void Timer_Tick(Object source, ElapsedEventArgs e)
        {
            if(!obs.IsConnected)
            {
                ConnectDisconnect();
            }
        }

        public static OBSControl GetInstance()
        {
            return _instance;
        }

        public void ConnectDisconnect()
        {
            if (!isConnected)
            {
                try
                {
                    obs.Connect("ws://" + options.options.Ip, options.options.Password);
                    if(obs.IsConnected)
                    {
                        Version pluginVersion = new Version(obs.GetVersion().PluginVersion);
                        if (pluginVersion.CompareTo(new Version("4.9.0")) < 0)
                        {
                            throw new ErrorResponseException("Incompatible plugin Version. Please update your OBS-Websocket plugin");
                        }
                    }
                }
                catch (AuthFailureException)
                {
                    isConnected = false;
                }
            }
            else
            {
                obs.Disconnect();
                isConnected = false;
            }
        }

        private void Obs_SourceFilterAdded(OBSWebsocket sender, string sourceName, string filterName, string filterType, JObject _filterSettings)
        {
            Task.Run(() =>
            {
                filterSettings = GetFiltersSettings();
            });            
        }
        private void Obs_SourceFilteRemoved(OBSWebsocket sender, string sourceName, string filterName)
        {
            Task.Run(() =>
            {
                filterSettings = GetFiltersSettings();
            });
        }

        public void DoAction(KeyBindEntry keybind, string action, List<string> args)
        {
            if (!isConnected) return;
#if DEBUG
            Debug.WriteLine("OBSControl : DoAction");
#endif
            MIDIFeedback feedback = new MIDIFeedback(keybind);
            try
            {
                switch (action)
                {
                    case "switchScene":
                        if(!feedbackScenes.ContainsKey(args[0]))
                        {
                            feedbackScenes.Add(args[0], feedback);
                        }
                        obs.SetCurrentScene(args[0]);
                        foreach (KeyValuePair<string, MIDIFeedback> entry in feedbackScenes)
                        {
                            if(entry.Key == args[0])
                            {
                                entry.Value.SendOn();
                            }
                            else
                            {
                                entry.Value.SendOff();
                            }
                        }
                        break;
                    case "previewScene":
                        if(obs.StudioModeEnabled())
                        {
                            obs.SetPreviewScene(args[0]);
                        }
                        break;
                    case "mute":
                        foreach (string arg in args)
                        {
                            obs.SetMute(arg, true);
                        }
                        break;
                    case "unmute":
                        foreach (string arg in args)
                        {
                            obs.SetMute(arg, false);
                        }
                        break;
                    case "togglemute":
                        foreach (string arg in args)
                        {
                            bool currentMute = obs.GetMute(arg);
                            obs.ToggleMute(arg);
                            if (currentMute)
                            {
                                feedback.SendOff();
                            }
                            else
                            {
                                feedback.SendIn();
                            }
                        }
                        break;
                    case "hide":
                        ShowSources(args, false);
                        break;
                    case "show":
                        ShowSources(args, true);
                        break;
                    case "togglehide":
                        ToggleSources(feedback, args);
                        break;
                    case "hidefilter":
                        foreach (string arg in args)
                        {
                            ShowFilter(arg, false);
                        }
                        break;
                    case "showfilter":
                        foreach (string arg in args)
                        {
                            ShowFilter(arg, true);
                        }
                        break;
                    case "togglefilter":
                        foreach (string arg in args)
                        {
                            ToggleFilter(feedback, arg);
                        }
                        break;
                    case "mediaplay":
                        foreach (string arg in args)
                        {
                            obs.PlayPauseMedia(arg, false);
                        }
                        break;
                    case "mediastop":
                        foreach (string arg in args)
                        {
                            obs.StopMedia(arg);
                        }
                        break;
                    case "mediarestart":
                        foreach (string arg in args)
                        {
                            obs.RestartMedia(arg);
                        }
                        break;
                    case "transition":
                        obs.SetCurrentTransition(args[0]);
                        obs.SetTransitionDuration(Int32.Parse(args[1]));
                        break;
                    case "hotkey":
                        foreach (string arg in args)
                        {
                            if (Hotkeys.TryGetValue(arg, out string value) == true)
                            {
                                obs.TriggerHotkeyByName(value);
                            }
                        }
                        break;
                    case "misc":
                        foreach (string arg in args)
                        {
                            OutputStatus streamstatus;
                            switch (arg)
                            {
                                case "Start Stream":
                                    obs.StartStreaming();
                                    break;
                                case "Stop Stream":
                                    obs.StopStreaming();
                                    break;
                                case "Toggle Stream":
                                    streamstatus = obs.GetStreamingStatus();
                                    obs.StartStopStreaming();
                                    if (streamstatus.IsStreaming)
                                    {
                                        feedback.SendOff();
                                    }
                                    else
                                    {
                                        feedback.SendIn();
                                    }
                                    break;
                                case "Start Record":
                                    obs.StartRecording();
                                    break;
                                case "Stop Record":
                                    obs.StopRecording();
                                    break;
                                case "Toggle Record":
                                    streamstatus = obs.GetStreamingStatus();
                                    obs.StartStopRecording();
                                    if (streamstatus.IsRecording)
                                    {
                                        feedback.SendOff();
                                    }
                                    else
                                    {
                                        feedback.SendIn();
                                    }
                                    break;
                                case "Play/Pause Record":
                                    try
                                    {
                                        obs.PauseRecording();
                                        feedback.SendIn();
                                    }
                                    catch (ErrorResponseException e)
                                    {
                                        if(e.Message.Equals("recording already paused"))
                                        {
                                            obs.ResumeRecording();
                                            feedback.SendOff();
                                        }
                                    }
                                    break;
                                case "Pause Record":
                                    obs.PauseRecording();
                                    break;
                                case "Resume Record":
                                    obs.ResumeRecording();
                                    break;
                                case "Save Record":
                                    obs.SaveReplayBuffer();
                                    break;
                                case "Transition To Program (Studio)":
                                    obs.TransitionToProgram();
                                    break;
                                case "Toggle Studio Mode":
                                    obs.ToggleStudioMode();
                                    break;
                            }
                        }
                        break;
                }
            }
            catch (ErrorResponseException
#if DEBUG
e
#endif
            )
            {
#if DEBUG
                Debug.WriteLine("OBSControl : ErrorResponseException " + e);
#endif
            }
        }
        public void DoAction(KeyBindEntry _, string action, List<string> args, float value)
        {
            if (!isConnected) return;

            switch (action)
            {
                case "transition":
                    obs.SetTransitionDuration((int)(value * 5000));
                    break;
                case "volume":
                    foreach (string arg in args)
                    {
                        obs.SetVolume(arg, value, false);
                    }
                    break;
                case "transitionSlider":
                    obs.SetTBarPosition(value);
                    break;
                case "filterSettings":
                    SetFilterProperties(args[0], args[1], value);
                    break;
                default:
                    break;
            }
        }


        private void ToggleFilter(MIDIFeedback feedback, string filter)
        {
            if (!isConnected) return;

            bool state = false;

            foreach (string scene in this.GetScenes())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(scene))
                {
                    if (filtersetting.Name == filter)
                    {
                        FilterSettings setting = obs.GetSourceFilterInfo(scene, filter);
                        bool currentVisibility = setting.IsEnabled;
                        obs.SetSourceFilterVisibility(scene, filter, !currentVisibility);
                        if (currentVisibility == false)
                        {
                            state = true;
                        }
                    }
                }
            }

            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    if(filtersetting.Name == filter)
                    {
                        FilterSettings setting = obs.GetSourceFilterInfo(source, filter);
                        bool currentVisibility = setting.IsEnabled;
                        obs.SetSourceFilterVisibility(source, filter, !currentVisibility);
                        if(currentVisibility == false)
                        {
                            state = true;
                        }
                    }
                }
            }
            if (state == true)
            {
                feedback.SendOn();
            }
            else
            {
                feedback.SendOff();
            }
        }
        private void ShowFilter(string filter, bool show)
        {
            if (!isConnected) return;

            foreach (string scene in this.GetScenes())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(scene))
                {
                    if (filtersetting.Name == filter)
                    {
                        obs.SetSourceFilterVisibility(scene, filter, show);
                    }
                }
            }

            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    if (filtersetting.Name == filter)
                    {
                        obs.SetSourceFilterVisibility(source, filter, show);
                    }
                }
            }
        }
        private void ToggleSources(MIDIFeedback feedback, List<string> sources)
        {
            if (!isConnected) return;

            Dictionary<SourceScene, bool> sourcesName = new Dictionary<SourceScene, bool>();
            List<OBSScene> scenes = obs.ListScenes();
            bool state = false;

            foreach (OBSScene scene in scenes)
            {
                foreach (SceneItem item in scene.Items)
                {
                    if (sources.Contains(item.SourceName))
                    {
                        sourcesName.Add(new SourceScene() { Source = item.SourceName, Scene = scene.Name }, item.Render);
                        if (item.GroupChildren != null)
                        {
                            foreach (SceneItem child in item.GroupChildren)
                            {
                                sourcesName.Add(new SourceScene() { Source = child.SourceName, Scene = scene.Name }, child.Render);
                            }
                        }
                    }
                    if (item.GroupChildren != null)
                    {
                        foreach (SceneItem child in item.GroupChildren)
                        {
                            if (sources.Contains(child.SourceName))
                            {
                                sourcesName.Add(new SourceScene() { Source = child.SourceName, Scene = scene.Name }, child.Render);
                            }
                        }
                    }
                }
            }
            foreach (KeyValuePair<SourceScene, bool> entry in sourcesName)
            {
                obs.SetSourceRender(entry.Key.Source, !entry.Value, entry.Key.Scene);
                if (entry.Value == false)
                {
                    state = true;
                }
            }

            if (state == true)
            {
                feedback.SendOn();
            }
            else
            {
                feedback.SendOff();
            }

            if (obs.StudioModeEnabled() == true)
            {
                int oldTransition = obs.GetTransitionDuration();
                obs.SetTransitionDuration(0);
                OBSScene displayScene = obs.GetCurrentScene();
                OBSScene previewScene = obs.GetPreviewScene();
                obs.SetPreviewScene(displayScene);
                obs.TransitionToProgram();
                obs.SetPreviewScene(previewScene);
                obs.SetTransitionDuration(oldTransition);
            }
        }
        private void ShowSources(List<string> sources, bool show)
        {
            if (!isConnected) return;

            List<SourceScene> sourcesName = new List<SourceScene>();
            List<OBSScene> scenes = obs.ListScenes();
            foreach (OBSScene scene in scenes)
            {
                foreach (SceneItem item in scene.Items)
                {
                    if (sources.Contains(item.SourceName))
                    {
                        sourcesName.Add(new SourceScene() { Source = item.SourceName, Scene = scene.Name } );
                        if (item.GroupChildren != null)
                        {
                            foreach (SceneItem child in item.GroupChildren)
                            {
                                sourcesName.Add(new SourceScene() { Source = child.SourceName, Scene = scene.Name } );
                            }
                        }
                    }
                    if (item.GroupChildren != null)
                    {
                        foreach (SceneItem child in item.GroupChildren)
                        {
                            if (sources.Contains(child.SourceName))
                            {
                                sourcesName.Add(new SourceScene() { Source = child.SourceName, Scene = scene.Name } );
                            }
                        }
                    }
                }
            }

            foreach (SourceScene sourcescene in sourcesName)
            {
                obs.SetSourceRender(sourcescene.Source, show, sourcescene.Scene);
            }
            if(obs.StudioModeEnabled() == true)
            {
                int oldTransition = obs.GetTransitionDuration();
                obs.SetTransitionDuration(0);
                OBSScene displayScene = obs.GetCurrentScene();
                OBSScene previewScene = obs.GetPreviewScene();
                obs.SetPreviewScene(displayScene);
                obs.TransitionToProgram();
                obs.SetPreviewScene(previewScene);
                obs.SetTransitionDuration(oldTransition);
            }
        }

        private void SetFilterProperties(string filterName, string property, float value)
        {
            if (!isConnected) return;

            foreach (FilterSettingsScene filterSetting in filterSettings)
            {
                if (FiltersMinMaxValues.TryGetValue(filterSetting.FilterSettings.Type + "." + property, out float[] values) == true)
                {
                    float min = values[0];
                    float max = values[1];
                    value = value * (max - min) + min;

                    if (filterSetting.FilterSettings.Name == filterName)
                    {
                        JObject o = new JObject(new JProperty(property, value));
                        obs.SetSourceFilterSettings(filterSetting.Scene, filterName, o);
                    }
                }
                else if(filterSetting.FilterSettings.Name == filterName)
                {
                    using (StreamWriter w = File.AppendText(FilterLog))
                    {
                        w.WriteLine(filterSetting.FilterSettings.Name + " is missing. Add a new line in filterminmax.csv (replace MinValue and MaxValue)'" + filterSetting.FilterSettings.Type + "." + property + ",MinValue,MaxValue'");
                    }
                }
            }
        }
        public List<string> GetFilterProperties(string filterName)
        {
            List<string> listProperties = new List<string>();
            if (!isConnected) return listProperties;

            List<FilterSettingsScene> list = GetFiltersSettings();
            foreach (FilterSettingsScene item in list)
            {         
                if(item.FilterSettings.Name == filterName)
                {
                    foreach (var setting in item.FilterSettings.Settings)
                    {
                        listProperties.Add(setting.Key);
                    }
                }
            }
            return listProperties;
        }
        public List<FilterSettingsScene> GetFiltersSettings()
        {
            List<FilterSettingsScene> filters = new List<FilterSettingsScene>();
            if (!isConnected) return filters;

            foreach (string scene in this.GetScenes())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(scene))
                {
                    filters.Add(new FilterSettingsScene() { Scene = scene, FilterSettings = filtersetting });
                }
            }

            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    filters.Add(new FilterSettingsScene() { Scene = source, FilterSettings = filtersetting });
                }
            }
            return filters;
        }
        public List<string> GetFilters()
        {
            List<string> filtersString = new List<string>();
            if (!isConnected) return filtersString;

            foreach (string scene in this.GetScenes())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(scene))
                {
                    filtersString.Add(filtersetting.Name);
                }
            }

            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    filtersString.Add(filtersetting.Name);
                }
            }
            return filtersString;
        }
        public List<string> GetScenes()
        {
            List<string> scenesString = new List<string>();
            if (!isConnected) return scenesString;

            List<OBSScene> scenes = obs.ListScenes();
            foreach (OBSScene scene in scenes)
            {
                scenesString.Add(scene.Name);
            }
            scenesString.Sort((x, y) => string.Compare(x, y));
            return scenesString;
        }
        public List<string> GetSources()
        {
            List<string> sourceString = new List<string>();
            if (!isConnected) return sourceString;

            List<OBSScene> scenes = obs.ListScenes();
            foreach (OBSScene scene in scenes)
            {
                foreach (SceneItem source in scene.Items)
                {
                    sourceString.Add(source.SourceName);
                    if (source.GroupChildren != null)
                    {
                        foreach (SceneItem subfield in source.GroupChildren)
                        {
                            sourceString.Add(subfield.SourceName);
                        }
                    }
                }
            }
            List<SourceInfo> sources = obs.GetSourcesList();
            foreach (SourceInfo source in sources)
            {
                sourceString.Add(source.Name);
            }

            sourceString.Sort((x, y) => string.Compare(x, y));
            return sourceString.Distinct().ToList();
        }
        public List<string> GetTransitions()
        {
            if (!isConnected) return new List<string>();
            return obs.ListTransitions();
        }
        public List<string> GetFilters(string source)
        {
            List<string> filters = new List<string>();
            if (!isConnected) return filters;

            List<FilterSettings> listFilters = obs.GetSourceFilters(source);
            foreach (FilterSettings filter in listFilters)
            {
                filters.Add(filter.Name);
            }
            return filters;
        }



        private void Obs_Connected(object sender, EventArgs e)
        {
            isConnected = true;
            Task.Run(() =>
            {
                filterSettings = GetFiltersSettings();
            });
            gui.Invoke(gui.OBSControlDelegate, new object[] {
                    true
                });
            timer.Enabled = false;
        }
        private void Obs_Disconnected(object sender, EventArgs e)
        {
            gui.Invoke(gui.OBSControlDelegate, new object[] {
                    false
                });
            isConnected = false;
            timer.Enabled = true;
        }
        public bool IsEnabled()
        {
            return isConnected;
        }
    }

    public class FilterSettingsScene
    {
        public string Scene { get; set; }
        public FilterSettings FilterSettings { get; set; }
    }

    public class SourceScene
    {
        public string Source { get; set; }
        public string Scene { get; set; }
    }
}
