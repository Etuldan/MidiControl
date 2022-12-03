namespace MidiControl
{
    partial class OptionsGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Interface");
			System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("MidiControl");
			this.LblOBSIP = new System.Windows.Forms.Label();
			this.LblOBSPassword = new System.Windows.Forms.Label();
			this.TxtBoxOBSIP = new System.Windows.Forms.TextBox();
			this.TxtBoxOBSPassword = new System.Windows.Forms.TextBox();
			this.BtnSave = new System.Windows.Forms.Button();
			this.groupBoxOBS = new System.Windows.Forms.GroupBox();
			this.groupBoxMIDI = new System.Windows.Forms.GroupBox();
			this.txtBoxDelay = new System.Windows.Forms.TextBox();
			this.lblDelay = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.ChkCmbBoxMIDI = new CheckComboBoxTest.CheckedComboBox();
			this.groupBoxTwitch = new System.Windows.Forms.GroupBox();
			this.BtnRequestTwitchLogout = new System.Windows.Forms.Button();
			this.BtnRequestTwitchLogin = new System.Windows.Forms.Button();
			this.txtBoxTwitchLogin = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chkConfirmDeleteKeybind = new System.Windows.Forms.CheckBox();
			this.chkConfirmDeleteProfile = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cboTheme = new System.Windows.Forms.ComboBox();
			this.cboToolbarPosition = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkLoadLastProfileOnStart = new System.Windows.Forms.CheckBox();
			this.chkStartToTray = new System.Windows.Forms.CheckBox();
			this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
			this.pnlGeneral = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.pnlInterface = new System.Windows.Forms.Panel();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBoxOBS.SuspendLayout();
			this.groupBoxMIDI.SuspendLayout();
			this.groupBoxTwitch.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.pnlGeneral.SuspendLayout();
			this.pnlInterface.SuspendLayout();
			this.SuspendLayout();
			// 
			// LblOBSIP
			// 
			this.LblOBSIP.AutoSize = true;
			this.LblOBSIP.Location = new System.Drawing.Point(6, 16);
			this.LblOBSIP.Name = "LblOBSIP";
			this.LblOBSIP.Size = new System.Drawing.Size(75, 13);
			this.LblOBSIP.TabIndex = 0;
			this.LblOBSIP.Text = "Websocket IP";
			// 
			// LblOBSPassword
			// 
			this.LblOBSPassword.AutoSize = true;
			this.LblOBSPassword.Location = new System.Drawing.Point(6, 42);
			this.LblOBSPassword.Name = "LblOBSPassword";
			this.LblOBSPassword.Size = new System.Drawing.Size(53, 13);
			this.LblOBSPassword.TabIndex = 1;
			this.LblOBSPassword.Text = "Password";
			// 
			// TxtBoxOBSIP
			// 
			this.TxtBoxOBSIP.Location = new System.Drawing.Point(87, 13);
			this.TxtBoxOBSIP.Name = "TxtBoxOBSIP";
			this.TxtBoxOBSIP.Size = new System.Drawing.Size(137, 20);
			this.TxtBoxOBSIP.TabIndex = 2;
			// 
			// TxtBoxOBSPassword
			// 
			this.TxtBoxOBSPassword.Location = new System.Drawing.Point(87, 39);
			this.TxtBoxOBSPassword.Name = "TxtBoxOBSPassword";
			this.TxtBoxOBSPassword.PasswordChar = '●';
			this.TxtBoxOBSPassword.Size = new System.Drawing.Size(137, 20);
			this.TxtBoxOBSPassword.TabIndex = 3;
			// 
			// BtnSave
			// 
			this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSave.Location = new System.Drawing.Point(244, 266);
			this.BtnSave.Name = "BtnSave";
			this.BtnSave.Size = new System.Drawing.Size(75, 23);
			this.BtnSave.TabIndex = 6;
			this.BtnSave.Text = "Save";
			this.BtnSave.UseVisualStyleBackColor = true;
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			// 
			// groupBoxOBS
			// 
			this.groupBoxOBS.Controls.Add(this.LblOBSIP);
			this.groupBoxOBS.Controls.Add(this.TxtBoxOBSIP);
			this.groupBoxOBS.Controls.Add(this.LblOBSPassword);
			this.groupBoxOBS.Controls.Add(this.TxtBoxOBSPassword);
			this.groupBoxOBS.Location = new System.Drawing.Point(12, 3);
			this.groupBoxOBS.Name = "groupBoxOBS";
			this.groupBoxOBS.Size = new System.Drawing.Size(230, 66);
			this.groupBoxOBS.TabIndex = 9;
			this.groupBoxOBS.TabStop = false;
			this.groupBoxOBS.Text = "OBS";
			// 
			// groupBoxMIDI
			// 
			this.groupBoxMIDI.Controls.Add(this.txtBoxDelay);
			this.groupBoxMIDI.Controls.Add(this.lblDelay);
			this.groupBoxMIDI.Controls.Add(this.label1);
			this.groupBoxMIDI.Controls.Add(this.ChkCmbBoxMIDI);
			this.groupBoxMIDI.Location = new System.Drawing.Point(12, 75);
			this.groupBoxMIDI.Name = "groupBoxMIDI";
			this.groupBoxMIDI.Size = new System.Drawing.Size(230, 96);
			this.groupBoxMIDI.TabIndex = 10;
			this.groupBoxMIDI.TabStop = false;
			this.groupBoxMIDI.Text = "MIDI (Restart software after any change)";
			// 
			// txtBoxDelay
			// 
			this.txtBoxDelay.Location = new System.Drawing.Point(83, 23);
			this.txtBoxDelay.Name = "txtBoxDelay";
			this.txtBoxDelay.Size = new System.Drawing.Size(63, 20);
			this.txtBoxDelay.TabIndex = 7;
			// 
			// lblDelay
			// 
			this.lblDelay.AutoSize = true;
			this.lblDelay.Location = new System.Drawing.Point(6, 26);
			this.lblDelay.Name = "lblDelay";
			this.lblDelay.Size = new System.Drawing.Size(67, 13);
			this.lblDelay.TabIndex = 6;
			this.lblDelay.Text = "Delay (in ms)";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "MIDI Interface to ignore";
			// 
			// ChkCmbBoxMIDI
			// 
			this.ChkCmbBoxMIDI.CheckOnClick = true;
			this.ChkCmbBoxMIDI.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.ChkCmbBoxMIDI.DropDownHeight = 1;
			this.ChkCmbBoxMIDI.FormattingEnabled = true;
			this.ChkCmbBoxMIDI.IntegralHeight = false;
			this.ChkCmbBoxMIDI.Location = new System.Drawing.Point(6, 68);
			this.ChkCmbBoxMIDI.Name = "ChkCmbBoxMIDI";
			this.ChkCmbBoxMIDI.Size = new System.Drawing.Size(218, 21);
			this.ChkCmbBoxMIDI.TabIndex = 9;
			this.ChkCmbBoxMIDI.ValueSeparator = ", ";
			// 
			// groupBoxTwitch
			// 
			this.groupBoxTwitch.Controls.Add(this.BtnRequestTwitchLogout);
			this.groupBoxTwitch.Controls.Add(this.BtnRequestTwitchLogin);
			this.groupBoxTwitch.Controls.Add(this.txtBoxTwitchLogin);
			this.groupBoxTwitch.Location = new System.Drawing.Point(12, 177);
			this.groupBoxTwitch.Name = "groupBoxTwitch";
			this.groupBoxTwitch.Size = new System.Drawing.Size(230, 46);
			this.groupBoxTwitch.TabIndex = 13;
			this.groupBoxTwitch.TabStop = false;
			this.groupBoxTwitch.Text = "Twitch Authentication";
			// 
			// BtnRequestTwitchLogout
			// 
			this.BtnRequestTwitchLogout.Location = new System.Drawing.Point(58, 15);
			this.BtnRequestTwitchLogout.Name = "BtnRequestTwitchLogout";
			this.BtnRequestTwitchLogout.Size = new System.Drawing.Size(51, 23);
			this.BtnRequestTwitchLogout.TabIndex = 9;
			this.BtnRequestTwitchLogout.Text = "Logout";
			this.BtnRequestTwitchLogout.UseVisualStyleBackColor = true;
			this.BtnRequestTwitchLogout.Click += new System.EventHandler(this.BtnRequestTwitchLogout_Click);
			// 
			// BtnRequestTwitchLogin
			// 
			this.BtnRequestTwitchLogin.Location = new System.Drawing.Point(9, 15);
			this.BtnRequestTwitchLogin.Name = "BtnRequestTwitchLogin";
			this.BtnRequestTwitchLogin.Size = new System.Drawing.Size(43, 23);
			this.BtnRequestTwitchLogin.TabIndex = 7;
			this.BtnRequestTwitchLogin.Text = "Login";
			this.BtnRequestTwitchLogin.UseVisualStyleBackColor = true;
			this.BtnRequestTwitchLogin.Click += new System.EventHandler(this.BtnRequestTwitchLogin_Click);
			// 
			// txtBoxTwitchLogin
			// 
			this.txtBoxTwitchLogin.Enabled = false;
			this.txtBoxTwitchLogin.Location = new System.Drawing.Point(115, 17);
			this.txtBoxTwitchLogin.Name = "txtBoxTwitchLogin";
			this.txtBoxTwitchLogin.ReadOnly = true;
			this.txtBoxTwitchLogin.Size = new System.Drawing.Size(109, 20);
			this.txtBoxTwitchLogin.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chkConfirmDeleteKeybind);
			this.groupBox2.Controls.Add(this.chkConfirmDeleteProfile);
			this.groupBox2.Location = new System.Drawing.Point(12, 170);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(230, 70);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Confirmations";
			// 
			// chkConfirmDeleteKeybind
			// 
			this.chkConfirmDeleteKeybind.AutoSize = true;
			this.chkConfirmDeleteKeybind.Location = new System.Drawing.Point(6, 19);
			this.chkConfirmDeleteKeybind.Name = "chkConfirmDeleteKeybind";
			this.chkConfirmDeleteKeybind.Size = new System.Drawing.Size(179, 17);
			this.chkConfirmDeleteKeybind.TabIndex = 2;
			this.chkConfirmDeleteKeybind.Text = "Confirm before deleting keybinds";
			this.chkConfirmDeleteKeybind.UseVisualStyleBackColor = true;
			// 
			// chkConfirmDeleteProfile
			// 
			this.chkConfirmDeleteProfile.AutoSize = true;
			this.chkConfirmDeleteProfile.Location = new System.Drawing.Point(6, 42);
			this.chkConfirmDeleteProfile.Name = "chkConfirmDeleteProfile";
			this.chkConfirmDeleteProfile.Size = new System.Drawing.Size(170, 17);
			this.chkConfirmDeleteProfile.TabIndex = 3;
			this.chkConfirmDeleteProfile.Text = "Confirm before deleting profiles";
			this.chkConfirmDeleteProfile.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cboTheme);
			this.groupBox1.Controls.Add(this.cboToolbarPosition);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.chkLoadLastProfileOnStart);
			this.groupBox1.Controls.Add(this.chkStartToTray);
			this.groupBox1.Controls.Add(this.chkAlwaysOnTop);
			this.groupBox1.Location = new System.Drawing.Point(12, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(230, 145);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "General";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(3, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Theme:";
			// 
			// cboTheme
			// 
			this.cboTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTheme.FormattingEnabled = true;
			this.cboTheme.Items.AddRange(new object[] {
            "Default (light)",
            "Dark",
            "Office 2007 Blue"});
			this.cboTheme.Location = new System.Drawing.Point(94, 91);
			this.cboTheme.Name = "cboTheme";
			this.cboTheme.Size = new System.Drawing.Size(130, 21);
			this.cboTheme.TabIndex = 5;
			// 
			// cboToolbarPosition
			// 
			this.cboToolbarPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboToolbarPosition.FormattingEnabled = true;
			this.cboToolbarPosition.Items.AddRange(new object[] {
            "Top",
            "Bottom"});
			this.cboToolbarPosition.Location = new System.Drawing.Point(94, 118);
			this.cboToolbarPosition.Name = "cboToolbarPosition";
			this.cboToolbarPosition.Size = new System.Drawing.Size(130, 21);
			this.cboToolbarPosition.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(85, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Toolbar position:";
			// 
			// chkLoadLastProfileOnStart
			// 
			this.chkLoadLastProfileOnStart.AutoSize = true;
			this.chkLoadLastProfileOnStart.Location = new System.Drawing.Point(6, 65);
			this.chkLoadLastProfileOnStart.Name = "chkLoadLastProfileOnStart";
			this.chkLoadLastProfileOnStart.Size = new System.Drawing.Size(176, 17);
			this.chkLoadLastProfileOnStart.TabIndex = 2;
			this.chkLoadLastProfileOnStart.Text = "Load last-used profile on startup";
			this.chkLoadLastProfileOnStart.UseVisualStyleBackColor = true;
			// 
			// chkStartToTray
			// 
			this.chkStartToTray.AutoSize = true;
			this.chkStartToTray.Location = new System.Drawing.Point(6, 19);
			this.chkStartToTray.Name = "chkStartToTray";
			this.chkStartToTray.Size = new System.Drawing.Size(115, 17);
			this.chkStartToTray.TabIndex = 0;
			this.chkStartToTray.Text = "Start to system tray";
			this.chkStartToTray.UseVisualStyleBackColor = true;
			// 
			// chkAlwaysOnTop
			// 
			this.chkAlwaysOnTop.AutoSize = true;
			this.chkAlwaysOnTop.Location = new System.Drawing.Point(6, 42);
			this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
			this.chkAlwaysOnTop.Size = new System.Drawing.Size(148, 17);
			this.chkAlwaysOnTop.TabIndex = 1;
			this.chkAlwaysOnTop.Text = "Keep main window on top";
			this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
			// 
			// pnlGeneral
			// 
			this.pnlGeneral.AutoScroll = true;
			this.pnlGeneral.BackColor = System.Drawing.SystemColors.Control;
			this.pnlGeneral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlGeneral.Controls.Add(this.groupBoxOBS);
			this.pnlGeneral.Controls.Add(this.groupBoxTwitch);
			this.pnlGeneral.Controls.Add(this.groupBoxMIDI);
			this.pnlGeneral.Location = new System.Drawing.Point(148, 12);
			this.pnlGeneral.Name = "pnlGeneral";
			this.pnlGeneral.Size = new System.Drawing.Size(251, 246);
			this.pnlGeneral.TabIndex = 15;
			this.pnlGeneral.Tag = "general";
			// 
			// treeView1
			// 
			this.treeView1.HotTracking = true;
			this.treeView1.Location = new System.Drawing.Point(12, 12);
			this.treeView1.Name = "treeView1";
			treeNode3.Name = "interface";
			treeNode3.Text = "Interface";
			treeNode3.ToolTipText = "Program appearance and behavior";
			treeNode4.Name = "general";
			treeNode4.Text = "MidiControl";
			treeNode4.ToolTipText = "General program settings";
			this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
			this.treeView1.ShowNodeToolTips = true;
			this.treeView1.ShowRootLines = false;
			this.treeView1.Size = new System.Drawing.Size(130, 246);
			this.treeView1.TabIndex = 16;
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.OptionsCategoryChanged);
			// 
			// pnlInterface
			// 
			this.pnlInterface.AutoScroll = true;
			this.pnlInterface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlInterface.Controls.Add(this.groupBox2);
			this.pnlInterface.Controls.Add(this.groupBox1);
			this.pnlInterface.Location = new System.Drawing.Point(422, 12);
			this.pnlInterface.Name = "pnlInterface";
			this.pnlInterface.Size = new System.Drawing.Size(251, 246);
			this.pnlInterface.TabIndex = 17;
			this.pnlInterface.Tag = "interface";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(325, 266);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 18;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.CancelPressed);
			// 
			// OptionsGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 301);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.pnlInterface);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.pnlGeneral);
			this.Controls.Add(this.BtnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(270, 310);
			this.Name = "OptionsGUI";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.groupBoxOBS.ResumeLayout(false);
			this.groupBoxOBS.PerformLayout();
			this.groupBoxMIDI.ResumeLayout(false);
			this.groupBoxMIDI.PerformLayout();
			this.groupBoxTwitch.ResumeLayout(false);
			this.groupBoxTwitch.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.pnlGeneral.ResumeLayout(false);
			this.pnlInterface.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblOBSIP;
        private System.Windows.Forms.Label LblOBSPassword;
        private System.Windows.Forms.TextBox TxtBoxOBSIP;
        private System.Windows.Forms.TextBox TxtBoxOBSPassword;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBoxMIDI;
        private System.Windows.Forms.GroupBox groupBoxOBS;
        private System.Windows.Forms.Label label1;
        private CheckComboBoxTest.CheckedComboBox ChkCmbBoxMIDI;
        private System.Windows.Forms.TextBox txtBoxDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.GroupBox groupBoxTwitch;
        private System.Windows.Forms.TextBox txtBoxTwitchLogin;
        private System.Windows.Forms.Button BtnRequestTwitchLogin;
        private System.Windows.Forms.Button BtnRequestTwitchLogout;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox chkConfirmDeleteKeybind;
		private System.Windows.Forms.CheckBox chkConfirmDeleteProfile;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkStartToTray;
		private System.Windows.Forms.CheckBox chkAlwaysOnTop;
		private System.Windows.Forms.CheckBox chkLoadLastProfileOnStart;
		private System.Windows.Forms.ComboBox cboToolbarPosition;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cboTheme;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel pnlInterface;
		private System.Windows.Forms.Button button1;
	}
}