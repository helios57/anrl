using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

                ListViewItem lvi = new ListViewItem(new string[] { team.ID.ToString(), team.Name!=null?team.Name:"" ,pilot.Name, (navigator != null) ? navigator.Name : "-" });
                lvi.Tag = team;
                listViewTeam.Items.Add(lvi);
            }

            listViewPilots.Items.Clear();
            foreach (NetworkObjects.Pilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.Name, p.Surename });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            List<NetworkObjects.Tracker> trackers = Client.getTrackers();
            trackerListView.Items.Clear();
            foreach (NetworkObjects.Tracker t in trackers)
            {
                ListViewItem lvi = new ListViewItem(new string[] { t.ID.ToString(), t.Name, t.IMEI });
                lvi.Tag = t;
                trackerListView.Items.Add(lvi);
            }
            /*List<IPicture> flags = null;// Client.getPictures(true);
            comboBoxCountry.Items.Clear();
            foreach (IPicture p in flags)
            {
                Flag f = new Flag(p);
                comboBoxCountry.Items.Add(f);
                if (f.ToString() == "Switzerland")
                {
                    comboBoxCountry.SelectedItem = f;
                }
            }*/
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
            comboBoxCountry.Enabled = teamSelected;
            trackerListView.Enabled = teamSelected;
            textBoxName.Enabled = teamSelected;
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
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((textBoxID.Tag != null || newTeam) && textBoxPilot.Tag != null/*&& comboBoxCountry.SelectedItem != null*/)
            {
                /*IPicture flag;
                Flag f = comboBoxCountry.SelectedItem as Flag;
                flag = f.getPicture();
                TeamEntry te = new TeamEntry(,textBoxPilot.Tag as IPilot, textBoxNavigator.Tag as IPilot,textTracker.Tag as ITracker, btnColorSelect.BackColor.Name,flag);
                //Client.addTeam(te);*/
                NetworkObjects.Team team = new NetworkObjects.Team();
                team.ID = Math.Max(Int32.Parse(textBoxID.Text), 0);
                team.ID_Pilot = (textBoxPilot.Tag as NetworkObjects.Pilot).ID;
                team.Name = textBoxName.Text;
                if (textBoxNavigator.Tag != null)
                {
                    team.ID_Navigator = (textBoxNavigator.Tag as NetworkObjects.Pilot).ID;
                }
                team.Color = btnColorSelect.BackColor.Name;
                foreach (ListViewItem lvi in trackerListView.Items)
                {
                    if (lvi.Checked)
                    {
                        NetworkObjects.Tracker tracker = lvi.Tag as NetworkObjects.Tracker;
                        team.ID_Tracker.Add(tracker.ID);
                    }
                }
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
            trackerListView.SelectedItems.Clear();
            foreach (ListViewItem lvi in trackerListView.Items)
            {
                lvi.Checked = false;
            }
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
                /*
                Flag selected = null;
                String flagName = team.FlagPicture.Name.Trim();
                foreach (object o in comboBoxCountry.Items)
                {
                    Flag f = o as Flag;
                    if (f!= null && f.ToString() == flagName )
                    {
                        selected = f;
                    }
                }
                comboBoxCountry.SelectedItem = selected;*/
                btnColorSelect.BackColor = Color.FromName(team.Color.Trim());
                foreach (ListViewItem lvi in trackerListView.Items)
                {
                    NetworkObjects.Tracker tracker = lvi.Tag as NetworkObjects.Tracker;
                    lvi.Checked = team.ID_Tracker.Contains(tracker.ID);
                }
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
    }
}
