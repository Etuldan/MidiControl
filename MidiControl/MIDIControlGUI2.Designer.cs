namespace MidiControl {
	partial class MIDIControlGUI2 {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI2));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddKeybind = new System.Windows.Forms.ToolStripButton();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mIDIControlOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnSaveCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.obsButton = new System.Windows.Forms.ToolStripButton();
			this.twitchButton = new System.Windows.Forms.ToolStripButton();
			this.midiButton = new System.Windows.Forms.ToolStripButton();
			this.midiStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createFromCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnDeleteCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.listView1 = new System.Windows.Forms.ListView();
			this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.showMainWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStrip1.SuspendLayout();
			this.trayMenuStrip.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.itemContextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.btnSaveCurrentProfile,
            this.btnDeleteCurrentProfile,
            this.toolStripSeparator2,
            this.btnAddKeybind,
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(534, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.toolStripMenuItem5,
            this.mIDIControlOptionsToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem3,
            this.closeToTrayToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(51, 22);
			this.toolStripDropDownButton1.Text = "Menu";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAddKeybind
			// 
			this.btnAddKeybind.Image = global::MidiControl.Properties.Resources.plus;
			this.btnAddKeybind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddKeybind.Name = "btnAddKeybind";
			this.btnAddKeybind.Size = new System.Drawing.Size(94, 22);
			this.btnAddKeybind.Text = "Add keybind";
			// 
			// trayIcon
			// 
			this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.trayIcon.BalloonTipTitle = "MIDIControl";
			this.trayIcon.ContextMenuStrip = this.trayMenuStrip;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "MIDIControl";
			this.trayIcon.Visible = true;
			// 
			// trayMenuStrip
			// 
			this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMainWindowToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exitToolStripMenuItem1});
			this.trayMenuStrip.Name = "trayMenuStrip";
			this.trayMenuStrip.Size = new System.Drawing.Size(179, 54);
			// 
			// mIDIControlOptionsToolStripMenuItem
			// 
			this.mIDIControlOptionsToolStripMenuItem.Image = global::MidiControl.Properties.Resources.settings;
			this.mIDIControlOptionsToolStripMenuItem.Name = "mIDIControlOptionsToolStripMenuItem";
			this.mIDIControlOptionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.mIDIControlOptionsToolStripMenuItem.Text = "MIDIControl options...";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.settingsToolStripMenuItem.Text = "Interface options...";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
			// 
			// closeToTrayToolStripMenuItem
			// 
			this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
			this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.closeToTrayToolStripMenuItem.Text = "Close to tray";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			// 
			// btnSaveCurrentProfile
			// 
			this.btnSaveCurrentProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnSaveCurrentProfile.Image = global::MidiControl.Properties.Resources.floppy_disk;
			this.btnSaveCurrentProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveCurrentProfile.Name = "btnSaveCurrentProfile";
			this.btnSaveCurrentProfile.Size = new System.Drawing.Size(23, 22);
			this.btnSaveCurrentProfile.Text = "toolStripButton3";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// statusBar
			// 
			this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obsButton,
            this.twitchButton,
            this.midiButton,
            this.midiStatus});
			this.statusBar.Location = new System.Drawing.Point(0, 445);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(534, 22);
			this.statusBar.TabIndex = 3;
			// 
			// obsButton
			// 
			this.obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obsRed;
			this.obsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.obsButton.Name = "obsButton";
			this.obsButton.Size = new System.Drawing.Size(23, 20);
			// 
			// twitchButton
			// 
			this.twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitchRed;
			this.twitchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.twitchButton.Name = "twitchButton";
			this.twitchButton.Size = new System.Drawing.Size(23, 20);
			// 
			// midiButton
			// 
			this.midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDIRed;
			this.midiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.midiButton.Name = "midiButton";
			this.midiButton.Size = new System.Drawing.Size(23, 20);
			// 
			// midiStatus
			// 
			this.midiStatus.ForeColor = System.Drawing.Color.Red;
			this.midiStatus.Name = "midiStatus";
			this.midiStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// profilesToolStripMenuItem
			// 
			this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewToolStripMenuItem,
            this.createFromCurrentProfileToolStripMenuItem,
            this.toolStripMenuItem1});
			this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
			this.profilesToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
			this.profilesToolStripMenuItem.Text = "Profiles";
			// 
			// createNewToolStripMenuItem
			// 
			this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
			this.createNewToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.createNewToolStripMenuItem.Text = "Create new";
			// 
			// createFromCurrentProfileToolStripMenuItem
			// 
			this.createFromCurrentProfileToolStripMenuItem.Name = "createFromCurrentProfileToolStripMenuItem";
			this.createFromCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
			this.createFromCurrentProfileToolStripMenuItem.Text = "Create from current profile";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(212, 6);
			// 
			// btnDeleteCurrentProfile
			// 
			this.btnDeleteCurrentProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDeleteCurrentProfile.Image = global::MidiControl.Properties.Resources.rubbish;
			this.btnDeleteCurrentProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteCurrentProfile.Name = "btnDeleteCurrentProfile";
			this.btnDeleteCurrentProfile.Size = new System.Drawing.Size(23, 22);
			this.btnDeleteCurrentProfile.Text = "toolStripButton2";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = global::MidiControl.Properties.Resources.mute;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton1.Text = "Stop all sounds";
			// 
			// listView1
			// 
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 25);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(534, 420);
			this.listView1.TabIndex = 4;
			this.listView1.UseCompatibleStateImageBehavior = false;
			// 
			// itemContextMenu
			// 
			this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.duplicateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
			this.itemContextMenu.Name = "itemContextMenu";
			this.itemContextMenu.Size = new System.Drawing.Size(125, 76);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Image = global::MidiControl.Properties.Resources.edit;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.editToolStripMenuItem.Text = "Edit...";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::MidiControl.Properties.Resources.minus;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.deleteToolStripMenuItem.Text = "Delete...";
			// 
			// duplicateToolStripMenuItem
			// 
			this.duplicateToolStripMenuItem.Name = "duplicateToolStripMenuItem";
			this.duplicateToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.duplicateToolStripMenuItem.Text = "Duplicate";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(121, 6);
			// 
			// showMainWindowToolStripMenuItem
			// 
			this.showMainWindowToolStripMenuItem.Name = "showMainWindowToolStripMenuItem";
			this.showMainWindowToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.showMainWindowToolStripMenuItem.Text = "Show main window";
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(175, 6);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(178, 22);
			this.exitToolStripMenuItem1.Text = "Exit";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(188, 6);
			// 
			// MIDIControlGUI2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 467);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MIDIControlGUI2";
			this.Text = "MIDIControl - [ProfileName]";
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.trayMenuStrip.ResumeLayout(false);
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.itemContextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnAddKeybind;
		private System.Windows.Forms.NotifyIcon trayIcon;
		private System.Windows.Forms.ContextMenuStrip trayMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem mIDIControlOptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem closeToTrayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton btnSaveCurrentProfile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.StatusStrip statusBar;
		private System.Windows.Forms.ToolStripButton obsButton;
		private System.Windows.Forms.ToolStripButton twitchButton;
		private System.Windows.Forms.ToolStripButton midiButton;
		private System.Windows.Forms.ToolStripStatusLabel midiStatus;
		private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createFromCurrentProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripButton btnDeleteCurrentProfile;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ToolStripMenuItem showMainWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.ContextMenuStrip itemContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
	}
}