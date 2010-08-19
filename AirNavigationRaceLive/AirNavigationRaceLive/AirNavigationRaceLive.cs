using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnrlInterfaces;

namespace AirNavigationRaceLive
{
    public partial class AirNavigationRaceLive : Form
    {
        AnrlInterfaces.IAnrlClient Client;
        Components.Connect Connect;
        Components.Credits Credits;

        public AirNavigationRaceLive()
        {
            Client = null;
            InitializeComponent();
        }

        private void AirNavigationRaceLive_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Credits == null)
            {
                Credits = new Components.Credits();
            }
            MainPanel.Controls.Add(Credits);
            StatusStripLabel.Text = "Ready";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Client == null)
            {
                MainPanel.Controls.Clear();
                if (Connect == null)
                {
                    Connect = new Components.Connect();
                    Connect.Connected += new EventHandler(Connect_Connected);
                }
                MainPanel.Controls.Add(Connect);
                StatusStripLabel.Text = "Ready to Connect to Server";
            }
            else
            {
                StatusStripLabel.Text = "Already connected to Server";
            }
        }

        private void Connect_Connected(object sender, EventArgs e)
        {
            AnrlInterfaces.IAnrlClient c = sender as IAnrlClient;
            if (c != null)
            {
                Client = c;
                StatusStripLabel.Text = "Connected to Server";
                MainPanel.Controls.Clear();
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = null;
            StatusStripLabel.Text = "Disconnected from Server";
        }
    }
}
