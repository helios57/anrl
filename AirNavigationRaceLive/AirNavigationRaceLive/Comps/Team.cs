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
    public partial class Team : UserControl
    {
        private Client.Client Client;
        private bool newTeam;

        public Team(Client.Client iClient)
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
            List<NetworkObjects.Pilot> pilots = Client.getPilots();
            List<NetworkObjects.Team> teams = Client.getTeams();
            listViewTeam.Items.Clear();
            foreach (NetworkObjects.Team team in teams)
            {
                NetworkObjects.Pilot pilot;
                NetworkObjects.Pilot navigator = null;
                if (pilots.Count(p => p.ID == team.ID_Pilot) == 1)
                {
                    pilot = pilots.Single(p => p.ID == team.ID_Pilot);
                }
                else
                {
                    pilot = Client.getPilot(team.ID_Pilot);
                }
                if (team.ID_Navigator > 0)
                {
                    if (pilots.Count(p => p.ID == team.ID_Navigator) == 1)
                    {
                        navigator = pilots.Single(p => p.ID == team.ID_Navigator);
                    }
                    else
                    {
                        navigator = Client.getPilot(team.ID_Navigator);
                    }
                }

                ListViewItem lvi = new ListViewItem(new string[] {team.StartID, team.Name != null ? team.Name : "", pilot.Name, (navigator != null) ? navigator.Name : "-", team.Description, team.Color });
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
            foreach (NetworkObjects.Pilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.Name, p.Surename });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            List<NetworkObjects.Tracker> trackers = Client.getTrackers();
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
            textBoxName.Enabled = teamSelected;
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
                textBoxPilot.Text = ((NetworkObjects.Pilot)listViewPilots.SelectedItems[0].Tag).Name;
            }
            UpdateEnablement();
        }

        private void btnAddNavigator_Click(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                textBoxNavigator.Tag = listViewPilots.SelectedItems[0].Tag;
                textBoxNavigator.Text = ((NetworkObjects.Pilot)listViewPilots.SelectedItems[0].Tag).Name;
            }
            UpdateEnablement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetFields();
            newTeam = true;
            textBoxID.Text = "-1";
            int id = 1;
            foreach (ListViewItem lvi in listViewTeam.Items)
            {
                NetworkObjects.Team team = lvi.Tag as NetworkObjects.Team;
                try {
                    int startId = int.Parse(team.StartID);
                    id = Math.Max(id, startId);
                }catch(Exception ex)
                {
                    //ignore
                }
            }

            textBoxCNumber.Text = ""+ (id+1);
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((textBoxID.Tag != null || newTeam) && textBoxPilot.Tag != null)
            {
                NetworkObjects.Team team = new NetworkObjects.Team();
                team.ID = Math.Max(Int32.Parse(textBoxID.Text), 0);
                team.ID_Pilot = (textBoxPilot.Tag as NetworkObjects.Pilot).ID;
                team.Name = textBoxName.Text;
                team.Description = fldAC.Text;
                team.StartID = textBoxCNumber.Text;
                if (textBoxNavigator.Tag != null)
                {
                    team.ID_Navigator = (textBoxNavigator.Tag as NetworkObjects.Pilot).ID;
                }
                team.Color = btnColorSelect.BackColor.Name;
                int id = Client.saveTeam(team);
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
            textBoxName.Text = "";
            fldAC.Text = "";
            textBoxCNumber.Text = "";
        }

        private void listViewTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.Team team = listViewTeam.SelectedItems[0].Tag as NetworkObjects.Team;
                textBoxID.Tag = team;
                textBoxID.Text = team.ID.ToString();
                textBoxName.Text = team.Name;
                NetworkObjects.Pilot pilot = Client.getPilot(team.ID_Pilot);
                NetworkObjects.Pilot navigator = null;
                if (team.ID_Navigator > 0)
                {
                    navigator = Client.getPilot(team.ID_Navigator);
                }
                textBoxPilot.Tag = pilot;
                textBoxPilot.Text = pilot.Name;
                textBoxNavigator.Tag = navigator;
                textBoxNavigator.Text = (navigator != null) ? navigator.Name : "";
                fldAC.Text = team.Description;
                textBoxCNumber.Text = team.StartID;
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
            PDFCreator.CreateTeamsPDF(Client.getTeams(), Client, dirPath +
                @"\CrewsPrintout_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");

        }
    }
}
