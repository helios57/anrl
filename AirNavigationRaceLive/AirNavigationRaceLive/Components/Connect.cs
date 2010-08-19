using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnrlInterfaces;
using System.Runtime.Remoting;

namespace AirNavigationRaceLive.Components
{
    public partial class Connect : UserControl
    {
        public event EventHandler Connected;

        public Connect()
        {
            InitializeComponent();
        }
        
        private void btnConnect_Click(object sender, EventArgs e)
        {
            IServer server = RemoteHelper.RemotingHelper.GetRemoteObjectOverTCP(typeof(IServer), "AnrlServer", fldServer.Text, 4321, false, false) as IServer;
            if (server != null)
            {
                IAnrlClient client = server.getAnrlClient(fldUsername.Text, fldPassword.Text);
                if (client != null)
                {
                    if (Connected != null)
                    {
                        Connected.Invoke(client, e);
                    }
                }
            }
        }
    }
}
