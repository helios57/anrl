using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Dialogs;

namespace AirNavigationRaceLive.Comps
{
    public partial class Visualisation : UserControl
    {
        private Client.Client Client;
        public Visualisation(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            VisualisationPopup vp = new VisualisationPopup();
            vp.Show();
        }
    }
}
