using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Client;
using NetworkObjects;
using AirNavigationRaceLive.Comps.Helper;
using System.Threading;

namespace AirNavigationRaceLive.Dialogs
{
    public partial class UploadGPX : Form
    {
        private Client Client;
        private t_Competition_Team ct;
        private String IMEI = "_GPX_IMPORT_" + DateTime.Now.Ticks;

        public EventHandler OnFinish;
        public UploadGPX(Client Client, t_Competition_Team ct)
        {
            this.Client = Client;
            this.ct = ct;
            InitializeComponent();
        }

        

        public void UpdateEnablement()
        {
            btnUploadData.Enabled = textBoxPositions.Tag != null;
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            if (textBoxPositions.Tag != null)
            {
                List<t_GPSPoint> list = textBoxPositions.Tag as List<t_GPSPoint>;
                list[0].identifier = IMEI;
                Thread thread = new Thread(new ParameterizedThreadStart(upload));
                thread.Start(list);

                MessageBox.Show("Upload Started in Background!");
                Close();
            }
        }
        private void upload(object o)
        {
            t_Competition_Team ct = this.ct;
            List<t_GPSPoint> list = o as List<t_GPSPoint>;
            int count = 0;
            int length = list.Count;
            List<t_GPSPoint> subList = null;
            while (count < length)
            {
                if (count % 1000 == 0)
                {
                    if (subList == null)
                    {
                        subList = new List<t_GPSPoint>();
                    }
                    else
                    {
                        subList[0].identifier = list[0].identifier;
                        Client.uploadGPSData(subList);
                        Application.DoEvents();
                        subList = new List<t_GPSPoint>();
                    }
                }
                subList.Add(list[count++]);
            }
            if (subList != null && subList.Count > 0)
            {
                subList[0].identifier = list[0].identifier;
                int ID_Tracker = Client.uploadGPSData(subList);
                t_Competition c = Client.getCompetitions().First(p => p.t_Competition_Team.Count(pp => pp.ID == ct.ID) == 1);
                Client.getTracker(ID_Tracker);
                List<t_Tracker> toDelete = new List<t_Tracker>();
                foreach(t_Tracker tr in c.t_Competition_Team.First(p => p.ID == ct.ID).t_Tracker)
                {
                    if (tr.Name.StartsWith("_GAC_IMPORT_"))
                    {
                        toDelete.Add(tr);
                    }
                }
                foreach (t_Tracker t in toDelete)
                {
                    c.t_Competition_Team.First(p => p.ID == ct.ID).t_Tracker.Remove(t);
                    c.t_Competition_Team.First(p => p.ID == ct.ID).t_Tracker.Add(t);
                }
                Client.saveCompetition(c);
                if (OnFinish != null)
                {
                    OnFinish.Invoke(null, null);
                }
            }

            MessageBox.Show("Upload Finished! \n Please reload the current form to refresh...");
        }

        private void btnImportGPX_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string FileFilter = "GPX  (*.gpx)|*.gpx";
            ofd.Title = "GPX Import";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = FileFilter;
            ofd.FileOk += new CancelEventHandler(ofd_FileOkGPX);
            ofd.ShowDialog();
        }

        void ofd_FileOkGPX(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            try
            {
                List<t_GPSPoint> list = Importer.GPSdataFromGPX(IMEI, ofd.FileName);
                textBoxPositions.Text = list.Count.ToString();
                textBoxPositions.Tag = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error while Parsing File");
            }
            UpdateEnablement();
        }

    }
}
