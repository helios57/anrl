using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AirNavigationRaceLive.Comps.Client;

namespace AirNavigationRaceLive.Dialogs
{
    public partial class RankForm : Form
    {
        private List<NetworkObjects.Penalty> rankinEntries;
        private List<NetworkObjects.Team> teams;
        private Client c;

        public RankForm()
        {
            InitializeComponent();
        }
        public void SetData(List<NetworkObjects.Penalty> rankinEntries, List<NetworkObjects.Team> teams, Client c)
        {
            this.c = c;
            this.rankinEntries = rankinEntries;
            this.teams = teams;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (c != null && c.isAuthenticated() && rankinEntries != null && teams != null)
            {
                List<RankedTeam> rankedTeams = new List<RankedTeam>();
                foreach (NetworkObjects.Team t in teams)
                {
                    int sum = 0;
                    foreach (NetworkObjects.Penalty p in rankinEntries.Where(p => p.ID_Team == t.ID))
                    {
                        sum += p.Points;
                    }
                    rankedTeams.Add(new RankedTeam(t, sum));
                }
                rankedTeams.Sort();
                for (int i = 0; i < rankedTeams.Count; i++)
                {
                    try{
                    RankedTeam rt = rankedTeams[i];
                    switch (i)
                    {
                        case 0:
                            {
                                lblPunkte1.Text = rt.points.ToString();
                                lblName1.Text = rt.t.Name;
                                break;
                            }
                        case 1:
                            {
                                lblPunkte2.Text = rt.points.ToString();
                                lblName2.Text = rt.t.Name;
                                break;
                            }
                        case 2:
                            {
                                lblPunkte3.Text = rt.points.ToString();
                                lblName3.Text = rt.t.Name;
                                break;
                            }
                        case 3:
                            {
                                lblPunkte4.Text = rt.points.ToString();
                                lblName4.Text = rt.t.Name;
                                break;
                            }
                    }
                    }catch{}
                }
            }
            base.OnPaint(e);
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
    }
    class RankedTeam:IComparable<RankedTeam>
    {
        public NetworkObjects.Team t;
        public int points;
        public RankedTeam(NetworkObjects.Team t, int points)
        {
            this.t = t;
            this.points = points;
        }

        public int CompareTo(RankedTeam obj)
        {
            return -this.points.CompareTo(obj.points);
        }
    }
}
