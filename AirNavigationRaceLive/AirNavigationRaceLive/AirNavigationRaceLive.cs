using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive
{
    public partial class AirNavigationRaceLive : Form
    {
        public AirNavigationRaceLive()
        {
            InitializeComponent();
        }

        private void AirNavigationRaceLive_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Components.Credits());
            StatusStripLabel.Text = "Ready";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Components.Connect());
            StatusStripLabel.Text = "Ready to Connect to Server";
        }
    }
}
