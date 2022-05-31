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
			this.Text = "MIDIControl - [" + conf.CurrentProfile + "]";

			midi = new MIDIListener(conf);
			UpdateMIDIStatus();

			ReloadProfilesList();

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
		}

		private void UpdateProfile() {
			ReloadEntries();

			// set selected profile in menu
			// ...
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

		public void ReloadEntries() {
			// display all keybinds for current profile in listview
			// ...
		}


		// ui events
		private void ProfileMenuItemClicked(object sender, EventArgs e) {

		}
	}
}
