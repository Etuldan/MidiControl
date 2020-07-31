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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsGUI));
            this.LblOBSIP = new System.Windows.Forms.Label();
            this.LblOBSPassword = new System.Windows.Forms.Label();
            this.TxtBoxOBSIP = new System.Windows.Forms.TextBox();
            this.TxtBoxOBSPassword = new System.Windows.Forms.TextBox();
            this.ChkBoxAutoConnectStart = new System.Windows.Forms.CheckBox();
            this.BtnSave = new System.Windows.Forms.Button();
            this.ChkBoxMIDIForward = new System.Windows.Forms.CheckBox();
            this.CmbBoxMIDIForward = new System.Windows.Forms.ComboBox();
            this.groupBoxOBS = new System.Windows.Forms.GroupBox();
            this.ChkBoxAutoReconnect = new System.Windows.Forms.CheckBox();
            this.groupBoxMIDI = new System.Windows.Forms.GroupBox();
            this.ChkBoxMIDIFeedback = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCmbBoxMIDI = new CheckComboBoxTest.CheckedComboBox();
            this.groupBoxMuteAll = new System.Windows.Forms.GroupBox();
            this.txtBoxMuteAllNote = new System.Windows.Forms.TextBox();
            this.txtBoxMuteAllChannel = new System.Windows.Forms.TextBox();
            this.lblMuteAllNote = new System.Windows.Forms.Label();
            this.lvlMuteAllChannel = new System.Windows.Forms.Label();
            this.lblMuteAllDevice = new System.Windows.Forms.Label();
            this.txtBoxMuteAllDevice = new System.Windows.Forms.TextBox();
            this.groupBoxOBS.SuspendLayout();
            this.groupBoxMIDI.SuspendLayout();
            this.groupBoxMuteAll.SuspendLayout();
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
            this.BtnSave.Location = new System.Drawing.Point(167, 355);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 6;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // ChkBoxMIDIForward
            // 
            this.ChkBoxMIDIForward.AutoSize = true;
            this.ChkBoxMIDIForward.Location = new System.Drawing.Point(6, 63);
            this.ChkBoxMIDIForward.Name = "ChkBoxMIDIForward";
            this.ChkBoxMIDIForward.Size = new System.Drawing.Size(140, 17);
            this.ChkBoxMIDIForward.TabIndex = 7;
            this.ChkBoxMIDIForward.Text = "Enable MIDI Forwarding";
            this.ChkBoxMIDIForward.UseVisualStyleBackColor = true;
            // 
            // CmbBoxMIDIForward
            // 
            this.CmbBoxMIDIForward.FormattingEnabled = true;
            this.CmbBoxMIDIForward.Location = new System.Drawing.Point(6, 86);
            this.CmbBoxMIDIForward.Name = "CmbBoxMIDIForward";
            this.CmbBoxMIDIForward.Size = new System.Drawing.Size(218, 21);
            this.CmbBoxMIDIForward.TabIndex = 8;
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
            this.groupBoxMIDI.Controls.Add(this.ChkBoxMIDIFeedback);
            this.groupBoxMIDI.Controls.Add(this.label1);
            this.groupBoxMIDI.Controls.Add(this.ChkCmbBoxMIDI);
            this.groupBoxMIDI.Controls.Add(this.ChkBoxMIDIForward);
            this.groupBoxMIDI.Controls.Add(this.CmbBoxMIDIForward);
            this.groupBoxMIDI.Location = new System.Drawing.Point(12, 133);
            this.groupBoxMIDI.Name = "groupBoxMIDI";
            this.groupBoxMIDI.Size = new System.Drawing.Size(230, 136);
            this.groupBoxMIDI.TabIndex = 10;
            this.groupBoxMIDI.TabStop = false;
            this.groupBoxMIDI.Text = "MIDI (Restart software after any change)";
            // 
            // ChkBoxMIDIFeedback
            // 
            this.ChkBoxMIDIFeedback.AutoSize = true;
            this.ChkBoxMIDIFeedback.Location = new System.Drawing.Point(6, 114);
            this.ChkBoxMIDIFeedback.Name = "ChkBoxMIDIFeedback";
            this.ChkBoxMIDIFeedback.Size = new System.Drawing.Size(136, 17);
            this.ChkBoxMIDIFeedback.TabIndex = 11;
            this.ChkBoxMIDIFeedback.Text = "Enable MIDI Feedback";
            this.ChkBoxMIDIFeedback.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 20);
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
            this.ChkCmbBoxMIDI.Location = new System.Drawing.Point(6, 36);
            this.ChkCmbBoxMIDI.Name = "ChkCmbBoxMIDI";
            this.ChkCmbBoxMIDI.Size = new System.Drawing.Size(218, 21);
            this.ChkCmbBoxMIDI.TabIndex = 9;
            this.ChkCmbBoxMIDI.ValueSeparator = ", ";
            // 
            // groupBoxMuteAll
            // 
            this.groupBoxMuteAll.Controls.Add(this.txtBoxMuteAllNote);
            this.groupBoxMuteAll.Controls.Add(this.txtBoxMuteAllChannel);
            this.groupBoxMuteAll.Controls.Add(this.lblMuteAllNote);
            this.groupBoxMuteAll.Controls.Add(this.lvlMuteAllChannel);
            this.groupBoxMuteAll.Controls.Add(this.lblMuteAllDevice);
            this.groupBoxMuteAll.Controls.Add(this.txtBoxMuteAllDevice);
            this.groupBoxMuteAll.Location = new System.Drawing.Point(12, 275);
            this.groupBoxMuteAll.Name = "groupBoxMuteAll";
            this.groupBoxMuteAll.Size = new System.Drawing.Size(230, 74);
            this.groupBoxMuteAll.TabIndex = 12;
            this.groupBoxMuteAll.TabStop = false;
            this.groupBoxMuteAll.Text = "Mute All Sounds Keybind";
            // 
            // txtBoxMuteAllNote
            // 
            this.txtBoxMuteAllNote.Location = new System.Drawing.Point(186, 45);
            this.txtBoxMuteAllNote.Name = "txtBoxMuteAllNote";
            this.txtBoxMuteAllNote.Size = new System.Drawing.Size(38, 20);
            this.txtBoxMuteAllNote.TabIndex = 5;
            // 
            // txtBoxMuteAllChannel
            // 
            this.txtBoxMuteAllChannel.Location = new System.Drawing.Point(58, 45);
            this.txtBoxMuteAllChannel.Name = "txtBoxMuteAllChannel";
            this.txtBoxMuteAllChannel.Size = new System.Drawing.Size(38, 20);
            this.txtBoxMuteAllChannel.TabIndex = 4;
            // 
            // lblMuteAllNote
            // 
            this.lblMuteAllNote.AutoSize = true;
            this.lblMuteAllNote.Location = new System.Drawing.Point(150, 48);
            this.lblMuteAllNote.Name = "lblMuteAllNote";
            this.lblMuteAllNote.Size = new System.Drawing.Size(30, 13);
            this.lblMuteAllNote.TabIndex = 3;
            this.lblMuteAllNote.Text = "Note";
            // 
            // lvlMuteAllChannel
            // 
            this.lvlMuteAllChannel.AutoSize = true;
            this.lvlMuteAllChannel.Location = new System.Drawing.Point(6, 48);
            this.lvlMuteAllChannel.Name = "lvlMuteAllChannel";
            this.lvlMuteAllChannel.Size = new System.Drawing.Size(46, 13);
            this.lvlMuteAllChannel.TabIndex = 2;
            this.lvlMuteAllChannel.Text = "Channel";
            // 
            // lblMuteAllDevice
            // 
            this.lblMuteAllDevice.AutoSize = true;
            this.lblMuteAllDevice.Location = new System.Drawing.Point(6, 20);
            this.lblMuteAllDevice.Name = "lblMuteAllDevice";
            this.lblMuteAllDevice.Size = new System.Drawing.Size(67, 13);
            this.lblMuteAllDevice.TabIndex = 1;
            this.lblMuteAllDevice.Text = "MIDI Device";
            // 
            // txtBoxMuteAllDevice
            // 
            this.txtBoxMuteAllDevice.Location = new System.Drawing.Point(80, 17);
            this.txtBoxMuteAllDevice.Name = "txtBoxMuteAllDevice";
            this.txtBoxMuteAllDevice.Size = new System.Drawing.Size(144, 20);
            this.txtBoxMuteAllDevice.TabIndex = 0;
            // 
            // OptionsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 381);
            this.Controls.Add(this.groupBoxMuteAll);
            this.Controls.Add(this.groupBoxMIDI);
            this.Controls.Add(this.groupBoxOBS);
            this.Controls.Add(this.BtnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(270, 420);
            this.MinimumSize = new System.Drawing.Size(270, 420);
            this.Name = "OptionsGUI";
            this.Text = "Options";
            this.TopMost = true;
            this.groupBoxOBS.ResumeLayout(false);
            this.groupBoxOBS.PerformLayout();
            this.groupBoxMIDI.ResumeLayout(false);
            this.groupBoxMIDI.PerformLayout();
            this.groupBoxMuteAll.ResumeLayout(false);
            this.groupBoxMuteAll.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblOBSIP;
        private System.Windows.Forms.Label LblOBSPassword;
        private System.Windows.Forms.TextBox TxtBoxOBSIP;
        private System.Windows.Forms.TextBox TxtBoxOBSPassword;
        private System.Windows.Forms.CheckBox ChkBoxAutoConnectStart;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.CheckBox ChkBoxMIDIForward;
        private System.Windows.Forms.ComboBox CmbBoxMIDIForward;
        private System.Windows.Forms.GroupBox groupBoxMIDI;
        private System.Windows.Forms.GroupBox groupBoxOBS;
        private System.Windows.Forms.Label label1;
        private CheckComboBoxTest.CheckedComboBox ChkCmbBoxMIDI;
        private System.Windows.Forms.CheckBox ChkBoxAutoReconnect;
        private System.Windows.Forms.CheckBox ChkBoxMIDIFeedback;
        private System.Windows.Forms.GroupBox groupBoxMuteAll;
        private System.Windows.Forms.TextBox txtBoxMuteAllNote;
        private System.Windows.Forms.TextBox txtBoxMuteAllChannel;
        private System.Windows.Forms.Label lblMuteAllNote;
        private System.Windows.Forms.Label lvlMuteAllChannel;
        private System.Windows.Forms.Label lblMuteAllDevice;
        private System.Windows.Forms.TextBox txtBoxMuteAllDevice;
    }
}