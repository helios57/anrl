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
    public partial class QualificationRoundControl : UserControl
    {
        private Client.DataAccess Client;

        public QualificationRoundControl(Client.DataAccess iClient)
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
            lblTitel.Text = lblTitel.Text + iClient.SelectedCompetition.Name;

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            Calculator c = new Calculator();
            c.Show();
        }

        private void LoadCompetition()
        {
            List<QualificationRound> comps = Client.SelectedCompetition.QualificationRound.ToList();
            listViewCompetition.Items.Clear();
            foreach (QualificationRound c in comps)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.Id.ToString(), c.Name });
                lvi.Tag = c;
                listViewCompetition.Items.Add(lvi);
            }
            UpdateEnablement();
        }
        private void LoadTeams()
        {
            List<Team> teams = Client.SelectedCompetition.Team.ToList();
            comboBoxTeam.Items.Clear();
            foreach (Team t in teams)
            {
                comboBoxTeam.Items.Add(new ComboTeam(t, getTeamDsc(t)));
            }
            if (comboBoxTeam.Items.Count > 0)
            {
                comboBoxTeam.SelectedIndex = 0;
            }
            UpdateEnablement();
        }
        private void LoadParcours()
        {
            List<Parcour> parcour = Client.SelectedCompetition.Parcour.ToList();
            parcours.Items.Clear();
            foreach (Parcour c in parcour)
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
            bool Ediable = textName.Text != "";
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
            textName.Text = "";
            parcours.SelectedItem = null;
            parcours.Text = "";
            takeOffLeftLatitude.Text = "47.97426";
            takeOffLeftLongitude.Text = "8.52242";
            takeOffRightLatitude.Text = "47.97425";
            takeOffRightLongitude.Text = "8.52188";
            textBoxStartId.Text = "";
            textBoxStartId.Tag = null;
            comboBoxTeam.SelectedItem = null;
            comboBoxRoute.SelectedItem = null;
            listViewCompetitionTeam.Items.Clear();
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
                QualificationRound c = listViewCompetition.SelectedItems[0].Tag as QualificationRound;
                Client.DBContext.QualificationRoundSet.Remove(c);
                Client.DBContext.SaveChanges();
                LoadCompetition();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LoadParcours();
            Reset();
            textName.Text = "new";
            QualificationRound qualificationRound = new QualificationRound();
            qualificationRound.Competition = Client.SelectedCompetition;
            textName.Tag = qualificationRound;
            UpdateEnablement();
        }

        private void listViewCompetitionTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCompetitionTeam.SelectedItems.Count == 1)
            {
                Flight ct = listViewCompetitionTeam.SelectedItems[0].Tag as Flight;
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
                    if ((o as ComboTeam).p == ct.Team)
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
            }
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEnablement();
            if (btnSave.Enabled)
            {
                QualificationRound c = textName.Tag as QualificationRound;
                c.Parcour = (parcours.SelectedItem as ComboParcour).p;
                c.Name = textName.Text;


                Vector start = new Vector(double.Parse(takeOffLeftLongitude.Text, NumberFormatInfo.InvariantInfo), double.Parse(takeOffLeftLatitude.Text, NumberFormatInfo.InvariantInfo), 0);
                Vector end = new Vector(double.Parse(takeOffRightLongitude.Text, NumberFormatInfo.InvariantInfo), double.Parse(takeOffRightLatitude.Text, NumberFormatInfo.InvariantInfo), 0);
                Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                Line line = new Line();
                line.A = Factory.newGPSPoint(start.X, start.Y, start.Z);
                line.B = Factory.newGPSPoint(end.X, end.Y, end.Z);
                line.O = Factory.newGPSPoint(o.X, o.Y, o.Z);
                c.TakeOffLine = line;
                c.Flight.Clear();
                foreach (ListViewItem lvi in listViewCompetitionTeam.Items)
                {
                    c.Flight.Add(lvi.Tag as Flight);
                }
                if (c.Id==0)
                {
                    Client.DBContext.QualificationRoundSet.Add(c);
                }
                Client.DBContext.SaveChanges();
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
                QualificationRound c = lvi.Tag as QualificationRound;
                textName.Tag = c;
                textName.Text = c.Name;
                ComboParcour cp = null;
                foreach (Object o in parcours.Items)
                {
                    if ((o as ComboParcour).p == c.Parcour)
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

        private void updateList(QualificationRound c)
        {

            listViewCompetitionTeam.Items.Clear();
            List<Flight> teams = new List<Flight>(c.Flight);
            teams.Sort((p,q)=>p.StartID.CompareTo(q.StartID));
            foreach (Flight ct in teams)
            {
                ListViewItem lvi2 = new ListViewItem(new string[] { ct.StartID.ToString(), ct.Team.CNumber, ct.Team.AC, getTeamDsc(ct.Team), new DateTime(ct.TimeTakeOff).ToShortTimeString(), new DateTime(ct.TimeStartLine).ToShortTimeString(), new DateTime(ct.TimeEndLine).ToShortTimeString(), getRouteText(ct.Route) });
                lvi2.Tag = ct;
                listViewCompetitionTeam.Items.Add(lvi2);
            }
            listViewCompetitionTeam.Sort();
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

        private void btnNewCompetitionTeam_Click(object sender, EventArgs e)
        {
            int starID = 1;
            QualificationRound c = textName.Tag as QualificationRound;
            if (c != null && c.Flight.Count > 0)
            {
                foreach (Flight ct in c.Flight)
                {
                    starID = Math.Max(starID, ct.StartID) + 1;
                }
            }

            textBoxStartId.Text = starID.ToString();
            textBoxStartId.Tag = new Flight();
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
                Flight ct = listViewCompetitionTeam.SelectedItems[0].Tag as Flight;
                QualificationRound c = listViewCompetition.SelectedItems[0].Tag as QualificationRound;
                List<Flight> toDelete= c.Flight.Where(p => p == ct).ToList();
                foreach(Flight t in toDelete)
                {
                    c.Flight.Remove(t);
                }
                listViewCompetition_SelectedIndexChanged(null, null);
            }
            UpdateEnablement();
        }

        private void btnSaveCompetitionTeam_Click(object sender, EventArgs e)
        {
            Flight ct = textBoxStartId.Tag as Flight;
            QualificationRound c = textName.Tag as QualificationRound;
            if (c != null && ct != null)
            {
                List<Flight> toDelete = c.Flight.Where(p => p == ct).ToList();
                foreach (Flight t in toDelete)
                {
                    c.Flight.Remove(t);
                }
                ct.StartID = Int32.Parse(textBoxStartId.Text);
                DateTime TakeOff = mergeDateTime(timeTakeOff.Value, date.Value);
                DateTime Start = mergeDateTime(timeStart.Value, date.Value);
                DateTime End = mergeDateTime(timeEnd.Value, date.Value);
                ct.TimeTakeOff = TakeOff.Ticks;
                ct.TimeStartLine = Start.Ticks;
                ct.TimeEndLine = End.Ticks;
                ComboTeam comboTeam = comboBoxTeam.SelectedItem as ComboTeam;
                ct.Team = comboTeam.p;
                ComboRoute route = comboBoxRoute.SelectedItem as ComboRoute;
                ct.Route = (int)(route.p);
                c.Flight.Add(ct);
                if (c.Id==0)
                {
                    c.Competition = Client.SelectedCompetition;
                    Client.DBContext.QualificationRoundSet.Add(c);
                }
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
            QualificationRound c = textName.Tag as QualificationRound;
            if (c != null)
            {
            String dirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\AirNavigationRace\";
            DirectoryInfo di = Directory.CreateDirectory(dirPath);
            if (!di.Exists)
            {
                di.Create();
            }
            PDFCreator.CreateStartListPDF(c, Client, dirPath +
                @"\StartList_" +  c.Id+"_"+c.Name+"_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
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
        public Parcour p;
        public ComboParcour(Parcour p)
        {
            this.p = p;
        }

        public override string ToString()
        {
            return p.Name;
        }
    }
    class ComboTeam
    {
        public Team p;
        private String toString;
        public ComboTeam(Team p, String toString)
        {
            this.p = p;
            this.toString = toString;
        }

        public override string ToString()
        {
            return toString;
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
