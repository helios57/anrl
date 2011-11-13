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
    public partial class ParcourOverview : UserControl
    {
        private Client.Client Client;
        Converter c = null;
        private Line activeLine;
        private ActivePoint ap = ActivePoint.NONE;
        private Line selectedLine = null;
        private Line hoverLine = null;
        private NetworkObjects.Parcour activeParcour = new NetworkObjects.Parcour();

        private enum ActivePoint
        {
            A, B, O, NONE
        }

        public ParcourOverview(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            pictureBox1.Cursor = new Cursor(@"Resources\GPSCursor.cur");
        }
        #region load

        class ListItem
        {
            private NetworkObjects.Parcour parcour;
            public ListItem(NetworkObjects.Parcour iParcour)
            {
                parcour = iParcour;
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

        private void loadParcours()
        {
            deleteToolStripMenuItem.Enabled = false;
            pictureBox1.SetConverter(c);
            pictureBox1.Image = null;
            activeParcour = new NetworkObjects.Parcour();
            pictureBox1.SetParcour(activeParcour);
            SetHoverLine(null);
            SetSelectedLine(null);
            pictureBox1.Invalidate();

            listBox1.Items.Clear();
            List<NetworkObjects.Parcour> parcours = Client.getParcours();
            foreach (NetworkObjects.Parcour p in parcours)
            {
                listBox1.Items.Add(new ListItem(p));
            }
        }
        #endregion
        private void ParcourGen_VisibleChanged(object sender, EventArgs e)
        {
            loadParcours();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadParcours();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                Client.deleteParcour(li.getParcour().ID);
                loadParcours();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                deleteToolStripMenuItem.Enabled = true;
                NetworkObjects.Map map = Client.getMap(li.getParcour().ID_Map);

                MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(map);
                pictureBox1.SetConverter(c);

                pictureBox1.SetParcour(li.getParcour());
                activeParcour = li.getParcour();
                SetHoverLine(null);
                SetSelectedLine(null);
                pictureBox1.Invalidate();
            }
        }

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
                if (activeLine != null)
                {
                    pictureBox1.SetSelectedLine(null);
                    #region activeLine != null
                    switch (ap)
                    {
                        case ActivePoint.A:
                            {
                                Point a = NetworkObjects.Helper.Point(longitude, latitude, 0);
                                Point b = NetworkObjects.Helper.Point(a.longitude, a.latitude, a.altitude);
                                Point o = NetworkObjects.Helper.Point(a.longitude, a.latitude, a.altitude);
                                activeLine.A = a;
                                activeLine.B = b;
                                activeLine.O = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.B:
                            {
                                Point b = NetworkObjects.Helper.Point(longitude, latitude, 0);
                                Point o = NetworkObjects.Helper.Point(b.longitude, b.latitude, b.altitude);
                                activeLine.B = b;
                                activeLine.O = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.O:
                            {
                                Point o = NetworkObjects.Helper.Point(longitude, latitude, 0);
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

        #region add Lines
        private void btnAddStartLine_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.LineList.Exists(p => p.Type == (int)LineType.START))
            {
                activeLine = activeParcour.LineList.Single(p => p.Type == (int)LineType.START) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.START;
                activeParcour.LineList.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddEnd_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.LineList.Exists(p => p.Type == (int)LineType.END))
            {
                activeLine = activeParcour.LineList.Single(p => p.Type == (int)LineType.END) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.END;
                activeParcour.LineList.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddLineOfNoReturn_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.LineList.Exists(p => p.Type == (int)LineType.LINEOFNORETURN))
            {
                activeLine = activeParcour.LineList.Single(p => p.Type == (int)LineType.LINEOFNORETURN) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.Type = (int)LineType.LINEOFNORETURN;
                activeParcour.LineList.Add(activeLine);
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
                    case ParcourOverview.ActivePoint.A:
                        {
                            ap = ParcourOverview.ActivePoint.B;
                            break;
                        }
                    case ParcourOverview.ActivePoint.B:
                        {
                            ap = ParcourOverview.ActivePoint.O;
                            break;
                        }
                    case ParcourOverview.ActivePoint.O:
                        {
                            ap = ParcourOverview.ActivePoint.NONE;
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

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

    }
}
