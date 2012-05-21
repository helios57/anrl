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
    public partial class QualificationRound : UserControl
    {
        private Client.Client Client;

        public QualificationRound(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            comboBoxRoute.Items.Clear();
            for (int i = 1; i <= 4; i++)
            {
                NetworkObjects.Route r = (NetworkObjects.Route)i;
                comboBoxRoute.Items.Add(new ComboRoute(r));
            }
            comboBoxRoute.SelectedIndex = 0;
            lblTitel.Text = lblTitel.Text + iClient.getCompetitionSet().Name;

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.Show();
        }

        private void LoadCompetition()
        {
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            listViewCompetition.Items.Clear();
            foreach (NetworkObjects.Competition c in comps)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.ID.ToString(), c.Name });
                lvi.Tag = c;
                listViewCompetition.Items.Add(lvi);
            }
            UpdateEnablement();
        }
        private void LoadTeams()
        {
            List<NetworkObjects.Team> teams = Client.getTeams();
            comboBoxTeam.Items.Clear();
            foreach (NetworkObjects.Team t in teams)
            {
                comboBoxTeam.Items.Add(new ComboTeam(t, getTeamDsc(t.ID)));
            }
            List<NetworkObjects.Tracker> trackers = Client.getTrackers();
            listViewTrackers.Items.Clear();
            foreach (NetworkObjects.Tracker t in trackers)
            {
                ListViewItem lvi = new ListViewItem(new string[] { t.ID.ToString(), t.Name, t.IMEI });
                lvi.Tag = t;
                listViewTrackers.Items.Add(lvi);
            }
            comboBoxTeam.SelectedIndex = 0;
            UpdateEnablement();
        }
        private void LoadParcours()
        {
            List<NetworkObjects.Parcour> parcour = Client.getParcours();
            parcours.Items.Clear();
            foreach (NetworkObjects.Parcour c in parcour)
            {
                ComboParcour cp = new ComboParcour(c);
                parcours.Items.Add(cp);
            }
            parcours.SelectedIndex = 0;
            UpdateEnablement();
        }

        private void UpdateEnablement()
        {
            bool CompetitionSelected = listViewCompetition.SelectedItems.Count == 1;
            bool CompetitionTeamSelected = listViewCompetitionTeam.SelectedItems.Count == 1;
            bool Ediable = textID.Text != "";
            bool parcourSelected = parcours.SelectedItem != null;
            bool takeOffLine = true;
            takeOffLine &= isValidDouble(takeOffLeftLatitude.Text);
            takeOffLine &= isValidDouble(takeOffLeftLongitude.Text);
            takeOffLine &= isValidDouble(takeOffRightLatitude.Text);
            takeOffLine &= isValidDouble(takeOffRightLongitude.Text);
            bool StartID = textBoxStartId.Text != "" && textBoxStartId.Tag != null && Ediable;
            try
            {
                int i = Int32.Parse(textBoxStartId.Text);
            }
            catch
            {
                StartID = false;
            }
            bool TeamSelected = comboBoxTeam.SelectedItem != null && Ediable;
            bool RouteSelected = comboBoxRoute.SelectedItem != null && Ediable;
            textBoxStartId.Enabled = StartID;
            btnDeleteCompetitions.Enabled = CompetitionSelected;
            btnSave.Enabled = Ediable && parcourSelected && takeOffLine;
            textName.Enabled = Ediable;
            date.Enabled = Ediable;
            timeTakeOff.Enabled = Ediable;
            timeStart.Enabled = Ediable;
            timeEnd.Enabled = Ediable;
            parcours.Enabled = Ediable;
            takeOffLeftLatitude.Enabled = Ediable;
            takeOffLeftLongitude.Enabled = Ediable;
            takeOffRightLatitude.Enabled = Ediable;
            takeOffRightLongitude.Enabled = Ediable;
            listViewCompetitionTeam.Enabled = Ediable;
            btnDeleteCompetitionTeam.Enabled = Ediable && StartID;
            btnSaveCompetitionTeam.Enabled = StartID && TeamSelected && RouteSelected;
            btnExportToPDF.Enabled = btnSave.Enabled;
            listViewTrackers.Enabled = StartID;
        }
        private bool isValidDouble(String s)
        {
            bool result = true;
            try
            {
                double.Parse(s);
            }
            catch
            {
                result = false;
            }
            return result;
        }
        private void Reset()
        {
            textID.Text = "";
            textName.Text = "";
            parcours.SelectedItem = null;
            parcours.Text = "";
            takeOffLeftLatitude.Text = "";
            takeOffLeftLongitude.Text = "";
            takeOffRightLatitude.Text = "";
            takeOffRightLongitude.Text = "";
            textBoxStartId.Text = "";
            textBoxStartId.Tag = null;
            comboBoxTeam.SelectedItem = null;
            comboBoxRoute.SelectedItem = null;
            listViewCompetitionTeam.Items.Clear();
            foreach (ListViewItem lvi in listViewTrackers.Items)
            {
                lvi.Checked = false;
            }
            UpdateEnablement();
        }

        private void Competition_Load(object sender, EventArgs e)
        {
            Reset();
            LoadParcours();
            LoadCompetition();
            LoadTeams();
            SetTimes();
        }

        private void SetTimes()
        {
            DateTime time = DateTime.Now;
            timeTakeOffIntervall.Value = new DateTime(time.Year,time.Month,time.Day,time.Hour,1,0);
            timeParcourLength.Value = new DateTime(time.Year, time.Month, time.Day, time.Hour, 12, 0);
            timeParcourIntervall.Value = new DateTime(time.Year,time.Month,time.Day,time.Hour,20,0);
            timeTakeOffStartgate.Value = new DateTime(time.Year, time.Month, time.Day, time.Hour, 12, 0);
            timeTakeOff.Value = time;
            timeStart.Value = timeTakeOff.Value.AddMinutes(timeTakeOffStartgate.Value.Minute+((comboBoxRoute.Items.Count-1)*timeTakeOffIntervall.Value.Minute));
            timeEnd.Value = timeStart.Value.AddMinutes(timeParcourLength.Value.Minute);
        }

        private void btnRefreshCompetitions_Click(object sender, EventArgs e)
        {
            Reset();
            LoadCompetition();
            LoadTeams();
            LoadParcours();
        }

        private void btnDeleteCompetitions_Click(object sender, EventArgs e)
        {
            if (listViewCompetition.SelectedItems.Count == 1)
            {
                NetworkObjects.Competition c = listViewCompetition.SelectedItems[0].Tag as NetworkObjects.Competition;
                Client.deleteCompetition(c.ID);
                LoadCompetition();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadParcours();
            Reset();
            textID.Text = "0";
            textID.Tag = new NetworkObjects.Competition();
            UpdateEnablement();
        }

        private void listViewCompetitionTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.CompetitionTeam ct = listViewCompetitionTeam.SelectedItems[0].Tag as NetworkObjects.CompetitionTeam;
                DateTime takeOff = new DateTime(ct.TimeTakeOff);
                date.Value = takeOff;
                timeTakeOff.Value = takeOff;
                timeStart.Value = new DateTime(ct.TimeStartLine);
                timeEnd.Value = new DateTime(ct.TimeEndLine);
                textBoxStartId.Tag = ct;
                textBoxStartId.Text = ct.StartID.ToString();

                ComboTeam comboTeam = null;
                foreach (Object o in comboBoxTeam.Items)
                {
                    if ((o as ComboTeam).p.ID == ct.ID_Team)
                    {
                        comboTeam = o as ComboTeam;
                        break;
                    }
                }
                comboBoxTeam.SelectedItem = comboTeam;

                ComboRoute route = null;
                foreach (Object o in comboBoxRoute.Items)
                {
                    ComboRoute r = o as ComboRoute;
                    if ((int)r.p == ct.Route)
                    {
                        route = r;
                        break;
                    }
                }
                comboBoxRoute.SelectedItem = route;
                foreach (ListViewItem lvi in listViewTrackers.Items)
                {
                    NetworkObjects.Tracker tracker = lvi.Tag as NetworkObjects.Tracker;
                    lvi.Checked = ct.ID_TrackerList.Contains(tracker.ID);
                }
            }
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEnablement();
            if (btnSave.Enabled)
            {
                NetworkObjects.Competition c = textID.Tag as NetworkObjects.Competition;
                c.ID = int.Parse(textID.Text);
                c.ID_Parcour = (parcours.SelectedItem as ComboParcour).p.ID;
                c.Name = textName.Text;


                Vector start = new Vector(double.Parse(takeOffLeftLongitude.Text), double.Parse(takeOffLeftLatitude.Text), 0);
                Vector end = new Vector(double.Parse(takeOffRightLongitude.Text), double.Parse(takeOffRightLatitude.Text), 0);
                Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                NetworkObjects.Line line = new NetworkObjects.Line();
                line.A = NetworkObjects.Helper.Point(start.X, start.Y, start.Z);
                line.B = NetworkObjects.Helper.Point(end.X, end.Y, end.Z);
                line.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                c.TakeOffLine = line;

                /*foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    c.CompetitionTeamList.Add(lvi.Tag as NetworkObjects.CompetitionTeam);
                }*/
                Client.saveCompetition(c);
                Reset();
                LoadCompetition();
                UpdateEnablement();
            }
        }

        private DateTime mergeDateTime(DateTime time, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0, 0);
        }


        private void listViewGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }


        private void parcours_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void takeOffLeftLongitude_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void takeOffLeftLatitude_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void takeOffRightLongitude_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void takeOffRightLatitude_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void listViewCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCompetition.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewCompetition.SelectedItems[0];
                NetworkObjects.Competition c = lvi.Tag as NetworkObjects.Competition;
                textID.Text = c.ID.ToString();
                textID.Tag = c;
                textName.Text = c.Name;
                ComboParcour cp = null;
                foreach (Object o in parcours.Items)
                {
                    if ((o as ComboParcour).p.ID == c.ID_Parcour)
                    {
                        cp = o as ComboParcour;
                        break;
                    }
                }
                parcours.SelectedItem = cp;
                takeOffLeftLongitude.Text = c.TakeOffLine.A.longitude.ToString();
                takeOffLeftLatitude.Text = c.TakeOffLine.A.latitude.ToString();
                takeOffRightLatitude.Text = c.TakeOffLine.B.latitude.ToString();
                takeOffRightLongitude.Text = c.TakeOffLine.B.longitude.ToString();
                updateList(c);
            }
            else
            {
                Reset();
            }
            UpdateEnablement();
        }

        private void updateList(NetworkObjects.Competition c)
        {

            listViewCompetitionTeam.Items.Clear();
            c.CompetitionTeamList.Sort((p,q)=>p.StartID.CompareTo(q.StartID));
            foreach (NetworkObjects.CompetitionTeam ct in c.CompetitionTeamList)
            {
                ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(), ct.ID_Team.ToString(), getTeamAC(ct.ID_Team), getTeamDsc(ct.ID_Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                lvi2.Tag = ct;
                listViewCompetitionTeam.Items.Add(lvi2);
            }
            listViewCompetitionTeam.Sort();
        }
        private string getTeamAC(int ID_Team)
        {
            return Client.getTeam(ID_Team).Description;
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

        private void btnNewCompetitionTeam_Click(object sender, EventArgs e)
        {
            int starID = 0;
            NetworkObjects.Competition c = textID.Tag as NetworkObjects.Competition;
            if (c != null && c.CompetitionTeamList.Count > 0)
            {
                foreach (NetworkObjects.CompetitionTeam ct in c.CompetitionTeamList)
                {
                    starID = Math.Max(starID, ct.StartID) + 1;
                }
            }

            textBoxStartId.Text = starID.ToString();
            textBoxStartId.Tag = new NetworkObjects.CompetitionTeam();
            if (comboBoxTeam.SelectedIndex == -1)
            {
                comboBoxRoute.SelectedIndex = 0;
                comboBoxTeam.SelectedIndex = 0;
            }
            UpdateEnablement();
        }

        private void btnDeleteCompetitionTeam_Click(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1 && listViewCompetition.SelectedItems.Count == 1)
            {
                NetworkObjects.CompetitionTeam ct = listViewCompetitionTeam.SelectedItems[0].Tag as NetworkObjects.CompetitionTeam;
                NetworkObjects.Competition c = listViewCompetition.SelectedItems[0].Tag as NetworkObjects.Competition;
                c.CompetitionTeamList.RemoveAll(p => p == ct);
                listViewCompetition_SelectedIndexChanged(null, null);
            }
            UpdateEnablement();
        }

        private void btnSaveCompetitionTeam_Click(object sender, EventArgs e)
        {
            NetworkObjects.CompetitionTeam ct = textBoxStartId.Tag as NetworkObjects.CompetitionTeam;
            NetworkObjects.Competition c = textID.Tag as NetworkObjects.Competition;
            if (c != null && ct != null)
            {
                c.CompetitionTeamList.RemoveAll(p => p == ct);
                ct.StartID = Int32.Parse(textBoxStartId.Text);
                DateTime TakeOff = mergeDateTime(timeTakeOff.Value, date.Value);
                DateTime Start = mergeDateTime(timeStart.Value, date.Value);
                DateTime End = mergeDateTime(timeEnd.Value, date.Value);
                ct.TimeTakeOff = TakeOff.Ticks;
                ct.TimeStartLine = Start.Ticks;
                ct.TimeEndLine = End.Ticks;
                ComboTeam comboTeam = comboBoxTeam.SelectedItem as ComboTeam;
                ct.ID_Team = comboTeam.p.ID;
                ComboRoute route = comboBoxRoute.SelectedItem as ComboRoute;
                ct.Route = (int)(route.p);
                ct.ID_TrackerList.Clear();
                foreach (ListViewItem lvi in listViewTrackers.Items)
                {
                    if (lvi.Checked)
                    {
                        NetworkObjects.Tracker tracker = lvi.Tag as NetworkObjects.Tracker;
                        ct.ID_TrackerList.Add(tracker.ID);
                    }
                }
                c.CompetitionTeamList.Add(ct);

                updateList(c);
                
               
            }
            UpdateEnablement();
        }

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateEnablement();
        }

        private void textBoxStartId_TextChanged(object sender, EventArgs e)
        {

            UpdateEnablement();
        }

        private void comboBoxRoute_SelectedIndexChanged(object sender, EventArgs e)
        {

            UpdateEnablement();
        }

        private void btnExportToPDF_Click(object sender, EventArgs e)
        {
            NetworkObjects.Competition c = textID.Tag as NetworkObjects.Competition;
            if (c != null)
            {
            String dirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\AirNavigationRace\";
            DirectoryInfo di = Directory.CreateDirectory(dirPath);
            if (!di.Exists)
            {
                di.Create();
            }
            PDFCreator.CreateStartListPDF(c, Client, dirPath +
                @"\StartList_" +  c.ID+"_"+c.Name+"_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
        }
        }

        private void btnAddCompetitionTeam_Click(object sender, EventArgs e)
        {
            btnSaveCompetitionTeam_Click(sender, e);
            int startid = int.Parse(textBoxStartId.Text.ToString());
            startid++;
            textBoxStartId.Text = startid.ToString();
            //Route um eins erhöhen
            if (comboBoxRoute.SelectedIndex == comboBoxRoute.Items.Count - 1)
            {
                comboBoxRoute.SelectedIndex = 0;
                timeStart.Value = timeStart.Value.AddMinutes(timeParcourIntervall.Value.Minute);
                timeEnd.Value = timeStart.Value.AddMinutes(timeParcourLength.Value.Minute);
                timeTakeOff.Value = timeTakeOff.Value.AddMinutes(timeParcourIntervall.Value.Minute - ((comboBoxRoute.Items.Count-1) * timeTakeOffIntervall.Value.Minute));
            }
            else
            {
                comboBoxRoute.SelectedIndex += 1;
                timeTakeOff.Value = timeTakeOff.Value.AddMinutes(timeTakeOffIntervall.Value.Minute);
            }
            if (comboBoxTeam.SelectedIndex != comboBoxTeam.Items.Count - 1)
            {
                comboBoxTeam.SelectedIndex += 1;
            }
            btnNewCompetitionTeam_Click(sender, e);

        }

        
    }
    class ComboParcour
    {
        public NetworkObjects.Parcour p;
        public ComboParcour(NetworkObjects.Parcour p)
        {
            this.p = p;
        }

        public override string ToString()
        {
            return p.ID + " " + p.Name;
        }
    }
    class ComboTeam
    {
        public NetworkObjects.Team p;
        private String toString;
        public ComboTeam(NetworkObjects.Team p, String toString)
        {
            this.p = p;
            this.toString = toString;
        }

        public override string ToString()
        {
            return p.ID + " " + toString;
        }
    }
    class ComboRoute
    {
        public NetworkObjects.Route p;
        public ComboRoute(NetworkObjects.Route p)
        {
            this.p = p;
        }

        public override string ToString()
        {
            return p.ToString();
        }
    }
}
