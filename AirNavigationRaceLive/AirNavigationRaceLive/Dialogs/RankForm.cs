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
        private List<t_Penalty> rankinEntries;
        private List<t_Competition_Team> teams;
        private Client c;

        public RankForm()
        {
            InitializeComponent();
        }
        public void SetData(List<t_Penalty> rankinEntries, List<t_Competition_Team> teams, Client c)
        {
            this.c = c;
            this.rankinEntries = rankinEntries;
            this.teams = teams;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (c != null && rankinEntries != null && teams != null)
            {
                List<RankedTeam> rankedTeams = new List<RankedTeam>();
                foreach (t_Competition_Team t in teams)
                {
                    int sum = 0;
                    foreach (t_Penalty p in rankinEntries.Where(p => p.ID_Competition_Team == t.ID))
                    {
                        sum += p.Points;
                    }
                    rankedTeams.Add(new RankedTeam(t,c.getTeam(t.ID_Team),sum));
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
                                lblName1.Text = getTeamDsc(rt.team.ID);
                                break;
                            }
                        case 1:
                            {
                                lblPunkte2.Text = rt.points.ToString();
                                lblName2.Text = getTeamDsc(rt.team.ID);
                                break;
                            }
                        case 2:
                            {
                                lblPunkte3.Text = rt.points.ToString();
                                lblName3.Text = getTeamDsc(rt.team.ID);
                                break;
                            }
                        case 3:
                            {
                                lblPunkte4.Text = rt.points.ToString();
                                lblName4.Text = getTeamDsc(rt.team.ID);
                                break;
                            }
                    }
                    }catch{}
                }
            }
            base.OnPaint(e);
        }

        private string getTeamDsc(int ID_Team)
        {
            t_Team team = c.getTeam(ID_Team);
            t_Pilot pilot = c.getPilot(team.ID_Pilot);
            StringBuilder sb = new StringBuilder();
            sb.Append(pilot.LastName).Append(" ").Append(pilot.SureName);
            if (team.ID_Navigator.HasValue)
            {
                t_Pilot navi = c.getPilot(team.ID_Navigator.Value);
                sb.Append(" - ").Append(navi.LastName).Append(" ").Append(navi.SureName);
            }
            return sb.ToString();
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
        public t_Competition_Team t;
        public int points;
        public t_Team team;
        public RankedTeam(t_Competition_Team t,t_Team team, int points)
        {
            this.t = t;
            this.team = team;
            this.points = points;
        }

        public int CompareTo(RankedTeam obj)
        {
            return this.points.CompareTo(obj.points);
        }
    }
}
