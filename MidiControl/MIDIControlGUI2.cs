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

		private const string STATIC_PROFILEMENU_TAG = "#STATIC_PROFILE_MENU_ITEM#";

		private static MIDIControlGUI2 _inst;
		public static MIDIControlGUI2 GetInstance() {
			return _inst;
		}

		// window constructor
		public MIDIControlGUI2() {
			_inst = this;
			InitializeComponent();			

			OBSControlDelegate = new OBSControlDelegateHandler(UpdateOBSStatus);
			TwitchControlDelegate = new TwitchControlDelegateHandler(UpdateTwitchStatus);
			SwitchProfileControlDelegate = new SwitchProfileControlDelegateHandler(UpdateProfile);

			options = new OptionsManagment();
			conf = new Configuration(this, options.options.LastUsedProfile);

			midi = new MIDIListener(conf);
			UpdateMIDIStatus();

			ReloadProfilesList();
			RefreshWindowTitle();

			trayIcon.BalloonTipText = "MIDIControl is now running.  Double-click the tray icon to open the main window.";
		}

		// form, tray icon, close window events
		private void MIDIControlGUI2_Load(object sender, EventArgs e) {
			ReloadEntries();
			OBSControl.GetInstance().ConnectDisconnect();
		}

		private void MIDIControlGUI2_FormClosing(object sender, FormClosingEventArgs e) {
			if(!this.actuallyClosing) {
				e.Cancel = true;

				this.Hide();
				trayIcon.BalloonTipText = "MIDIControl is still running.  Double-click the tray icon to reopen the main window.";
				trayIcon.ShowBalloonTip(500);
			}
		}

		private void MIDIControlGUI2_FormClosed(object sender, FormClosedEventArgs e) {
			// actual program close stuff here
			//

			// if the program started to tray, kill the main app thread since it was started without being linked to the window
			if(options.options.StartToTray) {
				Application.ExitThread();
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
		}

		private void closeToTrayToolStripMenuItem_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			this.actuallyClosing = true;
			this.Close();
		}

		private void RefreshWindowTitle() {
			this.Text = "MIDIControl - [" + conf.CurrentProfile + (conf.Unsaved?"*":"") + "]";
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
			} else {
				btnDeleteCurrentProfile.Text = deleteCurrentProfileToolStripMenuItem.Text = "Delete current profile";
			}
		}

		private void UpdateProfile() {
			ReloadEntries();

			// set selected profile in menu
			CheckCurrentProfileMenuItem();
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
					addEntry.ShowDialog();
					ReloadEntries();
					midi.EnableListening();
				}
			}
		}

		// ui events
		private void MidiControlOptionsToolStripMenuItem_Click(object sender, EventArgs e) {
			using(OptionsGUI optionGUI = new OptionsGUI(options))
				optionGUI.ShowDialog();
		}

		private void ProfileMenuItemClicked(object sender, EventArgs e) {
			var profile = ((ToolStripMenuItem)sender).Text;

			conf.LoadProfile(profile);
		}

		public void ReloadEntries() {
			// display all keybinds for current profile in listview
			listKeybinds.Items.Clear();

			foreach(KeyValuePair<string, KeyBindEntry> entry in conf.Config) {
				var item = new ListViewItem(entry.Key);
				
				// generate overview for details view
				// ...

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
				addEntry.ShowDialog();
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

		private void btnSaveCurrentProfile_Click(object sender, EventArgs e) {
			conf.SaveCurrentProfile();
			RefreshWindowTitle();
		}

		private void saveCurrentProfileAsDefaultToolStripMenuItem_Click(object sender, EventArgs e) {
			conf.SaveCurrentProfileAs("Default");
			ReloadProfilesList();
			RefreshWindowTitle();
		}

		private void DeleteCurrentProfileClicked(object sender, EventArgs e) {
			if(conf.CurrentProfile == "Default") {
				// can't delete default, but offer to clear it
				if(MessageBox.Show("You are about to clear the default profile.  Are you sure you want to do this?", "Confirm default profile delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
					conf.Config.Clear();
					conf.SaveCurrentProfile();
				}
			} else {
				if(MessageBox.Show("You are about to delete the profile '" + conf.CurrentProfile + "'.  Are you sure you want to do this?", "Confirm profile delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes) {
					conf.RemoveProfile(conf.CurrentProfile);
					conf.LoadProfile("Default");
				}
			}

			ReloadProfilesList();
			RefreshWindowTitle();
		}

		
	}
}
