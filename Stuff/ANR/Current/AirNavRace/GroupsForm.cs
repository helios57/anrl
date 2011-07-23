using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ANR.Core;
using System.IO;

namespace ANR
{
    public partial class GroupsForm : Form
    {
        public event EventHandler SubmitButtonClick;

        
        private CompetitorGroup competitorGroup;
        private Competition competition;
        private Race race;


        public CompetitorGroup CompetitorGroup
        {
            get { return competitorGroup; }
            set { competitorGroup = value; }
        }


        private void cmdSave_Click(object sender, EventArgs e)
        {
            SubmitButtonClick(this, new EventArgs());
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public GroupsForm(Competition competition, Race race, CompetitorGroup group)
        {
            InitializeComponent();
            this.competition = competition;
            this.race = race;
            this.competitorGroup = group;
        }

        private void compUpdateGrid()
        {
            if (competition != null)
            {
                dataGridCompetitors.Columns.Clear();
                dataGridCompetitors.Columns.Add("CompetitionNumber", "Start No.");
                dataGridCompetitors.Columns.Add("AcCallsign", "AC Callsign");
                dataGridCompetitors.Columns.Add("PilotName", "Pilot Name");
                dataGridCompetitors.Columns.Add("PilotFirstName", "Pilot Firstname");
                dataGridCompetitors.Columns.Add("NavigatorName", "Navigator Name");
                dataGridCompetitors.Columns.Add("NavigatorFirstName", "Navigator Firstname");
                dataGridCompetitors.Columns.Add("Country", "County");

                dataGridCompetitors.Rows.Clear();

                CompetitorCollection avilableCompetitors = new CompetitorCollection();
                foreach(Competitor comp in competition.CompetitorCollection)
                {
                    avilableCompetitors.Add(comp);
                }
                foreach (CompetitorGroup grp in race.CompetitorGroups)
                {
                    foreach (Competitor comp in grp.Competitors)
                    {
                        avilableCompetitors.Remove(comp);
                    }
                }
                foreach (Competitor c in competition.CompetitorCollection)
                {
                    int index = dataGridCompetitors.Rows.Add(new object[] { c.CompetitionNumber, c.AcCallsign, c.PilotName, c.PilotFirstName, c.NavigatorName, c.NavigatorFirstName, c.Country });
                    dataGridCompetitors.Rows[index].Tag = c;
                }
            }
        }

        Competitor currentCompetitor = null;
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            competitorGroup.Competitors.Add(currentCompetitor);
            updateListView();
        }

        private void updateListView()
        {
            foreach(Competitor c in competitorGroup.Competitors)
            {
                ListViewItem item = listView1.Items.Add(c.CompetitionNumber + "(" + c.AcCallsign + ")\n" + c.PilotName + " / " + c.NavigatorName);
                item.Tag = c;
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            competitorGroup.Competitors.Remove((Competitor)listView1.SelectedItems[0].Tag);
        }
        
        private void dataGridCompetitors_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                currentCompetitor = (Competitor)dataGridCompetitors.SelectedRows[0].Tag;
                cmdAdd.Enabled = true;
                cmdRemove.Enabled = false;
            }
        }

        private void dataGridCompetitors_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            competitorGroup.Competitors.Add((Competitor)dataGridCompetitors.SelectedRows[0].Tag);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                cmdRemove.Enabled = true;
                cmdAdd.Enabled = false;
            }
        }

        private void GroupsForm_Load(object sender, EventArgs e)
        {
            compUpdateGrid();
        }
    }
}








//        private CompetitorCollection competitors;
//        private CompetitorCollection members;
//        private string title;
//        private string groupBoxMainTitle;
//        private string submitButtonText;
//        private Guid groupId;
//        private int groupNumber;
//        private string groupName;
//        private string parcoursPath;
//        private Parcours parcours;
        
//        private string parcoursDurationMin;
//        private string parcoursDurationSec;
//        private string takeOffTimeHour;
//        private string takeOffTimeMin;
//        private bool usesDefaultRunway;
//        private int runwayDefault;
//        private int runwayAlternative;
//        private Race race;

//        public CompetitorCollection Members
//        {
//            get { return members; }
//        }
//        public Guid GroupId
//        {
//            get { return groupId; }
//            set { groupId = value; }
//        }
//        public int GroupNumber
//        {
//            get { return groupNumber; }
//        }
//        public string GroupName
//        {
//            get { return groupName; }
//        }
//        public string ParcoursPath
//        {
//            get { return parcoursPath; }
//        }
//        public Parcours Parcours
//        {
//            get { return parcours; }
//            set { parcours = value; }
//        }
//        public string ParcoursDurationMin
//        {
//            get { return parcoursDurationMin; }
//        }
//        public string ParcoursDurationSec
//        {
//            get { return parcoursDurationSec; }
//        }
//        public string TakeOffTimeHour
//        {
//            get { return takeOffTimeHour; }
//        }
//        public string TakeOffTimeMin
//        {
//            get { return takeOffTimeMin; }
//        }
//        public bool UsesDefaultRunway
//        {
//            get { return usesDefaultRunway; }
//        }

//        public GroupsForm()
//        {
//            InitializeComponent();
//        }

//        public GroupsForm(string title, string groupBoxMainTitle, string submitButtonText, CompetitorCollection competitors,
//                            CompetitorCollection groupMembers, Guid groupId, string groupName,Race race, string parcoursDurationMin,
//                            string parcoursDurationSec, string takeOffTimeHour, string takeOffTimeMin, bool usesDefaultRunway)
//        {
//            InitializeComponent();
//            this.title = title;
//            this.groupBoxMainTitle = groupBoxMainTitle;
//            this.submitButtonText = submitButtonText;
//            this.competitors = competitors;
//            this.groupId = groupId;
//            this.groupName = groupName;
//            this.race = race;
//            this.parcoursDurationMin = parcoursDurationMin;
//            this.parcoursDurationSec = parcoursDurationSec;
//            this.takeOffTimeHour = takeOffTimeHour;
//            this.takeOffTimeMin = takeOffTimeMin;
//            this.usesDefaultRunway = usesDefaultRunway;
//            //this.runwayDefault = race.DefaultRunway;
//            if (runwayDefault == 0)
//            {
//                runwayDefault = 36;
//            }
//            this.runwayAlternative = (runwayDefault + 18) % 36;
//            if (runwayAlternative == 0)
//            {
//                runwayAlternative = 36;
//            }
//            this.members = new CompetitorCollection();
//            if (groupMembers != null)
//            {
//                foreach (Competitor competitor in groupMembers)
//                {
//                    this.members.Add(competitor);
//                }
//            }
//        }

//        private void GroupsForm_Load(object sender, EventArgs e)
//        {
            
//            this.Text = title;
//            this.groupAddGroup.Text = groupBoxMainTitle;
//            this.groupAddSave.Text = submitButtonText;
//            this.groupAddFieldName.Text = groupName;
//            //foreach (Parcours p in race.ParcoursCollection)
//            //{
//            //    this.cmbGroupParcours.Items.Add(p.ToString());
//            //}
//            this.cmbGroupParcours.SelectedIndex = 0;
//            this.groupAddFieldMin.Text = parcoursDurationMin;
//            this.groupAddFieldSec.Text = parcoursDurationSec;
//            this.groupTakeOffTimeHour.Text = takeOffTimeHour;
//            this.groupTakeOffTimeMin.Text = takeOffTimeMin;
//            groupAddFieldPC2.Items.Add(runwayDefault);
//            groupAddFieldPC2.Items.Add(runwayAlternative);
//            if (usesDefaultRunway)
//            {
//                this.groupAddFieldPC2.SelectedIndex = 0;
//            }
//            else
//            {
//                this.groupAddFieldPC2.SelectedIndex = 1;
//            }
//            ListViewItem competitorItem;
//            foreach (Competitor competitor in competitors)
//            {
//                competitorItem = new ListViewItem();
//                competitorItem.Text =   competitor.Country
//                                        + ", " + competitor.CompetitionNumber.ToString()
//                                        + ", " + competitor.PilotName
//                                        + " / " + competitor.NavigatorName;
//                competitorItem.Tag = competitor;
//                groupAddCompData.Items.Add(competitorItem);
//            }
//            if (this.members.Count > 0)
//            {
//                foreach (ListViewItem item in groupAddCompData.Items)
//                {
//                    if (this.members.Contains((Competitor)item.Tag))
//                    {
//                        ListViewItem memberItem = new ListViewItem();
//                        memberItem.Text = item.Text;
//                        memberItem.Tag = item.Tag;
//                        groupAddMemberData.Items.Add(memberItem);
//                        item.Remove();
//                    }
//                }
//            }
//            handleButtons();
//        }

//        private void groupAddButtonCancel_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void groupAddSave_Click(object sender, EventArgs e)
//        {
//                groupName = groupAddFieldName.Text;
//                //parcours = race.ParcoursCollection[cmbGroupParcours.SelectedIndex];
//                parcoursDurationMin = groupAddFieldMin.Text;
//                parcoursDurationSec = groupAddFieldSec.Text;
//                takeOffTimeHour = groupTakeOffTimeHour.Text;
//                takeOffTimeMin = groupTakeOffTimeMin.Text;
//                SubmitButtonClick(this, new EventArgs());
//        }

//        private void addButton_Click(object sender, EventArgs e)
//        {
//            if (groupAddCompData.Items.Count > 0 && groupAddCompData.SelectedItems.Count > 0)
//            {
//                foreach (ListViewItem selectedItem in groupAddCompData.SelectedItems)
//                {
//                    ListViewItem memberItem = new ListViewItem();
//                    memberItem.Text = selectedItem.Text;
//                    memberItem.Tag = selectedItem.Tag;
//                    groupAddMemberData.Items.Add(memberItem);
//                    members.Add((Competitor)selectedItem.Tag);
//                    selectedItem.Remove();
                    
//                    handleButtons();
//                }
//            }
//        }

//        private void removeButton_Click(object sender, EventArgs e)
//        {
//            if (groupAddMemberData.Items.Count > 0)
//            {
//                if (groupAddMemberData.SelectedItems.Count > 0)
//                {
//                    ListViewItem memberItem = new ListViewItem();
//                    memberItem.Text = groupAddMemberData.SelectedItems[0].Text;
//                    memberItem.Tag = groupAddMemberData.SelectedItems[0].Tag;
//                    groupAddCompData.Items.Add(memberItem);
//                    members.Remove((Competitor)groupAddMemberData.SelectedItems[0].Tag);
//                    groupAddMemberData.SelectedItems[0].Remove();
//                    handleButtons();
//                }
//            }
//        }

//        private void groupAddCompData_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            groupAddMemberData.SelectedItems.Clear();
//            handleButtons();
//        }

//        private void groupAddMemberData_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            groupAddCompData.SelectedItems.Clear();
//            handleButtons();
//        }

//        private void handleButtons()
//        {
//            if (groupAddMemberData.Items.Count == 4 || groupAddCompData.SelectedItems.Count == 0)
//            {
//                addButton.Enabled = false;
//            }
//            else if (groupAddMemberData.Items.Count < 4 && groupAddCompData.SelectedItems.Count > 0)
//            {
//                addButton.Enabled = true;
//            }

//            if (groupAddMemberData.SelectedItems.Count == 0)
//            {
//                removeButton.Enabled = false;
//            }
//            else
//            {
//                removeButton.Enabled = true;
//            }
//        }

//        private void moveButtonUp_Click(object sender, EventArgs e)
//        {
//            MoveListViewItem(ref this.groupAddMemberData, true);
//        }

//        private void moveButtonDown_Click(object sender, EventArgs e)
//        { 
//            MoveListViewItem(ref this.groupAddMemberData, false);
//        }

//        private void MoveListViewItem(ref ListView lv, bool moveUp)
//        {
//            string cache;
//            int selIdx;

//            selIdx = lv.SelectedItems[0].Index;
//            if (moveUp)
//            {
//                // ignore moveup of row(0)
//                if (selIdx == 0)
//                    return;

//                // move the subitems for the previous row
//                // to cache to make room for the selected row
//                for (int i = 0; i < lv.Items[selIdx].SubItems.Count; i++)
//                {
//                    cache = lv.Items[selIdx - 1].SubItems[i].Text;
//                    lv.Items[selIdx - 1].SubItems[i].Text =
//                      lv.Items[selIdx].SubItems[i].Text;
//                    lv.Items[selIdx].SubItems[i].Text = cache;
//                }
//                lv.Items[selIdx - 1].Selected = true;
//                lv.Refresh();
//                lv.Focus();
//            }
//            else
//            {
//                // ignore movedown of last item
//                if (selIdx == lv.Items.Count - 1)
//                    return;
//                // move the subitems for the next row
//                // to cache so we can move the selected row down
//                for (int i = 0; i < lv.Items[selIdx].SubItems.Count; i++)
//                {
//                    cache = lv.Items[selIdx + 1].SubItems[i].Text;
//                    lv.Items[selIdx + 1].SubItems[i].Text =
//                      lv.Items[selIdx].SubItems[i].Text;
//                    lv.Items[selIdx].SubItems[i].Text = cache;
//                }
//                lv.Items[selIdx + 1].Selected = true;
//                lv.Refresh();
//                lv.Focus();
//            }
//        }
//    }
//}
