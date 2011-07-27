using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnrlInterfaces;
using System.IO;
using AirNavigationRaceLive.Components.Model;
using AirNavigationRaceLive.Components.Helper;

namespace AirNavigationRaceLive.Components
{
    public partial class ParcourGen : UserControl
    {        
        private AnrlInterfaces.IAnrlClient Client;
        Converter c = null;
        private Parcour activeParcour;
        private Line activeLine;
        private ActivePoint ap = ActivePoint.NONE;
        private Line selectedLine = null;
        private Line hoverLine = null;

        private enum ActivePoint
        {
            A,B,O,NONE
        }

        public ParcourGen(AnrlInterfaces.IAnrlClient iClient)
        {
            Client = iClient;
            InitializeComponent();
            pictureBox1.Cursor = new Cursor(@"Resources\GPSCursor.cur");
            activeParcour = new Parcour();
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
            List<IMap> maps = Client.getMaps();
            foreach (IMap m in maps)
            {
                comboBoxMaps.Items.Add(new ListItem(m));
            }
        }

        class ListItem
        {
            private IMap map;
            public ListItem(IMap imap)
            {
                map = imap;
            }

            public override String ToString()
            {
                return map.Name;
            }
            public IMap getMap()
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
                                GPSPoint a = new GPSPoint(longitude, latitude, 0);
                                GPSPoint b = new GPSPoint(a.Longitude, a.Latitude, a.Altitude);
                                GPSPoint o = new GPSPoint(a.Longitude, a.Latitude, a.Altitude);
                                activeLine.PointA = a;
                                activeLine.PointB = b;
                                activeLine.PointOrientation = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.B:
                            {
                                GPSPoint b = new GPSPoint(longitude, latitude, 0);
                                GPSPoint o = new GPSPoint(b.Longitude, b.Latitude, b.Altitude);
                                activeLine.PointB = b;
                                activeLine.PointOrientation = o;
                                pictureBox1.Invalidate();
                                break;
                            }
                        case ActivePoint.O:
                            {
                                GPSPoint o = new GPSPoint(longitude, latitude, 0);
                                activeLine.PointOrientation = o;
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
                        if (VectorUtil.getDistance(VectorUtil.getLot(new Vector(startX, startY, 0), new Vector(endX, endY, 0), mousePos)) < 3 ||
                            VectorUtil.getDistance(VectorUtil.getLot(new Vector(midX, midY, 0), new Vector(orientationX, orientationY, 0), mousePos)) < 3)
                        {
                            SetHoverLine(l);
                            lineSet = true;
                            break;
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
                    numLatA.Value = (decimal)l.PointA.Latitude;
                    numLatB.Value = (decimal)l.PointB.Latitude;
                    numLatO.Value = (decimal)l.PointOrientation.Latitude;
                    numLongA.Value = (decimal)l.PointA.Longitude;
                    numLongB.Value = (decimal)l.PointB.Longitude;
                    numLongO.Value = (decimal)l.PointOrientation.Longitude;
                    fldLineTyp.Text = l.LineType.ToString();
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
                        numLatA.Value = (decimal)l.PointA.Latitude;
                        numLatB.Value = (decimal)l.PointB.Latitude;
                        numLatO.Value = (decimal)l.PointOrientation.Latitude;
                        numLongA.Value = (decimal)l.PointA.Longitude;
                        numLongB.Value = (decimal)l.PointB.Longitude;
                        numLongO.Value = (decimal)l.PointOrientation.Longitude;
                        fldLineTyp.Text = l.LineType.ToString();
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
                MemoryStream ms = new MemoryStream(li.getMap().Picture.Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(li.getMap());
                pictureBox1.SetConverter(c);
            }
        }
        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            double lenght = Decimal.ToDouble(parcourLength.Value);
            double channel = Decimal.ToDouble(channelWide.Value);
            double zoneSize = Decimal.ToDouble(penaltyZoneSize.Value);
            ParcourGenerator.GenerateParcour(activeParcour, c, lenght,channel,zoneSize);
            pictureBox1.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        #region add Lines
        private void btnAddStartLine_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.LineType == LineType.START))
            {
                activeLine = activeParcour.Lines.Single(p => p.LineType == LineType.START) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.LineType = LineType.START;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddEnd_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.LineType == LineType.END))
            {
                activeLine = activeParcour.Lines.Single(p => p.LineType == LineType.END) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.LineType = LineType.END;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;
        }
        private void btnAddLineOfNoReturn_Click(object sender, EventArgs e)
        {
            SetSelectedLine(null);
            if (activeParcour.Lines.Exists(p => p.LineType == LineType.LINEOFNORETURN))
            {
                activeLine = activeParcour.Lines.Single(p => p.LineType == LineType.LINEOFNORETURN) as Line;
            }
            else
            {
                activeLine = new Line();
                activeLine.LineType = LineType.LINEOFNORETURN;
                activeParcour.Lines.Add(activeLine);
            }
            ap = ActivePoint.A;

        }
        #endregion
        private void pictureBox1_Click(object sender, EventArgs e)
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
            activeParcour = new Parcour();
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
                (selectedLine.PointA as GPSPoint).Latitude = Decimal.ToDouble(numLatA.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLongA_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.PointA as GPSPoint).Longitude = Decimal.ToDouble(numLongA.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLatB_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.PointB as GPSPoint).Latitude = Decimal.ToDouble(numLatB.Value);
                pictureBox1.Invalidate();
            }
        }

        private void numLongB_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.PointB as GPSPoint).Longitude = Decimal.ToDouble(numLongB.Value);
                pictureBox1.Invalidate();
            }

        }

        private void numLatO_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.PointOrientation as GPSPoint).Latitude = Decimal.ToDouble(numLatO.Value);
                pictureBox1.Invalidate();
            }

        }

        private void numLongO_ValueChanged(object sender, EventArgs e)
        {
            if (selectedLine != null)
            {
                (selectedLine.PointOrientation as GPSPoint).Longitude = Decimal.ToDouble(numLongO.Value);
                pictureBox1.Invalidate();
            }

        }
        #endregion
    }
}
