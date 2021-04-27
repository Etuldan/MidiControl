using System;
using System.Windows.Forms;

namespace MidiControl
{
    partial class MIDIControlGUI
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            this.mainpanel = new System.Windows.Forms.Panel();
            this.container = new System.Windows.Forms.TableLayoutPanel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.ComboBoxProfile = new System.Windows.Forms.ComboBox();
            this.BtnStopSounds = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.obsButton = new System.Windows.Forms.ToolStripButton();
            this.obsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.twitchButton = new System.Windows.Forms.ToolStripButton();
            this.twitchStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainpanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.AutoScroll = true;
            this.mainpanel.AutoSize = true;
            this.mainpanel.Controls.Add(this.container);
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(0, 0);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(384, 196);
            this.mainpanel.TabIndex = 0;
            // 
            // container
            // 
            this.container.AutoSize = true;
            this.container.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.container.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 484F));
            this.container.Dock = System.Windows.Forms.DockStyle.Top;
            this.container.Location = new System.Drawing.Point(0, 0);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(384, 0);
            this.container.TabIndex = 0;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.BtnRemove);
            this.BottomPanel.Controls.Add(this.ComboBoxProfile);
            this.BottomPanel.Controls.Add(this.BtnStopSounds);
            this.BottomPanel.Controls.Add(this.BtnOptions);
            this.BottomPanel.Controls.Add(this.statusBar);
            this.BottomPanel.Controls.Add(this.BtnAdd);
            this.BottomPanel.Controls.Add(this.BtnSave);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 196);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(384, 55);
            this.BottomPanel.TabIndex = 2;
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackgroundImage = global::MidiControl.Properties.Resources.rubbish;
            this.BtnRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnRemove.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnRemove.FlatAppearance.BorderSize = 0;
            this.BtnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnRemove.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemove.Location = new System.Drawing.Point(335, 9);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(20, 20);
            this.BtnRemove.TabIndex = 4;
            this.BtnRemove.UseVisualStyleBackColor = true;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // ComboBoxProfile
            // 
            this.ComboBoxProfile.FormattingEnabled = true;
            this.ComboBoxProfile.Location = new System.Drawing.Point(55, 9);
            this.ComboBoxProfile.Name = "ComboBoxProfile";
            this.ComboBoxProfile.Size = new System.Drawing.Size(248, 21);
            this.ComboBoxProfile.TabIndex = 2;
            this.ComboBoxProfile.SelectedValueChanged += new System.EventHandler(this.ComboBoxProfile_SelectedValueChanged);
            this.ComboBoxProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxProfile_KeyDown);
            // 
            // BtnStopSounds
            // 
            this.BtnStopSounds.BackgroundImage = global::MidiControl.Properties.Resources.mute;
            this.BtnStopSounds.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStopSounds.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnStopSounds.FlatAppearance.BorderSize = 0;
            this.BtnStopSounds.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnStopSounds.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnStopSounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStopSounds.Location = new System.Drawing.Point(29, 10);
            this.BtnStopSounds.Name = "BtnStopSounds";
            this.BtnStopSounds.Size = new System.Drawing.Size(20, 20);
            this.BtnStopSounds.TabIndex = 1;
            this.BtnStopSounds.UseVisualStyleBackColor = true;
            this.BtnStopSounds.Click += new System.EventHandler(this.BtnStopSounds_Click);
            // 
            // BtnOptions
            // 
            this.BtnOptions.BackgroundImage = global::MidiControl.Properties.Resources.settings;
            this.BtnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnOptions.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnOptions.FlatAppearance.BorderSize = 0;
            this.BtnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOptions.Location = new System.Drawing.Point(361, 10);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(20, 20);
            this.BtnOptions.TabIndex = 5;
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obsButton,
            this.obsStatus,
            this.twitchButton,
            this.twitchStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 33);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(384, 22);
            this.statusBar.TabIndex = 2;
            // 
            // obsButton
            // 
            this.obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obs;
            this.obsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.obsButton.Name = "obsButton";
            this.obsButton.Size = new System.Drawing.Size(23, 20);
            this.obsButton.Click += new System.EventHandler(this.ConnectOBS);
            // 
            // obsStatus
            // 
            this.obsStatus.ForeColor = System.Drawing.Color.Red;
            this.obsStatus.Name = "obsStatus";
            this.obsStatus.Size = new System.Drawing.Size(79, 17);
            this.obsStatus.Text = "Disconnected";
            // 
            // twitchButton
            // 
            this.twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitch;
            this.twitchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.twitchButton.Name = "twitchButton";
            this.twitchButton.Size = new System.Drawing.Size(23, 20);
            this.twitchButton.Click += new System.EventHandler(this.ConnectTwitch);
            // 
            // twitchStatus
            // 
            this.twitchStatus.ForeColor = System.Drawing.Color.Red;
            this.twitchStatus.Name = "twitchStatus";
            this.twitchStatus.Size = new System.Drawing.Size(79, 17);
            this.twitchStatus.Text = "Disconnected";
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackgroundImage = global::MidiControl.Properties.Resources.plus;
            this.BtnAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnAdd.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Location = new System.Drawing.Point(3, 10);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(20, 20);
            this.BtnAdd.TabIndex = 0;
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = global::MidiControl.Properties.Resources.floppy_disk;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.BtnSave.FlatAppearance.BorderSize = 0;
            this.BtnSave.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.BtnSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Location = new System.Drawing.Point(309, 9);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(20, 20);
            this.BtnSave.TabIndex = 3;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "MIDIControl";
            this.notifyIcon.BalloonTipTitle = "MIDIControl";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.notifyIcon.Text = "MIDIControl";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // MIDIControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 251);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.BottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 5000);
            this.MinimumSize = new System.Drawing.Size(400, 290);
            this.Name = "MIDIControlGUI";
            this.ShowInTaskbar = false;
            this.Text = "MIDIControl";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.MIDIControl_Load);
            this.Resize += new System.EventHandler(this.MIDIControlGUI_Resize);
            this.mainpanel.ResumeLayout(false);
            this.mainpanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TableLayoutPanel container;
        private Panel mainpanel;
        private Panel BottomPanel;
        private Button BtnAdd;
        private Button BtnSave;
        private StatusStrip statusBar;
        private ToolStripButton obsButton;
        private ToolStripStatusLabel obsStatus;
        private ToolStripButton twitchButton;
        private ToolStripStatusLabel twitchStatus;
        private Button BtnOptions;
        private Button BtnStopSounds;
        private NotifyIcon notifyIcon;
        private ComboBox ComboBoxProfile;
        private Button BtnRemove;
    }
}

