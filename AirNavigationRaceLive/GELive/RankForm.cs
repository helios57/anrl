﻿using System;
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
            Comparison<RankingEntry> compRankEntr = new Comparison<RankingEntry>(CompareRankingEntries);
            rankinEntries.Sort(compRankEntr);
            t_Pilot pilot;

            if (rankinEntries.Count > 3)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[0].TrackerID);
                lblName4.Text = pilot.LastName;
                lblPunkte4.Text = rankinEntries[0].Punkte.ToString();
                lblName4.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag4.Image = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null)
                picPilot4.Image = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                label4.Visible = true;
            }
            else
            {
                label4.Visible = false;
            }
            if (rankinEntries.Count > 2)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[1].TrackerID);
                lblName3.Text = pilot.LastName;
                lblPunkte3.Text = rankinEntries[1].Punkte.ToString();
                lblName3.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag3.Image = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null)  picPilot3.Image = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                label3.Visible = true;
            }
            else
            {
                label3.Visible = false;
            }
            if (rankinEntries.Count > 1)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[2].TrackerID);
                lblName2.Text = pilot.LastName;
                lblPunkte2.Text = rankinEntries[2].Punkte.ToString();
                lblName2.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag2.Image = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null)  picPilot2.Image = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                label2.Visible = true;
            }
            else
            {
                label2.Visible = false;
            }
            if (rankinEntries.Count > 0)
            {
                pilot = InformationPool.PilotList.Single(p => p.ID_Tracker == rankinEntries[3].TrackerID);
                lblName1.Text = pilot.LastName;
                lblPunkte1.Text = rankinEntries[3].Punkte.ToString();
                lblName1.ForeColor = Color.FromArgb(Int32.Parse(pilot.Color));
                picFlag1.Image = System.Drawing.Image.FromStream(new MemoryStream(InformationPool.Flags.Single(p => p.id == pilot.ID_Flag).Data.Bytes));
                if (pilot.Picture != null) picPilot1.Image = System.Drawing.Image.FromStream(new MemoryStream(pilot.Picture.Bytes));
                label1.Visible = true;
            }
            else
            {
                label1.Visible = false;
            }
        }



        /// <summary>
        /// Compares the ranking entries.
        /// </summary>
        /// <param name="rE1">The r e1.</param>
        /// <param name="rE2">The r e2.</param>
        /// <returns></returns>
        private static int CompareRankingEntries(RankingEntry rE1, RankingEntry rE2)
        {
            return rE1.Punkte.CompareTo(rE2.Punkte);
        }
        public void doranking(decimal longitude, decimal latitude, int trackerid, DateTime pointtime)
        {
            foreach (Polygon p in InformationPool.PolygonGroupToDraw.Polygons)
            {
                if (p.Type == (int)PolygonType.PenaltyZone)
                {
                    if(p.contains2(longitude,latitude)){
                        foreach (RankingEntry r in rankinEntries.Where(q => q.TrackerID == trackerid))
                        {
                            r.Punkte += 6;
                        }
                    }
                }
                else if (p.Type == PolygonType.GateStartA || p.Type == PolygonType.GateStartB || p.Type == PolygonType.GateStartC || p.Type == PolygonType.GateStartD)
                {
                    foreach (RankingEntry r in rankinEntries.Where(q => q.TrackerID == trackerid))
                    {
                        if (!r.passedstartinggate)
                        {
                            ALine trackline = new ALine(new APoint(lastlongitude,lastlatitude),new APoint(longitude,latitude));
                            ALine gateline = new ALine(new APoint(p.Points[0].Longitude,p.Points[0].Latitude),new APoint(p.Points[1].Longitude,p.Points[1].Latitude));
                            if (intersect(trackline, gateline))
                            {
                                r.Punkte += getGatePenaltyPoints("StartGate", Race.StartTime, pointtime);
                                r.passedstartinggate = true;
                            }
                        }
                    }
                }
                else if (p.Type == PolygonType.GateEndA || p.Type == PolygonType.GateEndB || p.Type == PolygonType.GateEndC || p.Type == PolygonType.GateEndD)
                {
                    foreach (RankingEntry r in rankinEntries.Where(q => q.TrackerID == trackerid))
                    {
                        if (!r.passedfinishgate && lastlatitude !=-1 && lastlongitude!=-1)
                        {
                            ALine trackline = new ALine(new APoint(lastlongitude,lastlatitude),new APoint(longitude,latitude));
                            ALine gateline = new ALine(new APoint(p.Points[0].Longitude,p.Points[0].Latitude),new APoint(p.Points[1].Longitude,p.Points[1].Latitude));
                            if(intersect(trackline,gateline)){
                                r.Punkte += getGatePenaltyPoints("FinishGate", Race.StartTime.AddMinutes((double)Race.Duration), pointtime);
                                r.passedfinishgate = true;
                            }
                        }
                    }
                }
            }
            lastlongitude = longitude;
            lastlatitude = latitude;
                this.Invoke(new MethodInvoker(PopulateData));
            try
            {
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

            public static decimal cross(APoint p1, APoint p2)
            {
                return p1.x * p2.y - p2.x * p1.y;
            }

            public static decimal direction(APoint pi, APoint pj, APoint pk)
            {
                return cross(distance(pi, pk), distance(pi, pj));
            }

            public static bool intersect(ALine l1, ALine l2)
            {
                decimal d1 = direction(l2.p1, l2.p2, l1.p1);
                decimal d2 = direction(l2.p1, l2.p2, l1.p2);
                decimal d3 = direction(l1.p1, l1.p2, l2.p1);
                decimal d4 = direction(l1.p1, l1.p2, l2.p2);
                if ((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0) || (d3 > 0 && d4 < 0)
                        || (d3 < 0 && d4 > 0))
                    return true;
                else
                    return false;
            }
        


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.TransparencyKey = Color.AntiqueWhite;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.TopMost = false;
                Refresh();
            }
            else
            {
                this.TransparencyKey = Color.AliceBlue;
                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;
                Refresh();
            }
        }

    }
    public class APoint
    {
        public decimal x;
        public decimal y;
        public APoint(decimal x, decimal y)
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
}
