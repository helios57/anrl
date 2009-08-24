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
    public partial class RankingForm : Form
    {
        public RankingForm()
        {
            InitializeComponent();
        }

        private void RankingForm_Load(object sender, EventArgs e)
        {

        }

        public void SetData(List<RankingEntry> RankingEntries)
        {
            // RankingEntries.Sort();
            string bla = "blubber";
        }

        private void TestRanking_Click(object sender, EventArgs e)
        {
            List<RankingEntry> rankingEntries = new List<RankingEntry>();

            for (int i = 1; i < 5; i++)
            {
                RankingEntry rankingEntry = new RankingEntry();
                rankingEntry.LastName = "Flugzeug" + i;
                rankingEntry.SureName = "Pilot" + i;
                rankingEntry.Punkte = i;

                rankingEntries.Add(rankingEntry);
            }

            SetData(rankingEntries);
        }
    }
}
