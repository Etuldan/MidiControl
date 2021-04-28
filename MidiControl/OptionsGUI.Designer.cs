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
            this.BtnSave = new System.Windows.Forms.Button();
            this.groupBoxOBS = new System.Windows.Forms.GroupBox();
            this.groupBoxMIDI = new System.Windows.Forms.GroupBox();
            this.txtBoxDelay = new System.Windows.Forms.TextBox();
            this.lblDelay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChkCmbBoxMIDI = new CheckComboBoxTest.CheckedComboBox();
            this.groupBoxTwitch = new System.Windows.Forms.GroupBox();
            this.BtnRequestTwitchLogout = new System.Windows.Forms.Button();
            this.txtBoxTwitchToken = new System.Windows.Forms.TextBox();
            this.BtnRequestTwitchLogin = new System.Windows.Forms.Button();
            this.txtBoxTwitchLogin = new System.Windows.Forms.TextBox();
            this.groupBoxOBS.SuspendLayout();
            this.groupBoxMIDI.SuspendLayout();
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
            this.TxtBoxOBSPassword.PasswordChar = '●';
            this.TxtBoxOBSPassword.Size = new System.Drawing.Size(137, 20);
            this.TxtBoxOBSPassword.TabIndex = 3;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(167, 267);
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
            this.groupBoxOBS.Location = new System.Drawing.Point(12, 12);
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
            this.groupBoxMIDI.Location = new System.Drawing.Point(12, 84);
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
            this.groupBoxTwitch.Controls.Add(this.txtBoxTwitchToken);
            this.groupBoxTwitch.Controls.Add(this.BtnRequestTwitchLogin);
            this.groupBoxTwitch.Controls.Add(this.txtBoxTwitchLogin);
            this.groupBoxTwitch.Location = new System.Drawing.Point(12, 186);
            this.groupBoxTwitch.Name = "groupBoxTwitch";
            this.groupBoxTwitch.Size = new System.Drawing.Size(230, 75);
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
            // txtBoxTwitchToken
            // 
            this.txtBoxTwitchToken.Enabled = false;
            this.txtBoxTwitchToken.Location = new System.Drawing.Point(9, 43);
            this.txtBoxTwitchToken.Name = "txtBoxTwitchToken";
            this.txtBoxTwitchToken.ReadOnly = true;
            this.txtBoxTwitchToken.Size = new System.Drawing.Size(215, 20);
            this.txtBoxTwitchToken.TabIndex = 8;
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
            // OptionsGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 301);
            this.Controls.Add(this.groupBoxTwitch);
            this.Controls.Add(this.groupBoxMIDI);
            this.Controls.Add(this.groupBoxOBS);
            this.Controls.Add(this.BtnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 340);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(270, 340);
            this.Name = "OptionsGUI";
            this.Text = "Options";
            this.TopMost = true;
            this.groupBoxOBS.ResumeLayout(false);
            this.groupBoxOBS.PerformLayout();
            this.groupBoxMIDI.ResumeLayout(false);
            this.groupBoxMIDI.PerformLayout();
            this.groupBoxTwitch.ResumeLayout(false);
            this.groupBoxTwitch.PerformLayout();
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
        private System.Windows.Forms.TextBox txtBoxTwitchToken;
        private System.Windows.Forms.Button BtnRequestTwitchLogout;
    }
}