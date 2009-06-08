using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TCPReciever;
using DataService;
using System.ServiceModel;

namespace ControllCenter
{
    public partial class ControllCenter : Form
    {
        GPSReciever Service_test;
        ServiceHost host;

        public ControllCenter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.ShowDialog();
            txtPfad.Text = f.FileName;
        }

        private void btnStartReciever_Click(object sender, EventArgs e)
        {
            Service_test = new GPSReciever();
            Service_test.Start();
            lblRecieverStatus.Text = "Started";
        }

        private void btnStartWebservice_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(ANRLDataService), new Uri("http://localhost:5555"));
            host.Open();
            lblStatusWebservice.Text = "Started";
        }

        private void ControllCenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Service_test.Stop();
                host.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Closing, end remaining Threads" + ex.InnerException);
            }
        }

    }
}
