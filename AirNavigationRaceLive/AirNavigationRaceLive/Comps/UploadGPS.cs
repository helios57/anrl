﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;
using System.Threading;

namespace AirNavigationRaceLive.Comps
{
    public partial class UploadGPS : UserControl
    {
        private Client.Client Client;

        public UploadGPS(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void Tracker_Load(object sender, EventArgs e)
        {
            UpdateTrackerList();
        }


        private void btnTrackersRefresh_Click(object sender, EventArgs e)
        {
            UpdateTrackerList();
        }


        private void listViewTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTracker.SelectedItems.Count == 1)
            {
                TrackerEntry t = listViewTracker.SelectedItems[0] as TrackerEntry;
                textBoxID.Text = t.getTracker().ID.ToString();
                textBoxName.Text = t.getTracker().Name;
                textBoxIMEI.Text = t.getTracker().IMEI;
            }
            else
            {
                Reset();
            }
            UpdateEnablement();
        }

        private void UpdateTrackerList()
        {
            List<t_Tracker> trackers = Client.getTrackers();
            listViewTracker.Items.Clear();
            foreach (t_Tracker t in trackers)
            {
                listViewTracker.Items.Add(new TrackerEntry(t));
            }
            Reset();
        }
        public void Reset()
        {
            textBoxID.Text = "";
            textBoxID.Tag = null;
            textBoxName.Text = "";
            textBoxIMEI.Text = "";
            textBoxPositions.Text = "";
            textBoxPositions.Tag = null;
            UpdateEnablement();
        }

        public void UpdateEnablement()
        {
            bool selected = textBoxID.Tag != null;
            textBoxIMEI.ReadOnly = selected;
            textBoxName.ReadOnly = selected;
            bool newTracker = textBoxID.Text == "0";
            textBoxName.Enabled = newTracker || selected;
            textBoxIMEI.Enabled = newTracker || selected;

            bool validTracker = textBoxID.Text != "" && textBoxIMEI.Text.Length > 3 && textBoxName.Text.Length > 2;
            dateGAC.Enabled = validTracker;
            btnImportGAC.Enabled = validTracker;
            bool imported = validTracker && textBoxPositions.Tag != null;
            btnUploadData.Enabled = imported;
        }

        partial class TrackerEntry : ListViewItem
        {
            private t_Tracker Tracker;

            public TrackerEntry(t_Tracker iTracker)
                : base(new String[] { iTracker.ID.ToString().Trim(), iTracker.Name != null ? iTracker.Name.Trim() : "", iTracker.IMEI.Trim() })
            {
                Tracker = iTracker;
            }

            public t_Tracker getTracker()
            {
                return Tracker;
            }
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
                List<t_GPSPoint> list = Importer.GPSdataFromGAC(dt.Year, dt.Month, dt.Day, textBoxIMEI.Text, ofd.FileName);
                textBoxPositions.Text = list.Count.ToString();
                textBoxPositions.Tag = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error while Parsing File");
            }
            UpdateEnablement();
        }


        private void btnUploadData_Click(object sender, EventArgs e)
        {
            if (textBoxPositions.Tag != null)
            {
                List<t_GPSPoint> list = textBoxPositions.Tag as List<t_GPSPoint>;
                string trackername = textBoxName.Text;

                list[0].identifier = trackername;
                Thread thread = new Thread(new ParameterizedThreadStart(upload));
                thread.Start(list);
                //upload(list);

                MessageBox.Show("Upload Started in Background!");
            }
            Reset();
        }

        private void upload(object o)
        {
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
                Client.uploadGPSData(subList);
            }


            MessageBox.Show("Upload Finished!");
        }

        private void buttonNewTracker_Click(object sender, EventArgs e)
        {
            Reset();
            textBoxID.Text = "0";
            UpdateEnablement();
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void textBoxIMEI_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
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
                List<t_GPSPoint> list = Importer.GPSdataFromGPX(textBoxIMEI.Text, ofd.FileName);
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
