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
        private Client.DataAccess Client;
        private VisualisationPopup vp;
        private GEControll controll = new GEControll();
        private Timer t;
        private QualificationRound comp;
        private List<Flight> flights = new List<Flight>();
        private volatile bool updating = false;
        private Parcour parcour;
        private RankForm rankForm;
        private List<Penalty> penaltyPoints = new List<Penalty>();
        public Visualisation(Client.DataAccess iClient)
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
                flights.Clear();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    if (lvi.Checked && lvi.Tag != null)
                    {
                        Flight ct = lvi.Tag as Flight;
                        flights.Add(ct);
                        mintime = Math.Min(mintime, ct.TimeTakeOff);
                        maxtime = Math.Max(maxtime, ct.TimeEndLine);
                    }
                }
                recieveData();
            }
        }
        public void recieveData()
        {
            try
            {
                if (flights.Count>0)
                {
                    controll.SetDaten(flights);
                    visualisationPictureBox1.SetData(flights);
                    visualisationPictureBox1.Invalidate();
                    if (comp != null)
                    {
                        penaltyPoints.Clear();
                        foreach (Flight flight in flights)
                        {
                            Team t = flight.Team;
                            if (flight.Point4D.Count>0)
                            {
                                List<Penalty> penalties = GeneratePenalty.CalculatePenaltyPoints(flight);
                                penaltyPoints.AddRange(penalties);
                            }
                        }
                        if (rankForm != null && !rankForm.IsDisposed)
                        {
                            rankForm.SetData(penaltyPoints, flights.ToList(), Client);
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

                    parcour = comp.Parcour;
                    Map map = parcour.Map;
                    MemoryStream ms = new MemoryStream(map.Picture.Data);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    controll.SetParcour(parcour);
                    listViewCompetitionTeam.Items.Clear();
                    List<Flight> CompetitionTeamList = comp.Flight.ToList();
                    CompetitionTeamList.Sort((p, q) => p.StartID.CompareTo(q.StartID));
                    foreach (Flight ct in CompetitionTeamList)
                    {
                        ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(),getTeamDsc(ct.Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                        lvi2.Tag = ct;
                        listViewCompetitionTeam.Items.Add(lvi2);
                    }
                }
            }
        }
        private string getTeamDsc(Team team)
        {
            Subscriber pilot = team.Pilot;
            StringBuilder sb = new StringBuilder();
            sb.Append(pilot.LastName).Append(" ").Append(pilot.FirstName);
            if (team.Navigator!=null)
            {
                Subscriber navi = team.Navigator;
                sb.Append(" - ").Append(navi.LastName).Append(" ").Append(navi.FirstName);
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
            List<QualificationRound> comps = Client.DBContext.QualificationRoundSet.ToList();
            comboBox1.Items.Clear();
            foreach (QualificationRound c in comps)
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
        public readonly QualificationRound comp;
        public CompetitionComboEntry(QualificationRound comp)
        {
            this.comp = comp;
        }
        public override string ToString()
        {
            return comp.Name;
        }
    }
}
