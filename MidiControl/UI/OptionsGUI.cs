using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MidiControl
{
    public partial class OptionsGUI : Form
    {
        private readonly OptionsManagment options;
        private List<Panel> panels;

        public OptionsGUI(OptionsManagment options, string tab = "general")
        {
            this.options = options;
            InitializeComponent();
            Icon = Properties.Resources.icon;
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
			cboToolbarPosition.SelectedIndex = options.options.ToolbarPosition;

			cboTheme.Items.Clear();
			cboTheme.Items.AddRange(ThemeSupport.GetThemesList());
			cboTheme.SelectedIndex = options.options.Theme;

            // select the category
            if(treeView1.Nodes.Find(tab, true).Length == 0)
                tab = "general";
            treeView1.SelectedNode = treeView1.Nodes.Find(tab, true)[0];
			
			// prepare the panels
            pnlGeneral.Location = new System.Drawing.Point(148, 12);
            pnlInterface.Location = new System.Drawing.Point(148, 12);

            pnlInterface.Visible = false;

            panels = new List<Panel>() {
                pnlGeneral,
                pnlInterface
            };

			// show the correct panel
			OptionsCategoryChanged(this, new TreeNodeMouseClickEventArgs(treeView1.SelectedNode, MouseButtons.Left, 1, 0, 0));

			// theme the window
			ThemeSupport.ThemeOtherWindow(options.options.Theme, this);
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
			options.options.ToolbarPosition = cboToolbarPosition.SelectedIndex;
			options.options.Theme = cboTheme.SelectedIndex;

            options.Save();
            this.Close();
            this.Dispose();
        }

        private async void BtnRequestTwitchLogin_Click(object sender, EventArgs e)
        {
            var taskServer = Task.Run(() => {
                var server = new WebServer();
                options.options.TwitchLogin = server.Login;
                options.options.TwitchToken = server.OAuthCode;
                options.options.TwitchRefreshToken = server.RefreshToken;

                if (options.options.TwitchLogin != "" && options.options.TwitchToken != "")
                {
                    TwitchChatControl.GetInstance().Connect();
                    return options.options.TwitchLogin;
                }
                return string.Empty;
            });

            var taskBrowser = Task.Run(() => {
                var uriBuilder = new UriBuilder("https://id.twitch.tv/oauth2/authorize?");
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query.Add("response_type", "code");
                query.Add("client_id", ConfigurationManager.AppSettings["TwitchClientId"]);
                query.Add("redirect_uri", ConfigurationManager.AppSettings["TwitchLocalUrl"]);
                query.Add("scope", ConfigurationManager.AppSettings["TwitchScope"]);
                query.Add("state", "c3ab8aa609ea11e793ae92361f002671");
                uriBuilder.Query = query.ToString();
                Process.Start(uriBuilder.Uri.ToString());
            });

            await Task.WhenAll(taskServer, taskBrowser);
            txtBoxTwitchLogin.Text = await taskServer;
        }

        private void BtnRequestTwitchLogout_Click(object sender, EventArgs e)
        {
            txtBoxTwitchLogin.Text = "";

            options.options.TwitchLogin = "";
            options.options.TwitchToken = "";
            options.options.TwitchRefreshToken = "";
            TwitchChatControl.GetInstance().Disconnect();
        }

        private void OptionsCategoryChanged(object sender, TreeNodeMouseClickEventArgs e) {
            this.Text = "Options - " + e.Node.Text;
            foreach(var p in panels) {
                p.Visible = ((p.Tag as string) == e.Node.Name);
            }
        }

		private void CancelPressed(object sender, EventArgs e) {
			this.Close();
		}
	}
}
