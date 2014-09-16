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
        private NetworkObjects.Parcour parcour;

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
                    listViewCompetitionTeam.Items.Clear();
                    List<int> trackers = new List<int>();
                    long min = long.MaxValue;
                    long max = long.MinValue;
                    competition.CompetitionTeamList.Sort((p, q) => p.StartID.CompareTo(q.StartID));
                    foreach (NetworkObjects.CompetitionTeam ct in competition.CompetitionTeamList)
                    {
                        ComboBoxCompetitionTeam lvi2 = new ComboBoxCompetitionTeam(ct, new string[] { ct.StartID.ToString(), "0", getTeamDsc(ct.ID_Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                        lvi2.Tag = ct;
                        listViewCompetitionTeam.Items.Add(lvi2);
                        trackers.AddRange(ct.ID_TrackerList);
                        min = Math.Min(ct.TimeTakeOff, min);
                        max = Math.Max(ct.TimeEndLine, max);
                    }
                    listViewCompetitionTeam.Enabled = true;
                    parcour = Client.getParcour(cce.comp.ID_Parcour);
                    NetworkObjects.Map map = Client.getMap(parcour.ID_Map);
                    MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    Client.getGPSDatenCache().requestGPSData(trackers, min - 1000000000, max + 10000000000, new AsyncCallback(recieveData));

                }
                else
                {
                    listViewCompetitionTeam.Enabled = false;
                    listViewCompetitionTeam.Items.Clear();
                    listViewPenalty.Items.Clear();
                }
            }
            else
            {
                listViewCompetitionTeam.Enabled = false;
                listViewCompetitionTeam.Items.Clear();
                listViewPenalty.Items.Clear();
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

        delegate void RecieveDataCallback(IAsyncResult result);
        public void recieveData(IAsyncResult result)
        {
            if (listViewCompetitionTeam.InvokeRequired)
            {
                RecieveDataCallback d = new RecieveDataCallback(recieveData);
                listViewCompetitionTeam.Invoke(d, new object[] { result });
            }
            else
            {
                List<NetworkObjects.GPSData> data = result.AsyncState as List<NetworkObjects.GPSData>;
                if (data != null && competition != null && parcour != null)
                {
                    foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                    {
                        ComboBoxCompetitionTeam item = lvi as ComboBoxCompetitionTeam;
                        item.penalty.Clear();
                        item.penalty.AddRange(Client.getPenalties().Where(p => p.ID_Competition_Team == item.competitionTeam.ID));
                        item.data.Clear();
                        item.data.AddRange(data.Where(p => item.competitionTeam.ID_TrackerList.Contains(p.trackerID)));
                        if (item.penalty.Count == 0)
                        {
                            List<NetworkObjects.Penalty> penalties = GeneratePenalty.CalculatePenaltyPoints(competition, item.competitionTeam, parcour, item.data, (NetworkObjects.Route)item.competitionTeam.Route);
                            item.penalty.AddRange(penalties);
                        }
                        int sum = 0;
                        foreach (NetworkObjects.Penalty p in item.penalty)
                        {
                            sum += p.Points;
                        }
                        item.SubItems[1].Text = sum.ToString();
                    }
                    listViewCompetitionTeam.Invalidate();
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
                listViewPenalty.Items.Clear();
                listViewPenalty.Items.AddRange(penalties.ToArray());
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
            textBoxPenaltyID.Tag = new NetworkObjects.Penalty(); ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1 && textBoxPenaltyID.Tag != null)
            {
                try
                {
                    ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                    NetworkObjects.Penalty p = textBoxPenaltyID.Tag as NetworkObjects.Penalty;
                    p.ID_Competition_Team = competitionTeam.competitionTeam.ID;
                    p.Points = Int32.Parse(textBoxPoints.Text);
                    p.Reason = textBoxReason.Text;
                    if (!competitionTeam.penalty.Contains(p))
                    {
                        competitionTeam.penalty.Add(p);
                    }
                    listViewCompetitionTeam_SelectedIndexChanged(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception occured, this mostly happen when you typed non-Integer to the Points-Field\n" + ex.ToString());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                if (listViewPenalty.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = listViewPenalty.SelectedItems[0];
                    NetworkObjects.Penalty p = lvi.Tag as NetworkObjects.Penalty;
                    competitionTeam.penalty.Remove(p);
                    if (p.ID > 0)
                    {
                        Client.deletePenalty(p.ID);
                    }
                    listViewCompetitionTeam_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                foreach (ListViewItem lvi in listViewPenalty.Items)
                {
                    NetworkObjects.Penalty penalty = lvi.Tag as NetworkObjects.Penalty;
                    penalty.ID_Competition_Team = competitionTeam.competitionTeam.ID;

                    if (penalty.ID > 0)
                    {
                        Client.deletePenalty(penalty.ID);
                    }
                    Client.savePenalty(penalty);
                }
                competitionTeam.penalty.Clear();
                competitionTeam.penalty.AddRange(Client.getPenalties().Where(p => p.ID_Competition_Team == competitionTeam.competitionTeam.ID));
                listViewCompetitionTeam_SelectedIndexChanged(null, null);
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

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (competition != null && listViewCompetitionTeam.Items.Count > 0)
            {
                List<ComboBoxCompetitionTeam> ctl = new List<ComboBoxCompetitionTeam>();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    ctl.Add(lvi as ComboBoxCompetitionTeam);
                }
                String dirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\AirNavigationRace\";
                DirectoryInfo di = Directory.CreateDirectory(dirPath);
                if (!di.Exists)
                {
                    di.Create();
                }
                PDFCreator.CreateResultPDF(visualisationPictureBox1, Client, competition, ctl, dirPath +
                    @"\Results_" + competition.Name + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
            }
        }

        private void listViewCompetitionTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                btnUpload.Enabled = true;
                btnUploadGPX.Enabled = true;
                ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                visualisationPictureBox1.SetData(competitionTeam.data, new List<NetworkObjects.Team>(new NetworkObjects.Team[] { Client.getTeam(competitionTeam.competitionTeam.ID_Team) }), new List<NetworkObjects.CompetitionTeam>(new NetworkObjects.CompetitionTeam[] { competitionTeam.competitionTeam }));
                visualisationPictureBox1.Invalidate();
                List<ListViewItem> ppp = new List<ListViewItem>();
                foreach (NetworkObjects.Penalty p in competitionTeam.penalty)
                {
                    ListViewItem lvi = new ListViewItem(new String[] { p.ID.ToString(), p.Points.ToString(), p.Reason });
                    lvi.Tag = p;
                    ppp.Add(lvi);
                }
                SetPenalties(ppp);
            }
            else
            {
                btnUpload.Enabled = false;
                btnUploadGPX.Enabled = false;
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                UploadGAC upload = new UploadGAC(Client, competitionTeam.competitionTeam);
                upload.OnFinish += new EventHandler(UploadFinished);
                upload.Show();
            }
        }
        delegate void OnFinishCallback(IAsyncResult result);

        public void UploadFinished(object o, EventArgs ea)
        {
            OnFinishCallback d = new OnFinishCallback(UploadFinished);
            listViewCompetitionTeam.Invoke(d, new object[] { null });
        }
        public void UploadFinished(IAsyncResult ass)
        {
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            comboBoxCompetition.Items.Clear();
            listViewCompetitionTeam.Items.Clear();
            foreach (NetworkObjects.Competition c in comps)
            {
                comboBoxCompetition.Items.Add(new CompetitionComboEntry(c));
            }
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            comboBoxCompetition.Items.Clear();
            comboBoxCompetition.SelectedItem = null;
            comboBoxCompetition.Text = "";
            foreach (NetworkObjects.Competition c in comps)
            {
                comboBoxCompetition.Items.Add(new CompetitionComboEntry(c));
            }
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void btnExportToplist_Click(object sender, EventArgs e)
        {
            if (competition != null && listViewCompetitionTeam.Items.Count > 0)
            {
                List<ComboBoxCompetitionTeam> ctl = new List<ComboBoxCompetitionTeam>();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    ctl.Add(lvi as ComboBoxCompetitionTeam);
                }
                String dirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\AirNavigationRace\";
                DirectoryInfo di = Directory.CreateDirectory(dirPath);
                if (!di.Exists)
                {
                    di.Create();
                }
                PDFCreator.CreateToplistResultPDF(Client, competition, ctl, dirPath +
                    @"\Results_" + competition.Name + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
            }
        }

        private void btnUploadGPX_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                ComboBoxCompetitionTeam competitionTeam = listViewCompetitionTeam.SelectedItems[0] as ComboBoxCompetitionTeam;
                UploadGPX upload = new UploadGPX(Client, competitionTeam.competitionTeam);
                upload.OnFinish += new EventHandler(UploadFinished);
                upload.Show();
            }
        }

    }
    public class ComboBoxCompetitionTeam : ListViewItem
    {
        public readonly NetworkObjects.CompetitionTeam competitionTeam;
        public readonly List<NetworkObjects.Penalty> penalty = new List<NetworkObjects.Penalty>();
        public readonly List<NetworkObjects.GPSData> data = new List<NetworkObjects.GPSData>();
        public ComboBoxCompetitionTeam(NetworkObjects.CompetitionTeam team, string[] display)
            : base(display)
        {
            this.competitionTeam = team;
        }
    }
}
