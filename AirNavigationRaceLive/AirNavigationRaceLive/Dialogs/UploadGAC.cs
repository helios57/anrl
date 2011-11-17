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
    public partial class UploadGAC : Form
    {
        private Client Client;
        private NetworkObjects.CompetitionTeam ct;
        private String IMEI = "_GAC_IMPORT_" + DateTime.Now.Ticks;

        public UploadGAC(Client Client, NetworkObjects.CompetitionTeam ct)
        {
            this.Client = Client;
            this.ct = ct;
            InitializeComponent();
        }

        private void btnImportGAC_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string FileFilter = "GAC  (*.gac)|*.gac";
            ofd.Title = "GAC Import";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = FileFilter;
            ofd.FileOk += new CancelEventHandler(ofd_FileOk);
            ofd.ShowDialog();
        }

        void ofd_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            try
            {
                DateTime dt = dateGAC.Value;
                List<GPSData> list = Importer.GPSdataFromGAC(dt.Year, dt.Month, dt.Day, IMEI, ofd.FileName);
                textBoxPositions.Text = list.Count.ToString();
                textBoxPositions.Tag = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error while Parsing File");
            }
            UpdateEnablement();
        }
        public void UpdateEnablement()
        {
            btnUploadData.Enabled = textBoxPositions.Tag != null;
        }

        private void btnUploadData_Click(object sender, EventArgs e)
        {
            if (textBoxPositions.Tag != null)
            {
                List<GPSData> list = textBoxPositions.Tag as List<GPSData>;
                list[0].trackerName = IMEI;
                Thread thread = new Thread(new ParameterizedThreadStart(upload));
                thread.Start(list);

                MessageBox.Show("Upload Started in Background!");
                Close();
            }
        }
        private void upload(object o)
        {
            CompetitionTeam ct = this.ct;
            List<GPSData> list = o as List<GPSData>;
            int count = 0;
            int length = list.Count;
            List<GPSData> subList = null;
            while (count < length)
            {
                if (count % 1000 == 0)
                {
                    if (subList == null)
                    {
                        subList = new List<GPSData>();
                    }
                    else
                    {
                        subList[0].trackerName = list[0].trackerName;
                        Client.uploadGPSData(subList);
                        Application.DoEvents();
                        subList = new List<GPSData>();
                    }
                }
                subList.Add(list[count++]);
            }
            if (subList != null && subList.Count > 0)
            {
                subList[0].trackerName = list[0].trackerName;
                int ID_Tracker = Client.uploadGPSData(subList);
                NetworkObjects.Competition c = Client.getCompetitions().First(p => p.CompetitionTeamList.Count(pp => pp.ID == ct.ID) == 1);
                Client.getTracker(ID_Tracker);
                c.CompetitionTeamList.First(p => p.ID == ct.ID).ID_TrackerList.Add(ID_Tracker);
                Client.saveCompetition(c);
            }

            MessageBox.Show("Upload Finished! \n Please reload the current form to refresh...");
        }
    }
}
