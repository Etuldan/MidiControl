using MidiControl.Control;
using NAudio.Midi;
using NAudio.Wave;
using System;
using System.Collections.Generic;
#if DEBUG
using System.Diagnostics;
#endif
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace MidiControl
{
    public partial class EntryGUI : Form
    {
        private delegate void MIDIDelegateHandler(string note, string device, string channel);
        private readonly MIDIDelegateHandler MIDIDelegate;

        private readonly List<MidiInCustom> midiDevice = new List<MidiInCustom>();
        private readonly Configuration conf;
        private readonly MIDIListener midi;
        private readonly OBSControl obs;

        private readonly Dictionary<string, string[]> CheckToCombo = new Dictionary<string, string[]>();

        private string Device;
        private int Channel;
        private int Note;
        private Event Input;

		private List<Panel> panels;
		private Size PanelSize = new Size(385, 301);
		private Size ProperWindowSize = new Size(632, 446);
		private Point PanelLocation = new Point(218, 60);

        private readonly string EntryName;

		private KeyBindEntry previousSettings = null;
		private List<string> keybindErrors;

		public EntryGUI()
        {
            this.obs = OBSControl.GetInstance();
            conf = Configuration.GetInstance();
			this.keybindErrors = new List<string>();

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            InitControls();

            MIDIDelegate = new MIDIDelegateHandler(UpdateNote);

            midi = MIDIListener.GetInstance();
            midi.DisableListening();
            foreach (KeyValuePair<string, MidiInCustom> entry in midi.midiInInterface)
            {
                entry.Value.MessageReceived += MidiIn_MessageReceived;
                midiDevice.Add(entry.Value);
            }

			DialogResult = DialogResult.Cancel;

			// form opened with no keybind to edit
			txtKeybindSummary.Visible = false;
		}

        public EntryGUI(string name, KeyBindEntry keybind)
        {
            this.obs = OBSControl.GetInstance();
            conf = Configuration.GetInstance();
			this.EntryName = name;
			this.keybindErrors = new List<string>();
			this.previousSettings = keybind;

			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            InitControls();

			// show text summary of the current settings on the main panel
			txtKeybindSummary.Text = "Current keybind settings:\r\n\r\n" + keybind.Summarize().Replace(" / ", "\r\n");

			BtnAdd.Text = "Modify";
            Text = "Edit MIDI Keybind";

            Device = keybind.Mididevice;
            Note = keybind.NoteNumber;
            Channel = keybind.Channel;
            Input = keybind.Input;

            TxtBoxName.Text = name;
            TxtBoxNote.Text = Note.ToString();
            TxtBoxDevice.Text = Device;
            TxtBoxChannel.Text = Channel.ToString();

            if(Input == Event.Note) {
                LblNote.Text = "Note";
                TxtBoxNote.Text = MIDIListener.getNoteString(Note);
            } else if(Input == Event.Slider) {
                LblNote.Text = "CC";
            }

			if (keybind.MediaCallBack != null)
            {
                switch (keybind.MediaCallBack.MediaType)
                {
                    case MediaType.PLAY:
                        ChkBoxMediaKeyPlayPress.Checked = true;
                        break;
                    case MediaType.NEXT:
                        ChkBoxMediaKeyNextPress.Checked = true;
                        break;
                    case MediaType.PREVIOUS:
                        ChkBoxMediaKeyPreviousPress.Checked = true;
                        break;
                    default:
                        break;
                }
            }
            if (keybind.MediaCallBackOFF != null)
            {
                switch (keybind.MediaCallBackOFF.MediaType)
                {
                    case MediaType.PLAY:
                        ChkBoxMediaKeyPlayRelease.Checked = true;
                        break;
                    case MediaType.NEXT:
                        ChkBoxMediaKeyNextRelease.Checked = true;
                        break;
                    case MediaType.PREVIOUS:
                        ChkBoxMediaKeyPreviousRelease.Checked = true;
                        break;
                    default:
                        break;
                }
            }

            if (keybind.GoXLRCallBackON != null)
            {
                if (keybind.GoXLRCallBackON.Action == (int)GoXLRControl.Action.Toggle)
                {
                    RadioButtonToggleXLRPress.Checked = true;
                    CboBoxXLRInputPress.SelectedItem = keybind.GoXLRCallBackON.Input;
                    CboBoxXLROutputPress.SelectedItem = keybind.GoXLRCallBackON.Output;
                }
                if (keybind.GoXLRCallBackON.Action == (int)GoXLRControl.Action.Mute)
                {
                    RadioButtonMuteXLRPress.Checked = true;
                    CboBoxXLRInputPress.SelectedItem = keybind.GoXLRCallBackON.Input;
                    CboBoxXLROutputPress.SelectedItem = keybind.GoXLRCallBackON.Output;
                }
                if (keybind.GoXLRCallBackON.Action == (int)GoXLRControl.Action.UnMute)
                {
                    RadioButtonUnMuteXLRPress.Checked = true;
                    CboBoxXLRInputPress.SelectedItem = keybind.GoXLRCallBackON.Input;
                    CboBoxXLROutputPress.SelectedItem = keybind.GoXLRCallBackON.Output;
                }
            }
            if (keybind.GoXLRCallBackOFF != null)
            {
                if (keybind.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.Toggle)
                {
                    RadioButtonToggleXLRRelease.Checked = true;
                    CboBoxXLRInputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Input;
                    CboBoxXLROutputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Output;
                }
                if (keybind.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.Mute)
                {
                    RadioButtonMuteXLRRelease.Checked = true;
                    CboBoxXLRInputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Input;
                    CboBoxXLROutputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Output;
                }
                if (keybind.GoXLRCallBackOFF.Action == (int)GoXLRControl.Action.UnMute)
                {
                    RadioButtonUnMuteXLRRelease.Checked = true;
                    CboBoxXLRInputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Input;
                    CboBoxXLROutputRelease.SelectedItem = keybind.GoXLRCallBackOFF.Output;
                }
            }

            if (keybind.TwitchCallBackON != null)
            {
                TxtBoxTwitchChannelPress.Text = keybind.TwitchCallBackON.Channel;
                TxtBoxTwitchMessagePress.Text = keybind.TwitchCallBackON.Messsage;
            }
            if (keybind.TwitchCallBackOFF != null)
            {
                TxtBoxTwitchChannelRelease.Text = keybind.TwitchCallBackOFF.Channel;
                TxtBoxTwitchMessageRelease.Text = keybind.TwitchCallBackOFF.Messsage;
            }

            if (keybind.SoundCallBack != null)
            {
                ChkBoxEnableAudio.Checked = true;
                TxtBoxAudioFile.Text = keybind.SoundCallBack.File;
                CboBoxAudioDevice.Text = keybind.SoundCallBack.DeviceName;
                ChkBoxAudioStop.Checked = keybind.SoundCallBack.StopWhenReleased;
                chkBoxLoop.Checked = keybind.SoundCallBack.Loop;
                volumeSlider.Volume = keybind.SoundCallBack.Volume == 0.0f ? 1.0f : keybind.SoundCallBack.Volume;
				chkStopAllOthers.Checked = keybind.SoundCallBack.StopAllOtherSounds;
            }

            if (keybind.MIDIControlCallBackON != null)
            {
                if(keybind.MIDIControlCallBackON.StopAllSound == true)
                {
                    ChkBoxStopAllSoundPress.Checked = true;
                }
                if(keybind.MIDIControlCallBackON.SwitchToProfile != null &&
					keybind.MIDIControlCallBackON.SwitchToProfile != "")
                {
                    ChkBoxSwitchToProfilePress.Checked = true;
                    CboBoxProfilePress.SelectedItem = keybind.MIDIControlCallBackON.SwitchToProfile;
                }
            }
            if (keybind.MIDIControlCallBackOFF != null)
            {
                if (keybind.MIDIControlCallBackOFF.StopAllSound == true)
                {
                    ChkBoxStopAllSoundRelease.Checked = true;
                }
                if (keybind.MIDIControlCallBackOFF.SwitchToProfile != null &&
					keybind.MIDIControlCallBackOFF.SwitchToProfile != "")
                {
                    ChkBoxSwitchToProfileRelease.Checked = true;
                    CboBoxProfileRelease.SelectedItem = keybind.MIDIControlCallBackOFF.SwitchToProfile;
                }
            }

            if (obs.IsEnabled())
            {
                foreach (OBSCallBack on in keybind.OBSCallBacksON)
                {
                    switch (on.Action)
                    {
                        case "switchScene":
                            if (on.Args[0] != null)
                            {
                                ChkBoxSwitchScenePress.Checked = true;
                                CboBoxSwitchScenePress.Enabled = true;
                                CboBoxSwitchScenePress.SelectedItem = on.Args[0];
                            }
                            break;
                        case "previewScene":
                            if (on.Args[0] != null)
                            {
                                ChkBoxPreviewScenePress.Checked = true;
                                CboBoxPreviewScenePress.Enabled = true;
                                CboBoxPreviewScenePress.SelectedItem = on.Args[0];
                            }
                            break;
                        case "mute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMutePress.Checked = true;
                                ChkCboBoxMutePress.Enabled = true;
                                try 
                                { 
                                ChkCboBoxMutePress.SetItemChecked(ChkCboBoxMutePress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "unmute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxUnmutePress.Checked = true;
                                ChkCboBoxUnmutePress.Enabled = true;
                                try
                                {
                                    ChkCboBoxUnmutePress.SetItemChecked(ChkCboBoxUnmutePress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException) 
                                {
                                }
                            }
                            break;
                        case "togglemute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxTogglemutePress.Checked = true;
                                ChkCboBoxToggleMutePress.Enabled = true;
                                try
                                {
                                    ChkCboBoxToggleMutePress.SetItemChecked(ChkCboBoxToggleMutePress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "hide":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHideSourcePress.Checked = true;
                                ChkCboBoxHidePress.Enabled = true;
                                try
                                {
                                    ChkCboBoxHidePress.SetItemChecked(ChkCboBoxHidePress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "show":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxShowSourcePress.Checked = true;
                                ChkCboBoxShowPress.Enabled = true;
                                try
                                {
                                    ChkCboBoxShowPress.SetItemChecked(ChkCboBoxShowPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "togglehide":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxToggleSourcePress.Checked = true;
                                ChkCboBoxToggleSourcePress.Enabled = true;
                                try 
                                { 
                                    ChkCboBoxToggleSourcePress.SetItemChecked(ChkCboBoxToggleSourcePress.Items.IndexOf(arg), true);
                                }
                                    catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "transition":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxTransitionPress.Checked = true;
                                CboBoxTransitionPress.Enabled = true;
                                CboBoxTransitionPress.SelectedItem = on.Args[0];
                                NumericTransitionPress.Enabled = true;
                                NumericTransitionPress.Value = Decimal.Parse(on.Args[1]);
                            }
                            break;
                        case "hidefilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHideFilterPress.Checked = true;
                                ChkCboBoxHideFilterPress.Enabled = true;
                                try 
                                { 
                                    ChkCboBoxHideFilterPress.SetItemChecked(ChkCboBoxHideFilterPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "showfilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxShowFilterPress.Checked = true;
                                ChkCboBoxShowFilterPress.Enabled = true;
                                try 
                                { 
                                    ChkCboBoxShowFilterPress.SetItemChecked(ChkCboBoxShowFilterPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "togglefilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxToggleFilterPress.Checked = true;
                                ChkCboBoxToggleFilterPress.Enabled = true;
                                try
                                { 
                                    ChkCboBoxToggleFilterPress.SetItemChecked(ChkCboBoxToggleFilterPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediaplay":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaPlayPress.Checked = true;
                                ChkCboBoxMediaPlayPress.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaPlayPress.SetItemChecked(ChkCboBoxMediaPlayPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediastop":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaStopPress.Checked = true;
                                ChkCboBoxMediaStopPress.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaStopPress.SetItemChecked(ChkCboBoxMediaStopPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediarestart":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaRestartPress.Checked = true;
                                ChkCboBoxMediaRestartPress.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaRestartPress.SetItemChecked(ChkCboBoxMediaRestartPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "hotkey":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHotkeyPress.Checked = true;
                                ChkCboBoxHotkeyPress.Enabled = true;
                                try
                                {
                                    ChkCboBoxHotkeyPress.SetItemChecked(ChkCboBoxHotkeyPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "misc":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMiscPress.Checked = true;
                                ChkCboBoxMiscPress.Enabled = true;
                                try
                                { 
                                    ChkCboBoxMiscPress.SetItemChecked(ChkCboBoxMiscPress.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                foreach (OBSCallBack on in keybind.OBSCallBacksOFF)
                {
                    switch (on.Action)
                    {
                        case "switchScene":
                            if (on.Args[0] != null)
                            {
                                ChkBoxSwitchSceneRelease.Checked = true;
                                CboBoxSwitchSceneRelease.Enabled = true;
                                CboBoxSwitchSceneRelease.SelectedItem = on.Args[0];
                            }
                            break;
                        case "previewScene":
                            if (on.Args[0] != null)
                            {
                                ChkBoxPreviewSceneRelease.Checked = true;
                                CboBoxPreviewSceneRelease.Enabled = true;
                                CboBoxPreviewSceneRelease.SelectedItem = on.Args[0];
                            }
                            break;
                        case "mute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMuteRelease.Checked = true;
                                ChkCboBoxMuteRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxMuteRelease.SetItemChecked(ChkCboBoxMuteRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "unmute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxUnmuteRelease.Checked = true;
                                ChkCboBoxUnmuteRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxUnmuteRelease.SetItemChecked(ChkCboBoxUnmuteRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "togglemute":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxTogglemuteRelease.Checked = true;
                                ChkCboBoxToggleMuteRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxToggleMuteRelease.SetItemChecked(ChkCboBoxToggleMuteRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "hide":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHideSourceRelease.Checked = true;
                                ChkCboBoxHideRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxHideRelease.SetItemChecked(ChkCboBoxHideRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "show":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxShowSourceRelease.Checked = true;
                                ChkCboBoxShowRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxShowRelease.SetItemChecked(ChkCboBoxShowRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "togglehide":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxToggleSourceRelease.Checked = true;
                                ChkCboBoxToggleSourceRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxToggleSourceRelease.SetItemChecked(ChkCboBoxToggleSourceRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "transition":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxTransitionRelease.Checked = true;
                                CboBoxTransitionRelease.Enabled = true;
                                CboBoxTransitionRelease.SelectedItem = on.Args[0];
                                NumericTransitionRelease.Enabled = true;
                                NumericTransitionRelease.Value = Decimal.Parse(on.Args[1]);
                            }
                            break;
                        case "hidefilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHideFilterRelease.Checked = true;
                                ChkCboBoxHideFilterRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxHideFilterRelease.SetItemChecked(ChkCboBoxHideFilterRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "showfilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxShowFilterRelease.Checked = true;
                                ChkCboBoxShowFilterRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxShowFilterRelease.SetItemChecked(ChkCboBoxShowFilterRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "togglefilter":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxToggleFilterRelease.Checked = true;
                                ChkCboBoxToggleFilterRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxToggleFilterRelease.SetItemChecked(ChkCboBoxToggleFilterRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediaplay":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaPlayRelease.Checked = true;
                                ChkCboBoxMediaPlayRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaPlayRelease.SetItemChecked(ChkCboBoxMediaPlayRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediastop":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaStopRelease.Checked = true;
                                ChkCboBoxMediaStopRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaStopRelease.SetItemChecked(ChkCboBoxMediaStopRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "mediarestart":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMediaRestartRelease.Checked = true;
                                ChkCboBoxMediaRestartRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxMediaRestartRelease.SetItemChecked(ChkCboBoxMediaRestartRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "hotkey":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxHotkeyRelease.Checked = true;
                                ChkCboBoxHotkeyRelease.Enabled = true;
                                try
                                {
                                    ChkCboBoxHotkeyRelease.SetItemChecked(ChkCboBoxHotkeyRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "misc":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxMiscRelease.Checked = true;
                                ChkCboBoxMiscRelease.Enabled = true;
                                try
                                { 
                                    ChkCboBoxMiscRelease.SetItemChecked(ChkCboBoxMiscRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                foreach (OBSCallBack on in keybind.OBSCallBacksSlider)
                {
                    switch (on.Action)
                    {
                        case "volume":
                            foreach (string arg in on.Args)
                            {
                                ChkBoxAdjustVolume.Checked = true;
                                ChkCboBoxVolumeSlider.Enabled = true;
                                try { 
                                    ChkCboBoxVolumeSlider.SetItemChecked(ChkCboBoxHideRelease.Items.IndexOf(arg), true);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                            break;
                        case "transition":
                            ChkBoxAdjustTransitionDuration.Checked = true;
                            break;
                        case "transitionSlider":
                            ChkBoxSlideTransition.Checked = true;
                            break;
                        case "filterSettings":
                            if(on.Args.Count == 2)
                            {
                                ChkBoxAdjustFilter.Checked = true;
                                CboBoxFilterNameSlider.Enabled = true;
                                CboBoxFilterNameSlider.SelectedItem = on.Args[0];
                                CboBoxFilterSettingSlider.Items.Clear();
                                List<string> listProperties = obs.GetFilterProperties(on.Args[0]);
                                foreach (string property in listProperties)
                                {
                                    CboBoxFilterSettingSlider.Items.Add(property);
                                }
                                CboBoxFilterSettingSlider.SelectedItem = on.Args[1];
                            }
                            break;
                        default:
                            break;
                    }
                }
            }


            MIDIDelegate = new MIDIDelegateHandler(UpdateNote);
            midi = MIDIListener.GetInstance();
            midi.DisableListening();
            foreach (KeyValuePair<string, MidiInCustom> entry in midi.midiInInterface)
            {
                entry.Value.MessageReceived += MidiIn_MessageReceived;
                midiDevice.Add(entry.Value);
            }

			DialogResult = DialogResult.Cancel;
		}

		// notes for adding new action categories:
		// - add a panel outside of the viewable area; put new controls in there and set AutoScroll = true
		// - initialize these new controls in InitControls(), EntryGUI(name, keybind), and BtnAdd_Click() as appropriate
		// - add a new node to the treeview in the appropriate place; the node's Name should match the new panel's Tag
		// - add the panel to the panels List in PrepareWindow()
		private void PrepareWindow() {
			// move all panels into place and size
			panels = new List<Panel>()
			{
				pnlOBSPress, pnlSoundBoardPress, pnlMediaKeysPress, pnlTwitchPress, pnlMidiControlPress, pnlGoXLRPress,
				pnlOBSRelease, pnlSoundBoardRelease, pnlMediaKeysRelease, pnlTwitchRelease, pnlMidiControlRelease, pnlGoXLRRelease,
				pnlOBSSlider
			};

			foreach(var p in panels)
			{
				p.Location = PanelLocation;
				p.Size = PanelSize;
				p.Visible = false;
				p.BorderStyle = BorderStyle.FixedSingle;
			}

			pnlRoot.BorderStyle = BorderStyle.FixedSingle;

			treeView1.ExpandAll();
			lblPanelLabel.Text = "No action selected";

			// finally, theme the window
			ThemeSupport.ThemeOtherWindow((new OptionsManagment()).options.Theme, this);

			if(this.EntryName == null)
			{
				this.Text = "Add MIDI Keybind";
			}
		}

		// show the correct section panel when the selected treeview node changes
		private void ActionCategoryChanged(object sender, TreeNodeMouseClickEventArgs e) {
			bool root_selected = (e.Node.Name as string).Contains("root");
			foreach(var p in panels)
			{
				p.Visible = ((p.Tag as string) == e.Node.Name);
			}
			pnlRoot.Visible = root_selected;
			if(pnlRoot.Visible)
				this.UpdateSummaryTextbox(this.GetProposedKeybind());

			if(root_selected)
			{
				lblPanelLabel.Text = "No action selected";
			}
			else
			{
				lblPanelLabel.Text = e.Node.FullPath;
			}
		}

		private void InitControls()
        {
			PrepareWindow();

            CheckToCombo.Add("ChkBoxSwitchScenePress", new string[] { "CboBoxSwitchScenePress" });
            CheckToCombo.Add("ChkBoxSwitchSceneRelease", new string[] { "CboBoxSwitchSceneRelease" });
            CheckToCombo.Add("ChkBoxPreviewScenePress", new string[] { "CboBoxPreviewScenePress" });
            CheckToCombo.Add("ChkBoxPreviewSceneRelease", new string[] { "CboBoxPreviewSceneRelease" });

            CheckToCombo.Add("ChkBoxMutePress", new string[] { "ChkCboBoxMutePress" });
            CheckToCombo.Add("ChkBoxMuteRelease", new string[] { "ChkCboBoxMuteRelease" });
            CheckToCombo.Add("ChkBoxUnmutePress", new string[] { "ChkCboBoxUnMutePress" });
            CheckToCombo.Add("ChkBoxUnmuteRelease", new string[] { "ChkCboBoxUnMuteRelease" });
            CheckToCombo.Add("ChkBoxHideSourcePress", new string[] { "ChkCboBoxHidePress" });
            CheckToCombo.Add("ChkBoxHideSourceRelease", new string[] { "ChkCboBoxHideRelease" });
            CheckToCombo.Add("ChkBoxShowSourcePress", new string[] { "ChkCboBoxShowPress" });
            CheckToCombo.Add("ChkBoxShowSourceRelease", new string[] { "ChkCboBoxShowRelease" });
            CheckToCombo.Add("ChkBoxTransitionPress", new string[] { "CboBoxTransitionPress", "NumericTransitionPress" });
            CheckToCombo.Add("ChkBoxTransitionRelease", new string[] { "CboBoxTransitionRelease", "NumericTransitionRelease" });
            CheckToCombo.Add("ChkBoxToggleSourcePress", new string[] { "ChkCboBoxToggleSourcePress" });
            CheckToCombo.Add("ChkBoxToggleSourceRelease", new string[] { "ChkCboBoxToggleSourceRelease" });
            CheckToCombo.Add("ChkBoxTogglemutePress", new string[] { "ChkCboBoxToggleMutePress" });
            CheckToCombo.Add("ChkBoxTogglemuteRelease", new string[] { "ChkCboBoxToggleMuteRelease" });
            CheckToCombo.Add("ChkBoxShowFilterPress", new string[] { "ChkCboBoxShowFilterPress" });
            CheckToCombo.Add("ChkBoxShowFilterRelease", new string[] { "ChkCboBoxShowFilterRelease" });
            CheckToCombo.Add("ChkBoxHideFilterPress", new string[] { "ChkCboBoxHideFilterPress" });
            CheckToCombo.Add("ChkBoxHideFilterRelease", new string[] { "ChkCboBoxHideFilterRelease" });
            CheckToCombo.Add("ChkBoxToggleFilterPress", new string[] { "ChkCboBoxToggleFilterPress" });
            CheckToCombo.Add("ChkBoxToggleFilterRelease", new string[] { "ChkCboBoxToggleFilterRelease" });

            CheckToCombo.Add("ChkBoxHotkeyPress", new string[] { "ChkCboBoxHotkeyPress" });
            CheckToCombo.Add("ChkBoxHotkeyRelease", new string[] { "ChkCboBoxHotkeyRelease" });
            CheckToCombo.Add("ChkBoxMiscPress", new string[] { "ChkCboBoxMiscPress" });
            CheckToCombo.Add("ChkBoxMiscRelease", new string[] { "ChkCboBoxMiscRelease" });

            CheckToCombo.Add("ChkBoxAdjustVolume", new string[] { "ChkCboBoxVolumeSlider" });
            CheckToCombo.Add("ChkBoxAdjustFilter", new string[] { "CboBoxFilterNameSlider", "CboBoxFilterSettingSlider"});

            CheckToCombo.Add("ChkBoxMediaPlayPress", new string[] { "ChkCboBoxMediaPlayPress" });
            CheckToCombo.Add("ChkBoxMediaPlayRelease", new string[] { "ChkCboBoxMediaPlayRelease" });
            CheckToCombo.Add("ChkBoxMediaStopPress", new string[] { "ChkCboBoxMediaStopPress" });
            CheckToCombo.Add("ChkBoxMediaStopRelease", new string[] { "ChkCboBoxMediaStopRelease" });
            CheckToCombo.Add("ChkBoxMediaRestartPress", new string[] { "ChkCboBoxMediaRestartPress" });
            CheckToCombo.Add("ChkBoxMediaRestartRelease", new string[] { "ChkCboBoxMediaRestartRelease" });


            CheckToCombo.Add("ChkBoxEnableAudio", new string[] { "CboBoxAudioDevice", "TxtBoxAudioFile", "BtnAudioSelect", "ChkBoxAudioStop" });

            CheckToCombo.Add("ChkBoxSwitchToProfilePress", new string[] { "CboBoxProfilePress" });
            CheckToCombo.Add("ChkBoxSwitchToProfileRelease", new string[] { "CboBoxProfileRelease" });

            CboBoxXLRInputPress.Items.Clear();
            CboBoxXLRInputRelease.Items.Clear();

            CboBoxXLROutputPress.Items.Clear();
            CboBoxXLROutputRelease.Items.Clear();

            foreach (string input in GoXLRControl.inputs)
            {
                CboBoxXLRInputPress.Items.Add(input);
                CboBoxXLRInputRelease.Items.Add(input);
            }
            foreach (string output in GoXLRControl.outputs)
            {
                CboBoxXLROutputPress.Items.Add(output);
                CboBoxXLROutputRelease.Items.Add(output);
            }

            CboBoxProfilePress.Items.Clear();
            CboBoxProfileRelease.Items.Clear();
            CboBoxProfilePress.Items.AddRange(conf.GetAllProfiles());
            CboBoxProfileRelease.Items.AddRange(conf.GetAllProfiles());

            ChkCboBoxHotkeyPress.Items.Clear();
            ChkCboBoxHotkeyRelease.Items.Clear();
            foreach (KeyValuePair<string,string> hotkey in obs.Hotkeys)
            {
                ChkCboBoxHotkeyPress.Items.Add(hotkey.Key);
                ChkCboBoxHotkeyRelease.Items.Add(hotkey.Key);
            }

            List<string> scenes = obs.GetScenes();
            CboBoxSwitchScenePress.Items.Clear();
            CboBoxSwitchSceneRelease.Items.Clear();
            CboBoxPreviewScenePress.Items.Clear();
            CboBoxPreviewSceneRelease.Items.Clear();

            foreach (string scene in scenes)
            {
                CboBoxSwitchScenePress.Items.Add(scene);
                CboBoxSwitchSceneRelease.Items.Add(scene);
                CboBoxPreviewScenePress.Items.Add(scene);
                CboBoxPreviewSceneRelease.Items.Add(scene);
            }

            List<string> sources = obs.GetSources();
            ChkCboBoxMutePress.Items.Clear();
            ChkCboBoxUnmutePress.Items.Clear();
            ChkCboBoxHidePress.Items.Clear();
            ChkCboBoxShowPress.Items.Clear();
            ChkCboBoxMuteRelease.Items.Clear();
            ChkCboBoxUnmuteRelease.Items.Clear();
            ChkCboBoxHideRelease.Items.Clear();
            ChkCboBoxShowRelease.Items.Clear();
            ChkCboBoxToggleSourcePress.Items.Clear();
            ChkCboBoxToggleMutePress.Items.Clear();
            ChkCboBoxToggleSourceRelease.Items.Clear();
            ChkCboBoxToggleMuteRelease.Items.Clear();
            ChkCboBoxVolumeSlider.Items.Clear();

            ChkCboBoxMediaPlayPress.Items.Clear();
            ChkCboBoxMediaStopPress.Items.Clear();
            ChkCboBoxMediaRestartPress.Items.Clear();
            ChkCboBoxMediaPlayRelease.Items.Clear();
            ChkCboBoxMediaStopRelease.Items.Clear();
            ChkCboBoxMediaRestartRelease.Items.Clear();
            foreach (string source in sources)
            {
                ChkCboBoxMutePress.Items.Add(source);
                ChkCboBoxUnmutePress.Items.Add(source);
                ChkCboBoxHidePress.Items.Add(source);
                ChkCboBoxShowPress.Items.Add(source);
                ChkCboBoxMuteRelease.Items.Add(source);
                ChkCboBoxUnmuteRelease.Items.Add(source);
                ChkCboBoxHideRelease.Items.Add(source);
                ChkCboBoxShowRelease.Items.Add(source);
                ChkCboBoxToggleSourcePress.Items.Add(source);
                ChkCboBoxToggleMutePress.Items.Add(source);
                ChkCboBoxToggleSourceRelease.Items.Add(source);
                ChkCboBoxToggleMuteRelease.Items.Add(source);
                ChkCboBoxVolumeSlider.Items.Add(source);

                ChkCboBoxMediaPlayPress.Items.Add(source);
                ChkCboBoxMediaStopPress.Items.Add(source);
                ChkCboBoxMediaRestartPress.Items.Add(source);
                ChkCboBoxMediaPlayRelease.Items.Add(source);
                ChkCboBoxMediaStopRelease.Items.Add(source);
                ChkCboBoxMediaRestartRelease.Items.Add(source);
            }
            List<string> transitions = obs.GetTransitions();
            CboBoxTransitionPress.Items.Clear();
            CboBoxTransitionRelease.Items.Clear();
            foreach (string transition in transitions)
            {
                CboBoxTransitionPress.Items.Add(transition);
                CboBoxTransitionRelease.Items.Add(transition);
            }

            List<string> filters = obs.GetFilters();
            ChkCboBoxShowFilterPress.Items.Clear();
            ChkCboBoxHideFilterPress.Items.Clear();
            ChkCboBoxToggleFilterPress.Items.Clear();
            ChkCboBoxShowFilterRelease.Items.Clear();
            ChkCboBoxHideFilterRelease.Items.Clear();
            ChkCboBoxToggleFilterRelease.Items.Clear();
            CboBoxFilterNameSlider.Items.Clear();
            foreach (string filter in filters)
            {
                ChkCboBoxShowFilterPress.Items.Add(filter);
                ChkCboBoxHideFilterPress.Items.Add(filter);
                ChkCboBoxToggleFilterPress.Items.Add(filter);
                ChkCboBoxShowFilterRelease.Items.Add(filter);
                ChkCboBoxHideFilterRelease.Items.Add(filter);
                ChkCboBoxToggleFilterRelease.Items.Add(filter);
                CboBoxFilterNameSlider.Items.Add(filter);
            }

            ChkCboBoxMiscPress.Items.Clear();
            ChkCboBoxMiscRelease.Items.Clear();
            string[] itemValues = new string[] {"Start Stream", "Stop Stream", "Toggle Stream", "Start Record", "Stop Record", "Toggle Record", "Pause Record", "Resume Record" ,"Play/Pause Record", "Save Record", "Transition To Program (Studio)", "Toggle Studio Mode" };
            ChkCboBoxMiscPress.Items.AddRange(itemValues);
            ChkCboBoxMiscRelease.Items.AddRange(itemValues);

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                WaveOutCapabilities WOC = WaveOut.GetCapabilities(i);
                CboBoxAudioDevice.Items.Add(WOC.ProductName);
            }
        }

        private void EntryGUI_FormClosing(Object sender, FormClosingEventArgs e)
        {
            foreach (MidiInCustom midi in midiDevice)
            {
                midi.MessageReceived -= MidiIn_MessageReceived;
            }
        }
				
		private KeyBindEntry GetProposedKeybind() {
			this.keybindErrors.Clear();

			KeyBindEntry key = new KeyBindEntry {
				Mididevice = Device,
				NoteNumber = Note,
				Channel = Channel,
				Input = Input
			};

			if(ChkBoxTransitionPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "transition"
				};
				if((string)CboBoxTransitionPress.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (on) - Transition");
				callback.Args.Add((string)CboBoxTransitionPress.SelectedItem);
				callback.Args.Add(NumericTransitionPress.Value.ToString());
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxSwitchScenePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "switchScene"
				};
				if((string)CboBoxSwitchScenePress.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (on) - Switch Scene"); ;
				callback.Args.Add((string)CboBoxSwitchScenePress.SelectedItem);
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxPreviewScenePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "previewScene"
				};
				if((string)CboBoxPreviewScenePress.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (on) - Preview Scene"); ;
				callback.Args.Add((string)CboBoxPreviewScenePress.SelectedItem);
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMutePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMutePress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxUnmutePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "unmute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxUnmutePress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxHideSourcePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hide"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHidePress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxShowSourcePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "show"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxShowPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxToggleSourcePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglehide"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleSourcePress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxTogglemutePress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglemute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleMutePress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxHideFilterPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hidefilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHideFilterPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxShowFilterPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "showfilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxShowFilterPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxToggleFilterPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglefilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleFilterPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMediaPlayPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediaplay"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaPlayPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMediaStopPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediastop"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaStopPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMediaRestartPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediarestart"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaRestartPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxHotkeyPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hotkey"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHotkeyPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMiscPress.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "misc"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMiscPress.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}


			if(ChkBoxTransitionRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "transition"
				};
				if((string)CboBoxTransitionRelease.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (off) - Transition"); ;
				callback.Args.Add((string)CboBoxTransitionRelease.SelectedItem);
				callback.Args.Add(NumericTransitionRelease.Value.ToString());
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxSwitchSceneRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "switchScene"
				};
				if((string)CboBoxSwitchSceneRelease.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (off) - Switch Scene"); ;
				callback.Args.Add((string)CboBoxSwitchSceneRelease.SelectedItem);
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxPreviewSceneRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "previewScene"
				};
				if((string)CboBoxPreviewSceneRelease.SelectedItem == null)
					this.keybindErrors.Add("No scene selected for OBS (off) - Preview Scene"); ;
				callback.Args.Add((string)CboBoxPreviewSceneRelease.SelectedItem);
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMuteRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMuteRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxUnmuteRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "unmute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxUnmuteRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxHideSourceRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hide"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHideRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxShowSourceRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "show"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxShowRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxToggleSourceRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglehide"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleSourceRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxTogglemuteRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglemute"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleMuteRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxHideFilterRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hidefilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHideFilterRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxShowFilterRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "showfilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxShowFilterRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxToggleFilterRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "togglefilter"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxToggleFilterRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxMediaPlayRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediaplay"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaPlayRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMediaStopRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediastop"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaStopRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxMediaRestartRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "mediarestart"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMediaRestartRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksON.Add(callback);
			}
			if(ChkBoxHotkeyRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "hotkey"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxHotkeyRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}
			if(ChkBoxMiscRelease.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "misc"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxMiscRelease.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksOFF.Add(callback);
			}

			if(ChkBoxAdjustVolume.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "volume"
				};
				CheckedListBox.CheckedItemCollection items = ChkCboBoxVolumeSlider.CheckedItems;
				foreach(object item in items) {
					callback.Args.Add(item.ToString());
				}
				key.OBSCallBacksSlider.Add(callback);
			}
			if(ChkBoxAdjustTransitionDuration.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Action = "transition"
				};
				key.OBSCallBacksSlider.Add(callback);
			}
			if(ChkBoxSlideTransition.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Action = "transitionSlider"
				};
				key.OBSCallBacksSlider.Add(callback);
			}
			if(ChkBoxAdjustFilter.Checked) {
				OBSCallBack callback = new OBSCallBack {
					Args = new List<string>(),
					Action = "filterSettings"
				};
				if((string)CboBoxFilterNameSlider.SelectedItem == null)
					this.keybindErrors.Add("No filter selected for OBS (adjust) - Filter slider"); ;
				callback.Args.Add((string)CboBoxFilterNameSlider.SelectedItem);
				callback.Args.Add((string)CboBoxFilterSettingSlider.SelectedItem);
				key.OBSCallBacksSlider.Add(callback);
			}


			// Sounboard
			if(ChkBoxEnableAudio.Checked) {
				key.SoundCallBack = new SoundCallBack(TxtBoxAudioFile.Text, CboBoxAudioDevice.Text, ChkBoxAudioStop.Checked, chkBoxLoop.Checked, volumeSlider.Volume, chkStopAllOthers.Checked);
			} else {
				key.SoundCallBack = null;
			}

			// MIDIControl
			if(ChkBoxStopAllSoundPress.Checked || ChkBoxSwitchToProfilePress.Checked) {
				key.MIDIControlCallBackON = new MIDIControlCallBack();
				if(ChkBoxStopAllSoundPress.Checked) {
					key.MIDIControlCallBackON.StopAllSound = true;
				}
				if(ChkBoxSwitchToProfilePress.Checked) {
					key.MIDIControlCallBackON.SwitchToProfile = CboBoxProfilePress.SelectedItem.ToString();
				}
			}
			if(ChkBoxStopAllSoundRelease.Checked || ChkBoxSwitchToProfileRelease.Checked) {
				key.MIDIControlCallBackOFF = new MIDIControlCallBack();
				if(ChkBoxStopAllSoundRelease.Checked) {
					key.MIDIControlCallBackOFF.StopAllSound = true;
				}
				if(ChkBoxSwitchToProfileRelease.Checked) {
					key.MIDIControlCallBackOFF.SwitchToProfile = CboBoxProfileRelease.SelectedItem.ToString();
				}
			}

			// Media Keys
			if(ChkBoxMediaKeyPlayPress.Checked) {
				key.MediaCallBack = new MediaCallBack(MediaType.PLAY);
			} else if(ChkBoxMediaKeyNextPress.Checked) {
				key.MediaCallBack = new MediaCallBack(MediaType.NEXT);
			} else if(ChkBoxMediaKeyPreviousPress.Checked) {
				key.MediaCallBack = new MediaCallBack(MediaType.PREVIOUS);
			} else {
				key.MediaCallBackOFF = null;
			}
			if(ChkBoxMediaKeyPlayRelease.Checked) {
				key.MediaCallBackOFF = new MediaCallBack(MediaType.PLAY);
			} else if(ChkBoxMediaKeyNextRelease.Checked) {
				key.MediaCallBackOFF = new MediaCallBack(MediaType.NEXT);
			} else if(ChkBoxMediaKeyPreviousRelease.Checked) {
				key.MediaCallBackOFF = new MediaCallBack(MediaType.PREVIOUS);
			} else {
				key.MediaCallBackOFF = null;
			}


			// Twitch
			if(TxtBoxTwitchChannelPress.Text != "" && TxtBoxTwitchMessagePress.Text != "") {
				key.TwitchCallBackON = new TwitchCallBack {
					Channel = TxtBoxTwitchChannelPress.Text,
					Messsage = TxtBoxTwitchMessagePress.Text
				};
			}
			if(TxtBoxTwitchChannelRelease.Text != "" && TxtBoxTwitchMessageRelease.Text != "") {
				key.TwitchCallBackOFF = new TwitchCallBack {
					Channel = TxtBoxTwitchChannelRelease.Text,
					Messsage = TxtBoxTwitchMessageRelease.Text
				};
			}

			// Go XLR
			if(RadioButtonToggleXLRPress.Checked) {
				key.GoXLRCallBackON = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.Toggle,
					Input = CboBoxXLRInputPress.SelectedItem.ToString(),
					Output = CboBoxXLROutputPress.SelectedItem.ToString()
				};
			}
			if(RadioButtonMuteXLRPress.Checked) {
				key.GoXLRCallBackON = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.Mute,
					Input = CboBoxXLRInputPress.SelectedItem.ToString(),
					Output = CboBoxXLROutputPress.SelectedItem.ToString()
				};
			}
			if(RadioButtonUnMuteXLRPress.Checked) {
				key.GoXLRCallBackON = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.UnMute,
					Input = CboBoxXLRInputPress.SelectedItem.ToString(),
					Output = CboBoxXLROutputPress.SelectedItem.ToString()
				};
			}
			if(RadioButtonToggleXLRRelease.Checked) {
				key.GoXLRCallBackOFF = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.Toggle,
					Input = CboBoxXLRInputRelease.SelectedItem.ToString(),
					Output = CboBoxXLROutputRelease.SelectedItem.ToString()
				};
			}
			if(RadioButtonMuteXLRRelease.Checked) {
				key.GoXLRCallBackOFF = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.Mute,
					Input = CboBoxXLRInputRelease.SelectedItem.ToString(),
					Output = CboBoxXLROutputRelease.SelectedItem.ToString()
				};
			}
			if(RadioButtonUnMuteXLRRelease.Checked) {
				key.GoXLRCallBackOFF = new GoXLRCallBack {
					Action = (int)GoXLRControl.Action.UnMute,
					Input = CboBoxXLRInputRelease.SelectedItem.ToString(),
					Output = CboBoxXLROutputRelease.SelectedItem.ToString()
				};
			}

			// finally, display the summary
			this.UpdateSummaryTextbox(key);

			return key;
		}

		private void UpdateSummaryTextbox(KeyBindEntry proposed) {
			txtKeybindSummary.Text = "";
			if(this.previousSettings != null) {
				txtKeybindSummary.Text += "Current keybind settings:\r\n";
				foreach(var s in this.previousSettings.Summarize().Split(new string[] { " / " }, StringSplitOptions.RemoveEmptyEntries))
					 txtKeybindSummary.Text += "- " + s + "\r\n";
				txtKeybindSummary.Text += "\r\n";
			}
			if(this.keybindErrors.Count > 0) {
				txtKeybindSummary.Visible = true;

				txtKeybindSummary.Text += "The following issues with the proposed settings were detected:\r\n";
				foreach(var s in this.keybindErrors) {
					txtKeybindSummary.Text += "- " + s + "\r\n";
				}
			} else {
				txtKeybindSummary.Text += "Proposed keybind settings:\r\n";
				string[] proposedChanges = proposed.Summarize().Split(new string[] { " / " }, StringSplitOptions.RemoveEmptyEntries);
				if(proposedChanges.Length > 0) {
					txtKeybindSummary.Visible = true;
					foreach(var s in proposedChanges)
						txtKeybindSummary.Text += "- " + s + "\r\n";
				} else {
					txtKeybindSummary.Visible = (this.previousSettings != null);
					txtKeybindSummary.Text += "(nothing selected)";
				}
			}
		}

        private void BtnAdd_Click(object sender, EventArgs e)
        {
			KeyBindEntry key = this.GetProposedKeybind();
			if(this.keybindErrors.Count > 0) {
				// invalid settings
				MessageBox.Show("One or more invalid settings was detected.  Please check your selections and try again.", "Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Warning);

				// show root panel
				foreach(var p in panels) {
					p.Visible = false;
				}
				pnlRoot.Visible = true;
				
				lblPanelLabel.Text = "Invalid options detected - please check your settings";
				return;
			}

			if(key.Summarize().Trim() == "") {
				// nothing selected
				MessageBox.Show("You haven't selected any actions for this keybind.", "Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if(TxtBoxName.Text == "") {
				// needs to have a name
				MessageBox.Show("Enter a name for your new keybind.", "Invalid options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
            

            if (this.EntryName == null) // New
            {
				// make sure the proposed name isn't already taken
				if(conf.Config.ContainsKey(TxtBoxName.Text)) {
					if(MessageBox.Show("A keybind with this name already exists.  Do you want to overwrite it?", "Keybind name taken", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						return;
					conf.Config[TxtBoxName.Text] = key;
				} else {
					conf.Config.Add(TxtBoxName.Text, key);
				}
            }
            else // Edit
            {
                if (conf.Config.ContainsKey(TxtBoxName.Text)) // Same Name
                {
					conf.Config[TxtBoxName.Text] = key;
				}
                else // Name Modified
                {
                    conf.Config.Remove(this.EntryName);
                    conf.Config.Add(TxtBoxName.Text, key);
                }
            }

			conf.Unsaved = true;

			DialogResult = DialogResult.OK;

            this.Close();
            this.Dispose();
        }

        private void ChkBox_State(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, string[]> items in CheckToCombo)
            {
                foreach (string item in items.Value)
                {
                    if (((CheckBox)sender).Name == items.Key)
                    {
                        this.Controls.Find(item, true).First().Enabled = ((CheckBox)sender).Checked;
                    }
                }
            }
        }

        private void MidiIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            // TODO: whatever bugfix is done in MIDIListener re: disconnecting/changing connected devices, may need to be done here as well
#if DEBUG
            Debug.WriteLine("Setting : MIDI IN Signal " + e.MidiEvent.GetType() + " | " + e.MidiEvent.ToString());
#endif
            if (e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
            {
                int device = ((MidiInCustom)sender).device;
                Device = MidiIn.DeviceInfo(device).ProductName;
                Channel = ((NoteEvent)e.MidiEvent).Channel;
                Note = ((NoteEvent)e.MidiEvent).NoteNumber;
                Input = Event.Note;

                this.Invoke(this.MIDIDelegate, new object[] {
                    Note.ToString(),
                    Device,
                    Channel.ToString()
                });
            }
            else if (e.MidiEvent.CommandCode == MidiCommandCode.ControlChange)
            {
                int device = ((MidiInCustom)sender).device;
                Device = MidiIn.DeviceInfo(device).ProductName;
                Channel = ((ControlChangeEvent)e.MidiEvent).Channel;
                Note = (int)((ControlChangeEvent)e.MidiEvent).Controller;
                Input = Event.Slider;

                this.Invoke(this.MIDIDelegate, new object[] {
                    Note.ToString(),
                    Device,
                    Channel.ToString()
                });
            }
        }


        private void UpdateNote(string note, string device, string channel)
        {
            TxtBoxNote.Text = note;
            TxtBoxDevice.Text = device;
            TxtBoxChannel.Text = channel;

            if(Input == Event.Note)
			{
                LblNote.Text = "Note";
                TxtBoxNote.Text = MIDIListener.getNoteString(Note);
            } 
			else if(Input == Event.Slider)
			{
                LblNote.Text = "CC";
            }
        }

        private void BtnAudioSelect_Click(object sender, EventArgs e)
        {
			using(var fdlg = new OpenFileDialog {
				Title = "Select Audio File",
				InitialDirectory = @"c:\",
				Filter = "Audio files (*.mp3;*.wav;*.wma;*.aac)|*.MP3;*.WAV;*.WMA;*.AAC|All files (*.*)|*.*",
				RestoreDirectory = true
			}) 
			{
				if(fdlg.ShowDialog() == DialogResult.OK)
				{
					TxtBoxAudioFile.Text = fdlg.FileName;
				}
			}
        }

        private void CboBoxFilterNameSlider_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string filterName = (string)CboBoxFilterNameSlider.SelectedItem;
            CboBoxFilterSettingSlider.Items.Clear();
            List<string> listProperties = obs.GetFilterProperties(filterName);
            CboBoxFilterSettingSlider.Items.Add("");
            foreach (string property in listProperties)
            {
                CboBoxFilterSettingSlider.Items.Add(property);
            }
            CboBoxFilterSettingSlider.SelectedIndex = 0;
        }

		private void CancelPressed(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
