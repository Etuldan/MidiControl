using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MidiControl
{
    public partial class OptionsGUI : Form
    {
        private readonly OptionsManagment options;
        public OptionsGUI(OptionsManagment options)
        {
            this.options = options;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            TxtBoxOBSIP.Text = options.options.Ip;
            TxtBoxOBSPassword.Text = options.options.Password;
            ChkBoxAutoConnectStart.Checked = options.options.Autoconnect;
            ChkBoxAutoReconnect.Checked = options.options.AutoReconnect;

            List<string> midiIn = MIDIListener.GetInstance().midiInStringOptions;
            foreach (string inInterface in midiIn)
            {
                ChkCmbBoxMIDI.Items.Add(inInterface);
                if(options.options.MIDIInterfaces.Contains(inInterface))
                {
                    ChkCmbBoxMIDI.SetItemChecked(ChkCmbBoxMIDI.Items.IndexOf(inInterface), true);
                }
            }

            txtBoxStopAllSoundsDevice.Text = options.options.MidiDeviceStopAllSounds;
            txtBoxStopAllSoundsChannel.Text = options.options.ChannelStopAllSounds.ToString();
            txtBoxStopAllSoundsNote.Text = options.options.NoteNumberStopAllSounds.ToString();
            txtBoxDelay.Text = options.options.Delay.ToString();

            txtBoxTwitchLogin.Text = options.options.TwitchLogin;
            txtBoxTwitchToken.Text = options.options.TwitchToken;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            options.options.Ip = TxtBoxOBSIP.Text;
            options.options.Password = TxtBoxOBSPassword.Text;
            options.options.Autoconnect = ChkBoxAutoConnectStart.Checked;
            options.options.AutoReconnect = ChkBoxAutoReconnect.Checked;

            options.options.MidiDeviceStopAllSounds = txtBoxStopAllSoundsDevice.Text;
            try
            {
                options.options.ChannelStopAllSounds = Int32.Parse(txtBoxStopAllSoundsChannel.Text);
                options.options.NoteNumberStopAllSounds = Int32.Parse(txtBoxStopAllSoundsNote.Text);
            }
            catch (FormatException)
            {
                options.options.ChannelStopAllSounds = 0;
                options.options.NoteNumberStopAllSounds = 0;
            }


            CheckedListBox.CheckedItemCollection items = ChkCmbBoxMIDI.CheckedItems;
            options.options.MIDIInterfaces.Clear();
            foreach (object item in items)
            {
                options.options.MIDIInterfaces.Add(item.ToString());
            }
            try
            {
                options.options.Delay = Int32.Parse(txtBoxDelay.Text);
            }
            catch (FormatException)
            {
                options.options.Delay = 0;
            }
            options.options.TwitchLogin = txtBoxTwitchLogin.Text;
            options.options.TwitchToken = txtBoxTwitchToken.Text;

            options.Save();
            this.Close();
            this.Dispose();
        }

        private void BtnRequestTwitchLogin_Click(object sender, EventArgs e)
        {
            WebViewLoginTwitch login = new WebViewLoginTwitch(options.options);
            login.ShowDialog();
            if (options.options.TwitchLogin != "" && options.options.TwitchToken != "")
            {
                txtBoxTwitchLogin.Text = options.options.TwitchLogin;
                txtBoxTwitchToken.Text = options.options.TwitchToken;
                TwitchChatControl.GetInstance().Connect();
            }
        }

        private void BtnRequestTwitchLogout_Click(object sender, EventArgs e)
        {
            txtBoxTwitchLogin.Text = "";
            txtBoxTwitchToken.Text = "";
            TwitchChatControl.GetInstance().Disconnect();
        }
    }
}
