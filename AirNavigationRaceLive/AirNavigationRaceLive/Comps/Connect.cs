using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Client;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class Connect : UserControl
    {
        public event EventHandler Connected;

        private Client.Client c;

        public Connect()
        {
            InitializeComponent();
            c = Client.Client.getClient();
            UpdateEnablement();
        }
        private void UpdateEnablement()
        {
            bool loggedIn = c!=null;
            btnLogin.Enabled = !loggedIn;
            btnRegister.Enabled = !loggedIn;
            fldServer.Enabled = !loggedIn;
            fldUsername.Enabled = !loggedIn;
            fldPassword.Enabled = !loggedIn;
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            AirNavigationRaceLiveMain.SetStatusText("");
            UpdateEnablement();
            Connected.Invoke(Client.Client.getClient(), e);
        }

        private void fldServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = Client.Client.getClient();
            UpdateEnablement();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //c.Authenticate(fldUsername.Text, fldPassword.Text);
                if (c!= null)// c.isLoggedIn())
                {
                    Status.SetStatus("Logged in, please choose a Competition");
                    Connected.Invoke(c, e);
                }
                else
                {
                    Status.SetStatus("Login was not successfull!");
                }
            }
            catch
            {
                Status.SetStatus("Login was not successfull!");
            }
            UpdateEnablement();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //c.Register(fldUsername.Text, fldPassword.Text);
        }
    }
}
