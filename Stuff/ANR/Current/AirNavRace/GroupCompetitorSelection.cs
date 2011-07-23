using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ANR.Core;

namespace ANR
{
    public partial class GroupCompetitorSelection : Form
    {
        private Competition competition;
        private Race race;
        private CompetitorCollection selectedCompetitors;

        public event EventHandler SubmitButtonClick;

        public CompetitorCollection SelectedCompetitors
        {
            get { return selectedCompetitors; }
            set { selectedCompetitors = value; }
        }

        public GroupCompetitorSelection(Competition competition, Race race)
        {
            InitializeComponent();
            this.race = race;
            this.competition = competition;
            UpdateCmbRaceResults();
            UpdateGridCompetitors(competition.CompetitorCollection);
        }

        private void UpdateCmbRaceResults()
        {
            cmbRaceResults.Items.Clear();
            
            foreach (Race race in competition.RaceCollection)
            {
                cmbRaceResults.Items.Add(race);
                cmbRaceResults.DisplayMember = "Name";
            }
        }

        private void Submit()
        {
            selectedCompetitors = new CompetitorCollection();
            foreach (DataGridViewRow row in dataGridCompetitors.Rows)
            {
                if ((bool)(row.Cells["selected"]).Value)
                {
                    selectedCompetitors.Add((Competitor)row.Tag);
                }
            }
            SubmitButtonClick(this, new EventArgs());
            this.Close();
        }

        private void UpdateGridCompetitors(CompetitorCollection collection)
        {
            dataGridCompetitors.Rows.Clear();
            foreach (Competitor c in collection)
            {
                bool isSetMemberOfRace;
                if (race.Competitors.Count == 0)
                {
                    isSetMemberOfRace = true;
                }
                else
                {
                    isSetMemberOfRace = false;
                }
                if (race.Competitors.Contains(c))
                {
                    isSetMemberOfRace = true;
                }
                int index = dataGridCompetitors.Rows.Add(new object[] { isSetMemberOfRace, null ,c.CompetitionNumber, c.AcCallsign, c.PilotName, c.PilotFirstName, c.NavigatorName, c.NavigatorFirstName, c.Country });
                dataGridCompetitors.Rows[index].Tag = c;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdSubmit_Click(object sender, EventArgs e)
        {
            Submit();
        }

        private void cmdReset_Click(object sender, EventArgs e)
        {
            UpdateGridCompetitors(competition.CompetitorCollection);
        }

        private void cmdApplyRankList_Click(object sender, EventArgs e)
        {
            dataGridCompetitors.Columns["rank"].Visible = true;
            dataGridCompetitors.Rows.Clear();
            if (cmbRaceResults.SelectedItem != null)
            {
                race = (Race)cmbRaceResults.SelectedItem;
                {
                    List<ANR.Core.Common.TotalResult> ranklist = Common.calculateRankingList(race);
                    foreach (ANR.Core.Common.TotalResult res in ranklist)
                    {
                        Competitor c = res.Competitor;
        
                        bool isSetMemberOfRace;
                        if (race.Competitors.Count == 0)
                        {
                            isSetMemberOfRace = true;
                        }
                        else
                        {
                            isSetMemberOfRace = false;
                        }
                        if (race.Competitors.Contains(c))
                        {
                            isSetMemberOfRace = true;
                        }
                        int index = dataGridCompetitors.Rows.Add(new object[] { isSetMemberOfRace, res.Rank, c.CompetitionNumber, c.AcCallsign, c.PilotName, c.PilotFirstName, c.NavigatorName, c.NavigatorFirstName, c.Country });
                        dataGridCompetitors.Rows[index].Tag = c;
                        dataGridCompetitors.Sort(rank, ListSortDirection.Ascending);
                    }
                }
            }
        }
    }
}