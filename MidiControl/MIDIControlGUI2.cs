using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MidiControl {
	public partial class MIDIControlGUI2 : Form {
		public delegate void OBSControlDelegateHandler(bool connect);
		public OBSControlDelegateHandler OBSControlDelegate;
		public delegate void TwitchControlDelegateHandler(bool connect);
		public TwitchControlDelegateHandler TwitchControlDelegate;
		public delegate void SwitchProfileControlDelegateHandler();
		public SwitchProfileControlDelegateHandler SwitchProfileControlDelegate;
		private readonly OptionsManagment options;
		private readonly Configuration conf;
		private readonly MIDIListener midi;

		private bool actuallyClosing = false;

		private static MIDIControlGUI2 _inst;
		public static MIDIControlGUI2 GetInstance() {
			return _inst;
		}

		// window constructor
		public MIDIControlGUI2() {
			_inst = this;

			InitializeComponent();

			
		}

		// form events
		//

		// delegate handlers
		//

		// ui events
		//
	}
}
