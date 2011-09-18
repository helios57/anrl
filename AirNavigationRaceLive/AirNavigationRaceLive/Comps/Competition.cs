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
            bool takeOffLine = true;
            takeOffLine &= isValidDouble(takeOffLeftLatitude.Text);
            takeOffLine &= isValidDouble(takeOffLeftLongitude.Text);
            takeOffLine &= isValidDouble(takeOffRightLatitude.Text);
            takeOffLine &= isValidDouble(takeOffRightLongitude.Text);

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
            listViewSelectedGroup.Enabled = Ediable;
            btnUp.Enabled = Ediable && CompetitionGroupSelected;
            btnDown.Enabled = Ediable && CompetitionGroupSelected;
            btnAddToCompetition.Enabled = Ediable && GroupSelected;
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
            Reset();
            textID.Text = "0";
            UpdateEnablement();
        }

        private void listViewSelectedGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateEnablement();
            if (btnSave.Enabled)
            {
                NetworkObjects.Competition c = new NetworkObjects.Competition();
                c.ID = int.Parse(textID.Text);
                c.ID_Parcour = (parcours.SelectedItem as ComboParcour).p.ID;
                c.Name = textName.Text;
                DateTime TakeOff = mergeDateTime(timeTakeOff.Value,date.Value);
                DateTime Start = mergeDateTime(timeStart.Value,date.Value);
                DateTime End = mergeDateTime(timeEnd.Value,date.Value);
                c.TimeTakeOff = TakeOff.Ticks;
                c.TimeStartLine = Start.Ticks;
                c.TimeEndLine = End.Ticks;
                
                Vector start = new Vector(double.Parse(takeOffLeftLongitude.Text),double.Parse(takeOffLeftLatitude.Text), 0);
                Vector end = new Vector(double.Parse(takeOffRightLongitude.Text),double.Parse(takeOffRightLatitude.Text), 0);
                Vector o = Vector.Middle(start, end) - Vector.Orthogonal(end - start);
                NetworkObjects.Line line = new NetworkObjects.Line();
                line.A = NetworkObjects.Helper.Point(start.X, start.Y, start.Z);
                line.B = NetworkObjects.Helper.Point(end.X, end.Y, end.Z);
                line.O = NetworkObjects.Helper.Point(o.X, o.Y, o.Z);
                c.TakeOffLine = line;

                foreach (ListViewItem lvi in listViewSelectedGroup.Items)
                {
                    c.CompetitionGroupList.Add(lvi.Tag as NetworkObjects.CompetitionGroup);
                }
                Client.saveCompetition(c);
                Reset();
                LoadCompetition();
                UpdateEnablement();
            }
        }

        private DateTime mergeDateTime(DateTime time, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second, time.Millisecond);
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            if (listViewSelectedGroup.SelectedItems.Count == 1)
            {
                ListViewItem lviSelected = listViewSelectedGroup.SelectedItems[0];
                NetworkObjects.CompetitionGroup selectedCG = lviSelected.Tag as NetworkObjects.CompetitionGroup;
                if (selectedCG.Pos <= 1)
                {
                    return;
                }
                selectedCG.Pos--;
                lviSelected.SubItems[0].Text = selectedCG.Pos.ToString();

                foreach (ListViewItem lvi in listViewSelectedGroup.Items)
                {
                    NetworkObjects.CompetitionGroup cg = lvi.Tag as NetworkObjects.CompetitionGroup;
                    if (cg != selectedCG && cg.Pos == selectedCG.Pos)
                    {
                        cg.Pos++;
                        lvi.SubItems[0].Text = cg.Pos.ToString();
                    }
                }
                listViewSelectedGroup.Sort();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (listViewSelectedGroup.SelectedItems.Count == 1)
            {
                ListViewItem lviSelected = listViewSelectedGroup.SelectedItems[0];
                NetworkObjects.CompetitionGroup selectedCG = lviSelected.Tag as NetworkObjects.CompetitionGroup;
                if (selectedCG.Pos >= getNextPos() - 1)
                {
                    return;
                }
                selectedCG.Pos++;
                lviSelected.SubItems[0].Text = selectedCG.Pos.ToString();

                foreach (ListViewItem lvi in listViewSelectedGroup.Items)
                {
                    NetworkObjects.CompetitionGroup cg = lvi.Tag as NetworkObjects.CompetitionGroup;
                    if (cg != selectedCG && cg.Pos == selectedCG.Pos)
                    {
                        cg.Pos--;
                        lvi.SubItems[0].Text = cg.Pos.ToString();
                    }
                }
                listViewSelectedGroup.Sort();
            }
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
                NetworkObjects.CompetitionGroup cg = new NetworkObjects.CompetitionGroup();
                cg.ID_Group = g.ID;
                cg.Pos = getNextPos();
                ListViewItem lvi2 = new ListViewItem(new string[] { cg.Pos.ToString(), cg.ID_Group.ToString(), g.Name });
                lvi2.Tag = cg;
                listViewSelectedGroup.Items.Add(lvi2);
            }
        }

        private int getNextPos()
        {
            int max = 1;
            foreach (ListViewItem lvi in listViewSelectedGroup.Items)
            {
                NetworkObjects.CompetitionGroup cg = lvi.Tag as NetworkObjects.CompetitionGroup;
                if (cg.Pos >= max)
                {
                    max = cg.Pos + 1;
                }
            }
            return max;
        }

        private void btnRefreshGroup_Click(object sender, EventArgs e)
        {
            LoadGroups();
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
                textName.Text = c.Name;
                DateTime takeOff = new DateTime(c.TimeTakeOff);
                date.Value = takeOff;
                timeTakeOff.Value = takeOff;
                timeStart.Value = new DateTime(c.TimeStartLine);
                timeEnd.Value = new DateTime(c.TimeEndLine);
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
                foreach (NetworkObjects.CompetitionGroup cg in c.CompetitionGroupList)
                {
                    ListViewItem lvi2 = new ListViewItem(new string[] { cg.Pos.ToString(), cg.ID_Group.ToString(), Client.getGroup(cg.ID_Group).Name});
                    lvi2.Tag = cg;
                    listViewSelectedGroup.Items.Add(lvi2);
                }
                listViewSelectedGroup.Sort();
            }
            else
            {
                Reset();
            }
            UpdateEnablement();
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
}
