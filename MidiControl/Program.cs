using System;
#if DEBUG
using System.Diagnostics;
using System.IO;
#endif
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
#if DEBUG
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string ConfFolder = Path.Combine(folder, "MIDIControl");
            Debug.Listeners.Add(new TextWriterTraceListener(Path.Combine(ConfFolder, Path.GetFileName("debug.log"))));
            Debug.AutoFlush = true;
#endif


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			//Application.Run(new MIDIControlGUI());

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
