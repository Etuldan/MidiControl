using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl {
	public partial class MIDIControlGUI : Form {
		public delegate void OBSControlDelegateHandler(bool connect);
		public OBSControlDelegateHandler OBSControlDelegate;
		public delegate void TwitchControlDelegateHandler(bool connect);
		public TwitchControlDelegateHandler TwitchControlDelegate;
		public delegate void SwitchProfileControlDelegateHandler();
		public SwitchProfileControlDelegateHandler SwitchProfileControlDelegate;
        public delegate void MidiInStatusDelegateHandler(bool error = false);
        public MidiInStatusDelegateHandler MidiInStatusDelegate;
		private readonly OptionsManagment options;
		private readonly Configuration conf;
		private readonly MIDIListener midi;

		private bool actuallyClosing = false;
		private bool windowWasShown = false;

		private string NIControllerEditorEXEPath = @"C:\Program Files\Native Instruments\Controller Editor\Controller Editor.exe";

		private const string STATIC_PROFILEMENU_TAG = "#STATIC_PROFILE_MENU_ITEM#";

		private ImageList keybindIconList;

		private static MIDIControlGUI _inst;
		public static MIDIControlGUI GetInstance() {
			return _inst;
		}

		// window constructor
		public MIDIControlGUI() {
			_inst = this;
			InitializeComponent();			

			OBSControlDelegate = new OBSControlDelegateHandler(UpdateOBSStatus);
			TwitchControlDelegate = new TwitchControlDelegateHandler(UpdateTwitchStatus);
			SwitchProfileControlDelegate = new SwitchProfileControlDelegateHandler(UpdateProfile);
            MidiInStatusDelegate = new MidiInStatusDelegateHandler(UpdateMIDIStatus);

            obsButton.Tag = twitchButton.Tag = midiButton.Tag = false;

			options = new OptionsManagment();
			string initialProfile = options.options.LastUsedProfile;
			if(!options.options.LoadLastProfileOnStartup) {
				initialProfile = "Default";
			}
			conf = new Configuration(this, initialProfile);

			midi = new MIDIListener(conf);
			UpdateMIDIStatus();

			ReloadProfilesList();
			RefreshWindowTitle();

			trayIcon.BalloonTipText = "MIDIControl loaded the '" + initialProfile + "' profile.  Double-click the tray icon to open the main window.";
			if(options.options.StartToTray) {
				trayIcon.ShowBalloonTip(500);
			}

			this.toolStrip1.Dock = (options.options.ToolbarPosition == 1 ? DockStyle.Bottom : DockStyle.Top);

			keybindIconList = new ImageList() {
				ColorDepth = ColorDepth.Depth32Bit,
				ImageSize = new Size(48, 48)
			};
			keybindIconList.Images.Add("button", Properties.Resources.control_button_icon);
			keybindIconList.Images.Add("knob", Properties.Resources.control_knob_icon);

			listKeybinds.LargeImageList = keybindIconList;
			//listKeybinds.SmallImageList = keybindIconList;
            
			this.SetWindowTheme(options.options.Theme);

			// apply the last-used listview style
			menuViewAsIcons.Checked = menuViewAsList.Checked = menuViewAsDetails.Checked = false;
			switch(options.options.ListViewStyle) {
				case "icons":
					listKeybinds.View = View.Tile;
					menuViewAsIcons.Checked = true;
					menuViewAsDropdown.Text = "View as: Icons";
					break;
				case "list":
					listKeybinds.View = View.List;
					menuViewAsList.Checked = true;
					menuViewAsDropdown.Text = "View as: List";
					break;
				case "details":
					listKeybinds.View = View.Details;
					menuViewAsDetails.Checked = true;
					menuViewAsDropdown.Text = "View as: Details";
					break;
			}

			// show menu option for Native Instruments Controller Editor, if installed
			if(!System.IO.File.Exists(NIControllerEditorEXEPath)) {
				mnuNIControllerEditor.Visible = false;
			}

			// (if other device manufacturers have MIDI controller editor apps, they can be added in a similar way for convenience to the user :) )
			//
		}

		// theme support functions
        private ThemeSupport.MidiControlTheme GetCurrentTheme() {
            return ThemeSupport.GetThemeByIndex(options.options.Theme);
        }

		private void SetWindowTheme(int theme) {
			ThemeSupport.MidiControlTheme mcTheme = ThemeSupport.GetThemeByIndex(theme);

            // set colors
			this.BackColor = mcTheme.WindowBackColor;

            toolStrip1.Renderer = new ThemeSupport.MidiControlThemeRenderer(mcTheme);
            //toolStrip1.Renderer = new ToolStripProfessionalRenderer(mcTheme);
            statusBar.Renderer = new ToolStripProfessionalRenderer(mcTheme);
            trayMenuStrip.Renderer = new ThemeSupport.MidiControlThemeRenderer(mcTheme);
            //trayMenuStrip.Renderer = new ToolStripProfessionalRenderer(mcTheme);
            itemContextMenu.Renderer = new ThemeSupport.MidiControlThemeRenderer(mcTheme);
            //itemContextMenu.Renderer = new ToolStripProfessionalRenderer(mcTheme);

            statusBar.SizingGrip = mcTheme.ShowStatusBarGrip;

			listKeybinds.BackColor = mcTheme.ListViewBackColor;
			listKeybinds.ForeColor = mcTheme.ListViewForeColor;
			listKeybinds.BorderStyle = mcTheme.ListViewBorderStyle;

            // theme menu items
			ThemeSubitems(toolStrip1.Items, mcTheme);
			ThemeSubitems(trayMenuStrip.Items, mcTheme);
			ThemeSubitems(itemContextMenu.Items, mcTheme);

            // set icons
			btnSaveCurrentProfile.Image = saveCurrentProfileToolStripMenuItem.Image = mcTheme.SaveIcon;
			editToolStripMenuItem.Image = butEditSelectedKeybind.Image = mcTheme.EditIcon;
			btnDeleteCurrentProfile.Image = deleteCurrentProfileToolStripMenuItem.Image = mcTheme.DeleteIcon;
			deleteToolStripMenuItem.Image = butDeleteSelectedKeybind.Image = mcTheme.MinusIcon;
			btnAddKeybind.Image = addKeybindToolStripMenuItem.Image = mcTheme.PlusIcon;
			btnStopAllSounds.Image = mcTheme.MuteIcon;
			MidiControlOptionsToolStripMenuItem.Image = mcTheme.SettingsIcon;

            if((bool)obsButton.Tag)
                obsButton.Image = mcTheme.OBSIcon;
            else
                obsButton.Image = mcTheme.OBSOffIcon;

            if((bool)twitchButton.Tag)
                twitchButton.Image = mcTheme.TwitchIcon;
            else
                twitchButton.Image = mcTheme.TwitchOffIcon;

            if((bool)midiButton.Tag)
                midiButton.Image = mcTheme.MIDIIcon;
            else
                midiButton.Image = mcTheme.MIDIOffIcon;
            
			keybindIconList.Images.Clear();
			keybindIconList.Images.Add("button", mcTheme.ControlButtonIcon);
			keybindIconList.Images.Add("knob", mcTheme.ControlKnobIcon);
            
			ReloadEntries();

            listKeybinds.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.ColumnContent);
		}

		private void ThemeSubitems(ToolStripItemCollection items, ThemeSupport.MidiControlTheme theme) {
			foreach(var item in items) {
				if(item is ToolStripButton) {
					(item as ToolStripButton).ForeColor = theme.ToolbarForeColor;
				}
				if(item is ToolStripDropDownButton) {
					(item as ToolStripDropDownButton).ForeColor = theme.ToolbarForeColor;
					ThemeSubitems((item as ToolStripDropDownButton).DropDownItems, theme);
				}
				if(item is ToolStripMenuItem) {
					(item as ToolStripMenuItem).ForeColor = theme.MenuForeColor;
					ThemeSubitems((item as ToolStripMenuItem).DropDownItems, theme);
				}
			}
		}

        // form, tray icon, close window events
        private void MIDIControlGUI_Load(object sender, EventArgs e) {
			ReloadEntries();
			OBSControl.GetInstance().ConnectDisconnect();

			this.windowWasShown = true;
		}

		private void MIDIControlGUI_FormClosing(object sender, FormClosingEventArgs e) {
			if(!this.actuallyClosing) {
				e.Cancel = true;

				this.Hide();
				trayIcon.BalloonTipText = "MIDIControl is still running.  Double-click the tray icon to reopen the main window.";
				trayIcon.ShowBalloonTip(500);
			} else {
				if(conf.Unsaved) {
					switch(MessageBox.Show("The current profile '" + conf.CurrentProfile + "' has unsaved changes.  Do you want to save them before exiting?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
						case DialogResult.Yes:
							conf.SaveCurrentProfile();
							break;
						case DialogResult.No:
							break;
						case DialogResult.Cancel:
							e.Cancel = true;
							break;
					}
				}
			}
		}

		private void MIDIControlGUI_FormClosed(object sender, FormClosedEventArgs e) {
			// actual program close stuff here
			midi.ReleaseAll();

			// if the program started to tray, kill the main app thread since it was started without being linked to the window
			if(Program.StartedToTray) {
				Application.Exit();
			}
		}

		private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Left) {
				this.Show();
			}
		}

		private void trayMenuShowMainWindow_Click(object sender, EventArgs e) {
			this.Show();
		}

		private void trayMenuExit_Click(object sender, EventArgs e) {
			this.actuallyClosing = true;
			this.Close();

			// if window was never shown, the FormClosing/Closed events won't fire
			if(!this.windowWasShown) {
				midi.ReleaseAll();
				Application.Exit();
			}
		}

		private void closeToTrayToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.actuallyClosing = true;
			this.Close();
		}

		private void RefreshWindowTitle() {
			this.Text = trayIcon.Text = "MIDIControl (for OBS 28) - [" + conf.CurrentProfile + (conf.Unsaved?"*":"") + "]";
		}

		// delegate handlers; from MIDIControlGUI; config/profiles/keybind refresh
		private void ReloadProfilesList() {
            // clear profile items from the submenu (but leave the utility ones)
			for(var i = 0; i < menuProfiles.DropDownItems.Count; i++) {
				var item = menuProfiles.DropDownItems[i];

				if(item is ToolStripSeparator) {
					continue;
				}
				if(item is ToolStripMenuItem) {
					if((string)item.Tag == STATIC_PROFILEMENU_TAG) {
						continue;
					} else {
						item.Click -= ProfileMenuItemClicked;
						menuProfiles.DropDownItems.RemoveAt(i);
						i--;
					}
				}
			}

            // clear tray profile switcher menu
            foreach(ToolStripMenuItem dditem in SwitchProfileTrayMenuItem.DropDownItems) {
                dditem.Click -= ProfileMenuItemClicked;
            }
            SwitchProfileTrayMenuItem.DropDownItems.Clear();

            // add new items to both
			foreach(var profile in conf.GetAllProfiles()) {
				var newitem = new ToolStripMenuItem(profile) {
					Tag = "main"
				};
				newitem.Click += ProfileMenuItemClicked;
				menuProfiles.DropDownItems.Add(newitem);

                var newtrayitem = new ToolStripMenuItem(profile) {
                    Tag = "tray"
                };
                newtrayitem.Click += ProfileMenuItemClicked;
                SwitchProfileTrayMenuItem.DropDownItems.Add(newtrayitem);
			}

            // set the checkmark on the currently-loaded profile
			CheckCurrentProfileMenuItem();
		}

		private void CheckCurrentProfileMenuItem() {
			foreach(ToolStripItem item in menuProfiles.DropDownItems) {
				if(item is ToolStripMenuItem) {
					((ToolStripMenuItem)item).Checked = (item.Text == conf.CurrentProfile);
				}
			}
            foreach(ToolStripItem item in SwitchProfileTrayMenuItem.DropDownItems) {
                if(item is ToolStripMenuItem) {
                    ((ToolStripMenuItem)item).Checked = (item.Text == conf.CurrentProfile);
                }
            }

			if(conf.CurrentProfile == "Default") {
				btnDeleteCurrentProfile.Text = deleteCurrentProfileToolStripMenuItem.Text = "Clear default profile";
				saveCurrentProfileAsDefaultToolStripMenuItem.Enabled = false;
			} else {
				btnDeleteCurrentProfile.Text = deleteCurrentProfileToolStripMenuItem.Text = "Delete current profile";
				saveCurrentProfileAsDefaultToolStripMenuItem.Enabled = true;
			}
		}

		private void UpdateProfile() {
			ReloadEntries();

			// set selected profile in menu
			CheckCurrentProfileMenuItem();

			// remember this as the last opened profile
			options.options.LastUsedProfile = conf.CurrentProfile;
			options.Save();
		}

		private void UpdateMIDIStatus(bool error = false) {
			midiStatus.Text = "";
			foreach(string device in midi.GetMIDIINDevices()) {
				midiStatus.Text += " " + device + ",";
			}
			midiStatus.Text = midiStatus.Text.Trim(',').Trim();
			if(midiStatus.Text == "") {
				midiButton.Image = this.GetCurrentTheme().MIDIOffIcon;
				midiStatus.Text = "No MIDI devices detected!  Click MIDI icon to rescan.";
				midiStatus.ForeColor = this.GetCurrentTheme().MIDILabelOff;
                midiButton.Tag = false;

                //MessageBox.Show("No MIDI devices were detected.  Connect a device and then click the MIDI icon in the status bar to rescan for devices.", "MIDIControl", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			} else {
                midiButton.Image = (error ? this.GetCurrentTheme().MIDIWarningIcon : this.GetCurrentTheme().MIDIIcon);
				midiStatus.ForeColor = (error ? this.GetCurrentTheme().MIDILabelWarning : this.GetCurrentTheme().MIDILabelOn);
                midiButton.Tag = true;
			}
		}

		private void UpdateOBSStatus(bool connect) {
			if(connect) {
                obsButton.Image = this.GetCurrentTheme().OBSIcon;
                obsButton.ToolTipText = "Disconnect OBS";
			} else {
				obsButton.Image = this.GetCurrentTheme().OBSOffIcon;
                obsButton.ToolTipText = "Connect OBS";
			}

            obsButton.Tag = connect;
		}
		private void UpdateTwitchStatus(bool connect) {
			if(connect) {
                twitchButton.Image = this.GetCurrentTheme().TwitchIcon;
                twitchButton.ToolTipText = "Disconnect Twitch";
			} else {
				twitchButton.Image = this.GetCurrentTheme().TwitchOffIcon;
                twitchButton.ToolTipText = "Connect Twitch";
			}

            twitchButton.Tag = connect;
		}

		private void OBSStatusButtonClicked(object sender, EventArgs e) {
			OBSControl.GetInstance().ConnectDisconnect();
		}

		private void TwitchStatusButtonClicked(object sender, EventArgs e) {
			TwitchChatControl.GetInstance().ConnectDisconnect();
		}

		private void MidiStatusButtonClicked(object sender, EventArgs e) {
			midi.RefeshMIDIDevices();
			UpdateMIDIStatus();
		}

		private void StopAllSoundsClicked(object sender, EventArgs e) {
			midi.StopAllSounds();
		}

		// processing
		private void EditEntry(string index) {
			if(conf.Config.TryGetValue(index, out KeyBindEntry value)) {
				using(EntryGUI addEntry = new EntryGUI(index, value)) {
					addEntry.StartPosition = FormStartPosition.CenterParent;
					if(addEntry.ShowDialog() == DialogResult.OK)
						ReloadEntries();
					midi.EnableListening();
				}
			}
		}

		// ui events
		private void MidiControlOptionsToolStripMenuItem_Click(object sender, EventArgs e) {
			using(OptionsGUI optionGUI = new OptionsGUI(options)) {
				optionGUI.ShowDialog();
				this.TopMost = options.options.AlwaysOnTop;
				this.toolStrip1.Dock = (options.options.ToolbarPosition == 1 ? DockStyle.Bottom : DockStyle.Top);
				this.SetWindowTheme(options.options.Theme);
			}
		}

		private void InterfaceOptionsMenuItem_Click(object sender, EventArgs e) {
			using(OptionsGUI optionGUI = new OptionsGUI(options, "interface")) {
				optionGUI.ShowDialog();
				this.TopMost = options.options.AlwaysOnTop;
				this.toolStrip1.Dock = (options.options.ToolbarPosition == 1 ? DockStyle.Bottom : DockStyle.Top);
				this.SetWindowTheme(options.options.Theme);
			}
		}

		private void ProfileMenuItemClicked(object sender, EventArgs e) {
			var profile = ((ToolStripMenuItem)sender).Text;
            var tag = (string)((ToolStripMenuItem)sender).Tag;

			bool doLoad = true;

			if(conf.Unsaved) {
				switch(MessageBox.Show("The current profile '" + conf.CurrentProfile + "' has unsaved changes.  Do you want to save them before switching?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
					case DialogResult.Yes:
						conf.SaveCurrentProfile();
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						doLoad = false;
						break;
				}
			}

			if(doLoad)
				conf.LoadProfile(profile);

            //if(tag == "tray")
            //    trayIcon.ShowBalloonTip(500, "MIDIControl", "The current profile is now '" + profile + "'.", ToolTipIcon.Info);
		}

		public void ReloadEntries() {
			// display all keybinds for current profile in listview
			listKeybinds.Items.Clear();

			foreach(KeyValuePair<string, KeyBindEntry> entry in conf.Config) {
				var item = new ListViewItem(entry.Key);
                item.UseItemStyleForSubItems = false;

				if(entry.Value.Input == Event.Note)
					item.ImageKey = "button";
				else if(entry.Value.Input == Event.Slider)
					item.ImageKey = "knob";

				// generate overview for details view
				var summary = entry.Value.Summarize();
				var overview = new ListViewItem.ListViewSubItem(item, summary);

                overview.ForeColor = this.GetCurrentTheme().ListViewSubitemForeColor;

				item.SubItems.Add(overview);
				item.ToolTipText = summary.Replace(" / ", "\n");

				listKeybinds.Items.Add(item);
			}

			RefreshWindowTitle();

			sepSelectedKeybind.Visible = butEditSelectedKeybind.Visible = butDeleteSelectedKeybind.Visible = false;
		}

		private void ListViewDisplayModeChanged(object sender, EventArgs e) {
			string mode = (sender as ToolStripMenuItem).Tag as string;
			string label = (sender as ToolStripMenuItem).Text;

			menuViewAsIcons.Checked = menuViewAsList.Checked = menuViewAsDetails.Checked = false;

			switch(mode) {
				case "icons":
					listKeybinds.View = View.Tile;
					menuViewAsIcons.Checked = true;
					break;
				case "list":
					listKeybinds.View = View.List;
					menuViewAsList.Checked = true;
					break;
				case "details":
					listKeybinds.View = View.Details;
					menuViewAsDetails.Checked = true;
					break;
			}

			menuViewAsDropdown.Text = "View as: " + label;

			// save preference
			options.options.ListViewStyle = mode;
			options.Save();
		}

		private void listKeybinds_MouseClick(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Right) {
				if(listKeybinds.SelectedItems.Count == 1) {
					itemContextMenu.Show(listKeybinds, e.Location);
				}
			}
		}

		private void listKeybinds_MouseDoubleClick(object sender, MouseEventArgs e) {
			if(e.Button == MouseButtons.Left) {
				editToolStripMenuItem_Click(sender, EventArgs.Empty);
			}
		}

		private void listKeybinds_SelectedIndexChanged(object sender, EventArgs e) {
			sepSelectedKeybind.Visible = butEditSelectedKeybind.Visible = butDeleteSelectedKeybind.Visible = (listKeybinds.SelectedItems.Count == 1);
			if(listKeybinds.SelectedItems.Count == 1) {
				butEditSelectedKeybind.Text = "Edit '" + listKeybinds.SelectedItems[0].Text + "'";
				butDeleteSelectedKeybind.Text = "Delete '" + listKeybinds.SelectedItems[0].Text + "'";
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e) {
			if(listKeybinds.SelectedIndices.Count == 1) {
				var index = listKeybinds.SelectedIndices[0];
				EditEntry(listKeybinds.Items[index].Text);
			}
		}

		private void AddKeybindItemClicked(object sender, EventArgs e) {
			using(EntryGUI addEntry = new EntryGUI()) {
				addEntry.StartPosition = FormStartPosition.CenterParent;
				if(addEntry.ShowDialog() == DialogResult.OK)
					ReloadEntries();
				midi.EnableListening();
			}
		}

		private void DeleteKeybindMenuItem_Click(object sender, EventArgs e) {
			if(listKeybinds.SelectedIndices.Count == 1) {
				var index = listKeybinds.SelectedIndices[0];
				string key = listKeybinds.Items[index].Text;
				bool delete = true;

				if(options.options.ConfirmKeybindDeletion) {
					delete = (MessageBox.Show("Delete the keybind named '" + key + "'?", "Confirm delete keybind", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
				}

				if(delete) {
					conf.Config.Remove(key);
					conf.Unsaved = true;
					ReloadEntries();
				}
			}
		}

		private void listKeybinds_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Delete) {
				DeleteKeybindMenuItem_Click(sender, e);
			}
		}

		private void SaveCurrentProfile_Click(object sender, EventArgs e) {
			conf.SaveCurrentProfile();
			RefreshWindowTitle();
		}

		private void saveCurrentProfileAsDefaultToolStripMenuItem_Click(object sender, EventArgs e) {
			conf.SaveCurrentProfileAs("Default");
			ReloadProfilesList();
			RefreshWindowTitle();

			options.options.LastUsedProfile = conf.CurrentProfile;
			options.Save();
		}

		private void DeleteCurrentProfileClicked(object sender, EventArgs e) {
			bool delete = true;

			if(options.options.ConfirmProfileDeletion) {
				if(conf.CurrentProfile == "Default") {
					// can't delete default, but offer to clear it
					if(MessageBox.Show("You are about to clear the default profile.  Are you sure you want to do this?", "Confirm default profile delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No) {
						delete = false;
					}
				} else {
					if(MessageBox.Show("You are about to delete the profile '" + conf.CurrentProfile + "'.  Are you sure you want to do this?", "Confirm profile delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No) {
						delete = false;
					}
				}
			}
			
			if(delete) {
				if(conf.CurrentProfile == "Default") {
					conf.Config.Clear();
					conf.SaveCurrentProfile();
				} else {
					conf.RemoveProfile(conf.CurrentProfile);
					conf.LoadProfile("Default");
				}

				ReloadProfilesList();
				ReloadEntries();
				RefreshWindowTitle();

				options.options.LastUsedProfile = conf.CurrentProfile;
				options.Save();
			}
		}

		private void NewProfileMenuItem_Click(object sender, EventArgs e) {
			bool doCreate = true;

			if(conf.Unsaved) {
				switch(MessageBox.Show("The current profile '" + conf.CurrentProfile + "' has unsaved changes.  Do you want to save them before creating a new profile?", "Unsaved changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) {
					case DialogResult.Yes:
						conf.SaveCurrentProfile();
						break;
					case DialogResult.No:
						break;
					case DialogResult.Cancel:
						doCreate = false;
						break;
				}
			}

			if(doCreate) {
				var newProfileResponse = this.PromptForNewProfileName("Enter a new profile name (no special characters):", "Name new profile");

				if(newProfileResponse.Accepted) {
					conf.Config.Clear();
					conf.SaveCurrentProfileAs(newProfileResponse.Text);
					ReloadProfilesList();
					ReloadEntries();
					RefreshWindowTitle();

					options.options.LastUsedProfile = conf.CurrentProfile;
					options.Save();
				}
			}
		}

		private void DuplicateProfileMenuItem_Click(object sender, EventArgs e) {
			//var dupProfileResponse = TextInputGUI.ShowPrompt("Enter a new name for the duplicate of '" + conf.CurrentProfile + "' (no special characters):", "Name duplicate of '" + conf.CurrentProfile + "'");
			var dupProfileResponse = this.PromptForNewProfileName("Enter a new name for the duplicate of '" + conf.CurrentProfile + "' (no special characters):", "Name duplicate of '" + conf.CurrentProfile + "'");

			if(dupProfileResponse.Accepted) {
				conf.SaveCurrentProfileAs(dupProfileResponse.Text);
				ReloadProfilesList();
				ReloadEntries();
				RefreshWindowTitle();

				options.options.LastUsedProfile = conf.CurrentProfile;
				options.Save();
			}
		}

		private TextInputResponse PromptForNewProfileName(string message, string caption, string initialValue = "") {
			bool validName = false;
			var newProfileResponse = new TextInputResponse();

			while(!validName) {
				newProfileResponse = TextInputGUI.ShowPrompt(message, caption);
				if(!newProfileResponse.Accepted) break;

				// new name can't be 'default' or an existing profile name
				if(newProfileResponse.Text.ToLower() == "default") {
					MessageBox.Show("New profile cannot be named 'default'.", "Invalid profile name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				} else if(conf.DoesProfileExist(newProfileResponse.Text.ToLower())) {
					MessageBox.Show("A profile with that name already exists.", "Profile already exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				} else if(newProfileResponse.Text.Trim() == "") {
					MessageBox.Show("New profile name cannot be blank.", "Invalid profile name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				} else {
					validName = true;
				}
			}

			return newProfileResponse;
		}

		private void trayIcon_BalloonTipClicked(object sender, EventArgs e) {
			//trayMenuShowMainWindow_Click(sender, e);
		}

		private void gitHubProjectPageToolStripMenuItem_Click(object sender, EventArgs e) {
			System.Diagnostics.Process.Start("https://github.com/Etuldan/MidiControl");
		}

		private void OpenNIControllerEditor_Clicked(object sender, EventArgs e) {
			System.Diagnostics.Process.Start(NIControllerEditorEXEPath);
		}
	}
}
