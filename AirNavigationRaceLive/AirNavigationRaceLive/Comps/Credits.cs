using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Comps
{
    public partial class Credits : UserControl
    {
        public Credits()
        {
            InitializeComponent();
        }

        private void btnDonations_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=6861542");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenSharpSoft();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenSharpSoft();
        }

        private static void OpenSharpSoft()
        {
            System.Diagnostics.Process.Start(@"http://SharpSoft.ch");
        }
    }
}
