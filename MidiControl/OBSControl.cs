using Newtonsoft.Json.Linq;
using OBSWebsocketDotNet;
using OBSWebsocketDotNet.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace MidiControl
{
    public class OBSControl : IExternalControl
    {
        private readonly OBSWebsocket obs;
        private readonly MIDIControlGUI gui;
        private static OBSControl _instance;
        public readonly OptionsManagment options;
        private Timer timer;

        public OBSControl()
        {
            _instance = this;
            obs = new OBSWebsocket();
            obs.Connected += Obs_Connected;
            obs.Disconnected += Obs_Disconnected;

            gui = MIDIControlGUI.GetInstance();
            options = OptionsManagment.GetInstance();

            InitTimer();
        }

        public void InitTimer()
        {
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(Timer_Tick);
            timer.Interval = 10000;
        }
        public void Timer_Tick(Object source, System.Timers.ElapsedEventArgs e)
        {
            if(options.options.AutoReconnect && !obs.IsConnected)
            {
                Connect();
            }
        }

        public static OBSControl GetInstance()
        {
            return _instance;
        }

        public void Connect()
        {
            if (!obs.IsConnected)
            {
                try
                {
                    obs.Connect("ws://" + options.options.Ip, options.options.Password);
                    if(obs.IsConnected)
                    {
                        Version pluginVersion = new Version(obs.GetVersion().PluginVersion);
                        if (pluginVersion.CompareTo(new Version("4.8.0")) < 0)
                        {
                            throw new ErrorResponseException("Incompatible plugin Version. Please update your OBS-Websocket plugin");
                        }
                    }
                }
                catch (AuthFailureException)
                {

                }
            }
            else
            {
                obs.Disconnect();
            }
        }

        public void DoAction(string action, List<string> args)
        {
            if (!obs.IsConnected) return;

            try
            {
                switch (action)
                {
                    case "switchScene":
                        obs.SetCurrentScene(args[0]);
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
                            obs.ToggleMute(arg);
                        }
                        break;
                    case "hide":
                        ShowSources(args, false);
                        break;
                    case "show":
                        ShowSources(args, true);
                        break;
                    case "togglehide":
                        ToggleSources(args);
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
                            ToggleFilter(arg);
                        }
                        break;
                    case "transition":
                        obs.SetCurrentTransition(args[0]);
                        obs.SetTransitionDuration(Int32.Parse(args[1]));
                        break;
                    case "transitionTo":
                        if (obs.StudioModeEnabled() == true)
                        {
                            obs.TransitionToProgram();
                        }
                        break;
                    case "misc":
                        foreach (string arg in args)
                        {
                            switch (arg)
                            {
                                case "Start Stream":
                                    obs.StartStreaming();
                                    break;
                                case "Stop Stream":
                                    obs.StopStreaming();
                                    break;
                                case "Toggle Stream":
                                    obs.StartStopStreaming();
                                    break;
                                case "Start Record":
                                    obs.StartRecording();
                                    break;
                                case "Stop Record":
                                    obs.StopRecording();
                                    break;
                                case "Play/Pause Record":
                                    try
                                    {
                                        obs.SendRequest("PauseRecording");
                                    }
                                    catch (ErrorResponseException e)
                                    {
                                        if(e.Message.Equals("recording already paused"))
                                        {
                                            obs.SendRequest("ResumeRecording");
                                        }
                                    }
                                    break;
                                case "Pause Record":
                                    obs.SendRequest("PauseRecording");
                                    break;
                                case "Resume Record":
                                    obs.SendRequest("ResumeRecording");
                                    break;
                                case "Transition To Program (Studio)":
                                    obs.TransitionToProgram();
                                    break;
                                case "Toggle Record":
                                    obs.StartStopRecording();
                                    break;
                            }
                        }
                        break;
                }
            }
            catch (ErrorResponseException)
            {
            }
        }
        public void DoAction(string action, List<string> args, float value)
        {
            if (!obs.IsConnected) return;

            switch (action)
            {
                case "transition":
                    obs.SetTransitionDuration((int)(value * 5000));
                    break;
                case "volume":
                    foreach (string arg in args)
                    {
                        JObject o = JObject.FromObject(new
                        {
                            source = arg,
                            volume = value,
                            useDecibel = false
                        });
                        obs.SendRequest("SetVolume", o);
                    }
                    break;
                default:
                    break;
            }
        }


        private void ToggleFilter(string filter)
        {
            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    if(filtersetting.Name == filter)
                    {
                        JObject o = JObject.FromObject(new
                        {
                            sourceName = source,
                            filterName = filter
                        });
                        JObject result = obs.SendRequest("GetSourceFilterInfo", o);
                        bool currentVisibilty = result.SelectToken("enabled").Value<bool>();

                        o = JObject.FromObject(new
                        {
                            sourceName = source,
                            filterName = filter,
                            filterEnabled = !currentVisibilty
                        });
                        obs.SendRequest("SetSourceFilterVisibility", o);
                    }
                }
            }
        }
        private void ShowFilter(string filter, bool show)
        {
            foreach (string source in this.GetSources())
            {
                foreach (FilterSettings filtersetting in obs.GetSourceFilters(source))
                {
                    if (filtersetting.Name == filter)
                    {
                        JObject o = JObject.FromObject(new
                        {
                            sourceName = source,
                            filterName = filter,
                            filterEnabled = show
                        });
                        obs.SendRequest("SetSourceFilterVisibility", o);
                    }
                }
            }
        }
        private void ToggleSources(List<string> sources)
        {
            Dictionary<SourceScene, bool> sourcesName = new Dictionary<SourceScene, bool>();
            List<OBSScene> scenes = obs.ListScenes();

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

        public List<string> GetFilters()
        {
            List<string> filtersString = new List<string>();
            if (!obs.IsConnected) return filtersString;

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
            if (!obs.IsConnected) return scenesString;

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
            if (!obs.IsConnected) return sourceString;

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
            if (!obs.IsConnected) return new List<string>();
            return obs.ListTransitions();
        }
        public List<string> GetFilters(string source)
        {
            List<FilterSettings> listFilters = obs.GetSourceFilters(source);
            List<string> filters = new List<string>();
            foreach (FilterSettings filter in listFilters)
            {
                filters.Add(filter.Name);
            }
            return filters;
        }



        private void Obs_Connected(object sender, EventArgs e)
        {
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
            timer.Enabled = true;
        }
        public bool IsEnabled()
        {
            return obs.IsConnected;
        }
    }

    public class SourceScene
    {
        public string Source { get; set; }
        public string Scene { get; set; }
    }
}
