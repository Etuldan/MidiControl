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
            this.LblOBSIP = new System.Windows.Forms.Label();
            this.LblOBSPassword = new System.Windows.Forms.Label();
            this.TxtBoxOBSIP = new System.Windows.Forms.TextBox();
            this.TxtBoxOBSPassword = new System.Windows.Forms.TextBox();
            this.ChkBoxAutoConnectStart = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBoxOBS = new System.Windows.Forms.GroupBox();
            this.ChkBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.groupBoxMIDI = new System.Windows.Forms.GroupBox();
            this.txtBoxDelay = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCmbBoxMIDI = new CheckComboBoxTest.CheckedComboBox();
            this.groupBoxStopAllSounds = new System.Windows.Forms.GroupBox();
            this.txtBoxStopAllSoundsNote = new System.Windows.Forms.TextBox();
            this.txtBoxStopAllSoundsChannel = new System.Windows.Forms.TextBox();
            this.lblStopAllSoundsNote = new System.Windows.Forms.Label();
            this.lvlStopAllSoundsChannel = new System.Windows.Forms.Label();
            this.lblStopAllSoundsDevice = new System.Windows.Forms.Label();
            this.txtBoxStopAllSoundsDevice = new System.Windows.Forms.TextBox();
            this.groupBoxTwitch = new System.Windows.Forms.GroupBox();
            this.txtBoxTwitchToken = new System.Windows.Forms.TextBox();
            this.BtnRquestTwitchLogin = new System.Windows.Forms.Button();
            this.txtBoxTwitchLogin = new System.Windows.Forms.TextBox();
            this.groupBoxOBS.SuspendLayout();
            this.groupBoxMIDI.SuspendLayout();
            this.groupBoxStopAllSounds.SuspendLayout();
            this.groupBoxTwitch.SuspendLayout();
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
            this.TxtBoxOBSPassword.Size = new System.Drawing.Size(137, 20);
            this.TxtBoxOBSPassword.TabIndex = 3;
            // 
            // ChkBoxAutoConnectStart
            // 
            this.ChkBoxAutoConnectStart.AutoSize = true;
            this.ChkBoxAutoConnectStart.Location = new System.Drawing.Point(9, 67);
            this.ChkBoxAutoConnectStart.Name = "ChkBoxAutoConnectStart";
            this.ChkBoxAutoConnectStart.Size = new System.Drawing.Size(141, 17);
            this.ChkBoxAutoConnectStart.TabIndex = 5;
            this.ChkBoxAutoConnectStart.Text = "Connect to OBS on start";
            this.ChkBoxAutoConnectStart.UseVisualStyleBackColor = true;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(167, 396);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // groupBoxOBS
            // 
            this.groupBoxOBS.Controls.Add(this.ChkBoxAutoReconnect);
            this.groupBoxOBS.Controls.Add(this.LblOBSIP);
            this.groupBoxOBS.Controls.Add(this.TxtBoxOBSIP);
            this.groupBoxOBS.Controls.Add(this.LblOBSPassword);
            this.groupBoxOBS.Controls.Add(this.TxtBoxOBSPassword);
            this.groupBoxOBS.Controls.Add(this.ChkBoxAutoConnectStart);
            this.groupBoxOBS.Location = new System.Drawing.Point(12, 12);
            this.groupBoxOBS.Name = "groupBoxOBS";
            this.groupBoxOBS.Size = new System.Drawing.Size(230, 115);
            this.groupBoxOBS.TabIndex = 9;
            this.groupBoxOBS.TabStop = false;
            this.groupBoxOBS.Text = "OBS";
            // 
            // ChkBoxAutoReconnect
            // 
            this.ChkBoxAutoReconnect.AutoSize = true;
            this.ChkBoxAutoReconnect.Location = new System.Drawing.Point(9, 90);
            this.ChkBoxAutoReconnect.Name = "ChkBoxAutoReconnect";
            this.ChkBoxAutoReconnect.Size = new System.Drawing.Size(134, 17);
            this.ChkBoxAutoReconnect.TabIndex = 6;
            this.ChkBoxAutoReconnect.Text = "Try to Auto-Reconnect";
            this.ChkBoxAutoReconnect.UseVisualStyleBackColor = true;
            // 
            // groupBoxMIDI
            // 
            this.groupBoxMIDI.Controls.Add(this.txtBoxDelay);
            this.groupBoxMIDI.Controls.Add(this.lblDelay);
            this.groupBoxMIDI.Controls.Add(this.label1);
            this.groupBoxMIDI.Controls.Add(this.ChkCmbBoxMIDI);
            this.groupBoxMIDI.Location = new System.Drawing.Point(12, 133);
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
            // groupBoxStopAllSounds
            // 
            this.groupBoxStopAllSounds.Controls.Add(this.txtBoxStopAllSoundsNote);
            this.groupBoxStopAllSounds.Controls.Add(this.txtBoxStopAllSoundsChannel);
            this.groupBoxStopAllSounds.Controls.Add(this.lblStopAllSoundsNote);
            this.groupBoxStopAllSounds.Controls.Add(this.lvlStopAllSoundsChannel);
            this.groupBoxStopAllSounds.Controls.Add(this.lblStopAllSoundsDevice);
            this.groupBoxStopAllSounds.Controls.Add(this.txtBoxStopAllSoundsDevice);
            this.groupBoxStopAllSounds.Location = new System.Drawing.Point(12, 235);
            this.groupBoxStopAllSounds.Name = "groupBoxStopAllSounds";
            this.groupBoxStopAllSounds.Size = new System.Drawing.Size(230, 74);
            this.groupBoxStopAllSounds.TabIndex = 12;
            this.groupBoxStopAllSounds.TabStop = false;
            this.groupBoxStopAllSounds.Text = "Stop All Sounds Keybind";
            // 
            // txtBoxStopAllSoundsNote
            // 
            this.txtBoxStopAllSoundsNote.Location = new System.Drawing.Point(186, 45);
            this.txtBoxStopAllSoundsNote.Name = "txtBoxStopAllSoundsNote";
            this.txtBoxStopAllSoundsNote.Size = new System.Drawing.Size(38, 20);
            this.txtBoxStopAllSoundsNote.TabIndex = 5;
            // 
            // txtBoxStopAllSoundsChannel
            // 
            this.txtBoxStopAllSoundsChannel.Location = new System.Drawing.Point(58, 45);
            this.txtBoxStopAllSoundsChannel.Name = "txtBoxStopAllSoundsChannel";
            this.txtBoxStopAllSoundsChannel.Size = new System.Drawing.Size(38, 20);
            this.txtBoxStopAllSoundsChannel.TabIndex = 4;
            // 
            // lblStopAllSoundsNote
            // 
            this.lblStopAllSoundsNote.AutoSize = true;
            this.lblStopAllSoundsNote.Location = new System.Drawing.Point(150, 48);
            this.lblStopAllSoundsNote.Name = "lblStopAllSoundsNote";
            this.lblStopAllSoundsNote.Size = new System.Drawing.Size(30, 13);
            this.lblStopAllSoundsNote.TabIndex = 3;
            this.lblStopAllSoundsNote.Text = "Note";
            // 
            // lvlStopAllSoundsChannel
            // 
            this.lvlStopAllSoundsChannel.AutoSize = true;
            this.lvlStopAllSoundsChannel.Location = new System.Drawing.Point(6, 48);
            this.lvlStopAllSoundsChannel.Name = "lvlStopAllSoundsChannel";
            this.lvlStopAllSoundsChannel.Size = new System.Drawing.Size(46, 13);
            this.lvlStopAllSoundsChannel.TabIndex = 2;
            this.lvlStopAllSoundsChannel.Text = "Channel";
            // 
            // lblStopAllSoundsDevice
            // 
            this.lblStopAllSoundsDevice.AutoSize = true;
            this.lblStopAllSoundsDevice.Location = new System.Drawing.Point(6, 20);
            this.lblStopAllSoundsDevice.Name = "lblStopAllSoundsDevice";
            this.lblStopAllSoundsDevice.Size = new System.Drawing.Size(67, 13);
            this.lblStopAllSoundsDevice.TabIndex = 1;
            this.lblStopAllSoundsDevice.Text = "MIDI Device";
            // 
            // txtBoxStopAllSoundsDevice
            // 
            this.txtBoxStopAllSoundsDevice.Location = new System.Drawing.Point(80, 17);
            this.txtBoxStopAllSoundsDevice.Name = "txtBoxStopAllSoundsDevice";
            this.txtBoxStopAllSoundsDevice.Size = new System.Drawing.Size(144, 20);
            this.txtBoxStopAllSoundsDevice.TabIndex = 0;
            // 
            // groupBoxTwitch
            // 
            this.groupBoxTwitch.Controls.Add(this.txtBoxTwitchToken);
            this.groupBoxTwitch.Controls.Add(this.BtnRquestTwitchLogin);
            this.groupBoxTwitch.Controls.Add(this.txtBoxTwitchLogin);
            this.groupBoxTwitch.Location = new System.Drawing.Point(12, 315);
            this.groupBoxTwitch.Name = "groupBoxTwitch";
            this.groupBoxTwitch.Size = new System.Drawing.Size(230, 75);
            this.groupBoxTwitch.TabIndex = 13;
            this.groupBoxTwitch.TabStop = false;
            this.groupBoxTwitch.Text = "Twitch Authentication";
            // 
            // txtBoxTwitchToken
            // 
            this.txtBoxTwitchToken.Enabled = false;
            this.txtBoxTwitchToken.Location = new System.Drawing.Point(9, 43);
            this.txtBoxTwitchToken.Name = "txtBoxTwitchToken";
            this.txtBoxTwitchToken.ReadOnly = true;
            this.txtBoxTwitchToken.Size = new System.Drawing.Size(215, 20);
            this.txtBoxTwitchToken.TabIndex = 8;
            // 
            // BtnRquestTwitchLogin
            // 
            this.BtnRquestTwitchLogin.Location = new System.Drawing.Point(9, 15);
            this.BtnRquestTwitchLogin.Name = "BtnRquestTwitchLogin";
            this.BtnRquestTwitchLogin.Size = new System.Drawing.Size(55, 23);
            this.BtnRquestTwitchLogin.TabIndex = 7;
            this.BtnRquestTwitchLogin.Text = "Login";
            this.BtnRquestTwitchLogin.UseVisualStyleBackColor = true;
            this.BtnRquestTwitchLogin.Click += new System.EventHandler(this.BtnRquestTwitchLogin_Click);
            // 
            // txtBoxTwitchLogin
            // 
            this.txtBoxTwitchLogin.Enabled = false;
            this.txtBoxTwitchLogin.Location = new System.Drawing.Point(67, 17);
            this.txtBoxTwitchLogin.Name = "txtBoxTwitchLogin";
            this.txtBoxTwitchLogin.ReadOnly = true;
            this.txtBoxTwitchLogin.Size = new System.Drawing.Size(157, 20);
            this.txtBoxTwitchLogin.TabIndex = 0;
            // 
            // OptionsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 431);
            this.Controls.Add(this.groupBoxTwitch);
            this.Controls.Add(this.groupBoxStopAllSounds);
            this.Controls.Add(this.groupBoxMIDI);
            this.Controls.Add(this.groupBoxOBS);
            this.Controls.Add(this.BtnSave);
            this.MaximumSize = new System.Drawing.Size(270, 470);
            this.MinimumSize = new System.Drawing.Size(270, 470);
            this.Name = "OptionsGUI";
            this.Text = "Options";
            this.TopMost = true;
            this.groupBoxOBS.ResumeLayout(false);
            this.groupBoxOBS.PerformLayout();
            this.groupBoxMIDI.ResumeLayout(false);
            this.groupBoxMIDI.PerformLayout();
            this.groupBoxStopAllSounds.ResumeLayout(false);
            this.groupBoxStopAllSounds.PerformLayout();
            this.groupBoxTwitch.ResumeLayout(false);
            this.groupBoxTwitch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblOBSIP;
        private System.Windows.Forms.Label LblOBSPassword;
        private System.Windows.Forms.TextBox TxtBoxOBSIP;
        private System.Windows.Forms.TextBox TxtBoxOBSPassword;
        private System.Windows.Forms.CheckBox ChkBoxAutoConnectStart;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.GroupBox groupBoxMIDI;
        private System.Windows.Forms.GroupBox groupBoxOBS;
        private System.Windows.Forms.Label label1;
        private CheckComboBoxTest.CheckedComboBox ChkCmbBoxMIDI;
        private System.Windows.Forms.CheckBox ChkBoxAutoReconnect;
        private System.Windows.Forms.GroupBox groupBoxStopAllSounds;
        private System.Windows.Forms.TextBox txtBoxStopAllSoundsNote;
        private System.Windows.Forms.TextBox txtBoxStopAllSoundsChannel;
        private System.Windows.Forms.Label lblStopAllSoundsNote;
        private System.Windows.Forms.Label lvlStopAllSoundsChannel;
        private System.Windows.Forms.Label lblStopAllSoundsDevice;
        private System.Windows.Forms.TextBox txtBoxStopAllSoundsDevice;
        private System.Windows.Forms.TextBox txtBoxDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.GroupBox groupBoxTwitch;
        private System.Windows.Forms.TextBox txtBoxTwitchLogin;
        private System.Windows.Forms.Button BtnRquestTwitchLogin;
        private System.Windows.Forms.TextBox txtBoxTwitchToken;
    }
}