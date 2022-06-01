using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MidiControl
{
    public partial class OptionsGUI : Form
    {
        private readonly OptionsManagment options;
        public OptionsGUI(OptionsManagment options, int tab = 0)
        {
            this.options = options;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MIDIControlGUI));
            InitializeComponent();
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            TxtBoxOBSIP.Text = options.options.Ip;
            TxtBoxOBSPassword.Text = options.options.Password;

            List<string> midiIn = MIDIListener.GetInstance().midiInStringOptions;
            foreach (string inInterface in midiIn)
            {
                ChkCmbBoxMIDI.Items.Add(inInterface);
                if(options.options.MIDIInterfaces.Contains(inInterface))
                {
                    ChkCmbBoxMIDI.SetItemChecked(ChkCmbBoxMIDI.Items.IndexOf(inInterface), true);
                }
            }

            txtBoxDelay.Text = options.options.Delay.ToString();

            txtBoxTwitchLogin.Text = options.options.TwitchLogin;

			chkStartToTray.Checked = options.options.StartToTray;
			chkAlwaysOnTop.Checked = options.options.AlwaysOnTop;
			chkLoadLastProfileOnStart.Checked = options.options.LoadLastProfileOnStartup;
			chkConfirmDeleteKeybind.Checked = options.options.ConfirmKeybindDeletion;
			chkConfirmDeleteProfile.Checked = options.options.ConfirmProfileDeletion;

			tabControl1.SelectedIndex = tab;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            options.options.Ip = TxtBoxOBSIP.Text;
            options.options.Password = TxtBoxOBSPassword.Text;

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

			options.options.StartToTray = chkStartToTray.Checked;
			options.options.AlwaysOnTop = chkAlwaysOnTop.Checked;
			options.options.LoadLastProfileOnStartup = chkLoadLastProfileOnStart.Checked;
			options.options.ConfirmKeybindDeletion = chkConfirmDeleteKeybind.Checked;
			options.options.ConfirmProfileDeletion = chkConfirmDeleteProfile.Checked;

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
                TwitchChatControl.GetInstance().Connect();
            }
        }

        private void BtnRequestTwitchLogout_Click(object sender, EventArgs e)
        {
            txtBoxTwitchLogin.Text = "";

            options.options.TwitchLogin = "";
            options.options.TwitchToken = "";
            options.options.TwitchRefreshToken = "";
            TwitchChatControl.GetInstance().Disconnect();
        }
	}
}
