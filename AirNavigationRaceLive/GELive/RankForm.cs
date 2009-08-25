using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GELive
{
    public partial class RankForm : Form
    {
        public RankForm()
        {
            InitializeComponent();
        }
        
        public void PopulateData(List<RankingEntry> rankingEntries)
        {
            Comparison<RankingEntry> compRankEntr = new Comparison<RankingEntry>(CompareRankingEntries);
            rankingEntries.Sort(compRankEntr);
            rng1Name.Text = rankingEntries[3].LastName;
            rng1Punkte.Text = rankingEntries[3].Punkte.ToString();
            rng2Name.Text = rankingEntries[2].LastName;
            rng2Punkte.Text = rankingEntries[2].Punkte.ToString();
            rng3Name.Text = rankingEntries[1].LastName;
            rng3Punkte.Text = rankingEntries[1].Punkte.ToString();
            rng4Name.Text = rankingEntries[0].LastName;
            rng4Punkte.Text = rankingEntries[0].Punkte.ToString();
        }

        private void TestRanking_Click(object sender, EventArgs e)
        {
            List<RankingEntry> rankingEntries = new List<RankingEntry>();

            RankingEntry rE1 = new RankingEntry();
            rE1.LastName = "Bart";
            rE1.Punkte = 15;
            rankingEntries.Add(rE1);

            RankingEntry rE2 = new RankingEntry();
            rE2.LastName = "Lisa";
            rE2.Punkte = 12;
            rankingEntries.Add(rE2);

            RankingEntry rE3 = new RankingEntry();
            rE3.LastName = "Homer";
            rE3.Punkte = 1045;
            rankingEntries.Add(rE3);

            RankingEntry rE4 = new RankingEntry();
            rE4.LastName = "Marge";
            rE4.Punkte = 985;
            rankingEntries.Add(rE4);

            PopulateData(rankingEntries);
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
    }
}
