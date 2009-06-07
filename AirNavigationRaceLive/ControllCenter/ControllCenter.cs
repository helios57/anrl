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
using GELive;

namespace ControllCenter
{
    public partial class ControllCenter : Form
    {
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
            GPSReciever Service_test = new GPSReciever();
            Service_test.Start();
            lblRecieverStatus.Text = "Started";
        }

        private void btnStartWebservice_Click(object sender, EventArgs e)
        {
            ServiceHost host = new ServiceHost(typeof(ANRLDataService), new Uri("http://localhost:5555"));
            host.Open();
            lblStatusWebservice.Text = "Started";
        }

        private void btnStartANRLGUI_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //WSManager test = new WSManager();
            //string bla = test.GetKml();
            Application.Run(new anrl_gui());
        }

    }
}
