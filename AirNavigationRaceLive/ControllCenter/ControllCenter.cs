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
using System.Data.Linq;

namespace ControllCenter
{
    public partial class ControllCenter : Form
    {
        GPSReciever Service_test;

        
        ServiceHost host;
        bool GPS_Service_running = false;
        bool Service_Host_running = false;
        String DB_Path = "";

        public ControllCenter()
        {
            InitializeComponent();
            btnStartReciever.Enabled = false;
            btnStartWebservice.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "DB |*.mdf";
            f.ShowDialog();
            DB_Path = f.FileName;
            try
            {
                DataContext db = new DataContext(DB_Path);
                db.SubmitChanges();
                txtPfad.Text = DB_Path;
                btnStartReciever.Enabled = true;
                btnStartWebservice.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Fehler beim öffnen der DB, bitte DB überprüfen");
            }
        }

        private void btnStartReciever_Click(object sender, EventArgs e)
        {
            try
            {
                Service_test = new GPSReciever(DB_Path);
                Service_test.Start();
                lblRecieverStatus.Text = "Started";
                GPS_Service_running = true;
                btnStartReciever.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Fehler beim starten des Reciever-Services");
            }
        }

        private void btnStartWebservice_Click(object sender, EventArgs e)
        {
            ExitForm ef = new ExitForm();
            try
             {
                ef.label1.Text = "Bitte Warten, der Webservice wird gestartet";
                ef.Show();
                ef.Refresh();
                ANRLDataService ds = new ANRLDataService(DB_Path);
                host = new ServiceHost(ds, new Uri("http://localhost:5555"));
            
                host.Open();
                lblStatusWebservice.Text = "Started";
                Service_Host_running = true;
                btnStartWebservice.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Fehler beim Starten des Webservices");
            }
            ef.Close();            
        }

        private void ControllCenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExitForm ef = new ExitForm();
            try
            {
                ef.label1.Text = "Beenden, Bitte Warten";
                ef.Show();
                ef.Refresh();
                if (GPS_Service_running)
                {
                    ef.label1.Text = "Bitte Warten, Reciever-Service wird beendet";
                    Service_test.Stop();
                }
                if (Service_Host_running)
                {
                    ef.label1.Text = "Bitte Warten, Web-Service wird beendet";
                    host.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Closing, end remaining Threads" + ex.InnerException);
            }
            ef.Close();
        }
    }
}
