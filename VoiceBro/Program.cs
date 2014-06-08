using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceBro
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            VoiceDetector detector = new VoiceDetector(null, new System.Speech.Recognition.Choices(new string[] { "computer hello", "computer shields", "computer power", "computer attack" }));
            
            MainView gui = new MainView(detector);
            Application.Run(gui);
        }
    }
}
