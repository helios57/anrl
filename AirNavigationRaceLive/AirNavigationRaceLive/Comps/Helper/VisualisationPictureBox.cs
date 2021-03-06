﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AirNavigationRaceLive.Comps.Helper;
using AirNavigationRaceLive.Comps.Model;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public class VisualisationPictureBox : PictureBox
    {
        private Parcour Parcour;
        private Converter c;
        private List<Flight> flights;
        private System.Drawing.Pen Pen = new Pen(new SolidBrush(Color.Red), 2f);
        private System.Drawing.Pen PenHover = new Pen(new SolidBrush(Color.White), 4f);
        private System.Drawing.Pen PenSelected = new Pen(new SolidBrush(Color.Blue), 6f);
        private SolidBrush Brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
        public void SetParcour(Parcour iParcour)
        {
            Parcour = iParcour;
            Brush = new SolidBrush(Color.FromArgb((255*iParcour.Alpha)/100, 255, 0, 0));
        }
        public void SetConverter(Converter iConverter)
        {
            c = iConverter;
        }
        public void SetData(List<Flight> flights)
        {
            this.flights = flights;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            PaintParcourAndData(pe, true);
        }

        private void PaintParcourAndData(PaintEventArgs pe, bool rescale)
        {
            if (Image == null)
            {
                return;
            }
            float lineThickness = 2f;
            if (pe != null && pe.ClipRectangle.Bottom == -4)
            {
                lineThickness = 7f;
            }
            Pen.Width = lineThickness;
            #region parcour
            if (Parcour != null && c != null)
            {
                int y0 = 0;
                int x0 = 0;
                double factor = 1;
                if (rescale)
                {
                    double widthFactor = (double)Width / Image.Width;
                    double heightFactor = (double)Height / Image.Height;
                    factor = Math.Min(widthFactor, heightFactor);
                    double factorDiff = Math.Abs(widthFactor - heightFactor);

                    if (widthFactor < heightFactor)
                    {
                        y0 = (int)((Height - (Image.Height * factor)) / 2);
                    }
                    else
                    {
                        x0 = (int)((Width - (Image.Width * factor)) / 2);
                    }
                }
                lock (Parcour)
                {
                    ICollection<Line> lines = Parcour.Line;
                    List<Line> linespenalty = lines.Where(p => p.Type == (int)LineType.PENALTYZONE).ToList();
                    foreach (Line l in linespenalty)
                    {
                        int startXp = x0 + (int)(c.getStartX(l) * factor);
                        int startYp = y0 + (int)(c.getStartY(l) * factor);
                        int endXp = x0 + (int)(c.getEndX(l) * factor);
                        int endYp = y0 + (int)(c.getEndY(l) * factor);
                        int orientationXp = x0 + (int)(c.getOrientationX(l) * factor);
                        int orientationYp = y0 + (int)(c.getOrientationY(l) * factor);
                        try
                        {
                            pe.Graphics.FillPolygon(Brush, new System.Drawing.Point[] { new System.Drawing.Point(startXp, startYp), new System.Drawing.Point(endXp, endYp), new System.Drawing.Point(orientationXp, orientationYp) });
                        }
                        catch
                        {
                            //TODO
                        }
                    }
                    foreach (Line l in lines)
                    {
                        if (l.A != null && l.B != null & l.O != null)
                        {
                            int startX = x0 + (int)(c.getStartX(l) * factor);
                            int startY = y0 + (int)(c.getStartY(l) * factor);
                            int endX = x0 + (int)(c.getEndX(l) * factor);
                            int endY = y0 + (int)(c.getEndY(l) * factor);
                            int orientationX = x0 + (int)(c.getOrientationX(l) * factor);
                            int orientationY = y0 + (int)(c.getOrientationY(l) * factor);

                            int midX = startX + (endX - startX) / 2;
                            int midY = startY + (endY - startY) / 2;
                            Vector start = new Vector(startX, startY, 0);
                            Vector midv = new Vector(midX, midY, 0);
                            float radius = (float)Vector.Abs(midv - start);
                            try
                            {
                                if (l.Type != (int)LineType.PENALTYZONE && l.Type != (int)LineType.Point && l.Type != (int)LineType.LINEOFNORETURN)
                                {
                                    //Start_X/End_X
                                    if (((int)l.Type) >= 3 && ((int)l.Type) <= 10)
                                    {
                                        pe.Graphics.DrawEllipse(Pen, midX - radius, midY - radius, radius * 2, radius * 2);
                                    }
                                    pe.Graphics.DrawLine(Pen, new System.Drawing.Point(startX, startY), new System.Drawing.Point(endX, endY));
                                    pe.Graphics.DrawLine(Pen, new System.Drawing.Point(midX, midY), new System.Drawing.Point(orientationX, orientationY));
                                    pe.Graphics.DrawEllipse(Pen, orientationX - 1, orientationY - 1, 2, 2);
                                }
                            }
                            catch
                            {
                                //TODO
                            }
                        }
                    }
                }
            }
            #endregion

            if (flights != null)
            {
                int y0 = 0;
                int x0 = 0;
                double factor = 1;


                if (rescale)
                {
                    double widthFactor = (double)Width / Image.Width;
                    double heightFactor = (double)Height / Image.Height;
                    factor = Math.Min(widthFactor, heightFactor);
                    double factorDiff = Math.Abs(widthFactor - heightFactor);

                    if (widthFactor < heightFactor)
                    {
                        y0 = (int)((Height - (Image.Height * factor)) / 2);
                    }
                    else
                    {
                        x0 = (int)((Width - (Image.Width * factor)) / 2);
                    }
                }

                foreach (Flight flight in flights)
                {
                    //Color Color = Color.FromName(flight.Team.Color);
                    Color Color = Color.Black;
                    List<System.Drawing.Point> points = new List<System.Drawing.Point>();
                    foreach (Point gd in flight.Point)
                    {
                        int startXp = x0 + (int)(c.LongitudeToX(gd.longitude) * factor);
                        int startYp = y0 + (int)(c.LatitudeToY(gd.latitude) * factor);
                        points.Add(new System.Drawing.Point(startXp, startYp));
                    }
                    if (points.Count > 2)
                    {
                        pe.Graphics.DrawLines(new Pen(new SolidBrush(Color), lineThickness), points.ToArray());
                    }
                }
         
            }
        }

        public System.Drawing.Image PrintOutImage { get { return GeneratePrintOut(); } }

        protected Image GeneratePrintOut()
        {
            if (Parcour != null && c != null)
            {
                Bitmap bt = new Bitmap(Image.Width, Image.Height);
                Graphics gr = Graphics.FromImage(bt);
                Rectangle rc = new Rectangle(0, 0, Image.Width, Image.Height);
                gr.DrawImage(Image, rc);
                PaintEventArgs pe = new PaintEventArgs(gr, new Rectangle(-2, -2, -2, -2));
                PaintParcourAndData(pe, false);
                return bt;
            }
            return null;
        }

        public double GetXDistanceKM()
        {
            double topLat = c.TopLeftLatitudeY;
            double leftLong = c.TopLeftLongitudeX;
            double rightLong = c.TopLeftLongitudeX + Image.Width * c.SizeLongitudeX;
            return Converter.Distance(leftLong, topLat, rightLong, topLat);
        }
        public double GetYDistanceKM()
        {
            double topLat = c.TopLeftLatitudeY;
            double leftLong = c.TopLeftLongitudeX;
            double bottomLat = c.TopLeftLatitudeY + Image.Height * c.SizeLatitudeY;
            return Converter.Distance(leftLong, topLat, leftLong, bottomLat);
        }
    }
}
