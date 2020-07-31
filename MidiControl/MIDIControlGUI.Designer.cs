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
            this.BtnStopSounds = new System.Windows.Forms.Button();
            this.BtnOptions = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.obsStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnConnect = new System.Windows.Forms.Button();
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
            this.mainpanel.Size = new System.Drawing.Size(384, 206);
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
            this.BottomPanel.Controls.Add(this.BtnStopSounds);
            this.BottomPanel.Controls.Add(this.BtnOptions);
            this.BottomPanel.Controls.Add(this.statusBar);
            this.BottomPanel.Controls.Add(this.BtnAdd);
            this.BottomPanel.Controls.Add(this.BtnConnect);
            this.BottomPanel.Controls.Add(this.BtnSave);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 206);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(384, 55);
            this.BottomPanel.TabIndex = 2;
            // 
            // BtnStopSounds
            // 
            this.BtnStopSounds.Location = new System.Drawing.Point(172, 6);
            this.BtnStopSounds.Name = "BtnStopSounds";
            this.BtnStopSounds.Size = new System.Drawing.Size(90, 23);
            this.BtnStopSounds.TabIndex = 4;
            this.BtnStopSounds.Text = "Stop All Sounds";
            this.BtnStopSounds.UseVisualStyleBackColor = true;
            this.BtnStopSounds.Click += new System.EventHandler(this.BtnStopSounds_Click);
            // 
            // BtnOptions
            // 
            this.BtnOptions.Location = new System.Drawing.Point(268, 6);
            this.BtnOptions.Name = "BtnOptions";
            this.BtnOptions.Size = new System.Drawing.Size(56, 23);
            this.BtnOptions.TabIndex = 3;
            this.BtnOptions.Text = "Options";
            this.BtnOptions.UseVisualStyleBackColor = true;
            this.BtnOptions.Click += new System.EventHandler(this.BtnOptions_Click);
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obsStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 33);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(384, 22);
            this.statusBar.TabIndex = 2;
            // 
            // obsStatus
            // 
            this.obsStatus.ForeColor = System.Drawing.Color.Red;
            this.obsStatus.Name = "obsStatus";
            this.obsStatus.Size = new System.Drawing.Size(79, 17);
            this.obsStatus.Text = "Disconnected";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(12, 6);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(47, 23);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.Add_Click);
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(65, 6);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 23);
            this.BtnConnect.TabIndex = 1;
            this.BtnConnect.Text = "Connect to OBS";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(330, 6);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(42, 23);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.Save_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "MIDIControl";
            this.notifyIcon.BalloonTipTitle = "MIDIControl";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MIDIControl";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // MIDIControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.BottomPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 5000);
            this.MinimumSize = new System.Drawing.Size(400, 300);
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
        private Button BtnConnect;
        private Button BtnSave;
        private StatusStrip statusBar;
        private ToolStripStatusLabel obsStatus;
        private Button BtnOptions;
        private Button BtnStopSounds;
        private NotifyIcon notifyIcon;
    }
}

