using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GELive
{
    public partial class AnrlClient : Form
    {
        public RaceEntry CurrentRace = new RaceEntry();
        public AnrlClient()
        {
            InitializeComponent();
            CheckEnabled();
        }
        private void CheckEnabled()
        {
            bool Connected = false;
            bool TrackerSelected = false;
            bool TrackerHasPilot = false;
            bool RaceSelected = false;
            bool RaceHasName = false;
            #region Calculate bools
            if (InformationPool.Client != null && InformationPool.Client.State == System.ServiceModel.CommunicationState.Opened)
            {
                Connected = true;
            }
            if (lstTrackers.SelectedItems.Count ==1)
            {
                TrackerSelected = true;
            }
            if (lstTrackers.SelectedItems.Count == 1 && lstTrackers.SelectedItems[0].SubItems[4].Text != "")
            {
                TrackerHasPilot = true;
            }
            if (lstRace.SelectedItems.Count ==1)
            {
                RaceSelected = true;
            }
            if (fldRaceName.Text != "")
            {
                RaceHasName = true;
            }
            #endregion
            panelConnection.Enabled = !Connected;
            panelTrackerPilot.Enabled = Connected;
            panelRace.Enabled = Connected;
            btnAddPilotToTracker.Enabled = Connected && TrackerSelected && !TrackerHasPilot;
            btnRemvPilotFromTracker.Enabled = Connected && TrackerSelected && TrackerHasPilot;
            btnRemvRace.Enabled = Connected && RaceSelected;
            btnLoadDxf.Enabled = Connected && RaceHasName;
            btnRacePilotA.Enabled = Connected && RaceHasName;
            btnRacePilotB.Enabled = Connected && RaceHasName;
            btnRacePilotC.Enabled = Connected && RaceHasName;
            btnRacePilotD.Enabled = Connected && RaceHasName;
            if (fldRacePilotA.Text == "") btnRacePilotA.Text = "Add Pilot";
            else btnRacePilotA.Text = "Remove";
            if (fldRacePilotB.Text == "") btnRacePilotB.Text = "Add Pilot";
            else btnRacePilotB.Text = "Remove";
            if (fldRacePilotC.Text == "") btnRacePilotC.Text = "Add Pilot";
            else btnRacePilotC.Text = "Remove";
            if (fldRacePilotD.Text == "") btnRacePilotD.Text = "Add Pilot";
            else btnRacePilotD.Text = "Remove";
            btnSaveRace.Enabled = Connected && RaceHasName;
            btnSelectParcour.Enabled = Connected && RaceHasName;
        }
        private void Connect()
        {
            InformationPool.RemoteAddress = fldServer.Text;
            InformationPool.Username = fldUsername.Text;
            InformationPool.Password = fldPassword.Text;
            InformationPool.Connect();
            CheckEnabled();
            try
            {
                LoadTrackerList();
            }
            catch
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }
        private void LoadTrackerList()
        {
            lstTrackers.Items.Clear();
            List<List<String>> Trackerlist = InformationPool.Client.GetTrackers();
            foreach (List<String> ls in Trackerlist)
            {
                lstTrackers.Items.Add(new ListViewItem(ls.ToArray()));
            }
            CheckEnabled();
        }
        private void RemovePilotFromTracker()
        {
            int TrackerId = int.Parse(lstTrackers.SelectedItems[0].Text);
            if (TrackerId > 0) InformationPool.Client.CleanTracker(TrackerId);
            LoadTrackerList();
        }
        private void LoadRaces()
        {
            lstRace.Items.Clear();
            foreach (List<String> StringArray in InformationPool.Client.GetRaces())
            {
                ListViewItem lvi = new ListViewItem(new String[] {StringArray[0],StringArray[1]});
                lvi.Tag = new RaceEntry(StringArray.ToArray());
                lstRace.Items.Add(lvi); 
            }
        }
        private void SyncRace()
        {
            fldRaceName.Text = CurrentRace.Name;
            #region Pilotes
            if (CurrentRace.PilotA != null)
                fldRacePilotA.Text =
                    CurrentRace.PilotA.ID + " " +
                    CurrentRace.PilotA.LastName + " " +
                    CurrentRace.PilotA.SureName;
            else
                fldRacePilotA.Text = "";

            if (CurrentRace.PilotB != null)
                fldRacePilotB.Text =
                    CurrentRace.PilotB.ID + " " +
                    CurrentRace.PilotB.LastName + " " +
                    CurrentRace.PilotB.SureName;
            else
                fldRacePilotB.Text = "";

            if (CurrentRace.PilotC != null)
                fldRacePilotC.Text =
                    CurrentRace.PilotC.ID + " " +
                    CurrentRace.PilotC.LastName + " " +
                    CurrentRace.PilotC.SureName;
            else
                fldRacePilotD.Text = "";
            if (CurrentRace.PilotD != null)
                fldRacePilotD.Text =
                    CurrentRace.PilotD.ID + " " +
                    CurrentRace.PilotD.LastName + " " +
                    CurrentRace.PilotD.SureName;
            else
                fldRacePilotB.Text = "";
            #endregion 
            fldRaceDuration.Value = CurrentRace.Duration;
            fldRaceDate.Value = CurrentRace.StartTime;
            fldRaceTime.Value = CurrentRace.StartTime;
            fldRacePolygonsLoaded.Text = CurrentRace.Polygons.Polygons.Count.ToString();
            CheckEnabled();
        }
        #region Event Handlers
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }
        private void lstTrackers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnabled();
        }
        private void btnRefreshTrackerList_Click(object sender, EventArgs e)
        {
            LoadTrackerList();
        }
        private void btnRemvPilotFromTracker_Click(object sender, EventArgs e)
        {
            RemovePilotFromTracker();
        }
        private void btnAddPilotToTracker_Click(object sender, EventArgs e)
        {
            Pilot PPick = new Pilot();
            PPick.OnPilotOk += new EventHandler(PPick_OnPilotOk);
            PPick.Show();
        }
        void PPick_OnPilotOk(object sender, EventArgs e)
        {
            if (lstTrackers.SelectedItems.Count ==1)
            {
                int TrackerId = int.Parse(lstTrackers.SelectedItems[0].Text);
                PilotEntry PE = (PilotEntry)sender;
                if (PE.ID == "")
                {
                    InformationPool.Client.AddNewPilot(TrackerId, PE.LastName, PE.SureName, PE.PilotColor);
                } 
                if (PE.ID != "")
                {
                    InformationPool.Client.AddPilot(int.Parse(PE.ID),TrackerId, PE.LastName, PE.SureName, PE.PilotColor);
                }
            }
        }
        private void lstRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRace.SelectedItems.Count == 1 && lstRace.SelectedItems[0] != null)
            {
                CurrentRace = (RaceEntry)lstRace.SelectedItems[0].Tag;
            }
            SyncRace();
        }
        private void btnRacesRefresh_Click(object sender, EventArgs e)
        {
            LoadRaces();
            CurrentRace = new RaceEntry();
            SyncRace();
        }
        private void btnNewRace_Click(object sender, EventArgs e)
        {
            CurrentRace = new RaceEntry();
            SyncRace();
        }
        private void btnRemvRace_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstRace.SelectedItems.Count == 1 && lstRace.SelectedItems[0] != null)
                {
                    InformationPool.Client.RemoveRace(((RaceEntry)lstRace.SelectedItems[0].Tag).ID);
                    CurrentRace = new RaceEntry();
                    LoadRaces();
                    SyncRace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Rmoving Race " + ex.ToString());  
            }
        }
        private void btnLoadDxf_Click(object sender, EventArgs e)
        {
            OpenFileDialog fp = new OpenFileDialog();
            fp.Filter = "Penalty-Zonen |*.dxf";
            fp.FileOk += new CancelEventHandler(fp_FileOk);
            fp.ShowDialog();
        }
        void fp_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog of = (OpenFileDialog)sender;
            CurrentRace.Polygons = InformationPool.importFromDxf(of.FileName);
            SyncRace();
        }

        private void btnRacePilotA_Click(object sender, EventArgs e)
        {
            if (CurrentRace.PilotA == null)
            {
                Pilot PilotA = new Pilot();
                PilotA.OnPilotOk += new EventHandler(PilotA_OnPilotOk);
                PilotA.Show();
            }
            else
            {
                CurrentRace.PilotA = null;
                SyncRace();
            }
        }
        void PilotA_OnPilotOk(object sender, EventArgs e)
        {
            PilotEntry PilotA = (PilotEntry)sender;
            CurrentRace.PilotA = PilotA;
            SyncRace();
        }
        private void btnRacePilotB_Click(object sender, EventArgs e)
        {
            if (CurrentRace.PilotB == null)
            {
                Pilot PilotB = new Pilot();
                PilotB.OnPilotOk += new EventHandler(PilotB_OnPilotOk);
                PilotB.Show();
            }
            else
            {
                CurrentRace.PilotB = null;
                SyncRace();
            }
        }
        void PilotB_OnPilotOk(object sender, EventArgs e)
        {
            PilotEntry PilotB = (PilotEntry)sender;
            CurrentRace.PilotB = PilotB;
            SyncRace();
        }
        private void btnRacePilotC_Click(object sender, EventArgs e)
        {
            if (CurrentRace.PilotC == null)
            {
                Pilot PilotC = new Pilot();
                PilotC.OnPilotOk += new EventHandler(PilotC_OnPilotOk);
                PilotC.Show();
            }
            else
            {
                CurrentRace.PilotC = null;
                SyncRace();
            }
        }
        void PilotC_OnPilotOk(object sender, EventArgs e)
        {
            PilotEntry PilotC = (PilotEntry)sender;
            CurrentRace.PilotC = PilotC;
            SyncRace();
        }
        private void btnRacePilotD_Click(object sender, EventArgs e)
        {
            if (CurrentRace.PilotD == null)
            {
                Pilot PilotD = new Pilot();
                PilotD.OnPilotOk += new EventHandler(PilotD_OnPilotOk);
                PilotD.Show();
            }
            else
            {
                CurrentRace.PilotD = null;
                SyncRace();
            }
        }
        void PilotD_OnPilotOk(object sender, EventArgs e)
        {
            PilotEntry PilotD = (PilotEntry)sender;
            CurrentRace.PilotD = PilotD;
            SyncRace();
        }
        private void fldRaceName_TextChanged(object sender, EventArgs e)
        {
            CurrentRace.Name = fldRaceName.Text;
            SyncRace();
        }
        private void fldRaceDuration_ValueChanged(object sender, EventArgs e)
        {
            CurrentRace.Duration = fldRaceDuration.Value;
            SyncRace();
        }
        private void fldRaceTime_ValueChanged(object sender, EventArgs e)
        {
            CurrentRace.StartTime = new DateTime(
                CurrentRace.StartTime.Year,
                CurrentRace.StartTime.Month,
                CurrentRace.StartTime.Day,
                fldRaceTime.Value.Hour,
                fldRaceTime.Value.Minute,
                fldRaceTime.Value.Second);
            SyncRace();
        }
        private void fldRaceDate_ValueChanged(object sender, EventArgs e)
        {
            CurrentRace.StartTime = new DateTime(
                fldRaceTime.Value.Year,
                fldRaceTime.Value.Month,
                fldRaceTime.Value.Day,
                CurrentRace.StartTime.Hour,
                CurrentRace.StartTime.Minute,
                CurrentRace.StartTime.Second);
            SyncRace();
        }



        private void btnSaveRace_Click(object sender, EventArgs e)
        {

        }
        #endregion


        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            //@todo when used
        }

        private void btnSelectParcour_Click(object sender, EventArgs e)
        {

        }


    }
}
