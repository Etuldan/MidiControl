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

		private static MIDIControlGUI2 _inst;
		public static MIDIControlGUI2 GetInstance() {
			return _inst;
		}

		// window constructor
		public MIDIControlGUI2() {
			_inst = this;
			InitializeComponent();

			// ...

			trayIcon.BalloonTipText = "MIDIControl is now running.  Double-click the tray icon to open the main window.";
		}

		// form, tray icon, close window events
		private void MIDIControlGUI2_Load(object sender, EventArgs e) {

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

		// delegate handlers
		//

		// ui events
		//
	}
}
