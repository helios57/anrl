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

        private void UpdateEnablement()
        {

        }

        private void Competition_Load(object sender, EventArgs e)
        {

        }

        private void btnRefreshCompetitions_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCompetitions_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void listViewSelectedGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        }

        private void btnAddToCompetition_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {

        }
    }
}
