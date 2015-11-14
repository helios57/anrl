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
        private Client.DataAccess Client;
        private QualificationRound competition = null;
        private Parcour parcour;

        public Results(Client.DataAccess iClient)
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
                    listViewFlights.Items.Clear();
                    long min = long.MaxValue;
                    long max = long.MinValue;
                    List<Flight> CompetitionTeamList = competition.Flight.ToList();
                    CompetitionTeamList.Sort((p, q) => p.StartID.CompareTo(q.StartID));
                    List<Point> points = new List<Point>();
                    foreach (Flight ct in competition.Flight)
                    {
                        ComboBoxFlights lvi2 = new ComboBoxFlights(ct, new string[] { ct.StartID.ToString(), "0", getTeamDsc(ct), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                        lvi2.Tag = ct;
                        listViewFlights.Items.Add(lvi2);
                        points.AddRange(ct.Point);
                        min = Math.Min(ct.TimeTakeOff, min);
                        max = Math.Max(ct.TimeEndLine, max);
                    }
                    listViewFlights.Enabled = true;
                    parcour = cce.comp.Parcour;
                    Map map = parcour.Map;
                    MemoryStream ms = new MemoryStream(map.Picture.Data);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    updatePoints();
                }
                else
                {
                    listViewFlights.Enabled = false;
                    listViewFlights.Items.Clear();
                    listViewPenalty.Items.Clear();
                }
            }
            else
            {
                listViewFlights.Enabled = false;
                listViewFlights.Items.Clear();
                listViewPenalty.Items.Clear();
            }
        }
        private string getTeamDsc(Flight flight)
        {
            Team team = flight.Team;
            Subscriber pilot = team.Pilot;
            StringBuilder sb = new StringBuilder();
            sb.Append(pilot.LastName).Append(" ").Append(pilot.FirstName);
            if (team.Navigator != null)
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

        public void updatePoints()
        {
            if (competition != null && parcour != null)
            {
                foreach (ListViewItem lvi in listViewFlights.Items)
                {
                    ComboBoxFlights item = lvi as ComboBoxFlights;
                    item.penalty.Clear();
                    item.penalty.AddRange(item.flight.Penalty);
                    int sum = 0;
                    foreach (Penalty p in item.penalty)
                    {
                        sum += p.Points;
                    }
                    item.SubItems[1].Text = sum.ToString();
                }
                listViewFlights.Invalidate();
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
            List<QualificationRound> comps = Client.SelectedCompetition.QualificationRound.ToList();
            comboBoxCompetition.Items.Clear();
            foreach (QualificationRound c in comps)
            {
                comboBoxCompetition.Items.Add(new CompetitionComboEntry(c));
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBoxPenaltyID.Text = "0";
            textBoxPoints.Text = "0";
            textBoxReason.Text = "";
            textBoxPenaltyID.Tag = new Penalty(); ;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (listViewFlights.SelectedItems.Count == 1 && textBoxPenaltyID.Tag != null)
            {
                try
                {
                    ComboBoxFlights competitionTeam = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                    Penalty p = textBoxPenaltyID.Tag as Penalty;
                    p.Points = Int32.Parse(textBoxPoints.Text);
                    p.Reason = textBoxReason.Text;
                    if (!competitionTeam.flight.Penalty.Contains(p))
                    {
                        competitionTeam.flight.Penalty.Add(p);
                    }
                    if (!competitionTeam.penalty.Contains(p))
                    {
                        competitionTeam.penalty.Add(p);
                    }
                    Client.DBContext.SaveChanges();
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
            if (listViewFlights.SelectedItems.Count == 1)
            {
                ComboBoxFlights competitionTeam = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                if (listViewPenalty.SelectedItems.Count == 1)
                {
                    ListViewItem lvi = listViewPenalty.SelectedItems[0];
                    Penalty p = lvi.Tag as Penalty;
                    competitionTeam.penalty.Remove(p);
                    if (competitionTeam.flight.Penalty.Contains(p))
                    {
                        competitionTeam.flight.Penalty.Remove(p);
                        Client.DBContext.SaveChanges();
                    }
                    listViewCompetitionTeam_SelectedIndexChanged(null, null);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (listViewFlights.SelectedItems.Count == 1)
            {
                ComboBoxFlights competitionTeam = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                foreach (ListViewItem lvi in listViewPenalty.Items)
                {
                    Penalty penalty = lvi.Tag as Penalty;
                    if (!competitionTeam.flight.Penalty.Contains(penalty))
                    {
                        competitionTeam.flight.Penalty.Add(penalty);
                    }
                    Client.DBContext.SaveChanges();
                }
                competitionTeam.penalty.Clear();
                competitionTeam.penalty.AddRange(competitionTeam.flight.Penalty);
                listViewCompetitionTeam_SelectedIndexChanged(null, null);
            }
        }

        private void listViewPenalty_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPenalty.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPenalty.SelectedItems[0];
                Penalty p = lvi.Tag as Penalty;
                textBoxPenaltyID.Text = p.Id.ToString();
                textBoxPenaltyID.Tag = p;
                textBoxPoints.Text = p.Points.ToString();
                textBoxReason.Text = p.Reason;
            }
        }

        private void btnPdf_Click(object sender, EventArgs e)
        {
            if (competition != null && listViewFlights.Items.Count > 0)
            {
                List<ComboBoxFlights> ctl = new List<ComboBoxFlights>();
                foreach (ListViewItem lvi in listViewFlights.Items)
                {
                    ctl.Add(lvi as ComboBoxFlights);
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

            if (listViewFlights.SelectedItems.Count == 1)
            {
                btnUpload.Enabled = true;
                btnUploadGPX.Enabled = true;
                ComboBoxFlights comboFlights = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                List<Flight> flights = new List<Flight>(1);
                flights.Add(comboFlights.flight);
                visualisationPictureBox1.SetData(flights);
                visualisationPictureBox1.Invalidate();
                List<ListViewItem> ppp = new List<ListViewItem>();
                foreach (Penalty p in comboFlights.penalty)
                {
                    ListViewItem lvi = new ListViewItem(new String[] { p.Id.ToString(), p.Points.ToString(), p.Reason });
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
            if (listViewFlights.SelectedItems.Count == 1)
            {
                ComboBoxFlights competitionTeam = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                UploadGAC upload = new UploadGAC(Client, competitionTeam.flight);
                upload.OnFinish += new EventHandler(UploadFinished);
                upload.Show();
            }
        }
        delegate void OnFinishCallback(IAsyncResult result);

        public void UploadFinished(object o, EventArgs ea)
        {
            OnFinishCallback d = new OnFinishCallback(UploadFinished);
            listViewFlights.Invoke(d, new object[] { null });
        }
        public void UploadFinished(IAsyncResult ass)
        {
            updatePoints();

            listViewCompetitionTeam_SelectedIndexChanged(null, null);

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<QualificationRound> comps = Client.SelectedCompetition.QualificationRound.ToList();
            comboBoxCompetition.Items.Clear();
            comboBoxCompetition.SelectedItem = null;
            comboBoxCompetition.Text = "";
            foreach (QualificationRound c in comps)
            {
                comboBoxCompetition.Items.Add(new CompetitionComboEntry(c));
            }
            comboBox1_SelectedIndexChanged(null, null);
        }

        private void btnExportToplist_Click(object sender, EventArgs e)
        {
            if (competition != null && listViewFlights.Items.Count > 0)
            {
                List<ComboBoxFlights> ctl = new List<ComboBoxFlights>();
                foreach (ListViewItem lvi in listViewFlights.Items)
                {
                    ctl.Add(lvi as ComboBoxFlights);
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
            if (listViewFlights.SelectedItems.Count == 1)
            {
                ComboBoxFlights competitionTeam = listViewFlights.SelectedItems[0] as ComboBoxFlights;
                UploadGPX upload = new UploadGPX(Client, competitionTeam.flight);
                upload.OnFinish += new EventHandler(UploadFinished);
                upload.Show();
            }
        }

    }
    public class ComboBoxFlights : ListViewItem
    {
        public readonly Flight flight;
        public readonly List<Penalty> penalty = new List<Penalty>();
        public ComboBoxFlights(Flight team, string[] display)
            : base(display)
        {
            this.flight = team;
        }
    }
}
