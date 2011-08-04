using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using AnrlInterfaces;
using AirNavigationRaceLive.Components.Helper;

namespace AirNavigationRaceLive.Components
{
    public class ParcourPictureBox : PictureBox
    {
        private IParcour Parcour;
        private Converter c;
        private ILine selectedLine;
        private ILine hoverLine;
        private System.Drawing.Pen Pen = new Pen(new SolidBrush(Color.Red), 2f);
        private System.Drawing.Pen PenHover = new Pen(new SolidBrush(Color.White), 4f);
        private System.Drawing.Pen PenSelected = new Pen(new SolidBrush(Color.Blue), 6f);
        private SolidBrush Brush = new SolidBrush(Color.FromArgb(100,255,0,0));
        public void SetParcour(IParcour iParcour)
        {
            Parcour = iParcour;
        }
        public void SetConverter(Converter iConverter)
        {
            c = iConverter;
        }
        public void SetSelectedLine(ILine iLine)
        {
            selectedLine = iLine;
        }
        public void SetHoverLine(ILine iLine)
        {
            hoverLine = iLine;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (Parcour != null && c != null)
            {
                lock (Parcour)
                {
                    List<ILine> lines = Parcour.Lines;
                    List<ILine> linespenalty = lines.Where(p => p.LineType == LineType.PENALTYZONE).ToList();
                    foreach (ILine l in linespenalty)
                    {
                        int startXp = c.getStartX(l);
                        int startYp = c.getStartY(l);
                        int endXp = c.getEndX(l);
                        int endYp = c.getEndY(l);
                        int orientationXp = c.getOrientationX(l);
                        int orientationYp = c.getOrientationY(l);
                        pe.Graphics.FillPolygon(Brush, new Point[] {new Point(startXp,startYp),new Point(endXp,endYp),new Point(orientationXp,orientationYp)});
                    }
                    foreach (ILine l in lines)
                    {
                        if (l.PointA != null && l.PointB != null & l.PointOrientation != null)
                        {
                            int startX = c.getStartX(l);
                            int startY = c.getStartY(l);
                            int endX = c.getEndX(l);
                            int endY = c.getEndY(l);
                            int midX = startX + (endX - startX) / 2;
                            int midY = startY + (endY - startY) / 2;
                            int orientationX = c.getOrientationX(l);
                            int orientationY = c.getOrientationY(l);
                            Vector start = new Vector(startX, startY, 0);
                            Vector midv = new Vector(midX, midY, 0);
                            float radius = (float)Vector.Abs(midv - start);
                            if (l.LineType != LineType.PENALTYZONE)
                            {
                                //Start_X/End_X
                                if (((int)l.LineType) >= 3 && ((int)l.LineType) <= 10)
                                {
                                    pe.Graphics.DrawEllipse(Pen, midX - radius, midY - radius, radius * 2, radius * 2);
                                }
                                if (selectedLine == l)
                                {
                                    pe.Graphics.DrawLine(PenSelected, new Point(startX, startY), new Point(endX, endY));
                                    pe.Graphics.DrawLine(PenSelected, new Point(midX, midY), new Point(orientationX, orientationY));
                                    pe.Graphics.DrawEllipse(PenSelected, orientationX - 3, orientationY - 3, 6, 6);
                                }
                                if (hoverLine == l)
                                {
                                    pe.Graphics.DrawLine(PenHover, new Point(startX, startY), new Point(endX, endY));
                                    pe.Graphics.DrawLine(PenHover, new Point(midX, midY), new Point(orientationX, orientationY));
                                    pe.Graphics.DrawEllipse(PenHover, orientationX - 2, orientationY - 2, 4, 4);
                                }
                                pe.Graphics.DrawLine(Pen, new Point(startX, startY), new Point(endX, endY));
                                pe.Graphics.DrawLine(Pen, new Point(midX, midY), new Point(orientationX, orientationY));
                                pe.Graphics.DrawEllipse(Pen, orientationX - 1, orientationY - 1, 2, 2);
                            }
                        }
                    }
                }
            }
        }
    }
}
