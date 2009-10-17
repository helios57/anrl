using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GELive.ANRLDataService;

namespace GELive
{
    public partial class RankForm : Form
    {
        List<RankingEntry> rankinEntries;
        public RankForm()
        {
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
            if (rankinEntries.Count > 0)
            {
                rng1Name.Text = rankinEntries[0].LastName;
                rng1Punkte.Text = rankinEntries[0].Punkte.ToString();
            }
            if (rankinEntries.Count > 1)
            {
                rng2Name.Text = rankinEntries[1].LastName;
                rng2Punkte.Text = rankinEntries[1].Punkte.ToString();
            }
            if (rankinEntries.Count > 2)
            {
                rng3Name.Text = rankinEntries[2].LastName;
                rng3Punkte.Text = rankinEntries[2].Punkte.ToString();
            }
            if (rankinEntries.Count > 3)
            {
                rng4Name.Text = rankinEntries[3].LastName;
                rng4Punkte.Text = rankinEntries[3].Punkte.ToString();
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
        public void doranking(decimal longitude, decimal latitude, int trackerid)
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
            }
            try
            {
                this.Invoke(new MethodInvoker(PopulateData));
            }
            catch
            { }     
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
}
