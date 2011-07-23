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
    public partial class CompetitorSelection : Form
    {
        private Race race;
        private Competitor selectedCompetitor;

        public Competitor SelectedCompetitor
        {
            get { return selectedCompetitor; }
            set { selectedCompetitor = value; }
        }

        public event EventHandler SubmitButtonClick;

        public CompetitorSelection(Race race)
        {
            InitializeComponent();
            this.race = race;
            compUpdateGrid();
        }

        private void cmdSelect_Click(object sender, EventArgs e)
        {
            Submit();
        }

        private void Submit()
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                selectedCompetitor = (Competitor)dataGridCompetitors.SelectedRows[0].Tag;
                SubmitButtonClick(this, new EventArgs());
                this.Close();
            }
        }
        private void compUpdateGrid()
        {
            if (race != null)
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
                CompetitorCollection availableCompetitors = new CompetitorCollection();
                availableCompetitors.AddRange(race.Competitors);
                
                foreach (CompetitorGroup cg in race.CompetitorGroups)
                {
                    foreach(CompetitorRouteAssignment cra in cg.CompetitorRouteAssignmentCollection)
                    {
                        availableCompetitors.Remove(cra.Competitor);
                    }
                }

                foreach (Competitor c in availableCompetitors)
                {
                    int index = dataGridCompetitors.Rows.Add(new object[] { c.CompetitionNumber, c.AcCallsign, c.PilotName, c.PilotFirstName, c.NavigatorName, c.NavigatorFirstName, c.Country });
                    dataGridCompetitors.Rows[index].Tag = c;
                }
            }
        }

        private void dataGridCompetitors_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridCompetitors.SelectedRows.Count > 0)
            {
                cmdSelect.Enabled = true;
            }
            else
            {
                cmdSelect.Enabled = false;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridCompetitors_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Submit();
        }


    }
}
