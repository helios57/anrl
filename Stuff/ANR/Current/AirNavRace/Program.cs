using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ANR.ErrorLog;

namespace ANR
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AirNavRace());
            }
            else if (args[1] == "open")
            {
                string filename = args[0];
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AirNavRace(filename));
            }
        }


        //Provides the General Application Handling. Logfile to be created...
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Log.WriteToLog(e.Exception);
        }
    }
}
