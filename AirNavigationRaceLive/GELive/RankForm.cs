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
            //rng1Name.Text = rankinEntries[3].LastName;
            //rng1Punkte.Text = rankinEntries[3].Punkte.ToString();
            //rng1Punkte.Invoke(new MethodInvoker(addrankingEntry1));
            rng2Name.Text = rankinEntries[2].LastName;
            rng2Punkte.Text = rankinEntries[2].Punkte.ToString();
            //rng2Punkte.Invoke(new MethodInvoker(addrankingEntry2));
            rng3Name.Text = rankinEntries[1].LastName;
            rng3Punkte.Text = rankinEntries[1].Punkte.ToString();
            //rng3Punkte.Invoke(new MethodInvoker(addrankingEntry3));
            rng4Name.Text = rankinEntries[0].LastName;
            rng4Punkte.Text = rankinEntries[0].Punkte.ToString();
            //rng4Punkte.Invoke(new MethodInvoker(addrankingEntry4));
        }

        private void TestRanking_Click(object sender, EventArgs e)
        {
            //List<RankingEntry> rankingEntries = new List<RankingEntry>();

            //RankingEntry rE1 = new RankingEntry();
            //rE1.LastName = "Bart";
            //rE1.Punkte = 15;
            //rankingEntries.Add(rE1);

            //RankingEntry rE2 = new RankingEntry();
            //rE2.LastName = "Lisa";
            //rE2.Punkte = 12;
            //rankingEntries.Add(rE2);

            //RankingEntry rE3 = new RankingEntry();
            //rE3.LastName = "Homer";
            //rE3.Punkte = 1045;
            //rankingEntries.Add(rE3);

            //RankingEntry rE4 = new RankingEntry();
            //rE4.LastName = "Marge";
            //rE4.Punkte = 985;
            //rankingEntries.Add(rE4);

            //PopulateData(rankingEntries);
            initranking();
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
            //PopulateData();
            this.Invoke(new MethodInvoker(PopulateData));
        }
        public void initranking()
        {
            rankinEntries = new List<RankingEntry>();
        }
    }
}
