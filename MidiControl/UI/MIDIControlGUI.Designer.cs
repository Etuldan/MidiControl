﻿namespace MidiControl {
	partial class MIDIControlGUI {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuProfiles = new System.Windows.Forms.ToolStripMenuItem();
			this.createNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.duplicateCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.saveCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveCurrentProfileAsDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteCurrentProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.profileListHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addKeybindToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.MidiControlOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.InterfaceOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuNIControllerEditor = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.gitHubProjectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.closeToTrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSaveCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.btnDeleteCurrentProfile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddKeybind = new System.Windows.Forms.ToolStripButton();
			this.btnStopAllSounds = new System.Windows.Forms.ToolStripButton();
			this.sepSelectedKeybind = new System.Windows.Forms.ToolStripSeparator();
			this.butEditSelectedKeybind = new System.Windows.Forms.ToolStripButton();
			this.butDeleteSelectedKeybind = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuViewAsDropdown = new System.Windows.Forms.ToolStripDropDownButton();
			this.menuViewAsIcons = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAsList = new System.Windows.Forms.ToolStripMenuItem();
			this.menuViewAsDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.trayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trayMenuShowMainWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.SwitchProfileTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
			this.statusBar = new System.Windows.Forms.StatusStrip();
			this.obsButton = new System.Windows.Forms.ToolStripButton();
			this.twitchButton = new System.Windows.Forms.ToolStripButton();
			this.midiButton = new System.Windows.Forms.ToolStripButton();
			this.midiStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.itemContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DuplicateKeybindMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.listKeybinds = new System.Windows.Forms.ListView();
			this.colKeybind = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colOverview = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1.SuspendLayout();
			this.trayMenuStrip.SuspendLayout();
			this.statusBar.SuspendLayout();
			this.itemContextMenu.SuspendLayout();
			this.panel1.SuspendLayout();
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
            this.btnStopAllSounds,
            this.sepSelectedKeybind,
            this.butEditSelectedKeybind,
            this.butDeleteSelectedKeybind,
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
			this.toolStripDropDownButton1.AutoToolTip = false;
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProfiles,
            this.addKeybindToolStripMenuItem,
            this.toolStripMenuItem5,
            this.MidiControlOptionsToolStripMenuItem,
            this.InterfaceOptionsMenuItem,
            this.mnuNIControllerEditor,
            this.toolStripMenuItem3,
            this.gitHubProjectPageToolStripMenuItem,
            this.toolStripMenuItem7,
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
            this.duplicateCurrentProfileToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveCurrentProfileToolStripMenuItem,
            this.saveCurrentProfileAsDefaultToolStripMenuItem,
            this.deleteCurrentProfileToolStripMenuItem,
            this.toolStripMenuItem6,
            this.profileListHereToolStripMenuItem});
			this.menuProfiles.Name = "menuProfiles";
			this.menuProfiles.Size = new System.Drawing.Size(217, 22);
			this.menuProfiles.Text = "Profiles";
			// 
			// createNewToolStripMenuItem
			// 
			this.createNewToolStripMenuItem.Name = "createNewToolStripMenuItem";
			this.createNewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
			this.createNewToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.createNewToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.createNewToolStripMenuItem.Text = "Create new";
			this.createNewToolStripMenuItem.Click += new System.EventHandler(this.NewProfileMenuItem_Click);
			// 
			// duplicateCurrentProfileToolStripMenuItem
			// 
			this.duplicateCurrentProfileToolStripMenuItem.Name = "duplicateCurrentProfileToolStripMenuItem";
			this.duplicateCurrentProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
			this.duplicateCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.duplicateCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.duplicateCurrentProfileToolStripMenuItem.Text = "Duplicate current profile";
			this.duplicateCurrentProfileToolStripMenuItem.Click += new System.EventHandler(this.DuplicateProfileMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(273, 6);
			this.toolStripMenuItem1.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			// 
			// saveCurrentProfileToolStripMenuItem
			// 
			this.saveCurrentProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveCurrentProfileToolStripMenuItem.Image")));
			this.saveCurrentProfileToolStripMenuItem.Name = "saveCurrentProfileToolStripMenuItem";
			this.saveCurrentProfileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.saveCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.saveCurrentProfileToolStripMenuItem.Text = "Save current profile";
			this.saveCurrentProfileToolStripMenuItem.Click += new System.EventHandler(this.SaveCurrentProfile_Click);
			// 
			// saveCurrentProfileAsDefaultToolStripMenuItem
			// 
			this.saveCurrentProfileAsDefaultToolStripMenuItem.Name = "saveCurrentProfileAsDefaultToolStripMenuItem";
			this.saveCurrentProfileAsDefaultToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.saveCurrentProfileAsDefaultToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.saveCurrentProfileAsDefaultToolStripMenuItem.Text = "Save current profile as default";
			this.saveCurrentProfileAsDefaultToolStripMenuItem.Click += new System.EventHandler(this.saveCurrentProfileAsDefaultToolStripMenuItem_Click);
			// 
			// deleteCurrentProfileToolStripMenuItem
			// 
			this.deleteCurrentProfileToolStripMenuItem.Image = global::MidiControl.Properties.Resources.rubbish;
			this.deleteCurrentProfileToolStripMenuItem.Name = "deleteCurrentProfileToolStripMenuItem";
			this.deleteCurrentProfileToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.deleteCurrentProfileToolStripMenuItem.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			this.deleteCurrentProfileToolStripMenuItem.Text = "Delete current profile";
			this.deleteCurrentProfileToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrentProfileClicked);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(273, 6);
			this.toolStripMenuItem6.Tag = "#STATIC_PROFILE_MENU_ITEM#";
			// 
			// profileListHereToolStripMenuItem
			// 
			this.profileListHereToolStripMenuItem.Enabled = false;
			this.profileListHereToolStripMenuItem.Name = "profileListHereToolStripMenuItem";
			this.profileListHereToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
			this.profileListHereToolStripMenuItem.Text = "(profile list here)";
			// 
			// addKeybindToolStripMenuItem
			// 
			this.addKeybindToolStripMenuItem.Image = global::MidiControl.Properties.Resources.plus;
			this.addKeybindToolStripMenuItem.Name = "addKeybindToolStripMenuItem";
			this.addKeybindToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.addKeybindToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.addKeybindToolStripMenuItem.Text = "Add keybind...";
			this.addKeybindToolStripMenuItem.Click += new System.EventHandler(this.AddKeybindItemClicked);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(214, 6);
			// 
			// MidiControlOptionsToolStripMenuItem
			// 
			this.MidiControlOptionsToolStripMenuItem.Image = global::MidiControl.Properties.Resources.settings;
			this.MidiControlOptionsToolStripMenuItem.Name = "MidiControlOptionsToolStripMenuItem";
			this.MidiControlOptionsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.MidiControlOptionsToolStripMenuItem.Text = "MIDIControl options...";
			this.MidiControlOptionsToolStripMenuItem.Click += new System.EventHandler(this.MidiControlOptionsToolStripMenuItem_Click);
			// 
			// InterfaceOptionsMenuItem
			// 
			this.InterfaceOptionsMenuItem.Name = "InterfaceOptionsMenuItem";
			this.InterfaceOptionsMenuItem.Size = new System.Drawing.Size(217, 22);
			this.InterfaceOptionsMenuItem.Text = "Interface options...";
			this.InterfaceOptionsMenuItem.Click += new System.EventHandler(this.InterfaceOptionsMenuItem_Click);
			// 
			// mnuNIControllerEditor
			// 
			this.mnuNIControllerEditor.Name = "mnuNIControllerEditor";
			this.mnuNIControllerEditor.Size = new System.Drawing.Size(217, 22);
			this.mnuNIControllerEditor.Text = "Open NI Controller Editor...";
			this.mnuNIControllerEditor.Click += new System.EventHandler(this.OpenNIControllerEditor_Clicked);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(214, 6);
			// 
			// gitHubProjectPageToolStripMenuItem
			// 
			this.gitHubProjectPageToolStripMenuItem.Name = "gitHubProjectPageToolStripMenuItem";
			this.gitHubProjectPageToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.gitHubProjectPageToolStripMenuItem.Text = "GitHub project page";
			this.gitHubProjectPageToolStripMenuItem.Click += new System.EventHandler(this.gitHubProjectPageToolStripMenuItem_Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(214, 6);
			// 
			// closeToTrayToolStripMenuItem
			// 
			this.closeToTrayToolStripMenuItem.Name = "closeToTrayToolStripMenuItem";
			this.closeToTrayToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
			this.closeToTrayToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
			this.closeToTrayToolStripMenuItem.Text = "Close to tray";
			this.closeToTrayToolStripMenuItem.Click += new System.EventHandler(this.closeToTrayToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Q)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
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
			this.btnSaveCurrentProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCurrentProfile.Image")));
			this.btnSaveCurrentProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveCurrentProfile.Name = "btnSaveCurrentProfile";
			this.btnSaveCurrentProfile.Size = new System.Drawing.Size(23, 22);
			this.btnSaveCurrentProfile.Text = "Save current profile";
			this.btnSaveCurrentProfile.Click += new System.EventHandler(this.SaveCurrentProfile_Click);
			// 
			// btnDeleteCurrentProfile
			// 
			this.btnDeleteCurrentProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnDeleteCurrentProfile.Image = global::MidiControl.Properties.Resources.rubbish;
			this.btnDeleteCurrentProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteCurrentProfile.Name = "btnDeleteCurrentProfile";
			this.btnDeleteCurrentProfile.Size = new System.Drawing.Size(23, 22);
			this.btnDeleteCurrentProfile.Text = "toolStripButton2";
			this.btnDeleteCurrentProfile.Click += new System.EventHandler(this.DeleteCurrentProfileClicked);
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
			this.btnAddKeybind.ToolTipText = "Adds a new keybind to the current profile";
			this.btnAddKeybind.Click += new System.EventHandler(this.AddKeybindItemClicked);
			// 
			// btnStopAllSounds
			// 
			this.btnStopAllSounds.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.btnStopAllSounds.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnStopAllSounds.Image = global::MidiControl.Properties.Resources.mute;
			this.btnStopAllSounds.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnStopAllSounds.Name = "btnStopAllSounds";
			this.btnStopAllSounds.Size = new System.Drawing.Size(23, 22);
			this.btnStopAllSounds.Text = "Stop all sounds";
			this.btnStopAllSounds.Click += new System.EventHandler(this.StopAllSoundsClicked);
			// 
			// sepSelectedKeybind
			// 
			this.sepSelectedKeybind.Name = "sepSelectedKeybind";
			this.sepSelectedKeybind.Size = new System.Drawing.Size(6, 25);
			this.sepSelectedKeybind.Visible = false;
			// 
			// butEditSelectedKeybind
			// 
			this.butEditSelectedKeybind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.butEditSelectedKeybind.Image = global::MidiControl.Properties.Resources.edit;
			this.butEditSelectedKeybind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.butEditSelectedKeybind.Name = "butEditSelectedKeybind";
			this.butEditSelectedKeybind.Size = new System.Drawing.Size(23, 22);
			this.butEditSelectedKeybind.Text = "Edit [keybind]";
			this.butEditSelectedKeybind.Visible = false;
			this.butEditSelectedKeybind.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// butDeleteSelectedKeybind
			// 
			this.butDeleteSelectedKeybind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.butDeleteSelectedKeybind.Image = global::MidiControl.Properties.Resources.minus;
			this.butDeleteSelectedKeybind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.butDeleteSelectedKeybind.Name = "butDeleteSelectedKeybind";
			this.butDeleteSelectedKeybind.Size = new System.Drawing.Size(23, 22);
			this.butDeleteSelectedKeybind.Text = "Delete [keybind]";
			this.butDeleteSelectedKeybind.Visible = false;
			this.butDeleteSelectedKeybind.Click += new System.EventHandler(this.DeleteKeybindMenuItem_Click);
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
			this.menuViewAsDropdown.ToolTipText = "Change keybind list display mode";
			// 
			// menuViewAsIcons
			// 
			this.menuViewAsIcons.Checked = true;
			this.menuViewAsIcons.CheckState = System.Windows.Forms.CheckState.Checked;
			this.menuViewAsIcons.Name = "menuViewAsIcons";
			this.menuViewAsIcons.Size = new System.Drawing.Size(109, 22);
			this.menuViewAsIcons.Tag = "icons";
			this.menuViewAsIcons.Text = "Icons";
			this.menuViewAsIcons.Click += new System.EventHandler(this.ListViewDisplayModeChanged);
			// 
			// menuViewAsList
			// 
			this.menuViewAsList.Name = "menuViewAsList";
			this.menuViewAsList.Size = new System.Drawing.Size(109, 22);
			this.menuViewAsList.Tag = "list";
			this.menuViewAsList.Text = "List";
			this.menuViewAsList.Click += new System.EventHandler(this.ListViewDisplayModeChanged);
			// 
			// menuViewAsDetails
			// 
			this.menuViewAsDetails.Name = "menuViewAsDetails";
			this.menuViewAsDetails.Size = new System.Drawing.Size(109, 22);
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
			this.trayIcon.BalloonTipClicked += new System.EventHandler(this.trayIcon_BalloonTipClicked);
			this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
			// 
			// trayMenuStrip
			// 
			this.trayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuShowMainWindow,
            this.toolStripMenuItem4,
            this.SwitchProfileTrayMenuItem,
            this.trayMenuExit});
			this.trayMenuStrip.Name = "trayMenuStrip";
			this.trayMenuStrip.Size = new System.Drawing.Size(183, 76);
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
			// SwitchProfileTrayMenuItem
			// 
			this.SwitchProfileTrayMenuItem.Name = "SwitchProfileTrayMenuItem";
			this.SwitchProfileTrayMenuItem.Size = new System.Drawing.Size(182, 22);
			this.SwitchProfileTrayMenuItem.Text = "Switch profile";
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
			this.statusBar.ShowItemToolTips = true;
			this.statusBar.Size = new System.Drawing.Size(534, 22);
			this.statusBar.TabIndex = 3;
			// 
			// obsButton
			// 
			this.obsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.obsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.obsButton.Image = global::MidiControl.Properties.Resources.obsRed;
			this.obsButton.Name = "obsButton";
			this.obsButton.Size = new System.Drawing.Size(23, 20);
			this.obsButton.Click += new System.EventHandler(this.OBSStatusButtonClicked);
			// 
			// twitchButton
			// 
			this.twitchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.twitchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.twitchButton.Image = global::MidiControl.Properties.Resources.twitchRed;
			this.twitchButton.Name = "twitchButton";
			this.twitchButton.Size = new System.Drawing.Size(23, 20);
			this.twitchButton.Text = "Connect Twitch";
			this.twitchButton.Click += new System.EventHandler(this.TwitchStatusButtonClicked);
			// 
			// midiButton
			// 
			this.midiButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.midiButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.midiButton.Image = global::MidiControl.Properties.Resources.MIDIRed;
			this.midiButton.Name = "midiButton";
			this.midiButton.Size = new System.Drawing.Size(23, 20);
			this.midiButton.Text = "Rescan MIDI devices";
			this.midiButton.Click += new System.EventHandler(this.MidiStatusButtonClicked);
			// 
			// midiStatus
			// 
			this.midiStatus.ForeColor = System.Drawing.Color.Red;
			this.midiStatus.Name = "midiStatus";
			this.midiStatus.Size = new System.Drawing.Size(0, 17);
			// 
			// itemContextMenu
			// 
			this.itemContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.DuplicateKeybindMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
			this.itemContextMenu.Name = "itemContextMenu";
			this.itemContextMenu.Size = new System.Drawing.Size(141, 76);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editToolStripMenuItem.Image = global::MidiControl.Properties.Resources.edit;
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.editToolStripMenuItem.Text = "Edit...";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// DuplicateKeybindMenuItem
			// 
			this.DuplicateKeybindMenuItem.Enabled = false;
			this.DuplicateKeybindMenuItem.Name = "DuplicateKeybindMenuItem";
			this.DuplicateKeybindMenuItem.Size = new System.Drawing.Size(140, 22);
			this.DuplicateKeybindMenuItem.Text = "Duplicate";
			this.DuplicateKeybindMenuItem.Visible = false;
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(137, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::MidiControl.Properties.Resources.minus;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.deleteToolStripMenuItem.Text = "Delete...";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteKeybindMenuItem_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.listKeybinds);
			this.panel1.Controls.Add(this.toolStrip1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(534, 445);
			this.panel1.TabIndex = 5;
			// 
			// listKeybinds
			// 
			this.listKeybinds.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colKeybind,
            this.colOverview});
			this.listKeybinds.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listKeybinds.FullRowSelect = true;
			this.listKeybinds.HideSelection = false;
			this.listKeybinds.Location = new System.Drawing.Point(0, 25);
			this.listKeybinds.Name = "listKeybinds";
			this.listKeybinds.ShowItemToolTips = true;
			this.listKeybinds.Size = new System.Drawing.Size(534, 420);
			this.listKeybinds.TabIndex = 5;
			this.listKeybinds.UseCompatibleStateImageBehavior = false;
			this.listKeybinds.View = System.Windows.Forms.View.Tile;
			this.listKeybinds.SelectedIndexChanged += new System.EventHandler(this.listKeybinds_SelectedIndexChanged);
			this.listKeybinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listKeybinds_KeyDown);
			this.listKeybinds.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listKeybinds_MouseClick);
			this.listKeybinds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listKeybinds_MouseDoubleClick);
			// 
			// colKeybind
			// 
			this.colKeybind.Text = "Keybind Name";
			this.colKeybind.Width = 156;
			// 
			// colOverview
			// 
			this.colOverview.Text = "Overview";
			this.colOverview.Width = 355;
			// 
			// MIDIControlGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(534, 467);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MIDIControlGUI";
			this.Text = "MIDIControl - [ProfileName]";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MIDIControlGUI_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MIDIControlGUI_FormClosed);
			this.Load += new System.EventHandler(this.MIDIControlGUI2_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.trayMenuStrip.ResumeLayout(false);
			this.statusBar.ResumeLayout(false);
			this.statusBar.PerformLayout();
			this.itemContextMenu.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem MidiControlOptionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem InterfaceOptionsMenuItem;
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
		private System.Windows.Forms.ToolStripMenuItem duplicateCurrentProfileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripButton btnDeleteCurrentProfile;
		private System.Windows.Forms.ToolStripButton btnStopAllSounds;
		private System.Windows.Forms.ToolStripMenuItem trayMenuShowMainWindow;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
		private System.Windows.Forms.ContextMenuStrip itemContextMenu;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DuplicateKeybindMenuItem;
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
		private System.Windows.Forms.ToolStripMenuItem saveCurrentProfileAsDefaultToolStripMenuItem;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView listKeybinds;
		private System.Windows.Forms.ColumnHeader colKeybind;
		private System.Windows.Forms.ColumnHeader colOverview;
		private System.Windows.Forms.ToolStripMenuItem gitHubProjectPageToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem SwitchProfileTrayMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuNIControllerEditor;
		private System.Windows.Forms.ToolStripSeparator sepSelectedKeybind;
		private System.Windows.Forms.ToolStripButton butEditSelectedKeybind;
		private System.Windows.Forms.ToolStripButton butDeleteSelectedKeybind;
	}
}