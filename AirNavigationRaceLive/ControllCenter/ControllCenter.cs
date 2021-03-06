﻿using System;
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
using System.IO;

namespace ControllCenter
{
    public partial class ControllCenter : Form
    {
        GPSReciever Service_test;
        ServiceHost host;
        bool GPS_Service_running = false;
        bool Service_Host_running = false;
        public String DB_Path = "";
        DebugWindow d;

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
            f.FileOk += new CancelEventHandler(f_FileOk);
            f.ShowDialog();
        }
        void f_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog f = (OpenFileDialog)sender;
            DB_Path = f.FileName;
            StatusForm ef = new StatusForm();
            ef.label1.Text = "Bitte warte, die Datenbank wird geladen.";
            ef.Show();
            ef.Refresh();
            try
            {
                DataContext db = new DataContext(DB_Path);
                db.SubmitChanges();
                txtPfad.Text = DB_Path;
                txtPfad.Enabled = false;
                button1.Enabled = false;
                btnStartReciever.Enabled = true;
                btnStartWebservice.Enabled = true;
                RefreshTrackerList();
                ef.Close();
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:f_FileOk", "DB_Path Set");
            }
            catch (Exception ex)
            {
                ef.Close();
                MessageBox.Show("Fehler beim öffnen der DB, bitte DB überprüfen " + ex.ToString() );
            }
        }
        private void btnStartReciever_Click(object sender, EventArgs e)
        {
            try
            {
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:btnStartReciever_Click", "Start");
                Service_test = new GPSReciever(DB_Path);
                Service_test.Start();
                lblRecieverStatus.Text = "Started";
                GPS_Service_running = true;
                btnStartReciever.Enabled = false;
                Service_test.OnTrackerAddded += new EventHandler(Service_test_OnTrackerAddded);
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:btnStartReciever_Click", "Successfull");
            }
            catch (Exception ex)
            {
                LogManager.AddLog(DB_Path, 0, "ControllCenter.cs:btnStartReciever_Click", "Fehler beim starten des Reciever-Services" + ex.ToString());
                MessageBox.Show("Fehler beim starten des Reciever-Services");
            }
        }
        void Service_test_OnTrackerAddded(object sender, EventArgs e)
        {
            LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:Service_test_OnTrackerAddded", "");
            RefreshTrackerList();
        }
        private void btnStartWebservice_Click(object sender, EventArgs e)
        {
            StatusForm ef = new StatusForm();
            try
             {
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:btnStartWebservice_Click", "Start");
                ef.label1.Text = "Bitte Warten, der Webservice wird gestartet";
                ef.Show();
                ef.Refresh();
                ANRLDataService ds = new ANRLDataService(DB_Path);
                host = new ServiceHost(ds, new Uri("http://92.51.137.17:5555"));
                host.Open();
                lblStatusWebservice.Text = "Started";
                Service_Host_running = true;
                btnStartWebservice.Enabled = false;
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:btnStartWebservice_Click", "Successfull");
            }
            catch (Exception ex)
            {
                LogManager.AddLog(DB_Path, 0, "ControllCenter.cs:btnStartWebservice_Click", "Fehler beim Starten des Webservices " + ex.ToString());
                MessageBox.Show("Fehler beim Starten des Webservices "+ ex.ToString());
            }
            ef.Close();            
        }
        private void ControllCenter_FormClosing(object sender, FormClosingEventArgs e)
        {
            StatusForm ef = new StatusForm();
            try
            {
                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:ControllCenter_FormClosing", "Start");
                ef.label1.Text = "Beenden, Bitte Warten";
                ef.Show();
                ef.Refresh();
                try
                {
                    if (GPS_Service_running)
                    {
                        ef.label1.Text = "Bitte Warten, Reciever-Service wird beendet";
                        ef.Refresh();
                        Service_test.Stop();
                    }
                }
                catch { }
                try
                {
                    if (Service_Host_running)
                    {
                        ef.label1.Text = "Bitte Warten, Web-Service wird beendet";
                        ef.Refresh();
                        host.Close();
                    }
                }
                catch { }

                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:ControllCenter_FormClosing", "Successfull");
            }
            catch (Exception ex)
            {

                LogManager.AddLog(DB_Path, 0, "ControllCenter.cs:ControllCenter_FormClosing", "Error while Closing, end remaining Threads" + ex.InnerException);
                MessageBox.Show("Error while Closing, end remaining Threads" + ex.InnerException);
            }
            ef.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTrackerList();
        }
        private void RefreshTrackerList()
        {
            LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:RefreshTrackerList", "Start");
            DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
            lstTrackers.Items.Clear();
            foreach (t_Tracker t in dataContext.t_Trackers)
            {
                TrackerListEntry tle = new TrackerListEntry(t.ID, t.IMEI);
                #region Check airplanes attached ?
                //Remove GPS-Trackers if added to may Airplanes
                int Count = dataContext.t_Pilots.Count(p => p.ID_Tracker == t.ID);
                if (Count > 1)
                {
                    foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == t.ID))
                    {
                        f.ID_Tracker = 0;
                    }
                    dataContext.SubmitChanges();
                }
                else if (Count == 1)
                {
                    t_Pilot f = dataContext.t_Pilots.Single(p=>p.ID_Tracker==t.ID);
                    tle.ID_Pilot = f.ID;
                    tle.SureName = f.SureName;
                    tle.LastName = f.LastName;
                }
                #endregion
                tle.Set();
                lstTrackers.Items.Add(tle);
            }
            drpAirplane.Items.Clear();
            foreach (t_Pilot f in dataContext.t_Pilots.Where(p=>p.ID_Tracker == 0))
            {
                drpAirplane.Items.Add(new AirplaneListEntry(f));
            }
            CheckButtons();
            LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:RefreshTrackerList", "Ende");
        }
        private void CheckButtons()
        {
            bool all = false;
            bool TrackerHasAirplane = false;
            bool refresh = false;
            if (!(DB_Path == ""))
            {
                refresh = true;
                if (lstTrackers.SelectedItems.Count == 1)
                {
                    all = true;
                    if (lstTrackers.SelectedItems[0].SubItems.Count > 4)
                    {
                        TrackerHasAirplane = true;
                    }
                }
            }
            btnRefresh.Enabled = refresh;
            btnAddAirplaneToTracker.Enabled = all && !TrackerHasAirplane;
            btnAddNewAirplaneToTracker.Enabled = all &&!TrackerHasAirplane;
            drpAirplane.Enabled = all && !TrackerHasAirplane;
            txtAirplane.Enabled = all && !TrackerHasAirplane;
            txtPilot.Enabled = all && !TrackerHasAirplane;
            btnRemvAirplaneFromTracker.Enabled = all && TrackerHasAirplane;
            btnImportPenalty.Enabled = refresh;
        }
        private void btnRemvAirplaneFromTracker_Click(object sender, EventArgs e)
        {
            if (lstTrackers.SelectedItems.Count == 1)
            {
                TrackerListEntry tle = (TrackerListEntry)lstTrackers.SelectedItems[0];

                DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
                foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == tle.ID_Tracker))
                {
                    f.ID_Tracker = 0;
                }

                dataContext.SubmitChanges();
            }
            RefreshTrackerList();
        }
        private void btnAddAirplaneToTracker_Click(object sender, EventArgs e)
        {
            if (lstTrackers.SelectedItems.Count == 1 && drpAirplane.SelectedItem != null)
            {
                TrackerListEntry tle = (TrackerListEntry)lstTrackers.SelectedItems[0];
                DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
                foreach (t_Pilot f in dataContext.t_Pilots.Where(p => p.ID_Tracker == tle.ID_Tracker))
                {
                    f.ID_Tracker = 0;
                }
                t_Pilot fl = dataContext.t_Pilots.Single(p=>p.ID == ((AirplaneListEntry)drpAirplane.SelectedItem).ID);
                fl.ID_Tracker = tle.ID_Tracker;
                dataContext.SubmitChanges();
                RefreshTrackerList();
            }
        }
        private void btnAddNewAirplaneToTracker_Click(object sender, EventArgs e)
        {
            if (lstTrackers.SelectedItems.Count == 1)
            {
                DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
                t_Pilot f = new t_Pilot();
                f.ID_Tracker = ((TrackerListEntry)lstTrackers.SelectedItems[0]).ID_Tracker;
                f.LastName = txtPilot.Text;
                f.SureName = txtAirplane.Text;
                dataContext.t_Pilots.InsertOnSubmit(f);
                dataContext.SubmitChanges();
                RefreshTrackerList();
            }
        }
        private void lstTrackers_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckButtons();
        }
        private void drpAirplane_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckButtons();
        }
        private void btnImportPenalty_Click(object sender, EventArgs e)
        {
            OpenFileDialog fp = new OpenFileDialog();
            fp.Filter = "Penalty-Zonen |*.dxf";
            fp.FileOk += new CancelEventHandler(fp_FileOk);
            fp.ShowDialog();

        }
        void fp_FileOk(object sender, CancelEventArgs e)
        {

            LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:fp_FileOk", "Start");
            OpenFileDialog f = (OpenFileDialog)sender;
            String DxfFilePath = f.FileName;
            StatusForm ef = new StatusForm();
            ef.label1.Text = "Bitte warte, Penaltyzonen werden geladen.";
            ef.Show();
            ef.Refresh();
            try
            {
                ImportPenaltyZones.importFromDxf(DxfFilePath, DB_Path);
                DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
                int count = dataContext.t_Polygons.Count();
                lblPenaltyZonenLoaded.Text = count.ToString() + " Penalty Zonen geladen";
                ef.Close();

                LogManager.AddLog(DB_Path, 4, "ControllCenter.cs:fp_FileOk", "Ende");
            }
            catch (Exception ex)
            {

                LogManager.AddLog(DB_Path,0, "ControllCenter.cs:fp_FileOk:Error", ex.ToString());
                ef.Close();
                MessageBox.Show("Fehler beim laden der Penalty-Zonen");
            }
        }
        private void btnShowDebug_Click(object sender, EventArgs e)
        {
            d = new DebugWindow(this);
            d.Show();
        }

        private void btnAddFlags_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "PNG | *.png";
            of.FileOk += new CancelEventHandler(of_FileOk);
            of.Multiselect = true;
            of.ShowDialog();
        }

        void of_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog of = sender as OpenFileDialog;
            if (of != null)
            {
                DatabaseDataContext dataContext = new DatabaseDataContext(DB_Path);
                dataContext.t_Pictures.DeleteAllOnSubmit(dataContext.t_Pictures.Where(p => p.isFlag));
                dataContext.SubmitChanges();
                foreach (String s in of.FileNames)
                {
                    FileStream fs = File.OpenRead(s);
                    List<Byte> lb = new List<Byte>();
                    lb.Clear();
                    int b;
                    while ((b = fs.ReadByte()) >= 0)
                    {
                        lb.Add((Byte)b);
                    }
                    t_Picture p = new t_Picture();
                    p.isFlag = true;
                    String[] Name = s.Split(new char[]{'\\'});
                    p.Name = Name[Name.Length - 1].Split(new char[] {'.'})[0];
                    if (p.Name.Contains("flag_"))
                    {
                        p.Name = p.Name.Substring(5);
                    }
                    p.Data = new Binary(lb.ToArray());
                    fs.Close();
                    dataContext.t_Pictures.InsertOnSubmit(p);
                    dataContext.SubmitChanges();
                }
                dataContext.SubmitChanges();
            }
        }
    }
}
