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
        public delegate void TwitchControlDelegateHandler(bool connect);
        public TwitchControlDelegateHandler TwitchControlDelegate;
        public delegate void SwitchProfileControlDelegateHandler();
        public SwitchProfileControlDelegateHandler SwitchProfileControlDelegate;
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
            TwitchControlDelegate = new TwitchControlDelegateHandler(UpdateTwitchStatus);
            SwitchProfileControlDelegate = new SwitchProfileControlDelegateHandler(UpdateProfile);

            options = new OptionsManagment();
            conf = new Configuration(this);
            midi = new MIDIListener(conf);

            this.ComboBoxProfile.Items.AddRange(conf.GetAllProfiles());
            this.ComboBoxProfile.SelectedItem = "Default";

            UpdateMIDIStatus();

            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            this.Hide();
        }

        private void UpdateProfile()
        {
            ReloadEntries();
            this.ComboBoxProfile.SelectedItem = conf.CurrentProfile;
        }

        private void MIDIControlGUI_FormClosing(Object sender, FormClosedEventArgs e)
        {
            midi.ReleaseAll();
        }
        public static MIDIControlGUI GetInstance()
        {
            return _instance;
        }

        private void UpdateMIDIStatus()
        {
            midiStatus.Text = "";
            foreach (string device in midi.GetMIDIINDevices())
            {
                midiStatus.Text += " " + device + ",";
            }
            midiStatus.Text = midiStatus.Text.Trim(',').Trim();
            if (midiStatus.Text == "")
            {
                midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDIRed;
                midiStatus.Text = "N/A";
                midiStatus.ForeColor = Color.Red;
            }
            else
            {
                midiButton.BackgroundImage = global::MidiControl.Properties.Resources.MIDI;
                midiStatus.ForeColor = Color.Green;
            }
        }

        private void UpdateOBSStatus(bool connect)
        {
            if (connect)
            {
                obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obs;
            }
            else
            {
                obsButton.BackgroundImage = global::MidiControl.Properties.Resources.obsRed;
            }
        }
        private void UpdateTwitchStatus(bool connect)
        {
            if (connect)
            {
                twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitch;
            }
            else
            {
                twitchButton.BackgroundImage = global::MidiControl.Properties.Resources.twitchRed;
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
                    Location = new Point(50, 9),
                    Name = "LblName",
                    Size = new Size(35, 13),
                    TabIndex = 2,
                    Text = entry.Key
                };

                ButtonCustom editUI = new ButtonCustom
                {
                    index = entry.Key,
                    BackgroundImage = global::MidiControl.Properties.Resources.edit,
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,

                    Location = new Point(3, 4),
                    Name = "BtnEdit",
                    Size = new Size(20, 20),
                    TabIndex = 0,
                    UseVisualStyleBackColor = true
                };
                editUI.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
                editUI.FlatAppearance.BorderSize = 0;
                editUI.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
                editUI.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
                editUI.Click += new EventHandler(this.EditEntry_Click);

                ButtonCustom deleteUI = new ButtonCustom
                {
                    index = entry.Key,
                    BackgroundImage = global::MidiControl.Properties.Resources.minus,
                    BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch,
                    FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                    Location = new Point(27, 4),
                    Name = "BtnDelete",
                    Size = new Size(20, 20),
                    TabIndex = 1,
                    UseVisualStyleBackColor = true
                };
                deleteUI.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
                deleteUI.FlatAppearance.BorderSize = 0;
                deleteUI.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
                deleteUI.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
                deleteUI.Click += new EventHandler(this.DeleteEntry_Click);

                entryUI.Controls.Add(nameUI);
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
            OBSControl.GetInstance().ConnectDisconnect();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            conf.SaveCurrentProfile();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            EntryGUI addEntry = new EntryGUI();
            addEntry.ShowDialog();
            ReloadEntries();
            midi.EnableListening();
        }

        private void ConnectOBS(object sender, EventArgs e)
        {
            OBSControl.GetInstance().ConnectDisconnect();
        }
        private void ConnectTwitch(object sender, EventArgs e)
        {
            TwitchChatControl.GetInstance().ConnectDisconnect();
        }
        private void ConnectMIDI(object sender, EventArgs e)
        {
            midi.RefeshMIDIDevices();
            UpdateMIDIStatus();
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

        private void ComboBoxProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
				bool createNew = false;
				bool copyToNew = false;

                if(! this.ComboBoxProfile.Items.Contains(this.ComboBoxProfile.Text))
                {
					//this.ComboBoxProfile.Items.Add(this.ComboBoxProfile.Text);
					createNew = true;
                }

				if(createNew)
					{
					switch(MessageBox.Show("This profile doesn't exist (yet).  Do you want to copy your current settings for profile '" + conf.CurrentProfile + "' into new profile '" + this.ComboBoxProfile.Text + "?", "New profile", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
					{
						case DialogResult.Yes:
							conf.CurrentProfile = this.ComboBoxProfile.Text;
							this.ComboBoxProfile.Items.Add(this.ComboBoxProfile.Text);
							conf.SaveCurrentProfileAs(this.ComboBoxProfile.Text);
							this.ComboBoxProfile.SelectedItem = this.ComboBoxProfile.Text;
							break;
						case DialogResult.No:
							// original behavior
							this.ComboBoxProfile.Items.Add(this.ComboBoxProfile.Text);
							this.ComboBoxProfile.SelectedItem = this.ComboBoxProfile.Text;
							conf.LoadProfile(this.ComboBoxProfile.SelectedItem.ToString());
							break;
						case DialogResult.Cancel:
							break;
					}
				}
				else
				{
					this.ComboBoxProfile.SelectedItem = this.ComboBoxProfile.Text;
					conf.LoadProfile(this.ComboBoxProfile.SelectedItem.ToString());
				}
            }
        }

        private void ComboBoxProfile_SelectedValueChanged(object sender, EventArgs e)
        {
            conf.LoadProfile(this.ComboBoxProfile.SelectedItem.ToString());
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if(this.ComboBoxProfile.SelectedItem.ToString() == "Default")
            {
                return;
            }

			if(MessageBox.Show("You are about to delete the profile '" + conf.CurrentProfile + "'.  Are you sure you want to do this?", "Confirm profile delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				string currProfile = this.ComboBoxProfile.SelectedItem.ToString();
				this.ComboBoxProfile.Items.Clear();
				this.ComboBoxProfile.Items.AddRange(conf.RemoveProfile(currProfile));
				this.ComboBoxProfile.SelectedItem = "Default";
			}
        }
    }
}
