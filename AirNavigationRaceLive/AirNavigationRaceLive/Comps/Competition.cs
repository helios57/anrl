using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Dialogs;

namespace AirNavigationRaceLive.Comps
{
    public partial class Competition : UserControl
    {
        private Client.Client Client;

        public Competition(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
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
        private void LoadGroups()
        {
            List<NetworkObjects.Group> groups = Client.getGroups();
            listViewGroups.Items.Clear();
            foreach (NetworkObjects.Group c in groups)
            {
                ListViewItem lvi = new ListViewItem(new String[] { c.ID.ToString(), c.Name });
                lvi.Tag = c;
                listViewGroups.Items.Add(lvi);
            }
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
            UpdateEnablement();
        }

        private void UpdateEnablement()
        {
            bool CompetitionSelected = listViewCompetition.SelectedItems.Count == 1;
            bool GroupSelected = listViewGroups.SelectedItems.Count == 1;
            bool CompetitionGroupSelected = listViewSelectedGroup.SelectedItems.Count == 1;
            bool Ediable = textID.Text != "";
            bool parcourSelected = parcours.SelectedItem != null;

            btnDeleteCompetitions.Enabled = CompetitionSelected;
            btnSave.Enabled = Ediable && parcourSelected;
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
            listViewSelectedGroup.Enabled = Ediable;
            btnUp.Enabled = Ediable && CompetitionGroupSelected;
            btnDown.Enabled = Ediable && CompetitionGroupSelected;
            btnAddToCompetition.Enabled = Ediable && GroupSelected;
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
            listViewSelectedGroup.Items.Clear();
            UpdateEnablement();
        }

        private void Competition_Load(object sender, EventArgs e)
        {
            LoadParcours();
            Reset();
            LoadCompetition();
            LoadGroups();
        }

        private void btnRefreshCompetitions_Click(object sender, EventArgs e)
        {
            Reset();
            LoadCompetition();
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
            textID.Text = "0";
            UpdateEnablement();
        }

        private void listViewSelectedGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {

        }

        private void listViewGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnAddToCompetition_Click(object sender, EventArgs e)
        {
            if (listViewGroups.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewGroups.SelectedItems[0];
                NetworkObjects.Group g = lvi.Tag as NetworkObjects.Group;
                //TODO
            }
        }

        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void parcours_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }
    }
    class ComboParcour
    {
        NetworkObjects.Parcour p;
        public ComboParcour(NetworkObjects.Parcour p)
        {
            this.p = p;
        }

        public override string ToString()
        {
            return p.ID + " " + p.Name;
        }
    }
}
