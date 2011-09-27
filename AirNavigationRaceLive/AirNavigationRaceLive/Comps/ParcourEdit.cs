﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AirNavigationRaceLive.Comps.Model;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class ParcourEdit : UserControl
    {
        Cursor select = new Cursor(@"Resources\GPSCursor.cur");
        Cursor move = new Cursor(@"Resources\GPSCursorModify.cur");
        private Client.Client Client;
        Converter c = null;
        private AirNavigationRaceLive.Comps.Model.Parcour activeParcour;
        private Point dragPoint = null;
        private readonly List<Point> gluePoints = new List<Point>();
        private Point hoverPoint = null;
        private Line selectedLine = null;
        ParcourGenerator pc;
        Timer t;
        private NetworkObjects.Map CurrentMap = null;
        private volatile bool drag = false;

        public ParcourEdit(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            pictureBox1.Cursor = select;
            activeParcour = new AirNavigationRaceLive.Comps.Model.Parcour();
            pictureBox1.SetParcour(activeParcour);
        }
        #region load
        private void ParcourGen_Load(object sender, EventArgs e)
        {
            loadMaps();
        }
        private void loadMaps()
        {
            comboBoxParcours.Items.Clear();
            List<NetworkObjects.Parcour> parcours = Client.getParcours();
            foreach (NetworkObjects.Parcour p in parcours)
            {
                comboBoxParcours.Items.Add(new ListItem(p));
            }
        }

        class ListItem
        {
            private NetworkObjects.Parcour parcour;
            public ListItem(NetworkObjects.Parcour iparcour)
            {
                parcour = iparcour;
            }

            public override String ToString()
            {
                return parcour.Name;
            }
            public NetworkObjects.Parcour getParcour()
            {
                return parcour;
            }
        }
        #endregion

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            fldCursorX.Text = e.X.ToString();
            fldCursorY.Text = e.Y.ToString();
            if (c != null)
            {
                double latitude = c.YtoLatitude(e.Y);
                double longitude = c.XtoLongitude(e.X);
                fldLatitude.Text = latitude.ToString();
                fldLongitude.Text = longitude.ToString();
                if (drag && (hoverPoint != null || dragPoint != null))
                {
                    if (dragPoint == null )
                    {
                        dragPoint = hoverPoint;
                    }
                    double newLatitude = c.YtoLatitude(e.Y);
                    double newLongitude = c.XtoLongitude(e.X);
                    dragPoint.latitude = newLatitude;
                    dragPoint.longitude = newLongitude;
                    dragPoint.edited = true;
                    foreach (Point p in gluePoints)
                    {
                        p.latitude = newLatitude;
                        p.longitude = newLongitude;
                        p.edited = true;
                    }
                    pictureBox1.Invalidate();
                }
                else
                {
                    dragPoint = null;
                    bool pointSet = false;
                    lock (activeParcour)
                    {
                        foreach (Line l in activeParcour.LineList)
                        {
                            int startX = c.getStartX(l);
                            int startY = c.getStartY(l);
                            int endX = c.getEndX(l);
                            int endY = c.getEndY(l);
                            int midX = startX + (endX - startX) / 2;
                            int midY = startY + (endY - startY) / 2;
                            int orientationX = c.getOrientationX(l);
                            int orientationY = c.getOrientationY(l);
                            Vector mousePos = new Vector(e.X, e.Y, 0);
                            if (Vector.Abs(mousePos - new Vector(startX, startY, 0)) < 3)
                            {
                                SetHoverPoint(l.A, l);
                                gluePoints.Clear();
                                gluePoints.AddRange(findGluePoints(activeParcour.LineList, l.A));
                                pointSet = true;
                                pictureBox1.Cursor = move;
                                break;
                            }
                            else if (Vector.Abs(mousePos - new Vector(endX, endY, 0)) < 3)
                            {
                                SetHoverPoint(l.B, l);
                                gluePoints.Clear();
                                gluePoints.AddRange(findGluePoints(activeParcour.LineList, l.B));
                                pointSet = true;
                                pictureBox1.Cursor = move;
                                break;

                            }
                            else if (Vector.Abs(mousePos - new Vector(orientationX, orientationY, 0)) < 3)
                            {
                                SetHoverPoint(l.O, l);
                                gluePoints.Clear();
                                gluePoints.AddRange(findGluePoints(activeParcour.LineList, l.O));
                                pointSet = true;
                                pictureBox1.Cursor = move;
                                break;
                            }
                        }

                    }
                    if (!pointSet)
                    {
                        SetHoverPoint(null, null);
                        pictureBox1.Cursor = select;
                    }
                }
            }
        }
        private List<Point> findGluePoints(List<Line> linelist, Point original)
        {
            List<Point> result = new List<Point>();
            foreach (Line l in linelist)
            {
                if (samePos(l.A, original) && !(original == l.A))
                {
                    result.Add(l.A);
                } 
                if (samePos(l.B, original) && !(original == l.B))
                {
                    result.Add(l.B);
                } 
                if (samePos(l.O, original) && !(original == l.O))
                {
                    result.Add(l.O);
                }
            }
            return result;
        }
        private bool samePos(Point a, Point b)
        {
            return Vector.Abs(new Vector(a.longitude, a.latitude, a.altitude) - new Vector(b.longitude, b.latitude, b.altitude)) ==0;
        }
        private void SetHoverPoint(Point p, Line l)
        {
            bool change = hoverPoint != p;
            if (change)
            {
                selectedLine = l;
                hoverPoint = p;
                pictureBox1.SetHoverLine(l);
                pictureBox1.Invalidate();
                if (hoverPoint == null)
                {
                    lineBox.Enabled = l != null;
                    if (l != null)
                    {
                        numLatA.Value = (decimal)l.A.latitude;
                        numLatB.Value = (decimal)l.B.latitude;
                        numLatO.Value = (decimal)l.O.latitude;
                        numLongA.Value = (decimal)l.A.longitude;
                        numLongB.Value = (decimal)l.B.longitude;
                        numLongO.Value = (decimal)l.O.longitude;
                        fldLineTyp.Text = ((LineType)l.Type).ToString();
                    }
                    else
                    {
                        numLatA.Value = 0;
                        numLatB.Value = 0;
                        numLatO.Value = 0;
                        numLongA.Value = 0;
                        numLongB.Value = 0;
                        numLongO.Value = 0;
                        fldLineTyp.Text = "";
                    }
                }
            }
        }
        private void comboBoxParcours_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li = comboBoxParcours.SelectedItem as ListItem;
            if (li != null)
            {
                NetworkObjects.Parcour p = li.getParcour();
                NetworkObjects.Map m = Client.getMap(p.ID_Map);
                MemoryStream ms = new MemoryStream(Client.getPicture(m.ID_Picture).Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(m);
                pictureBox1.SetConverter(c);
                CurrentMap = m;
                activeParcour = new Model.Parcour(p);
                pictureBox1.SetParcour(activeParcour);
                bool generatedParcour = activeParcour.LineList.Count(pp=>pp.Type == (int)LineType.Point) > 0;
                btnRecalc.Enabled = generatedParcour;
                chkAutocalc.Enabled = generatedParcour;
                chkAutocalc.Checked = generatedParcour;
            }
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            btnRecalc.Enabled = false;
            try
            {
                double lenght = Decimal.ToDouble(parcourLength.Value);
                double channel = Decimal.ToDouble(channelWide.Value);
                t = new Timer();
                t.Tick += new EventHandler(t_Tick);
                t.Interval = 100;
                t.Start();
                pc = new ParcourGenerator();
                pc.RecalcParcour(activeParcour, c, lenght, channel);
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                btnRecalc.Enabled = true;
                MessageBox.Show(ex.Message, "Error while generating Parcour");
            }
        }

        void t_Tick(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Invalidate();
                if (pc.finished)
                {
                    t.Stop();
                    btnRecalc.Enabled = true;
                }
            }
            catch
            {
                t.Stop();
                btnRecalc.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CurrentMap == null)
            {
                MessageBox.Show("No Map selected", "Incomplete Data");
            }
            else
            {
                NetworkObjects.Parcour p = new NetworkObjects.Parcour();
                p.Name = fldName.Text;
                p.LineList.AddRange(activeParcour.LineList);
                p.ID_Map = CurrentMap.ID;
                Client.saveParcour(p);
                MessageBox.Show("Successfully saved");
            }
        }

        private void ParcourGen_VisibleChanged(object sender, EventArgs e)
        {
            loadMaps();
        }
        #region NumUpDown
        private void numLatA_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.A as Point).latitude = Decimal.ToDouble(numLatA.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLongA_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.A as Point).longitude = Decimal.ToDouble(numLongA.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLatB_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.B as Point).latitude = Decimal.ToDouble(numLatB.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLongB_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.B as Point).longitude = Decimal.ToDouble(numLongB.Value);
                pictureBox1.Invalidate();
            }

        }

        private void numLatO_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.O as Point).latitude = Decimal.ToDouble(numLatO.Value);
                pictureBox1.Invalidate();
            }

        }

        private void numLongO_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.O as Point).longitude = Decimal.ToDouble(numLongO.Value);
                pictureBox1.Invalidate();
            }

        }
        #endregion

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            if (chkAutocalc.Checked)
            {
                btnRecalc_Click(null, null);
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            drag = false;
        }


    }
}