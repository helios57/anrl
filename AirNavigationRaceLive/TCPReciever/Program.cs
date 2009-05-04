using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TCPReciever
{
    static class Program
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Control c = new Control();
            //Application.Run(new Control());
            GPSReciever Service_test = new GPSReciever();
            Service_test.Start();
        }
    }
}
