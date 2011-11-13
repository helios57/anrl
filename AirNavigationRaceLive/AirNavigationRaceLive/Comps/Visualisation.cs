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
        private NetworkObjects.Competition comp;
        private List<int> trackerlist = new List<int>();
        private List<NetworkObjects.Team> teamlist = new List<NetworkObjects.Team>();
        private List<NetworkObjects.CompetitionTeam> competitonTeamlist = new List<NetworkObjects.CompetitionTeam>();
        private volatile bool updating = false;
        private NetworkObjects.Parcour parcour;
        private RankForm rankForm;
        private List<NetworkObjects.Penalty> penaltyPoints = new List<NetworkObjects.Penalty>();
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
                trackerlist.Clear();
                teamlist.Clear();
                competitonTeamlist.Clear();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    if (lvi.Checked && lvi.Tag != null)
                    {
                        NetworkObjects.CompetitionTeam ct = lvi.Tag as NetworkObjects.CompetitionTeam;
                        competitonTeamlist.Add(ct);
                        NetworkObjects.Team t = Client.getTeam(ct.ID_Team);
                        teamlist.Add(t);
                        trackerlist.AddRange(ct.ID_TrackerList);
                        mintime = Math.Min(mintime, ct.TimeTakeOff);
                        maxtime = Math.Max(maxtime, ct.TimeEndLine);
                    }
                }
                Client.getGPSDatenCache().requestGPSData(trackerlist, mintime - 1000000000, maxtime + 10000000000, new AsyncCallback(recieveData));
            }
        }
        public void recieveData(IAsyncResult result)
        {
            try
            {
                List<NetworkObjects.GPSData> data = result.AsyncState as List<NetworkObjects.GPSData>;
                if (data != null)
                {
                    controll.SetDaten(data, teamlist.ToList());
                    visualisationPictureBox1.SetData(data, teamlist.ToList(), competitonTeamlist);
                    visualisationPictureBox1.Invalidate();

                    if (comp != null)
                    {
                        penaltyPoints.Clear();
                        foreach (NetworkObjects.CompetitionTeam g in competitonTeamlist)
                        {
                            trackerlist.Clear();
                            teamlist.Clear();
                            NetworkObjects.Team t = Client.getTeam(g.ID_Team);
                            if (g.ID_TrackerList.Count > 0)
                            {
                                teamlist.Add(t);
                                List<NetworkObjects.Penalty> penalties = GeneratePenalty.CalculatePenaltyPoints(comp, g,Client.getParcour(comp.ID_Parcour), data.Where(p => g.ID_TrackerList.Contains(p.trackerID)).ToList(), (NetworkObjects.Route)g.Route);
                                foreach (NetworkObjects.Penalty p in penalties)
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
                    NetworkObjects.Map map = Client.getMap(parcour.ID_Map);
                    MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    controll.SetParcour(parcour);
                    listViewCompetitionTeam.Items.Clear();
                    foreach (NetworkObjects.CompetitionTeam ct in comp.CompetitionTeamList)
                    {
                        ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(),getTeamDsc(ct.ID_Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                        lvi2.Tag = ct;
                        listViewCompetitionTeam.Items.Add(lvi2);
                    }
                }
            }
        }
        private string getTeamDsc(int ID_Team)
        {
            NetworkObjects.Team team = Client.getTeam(ID_Team);
            NetworkObjects.Pilot pilot = Client.getPilot(team.ID_Pilot);
            StringBuilder sb = new StringBuilder();
            sb.Append(pilot.Name).Append(" ").Append(pilot.Surename);
            if (team.ID_Navigator > 0)
            {
                NetworkObjects.Pilot navi = Client.getPilot(team.ID_Navigator);
                sb.Append(" - ").Append(navi.Name).Append(" ").Append(navi.Surename);
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
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            comboBox1.Items.Clear();
            foreach (NetworkObjects.Competition c in comps)
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
        public readonly NetworkObjects.Competition comp;
        public CompetitionComboEntry(NetworkObjects.Competition comp)
        {
            this.comp = comp;
        }
        public override string ToString()
        {
            return comp.ID + " " + comp.Name;
        }
    }
}
