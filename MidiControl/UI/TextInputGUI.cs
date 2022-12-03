using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidiControl {
	public partial class TextInputGUI : Form {
		public TextInputGUI() {
			InitializeComponent();

			ThemeSupport.ThemeOtherWindow((new OptionsManagment()).options.Theme, this);
		}

		public static TextInputResponse ShowPrompt(string message, string caption, string default_response = "") {
			using(var form = new TextInputGUI()) {
				form.lblMessage.Text = message;
				form.Text = caption;
				form.txtInput.Text = default_response;

				var resp = form.ShowDialog();

				return new TextInputResponse() {
					Accepted = (resp == DialogResult.OK),
					Text = form.txtInput.Text
				};
			}
		}

		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}

	public class TextInputResponse {
		public bool Accepted { get; set; }
		public string Text { get; set; }
	}
}
