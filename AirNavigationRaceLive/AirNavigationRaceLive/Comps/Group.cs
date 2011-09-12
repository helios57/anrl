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
    public partial class Group : UserControl
    {
        private Client.Client Client;

        public Group(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }


        private void Group_Load(object sender, EventArgs e)
        {
            ResetFields();
            LoadGroups();
            LoadTeams();
        }
        private void LoadGroups()
        {
            List<NetworkObjects.Group> groups = Client.getGroups();
            ResetFields();
            listViewGroup.Items.Clear();
            foreach (NetworkObjects.Group g in groups)
            {
                ListViewItem lvi = new ListViewItem(new String[] { g.ID.ToString(), g.Name != null ? g.Name : "" });
                lvi.Tag = g;
                listViewGroup.Items.Add(lvi);
            }
            UpdateEnablement();
        }
        private void LoadTeams()
        {
            List<NetworkObjects.Team> teams = Client.getTeams();
            listViewTeam.Items.Clear();
            foreach (NetworkObjects.Team t in teams)
            {
                ListViewItem lvi = new ListViewItem(new String[] { t.ID.ToString(), getTeamText(t) });
                lvi.Tag = t;
                listViewTeam.Items.Add(lvi);
            }
            UpdateEnablement();
        }
        private string getTeamText(NetworkObjects.Team t)
        {
            string result = "";
            if (t.Name != null && t.Name !="")
            {
                result = t.Name;
            }
            else
            {
                result = Client.getPilot(t.ID_Pilot).Name;
                if (t.ID_Navigator!= 0)
                {
                    result += " + " + Client.getPilot(t.ID_Navigator).Name;
                }
            }
            return result;
        }

        private void UpdateEnablement()
        {
            bool GroupSelected = listViewGroup.SelectedItems.Count == 1;
            btnDeleteGroup.Enabled = GroupSelected;
            btnSave.Enabled = textID.Text != "";
            listViewTeam.Enabled = btnSave.Enabled;
            if (!btnSave.Enabled)
            {
                listViewTeam.SelectedItems.Clear();
            }
            bool TeamSelected = listViewTeam.SelectedItems.Count == 1;
            btnAddSelectedA.Enabled = TeamSelected && textTeamA.Tag == null;
            btnAddSelectedB.Enabled = TeamSelected && textTeamB.Tag == null && textTeamA.Tag != null;
            btnAddSelectedC.Enabled = TeamSelected && textTeamC.Tag == null && textTeamB.Tag != null;
            btnAddSelectedD.Enabled = TeamSelected && textTeamD.Tag == null && textTeamC.Tag != null;

            btnClearA.Enabled = btnSave.Enabled && textTeamA.Tag != null;
            btnClearB.Enabled = btnSave.Enabled && textTeamB.Tag != null;
            btnClearC.Enabled = btnSave.Enabled && textTeamC.Tag != null;
            btnClearD.Enabled = btnSave.Enabled && textTeamD.Tag != null;
        }

        private void ResetFields()
        {
            listViewTeam.SelectedItems.Clear();
            textID.Text = "";
            textName.Text = "";
            textTeamA.Tag = null;
            textTeamB.Tag = null;
            textTeamC.Tag = null;
            textTeamD.Tag = null;
            textTeamA.Text = "";
            textTeamB.Text = "";
            textTeamC.Text = "";
            textTeamD.Text = "";
            UpdateEnablement();
        }

        private void listViewGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewGroup.SelectedItems.Count == 1)
            {
                ResetFields();
                NetworkObjects.Group g = listViewGroup.SelectedItems[0].Tag as NetworkObjects.Group;
                textID.Text = g.ID.ToString();
                textName.Text = g.Name;
                foreach (NetworkObjects.GroupTeam gt in g.GroupTeamList)
                {
                    NetworkObjects.Team p = Client.getTeam(gt.ID_Team);
                    switch ((NetworkObjects.GroupPosType)gt.Pos)
                    {
                        case NetworkObjects.GroupPosType.A:
                            {
                                textTeamA.Text = getTeamText(p);
                                textTeamA.Tag = p;
                                break;
                            }
                        case NetworkObjects.GroupPosType.B:
                            {
                                textTeamB.Text = getTeamText(p);
                                textTeamB.Tag = p;
                                break;
                            }
                        case NetworkObjects.GroupPosType.C:
                            {
                                textTeamC.Text = getTeamText(p);
                                textTeamC.Tag = p;
                                break;
                            }
                        case NetworkObjects.GroupPosType.D:
                            {
                                textTeamD.Text = getTeamText(p);
                                textTeamD.Tag = p;
                                break;
                            }
                    }
                }
                UpdateEnablement();
            }
        }

        private void listViewTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {
            LoadGroups();
        }

        private void btnDeleteGroup_Click(object sender, EventArgs e)
        {

            if (listViewGroup.SelectedItems.Count == 1)
            {
                NetworkObjects.Group g = listViewGroup.SelectedItems[0].Tag as NetworkObjects.Group;
                Client.deleteGroup(g.ID);
                LoadGroups();
            }
        }

        private void btnRefreshTeam_Click(object sender, EventArgs e)
        {
            LoadTeams();
        }

        private void btnAddSelectedA_Click(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.Team team = listViewTeam.SelectedItems[0].Tag as NetworkObjects.Team;
                textTeamA.Tag = team;
                textTeamA.Text = getTeamText(team);
                listViewTeam.SelectedItems.Clear();
                UpdateEnablement();
            }
        }

        private void btnClearA_Click(object sender, EventArgs e)
        {
            textTeamA.Tag = null;
            textTeamA.Text = "";
            UpdateEnablement();
        }

        private void btnAddSelectedB_Click(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.Team team = listViewTeam.SelectedItems[0].Tag as NetworkObjects.Team;
                textTeamB.Tag = team;
                textTeamB.Text = getTeamText(team);
                listViewTeam.SelectedItems.Clear();
                UpdateEnablement();
            }
        }

        private void btnClearB_Click(object sender, EventArgs e)
        {
            textTeamB.Tag = null;
            textTeamB.Text = "";
            UpdateEnablement();
        }

        private void btnAddSelectedC_Click(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.Team team = listViewTeam.SelectedItems[0].Tag as NetworkObjects.Team;
                textTeamC.Tag = team;
                textTeamC.Text = getTeamText(team);
                listViewTeam.SelectedItems.Clear();
                UpdateEnablement();
            }

        }

        private void btnClearC_Click(object sender, EventArgs e)
        {
            textTeamC.Tag = null;
            textTeamC.Text = "";
            UpdateEnablement();
        }

        private void btnAddSelectedD_Click(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                NetworkObjects.Team team = listViewTeam.SelectedItems[0].Tag as NetworkObjects.Team;
                textTeamD.Tag = team;
                textTeamD.Text = getTeamText(team);
                listViewTeam.SelectedItems.Clear();
                UpdateEnablement();
            }
        }

        private void btnClearD_Click(object sender, EventArgs e)
        {
            textTeamD.Tag = null;
            textTeamD.Text = "";
            UpdateEnablement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textID.Text = "0";
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NetworkObjects.Group g;
            if (textID.Text != "0" && listViewGroup.SelectedItems.Count == 1)
            {
                g = listViewGroup.SelectedItems[0].Tag as NetworkObjects.Group;
            }
            else
            {
                g = new NetworkObjects.Group();
                g.ID = 0;
            }
            g.Name = textName.Text;
            #region teams
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (textTeamA.Tag != null)
                            {
                                NetworkObjects.GroupTeam gt = new NetworkObjects.GroupTeam();
                                gt.ID_Team = (textTeamA.Tag as NetworkObjects.Team).ID;
                                gt.Pos = (int)NetworkObjects.GroupPosType.A;
                                g.GroupTeamList.Add(gt);
                            }
                            break;
                        }
                    case 1:
                        {
                            if (textTeamB.Tag != null)
                            {
                                NetworkObjects.GroupTeam gt = new NetworkObjects.GroupTeam();
                                gt.ID_Team = (textTeamB.Tag as NetworkObjects.Team).ID;
                                gt.Pos = (int)NetworkObjects.GroupPosType.B;
                                g.GroupTeamList.Add(gt);
                            }
                            break;
                        }
                    case 2:
                        {
                            if (textTeamC.Tag != null)
                            {
                                NetworkObjects.GroupTeam gt = new NetworkObjects.GroupTeam();
                                gt.ID_Team = (textTeamC.Tag as NetworkObjects.Team).ID;
                                gt.Pos = (int)NetworkObjects.GroupPosType.C;
                                g.GroupTeamList.Add(gt);
                            }
                            break;
                        }
                    case 3:
                        {
                            if (textTeamD.Tag != null)
                            {
                                NetworkObjects.GroupTeam gt = new NetworkObjects.GroupTeam();
                                gt.ID_Team = (textTeamD.Tag as NetworkObjects.Team).ID;
                                gt.Pos = (int)NetworkObjects.GroupPosType.D;
                                g.GroupTeamList.Add(gt);
                            }
                            break;
                        }
                }
            }
            #endregion
            Client.saveGroup(g);
            LoadGroups();
        }
    }
}
