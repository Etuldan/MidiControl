using System;
#if DEBUG
using System.Diagnostics;
#endif
using System.Windows.Forms;

namespace MidiControl
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Debug.Listeners.Add(new TextWriterTraceListener("./debug.log"));
            Debug.AutoFlush = true;
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MIDIControlGUI());
        }
    }
}
