using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace AnrlService
{
    public partial class AnrlService : ServiceBase
    {
        Server.Server s;
        public AnrlService()
        {
            s = new Server.Server(); 
            InitializeComponent();
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                RemoteHelper.RemotingHelper.PublishObjectOverTCP(s, "AnrlServer", 4321, false, false);
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("Unable to start Service " + ex.InnerException.Message);
            }
        }

        protected override void OnStop()
        {
        }
    }
}
