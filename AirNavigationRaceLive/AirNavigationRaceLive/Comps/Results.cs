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
    public partial class Results : UserControl
    {
        private Client.Client Client;
        private NetworkObjects.Competition competition = null;
        private NetworkObjects.Team team = null;
        private int pos;

        public Results(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            competition = null;
            if (comboBoxCompetition.SelectedItem != null)
            {
                CompetitionComboEntry cce = comboBoxCompetition.SelectedItem as CompetitionComboEntry;
                if (cce != null)
                {
                    competition = cce.comp;
                    comboBoxTeam.Items.Clear();
                    foreach (NetworkObjects.CompetitionGroup cg in cce.comp.CompetitionGroupList)
                    {
                        NetworkObjects.Group g = Client.getGroup(cg.ID_Group);
                        foreach (NetworkObjects.GroupTeam gt in g.GroupTeamList)
                        {
                            comboBoxTeam.Items.Add(new ComboBoxTeam(Client.getTeam(gt.ID_Team), gt.Pos));
                        }
                    }
                    comboBoxTeam.Enabled = true;
                    NetworkObjects.Parcour parcour = Client.getParcour(cce.comp.ID_Parcour);
                    NetworkObjects.Map map = Client.getMap(parcour.ID_Map);
                    MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                }
                else
                {
                    comboBoxTeam.Enabled = false;
                }
            }
            else
            {
                comboBoxTeam.Enabled = false;
            }
        }

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            team = null;
            listViewPenalty.Items.Clear();
            fldTotalPoints.Text = "";
            if (comboBoxTeam.SelectedItem != null)
            {
                ComboBoxTeam cbt = comboBoxTeam.SelectedItem as ComboBoxTeam;
                if (cbt != null)
                {
                    team = cbt.team;
                    pos = cbt.pos;
                    if (team.ID_Tracker.Count > 0)
                    {
                        Client.getGPSDatenCache().requestGPSData(team.ID_Tracker, competition.TimeTakeOff - 10000000, competition.TimeEndLine + 10000000, new AsyncCallback(recieveData));
                    }
                }
            }
        }
        public void recieveData(IAsyncResult result)
        {
            List<NetworkObjects.GPSData> data = result.AsyncState as List<NetworkObjects.GPSData>;
            if (data != null && team != null && competition != null)
            {
                visualisationPictureBox1.SetData(data, new List<NetworkObjects.Team>(new NetworkObjects.Team[] { team }));
                visualisationPictureBox1.Invalidate();
                if (Client.getPenalties().Count(p => p.ID_Competition == competition.ID && p.ID_Team == team.ID) > 0)
                {
                    List<ListViewItem> ppp = new List<ListViewItem>();
                    foreach (NetworkObjects.Penalty p in Client.getPenalties().Where(p => p.ID_Competition == competition.ID && p.ID_Team == team.ID))
                    {
                        p.ID_Team = team.ID;
                        p.ID_Competition = competition.ID;
                        ListViewItem lvi = new ListViewItem(new String[] { p.ID.ToString(), p.Points.ToString(), p.Reason });
                        lvi.Tag = p;
                        ppp.Add(lvi);
                    }
                    SetPenalties(ppp);
                }
                else
                {
                    List<NetworkObjects.Penalty> penalties = GeneratePenalty.CalculatePenaltyPoints(competition, Client.getParcour(competition.ID_Parcour), data.Where(p => team.ID_Tracker.Contains(p.trackerID)).ToList(), (NetworkObjects.GroupPosType)pos);
                    List<ListViewItem> ppp = new List<ListViewItem>();
                    foreach (NetworkObjects.Penalty p in penalties)
                    {
                        p.ID_Team = team.ID;
                        p.ID_Competition = competition.ID;
                        ListViewItem lvi = new ListViewItem(new String[] { p.ID.ToString(), p.Points.ToString(), p.Reason });
                        lvi.Tag = p;
                        ppp.Add(lvi);
                    }
                    SetPenalties(ppp);
                }
            }
        }
        delegate void SetPenaltiesCallback(List<ListViewItem> penalties);
        private void SetPenalties(List<ListViewItem> penalties)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.listViewPenalty.InvokeRequired)
            {
                SetPenaltiesCallback d = new SetPenaltiesCallback(SetPenalties);
                this.Invoke(d, new object[] { penalties });
            }
            else
            {
                int sum = 0;
                foreach (ListViewItem lvi in penalties)
                {
                    listViewPenalty.Items.Add(lvi);
                    sum += (lvi.Tag as NetworkObjects.Penalty).Points;
                }
                fldTotalPoints.Text = sum.ToString();
            }
        }

        private void Visualisation_Load(object sender, EventArgs e)
        {
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            comboBoxCompetition.Items.Clear();
            foreach (NetworkObjects.Competition c in comps)
            {
                comboBoxCompetition.Items.Add(new CompetitionComboEntry(c));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBoxPenaltyID.Text = "0";
            textBoxPoints.Text = "0";
            textBoxReason.Text = "";
            textBoxPenaltyID.Tag = null;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NetworkObjects.Penalty p;
            if (textBoxPenaltyID.Tag != null)
            {
                p = textBoxPenaltyID.Tag as NetworkObjects.Penalty;
                ListViewItem lvi = null;
                foreach (ListViewItem lvit in listViewPenalty.Items)
                {
                    if (lvit.Tag == p)
                    {
                        lvi = lvit;
                    }
                }
                listViewPenalty.Items.Remove(lvi);
            }
            else
            {
                p = new NetworkObjects.Penalty();
                p.ID_Team = team.ID;
                p.ID_Competition = competition.ID;
            }
            p.Points = Int32.Parse(textBoxPoints.Text);
            p.Reason = textBoxReason.Text;
            ListViewItem lvi2 = new ListViewItem(new String[] { p.ID.ToString(), p.Points.ToString(), p.Reason });
            lvi2.Tag = p;
            listViewPenalty.Items.Add(lvi2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewPenalty.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPenalty.SelectedItems[0];
                NetworkObjects.Penalty p = lvi.Tag as NetworkObjects.Penalty;
                if (p.ID > 0)
                {
                    Client.deletePenalty(p.ID);
                    listViewPenalty.Items.Clear();
                    Client.getGPSDatenCache().requestGPSData(team.ID_Tracker, competition.TimeTakeOff - 10000000, competition.TimeEndLine + 10000000, new AsyncCallback(recieveData));
                }
                else
                {
                    listViewPenalty.Items.Remove(lvi);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listViewPenalty.Items)
            {
                Client.savePenalty(lvi.Tag as NetworkObjects.Penalty);
            }
            listViewPenalty.Items.Clear();
            if (team.ID_Tracker.Count > 0)
            {
                Client.getGPSDatenCache().requestGPSData(team.ID_Tracker, competition.TimeTakeOff - 10000000, competition.TimeEndLine + 10000000, new AsyncCallback(recieveData));
            }
        }

        private void listViewPenalty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPenalty.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPenalty.SelectedItems[0];
                NetworkObjects.Penalty p = lvi.Tag as NetworkObjects.Penalty;
                textBoxPenaltyID.Text = p.ID.ToString();
                textBoxPenaltyID.Tag = p;
                textBoxPoints.Text = p.Points.ToString();
                textBoxReason.Text = p.Reason;
            }
        }
    }
    class ComboBoxTeam
    {
        public readonly NetworkObjects.Team team;
        public readonly int pos;
        public ComboBoxTeam(NetworkObjects.Team team, int pos)
        {
            this.team = team;
            this.pos = pos;
        }
        public override string ToString()
        {
            return team.Name;
        }
    }
}
