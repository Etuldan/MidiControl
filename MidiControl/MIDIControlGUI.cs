using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl
{
    public partial class MIDIControlGUI : Form
    {
        public delegate void OBSControlDelegateHandler(bool connect);
        public OBSControlDelegateHandler OBSControlDelegate;
        private readonly OptionsManagment options;
        private readonly Configuration conf;
        private readonly MIDIListener midi;

        private static MIDIControlGUI _instance;

        public MIDIControlGUI()
        {
            _instance = this;
            this.FormClosed += MIDIControlGUI_FormClosing;

            InitializeComponent();
            OBSControlDelegate = new OBSControlDelegateHandler(UpdateOBSStatus);

            options = new OptionsManagment();
            conf = new Configuration();
            midi = new MIDIListener(conf);
            

            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            this.Hide();
        }

        private void MIDIControlGUI_FormClosing(Object sender, FormClosedEventArgs e)
        {
            midi.ReleaseAll();
        }
        public static MIDIControlGUI GetInstance()
        {
            return _instance;
        }

        private void UpdateOBSStatus(bool connect)
        {
            if (connect)
            {
                obsStatus.Text = "Connected";
                this.obsStatus.ForeColor = Color.Green;
                BtnConnect.Text = "Disconnect";
            }
            else
            {
                obsStatus.Text = "Disconnected";
                this.obsStatus.ForeColor = Color.Red;
                BtnConnect.Text = "Connect to OBS";
            }
        }

        public void ReloadEntries()
        {
            container.Controls.Clear();
            container.RowCount = 0;

            foreach (KeyValuePair<string, KeyBindEntry> entry in conf.Config)
            {
                container.RowCount += 1;
                container.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));

                Panel entryUI = new Panel();
                entryUI.SuspendLayout();
                container.Controls.Add(entryUI);

                Label nameUI = new Label
                {
                    AutoSize = true,
                    Location = new Point(3, 9),
                    Name = "LblName",
                    Size = new Size(35, 13),
                    TabIndex = 0,
                    Text = entry.Key
                };

                Label keyUI = new Label
                {
                    AutoSize = true,
                    Location = new Point(172, 9),
                    Name = "LblKey",
                    Size = new Size(35, 13),
                    TabIndex = 2
                };

                ButtonCustom editUI = new ButtonCustom
                {
                    index = entry.Key,
                    Location = new Point(200, 4),
                    Name = "BtnEdit",
                    Size = new Size(75, 23),
                    TabIndex = 3,
                    Text = "Edit",
                    UseVisualStyleBackColor = true
                };
                editUI.Click += new EventHandler(this.EditEntry_Click);

                ButtonCustom deleteUI = new ButtonCustom
                {
                    index = entry.Key,
                    Location = new Point(280, 4),
                    Name = "BtnDelete",
                    Size = new Size(75, 23),
                    TabIndex = 1,
                    Text = "Delete",
                    UseVisualStyleBackColor = true
                };
                deleteUI.Click += new EventHandler(this.DeleteEntry_Click);

                entryUI.Controls.Add(nameUI);
                entryUI.Controls.Add(keyUI);
                entryUI.Controls.Add(editUI);
                entryUI.Controls.Add(deleteUI);
                entryUI.Location = new Point(3, 3);
                entryUI.Size = new Size(470, 34);
                entryUI.Name = "PnlContainer";
                entryUI.TabIndex = 0;

                entryUI.ResumeLayout(false);
                entryUI.PerformLayout();
            }
        }

        private void EditEntry_Click(object sender, EventArgs e)
        {

            string index = ((ButtonCustom)sender).index;
            if (conf.Config.TryGetValue(index, out KeyBindEntry value))
            {
                EntryGUI addEntry = new EntryGUI(index, value);
                addEntry.ShowDialog();
                ReloadEntries();
                midi.EnableListening();
            }
        }

        private void DeleteEntry_Click(object sender, EventArgs e)
        {
            conf.Config.Remove(((ButtonCustom)sender).index);
            ReloadEntries();
        }

        private void MIDIControl_Load(object sender, EventArgs e)
        {
            ReloadEntries();
            if (options.options.Autoconnect) OBSControl.GetInstance().Connect();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            conf.Save();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            EntryGUI addEntry = new EntryGUI();
            addEntry.ShowDialog();
            ReloadEntries();
            midi.EnableListening();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            OBSControl.GetInstance().Connect();
        }

        private void BtnOptions_Click(object sender, EventArgs e)
        {
            OptionsGUI optionGUI = new OptionsGUI(options);
            optionGUI.ShowDialog();
        }

        class ButtonCustom : Button
        {
            public string index;
        }

        private void BtnStopSounds_Click(object sender, EventArgs e)
        {
            midi.StopAllSounds();
        }

        private void MIDIControlGUI_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Show();
        }
    }
}
