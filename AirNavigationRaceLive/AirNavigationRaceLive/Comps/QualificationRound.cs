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
using System.Globalization;

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
            lblTitel.Text = lblTitel.Text + iClient.getSelectedCompetitionSet().Name;

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.Show();
        }

        private void LoadCompetition()
        {
            List<t_Competition> comps = Client.getCompetitions();
            listViewCompetition.Items.Clear();
            foreach (t_Competition c in comps)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.ID.ToString(), c.Name });
                lvi.Tag = c;
                listViewCompetition.Items.Add(lvi);
            }
            UpdateEnablement();
        }
        private void LoadTeams()
        {
            List<t_Team> teams = Client.getTeams();
            comboBoxTeam.Items.Clear();
            foreach (t_Team t in teams)
            {
                comboBoxTeam.Items.Add(new ComboTeam(t, getTeamDsc(t.ID)));
            }
            List<t_Tracker> trackers = Client.getTrackers();
            listViewTrackers.Items.Clear();
            foreach (t_Tracker t in trackers)
            {
                ListViewItem lvi = new ListViewItem(new string[] { t.ID.ToString(), t.Name, t.IMEI });
                lvi.Tag = t;
                listViewTrackers.Items.Add(lvi);
            }

            if (comboBoxTeam.Items.Count > 0)
            {
                comboBoxTeam.SelectedIndex = 0;
            }
            UpdateEnablement();
        }
        private void LoadParcours()
        {
            List<t_Parcour> parcour = Client.getParcours();
            parcours.Items.Clear();
            foreach (t_Parcour c in parcour)
            {
                ComboParcour cp = new ComboParcour(c);
                parcours.Items.Add(cp);
            }
            if (parcours.Items.Count > 0) {
                parcours.SelectedIndex = 0;
            }
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
                double.Parse(s, NumberFormatInfo.InvariantInfo);
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
                t_Competition c = listViewCompetition.SelectedItems[0].Tag as t_Competition;
                Client.deleteCompetition(c.ID);
                LoadCompetition();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadParcours();
            Reset();
            textID.Text = "0";
            textID.Tag = new t_Competition();
            UpdateEnablement();
        }

        private void listViewCompetitionTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                t_Competition_Team ct = listViewCompetitionTeam.SelectedItems[0].Tag as t_Competition_Team;
                DateTime takeOff = new DateTime(ct.TimeTakeOff);
                date.Value = takeOff;
                timeTakeOff.Value = takeOff;
                timeStart.Value = new DateTime(ct.TimeStart);
                timeEnd.Value = new DateTime(ct.TimeEnd);
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
                    t_Tracker tracker = lvi.Tag as t_Tracker;
                    lvi.Checked = ct.t_Tracker.Any(p=>p.ID==tracker.ID);
                }
            }
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEnablement();
            if (btnSave.Enabled)
            {
                t_Competition c = textID.Tag as t_Competition;
                c.ID = int.Parse(textID.Text);
                c.ID_Parcour = (parcours.SelectedItem as ComboParcour).p.ID;
                c.Name = textName.Text;


                Vector start = new Vector(double.Parse(takeOffLeftLongitude.Text, NumberFormatInfo.InvariantInfo), double.Parse(takeOffLeftLatitude.Text, NumberFormatInfo.InvariantInfo), 0);
                Vector end = new Vector(double.Parse(takeOffRightLongitude.Text, NumberFormatInfo.InvariantInfo), double.Parse(takeOffRightLatitude.Text, NumberFormatInfo.InvariantInfo), 0);
                Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                t_Line line = new t_Line();
                line.A = Factory.newGPSPoint(start.X, start.Y, start.Z);
                line.B = Factory.newGPSPoint(end.X, end.Y, end.Z);
                line.O = Factory.newGPSPoint(o.X, o.Y, o.Z);
                c.TakeOffLine = line;

                /*foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    c.CompetitionTeamList.Add(lvi.Tag as t_Competition_Team);
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
                t_Competition c = lvi.Tag as t_Competition;
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

        private void updateList(t_Competition c)
        {

            listViewCompetitionTeam.Items.Clear();
            List<t_Competition_Team> teams = new List<t_Competition_Team>(c.t_Competition_Team);
            teams.Sort((p,q)=>p.StartID.CompareTo(q.StartID));
            foreach (t_Competition_Team ct in teams)
            {
                ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(), getTeamCNumber(ct.ID_Team), getTeamAC(ct.ID_Team), getTeamDsc(ct.ID_Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStart).ToShortTimeString(), new DateTime(ct.TimeEnd).ToShortTimeString(), getRouteText(ct.Route) });
                lvi2.Tag = ct;
                listViewCompetitionTeam.Items.Add(lvi2);
            }
            listViewCompetitionTeam.Sort();
        }
        private string getTeamCNumber(int ID_Team)
        {
            return Client.getTeam(ID_Team).StartID;
        }
        private string getTeamAC(int ID_Team)
        {
            return Client.getTeam(ID_Team).Description;
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

        private void btnNewCompetitionTeam_Click(object sender, EventArgs e)
        {
            int starID = 1;
            t_Competition c = textID.Tag as t_Competition;
            if (c != null && c.t_Competition_Team.Count > 0)
            {
                foreach (t_Competition_Team ct in c.t_Competition_Team)
                {
                    starID = Math.Max(starID, ct.StartID) + 1;
                }
            }

            textBoxStartId.Text = starID.ToString();
            textBoxStartId.Tag = new t_Competition_Team();
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
                t_Competition_Team ct = listViewCompetitionTeam.SelectedItems[0].Tag as t_Competition_Team;
                t_Competition c = listViewCompetition.SelectedItems[0].Tag as t_Competition;
                List<t_Competition_Team> toDelete= c.t_Competition_Team.Where(p => p == ct).ToList();
                foreach(t_Competition_Team t in toDelete)
                {
                    c.t_Competition_Team.Remove(t);
                }
                listViewCompetition_SelectedIndexChanged(null, null);
            }
            UpdateEnablement();
        }

        private void btnSaveCompetitionTeam_Click(object sender, EventArgs e)
        {
            t_Competition_Team ct = textBoxStartId.Tag as t_Competition_Team;
            t_Competition c = textID.Tag as t_Competition;
            if (c != null && ct != null)
            {
                List<t_Competition_Team> toDelete = c.t_Competition_Team.Where(p => p == ct).ToList();
                foreach (t_Competition_Team t in toDelete)
                {
                    c.t_Competition_Team.Remove(t);
                }
                ct.StartID = Int32.Parse(textBoxStartId.Text);
                DateTime TakeOff = mergeDateTime(timeTakeOff.Value, date.Value);
                DateTime Start = mergeDateTime(timeStart.Value, date.Value);
                DateTime End = mergeDateTime(timeEnd.Value, date.Value);
                ct.TimeTakeOff = TakeOff.Ticks;
                ct.TimeStart = Start.Ticks;
                ct.TimeEnd = End.Ticks;
                ComboTeam comboTeam = comboBoxTeam.SelectedItem as ComboTeam;
                ct.ID_Team = comboTeam.p.ID;
                ComboRoute route = comboBoxRoute.SelectedItem as ComboRoute;
                ct.Route = (int)(route.p);
                ct.t_Tracker.Clear();
                foreach (ListViewItem lvi in listViewTrackers.Items)
                {
                    if (lvi.Checked)
                    {
                        t_Tracker tracker = lvi.Tag as t_Tracker;
                        ct.t_Tracker.Add(tracker);
                    }
                }
                c.t_Competition_Team.Add(ct);

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
            t_Competition c = textID.Tag as t_Competition;
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
        public t_Parcour p;
        public ComboParcour(t_Parcour p)
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
        public t_Team p;
        private String toString;
        public ComboTeam(t_Team p, String toString)
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
