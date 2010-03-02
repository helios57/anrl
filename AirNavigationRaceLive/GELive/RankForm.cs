using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GELive.ANRLDataService;
using System.IO;

namespace GELive
{
    public partial class RankForm : Form
    {
        List<RankingEntry> rankinEntries;
        RaceEntry Race;
        decimal lastlongitude=-1;
        decimal lastlatitude=-1;
        /// <summary>
        /// Timespan in which you can still pass starting and ending gate without penalty
        /// (hours,minutes,seconds)
        /// </summary>
        private TimeSpan spanStartEnd = new TimeSpan(0, 1, 0);
        public RankForm(RaceEntry Race)
        {
            this.Race = Race;
            InitializeComponent();
            rankinEntries = new List<RankingEntry>();
            InitializeRankingEntries();
        }

        public void InitializeRankingEntries()
        {
            foreach (PilotEntry p in InformationPool.PilotsToBeDrawn)
            {                
                RankingEntry r = new RankingEntry();
                r.LastName= p.LastName;
                r.SureName = p.SureName;
                r.TrackerID = p.ID_Tracker;
                r.Punkte =0;
                r.Color = Int32.Parse(p.PilotColor);
                bool check = false;
                foreach (RankingEntry re in rankinEntries)
                {
                    if (re.TrackerID == p.ID_Tracker)
                    {
                        check = true;
                    }
                }
                if (!check)
                {
                    rankinEntries.Add(r);
                }
            }
        }
        
        public void PopulateData()
        {
            rankinEntries.Sort(new RankingEntryComparer());
            t_Pilot pilot;

            if (rankinEntries.Count > 3)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[3].TrackerID);
                lblName4.Text = pilot.LastName;
                lblPunkte4.Text = rankinEntries[3].Punkte.ToString();
                lblName4.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag4.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null) picPilot4.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                else
                {
                    picPilot4.BackgroundImage = null;
                }
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
            if (rankinEntries.Count > 2)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[2].TrackerID);
                lblName3.Text = pilot.LastName;
                lblPunkte3.Text = rankinEntries[2].Punkte.ToString();
                lblName3.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag3.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null) picPilot3.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                else
                {
                    picPilot3.BackgroundImage = null;
                }
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
            if (rankinEntries.Count > 1)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[1].TrackerID);
                lblName2.Text = pilot.LastName;
                lblPunkte2.Text = rankinEntries[1].Punkte.ToString();
                lblName2.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag2.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null) picPilot2.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                else
                {
                    picPilot2.BackgroundImage = null;
                }
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
            if (rankinEntries.Count > 0)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[0].TrackerID);
                lblName1.Text = pilot.LastName;
                lblPunkte1.Text = rankinEntries[0].Punkte.ToString();
                lblName1.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag1.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null) picPilot1.BackgroundImage = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                else
                {
                    picPilot1.BackgroundImage = null;
                }
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }

        public void doranking(decimal longitude, decimal latitude, int trackerid, DateTime pointtime)
        {
            foreach (RankingEntry r in rankinEntries.Where(q => q.TrackerID == trackerid))
            {
                foreach (Polygon p in InformationPool.PolygonGroupToDraw.Polygons)
                {
                    if (p.Type == (int)PolygonType.PenaltyZone)
                    {
                        if (p.contains2(longitude, latitude))
                        {
                            r.Punkte += 6;
                        }
                    }
                    else if (p.Type == PolygonType.GateStartA || p.Type == PolygonType.GateStartB || p.Type == PolygonType.GateStartC || p.Type == PolygonType.GateStartD)
                    {

                        // Es wird nur innerhalb der möglichen Zeitspanne überprüft
                        if (!r.passedstartinggate && Race.StartTime + spanStartEnd >= pointtime && r.lastlatitude != -1 && r.lastlongitude != -1)
                        {
                            //ALine trackline = new ALine(new APoint(lastlongitude,lastlatitude),new APoint(longitude,latitude));
                            //ALine gateline = new ALine(new APoint(p.Points[0].Longitude,p.Points[0].Latitude),new APoint(p.Points[1].Longitude,p.Points[1].Latitude));
                            APoint gp1 = new APoint((double)p.Points[0].Longitude, (double)p.Points[0].Latitude);
                            APoint gp2 = new APoint((double)p.Points[1].Longitude, (double)p.Points[1].Latitude);
                            APoint p1 = new APoint((double)r.lastlongitude, (double)r.lastlatitude);
                            APoint p2 = new APoint((double)longitude, (double)latitude);
                            if (gatePassed(p1, p2, gp1, gp2))
                            {
                                r.Punkte += getGatePenaltyPoints("StartGate", Race.StartTime, pointtime);
                                r.passedstartinggate = true;
                            }
                        }
                        //Wird das Gate bis zur letzten Möglichkeit nicht überflogen gibt es auch strafpunkte
                        else if (!r.passedstartinggate && pointtime > Race.StartTime + spanStartEnd)
                        {
                            r.Punkte += getGatePenaltyPoints("StartGate", Race.StartTime, pointtime);
                            r.passedstartinggate = true;
                        }
                    }
                    else if (p.Type == PolygonType.GateEndA || p.Type == PolygonType.GateEndB || p.Type == PolygonType.GateEndC || p.Type == PolygonType.GateEndD)
                    {
                        if (!r.passedfinishgate && Race.StartTime.AddMinutes((double)Race.Duration) + spanStartEnd >= pointtime && r.lastlatitude != -1 && r.lastlongitude != -1)
                        {
                            //ALine trackline = new ALine(new APoint(lastlongitude,lastlatitude),new APoint(longitude,latitude));
                            //ALine gateline = new ALine(new APoint(p.Points[0].Longitude,p.Points[0].Latitude),new APoint(p.Points[1].Longitude,p.Points[1].Latitude));

                            APoint gp1 = new APoint((double)p.Points[0].Longitude, (double)p.Points[0].Latitude);
                            APoint gp2 = new APoint((double)p.Points[1].Longitude, (double)p.Points[1].Latitude);
                            APoint p1 = new APoint((double)r.lastlongitude, (double)r.lastlatitude);
                            APoint p2 = new APoint((double)longitude, (double)latitude);


                            if (gatePassed(p1, p2, gp1, gp2))
                            {
                                r.Punkte += getGatePenaltyPoints("FinishGate", Race.StartTime.AddMinutes((double)Race.Duration), pointtime);
                                r.passedfinishgate = true;
                            }
                        }
                        else if (!r.passedfinishgate && Race.StartTime.AddMinutes((double)Race.Duration) + spanStartEnd < pointtime)
                        {
                            r.Punkte += getGatePenaltyPoints("FinishGate", Race.StartTime.AddMinutes((double)Race.Duration), pointtime);
                            r.passedfinishgate = true;
                        }
                    }

                }
                r.lastlatitude = latitude;
                r.lastlongitude = longitude;
            }
                
            try
            {
                this.Invoke(new MethodInvoker(PopulateData));
            }
            catch
            { }     
        }

        private int getGatePenaltyPoints(string gatename, DateTime expected, DateTime effective)
        {
            double seconds = Math.Abs(expected.TimeOfDay.Subtract(effective.TimeOfDay).TotalSeconds);
            int points = 0;
            string message = "Passed " + gatename + " right on time";
            if (seconds > 1 && seconds * 3 < 200)
            {
                message = "Failed to pass " + gatename + " by " + seconds + " seconds. (Plan: " +
                    expected.ToString("HH:mm:ss") + ", effective: " + effective.ToString("HH:mm:ss") + ").";
                points = Convert.ToInt32((seconds - 1) * 3);
            }
            else if (seconds * 3 >= 200)
            {
                message = "Failed to pass " + gatename + " within time slot. (Maximum Penalty, Plan: " +
                    expected.ToString("HH:mm:ss") + ", effective: " + effective.ToString("HH:mm:ss") + ")."; ;
                points = 200;
            }
            return points;
        }

        public static APoint distance(APoint p1, APoint p2)
        {
            return new APoint(p2.x - p1.x, p2.y - p1.y);
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.TransparencyKey = Color.Bisque;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                Refresh();
            }
            else
            {
                this.TransparencyKey = Color.White;
                this.FormBorderStyle = FormBorderStyle.None;
                Refresh();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox2.Checked)
            {
                this.TopMost = true;
                Refresh();
            }
            else
            {
                this.TopMost = false;
                Refresh();
            }
        }

        public bool gatePassed(APoint p1, APoint p2, APoint gp1, APoint gp2)
        {
            double Ax = gp1.x;
            double Ay = gp1.y;
            double Bx = gp2.x;
            double By = gp2.y;
            double Cx = p1.x;
            double Cy = p1.y;
            double Dx = p2.x;
            double Dy = p2.y;
            //double* X, double* Y

            double distAB, theCos, theSin, newX, ABpos;

            //  Fail if either line segment is zero-length.
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy) return false;

            //  Fail if the segments share an end-point.
            if (Ax == Cx && Ay == Cy || Bx == Cx && By == Cy
                || Ax == Dx && Ay == Dy || Bx == Dx && By == Dy)
            {
                return false;
            }

            //  (1) Translate the system so that point A is on the origin.
            Bx -= Ax;
            By -= Ay;
            Cx -= Ax;
            Cy -= Ay;
            Dx -= Ax;
            Dy -= Ay;

            //  Discover the length of segment A-B.
            distAB = Math.Sqrt(Bx * Bx + By * By);

            //  (2) Rotate the system so that point B is on the positive X axis.
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = Cx * theCos + Cy * theSin;
            Cy = Cy * theCos - Cx * theSin;
            Cx = newX;
            newX = Dx * theCos + Dy * theSin;
            Dy = Dy * theCos - Dx * theSin;
            Dx = newX;

            //  Fail if segment C-D doesn't cross line A-B.
            if (Cy < 0.0 && Dy < 0.0 || Cy >= 0.0 && Dy >= 0.0)
                return false;

            //  (3) Discover the position of the intersection point along line A-B.
            ABpos = Dx + (Cx - Dx) * Dy / (Dy - Cy);

            //  Fail if segment C-D crosses line A-B outside of segment A-B.
            if (ABpos < 0.0 || ABpos > distAB)
                return false;
            else
            {
                return true;
            }
        }

    }
    public class APoint
    {
        public double x;
        public double y;
        public APoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class ALine
    {
        public APoint p1;
        public APoint p2;
        public ALine(APoint p1, APoint p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }
    public class RankingEntryComparer:  Comparer<RankingEntry>
    {
        public override int Compare(RankingEntry x, RankingEntry y)
        {
            if (x.Punkte > y.Punkte) return 1;
            if (x.Punkte < y.Punkte) return -1;
            return 0;
        }
    }
}
