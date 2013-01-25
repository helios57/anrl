﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class MapImportFromMaps : UserControl
    {


        private Client.Client Client;
        private ToolTip Tooltip;

        public MapImportFromMaps(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            Tooltip = new ToolTip();
            Tooltip.AutomaticDelay = 0;
            Tooltip.AutoPopDelay = 0;
            Tooltip.InitialDelay = 0;
            Tooltip.ReshowDelay = 0;
            Tooltip.ShowAlways = true;
            Tooltip.UseAnimation = true;
            Tooltip.UseFading = true;
            Tooltip.IsBalloon = true;
            Tooltip.SetToolTip(fldSizeX, "pixel size in the x-direction in map units/pixel; unit is degree as the position! Example: 1.669E-4");
            Tooltip.SetToolTip(fldSizeY, "pixel size in the y-direction in map units/pixel; unit is degree as the position! Example: -9.278E-5");
            Tooltip.SetToolTip(fldRotationX, "rotation about x-axis; unit is degree as the position! Example: 0");
            Tooltip.SetToolTip(fldRotationY, "rotation about y-axis; unit is degree as the position! Example: 0");
            Tooltip.SetToolTip(fldX, "x-coordinate of the center of the upper left pixel; unit is degree! Example: 8.491");
            Tooltip.SetToolTip(fldY, "y-coordinate of the center of the upper left pixel; unit is degree! Example: 50.058");
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnSave.Enabled = false;
                fldName.Enabled = false;
                NetworkObjects.Map m = new NetworkObjects.Map();
                m.Name = fldName.Text;
                m.XSize = Double.Parse(fldSizeX.Text);
                m.YSize = Double.Parse(fldSizeY.Text);
                m.XRot = 0;
                m.YRot = 0;
                m.XTopLeft = Double.Parse(fldX.Text);
                m.YTopLeft = Double.Parse(fldY.Text);
                MemoryStream ms = new MemoryStream();
                gMapControl1.ToImage().Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Picture picture = new Picture();
                picture.Image = ms.ToArray();
                picture.Name = m.Name;
                m.ID_Picture = Client.savePicture(picture);
                Client.saveMap(m);
                MessageBox.Show("Map saved successfull!");
                btnSave.Enabled = true;
                fldName.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Saving");
            }
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            GMapOverlay overlayOne;
            gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            gMapControl1.MaxZoom = 20;
            gMapControl1.MinZoom = 3;
            gMapControl1.Zoom = 3;
            gMapControl1.Manager.Mode = AccessMode.ServerAndCache;
            overlayOne = new GMapOverlay(gMapControl1, "OverlayOne");
            gMapControl1.Overlays.Add(overlayOne);
            trackBarZoomlevel.Maximum = gMapControl1.MaxZoom;
            trackBarZoomlevel.Minimum = gMapControl1.MinZoom;
        }

        private void gMapControl1_MouseUp(object sender, MouseEventArgs e)
        {
            fldX.Text = gMapControl1.CurrentViewArea.LocationTopLeft.Lng.ToString();
            fldY.Text = gMapControl1.CurrentViewArea.LocationTopLeft.Lat.ToString();
            fldSizeY.Text = (Math.Abs(gMapControl1.CurrentViewArea.LocationRightBottom.Lat - gMapControl1.CurrentViewArea.LocationTopLeft.Lat) / gMapControl1.Size.Height).ToString();
            fldSizeX.Text = (Math.Abs(gMapControl1.CurrentViewArea.LocationRightBottom.Lng - gMapControl1.CurrentViewArea.LocationTopLeft.Lng) / gMapControl1.Size.Width).ToString();
        }

        private void fldX_TextChanged(object sender, EventArgs e)
        {
            if (!fldX.Text.Equals("") && !fldY.Text.Equals(""))
            {
                try
                {
                    gMapControl1.Position = new PointLatLng(((gMapControl1.CurrentViewArea.LocationRightBottom.Lat - gMapControl1.CurrentViewArea.LocationTopLeft.Lat) / 2) + Double.Parse(fldY.Text),
                    ((gMapControl1.CurrentViewArea.LocationRightBottom.Lng - gMapControl1.CurrentViewArea.LocationTopLeft.Lng) / 2) + Double.Parse(fldX.Text));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error while Changing position!");
                }
            }
        }




        private void gMapControl1_MouseMove(object sender, MouseEventArgs e)
        {
            textBoxZoomLevel.Text = gMapControl1.Zoom.ToString();
            trackBarZoomlevel.Value = (int)gMapControl1.Zoom;
        }

        private void trackBarZoomlevel_Scroll(object sender, EventArgs e)
        {
            gMapControl1.Zoom = trackBarZoomlevel.Value;
            if (trackBarZoomlevel.Value == 11 && fldName.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void trackBarZoomlevel_ValueChanged(object sender, EventArgs e)
        {
            trackBarZoomlevel_Scroll(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                gMapControl1.MapProvider = GMapProviders.OpenStreetMap;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                gMapControl1.MapProvider = GMapProviders.GoogleMap;
            }
        }
    }
}
