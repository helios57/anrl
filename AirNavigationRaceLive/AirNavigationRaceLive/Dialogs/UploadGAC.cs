﻿using System;
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
        private DataAccess Client;
        private Flight ct;

        public EventHandler OnFinish;
        public UploadGAC(DataAccess Client, Flight ct)
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
                List<Point4D> list = Importer.GPSdataFromGAC(dt.Year, dt.Month, dt.Day, ofd.FileName);
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
                List<Point4D> list = textBoxPositions.Tag as List<Point4D>;
                ct.Point4D.Clear();
                foreach(Point4D point in list)
                {
                    ct.Point4D.Add(point);
                }
                Client.DBContext.SaveChanges();
                GeneratePenalty.CalculateAndPersistPenaltyPoints(Client, ct);
                Close();
            }
        }
    }
}
