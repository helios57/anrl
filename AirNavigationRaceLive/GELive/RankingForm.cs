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

        public void SetData(List<RankingEntry> RankingList)
        {

        }
    }
    public class RankingEntry
    {
        public String Flugzeug;
        public String Pilot;
        public int Punkte;
    }
}
