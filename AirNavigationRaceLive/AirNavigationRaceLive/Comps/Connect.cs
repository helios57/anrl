using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Client;

namespace AirNavigationRaceLive.Comps
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
            try
            {
                Client.Client c = new Client.Client(fldServer.Text);
                c.Authenticate(fldUsername.Text, fldPassword.Text);
                if (c.isAuthenticated() && Connected != null)
                {
                    Connected.Invoke(c, e);
                }
            }
            catch
            {
            }
        }
    }
}
