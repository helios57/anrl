using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace TCPReciever
{
    partial class GPSReciever : ServiceBase
    {
        Server GPS;
        public GPSReciever()
        {
            InitializeComponent();
        }

        public void Start()
        {
            OnStart(null);
        }
        protected override void OnStart(string[] args)
        {
            GPS = new Server();
        }

        protected override void OnStop()
        {
            GPS.Stop();
        }
    }
}
