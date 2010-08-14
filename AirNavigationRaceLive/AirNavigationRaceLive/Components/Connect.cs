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
        public Connect()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IServer server = RemoteHelper.RemotingHelper.GetRemoteObjectOverTCP(typeof(IServer), "AnrlServer", "localhost", 4321, false, false) as IServer;
            if (server != null)
            {
                IAnrlClient client = server.getAnrlClient("test", "test");
                client.getTrackers();
            }
            /*
            Client = new ANRL.ANRLDataService.ANRLDataServiceClient(ConnectionConfig, RemoteAddress);
            if (!RemoteAddress.Contains("127.0.0.1"))
            {
                Client.ClientCredentials.UserName.UserName = Username;
                Client.ClientCredentials.UserName.Password = Password;
                Client.ClientCredentials.Windows.ClientCredential.UserName = Username;
                Client.ClientCredentials.Windows.ClientCredential.Password = Password;
            }
            return Client.State == System.ServiceModel.CommunicationState.Created;*/
        }

        void client_Update(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
