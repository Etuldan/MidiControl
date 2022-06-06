using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl {
	public partial class MIDIControlGUI2 : Form {
		public delegate void OBSControlDelegateHandler(bool connect);
		public OBSControlDelegateHandler OBSControlDelegate;
		public delegate void TwitchControlDelegateHandler(bool connect);
		public TwitchControlDelegateHandler TwitchControlDelegate;
		public delegate void SwitchProfileControlDelegateHandler();
		public SwitchProfileControlDelegateHandler SwitchProfileControlDelegate;
		private readonly OptionsManagment options;
		private readonly Configuration conf;
		private readonly MIDIListener midi;

		private bool actuallyClosing = false;
		private bool windowWasShown = false;

		private const string STATIC_PROFILEMENU_TAG = "#STATIC_PROFILE_MENU_ITEM#";

		private ImageList keybindIconList;

		private static MIDIControlGUI2 _inst;
		public static MIDIControlGUI2 GetInstance() {
			return _inst;
		}

		// active window theme name
		private string windowTheme = "default";

		// window constructor
		public MIDIControlGUI2() {
			_inst = this;
			InitializeComponent();			

			OBSControlDelegate = new OBSControlDelegateHandler(UpdateOBSStatus);
			TwitchControlDelegate = new TwitchControlDelegateHandler(UpdateTwitchStatus);
			SwitchProfileControlDelegate = new SwitchProfileControlDelegateHandler(UpdateProfile);

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

			// todo: load theme from config
			//this.windowTheme = "default";
			this.SetWindowTheme(options.options.Theme);
		}

		// form, tray icon, close window events

		private void SetWindowTheme(int theme) {
			ThemeSupport.MidiControlTheme mcTheme = ThemeSupport.GetThemeByIndex(theme);

			this.BackColor = mcTheme.WindowBackColor;

			toolStrip1.Renderer = new ToolStripProfessionalRenderer(mcTheme);
			statusBar.Renderer = new ToolStripProfessionalRenderer(mcTheme);
			trayMenuStrip.Renderer = new ToolStripProfessionalRenderer(mcTheme);
			itemContextMenu.Renderer = new ToolStripProfessionalRenderer(mcTheme);

			statusBar.SizingGrip = mcTheme.ShowStatusBarGrip;

			listKeybinds.BackColor = mcTheme.ListViewBackColor;
			listKeybinds.ForeColor = mcTheme.ListViewForeColor;
			listKeybinds.BorderStyle = mcTheme.ListViewBorderStyle;

			ThemeSubitems(toolStrip1.Items, mcTheme);
			ThemeSubitems(trayMenuStrip.Items, mcTheme);
			ThemeSubitems(itemContextMenu.Items, mcTheme);

			btnSaveCurrentProfile.Image = saveCurrentProfileToolStripMenuItem.Image = mcTheme.SaveIcon;
			editToolStripMenuItem.Image = mcTheme.EditIcon;
			btnDeleteCurrentProfile.Image = deleteCurrentProfileToolStripMenuItem.Image = mcTheme.DeleteIcon;
			deleteToolStripMenuItem.Image = mcTheme.MinusIcon;
			btnAddKeybind.Image = addKeybindToolStripMenuItem.Image = mcTheme.PlusIcon;
			btnStopAllSounds.Image = mcTheme.MuteIcon;
			MidiControlOptionsToolStripMenuItem.Image = mcTheme.SettingsIcon;

			// need to fix these from being BackgroundImages instead of Images
			//obsButton.Image = mcTheme.OBSIcon;
			//twitchButton.Image = mcTheme.TwitchIcon;
			//midiButton.Image = mcTheme.MIDIIcon;

			keybindIconList.Images.Clear();
			keybindIconList.Images.Add("button", mcTheme.ControlButtonIcon);
			keybindIconList.Images.Add("knob", mcTheme.ControlKnobIcon);

			ReloadEntries();
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

		private void MIDIControlGUI2_Load(object sender, EventArgs e) {
			ReloadEntries();
			OBSControl.GetInstance().ConnectDisconnect();

			this.windowWasShown = true;
		}

		private void MIDIControlGUI2_FormClosing(object sender, FormClosingEventArgs e) {
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

		private void MIDIControlGUI2_FormClosed(object sender, FormClosedEventArgs e) {
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
			this.Text = trayIcon.Text = "MIDIControl - [" + conf.CurrentProfile + (conf.Unsaved?"*":"") + "]";
		}

		// delegate handlers; from MIDIControlGUI; config/profiles/keybind refresh
		private void ReloadProfilesList() {
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

			foreach(var profile in conf.GetAllProfiles()) {
				var newitem = new ToolStripMenuItem(profile) {
					Tag = profile
				};
				newitem.Click += ProfileMenuItemClicked;

				menuProfiles.DropDownItems.Add(newitem);
			}

			CheckCurrentProfileMenuItem();
		}

		private void CheckCurrentProfileMenuItem() {
			foreach(ToolStripItem item in menuProfiles.DropDownItems) {
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

		private void UpdateMIDIStatus() {
			midiStatus.Text = "";
			foreach(string device in midi.GetMIDIINDevices()) {
				midiStatus.Text += " " + device + ",";
			}
			midiStatus.Text = midiStatus.Text.Trim(',').Trim();
			if(midiStatus.Text == "") {
				midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDIRed;
				midiStatus.Text = "N/A";
				midiStatus.ForeColor = Color.Red;
			} else {
				midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDI;
				midiStatus.ForeColor = Color.Green;
			}
		}

		private void UpdateOBSStatus(bool connect) {
			if(connect) {
				obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obs;
			} else {
				obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obsRed;
			}
		}
		private void UpdateTwitchStatus(bool connect) {
			if(connect) {
				twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitch;
			} else {
				twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitchRed;
			}
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
			using(OptionsGUI optionGUI = new OptionsGUI(options, 1)) {
				optionGUI.ShowDialog();
				this.TopMost = options.options.AlwaysOnTop;
				this.toolStrip1.Dock = (options.options.ToolbarPosition == 1 ? DockStyle.Bottom : DockStyle.Top);
				this.SetWindowTheme(options.options.Theme);
			}
		}

		private void ProfileMenuItemClicked(object sender, EventArgs e) {
			var profile = ((ToolStripMenuItem)sender).Text;
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
		}

		public void ReloadEntries() {
			// display all keybinds for current profile in listview
			listKeybinds.Items.Clear();

			foreach(KeyValuePair<string, KeyBindEntry> entry in conf.Config) {
				var item = new ListViewItem(entry.Key);

				if(entry.Value.Input == Event.Note)
					item.ImageKey = "button";
				else if(entry.Value.Input == Event.Slider)
					item.ImageKey = "knob";

				// generate overview for details view
				var summary = entry.Value.Summarize();
				var overview = new ListViewItem.ListViewSubItem(item, summary);
				item.SubItems.Add(overview);
				item.ToolTipText = summary.Replace(" / ", "\n");

				listKeybinds.Items.Add(item);
			}

			RefreshWindowTitle();
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
				} else if(conf.DoesProfileExist(newProfileResponse.Text)) {
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
	}
}
