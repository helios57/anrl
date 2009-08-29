﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GELive.ANRLDataService;
using System.Threading;

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
            if (lstTrackers.SelectedItems.Count == 1 && lstTrackers.SelectedItems[0].SubItems.Count > 4 && lstTrackers.SelectedItems[0].SubItems[4].Text != "")
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
            panelConnection.Visible = !Connected;
            panelTrackerPilot.Enabled = Connected;
            panelTrackerPilot.Visible = Connected;
            panelRace.Enabled = Connected;
            panelRace.Visible = Connected;
            panelStarterPanel.Enabled = Connected;
            panelStarterPanel.Visible = Connected;
            btnAddPilotToTracker.Enabled = Connected && TrackerSelected && !TrackerHasPilot;
            btnRemvPilotFromTracker.Enabled = Connected && TrackerSelected && TrackerHasPilot;
            btnRemvRace.Enabled = Connected && RaceSelected;
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
            btnShowRanking.Enabled = Connected && RaceSelected;
            RefreshTimeline();

        }

        private void Connect()
        {
            Developper d = new Developper();
            d.Show();
            InformationPool.RemoteAddress = fldServer.Text;
            InformationPool.Username = fldUsername.Text;
            InformationPool.Password = fldPassword.Text;
            InformationPool.Connect();
            CheckEnabled();
            try
            {
                LoadTrackerList();
                LoadRaces();
            }
            catch
            {
                MessageBox.Show("Wrong Username or Password");
            }
            d.UseWaitCursor = false;
            d.lblConnect.Visible = false;
            d.Cursor = System.Windows.Forms.Cursors.Hand;
        }
        private void LoadTrackerList()
        {
            lstTrackers.Items.Clear();
            List<t_Tracker> Trackerlist = InformationPool.Client.GetTrackers();
            List<t_Pilot> PilotList = InformationPool.Client.GetPilots();

            foreach (t_Tracker t in Trackerlist)
            {
                ListViewItem lvi = new ListViewItem(new String[] { t.ID.ToString(), t.IMEI });
                lvi.Tag = t;
                if (PilotList.Count(p => p.ID_Tracker == t.ID) == 1)
                {
                    t_Pilot Pilot = PilotList.Single(p => p.ID_Tracker == t.ID);
                    lvi.SubItems.Add(Pilot.ID.ToString());
                    lvi.SubItems.Add(Pilot.LastName);
                    lvi.SubItems.Add(Pilot.SureName);
                    lvi.BackColor = Color.FromArgb(int.Parse(Pilot.Color));
                }
                lstTrackers.Items.Add(lvi);
            }
            lstVisualPilotsToShow.Items.Clear();
            foreach (t_Pilot p in PilotList.Where(p=>p.ID_Tracker > 0))
            {
                lstVisualPilotsToShow.Items.Add(new PilotLst(p));
            }
            CheckEnabled();
            CheckPilotListChecked();
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
            lstVisualRacesToShow.Items.Clear();
            List<t_Race> RaceList = InformationPool.Client.GetRaces();
            foreach (t_Race Race in RaceList)
            {
                ListViewItem lvi = new ListViewItem(new String[] {Race.ID.ToString(),Race.Name});
                lvi.Tag = new RaceEntry(Race);
                lstRace.Items.Add(lvi);
                RaceLst rl = new RaceLst(Race);
                rl.re = (RaceEntry)lvi.Tag;
                lstVisualRacesToShow.Items.Add(rl);
            }
            CheckRacecListChecked();
        }
        private void SyncRace()
        {
            fldRaceName.Text = CurrentRace.Name;
            #region Pilotes
            if (CurrentRace.PilotA != null)
            {
                fldRacePilotA.Text =
                    CurrentRace.PilotA.ID + " " +
                    CurrentRace.PilotA.LastName + " " +
                    CurrentRace.PilotA.SureName;
                fldRacePilotA.BackColor = Color.FromArgb(int.Parse(CurrentRace.PilotA.PilotColor));
            }
            else
            {
                fldRacePilotA.Text = "";
                fldRacePilotA.BackColor = Color.Gray;
            }

            if (CurrentRace.PilotB != null)
            {
                fldRacePilotB.Text =
                    CurrentRace.PilotB.ID + " " +
                    CurrentRace.PilotB.LastName + " " +
                    CurrentRace.PilotB.SureName;
                fldRacePilotB.BackColor = Color.FromArgb(int.Parse(CurrentRace.PilotB.PilotColor));
            }
            else
            {
                fldRacePilotB.Text = "";
                fldRacePilotB.BackColor = Color.Gray;
            }

            if (CurrentRace.PilotC != null)
            {
                fldRacePilotC.Text =
                    CurrentRace.PilotC.ID + " " +
                    CurrentRace.PilotC.LastName + " " +
                    CurrentRace.PilotC.SureName;
                fldRacePilotC.BackColor = Color.FromArgb(int.Parse(CurrentRace.PilotC.PilotColor));
            }
            else
            {
                fldRacePilotC.Text = "";
                fldRacePilotC.BackColor = Color.Gray;
            }

            if (CurrentRace.PilotD != null)
            {
                fldRacePilotD.Text =
                    CurrentRace.PilotD.ID + " " +
                    CurrentRace.PilotD.LastName + " " +
                    CurrentRace.PilotD.SureName;
                fldRacePilotD.BackColor = Color.FromArgb(int.Parse(CurrentRace.PilotD.PilotColor));
            }
            else
            {
                fldRacePilotD.Text = "";
                fldRacePilotD.BackColor = Color.Gray;
            }

            #endregion 
            fldRaceDuration.Value = CurrentRace.Duration;
            fldRaceDate.Value = CurrentRace.StartTime;
            fldRaceTime.Value = CurrentRace.StartTime;
            fldRacePolygonsLoaded.Text = CurrentRace.Polygons.Polygons.Count.ToString();
            fldRaceParcour.Text = CurrentRace.Polygons.Name;
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
                InformationPool.Client.AddPilot(int.Parse(PE.ID),TrackerId, PE.LastName, PE.SureName, PE.PilotColor);
            }
            LoadTrackerList();
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
                fldRaceDate.Value.Year,
                fldRaceDate.Value.Month,
                fldRaceDate.Value.Day,
                CurrentRace.StartTime.Hour,
                CurrentRace.StartTime.Minute,
                CurrentRace.StartTime.Second);
            SyncRace();
        }
        private void btnSaveRace_Click(object sender, EventArgs e)
        {
            t_Race r = new t_Race();
            r.Name = CurrentRace.Name;
            if (CurrentRace.PilotA != null)
            {
                r.t_Pilot = new t_Pilot();
                r.t_Pilot.ID = int.Parse(CurrentRace.PilotA.ID);
            }
            if (CurrentRace.PilotB != null)
            {
                r.t_Pilot1 = new t_Pilot();
                r.t_Pilot1.ID = int.Parse(CurrentRace.PilotB.ID);
            }
            if (CurrentRace.PilotC != null)
            {
                r.t_Pilot2 = new t_Pilot();
                r.t_Pilot2.ID = int.Parse(CurrentRace.PilotC.ID);
            }
            if (CurrentRace.PilotD != null)
            {
                r.t_Pilot3 = new t_Pilot();
                r.t_Pilot3.ID = int.Parse(CurrentRace.PilotD.ID);
            }
            r.ID_PolygonGroup = CurrentRace.Polygons.ID;
            r.t_PolygonGroup = new t_PolygonGroup();
            r.t_PolygonGroup.Name = CurrentRace.Polygons.Name;
            r.t_PolygonGroup.t_Polygons = new List<t_Polygon>();
            foreach (Polygon p in CurrentRace.Polygons.Polygons)
            {
                t_Polygon poly = new t_Polygon();
                poly.t_PolygonPoints = new List<t_PolygonPoint>();
                foreach (PolygonPoint pp in p.Points)
                {
                    t_PolygonPoint temp_poly_point = new t_PolygonPoint();
                    temp_poly_point.altitude = pp.Altitude;
                    temp_poly_point.latitude = pp.Latitude;
                    temp_poly_point.longitude = pp.Longitude;
                    poly.t_PolygonPoints.Add(temp_poly_point);
                }
                r.t_PolygonGroup.t_Polygons.Add(poly);
            }
            r.t_PolygonGroup.ID = CurrentRace.Polygons.ID;
            r.TimeStart = CurrentRace.StartTime;
            r.TimeEnd = CurrentRace.StartTime.Add(new TimeSpan(0,(int)CurrentRace.Duration,0));
            InformationPool.Client.AddRace(r);
            LoadRaces();
            CurrentRace = new RaceEntry();
            SyncRace();
        }
        private void btnSelectParcour_Click(object sender, EventArgs e)
        {
            Parcours P = new Parcours();
            P.OnParcourOk += new EventHandler(P_OnParcourOk);
            P.Show();
        }
        void P_OnParcourOk(object sender, EventArgs e)
        {
            PolygonGroup G = (PolygonGroup)sender;
            CurrentRace.Polygons = G;
            SyncRace();
        }
        #endregion

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            InformationPool.StartVisualisation();
            InformationPool.GuiLoaded += new EventHandler(InformationPool_GuiLoaded);
        }

        void InformationPool_GuiLoaded(object sender, EventArgs e)
        {
            InformationPool.manager.DataUpdated += new EventHandler(manager_DataUpdated);
        }

        void manager_DataUpdated(object sender, EventArgs e)
        {
            RefreshTimeline();
        }
        private void btnShowRanking_Click(object sender, EventArgs e)
        {
            if (lstRace.SelectedItems.Count == 1)
            {
                InformationPool.ShowRanking(CurrentRace);
            }
        }

        public void RefreshTimeline()
        {
            try
            {
                VisualScrollBar.Invoke(new MethodInvoker(UpdateScrollbar));
                if (InformationPool.DatenListe.Count > 1)
                {
                    try
                    {
                        InformationPool.CurrentEnd = InformationPool.DatenListe[VisualScrollBar.Value - 1].Timestamp;
                        InformationPool.CurrentStart = InformationPool.DatenListe[0].Timestamp;
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void UpdateScrollbar()
        {
            VisualScrollBar.Maximum = InformationPool.DatenListe.Count;
            if (VisualChkBoxAlwaysNewest.Checked)
            {
                VisualScrollBar.Value = VisualScrollBar.Maximum;
            }
        }

        private void CheckPilotListChecked()
        {
            InformationPool.PilotsToBeDrawn.Clear();
            foreach (Object o in lstVisualPilotsToShow.CheckedItems)
            {
                PilotLst pl = (PilotLst)o;
                PilotEntry p = new PilotEntry();
                p.ID_Tracker = pl.p.ID_Tracker;
                p.ID = pl.p.ID.ToString();
                p.PilotColor = pl.p.Color;
                InformationPool.PilotsToBeDrawn.Add(p);
            }
        }
        private void CheckRacecListChecked()
        {
            InformationPool.PolygonGroupToDraw = new PolygonGroup();
            InformationPool.PolygonGroupToDraw.ID = 0;

            foreach (Object o in lstVisualRacesToShow.CheckedItems)
            {
                RaceLst rl = (RaceLst)o;
                if (InformationPool.PolygonGroupToDraw.ID == 0)
                {
                    InformationPool.PolygonGroupToDraw = rl.re.Polygons;
                }
                else if (InformationPool.PolygonGroupToDraw.ID == rl.re.Polygons.ID)
                {
                    InformationPool.PolygonGroupToDraw = rl.re.Polygons;
                }
                else
                {
                    InformationPool.PolygonGroupToDraw = new PolygonGroup();
                    InformationPool.PolygonGroupToDraw.ID = 0;
                    LoadRaces();
                    break;
                }
            }
            panelStarterPanel.Enabled = false;
            panelTrackerPilot.Enabled = false;
            panelRace.Enabled = false;
            if (InformationPool.PolygonGroupToDraw.ID > 0)
            {
                Thread t = new Thread(new ThreadStart(GetPolygonsFromServer));
                t.Start();
            }
            CheckEnabled();
        }

        private static void GetPolygonsFromServer()
        {
            List<t_Polygon> pg = InformationPool.Client.GetPolygonsByGroup(InformationPool.PolygonGroupToDraw.ID);
            foreach (t_Polygon p in pg)
            {
                List<t_PolygonPoint> ppl = InformationPool.Client.GetPolygonPoints(p.ID);
                Polygon TmpPolygon = new Polygon();
                TmpPolygon.ID = p.ID;
                TmpPolygon.Type = (PolygonType)p.Type;
                #region Polygon Points
                TmpPolygon.Points = new List<PolygonPoint>();
                foreach (t_PolygonPoint pgp in ppl)
                {
                    PolygonPoint pgpp = new PolygonPoint();
                    pgpp.Altitude = pgp.altitude;
                    pgpp.Longitude = pgp.longitude;
                    pgpp.Latitude = pgp.latitude;
                    pgpp.ID = pgp.ID;
                    TmpPolygon.Points.Add(pgpp);
                }
                #endregion
                InformationPool.PolygonGroupToDraw.Polygons.Add(TmpPolygon);
            }
        }

        private void fldVisualPlaySpeed_ValueChanged(object sender, EventArgs e)
        {
            InformationPool.PlaySpeed = (int)fldVisualPlaySpeed.Value;
        }
        private void lstVisualRacesToShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckRacecListChecked();
        }
        private void lstVisualPilotsToShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckPilotListChecked();
        }

        private void VisualScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            VisualChkBoxAlwaysNewest.Checked = false;
        }

        private void VisualChkBoxAlwaysNewest_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnVisualGetDelay_Click(object sender, EventArgs e)
        {
            fldVisualDelay.Items.Clear();
            List<DateTime> tmp = InformationPool.Client.GetTimestamps();
            foreach (DateTime t in tmp)
            {
                fldVisualDelay.Items.Add(t);
            }
        }

        private void btnVisualApplyDelay_Click(object sender, EventArgs e)
        {
            InformationPool.DatenListe.Clear();
            if (fldVisualDelay.SelectedItem != null)
            {
                DateTime tmp = (DateTime)fldVisualDelay.SelectedItem;
                InformationPool.Newest = tmp;
                InformationPool.Next = tmp;
                InformationPool.Oldest = tmp;
                
            }
        }

        private void fldVisualLineWidth_ValueChanged(object sender, EventArgs e)
        {
            InformationPool.LineWidth = (int)fldVisualLineWidth.Value;
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            Developper d = new Developper();
            d.UseWaitCursor = false;
            d.lblConnect.Visible = false;
            d.Cursor = System.Windows.Forms.Cursors.Hand;
            d.Show();
        }
    }
}
