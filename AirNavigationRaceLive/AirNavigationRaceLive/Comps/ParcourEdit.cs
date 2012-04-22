using System;
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
        private readonly List<Point> connectedPoints = new List<Point>();
        private Point hoverPoint = null;
        private Point selectedPoint = null;
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
            comboBoxPoint.Items.Clear();
            foreach (int i in new int[]{3,4,5,6,7,8,9,10,14})
            {
                comboBoxPoint.Items.Add((LineType)i);
            }
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
                    if (dragPoint == null)
                    {
                        dragPoint = hoverPoint;
                    }
                    double newLatitude = c.YtoLatitude(e.Y);
                    double newLongitude = c.XtoLongitude(e.X);
                    double oldLat = dragPoint.latitude;
                    double oldLong = dragPoint.longitude;
                    dragPoint.latitude = newLatitude;
                    dragPoint.longitude = newLongitude;
                    dragPoint.edited = true;
                    foreach (Point p in gluePoints)
                    {
                        p.latitude = newLatitude;
                        p.longitude = newLongitude;
                        p.edited = true;
                    }
                    if (checkBoxConnected.Checked)
                    {
                        foreach (Point p in connectedPoints)
                        {
                            if (p != dragPoint)
                            {
                                p.latitude = dragPoint.latitude + (p.latitude - oldLat);
                                p.longitude = dragPoint.longitude + (p.longitude - oldLong);
                                p.edited = true;
                            }
                        }
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
                                connectedPoints.Clear();
                                connectedPoints.AddRange(findConnectedPoints(activeParcour.LineList, l.A, l));
                                pointSet = true;
                                pictureBox1.Cursor = move;
                                break;
                            }
                            else if (Vector.Abs(mousePos - new Vector(endX, endY, 0)) < 3)
                            {
                                SetHoverPoint(l.B, l);
                                gluePoints.Clear();
                                gluePoints.AddRange(findGluePoints(activeParcour.LineList, l.B));
                                connectedPoints.Clear();
                                connectedPoints.AddRange(findConnectedPoints(activeParcour.LineList, l.B, l));
                                pointSet = true;
                                pictureBox1.Cursor = move;
                                break;

                            }
                            else if (Vector.Abs(mousePos - new Vector(orientationX, orientationY, 0)) < 3)
                            {
                                SetHoverPoint(l.O, l);
                                gluePoints.Clear();
                                gluePoints.AddRange(findGluePoints(activeParcour.LineList, l.O));
                                connectedPoints.Clear();
                                connectedPoints.AddRange(findConnectedPoints(activeParcour.LineList, l.O, l));
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
        private List<Point> findConnectedPoints(List<Line> linelist, Point original, Line originalLine)
        {
            List<Point> result = new List<Point>();
            foreach (Line l in linelist)
            {
                if (l.Type >= 3 && l.Type <= 10 && (l.A == original || l.B == original || l.O == original))
                {
                    result.Add(l.A);
                    result.Add(l.B);
                    result.Add(l.O);
                }
                else if (l.Type == (int)NetworkObjects.LineType.Point && originalLine.Type >= 3 && originalLine.Type <= 6)
                {
                    Vector mid = Vector.Middle(new Vector(originalLine.A.longitude, originalLine.A.latitude, originalLine.A.altitude), new Vector(originalLine.B.longitude, originalLine.B.latitude, originalLine.B.altitude));
                    if (Vector.Abs(mid - new Vector(l.A.longitude, l.A.latitude, l.A.altitude)) < 0.01)
                    {
                        result.Add(l.A);
                        result.Add(l.B);
                        result.Add(l.O);
                        result.AddRange(findGluePoints(linelist, l.O));
                    }
                }
            }
            return result;
        }
        private bool samePos(Point a, Point b)
        {
            return Vector.Abs(new Vector(a.longitude, a.latitude, a.altitude) - new Vector(b.longitude, b.latitude, b.altitude)) == 0;
        }
        private void SetHoverPoint(Point p, Line l)
        {
            bool change = hoverPoint != p;
            if (change)
            {
                hoverPoint = p;
                pictureBox1.SetHoverLine(l);
                pictureBox1.Invalidate();
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
                p.LineList.RemoveAll(pp => pp.Type == (int)LineType.START || pp.Type == (int)LineType.END);
                activeParcour = new Model.Parcour(p);
                pictureBox1.SetParcour(activeParcour);
                bool generatedParcour = activeParcour.LineList.Count(pp => pp.Type == (int)LineType.Point) > 0;
                btnRecalc.Enabled = generatedParcour;
                chkAutocalc.Enabled = generatedParcour;
                chkAutocalc.Checked = generatedParcour;
            }
        }

        private void btnRecalc_Click(object sender, EventArgs e)
        {
            if (btnRecalc.Enabled)
            {
                btnRecalc.Enabled = false;
                try
                {
                    double channel = Decimal.ToDouble(channelWide.Value);
                    t = new Timer();
                    t.Tick += new EventHandler(t_Tick);
                    t.Interval = 100;
                    t.Start();
                    pc = new ParcourGenerator();
                    lock (activeParcour)
                    {
                        pc.RecalcParcour(activeParcour, c, channel);
                    }
                    pictureBox1.Invalidate();
                }
                catch (Exception ex)
                {
                    btnRecalc.Enabled = true;
                    MessageBox.Show(ex.Message, "Error while generating Parcour");
                }
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
            if (selectedPoint != null)
            {
                selectedPoint.latitude = Decimal.ToDouble(numLatA.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLongA_ValueChanged(object sender, EventArgs e)
        {
            if (selectedPoint != null)
            {
                selectedPoint.longitude = Decimal.ToDouble(numLongA.Value);
                pictureBox1.Invalidate();
            }
        }
        #endregion

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            if (activeParcour != null && hoverPoint != null)
            {
                foreach (Line l in activeParcour.LineList)
                {
                    if (l.Type <= 10 && l.Type >= 3 && (l.O == hoverPoint || l.A == hoverPoint || l.B == hoverPoint))
                    {
                        comboBoxPoint.SelectedItem = (LineType)l.Type;
                    }
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            if (chkAutocalc.Checked)
            {
                btnRecalc_Click(null, null);
            }
            pictureBox1_MouseMove(pictureBox1, e);
            if (hoverPoint != null)
            {
                selectedPoint = hoverPoint;
                numLatA.Value = (decimal)selectedPoint.latitude;
                numLongA.Value = (decimal)selectedPoint.longitude;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            drag = false;
        }

        private void channelWide_ValueChanged(object sender, EventArgs e)
        {
            btnRecalc_Click(null, null);
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (activeParcour != null && comboBoxPoint.SelectedItem != null)
            {
                if (activeParcour.LineList.Count(p => p.Type == (int)comboBoxPoint.SelectedItem) == 1)
                {
                    Line l = activeParcour.LineList.First(p => p.Type == (int)comboBoxPoint.SelectedItem);
                    Vector a = new Vector(l.A.longitude, l.A.latitude, 0);
                    Vector b = new Vector(l.B.longitude, l.B.latitude, 0);
                    Vector m = Vector.Middle(a, b);
                    Vector neu = new Vector((double)manualPointLongitude.Value, (double)manualPointLatitude.Value, 0);
                    Vector diff = neu-m;
                    l.A.longitude += diff.X;
                    l.A.latitude += diff.Y;
                    l.O.longitude += diff.X;
                    l.O.latitude += diff.Y;
                    l.B.longitude += diff.X;
                    l.B.latitude += diff.Y;
                    List<Point> connectedPoints = findConnectedPoints(activeParcour.LineList, l.A, l);
                    foreach (Point p in connectedPoints)
                    {
                        if (p != l.A && p != l.B && p != l.O)
                        {
                            p.longitude += diff.X;
                            p.latitude += diff.Y;
                        }
                    }
                    pictureBox1.Invalidate();
                }
            }
        }

        private void comboBoxPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (activeParcour != null && comboBoxPoint.SelectedItem != null)
            {
                if (activeParcour.LineList.Count(p => p.Type == (int)comboBoxPoint.SelectedItem) == 1)
                {
                    Line l = activeParcour.LineList.First(p => p.Type == (int)comboBoxPoint.SelectedItem);
                    Vector a = new Vector(l.A.longitude, l.A.latitude, 0);
                    Vector b = new Vector(l.B.longitude, l.B.latitude, 0);
                    Vector m = Vector.Middle(a, b);
                    manualPointLatitude.Value = (decimal)m.Y;
                    manualPointLongitude.Value = (decimal)m.X;
                }
                else
                {
                    manualPointLatitude.Value = 0;
                    manualPointLongitude.Value = 0;
                }
            }
        }
    }
}
