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
                    textStatus.Text = "Connected to Server, downloading data";
                    while (!c.IsInitialLoadComplete())
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                    textStatus.Text = "Connected to Server, download finished";

                    Connected.Invoke(c, e);
                }
                else
                {
                    textStatus.Text = "Connection failed";
                }
            }
            catch
            {
            }
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            textStatus.Text = "";
        }
    }
}
