﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GELive
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
            //WSManager test = new WSManager();
            //string bla = test.GetKml();
            Application.Run(new anrl_gui());
        }
    }
}
