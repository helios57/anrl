using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Dialogs;
using AirNavigationRaceLive.Comps.Helper;
using System.IO;

namespace AirNavigationRaceLive.Comps
{
    public partial class Visualisation : UserControl
    {
        private Client.Client Client;
        private VisualisationPopup vp;
        private GEControll controll = new GEControll();
        private Timer t;
        private t_Competition comp;
        private List<t_Team> teamlist = new List<t_Team>();
        private List<t_Competition_Team> competitonTeamlist = new List<t_Competition_Team>();
        private volatile bool updating = false;
        private t_Parcour parcour;
        private RankForm rankForm;
        private List<t_Penalty> penaltyPoints = new List<t_Penalty>();
        public Visualisation(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            t = new Timer();
            t.Interval = 5000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (this.Visible && comp != null && !updating)
            {
                updating = true;
                long mintime = long.MaxValue;
                long maxtime = long.MinValue;
                List<t_GPSPoint> points = new List<t_GPSPoint>();
                teamlist.Clear();
                competitonTeamlist.Clear();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    if (lvi.Checked && lvi.Tag != null)
                    {
                        t_Competition_Team ct = lvi.Tag as t_Competition_Team;
                        competitonTeamlist.Add(ct);
                        t_Team t = Client.getTeam(ct.ID_Team);
                        teamlist.Add(t);
                        foreach(t_Tracker tracker in ct.t_Tracker)
                        {
                            points.AddRange(tracker.t_GPSPoint);
                        }
                        mintime = Math.Min(mintime, ct.TimeTakeOff);
                        maxtime = Math.Max(maxtime, ct.TimeEnd);
                    }
                }
                recieveData(points);
            }
        }
        public void recieveData(List<t_GPSPoint> data)
        {
            try
            {
                if (data != null)
                {
                    controll.SetDaten(data, teamlist.ToList(), competitonTeamlist);
                    visualisationPictureBox1.SetData(data, teamlist.ToList(), competitonTeamlist);
                    visualisationPictureBox1.Invalidate();

                    if (comp != null)
                    {
                        penaltyPoints.Clear();
                        foreach (t_Competition_Team g in competitonTeamlist)
                        {
                            teamlist.Clear();
                            t_Team t = Client.getTeam(g.ID_Team);
                            if (g.t_Tracker.Count > 0)
                            {
                                teamlist.Add(t);
                                List<t_Penalty> penalties = GeneratePenalty.CalculatePenaltyPoints(comp, g,Client.getParcour(comp.ID_Parcour), data.Where(p => g.t_Tracker.Any(tr=>tr.ID==p.t_Tracker.ID)).ToList(), (NetworkObjects.Route)g.Route);
                                foreach (t_Penalty p in penalties)
                                {
                                    p.ID_Competition_Team = g.ID;
                                }
                                penaltyPoints.AddRange(penalties);

                            }
                        }
                        if (rankForm != null && !rankForm.IsDisposed)
                        {
                            rankForm.SetData(penaltyPoints, competitonTeamlist.ToList(), Client);
                        }
                    }
                }
            }
            catch { }
            updating = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CompetitionComboEntry cce = comboBox1.SelectedItem as CompetitionComboEntry;
                if (cce != null)
                {
                    comp = cce.comp;

                    parcour = Client.getParcour(comp.ID_Parcour);
                    t_Map map = Client.getMap(parcour.ID_Map);
                    MemoryStream ms = new MemoryStream(Client.gett_Picture(map.ID_Picture).Data);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    controll.SetParcour(parcour);
                    listViewCompetitionTeam.Items.Clear();
                    List<t_Competition_Team> CompetitionTeamList = comp.t_Competition_Team.ToList();
                    CompetitionTeamList.Sort((p, q) => p.StartID.CompareTo(q.StartID));
                    foreach (t_Competition_Team ct in CompetitionTeamList)
                    {
                        ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(),getTeamDsc(ct.ID_Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStart).ToShortTimeString(), new DateTime(ct.TimeEnd).ToShortTimeString(), getRouteText(ct.Route) });
                        lvi2.Tag = ct;
                        listViewCompetitionTeam.Items.Add(lvi2);
                    }
                }
            }
        }
        private string getTeamDsc(int ID_Team)
        {
            t_Team team = Client.getTeam(ID_Team);
            t_Pilot pilot = Client.getPilot(team.ID_Pilot);
            StringBuilder sb = new StringBuilder();
            sb.Append(pilot.LastName).Append(" ").Append(pilot.SureName);
            if (team.ID_Navigator.HasValue)
            {
                t_Pilot navi = Client.getPilot(team.ID_Navigator.Value);
                sb.Append(" - ").Append(navi.LastName).Append(" ").Append(navi.SureName);
            }
            return sb.ToString();
        }
        private string getRouteText(int id)
        {
            return ((NetworkObjects.Route)id).ToString();
        }
        private void btnStartClient_Click(object sender, EventArgs e)
        {
            if (vp != null && !vp.IsDisposed)
            {
                vp.Close();
            }
            vp = new VisualisationPopup();
            vp.Show();
            while (vp.getPlugin() == null) Application.DoEvents();
            controll.SetPlugin(vp.getPlugin());
            if (parcour != null)
            {
                controll.SetParcour(parcour);
            }
        }


        private void Visualisation_Load(object sender, EventArgs e)
        {
            List<t_Competition> comps = Client.getCompetitions();
            comboBox1.Items.Clear();
            foreach (t_Competition c in comps)
            {
                comboBox1.Items.Add(new CompetitionComboEntry(c));
            }
        }

        private void fldVisualLineWidth_ValueChanged(object sender, EventArgs e)
        {
            controll.SetLineWidth((int)fldVisualLineWidth.Value);
        }

        private void fldPenaltyHeight_ValueChanged(object sender, EventArgs e)
        {
            controll.SetHeightPenalty((int)fldPenaltyHeight.Value);
            if (parcour != null)
            {
                controll.SetParcour(parcour);
            }
        }

        private void fldTrackerHeight_ValueChanged(object sender, EventArgs e)
        {
            controll.SetTrackerHeightAdjustment((int)fldTrackerHeight.Value);
        }

        private void btnShowRanking_Click(object sender, EventArgs e)
        {
            if (rankForm != null && !rankForm.IsDisposed)
            {
                rankForm.Close();
            }
            rankForm = new RankForm();
            rankForm.Show();
        }
    }
    class CompetitionComboEntry
    {
        public readonly t_Competition comp;
        public CompetitionComboEntry(t_Competition comp)
        {
            this.comp = comp;
        }
        public override string ToString()
        {
            return comp.ID + " " + comp.Name;
        }
    }
}
