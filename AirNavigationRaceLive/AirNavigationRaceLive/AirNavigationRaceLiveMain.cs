using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps;
using AirNavigationRaceLive.Comps.Client;
using AirNavigationRaceLive.Dialogs;

namespace AirNavigationRaceLive
{
    public partial class AirNavigationRaceLiveMain : Form
    {
        private static AirNavigationRaceLiveMain main;
        private DataAccess Client;
        private CompetitionControl CompetitionO;
        private Credits Credits;
        private Pilot Pilot;
        private TeamControl Team;
        private QualificationRoundControl QualificationRound;
        private MapControl Map;
        private Visualisation Visualisation;
        private ParcourGen ParcourGen;
        private ParcourEditSingle ParcourEditSingle;
        private ParcourImport ParcourImport;
        private ParcourOverview ParcourOverview;
        private ParcourEdit ParcourEdit;
        private MapLegacy MapLegacy;
        private ParcourOverviewZoomed ParcourOverviewZoomed;
        private Results Results;
        private MapSelection MapSelection;
        private MapImportFromMaps MapImportFromMaps;
        private ImportExport ImportExport;

        public static void SetStatusText(String text)
        {
            if (main != null)
            {
                SetStatusCallback d = new SetStatusCallback(main.SetStatusTextCB);
                main.Invoke(d, new object[] { text });
            }
        }

        delegate void SetStatusCallback(String statusText);
        public void SetStatusTextCB(String statusText)
        {
            StatusStripLabel.Text = statusText;
        }

        public AirNavigationRaceLiveMain()
        {
            Client = DataAccess.Instance;
            InitializeComponent();
            main = this;
        }

        public void UpdateEnablement()
        {
            Boolean connected = Client.SelectedCompetition != null;
            competitionToolStripMenuItem.Enabled = Client != null;
            mapToolStripMenuItem.Enabled = connected;
            parcourToolStripMenuItem.Enabled = connected;
            overviewZoomedToolStripMenuItem.Enabled = connected;
            overviewToolStripMenuItem.Enabled = connected;
            generateToolStripMenuItem.Enabled = connected;
            importToolStripMenuItem.Enabled = connected;
            pilotsToolStripMenuItem.Enabled = connected;
            teamsToolStripMenuItem.Enabled = connected;
            qualificationRoundsToolStripMenuItem.Enabled = connected;
            rulesToolStripMenuItem.Enabled = connected;
            resultsToolStripMenuItem.Enabled = connected;
            toplistToolStripMenuItem.Enabled = connected;
            toplistFlightToolStripMenuItem.Enabled = connected;
            toplistLandingToolStripMenuItem.Enabled = connected;
            individualToplistToolStripMenuItem.Enabled = connected;
            addLandingResultsToolStripMenuItem.Enabled = connected;
            adjustResultsToolStripMenuItem.Enabled = connected;
            visualisationToolStripMenuItem.Enabled = connected;
            editToolStripMenuItem.Enabled = connected;
            exportToolStripMenuItem.Enabled = connected;
        }

        private void AirNavigationRaceLive_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Credits == null)
            {
                Credits = new Comps.Credits();
            }
            enableControl(Credits);
            StatusStripLabel.Text = "Ready";
            MainPanel.Controls.Clear();
            CompetitionO = new CompetitionControl(Client);
            CompetitionO.Connected += new EventHandler(CompetitionO_Connected);
            enableControl(CompetitionO);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        void CompetitionO_Connected(object sender, EventArgs e)
        {
            DataAccess c = sender as DataAccess;
            if (c != null)
            {
                Client = c;
                Pilot = null;
                Team = null;
                QualificationRound = null;
                Visualisation = null;
                Map = null;
                ParcourGen = null;
                ParcourImport = null;
                ParcourEdit = null;
                ParcourOverviewZoomed = null;
                MapLegacy = null;
                Results = null;
                UpdateEnablement();
            }
            enableControl(Credits);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = null;
            Pilot = null;
            Team = null;
            QualificationRound = null;
            Visualisation = null;
            Map = null;
            ParcourGen = null;
            ParcourImport = null;
            ParcourEdit = null;
            ParcourOverviewZoomed = null;
            MapLegacy = null;
            Results = null;
            CompetitionO = null;
            StatusStripLabel.Text = "Disconnected from Server";
            UpdateEnablement();
            enableControl(Credits);
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableControl(Credits);
        }

        private void pilotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pilot == null)
            {
                Pilot = new Pilot(Client);
            }
            enableControl(Pilot);
        }

        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Team == null)
            {
                Team = new TeamControl(Client);
            }
            enableControl(Team);
        }

        private void racesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (QualificationRound == null)
            {
                QualificationRound = new QualificationRoundControl(Client);
            }
            enableControl(QualificationRound);
        }

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visualisation == null)
            {
                Visualisation = new Visualisation(Client);
            }
            enableControl(Visualisation);
        }

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            if (MainPanel.Controls.Count == 1)
            {
                resize();
            }
        }

        private void enableControl(Control c)
        {
            foreach (Control cc in MainPanel.Controls) { cc.Visible = false; }
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(c);
            c.Visible = true;
            UpdateEnablement();
            resize();
        }
        private void resize()
        {
            MainPanel.Controls[0].SetBounds(0, 0, MainPanel.Width, MainPanel.Height);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visualisation == null)
            {
                Map = new MapControl(Client);
            }
            enableControl(Map);
        }

        private void parcourToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void overviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ParcourOverview == null)
            {
                ParcourOverview = new ParcourOverview(Client);
            }
            enableControl(ParcourOverview);
        }

        private void generateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParcourGen == null)
            {
                ParcourGen = new ParcourGen(Client);
            }
            enableControl(ParcourGen);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParcourImport == null)
            {
                ParcourImport = new ParcourImport(Client);
            }
            enableControl(ParcourImport);
        }

        private void legacyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapLegacy == null)
            {
                MapLegacy = new MapLegacy(Client);
            }
            enableControl(MapLegacy);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParcourEdit == null)
            {
                ParcourEdit = new ParcourEdit(Client);
            }
            enableControl(ParcourEdit);
        }

        private void overviewZoomedToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ParcourOverviewZoomed == null)
            {
                ParcourOverviewZoomed = new ParcourOverviewZoomed(Client);
            }
            enableControl(ParcourOverviewZoomed);
        }

        private void adjustResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Results == null)
            {
                Results = new Results(Client);
            }
            enableControl(Results);

        }

        private void competitionToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (CompetitionO != null)
            {
                enableControl(CompetitionO);
            }
        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Results == null)
            {
                Results = new Results(Client);
            }
            enableControl(Results);

        }

        private void addLandingResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mapImportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapSelection == null)
            {
                MapSelection = new MapSelection();
            }
            enableControl(MapSelection);
        }

        private void importFromMapsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MapImportFromMaps == null)
            {
                MapImportFromMaps = new MapImportFromMaps(Client);
            }
            enableControl(MapImportFromMaps);

        }

        private void generateSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ParcourEditSingle == null)
            {
                ParcourEditSingle = new ParcourEditSingle(Client);
            }
            enableControl(ParcourEditSingle);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ImportExport == null)
            {
                ImportExport = new ImportExport(Client);
            }
            enableControl(ImportExport);
        }
    }
}
