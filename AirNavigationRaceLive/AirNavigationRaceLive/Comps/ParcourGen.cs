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
    public partial class ParcourGen : UserControl
    {
        private Client.Client Client;
        Converter c = null;
        private AirNavigationRaceLive.Comps.Model.Parcour activeParcour;
        private Line activeLine;
        private ActivePoint ap = ActivePoint.NONE;
        private Line selectedLine = null;
        private Line hoverLine = null;
        ParcourGenerator pc; Timer t;
        private NetworkObjects.Map CurrentMap = null;

        private enum ActivePoint
        {
            A, B, O, NONE
        }

        public ParcourGen(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            pictureBox1.Cursor = new Cursor(@"Resources\GPSCursor.cur");
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
            comboBoxMaps.Items.Clear();
            List<NetworkObjects.Map> maps = Client.getMaps();
            foreach (NetworkObjects.Map m in maps)
            {
                comboBoxMaps.Items.Add(new ListItem(m));
            }
        }

        class ListItem
        {
            private NetworkObjects.Map map;
            public ListItem(NetworkObjects.Map imap)
            {
                map = imap;
            }

            public override String ToString()
            {
                return map.Name;
            }
            public NetworkObjects.Map getMap()
            {
                return map;
            }
        }
        #endregion

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            fldCursorX.Text = e.X.ToString();
            fldCursorY.Text = e.Y.ToString();
            if (c != null)
            {
                double latitude = c.YtoDeg(e.Y);
                double longitude = c.XtoDeg(e.X);
                fldLatitude.Text = latitude.ToString();
                fldLongitude.Text = longitude.ToString();
                if (activeLine != null)
                {
                    pictureBox1.SetSelectedLine(null);
                    #region activeLine != null
                    switch (ap)
                    {
                        case ActivePoint.A:
                            {
                                Point a = new Point(longitude, latitude, 0);
                                Point b = new Point(a.longitude, a.latitude, a.altitude);
                                Point o = new Point(a.longitude, a.latitude, a.altitude);
                                activeLine.A = a;
                                activeLine.B = b;
                                activeLine.O = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.B:
                            {
                                Point b = new Point(longitude, latitude, 0);
                                Point o = new Point(b.longitude, b.latitude, b.altitude);
                                activeLine.B = b;
                                activeLine.O = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.O:
                            {
                                Point o = new Point(longitude, latitude, 0);
                                activeLine.O = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.NONE:
                            {

                                break;
                            }
                    }
                    #endregion
                }
                else
                {
                    bool lineSet = false;
                    lock (activeParcour)
                    {
                        foreach (Line l in activeParcour.Lines)
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
                            if (Vector.Abs(Vector.MinDistance(new Vector(startX, startY, 0), new Vector(endX, endY, 0), mousePos)) < 3 ||
                                Vector.Abs(Vector.MinDistance(new Vector(midX, midY, 0), new Vector(orientationX, orientationY, 0), mousePos)) < 3)
                            {
                                SetHoverLine(l);
                                lineSet = true;
                                break;
                            }
                        }
                    }
                    if (!lineSet)
                    {
                        SetHoverLine(null);
                    }
                }
            }
        }
        private void SetSelectedLine(Line l)
        {
            bool change = selectedLine != l;
            if (change)
            {
                selectedLine = l;
                pictureBox1.SetSelectedLine(l);
                pictureBox1.Invalidate();
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
        private void SetHoverLine(Line l)
        {
            bool change = hoverLine != l;
            if (change)
            {
                hoverLine = l;
                pictureBox1.SetHoverLine(l);
                pictureBox1.Invalidate();
                if (selectedLine == null)
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
        private void comboBoxMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li = comboBoxMaps.SelectedItem as ListItem;
            if (li != null)
            {
                MemoryStream ms = new MemoryStream(Client.getPicture(li.getMap().ID_Picture).Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(li.getMap());
                pictureBox1.SetConverter(c);
                CurrentMap = li.getMap();
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            try
            {
                double lenght = Decimal.ToDouble(parcourLength.Value);
                double channel = Decimal.ToDouble(channelWide.Value);
                t = new Timer();
                t.Tick += new EventHandler(t_Tick);
                t.Interval = 100;
                t.Start();
                pc = new ParcourGenerator();
                pc.GenerateParcour(activeParcour, c, lenght, channel);
                pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                btnGenerate.Enabled = true;
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
                    btnGenerate.Enabled = true;
                }
            }
            catch
            {
                t.Stop();
                btnGenerate.Enabled = true;
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
                p.Lines.AddRange(activeParcour.Lines);
                p.ID_Map = CurrentMap.ID;
                Client.saveParcour(p);
                MessageBox.Show("Successfully saved");
            }
        }

        #region add Lines
        private void btnAddStartLine_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.Type == (int)LineType.START))
            {
                activeLine = activeParcour.Lines.Single(p => p.Type == (int)LineType.START) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.START;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddEnd_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.Type == (int)LineType.END))
            {
                activeLine = activeParcour.Lines.Single(p => p.Type == (int)LineType.END) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.END;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddLineOfNoReturn_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.Type == (int)LineType.LINEOFNORETURN))
            {
                activeLine = activeParcour.Lines.Single(p => p.Type == (int)LineType.LINEOFNORETURN) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.LINEOFNORETURN;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;

        }
        #endregion
        private void pictureBox1_Click(object sender, MouseEventArgs e)
        {
            if (activeLine != null)
            {
                switch (ap)
                {
                    case ParcourGen.ActivePoint.A:
                        {
                            ap = ParcourGen.ActivePoint.B;
                            break;
                        }
                    case ParcourGen.ActivePoint.B:
                        {
                            ap = ParcourGen.ActivePoint.O;
                            break;
                        }
                    case ParcourGen.ActivePoint.O:
                        {
                            ap = ParcourGen.ActivePoint.NONE;
                            activeLine = null;
                            break;
                        }
                }
            }
            else
            {
                SetSelectedLine(hoverLine);
            }
        }
        private void ParcourGen_VisibleChanged(object sender, EventArgs e)
        {
            loadMaps();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            activeParcour = new AirNavigationRaceLive.Comps.Model.Parcour();
            pictureBox1.SetParcour(activeParcour);
            SetHoverLine(null);
            SetSelectedLine(null);
            pictureBox1.Invalidate();
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

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

        }

    }
}