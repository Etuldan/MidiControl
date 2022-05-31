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
			this.menuProfiles = new System.Windows.Forms.ToolStripMenuItem();
			this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.createFromCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.profileListHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addKeybindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.mIDIControlOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSaveCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.btnDeleteCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddKeybind = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuViewAsDropdown = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuViewAsIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAsList = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAsDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trayMenuShowMainWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.obsButton = new System.Windows.Forms.ToolStripButton();
			this.twitchButton = new System.Windows.Forms.ToolStripButton();
			this.midiButton = new System.Windows.Forms.ToolStripButton();
			this.midiStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.listKeybinds = new System.Windows.Forms.ListView();
			this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.menuViewAsDropdown});
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
            this.menuProfiles,
            this.addKeybindToolStripMenuItem,
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
			// menuProfiles
			// 
			this.menuProfiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewToolStripMenuItem,
            this.createFromCurrentProfileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveCurrentProfileToolStripMenuItem,
            this.deleteCurrentProfileToolStripMenuItem,
            this.toolStripMenuItem6,
            this.profileListHereToolStripMenuItem});
			this.menuProfiles.Name = "menuProfiles";
			this.menuProfiles.Size = new System.Drawing.Size(193, 22);
			this.menuProfiles.Text = "Profiles";
			// 
			// createNewToolStripMenuItem
			// 
			this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
			this.createNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.createNewToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
			this.createNewToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.createNewToolStripMenuItem.Text = "Create new";
			// 
			// createFromCurrentProfileToolStripMenuItem
			// 
			this.createFromCurrentProfileToolStripMenuItem.Name = "createFromCurrentProfileToolStripMenuItem";
			this.createFromCurrentProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
			this.createFromCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
			this.createFromCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.createFromCurrentProfileToolStripMenuItem.Text = "Create from current profile";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(286, 6);
			this.toolStripMenuItem1.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			// 
			// saveCurrentProfileToolStripMenuItem
			// 
			this.saveCurrentProfileToolStripMenuItem.Image = global::MidiControl.Properties.Resources.floppy_disk;
			this.saveCurrentProfileToolStripMenuItem.Name = "saveCurrentProfileToolStripMenuItem";
			this.saveCurrentProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
			this.saveCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.saveCurrentProfileToolStripMenuItem.Text = "Save current profile";
			// 
			// deleteCurrentProfileToolStripMenuItem
			// 
			this.deleteCurrentProfileToolStripMenuItem.Image = global::MidiControl.Properties.Resources.rubbish;
			this.deleteCurrentProfileToolStripMenuItem.Name = "deleteCurrentProfileToolStripMenuItem";
			this.deleteCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
			this.deleteCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.deleteCurrentProfileToolStripMenuItem.Text = "Delete current profile";
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(286, 6);
			this.toolStripMenuItem6.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			// 
			// profileListHereToolStripMenuItem
			// 
			this.profileListHereToolStripMenuItem.Enabled = false;
			this.profileListHereToolStripMenuItem.Name = "profileListHereToolStripMenuItem";
			this.profileListHereToolStripMenuItem.Size = new System.Drawing.Size(289, 22);
			this.profileListHereToolStripMenuItem.Text = "(profile list here)";
			// 
			// addKeybindToolStripMenuItem
			// 
			this.addKeybindToolStripMenuItem.Image = global::MidiControl.Properties.Resources.plus;
			this.addKeybindToolStripMenuItem.Name = "addKeybindToolStripMenuItem";
			this.addKeybindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.addKeybindToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.addKeybindToolStripMenuItem.Text = "Add keybind...";
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(190, 6);
			// 
			// mIDIControlOptionsToolStripMenuItem
			// 
			this.mIDIControlOptionsToolStripMenuItem.Image = global::MidiControl.Properties.Resources.settings;
			this.mIDIControlOptionsToolStripMenuItem.Name = "mIDIControlOptionsToolStripMenuItem";
			this.mIDIControlOptionsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.mIDIControlOptionsToolStripMenuItem.Text = "MIDIControl options...";
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.settingsToolStripMenuItem.Text = "Interface options...";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(190, 6);
			// 
			// closeToTrayToolStripMenuItem
			// 
			this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
			this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.closeToTrayToolStripMenuItem.Text = "Close to tray";
			this.closeToTrayToolStripMenuItem.Click += new System.EventHandler(this.closeToTrayToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
			// btnDeleteCurrentProfile
			// 
			this.btnDeleteCurrentProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDeleteCurrentProfile.Image = global::MidiControl.Properties.Resources.rubbish;
			this.btnDeleteCurrentProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteCurrentProfile.Name = "btnDeleteCurrentProfile";
			this.btnDeleteCurrentProfile.Size = new System.Drawing.Size(23, 22);
			this.btnDeleteCurrentProfile.Text = "toolStripButton2";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAddKeybind
			// 
			this.btnAddKeybind.Image = global::MidiControl.Properties.Resources.plus;
			this.btnAddKeybind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddKeybind.Name = "btnAddKeybind";
			this.btnAddKeybind.Size = new System.Drawing.Size(94, 22);
			this.btnAddKeybind.Text = "Add keybind";
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
			this.toolStripButton1.Click += new System.EventHandler(this.StopAllSoundsClicked);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// menuViewAsDropdown
			// 
			this.menuViewAsDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.menuViewAsDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewAsIcons,
            this.menuViewAsList,
            this.menuViewAsDetails});
			this.menuViewAsDropdown.Image = ((System.Drawing.Image)(resources.GetObject("menuViewAsDropdown.Image")));
			this.menuViewAsDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.menuViewAsDropdown.Name = "menuViewAsDropdown";
			this.menuViewAsDropdown.Size = new System.Drawing.Size(93, 22);
			this.menuViewAsDropdown.Text = "View as: Icons";
			// 
			// menuViewAsIcons
			// 
			this.menuViewAsIcons.Checked = true;
			this.menuViewAsIcons.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuViewAsIcons.Name = "menuViewAsIcons";
			this.menuViewAsIcons.Size = new System.Drawing.Size(180, 22);
			this.menuViewAsIcons.Tag = "icons";
			this.menuViewAsIcons.Text = "Icons";
			this.menuViewAsIcons.Click += new System.EventHandler(this.ListViewDisplayModeChanged);
			// 
			// menuViewAsList
			// 
			this.menuViewAsList.Name = "menuViewAsList";
			this.menuViewAsList.Size = new System.Drawing.Size(180, 22);
			this.menuViewAsList.Tag = "list";
			this.menuViewAsList.Text = "List";
			this.menuViewAsList.Click += new System.EventHandler(this.ListViewDisplayModeChanged);
			// 
			// menuViewAsDetails
			// 
			this.menuViewAsDetails.Name = "menuViewAsDetails";
			this.menuViewAsDetails.Size = new System.Drawing.Size(180, 22);
			this.menuViewAsDetails.Tag = "details";
			this.menuViewAsDetails.Text = "Details";
			this.menuViewAsDetails.Click += new System.EventHandler(this.ListViewDisplayModeChanged);
			// 
			// trayIcon
			// 
			this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.trayIcon.BalloonTipTitle = "MIDIControl";
			this.trayIcon.ContextMenuStrip = this.trayMenuStrip;
			this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
			this.trayIcon.Text = "MIDIControl";
			this.trayIcon.Visible = true;
			this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
			// 
			// trayMenuStrip
			// 
			this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuShowMainWindow,
            this.toolStripMenuItem4,
            this.trayMenuExit});
			this.trayMenuStrip.Name = "trayMenuStrip";
			this.trayMenuStrip.Size = new System.Drawing.Size(183, 54);
			// 
			// trayMenuShowMainWindow
			// 
			this.trayMenuShowMainWindow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.trayMenuShowMainWindow.Name = "trayMenuShowMainWindow";
			this.trayMenuShowMainWindow.Size = new System.Drawing.Size(182, 22);
			this.trayMenuShowMainWindow.Text = "Show main window";
			this.trayMenuShowMainWindow.Click += new System.EventHandler(this.trayMenuShowMainWindow_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(179, 6);
			// 
			// trayMenuExit
			// 
			this.trayMenuExit.Name = "trayMenuExit";
			this.trayMenuExit.Size = new System.Drawing.Size(182, 22);
			this.trayMenuExit.Text = "Exit";
			this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);
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
			this.obsButton.Click += new System.EventHandler(this.OBSStatusButtonClicked);
			// 
			// twitchButton
			// 
			this.twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitchRed;
			this.twitchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.twitchButton.Name = "twitchButton";
			this.twitchButton.Size = new System.Drawing.Size(23, 20);
			this.twitchButton.Click += new System.EventHandler(this.TwitchStatusButtonClicked);
			// 
			// midiButton
			// 
			this.midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDIRed;
			this.midiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.midiButton.Name = "midiButton";
			this.midiButton.Size = new System.Drawing.Size(23, 20);
			this.midiButton.Click += new System.EventHandler(this.MidiStatusButtonClicked);
			// 
			// midiStatus
			// 
			this.midiStatus.ForeColor = System.Drawing.Color.Red;
			this.midiStatus.Name = "midiStatus";
			this.midiStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// listKeybinds
			// 
			this.listKeybinds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listKeybinds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listKeybinds.HideSelection = false;
			this.listKeybinds.Location = new System.Drawing.Point(0, 25);
			this.listKeybinds.Name = "listKeybinds";
			this.listKeybinds.Size = new System.Drawing.Size(534, 420);
			this.listKeybinds.TabIndex = 4;
			this.listKeybinds.UseCompatibleStateImageBehavior = false;
			this.listKeybinds.View = System.Windows.Forms.View.Tile;
			this.listKeybinds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listKeybinds_MouseClick);
			this.listKeybinds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listKeybinds_MouseDoubleClick);
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
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
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
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::MidiControl.Properties.Resources.minus;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.deleteToolStripMenuItem.Text = "Delete...";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Keybind Name";
			this.columnHeader1.Width = 156;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Overview";
			this.columnHeader2.Width = 355;
			// 
			// MIDIControlGUI2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 467);
			this.Controls.Add(this.listKeybinds);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.toolStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MIDIControlGUI2";
			this.Text = "MIDIControl - [ProfileName]";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIDIControlGUI2_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MIDIControlGUI2_FormClosed);
			this.Load += new System.EventHandler(this.MIDIControlGUI2_Load);
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
		private System.Windows.Forms.ToolStripMenuItem menuProfiles;
		private System.Windows.Forms.ToolStripMenuItem createNewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createFromCurrentProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripButton btnDeleteCurrentProfile;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ListView listKeybinds;
		private System.Windows.Forms.ToolStripMenuItem trayMenuShowMainWindow;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
		private System.Windows.Forms.ContextMenuStrip itemContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem duplicateToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripDropDownButton menuViewAsDropdown;
		private System.Windows.Forms.ToolStripMenuItem menuViewAsIcons;
		private System.Windows.Forms.ToolStripMenuItem menuViewAsList;
		private System.Windows.Forms.ToolStripMenuItem menuViewAsDetails;
		private System.Windows.Forms.ToolStripMenuItem saveCurrentProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteCurrentProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem profileListHereToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addKeybindToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
	}
}