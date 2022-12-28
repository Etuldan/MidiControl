using System;
using System.Windows.Forms;

namespace MidiControl
{
    static class Program
    {

		public static bool StartedToTray = false;

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

			var mainForm = new MIDIControlGUI();
			var options = (new OptionsManagment()).options;

			StartedToTray = options.StartToTray;

			if(options.StartToTray) {
				Application.Run();
			} else {
				Application.Run(mainForm);
			}
        }
    }
}
