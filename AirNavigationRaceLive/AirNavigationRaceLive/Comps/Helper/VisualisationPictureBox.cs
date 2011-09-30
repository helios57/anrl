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
        private NetworkObjects.Parcour Parcour;
        private Converter c;
        private List<GPSData> data;
        private List<NetworkObjects.Team> teams;
        private System.Drawing.Pen Pen = new Pen(new SolidBrush(Color.Red), 2f);
        private System.Drawing.Pen PenHover = new Pen(new SolidBrush(Color.White), 4f);
        private System.Drawing.Pen PenSelected = new Pen(new SolidBrush(Color.Blue), 6f);
        private SolidBrush Brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
        public void SetParcour(NetworkObjects.Parcour iParcour)
        {
            Parcour = iParcour;
        }
        public void SetConverter(Converter iConverter)
        {
            c = iConverter;
        }
        public void SetData(List<GPSData> data, List<NetworkObjects.Team> teams)
        {
            this.data = data;
            this.teams = teams;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            #region parcour
            if (Parcour != null && c != null)
            {
                double widthFactor = (double)Width / Image.Width;
                double heightFactor = (double)Height / Image.Height;
                double factor = Math.Min(widthFactor, heightFactor);
                double factorDiff = Math.Abs(widthFactor - heightFactor);
                int y0 = 0;
                int x0 = 0;
                if (widthFactor < heightFactor)
                {
                    y0 = (int)((Height - (Image.Height * factor)) / 2);
                }
                else
                {
                    x0 = (int)((Width - (Image.Width * factor)) / 2);
                }
                lock (Parcour)
                {
                    List<Line> lines = Parcour.LineList;
                    List<Line> linespenalty = lines.Where(p => p.Type == (int)NetworkObjects.LineType.PENALTYZONE).ToList();
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
                                if (l.Type != (int)NetworkObjects.LineType.PENALTYZONE && l.Type != (int)NetworkObjects.LineType.Point)
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

            if (data != null && teams != null && data.Count > 10 && teams.Count >=1)
            {
                double widthFactor = (double)Width / Image.Width;
                double heightFactor = (double)Height / Image.Height;
                double factor = Math.Min(widthFactor, heightFactor);
                double factorDiff = Math.Abs(widthFactor - heightFactor);
                int y0 = 0;
                int x0 = 0;
                if (widthFactor < heightFactor)
                {
                    y0 = (int)((Height - (Image.Height * factor)) / 2);
                }
                else
                {
                    x0 = (int)((Width - (Image.Width * factor)) / 2);
                }
                foreach (NetworkObjects.Team Team in teams)
                {
                    Color Color = Color.FromName(Team.Color);
                    List<System.Drawing.Point> points = new List<System.Drawing.Point>();
                    foreach (GPSData gd in data.Where(p => Team.ID_Tracker.Contains(p.trackerID)))
                    {
                        int startXp = x0 + (int)(c.LongitudeToX(gd.longitude) * factor);
                        int startYp = y0 + (int)(c.LatitudeToY(gd.latitude) * factor);
                        points.Add(new System.Drawing.Point(startXp, startYp));
                    }
                    if (points.Count > 2)
                    {
                        pe.Graphics.DrawLines(new Pen(new SolidBrush(Color), 2f), points.ToArray());
                    }
                }
            }
        }
    }
}