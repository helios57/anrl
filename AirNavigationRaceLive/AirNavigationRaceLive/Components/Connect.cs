using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components
{
    public partial class Connect : UserControl
    {
        public Connect()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {/*
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
    }
}
