using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;
using System.IO;

namespace AirNavigationRaceLive.Comps
{
    public partial class TeamControl : UserControl
    {
        private Client.DataAccess Client;
        private bool newTeam;

        public TeamControl(Client.DataAccess iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void Team_Load(object sender, EventArgs e)
        {
            UpdateListe();
            UpdateEnablement();
        }

        private void UpdateListe()
        {
            resetFields();
            List<Subscriber> pilots = Client.SelectedCompetition.Subscriber.ToList();
            List<Team> teams = Client.SelectedCompetition.Team.ToList();
            listViewTeam.Items.Clear();
            foreach (Team team in teams)
            {
                ListViewItem lvi = new ListViewItem(new string[] {team.CNumber, team.Nationality != null ? team.Nationality : "", team.Pilot.LastName, (team.Navigator != null) ? team.Navigator.LastName : "-", team.AC, team.Color });
                lvi.UseItemStyleForSubItems = false;
                lvi.Tag = team;
                Color c =Color.FromName(team.Color);
                lvi.SubItems[5].BackColor = c;
               
                if (c.A == 0 && c.B == 0 && c.G == 0 && c.R == 0)
                {
                    ColorConverter cc = new ColorConverter();
                    lvi.SubItems[5].BackColor = (Color)cc.ConvertFromString("#"+team.Color);
                }
                listViewTeam.Items.Add(lvi);
            }
            listViewPilots.Items.Clear();
            foreach (Subscriber p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.LastName, p.FirstName });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
        }

        private void UpdateEnablement()
        {
            Boolean teamSelected = (listViewTeam.SelectedItems.Count == 1 || newTeam);
            Boolean pilotSelected = (listViewPilots.SelectedItems.Count == 1);
            btnSave.Enabled = teamSelected;
            btnClearNavigator.Enabled = teamSelected && textBoxNavigator.Tag != null;
            btnClearPilot.Enabled = teamSelected && textBoxPilot.Tag != null;
            btnAddNavigator.Enabled = teamSelected && pilotSelected && textBoxNavigator.Tag == null;
            btnAddPilot.Enabled = teamSelected && pilotSelected && textBoxPilot.Tag == null;
            btnSave.Enabled = teamSelected && textBoxPilot.Tag != null /*&& comboBoxCountry.SelectedItem != null*/;
            btnColorSelect.Enabled = teamSelected;
            fldAC.Enabled = teamSelected;
            textBoxNationality.Enabled = teamSelected;
            textBoxCNumber.Enabled = teamSelected;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateListe();
            UpdateEnablement();
        }

        private void btnClearPilot_Click(object sender, EventArgs e)
        {
            textBoxPilot.Tag = null;
            textBoxPilot.Text = "";
            UpdateEnablement();
        }

        private void btnClearNavigator_Click(object sender, EventArgs e)
        {
            textBoxNavigator.Tag = null;
            textBoxNavigator.Text = "";
            UpdateEnablement();
        }

        private void btnAddPilot_Click(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                textBoxPilot.Tag = listViewPilots.SelectedItems[0].Tag;
                textBoxPilot.Text = ((Subscriber)listViewPilots.SelectedItems[0].Tag).LastName;
            }
            UpdateEnablement();
        }

        private void btnAddNavigator_Click(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                textBoxNavigator.Tag = listViewPilots.SelectedItems[0].Tag;
                textBoxNavigator.Text = ((Subscriber)listViewPilots.SelectedItems[0].Tag).LastName;
            }
            UpdateEnablement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetFields();
            newTeam = true;
            textBoxID.Text = "-1";
            int id = 0;
            foreach (ListViewItem lvi in listViewTeam.Items)
            {
                Team team = lvi.Tag as Team;
                int startId = Int32.Parse(team.CNumber);
                id = Math.Max(id, startId);
            }
            textBoxCNumber.Text = ""+ (id+1);
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textBoxPilot.Tag != null)
            {
                Team team;

                if (textBoxID.Tag == null || newTeam)
                {
                    team = new Team();
                    team.Competition = Client.SelectedCompetition;
                }
                else
                {
                    team = textBoxID.Tag as Team;
                }
                    
                    
                team.Pilot = textBoxPilot.Tag as Subscriber;
                team.Nationality = textBoxNationality.Text;
                team.AC = fldAC.Text;
                team.CNumber = textBoxCNumber.Text;
                team.Navigator = textBoxNavigator.Tag as Subscriber;
                team.Color = btnColorSelect.BackColor.Name;
                if (team.Id==0)
                {
                    Client.DBContext.TeamSet.Add(team);
                }
                Client.DBContext.SaveChanges();
                resetFields();
                UpdateEnablement();
            }
            UpdateListe();
            UpdateEnablement();
        }
        private void resetFields()
        {
            newTeam = false;
            textBoxID.Tag = null;
            textBoxID.Text = "";
            textBoxPilot.Tag = null;
            textBoxPilot.Text = "";
            textBoxNavigator.Tag = null;
            textBoxNavigator.Text = "";
            btnColorSelect.BackColor = Color.Gray;
            textBoxNationality.Text = "";
            fldAC.Text = "";
            textBoxCNumber.Text = "";
        }

        private void listViewTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                Team team = listViewTeam.SelectedItems[0].Tag as Team;
                textBoxID.Tag = team;
                textBoxID.Text = team.Id.ToString();
                textBoxNationality.Text = team.Nationality;
                Subscriber pilot = team.Pilot;
                Subscriber navigator = team.Navigator;
                textBoxPilot.Tag = pilot;
                textBoxPilot.Text = pilot.LastName;
                textBoxNavigator.Tag = navigator;
                textBoxNavigator.Text = (navigator != null) ? navigator.LastName : "";
                fldAC.Text = team.AC;
                textBoxCNumber.Text = team.CNumber;
                btnColorSelect.BackColor = Color.FromName(team.Color.Trim());
            }
            else
            {
                resetFields();
            }
            UpdateEnablement();
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }


        private void listViewTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnColorSelect_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = false;
            cd.SolidColorOnly = true;
            cd.ShowDialog();
            btnColorSelect.BackColor = cd.Color;
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            String dirPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + @"\AirNavigationRace\";
            DirectoryInfo di = Directory.CreateDirectory(dirPath);
            if (!di.Exists)
            {
                di.Create();
            }
            PDFCreator.CreateTeamsPDF(Client.SelectedCompetition.Team.ToList(), Client, dirPath +
                @"\CrewsPrintout_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");

        }
    }
}
