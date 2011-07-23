using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ANR.Core;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace ANR
{
    public partial class AirNavRace : Form
    {

        Competition competition;

        
        #region Constructors
        public AirNavRace()
        {
            competition = new Competition();
            

            InitializeComponent();
            InitBindings();
            //InitCompetitionForm();
        }

        public AirNavRace(string filename)
        {
            //race = new Race(filename);

            // ToDo: Load Competition
            InitializeComponent();
            //InitBindings();
            //LoadCompetitionForm();
        }
        #endregion Constructors


        private void InitBindings()
        {

        }

        #region TabPage Competition
        #region Competition Base Data
        private void competitionTxtDefaultRunway_TextChanged(object sender, EventArgs e)
        {
            //if (competitionTxtDefaultRunway.Text != string.Empty)
            //{
            //    int defaultRunway = -1;
            //    int.TryParse(competitionTxtDefaultRunway.Text, out defaultRunway);
            //    if (defaultRunway >= 0 && defaultRunway <= 36)
            //    {
            //        int oppositeRunway;
            //        if (defaultRunway - 18 < 1)
            //        {
            //            oppositeRunway = defaultRunway + 18;
            //        }
            //        else
            //        {
            //            oppositeRunway = defaultRunway - 18;
            //        }
            //        competitionTxtAlternativeRunway.Text = oppositeRunway.ToString();
            //    }
            //    else
            //    {
            //        competitionTxtDefaultRunway.Text = string.Empty;
            //        competitionTxtAlternativeRunway.Text = string.Empty;
            //        MessageBox.Show("Invalid Entry. Runway must be a 2 digits Number from 01 to 36.");
            //    }
            //}
            //else
            //{
            //    competitionTxtAlternativeRunway.Text = string.Empty;
            //}
        }

        private void competitionCmdSaveCompetitionData_Click(object sender, EventArgs e)
        {
            int startPLatitudeDeg = 0;
            int.TryParse(competitionStartPointLatitudeDegrees.Text, out startPLatitudeDeg);
            double startPLatitudeMin = 0;
            double.TryParse(competitionStartPointLatitudeMinutes.Text, out startPLatitudeMin);
            double startPLatitudeSec = 0;
            double.TryParse(competitionStartPointLatitudeSeconds.Text, out startPLatitudeSec);
            int startPLongitudeDeg = 0;
            int.TryParse(competitionStartPointLongitudeDegrees.Text, out startPLongitudeDeg);
            double startPLongitudeMin = 0;
            double.TryParse(competitionStartPointLongitudeMinutes.Text, out startPLongitudeMin);
            double startPLongitudeSec = 0;
            double.TryParse(competitionStartPointLatitudeSeconds.Text, out startPLongitudeSec);
                        
            double startPointLongitudeDbl = startPLongitudeDeg * 3600 + startPLongitudeMin * 60 +  startPLatitudeSec;
            double startPointLatitudeDbl = startPLatitudeDeg * 3600 + startPLatitudeMin * 60 + startPLongitudeDeg;
   
            int intervalGroupTakeoffs = 0;
            int.TryParse(competitionTxtGroupStartsInterval.Text, out intervalGroupTakeoffs);
            competition.IntervalBetweenGroupTakeoffs = TimeSpan.FromMinutes(intervalGroupTakeoffs);
            
            int intervalGroupCompetitorTakeoffs = 0;
            int.TryParse(competitionTxtCompetitorsStartInterval.Text, out intervalGroupCompetitorTakeoffs);
            competition.IntervalBetweenGroupCompetitorTakeoffs = TimeSpan.FromSeconds(intervalGroupCompetitorTakeoffs);
         
            this.competition.CompetitionName = competitionTxtCompetitionName.Text;
            this.competition.Location = competitionTxtLocation.Text;
            this.competition.Date = competitionDatePickerDate.Value;
            this.competition.Runway = int.Parse(competitionTxtRunway.Text);
            this.competition.Organizer = competitionTxtOrganizer.Text;
            this.competition.StartPoint = new GpsPoint(startPointLatitudeDbl, startPointLongitudeDbl, GpsPointFormatImport.WGS84);
            //this.competition.TakeOffGate = new Gate(new GpsPoint(leftPointLatitudeDbl, leftPointLongitudeDbl, GpsPointFormatImport.WGS84),
            //new GpsPoint(rightPointLatitudeDbl, rightPointLongitudeDbl, GpsPointFormatImport.WGS84));
        }

        private void competitionUpdateBaseData()
        {
            competitionStartPointLatitudeDegrees.Text = competition.StartPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Latitude);
            competitionStartPointLatitudeMinutes.Text = competition.StartPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Latitude);
            competitionStartPointLatitudeSeconds.Text = competition.StartPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Latitude);
            competitionStartPointLongitudeDegrees.Text = competition.StartPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
            competitionStartPointLongitudeMinutes.Text = competition.StartPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Longitude);
            competitionStartPointLongitudeSeconds.Text = competition.StartPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Longitude);
            competitionTxtRunway.Text = competition.Runway.ToString();
            competitionTxtCompetitionName.Text = competition.CompetitionName;
            competitionTxtLocation.Text = competition.Location;
            competitionTxtOrganizer.Text = competition.Organizer;
            competitionDatePickerDate.Value = competition.Date;
            competitionTxtCompetitorsStartInterval.Text = competition.IntervalBetweenGroupCompetitorTakeoffs.TotalSeconds.ToString();
            competitionTxtGroupStartsInterval.Text = competition.IntervalBetweenGroupTakeoffs.TotalMinutes.ToString();
        }
        #endregion Competition Base Data

        Map currentMap;
        Parcours currentParcours;

        #region Map
        private void competitionMapsCmbSelectMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMap = (Map)competitionMapsCmbSelectMaps.SelectedItem;
            UpdateMapView();
        }

        private void competitionMapsCmdDelete_Click(object sender, EventArgs e)
        {
            competition.MapCollection.Remove((Map)competitionMapsCmbSelectMaps.SelectedItem);
            competitionMapsCmbSelectMaps.Items.Remove(competitionMapsCmbSelectMaps.SelectedItem);
            UpdateCompetitionMapsCmbSelectMaps();
            UpdateMapView();
        }

        private void competitionMapsCmdAddMap_Click(object sender, EventArgs e)
        {
            OpenFileDialog MapLoad = new OpenFileDialog();
            MapLoad.FileOk += new CancelEventHandler(MapLoad_FileOk);
            MapLoad.Title = "Open Map Image File";
            MapLoad.Filter = "Image Files|*.jpg;*.bmp;*.png";
            MapLoad.ShowDialog();
        }

        void MapLoad_FileOk(object sender, CancelEventArgs e)
        {
            string filename = ((OpenFileDialog)sender).FileName;
            Map map = new Map(filename, competition);
            competition.MapCollection.Add(map);
            currentMap = map;
            UpdateCompetitionMapsCmbSelectMaps();
            UpdateMapView();
        }

        private void competitionMapsCmdSaveChanges_Click(object sender, EventArgs e)
        {
            currentMap.MapName = competitionMapsTxtMapName.Text;

            int startP1LatitudeDeg = 0;
            int.TryParse(competitionMapTopLeftLatitudeDegree.Text, out startP1LatitudeDeg);
            double startP1LatitudeMin = 0;
            double.TryParse(competitionMapTopLeftLatitudeMinutes.Text, out startP1LatitudeMin);
            double startP1LatitudeSec = 0;
            double.TryParse(competitionMapTopLeftLatitudeMinutes.Text, out startP1LatitudeSec);
            int startP1LongitudeDeg = 0;
            int.TryParse(competitionMapTopLeftLongitudeDegree.Text, out startP1LongitudeDeg);
            double startP1LongitudeMin = 0;
            double.TryParse(competitionMapTopLeftLongitudeMinutes.Text, out startP1LongitudeMin);
            double startP1LongitudeSec = 0;
            double.TryParse(competitionMapTopLeftLongitudeMinutes.Text, out startP1LongitudeSec);


            int startP2LatitudeDeg = 0;
            int.TryParse(competitionMapBottomRightLatitudeDegree.Text, out startP2LatitudeDeg);
            double startP2LatitudeMin = 0;
            double.TryParse(competitionMapBottomRightLatitudeMinutes.Text, out startP2LatitudeMin);
            double startP2LatitudeSec = 0;
            double.TryParse(competitionMapBottomRightLatitudeMinutes.Text, out startP2LatitudeSec);
            int startP2LongitudeDeg = 0;
            int.TryParse(competitionMapBottomRightLongitudeDegree.Text, out startP2LongitudeDeg);
            double startP2LongitudeMin = 0;
            double.TryParse(competitionMapBottomRightLongitudeMinutes.Text, out startP2LongitudeMin);
            double startP2LongitudeSec = 0;
            double.TryParse(competitionMapTopLeftLongitudeMinutes.Text, out startP2LongitudeSec);

            double Point1LongitudeDbl = startP1LongitudeDeg * 3600 + startP1LongitudeMin * 60 + startP2LongitudeSec;
            double Point1LatitudeDbl = startP1LatitudeDeg * 3600 + startP1LatitudeMin * 60 + startP1LatitudeSec;
            double Point2LongitudeDbl = startP2LongitudeDeg * 3600 + startP2LongitudeMin * 60 + startP2LongitudeSec;
            double Point2LatitudeDbl = startP2LatitudeDeg * 3600 + startP2LatitudeMin * 60 + startP2LatitudeSec;

            currentMap.TopLeftPoint = new GpsPoint(Point1LatitudeDbl, Point1LongitudeDbl, GpsPointFormatImport.WGS84);
            currentMap.BottomRightPoint = new GpsPoint(Point2LatitudeDbl, Point2LongitudeDbl, GpsPointFormatImport.WGS84);
            
            UpdateCompetitionMapsCmbSelectMaps();
            UpdateMapView();
        }

        private void competitionMapChangeMapFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog MapChangeImage = new OpenFileDialog();
            MapChangeImage.FileOk += new CancelEventHandler(MapChangeImage_FileOk);
            MapChangeImage.Title = "Open Map Image File";
            MapChangeImage.Filter = "Image Files|*.jpg;*.bmp;*.png";
            MapChangeImage.ShowDialog();
        }

        void MapChangeImage_FileOk(object sender, CancelEventArgs e)
        {
            string filename = ((OpenFileDialog)sender).FileName;
            Image img = Image.FromFile(filename);
            currentMap.Image = img;
            UpdateMapView();
        }

        private void UpdateMapView()
        {
            if (currentMap != null)
            {
                setMapViewControlsEnabled(true);
                competitionMapsMapImage.Image = currentMap.Image;
                competitionMapsTxtMapName.Text = currentMap.MapName;
                competitionMapTopLeftLatitudeDegree.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Latitude);
                competitionMapTopLeftLatitudeMinutes.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Latitude);
                competitionMapTopLeftLatitudeSeconds.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Latitude);
                
                competitionMapTopLeftLongitudeDegree.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
                competitionMapTopLeftLongitudeMinutes.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Longitude);
                competitionMapTopLeftLongitudeSeconds.Text = currentMap.TopLeftPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Longitude);
                
                competitionMapBottomRightLatitudeDegree.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Latitude);
                competitionMapBottomRightLatitudeMinutes.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Latitude);
                competitionMapBottomRightLatitudeSeconds.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Latitude);
                competitionMapBottomRightLongitudeDegree.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
                competitionMapBottomRightLongitudeMinutes.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Longitude);
                competitionMapBottomRightLongitudeSeconds.Text = currentMap.BottomRightPoint.ToString(GpsPointFormatString.SecondsOnly, GpsPointComponent.Longitude);
            }
            else
            {
                setMapViewControlsEnabled(false);
                competitionMapsMapImage.Image = new Bitmap(1, 1);
                competitionMapsTxtMapName.Text = string.Empty;
                competitionMapTopLeftLatitudeDegree.Text = string.Empty;
                competitionMapTopLeftLatitudeMinutes.Text = string.Empty;
                competitionMapTopLeftLatitudeSeconds.Text = string.Empty;
                competitionMapTopLeftLongitudeDegree.Text = string.Empty;
                competitionMapTopLeftLongitudeMinutes.Text = string.Empty;
                competitionMapTopLeftLongitudeSeconds.Text = string.Empty;
                competitionMapBottomRightLatitudeDegree.Text = string.Empty;
                competitionMapBottomRightLatitudeMinutes.Text = string.Empty;
                competitionMapBottomRightLatitudeSeconds.Text = string.Empty;
                competitionMapBottomRightLongitudeDegree.Text = string.Empty;
                competitionMapBottomRightLongitudeMinutes.Text = string.Empty;
                competitionMapBottomRightLongitudeSeconds.Text = string.Empty;
            }
            UpdateParcoursView();
            UpdateCompetitionParcoursCmbParcoursSelection();
        }

        public void setMapViewControlsEnabled(Boolean state)
        {
            competitionMapsCmdDelete.Enabled = state;
            competitionMapChangeMapFile.Enabled = state;
            competitionMapsCmdSaveChanges.Enabled = state;
            competitionMapsTxtMapName.Enabled = state;
            competitionMapTopLeftLatitudeDegree.Enabled = state;
            competitionMapTopLeftLatitudeMinutes.Enabled = state;
            competitionMapTopLeftLongitudeDegree.Enabled = state;
            competitionMapTopLeftLongitudeMinutes.Enabled = state;
            competitionMapBottomRightLatitudeDegree.Enabled = state;
            competitionMapBottomRightLatitudeMinutes.Enabled = state;
            competitionMapBottomRightLongitudeDegree.Enabled = state;
            competitionMapBottomRightLongitudeMinutes.Enabled = state;
        }

        private void UpdateCompetitionMapsCmbSelectMaps()
        {
            competitionMapsCmbSelectMaps.Items.Clear();
            foreach (Map map in competition.MapCollection)
            {
                competitionMapsCmbSelectMaps.DisplayMember = "MapName";
                competitionMapsCmbSelectMaps.Items.Add(map);
            }
            if(currentMap != null)
            {
                competitionMapsCmbSelectMaps.SelectedItem = currentMap;
            }
        }
        #endregion Map

        #region Parcours
        private void UpdateParcoursView()
        {
            if (currentParcours != null)
            {
                competitionParcoursParcoursImage.Image = Common.drawParcours(currentParcours);
                //competitionParcoursMaskedTextBoxTakeoffTimeToStartgateAlternateRunway.Text = currentParcours.TimeToStartGateAlternativeRunway.Minutes.ToString();
                competitionParcoursTxtTakeoffToStartgate.Text = currentParcours.TimeToStartGateDefaultRunway.Minutes.ToString();
                competitionParcoursTxtParcoursTime.Text = currentParcours.DefaultTargetFlightDuration.Minutes.ToString();
                competitionParcoursLoadAvailableParcoursNames();
                setParcoursControlsEnabled(true);
            }
            else
            {
                competitionParcoursCmbParcoursNameGreek.Items.Clear();
                competitionParcoursParcoursImage.Image = new Bitmap(1, 1);
                //competitionParcoursMaskedTextBoxTakeoffTimeToStartgateAlternateRunway.Text = string.Empty;
                competitionParcoursTxtTakeoffToStartgate.Text = string.Empty;
                competitionParcoursTxtParcoursTime.Text = string.Empty;
                competitionParcoursCmbParcoursNameGreek.Text = string.Empty;
                competitionParcoursCmbParcoursNameGreek.Items.Clear();
                setParcoursControlsEnabled(false);
                UpdateCompetitionParcoursCmbParcoursSelection();
            }
        }

        private void setParcoursControlsEnabled(Boolean state)
        {
            competitionParcoursCmbParcoursNameGreek.Enabled = state;
            competitionParcoursChangeParcoursFile.Enabled = state;
            competitionParcoursCmdDelete.Enabled = state;
            competitionParcoursCmdSaveChanges.Enabled = state;
            competitionParcoursTxtParcoursTime.Enabled = state;
            //competitionParcoursMaskedTextBoxTakeoffTimeToStartgateAlternateRunway.Enabled = state;
            competitionParcoursTxtTakeoffToStartgate.Enabled = state;
        }

        private void UpdateCompetitionParcoursCmbParcoursSelection()
        {
            if (currentMap != null)
            {
                competitionParcoursCmbParcoursSelection.Items.Clear();
                competitionParcoursCmbParcoursSelection.Text = string.Empty;
                foreach (Parcours p in currentMap.ParcoursCollection)
                {
                    competitionParcoursCmbParcoursSelection.DisplayMember = "ParcoursName";
                    competitionParcoursCmbParcoursSelection.Items.Add(p);
                }
                if (currentParcours != null)
                {
                    competitionParcoursCmbParcoursSelection.SelectedItem = currentParcours;
                }
            }
        }
        
        private void competitionParcoursLoadAvailableParcoursNames()
        {
            competitionParcoursCmbParcoursNameGreek.Items.Clear();
            competitionParcoursCmbParcoursNameGreek.Items.AddRange(getAvailableParcoursNames().ToArray());
            if (currentParcours != null)
            {
                competitionParcoursCmbParcoursNameGreek.Items.Add(currentParcours.ParcoursName);
                competitionParcoursCmbParcoursNameGreek.SelectedItem = currentParcours.ParcoursName;
            }
        }

        private void competitionParcoursCmdAddNewParcours_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDxfFileDialog = new OpenFileDialog();
            openDxfFileDialog.FileOk += new CancelEventHandler(openDxfFileDialog_FileOk);
            openDxfFileDialog.Title = "Open Dxf File";
            openDxfFileDialog.Filter = "Dxf Files|*.dxf";
            openDxfFileDialog.ShowDialog();
        }

        private void openDxfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = ((OpenFileDialog)sender).FileName;
            Parcours p = new Parcours(path, currentMap );
            p.ParcoursName = getNextAvailableParcoursName();
            currentMap.ParcoursCollection.Add(p);
            currentParcours = p;
            UpdateCompetitionParcoursCmbParcoursSelection();
            UpdateParcoursView();
        }
        private void competitionParcoursCmdDelete_Click(object sender, EventArgs e)
        {
            currentParcours.ParentMap.ParcoursCollection.Remove(currentParcours);
            competitionParcoursCmbParcoursSelection.Items.Remove(currentParcours);
            currentParcours = null;
            UpdateCompetitionParcoursCmbParcoursSelection();
            UpdateParcoursView();
        }
        private void competitionParcoursChangeParcoursFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog changeDxfFileDialog = new OpenFileDialog();
            changeDxfFileDialog.FileOk += new CancelEventHandler(changeDxfFileDialog_FileOk);
            changeDxfFileDialog.Title = "Open Dxf File";
            changeDxfFileDialog.Filter = "Dxf Files|*.dxf";
            changeDxfFileDialog.ShowDialog();
        }
        void  changeDxfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string path = ((OpenFileDialog)sender).FileName;
            Parcours currentParcours = (Parcours)competitionParcoursCmbParcoursSelection.SelectedItem;
            currentParcours.importFromDxf(path);
            UpdateParcoursView();
        }
        private void competitionParcoursCmdSaveChanges_Click(object sender, EventArgs e)
        {
            int timeTakeoffStartgate = 0 ;
            if (int.TryParse(competitionParcoursTxtTakeoffToStartgate.Text, out timeTakeoffStartgate))
            {
                currentParcours.TimeToStartGateDefaultRunway = TimeSpan.FromMinutes(timeTakeoffStartgate);
            }
            int parcoursTime = 0;
            if (int.TryParse(competitionParcoursTxtParcoursTime.Text, out parcoursTime))
            {
                currentParcours.DefaultTargetFlightDuration = TimeSpan.FromMinutes(parcoursTime);
            }

            currentParcours.ParcoursName = (string)competitionParcoursCmbParcoursNameGreek.SelectedItem;
            UpdateCompetitionParcoursCmbParcoursSelection();
            UpdateParcoursView();
        }

        private void competitionParcoursCmbParcoursSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentParcours = (Parcours)competitionParcoursCmbParcoursSelection.SelectedItem;
            UpdateParcoursView();
        }

        private string getNextAvailableParcoursName()
        {
            List<string> availableParcoursNames = getAvailableParcoursNames();
            if (availableParcoursNames.Count > 0)
            {
                return availableParcoursNames[0];
            }
            else
            {
                return new Random().ToString();
            }
        }
        private List<string> getAvailableParcoursNames()
        {
            string[] greekAlphabet = new string[] {"Alpha","Beta", "Gamma", "Delta","Epsilon","Zeta","Eta","Theta","Iota","Kappa","Lambda",
                "Mu","Nu","Xi","Omicron","Pi","Rho","Sigma","Tau","Ypsilon","Phi","Chi","Psi","Omega" };
            List<string> availableNames = greekAlphabet.ToList<string>();
            foreach (string name in greekAlphabet)
            {
                Parcours currentParcours = ((Parcours)competitionParcoursCmbParcoursSelection.SelectedItem);
                if (currentParcours != null)
                {
                    if (((Parcours)competitionParcoursCmbParcoursSelection.SelectedItem).ParentMap.ParcoursCollection.Contains(name))
                    {
                        availableNames.Remove(name);
                    }
                }
            }
            return availableNames;
        }

        #endregion Parcours
        #endregion TabPage Competition

        #region TabPage Competitors
        Competitor currentCompetitor;
        private void compUpdateGrid()
        {
            if (competition != null)
            {

                compDatagridCompetitors.Rows.Clear();
                foreach(Competitor c in competition.CompetitorCollection)
                {
                    int index = compDatagridCompetitors.Rows.Add(new object[] { c.CompetitionNumber, c.AcCallsign, c.PilotName, c.PilotFirstName, c.NavigatorName, c.NavigatorFirstName, c.Country });
                    compDatagridCompetitors.Rows[index].Tag = c;
                    if (c == currentCompetitor)
                    {
                        compDatagridCompetitors.Rows[index].Selected = true;
                    }
                }
                //currentCompetitor = null;
            }
        }
       
        private void compUpdateCompView()
        {
            if (currentCompetitor != null)
            {
                compTxtAcCallsign.Text = currentCompetitor.AcCallsign;
                compTxtCountry.Text = currentCompetitor.Country;
                compTxtNavigatorFirstname.Text = currentCompetitor.NavigatorFirstName;
                compTxtNavigatorLastname.Text = currentCompetitor.NavigatorName;
                compTxtPilotFirstname.Text = currentCompetitor.PilotFirstName;
                compTxtPilotLastname.Text = currentCompetitor.PilotName;
                compCmdDelete.Enabled = true;
                compCmdSave.Enabled = true;
            }
            else
            {
                compTxtAcCallsign.Text = string.Empty;
                compTxtCountry.Text = string.Empty;
                compTxtNavigatorFirstname.Text = string.Empty;
                compTxtNavigatorLastname.Text = string.Empty;
                compTxtPilotFirstname.Text = string.Empty;
                compTxtPilotLastname.Text = string.Empty;
                compCmdDelete.Enabled = false;
                compCmdSave.Enabled = false;
            }
        }

   
        private void compCmdAddNew_Click(object sender, EventArgs e)
        {
            currentCompetitor = new Competitor();
            currentCompetitor.AcCallsign = compTxtAcCallsign.Text;
            currentCompetitor.CompetitionNumber = getNextCompetitionNumber();
            currentCompetitor.Country = compTxtCountry.Text;
            currentCompetitor.NavigatorFirstName = compTxtNavigatorFirstname.Text;
            currentCompetitor.NavigatorName = compTxtNavigatorLastname.Text;
            currentCompetitor.PilotFirstName = compTxtPilotFirstname.Text;
            currentCompetitor.PilotName = compTxtPilotLastname.Text;
            competition.CompetitorCollection.Add(currentCompetitor);
            compUpdateGrid();
        }
        private int getNextCompetitionNumber()
        {
            for(int i = 1; i<160;i++)
            {
                if (!competition.CompetitorCollection.Contains(i))
                {
                    return i;
                }
            }
            return 0;
        }
        private void compCmdSave_Click(object sender, EventArgs e)
        {
            if (currentCompetitor != null)
            {
                currentCompetitor.AcCallsign = compTxtAcCallsign.Text;
                currentCompetitor.Country = compTxtCountry.Text;
                currentCompetitor.NavigatorFirstName = compTxtNavigatorFirstname.Text;
                currentCompetitor.NavigatorName = compTxtNavigatorLastname.Text;
                currentCompetitor.PilotFirstName = compTxtPilotFirstname.Text;
                currentCompetitor.PilotName = compTxtPilotLastname.Text;
            }
            compUpdateGrid();
        }
        private void compCmdDelete_Click(object sender, EventArgs e)
        {
            if (currentCompetitor != null)
            {
                competition.CompetitorCollection.Remove(currentCompetitor);
            }
            compUpdateGrid();
        }
        private void compDatagridCompetitors_SelectionChanged(object sender, EventArgs e)
        {
            if (compDatagridCompetitors.SelectedRows.Count > 0)
            {
                currentCompetitor = (Competitor)compDatagridCompetitors.SelectedRows[0].Tag;
            }
            else
            {
                currentCompetitor = null;
            }
            compUpdateCompView();
        }
        private void compDatagridCompetitors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentCompetitor = (Competitor)compDatagridCompetitors.Rows[e.RowIndex].Tag;
                compUpdateCompView();
            }
        }
        #endregion TabPage Competitors

        #region TabPage Races
 
        Race racesCurrentRace;
        
        private void raceCmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            raceCurrentRace = (Race)raceCmbRaces.SelectedItem;
            raceUpdateGroupGrid();
        }

        private void racesCmdAddRaceToCompetition_Click(object sender, EventArgs e)
        {
            Race newRace = new Race();
            newRace.Name = "New Race";
            newRace.Map = competition.MapCollection[0];
            newRace.Parcours = newRace.Map.ParcoursCollection[0];
            this.competition.RaceCollection.Add(newRace);
            racesCurrentRace = newRace;
            racesUpdateGrid();
        }

        private void racesCmbMap_SelectedIndexChanged(object sender, EventArgs e)
        {
            racesCurrentRace.Map = (Map)racesCmbMap.SelectedItem;
            racesCmbParcours.DisplayMember = "ParcoursName";
            foreach (Parcours parcours in racesCurrentRace.Map.ParcoursCollection)
            {
                racesCmbParcours.Items.Add(parcours);
            }
            if (racesCurrentRace.Parcours != null)
            {
                racesCmbParcours.SelectedItem = racesCurrentRace.Parcours;
            }
            else
            {
                racesCmbParcours.SelectedIndex = 0;
            }
            //racesUpdateView();
        }
       

        private void racesCmdDeleteRace_Click(object sender, EventArgs e)
        {
            competition.RaceCollection.Remove(racesCurrentRace);
            racesCurrentRace = null;
            racesUpdateGrid();
        }

        private void racesCmdSaveRaceChanges_Click(object sender, EventArgs e)
        {
            racesCurrentRace.Name = racesTxtRaceName.Text;
            racesCurrentRace.Map = (Map)racesCmbMap.SelectedItem;
            racesCurrentRace.Parcours = (Parcours)racesCmbParcours.SelectedItem;
            racesUpdateGrid();
        }

        private void racesCmdSelectCompetitors_Click(object sender, EventArgs e)
        {
            GroupCompetitorSelection gcs = new GroupCompetitorSelection(competition, racesCurrentRace);
            gcs.SubmitButtonClick += new EventHandler(gcs_SubmitButtonClick);
            gcs.Show();
        }

        void gcs_SubmitButtonClick(object sender, EventArgs e)
        {
            racesCurrentRace.Competitors = ((GroupCompetitorSelection)sender).SelectedCompetitors;
            racesUpdateGrid();
        }
        private void racesUpdateGrid()
        {
            Race currentRaceLocalCopy = racesCurrentRace; //cause clearing the Rows also sets racesCurrentRace to null...

            racesDataGridViewRaces.Rows.Clear();
            
            foreach (Race race in competition.RaceCollection)
            {
                int index = racesDataGridViewRaces.Rows.Add(new object[] { race.Name, race.Map.MapName, race.Competitors.Count });
                racesDataGridViewRaces.Rows[index].Tag = race;
                if (race == currentRaceLocalCopy)
                {
                    racesDataGridViewRaces.Rows[index].Selected = true;
                }
            }
            racesCurrentRace = currentRaceLocalCopy;
            racesUpdateView();
        }
        private void racesUpdateView()
        {
            racesCmbMap.Items.Clear();
            racesCmbParcours.Items.Clear();
            if (racesCurrentRace != null)
            {
                
                racesCmbMap.DisplayMember = "MapName";
                foreach (Map map in competition.MapCollection)
                {
                    racesCmbMap.Items.Add(map);
                }
                if (racesCurrentRace.Map != null)
                {
                    racesCmbMap.SelectedItem = racesCurrentRace.Map;
                }
                else
                {
                    racesCmbMap.SelectedIndex = 0;
                }

                
                

                racesTxtRaceName.Text = racesCurrentRace.Name;
                racesCmbMap.SelectedItem = racesCurrentRace.Map;
                racesLblNumberOfCompetitorsSelected.Text = racesCurrentRace.Competitors.Count + " of " + competition.CompetitorCollection.Count + " Competitors selected for this Race";
                racesSetRaceControlsEnabled(true);
            }
            else
            {
                racesTxtRaceName.Text = string.Empty;
                racesCmbMap.SelectedItem = null;
                racesCmbParcours.SelectedItem = null;
                racesLblNumberOfCompetitorsSelected.Text = string.Empty;
                racesSetRaceControlsEnabled(false);
            }
        }

        private void racesSetRaceControlsEnabled(bool state)
        {
            racesTxtRaceName.Enabled = state;
            racesLblNumberOfCompetitorsSelected.Enabled = state;
            racesCmdSelectCompetitors.Enabled = state;
            racesCmdSaveRaceChanges.Enabled = state;
            racesCmdDeleteRace.Enabled = state;
            racesCmbMap.Enabled = state;
            racesCmbParcours.Enabled = state;
        }

        private void racesDataGridViewRaces_SelectionChanged(object sender, EventArgs e)
        {
            if (racesDataGridViewRaces.SelectedRows.Count > 0)
            {
                racesCurrentRace = (Race)racesDataGridViewRaces.SelectedRows[0].Tag;
            }
            racesUpdateView();
        }

        private void racesDataGridViewRaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            racesCurrentRace = (Race)racesDataGridViewRaces.Rows[e.RowIndex].Tag;
            racesUpdateView();
        }

        #endregion TabPage Race and Groups
        #region TabPage Race and Groups
        Race raceCurrentRace = null;
        CompetitorGroup raceCurrentCompetitorGroup = null;

        private void raceGroupsCmdNewGroup_Click(object sender, EventArgs e)
        {
            CompetitorGroup newGroup = new CompetitorGroup();
            newGroup.Name = "New Group";
            newGroup.Parcours = raceCurrentRace.Parcours;
            if (raceCurrentRace.CompetitorGroups.Count > 0)
            {
                newGroup.StartingTime = raceCurrentRace.CompetitorGroups[raceCurrentRace.CompetitorGroups.Count - 1].StartingTime.Add(competition.IntervalBetweenGroupTakeoffs);
            }
            else
            {
                newGroup.StartingTime = DateTime.Now.Subtract(TimeSpan.FromSeconds((double)DateTime.Now.Second));
            }
            raceCurrentRace.CompetitorGroups.Add(newGroup);
            raceCurrentCompetitorGroup = newGroup;
            raceCurrentCompetitorGroup.Interval = competition.IntervalBetweenGroupCompetitorTakeoffs;
            raceCurrentCompetitorGroup.ParcoursTime = raceCurrentRace.Parcours.DefaultTargetFlightDuration;
            raceCurrentCompetitorGroup.TakeoffToStartGateTime = raceCurrentRace.Parcours.TimeToStartGateDefaultRunway;
            raceUpdateGroupGrid();
        }

        private void raceGroupsCmdDeleteGroup_Click(object sender, EventArgs e)
        {
            if (raceCurrentCompetitorGroup != null)
            {
                raceCurrentRace.CompetitorGroups.Remove(raceCurrentCompetitorGroup);
                raceCurrentCompetitorGroup = null;
                raceUpdateGroupView();
                raceUpdateGroupGrid();
            }
        }

        private void RaceGroupCmdSave_Click(object sender, EventArgs e)
        {
            raceCurrentCompetitorGroup.Name = raceGroupsTxtGroupName.Text;
            raceCurrentCompetitorGroup.StartingTime = raceDateTimePickerGroupStartTime.Value;
            raceCurrentCompetitorGroup.Interval = TimeSpan.FromSeconds(Convert.ToInt32(raceNumUpDownStartInterval.Value));
            raceCurrentCompetitorGroup.ParcoursTime = TimeSpan.FromMinutes((double)raceNumUpDownParcoursTime.Value);
            raceCurrentCompetitorGroup.TakeoffToStartGateTime = TimeSpan.FromMinutes((double)raceNumUpDownTakeOffToStartgate.Value);
            raceUpdateGroupGrid();
        }

        private void raceDataGridGroups_SelectionChanged(object sender, EventArgs e)
        {
            if (raceDataGridGroups.SelectedRows.Count > 0)
            {
                raceCurrentCompetitorGroup = (CompetitorGroup)raceDataGridGroups.SelectedRows[0].Tag;
            }
            raceUpdateGroupView();
        }

        private void raceDataGridGroups_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            raceCurrentCompetitorGroup = (CompetitorGroup)raceDataGridGroups.Rows[e.RowIndex].Tag;
            raceUpdateGroupView();
        }

        private void raceUpdateCmbRaces()
        {
            raceCmbRaces.DisplayMember = "Name";
            raceCmbRaces.Items.Clear();
            foreach (Race race in competition.RaceCollection)
            {
                raceCmbRaces.Items.Add(race);
            }

            if (raceCmbRaces.SelectedItem != null)
            {            
                raceCmbRaces.SelectedIndex = 0;
                raceCurrentRace = (Race)raceCmbRaces.SelectedItem;
            }
            raceUpdateGroupView();
        }
        private void raceUpdateRaceView()
        {
   
            if (raceCurrentRace != null)
            {
                racesCmdDeleteRace.Enabled = true;
                racesTxtRaceName.Enabled = true;
                racesTxtRaceName.Text = raceCurrentRace.Name;
                racesCmbMap.Enabled = true;
                racesCmbMap.Items.Clear();
                racesCmbMap.DisplayMember = "MapName"; 
                foreach(Map map in competition.MapCollection)
                {
                    racesCmbMap.Items.Add(map);
                }
                if (raceCurrentRace.Map != null)
                {
                    racesCmbMap.SelectedItem = raceCurrentRace.Map;
                }
            }
            else
            {
                racesCmdDeleteRace.Enabled = true;
                racesCmbMap.Enabled = false;
                racesTxtRaceName.Text = string.Empty;
                racesTxtRaceName.Enabled = false;
                racesCmbMap.Items.Clear();
                racesCmbMap.Text = string.Empty;
            }
        }

        
        private void setGroupViewControlsActive(Boolean state)
        {
            raceGroupsCmdDeleteGroup.Enabled = state;
            RaceGroupCmdSave.Enabled = state;
            raceCmdRoute1Select.Enabled = state;
            raceCmdRoute2Select.Enabled = state;
            raceCmdRoute3Select.Enabled = state;
            raceCmdRoute4Select.Enabled = state;
            raceDateTimePickerGroupStartTime.Enabled = state;
            raceNumUpDownStartInterval.Enabled = state;
            raceNumUpDownTakeOffToStartgate.Enabled = state;
            raceNumUpDownParcoursTime.Enabled = state;
            raceGroupsTxtGroupName.Enabled = state;
        }

        private void raceUpdateGroupView()
        {
           
            if (raceCurrentCompetitorGroup != null)
            {
                raceGroupsTxtGroupName.Text = raceCurrentCompetitorGroup.Name;
                raceNumUpDownParcoursTime.Value = Convert.ToDecimal(raceCurrentCompetitorGroup.ParcoursTime.TotalMinutes);
                raceNumUpDownStartInterval.Value = Convert.ToDecimal(raceCurrentCompetitorGroup.Interval.TotalSeconds);
                raceNumUpDownTakeOffToStartgate.Value = Convert.ToDecimal(raceCurrentCompetitorGroup.TakeoffToStartGateTime.TotalMinutes);
                raceDateTimePickerGroupStartTime.Value = raceCurrentCompetitorGroup.StartingTime;
                raceUpdateRouteAssignment();
                setGroupViewControlsActive(true);
            }
            else
            {
                setGroupViewControlsActive(false);
                raceGroupsTxtGroupName.Text = string.Empty;
                raceUpdateRouteAssignment();
            }
        }

        private void raceUpdateGroupGrid()
        {
            CompetitorGroup currentCompetitorGroupTempCopy = raceCurrentCompetitorGroup; //cause clearing the Rows also sets raceCurrentCompetitorGroup to null...

            raceDataGridGroups.Rows.Clear();
            foreach (CompetitorGroup group in raceCurrentRace.CompetitorGroups)
            {
                string team1Text = string.Empty;
                string team2Text = string.Empty;
                string team3Text = string.Empty;
                string team4Text = string.Empty;
                if (group.Parcours.Routes.Contains("A"))
                {
                    if (group.CompetitorRouteAssignmentCollection.Contains(group.Parcours.Routes["A"]))
                    {
                        Competitor c = group.CompetitorRouteAssignmentCollection[group.Parcours.Routes["A"]].Competitor;
                        team1Text = c.CompetitionNumber + ": " + c.AcCallsign + "(" + c.PilotName + " / " + c.NavigatorName + ")";
                    }
                }
                if (group.Parcours.Routes.Contains("B"))
                {
                    if (group.CompetitorRouteAssignmentCollection.Contains(group.Parcours.Routes["B"]))
                    {
                        Competitor c = group.CompetitorRouteAssignmentCollection[group.Parcours.Routes["B"]].Competitor;
                        team2Text = c.CompetitionNumber + ": " + c.AcCallsign + "(" + c.PilotName + " / " + c.NavigatorName + ")";
                    }
                }
                if (group.Parcours.Routes.Contains("C"))
                {
                    if (group.CompetitorRouteAssignmentCollection.Contains(group.Parcours.Routes["C"]))
                    {
                        Competitor c = group.CompetitorRouteAssignmentCollection[group.Parcours.Routes["C"]].Competitor;
                        team3Text = c.CompetitionNumber + ": " + c.AcCallsign + "(" + c.PilotName + " / " + c.NavigatorName + ")";
                    }
                }
                if (group.Parcours.Routes.Contains("D"))
                {
                    if (group.CompetitorRouteAssignmentCollection.Contains(group.Parcours.Routes["D"]))
                    {
                        Competitor c = group.CompetitorRouteAssignmentCollection[group.Parcours.Routes["D"]].Competitor;
                        team4Text = c.CompetitionNumber + ": " + c.AcCallsign + "(" + c.PilotName + " / " + c.NavigatorName + ")";
                    }
                }

                int index = raceDataGridGroups.Rows.Add(new object[]{
                    group.Name, team1Text, team2Text, team3Text, team4Text, group.StartingTime.ToString("HH:mm"), group.Interval.ToString()});
                raceDataGridGroups.Rows[index].Tag = group;
                if (group == currentCompetitorGroupTempCopy)
                {
                    raceDataGridGroups.Rows[index].Selected = true;
                }
            }
            raceCurrentCompetitorGroup = currentCompetitorGroupTempCopy;
            raceUpdateGroupView();
        }

        private void raceCmdSaveRaceChanges_Click(object sender, EventArgs e)
        {
            raceCurrentRace.Name = racesTxtRaceName.Text;
            raceCurrentRace.Map = (Map)racesCmbMap.SelectedItem;
            raceUpdateRaceView();
        }


        private Route raceRouteToAssignCompetitor;
        private void raceCmdSelectCompetitor_Click(object sender, EventArgs e)
        {
            Button currentButton = sender as Button;
            if(currentButton == raceCmdRoute1Select)
            {
                raceRouteToAssignCompetitor = raceCurrentCompetitorGroup.Parcours.Routes["A"];
            }
            else if (currentButton == raceCmdRoute2Select)
            {
                raceRouteToAssignCompetitor = raceCurrentCompetitorGroup.Parcours.Routes["B"];
            }
            else if (currentButton == raceCmdRoute3Select)
            {
                raceRouteToAssignCompetitor = raceCurrentCompetitorGroup.Parcours.Routes["C"];
            }
            else if (currentButton == raceCmdRoute4Select)
            {
                raceRouteToAssignCompetitor = raceCurrentCompetitorGroup.Parcours.Routes["D"];
            }

            CompetitorSelection cs = new CompetitorSelection(raceCurrentRace);
            cs.SubmitButtonClick += new EventHandler(cs_SubmitButtonClick);
            cs.Show();
        }

        Route raceAddFlightSelectedRoute = null;
        Button raceCurrentButton = null;
        private void raceGroupCmdLoadFlightCompetitor_Click(object sender, EventArgs e)
        {
            raceCurrentButton = sender as Button;
            if (raceCurrentButton == raceGroupCmdLoadFlightCompetitor1)
            {
                raceAddFlightSelectedRoute = raceCurrentCompetitorGroup.Parcours.Routes["A"];
            }
            else if (raceCurrentButton == raceGroupCmdLoadFlightCompetitor2)
            {
                raceAddFlightSelectedRoute = raceCurrentCompetitorGroup.Parcours.Routes["B"];
            }
            else if (raceCurrentButton == raceGroupCmdLoadFlightCompetitor3)
            {
                raceAddFlightSelectedRoute = raceCurrentCompetitorGroup.Parcours.Routes["C"];
            }
            else if (raceCurrentButton == raceGroupCmdLoadFlightCompetitor4)
            {
                raceAddFlightSelectedRoute = raceCurrentCompetitorGroup.Parcours.Routes["D"];
            }

            OpenFileDialog ImportFlight = new OpenFileDialog();
            ImportFlight.FileOk += new CancelEventHandler(ImportFlight_FileOk);
            ImportFlight.Title = "GAC File";
            ImportFlight.Filter = "GAC Files|*.GAC";
            ImportFlight.ShowDialog();
        }

        private void ImportFlight_FileOk(object sender, CancelEventArgs e)
        {
            string filename = ((OpenFileDialog)sender).FileName;
            Competitor localCompetitor = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceAddFlightSelectedRoute].Competitor;
            if (raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, localCompetitor) != null)
            {
                raceCurrentRace.Flights.Remove(raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(flightCurrentGroup, flightCurrentCompetitor));
            }
            Flight newFlight = new Flight();
            newFlight.Competitor = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceAddFlightSelectedRoute].Competitor;
            newFlight.CompetitorGroup = raceCurrentCompetitorGroup;
            newFlight.Map = raceCurrentRace.Map;
            newFlight.Parcours = raceCurrentCompetitorGroup.Parcours;
            newFlight.dataFromGAC(filename);
            newFlight.Route = raceAddFlightSelectedRoute;
            newFlight.Filename = new FileInfo(filename).Name;
            
            raceCurrentRace.Flights.Add(newFlight);
            raceUpdateGroupGrid();
        }

        public void raceUpdateRouteSelectCompetitorButtonLabels()
        {
            if (raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(
                raceCurrentCompetitorGroup, 
                raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceCurrentCompetitorGroup.Parcours.Routes["A"]].Competitor)== null)
            {
                raceCmdRoute1Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute1Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["B"]))
            {
                raceCmdRoute2Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute2Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["C"]))
            {
                raceCmdRoute3Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute3Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["D"]))
            {
                raceCmdRoute4Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute4Select.Text = "Remove Competitor";
            }
        }
        public void raceUpdateRouteSelectFlightButtonLabels()
        {
            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["A"]))
            {
                raceCmdRoute1Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute1Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["B"]))
            {
                raceCmdRoute2Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute2Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["C"]))
            {
                raceCmdRoute3Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute3Select.Text = "Remove Competitor";
            }

            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["D"]))
            {
                raceCmdRoute4Select.Text = "Select Competitor";
            }
            else
            {
                raceCmdRoute4Select.Text = "Remove Competitor";
            }
        }

        void cs_SubmitButtonClick(object sender, EventArgs e)
        {
            if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceRouteToAssignCompetitor))
            {
                raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceRouteToAssignCompetitor].Competitor = ((CompetitorSelection)sender).SelectedCompetitor;
            }
            else
            {
                raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Add(new CompetitorRouteAssignment(((CompetitorSelection)sender).SelectedCompetitor, raceRouteToAssignCompetitor,raceCurrentCompetitorGroup.StartingTime));
            }
            raceUpdateRouteAssignment();
        }

        private void raceUpdateRouteAssignment()
        {
            raceGroupRoutesLblTeam1.Text = string.Empty;
            raceGroupRoutesLblTeam2.Text = string.Empty;
            raceGroupRoutesLblTeam3.Text = string.Empty;
            raceGroupRoutesLblTeam4.Text = string.Empty;
            raceGroupRoutesLblTeam1FlightName.Text = string.Empty;
            raceGroupRoutesLblTeam2FlightName.Text = string.Empty;
            raceGroupRoutesLblTeam3FlightName.Text = string.Empty;
            raceGroupRoutesLblTeam4FlightName.Text = string.Empty;
            raceLblStartTime1.Text = string.Empty;
            raceLblStartTime2.Text = string.Empty;
            raceLblStartTime3.Text = string.Empty;
            raceLblStartTime4.Text = string.Empty;
            raceGroupCmdLoadFlightCompetitor1.Enabled = false;
            raceGroupCmdLoadFlightCompetitor1.Text = "Load Flight";
            raceGroupCmdLoadFlightCompetitor2.Enabled = false;
            raceGroupCmdLoadFlightCompetitor2.Text = "Load Flight";
            raceGroupCmdLoadFlightCompetitor3.Enabled = false;
            raceGroupCmdLoadFlightCompetitor3.Text = "Load Flight";
            raceGroupCmdLoadFlightCompetitor4.Enabled = false;
            raceGroupCmdLoadFlightCompetitor4.Text = "Load Flight";

            if (raceCurrentCompetitorGroup != null)
            {
                if (raceCurrentCompetitorGroup.Parcours.Routes.Contains("A"))
                {
                    if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["A"]))
                    {
                        CompetitorRouteAssignment cra = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceCurrentCompetitorGroup.Parcours.Routes["A"]];
                        raceGroupRoutesLblTeam1.Text = cra.Competitor.CompetitionNumber + ": " + cra.Competitor.AcCallsign + "(" + cra.Competitor.PilotName + " / " + cra.Competitor.NavigatorName + ")";
                        raceGroupCmdLoadFlightCompetitor1.Enabled = true;
                        cra.TakeoffTime = raceCurrentCompetitorGroup.StartingTime;
                        raceLblStartTime1.Text = cra.TakeoffTime.ToString("HH:mm:ss");
                        Flight flight = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor);
                        if (flight != null)
                        {
                            flight.PlannedTakeOffTime = raceDateTimePickerGroupStartTime.Value;
                            flight.PlannedStartGateTime = raceDateTimePickerGroupStartTime.Value.AddMinutes((int)raceNumUpDownTakeOffToStartgate.Value);
                            flight.PlannedFinishGateTime = flight.PlannedStartGateTime.AddMinutes((int)raceNumUpDownParcoursTime.Value);
                            raceLblStartTime1.Text = flight.PlannedTakeOffTime.ToString("HH:mm:ss");
                        
                            raceGroupCmdLoadFlightCompetitor1.Text = "Change Flight";
                            raceGroupRoutesLblTeam1FlightName.Text = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor).Filename;
                        }
                        else
                        {
                            raceGroupCmdLoadFlightCompetitor1.Text = "Load Flight";
                        }
                    }
                }
                if (raceCurrentCompetitorGroup.Parcours.Routes.Contains("B"))
                {
                    if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["B"]))
                    {
                        CompetitorRouteAssignment cra = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceCurrentCompetitorGroup.Parcours.Routes["B"]];
                        cra.TakeoffTime = raceCurrentCompetitorGroup.StartingTime.AddSeconds(raceCurrentCompetitorGroup.Interval.TotalSeconds);
                        raceLblStartTime2.Text = cra.TakeoffTime.ToString("HH:mm:ss");
                        raceGroupRoutesLblTeam2.Text = cra.Competitor.CompetitionNumber + ": " + cra.Competitor.AcCallsign + "(" + cra.Competitor.PilotName + " / " + cra.Competitor.NavigatorName + ")";
                        raceGroupCmdLoadFlightCompetitor2.Enabled = true;

                        Flight flight = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor);
                        if (flight != null)
                        {
                            flight.PlannedTakeOffTime = raceDateTimePickerGroupStartTime.Value.AddSeconds((double)raceNumUpDownStartInterval.Value);
                            flight.PlannedStartGateTime = raceDateTimePickerGroupStartTime.Value.AddMinutes((int)raceNumUpDownTakeOffToStartgate.Value);
                            flight.PlannedFinishGateTime = flight.PlannedStartGateTime.AddMinutes((int)raceNumUpDownParcoursTime.Value);
                            raceLblStartTime2.Text = flight.PlannedTakeOffTime.ToString("HH:mm:ss");

                            raceGroupCmdLoadFlightCompetitor2.Text = "Change Flight";
                            raceGroupRoutesLblTeam2FlightName.Text = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor).Filename;
                        }
                        else
                        {
                            raceGroupCmdLoadFlightCompetitor2.Text = "Load Flight";
                        }

                    }
                }
                if (raceCurrentCompetitorGroup.Parcours.Routes.Contains("C"))
                {
                    if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["C"]))
                    {
                     
                        CompetitorRouteAssignment cra = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceCurrentCompetitorGroup.Parcours.Routes["C"]];
                        cra.TakeoffTime = raceCurrentCompetitorGroup.StartingTime.AddSeconds(2 * raceCurrentCompetitorGroup.Interval.TotalSeconds);
                        raceLblStartTime3.Text = cra.TakeoffTime.ToString("HH:mm:ss");
                        raceGroupRoutesLblTeam3.Text = cra.Competitor.CompetitionNumber + ": " + cra.Competitor.AcCallsign + "(" + cra.Competitor.PilotName + " / " + cra.Competitor.NavigatorName + ")";
                        raceGroupCmdLoadFlightCompetitor3.Enabled = true;

                        Flight flight = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor);
                        if (flight != null)
                        {
                            flight.PlannedTakeOffTime = raceDateTimePickerGroupStartTime.Value.AddSeconds((double)raceNumUpDownStartInterval.Value * 2);
                            flight.PlannedStartGateTime = raceDateTimePickerGroupStartTime.Value.AddMinutes((int)raceNumUpDownTakeOffToStartgate.Value);
                            flight.PlannedFinishGateTime = flight.PlannedStartGateTime.AddMinutes((int)raceNumUpDownParcoursTime.Value);
                            raceLblStartTime3.Text = flight.PlannedTakeOffTime.ToString("HH:mm:ss");

                            raceGroupCmdLoadFlightCompetitor3.Text = "Change Flight";
                            raceGroupRoutesLblTeam3FlightName.Text = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor).Filename;
                        }
                        else
                        {
                            raceGroupCmdLoadFlightCompetitor3.Text = "Load Flight";
                        }
                    }
                }
                if (raceCurrentCompetitorGroup.Parcours.Routes.Contains("D"))
                {
                    if (raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection.Contains(raceCurrentCompetitorGroup.Parcours.Routes["D"]))
                    {
                        CompetitorRouteAssignment cra = raceCurrentCompetitorGroup.CompetitorRouteAssignmentCollection[raceCurrentCompetitorGroup.Parcours.Routes["D"]];
                        cra.TakeoffTime = raceCurrentCompetitorGroup.StartingTime.AddSeconds(3 * raceCurrentCompetitorGroup.Interval.TotalSeconds); ;
                        raceLblStartTime4.Text = cra.TakeoffTime.ToString("HH:mm:ss");
                        raceGroupRoutesLblTeam4.Text = cra.Competitor.CompetitionNumber + ": " + cra.Competitor.AcCallsign + "(" + cra.Competitor.PilotName + " / " + cra.Competitor.NavigatorName + ")";
                        raceGroupCmdLoadFlightCompetitor4.Enabled = true;
                        Flight flight = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor);
                        if (flight != null)
                        {
                            flight.PlannedTakeOffTime =raceDateTimePickerGroupStartTime.Value.AddSeconds((double)raceNumUpDownStartInterval.Value * 3);
                            flight.PlannedStartGateTime = raceDateTimePickerGroupStartTime.Value.AddMinutes((int)raceNumUpDownTakeOffToStartgate.Value);
                            flight.PlannedFinishGateTime = flight.PlannedStartGateTime.AddMinutes((int)raceNumUpDownParcoursTime.Value);
                            raceLblStartTime4.Text = flight.PlannedTakeOffTime.ToString("HH:mm:ss");

                            raceGroupCmdLoadFlightCompetitor4.Text = "Change Flight";
                            raceGroupRoutesLblTeam4FlightName.Text = raceCurrentRace.Flights.GetFlightByGroupAndCompetitorId(raceCurrentCompetitorGroup, cra.Competitor).Filename;
                        }
                        else
                        {
                            raceGroupCmdLoadFlightCompetitor4.Text = "Load Flight";
                        }
                    }
                }
            }
        }

        private void raceNumUpDownHours_ValueChanged(object sender, EventArgs e)
        {
            raceUpdateGroupView();
        }

        private void raceCmdExportStartlist_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveRanklistFlileDialog = new SaveFileDialog();
            saveRanklistFlileDialog.Title = "Save Startlist";
            saveRanklistFlileDialog.Filter = "CSV Files|*.csv";
            saveRanklistFlileDialog.DefaultExt = "csv";
            saveRanklistFlileDialog.FileOk +=new CancelEventHandler(saveRanklistFlileDialog_FileOk);
            saveRanklistFlileDialog.ShowDialog();

        }

        void  saveRanklistFlileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Common.saveRaceStartlist(raceCurrentRace, ((SaveFileDialog)sender).FileName);
        }

        #endregion TabPage Race and Groups

        #region TabPage Flight
        Race flightCurrentRace = null;
        CompetitorGroup flightCurrentGroup;
        Competitor flightCurrentCompetitor;
        Flight flightCurrentFlight;
        Penalty flightCurrentPenalty;
        
        private void flightUpdateTree()
        {
            flightTreeViewGroupsAndCompetitors.Nodes.Clear();
            foreach (Race race in competition.RaceCollection)
            {
                TreeNode raceNode = new TreeNode(race.Name);
                raceNode.Tag = race;
                foreach (CompetitorGroup group in race.CompetitorGroups)
                {
                    TreeNode groupNode = new TreeNode(group.Name);
                    groupNode.Tag = group;
                    foreach (CompetitorRouteAssignment competitorRouteAssignment in group.CompetitorRouteAssignmentCollection)
                    {
                        TreeNode compNode = new TreeNode(competitorRouteAssignment.Competitor.CompetitionNumber + ": " + competitorRouteAssignment.Competitor.PilotName + " / " + competitorRouteAssignment.Competitor.NavigatorName);
                        compNode.Tag = competitorRouteAssignment.Competitor;
                        flightTreeViewGroupsAndCompetitors.AfterSelect += new TreeViewEventHandler(flightTreeViewGroupsAndCompetitors_AfterSelect);
                        groupNode.Nodes.Add(compNode);
                    }
                    raceNode.Nodes.Add(groupNode);
                }
                flightTreeViewGroupsAndCompetitors.Nodes.Add(raceNode);
            }
        }

        void flightTreeViewGroupsAndCompetitors_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(Competitor))
            {
                flightCurrentCompetitor = e.Node.Tag as Competitor;
                flightCurrentGroup = e.Node.Parent.Tag as CompetitorGroup;
                flightCurrentRace = e.Node.Parent.Parent.Tag as Race;
                updateFlightView();
            }
        }

        private void updateFlightView()
        {
            this.Cursor = Cursors.WaitCursor;

            flightDataGridPenalties.Rows.Clear();
            flightImageFlight.Image = new Bitmap(flightImageFlight.Width, flightImageFlight.Width);
            if (flightCurrentCompetitor != null && flightCurrentGroup != null)
            {
                flightCurrentFlight = flightCurrentRace.Flights.GetFlightByGroupAndCompetitorId(flightCurrentGroup, flightCurrentCompetitor);
                if (flightCurrentFlight != null)
                {

                    flightLblCompetitor.Text = flightCurrentCompetitor.PilotName + " / " + flightCurrentCompetitor.NavigatorName;
                    flightLblFilename.Text = flightCurrentFlight.Filename;
                    flightLblStartgatePlan.Text = flightCurrentFlight.PlannedStartGateTime.ToString("HH:mm:ss");
                    flightLblStartgatePassed.Text = flightCurrentFlight.StartGateTime.ToString("HH:mm:ss");
                    flightLblEndgatePlan.Text = flightCurrentFlight.PlannedFinishGateTime.ToString("HH:mm:ss");
                    flightLblEndgatePassed.Text = flightCurrentFlight.FinishGateTime.ToString("HH:mm:ss");
                    flightLblTakeoffTimePlan.Text = flightCurrentFlight.PlannedTakeOffTime.ToString("HH:mm:ss");
                    flightLblTakeoffTime.Text = flightCurrentFlight.TakeOffTime.ToString("HH:mm:ss");
                    flightImageFlight.Image = Common.drawFlight(flightCurrentRace.Map, flightCurrentGroup.Parcours, flightCurrentFlight);
                    flightCurrentFlight.resetPenalties();
                    flightUpdatePenaltyGrid();
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                flightImageFlight.Image = new Bitmap(1, 1);
                flightLblCompetitor.Text = string.Empty;
                flightLblFilename.Text = string.Empty;
                flightLblStartgatePassed.Text = string.Empty;
                flightLblEndgatePassed.Text = string.Empty;
                flightLblTakeoffTime.Text = string.Empty;
            }
        }

        private void flightCmdImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImportFlight = new OpenFileDialog();
            ImportFlight.FileOk += new CancelEventHandler(ImportFlight_FileOk);
            ImportFlight.Title = "GAC File";
            ImportFlight.Filter = "GAC Files|*.GAC";
            ImportFlight.ShowDialog();
        }

        private void flightCmdViewFullScreen_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer(flightImageFlight.Image);
            viewer.Show();
        }

        private void flightCmdExportFlightToPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog savePdfFileDialog = new SaveFileDialog();
            savePdfFileDialog.FileOk += new CancelEventHandler(savePdfFileDialog_FileOk);
            savePdfFileDialog.Title = "Save Flight Report as PDF";
            savePdfFileDialog.Filter = "PDF Files|*.pdf";
            savePdfFileDialog.FileName = "flightreport_" + flightCurrentRace.Name + "_" + flightCurrentCompetitor.AcCallsign;
            savePdfFileDialog.DefaultExt = "pdf";
            savePdfFileDialog.ShowDialog();
        }

        private void savePdfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Common.savePdf(competition, flightCurrentCompetitor, flightCurrentFlight,flightCurrentRace, flightCurrentGroup.Parcours,((SaveFileDialog)sender).FileName);
        }

        private void flightCmdSaveImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveImageDialog = new SaveFileDialog();
            saveImageDialog.Title = "Save Image Flight";
            saveImageDialog.Filter = "JPEG Files|*.jpeg";
            saveImageDialog.DefaultExt = "jpeg";
            saveImageDialog.FileOk += new CancelEventHandler(saveImageDialog_FileOk);            
            saveImageDialog.ShowDialog();

        }
        private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        {
            Common.drawFlight(flightCurrentRace.Map, flightCurrentGroup.Parcours, flightCurrentFlight).Save(((SaveFileDialog)sender).FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private void flightCmdViewGroupFlights_Click(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer(Common.drawGroupFlights(flightCurrentRace, flightCurrentRace.Map, flightCurrentGroup.Parcours, flightCurrentGroup));
            viewer.Show();
        }

        private void flightImageFlight_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ImageViewer viewer = new ImageViewer(Common.drawFlight(flightCurrentRace.Map, flightCurrentGroup.Parcours, flightCurrentFlight));
            viewer.Show();
        }

        private void flightCmdRecalculateFlightPenalties_Click(object sender, EventArgs e)
        {
            flightUpdatePenaltyGrid();
        }
        private void flightCmdAddNewPenalty_Click(object sender, EventArgs e)
        {
            Penalty newPenalty = new Penalty();
            newPenalty.PenaltyType = PenaltyType.Custom;
            newPenalty.Comment = "New Penalty";
            newPenalty.PenaltyPoints = 0;
            flightCurrentPenalty = newPenalty;
            flightUpdatePenaltyView();
        }

        private void flightCmdDeletePenalty_Click(object sender, EventArgs e)
        {
            flightCurrentFlight.Penalties.Remove(flightCurrentPenalty);
            flightUpdatePenaltyGrid();
            flightUpdatePenaltyView();
        }

        private void flightCmdSavePenalty_Click(object sender, EventArgs e)
        {
            flightCurrentPenalty.PenaltyPoints = int.Parse(flightTxtPenaltyPoints.Text);
            flightCurrentPenalty.Comment = flightTxtPenaltyComment.Text;
            flightCurrentPenalty.PenaltyType = (PenaltyType)flightCmbPenaltyType.SelectedItem;
            if(!(flightCurrentFlight.CustomPenalties.Contains(flightCurrentPenalty))){
                flightCurrentFlight.CustomPenalties.Add(flightCurrentPenalty);
            }
            flightUpdatePenaltyGrid();
            flightUpdatePenaltyView();
        }

        private void flightDataGridPenalties_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (flightDataGridPenalties.SelectedRows.Count > 0)
            {
                flightCurrentPenalty = (Penalty)flightDataGridPenalties.SelectedRows[0].Tag;
            }
            else
            {
                flightCurrentPenalty = null;
            }
            flightUpdatePenaltyView();
        }

        private void flightDataGridPenalties_SelectionChanged(object sender, EventArgs e)
        {
            if (flightDataGridPenalties.SelectedRows.Count > 0)
            {
                flightCurrentPenalty = (Penalty)flightDataGridPenalties.SelectedRows[0].Tag;
            }
            else
            {
                flightCurrentPenalty = null;
            }
            flightUpdatePenaltyView();
        }

        private void flightUpdatePenaltyView()
        {
            if (flightCurrentPenalty != null)
            {
                flightTxtPenaltyPoints.Text = flightCurrentPenalty.PenaltyPoints.ToString();
                flightCmbPenaltyType.DataSource = System.Enum.GetValues(typeof(PenaltyType));
                flightTxtPenaltyComment.Text = flightCurrentPenalty.Comment;
            }
            else
            {
                flightTxtPenaltyComment.Text = string.Empty;
                flightTxtPenaltyPoints.Text = string.Empty;
                flightCmbPenaltyType.DataSource = null;
                flightCmbPenaltyType.Items.Clear();
                flightCmbPenaltyType.Text = string.Empty;
            }
        }
        private void flightUpdatePenaltyGrid()
        {
            Penalty localpenaltyCopy = flightCurrentPenalty;
            flightDataGridPenalties.Rows.Clear();
            int totalFlightPenalties = 0;
            int totalLandingPenalties = 0;
            int totalPenalties = 0;
            foreach (Penalty penalty in flightCurrentFlight.Penalties)
            {
                int index = flightDataGridPenalties.Rows.Add(new string[] { penalty.PenaltyPoints.ToString(), penalty.PenaltyType.ToString(), penalty.Comment.ToString() });
                flightDataGridPenalties.Rows[index].Tag = penalty;

                if (localpenaltyCopy == penalty)
                {
                    flightDataGridPenalties.Rows[index].Selected = true;
                }
                if (penalty.PenaltyType == PenaltyType.Navigation)
                {
                    totalFlightPenalties += penalty.PenaltyPoints;
                }
                else if (penalty.PenaltyType == PenaltyType.Landing)
                {
                    totalLandingPenalties += penalty.PenaltyPoints;
                }
                totalPenalties += penalty.PenaltyPoints;
            }
            flightLblTotalFlightPenalties.Text = totalFlightPenalties.ToString();
            flightLblTotalLandingPenalties.Text = totalLandingPenalties.ToString();
            flightLblTotalPenalties.Text = totalPenalties.ToString();
            flightCurrentPenalty = localpenaltyCopy;
        }

        #endregion TabPage Flight

  
        private void flightImageFlight_DoubleClick(object sender, EventArgs e)
        {
            ImageViewer viewer = new ImageViewer(flightImageFlight.Image);
            viewer.Show();
        }
            
        #region TabPage Results and Reports
        Race resCurrentRace = null;
        private void resUpdateRaces()
        {
            resCmbRaces.Items.Clear();
            resCmbRaces.DisplayMember = "Name";
            foreach(Race race in competition.RaceCollection)
            {
                resCmbRaces.Items.Add(race);
            }
        }
        private void resCmbRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            resCurrentRace = (Race)resCmbRaces.SelectedItem;
            UpdateResultList();
        }
        private void resCmdSaveAsCsv_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveRankListCsvFileDialog = new SaveFileDialog();
            saveRankListCsvFileDialog.FileOk += new CancelEventHandler(saveRankListCsvFileDialog_FileOk);
            saveRankListCsvFileDialog.Title = "Save Rank List as CSV";
            saveRankListCsvFileDialog.Filter = "csv Files|*.csv";
            saveRankListCsvFileDialog.DefaultExt = "csv";
            saveRankListCsvFileDialog.ShowDialog();
        }

        private void saveRankListCsvFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            Common.saveRankingList(resCurrentRace, (((SaveFileDialog)sender).FileName));
        }
        private void UpdateResultList()
        {
            resDataGridResults.Rows.Clear();
            if (resCurrentRace != null)
            {
                List<ANR.Core.Common.TotalResult> ranklist = Common.calculateRankingList(resCurrentRace);
                foreach (ANR.Core.Common.TotalResult res in ranklist)
                {
                    resDataGridResults.Rows.Add(new object[]
                {
                    res.Rank, res.Result, res.Competitor.AcCallsign, res.Competitor.PilotFirstName, res.Competitor.PilotName, res.Competitor.NavigatorFirstName,
                    res.Competitor.NavigatorName, res.Competitor.Country, res.Competitor.CompetitionNumber
                });
                }
            }
        }

        #endregion TabPage Results and Reports


        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////currentCompetitor = null;
            ////currentMap = null;
            ////currentParcours = null;
            ////raceCurrentRace = null;
            ////raceCurrentCompetitorGroup = null;
            ////raceCurrentButton = null;
            ////flightCurrentCompetitor = null;
            ////flightCurrentFlight = null;
            ////flightCurrentGroup = null;
            ////flightCurrentRace = null;
            ////resCurrentRace = null;            
            if(tabControl.SelectedTab == Teilnehmer)
            {
                compUpdateGrid();
            }
            if(tabControl.SelectedTab == tabPageRaces)
            {
                racesUpdateGrid();
                raceUpdateCmbRaces();
            }
            if (tabControl.SelectedTab == FlugVerw)
            {
                flightCurrentFlight = null;
                flightUpdateTree();
                flightUpdatePenaltyView();
            }
            if (tabControl.SelectedTab == Rangliste)
            {
                resUpdateRaces();
            }
            if (tabControl.SelectedTab == Gruppen)
            {
                raceUpdateCmbRaces();               
            }
            if (tabControl.SelectedTab == Wettkampf)
            {
                competitionUpdateBaseData();
                UpdateCompetitionMapsCmbSelectMaps();
                UpdateCompetitionParcoursCmbParcoursSelection();
            }
        }


        private void compCmdExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCompetitorListDialog = new SaveFileDialog();
            saveCompetitorListDialog.FileOk += new CancelEventHandler(saveCompetitorListDialog_FileOk);
            saveCompetitorListDialog.Title = "Save Competitor List";
            saveCompetitorListDialog.Filter = "CSV Files|*.csv";
            saveCompetitorListDialog.DefaultExt = "csv";
            saveCompetitorListDialog.ShowDialog();
        }

        private void saveCompetitorListDialog_FileOk(object sender, CancelEventArgs e)
        {
            string csv = competition.CompetitorCollection.getCsvCompetitorList();
            string filename = (((SaveFileDialog)sender).FileName);
            StreamWriter sw = new StreamWriter(filename);
            sw.Write(csv);
            sw.Close();
        }

        private void wettkampfSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCompetition = new SaveFileDialog();
            saveCompetition.FileOk += new CancelEventHandler(saveCompetition_FileOk);
            saveCompetition.Title = "Save Competition";
            saveCompetition.Filter = "anrx Files|*.anrx";
            saveCompetition.DefaultExt = "anrx";
            saveCompetition.ShowDialog();
        }

        void saveCompetition_FileOk(object sender, CancelEventArgs e)
        {
            
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(((SaveFileDialog)sender).FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            formatter.Serialize(stream, competition);
            stream.Close();
        }

        private void wettkampfLadenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ImportCompetition = new OpenFileDialog();
            ImportCompetition.FileOk += new CancelEventHandler(ImportCompetition_FileOk);
            ImportCompetition.Title = "Load Competition";
            ImportCompetition.Filter = "anrx Files|*.anrx";
            ImportCompetition.ShowDialog();

        }

        void ImportCompetition_FileOk(object sender, CancelEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(((OpenFileDialog)sender).FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            competition = (Competition)formatter.Deserialize(stream);
            stream.Close();
            currentCompetitor = null;
            currentMap = null;
            currentParcours = null;
            competitionUpdateBaseData();
            UpdateCompetitionMapsCmbSelectMaps();
            UpdateCompetitionParcoursCmbParcoursSelection();
            UpdateMapView();
            UpdateParcoursView();

        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pFAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.pfa.ch");
        }

        private void developmentTeamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.marvinsoft.net");
        }
    }
}
    
        //#region Private Methods
        //#region Event Handlers
        //#region Tool Strip Menu
        //#region Save Competition
        //private void wettkampfSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveRaceDialog = new SaveFileDialog();
        //    saveRaceDialog.FileOk += new CancelEventHandler(saveRaceDialog_FileOk);
        //    saveRaceDialog.Title = "Save Race";
        //    saveRaceDialog.Filter = "ANR Competition Files|*.anrx";
        //    saveRaceDialog.DefaultExt = "anrx";
        //    saveRaceDialog.ShowDialog();
        //}

        //private void saveRaceDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    race.saveRace(((SaveFileDialog)sender).FileName);
        //}
        //#endregion Save Competition

        //#region Load Competition
        //private void wettkampfLadenToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openRaceFileDialog = new OpenFileDialog();
        //    openRaceFileDialog.Title = "Open Race File";
        //    openRaceFileDialog.Filter = "ANR Competition Files|*.anrx";
        //    openRaceFileDialog.FileOk += new CancelEventHandler(openRaceFileDialog_FileOk);
        //    openRaceFileDialog.ShowDialog();
        //}

        //private void openRaceFileDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    race.loadRace(((OpenFileDialog)sender).FileName);
        //    LoadCompetitionForm();
        //}
        //#endregion Load Competition

        //#region Close
        //private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //#endregion Close
        //#endregion Tool Strip Menu

        //#region TabPage Race
        //private void raceButtonCancel_Click(object sender, EventArgs e)
        //{
        //    foreach (Control control in raceGroupBoxRaceData.Controls)
        //    {
        //        if (control.GetType() == typeof(TextBox))
        //        {
        //            ((TextBox)control).Text = "";
        //        }
        //    }
        //}
        //private void raceFieldDefaultRunway_TextChanged(object sender, EventArgs e)
        //{
        //    raceTxtAlternativeRunway.Text = (360 - int.Parse(raceFieldDefaultRunway.Text)).ToString();
        //}

        //private void raceButtonSave_Click(object sender, EventArgs e)
        //{
        //    int flightDurationMin = 0;
        //    int.TryParse(raceFieldDurationMin.Text, out flightDurationMin);
        //    int flightDurationSec = 0;
        //    int.TryParse(raceFieldDurationSec.Text, out flightDurationSec);
        //    TimeSpan flightDuration = new TimeSpan(0, flightDurationMin, flightDurationSec);

        //    int timeToStartGateDefaultMin = 0;
        //    int.TryParse(raceFieldTakeoffDefault.Text, out timeToStartGateDefaultMin);
        //    int timeToStartGateDefaultSec = 0;
        //    int.TryParse(raceFieldTakeoffDefault.Text, out timeToStartGateDefaultSec);
        //    TimeSpan timeToStartGateDefault = new TimeSpan(0, timeToStartGateDefaultMin, timeToStartGateDefaultSec);

        //    int timeToStartGateAlternativeMin = 0;
        //    int.TryParse(raceFieldTakeoffAlternative.Text, out timeToStartGateAlternativeMin);
        //    int timeToStartGateAlternativeSec = 0;
        //    int.TryParse(raceFieldTakeoffAlternative.Text, out timeToStartGateAlternativeSec);
        //    TimeSpan timeToStartGateAlternative = new TimeSpan(0, timeToStartGateAlternativeMin, timeToStartGateAlternativeSec);

        //    int startP1LatitudeDeg = 0;
        //    int.TryParse(raceFieldStartP1BrDegree.Text, out startP1LatitudeDeg);
        //    double startP1LatitudeMin = 0;
        //    double.TryParse(raceFieldStartP1BrMin.Text, out startP1LatitudeMin);
        //    int startP1LongitudeDeg = 0;
        //    int.TryParse(raceFieldStartP1LenDegree.Text, out startP1LongitudeDeg);
        //    double startP1LongitudeMin = 0;
        //    double.TryParse(raceFieldStartP1LenMin.Text, out startP1LongitudeMin);

        //    int startP2LatitudeDeg = 0;
        //    int.TryParse(raceFieldStartP2BreDegree.Text, out startP2LatitudeDeg);
        //    double startP2LatitudeMin = 0;
        //    double.TryParse(raceFieldStartP2BreMin.Text, out startP2LatitudeMin);
        //    int startP2LongitudeDeg = 0;
        //    int.TryParse(raceFieldStartP2LenDegree.Text, out startP2LongitudeDeg);
        //    double startP2LongitudeMin = 0;
        //    double.TryParse(raceFieldStartP2LenMin.Text, out startP2LongitudeMin);
        //    double leftPointLongitudeDbl = startP1LongitudeDeg * 3600 + startP1LongitudeMin * 60;
        //    double leftPointLatitudeDbl = startP1LatitudeDeg * 3600 + startP1LatitudeMin * 60;
        //    double rightPointLongitudeDbl = startP2LongitudeDeg * 3600 + startP2LongitudeMin * 60;
        //    double rightPointLatitudeDbl = startP2LatitudeDeg * 3600 + startP2LatitudeMin * 60;

        //    int defaultRunway = Convert.ToInt32(raceFieldDefaultRunway.Text);

        //    race.Name = raceFieldCompName.Text;
        //    race.Location = raceFieldLocation.Text;
        //    race.Date = raceFieldDate.Value;
        //    race.TargetFlightDuration = flightDuration;
        //    race.DefaultRunway = defaultRunway;
        //    race.TakeOffGate.LeftPoint = new GpsPoint(leftPointLatitudeDbl, leftPointLongitudeDbl, GpsPointFormatImport.WGS84);
        //    race.TakeOffGate.RightPoint = new GpsPoint(rightPointLatitudeDbl, rightPointLongitudeDbl, GpsPointFormatImport.WGS84);
        //}
        //#endregion Race

        //#region Parcours
        //private void raceParcoursLoadButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openDxfFileDialog = new OpenFileDialog();
        //    openDxfFileDialog.FileOk += new CancelEventHandler(openDxfFileDialog_FileOk);
        //    openDxfFileDialog.Title = "Open Dxf File";
        //    openDxfFileDialog.Filter = "Dxf Files|*.dxf";
        //    openDxfFileDialog.ShowDialog();
        //}

        //private void openDxfFileDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    string path = ((OpenFileDialog)sender).FileName;
        //    int combobox = cmbParcours.Items.Add(path);
        //    race.ParcoursCollection.Add(new Parcours(path));
        //    raceParcoursImage.Image = null;
        //}

        //private void cmbParcours_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    raceParcoursImage.Image = Common.drawParcours(map, race.ParcoursCollection[cmbParcours.SelectedIndex]);
        //}

        //#endregion Parcours

        //#region Map
        //private void raceMapLoadButton_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog MapLoad = new OpenFileDialog();
        //    MapLoad.FileOk += new CancelEventHandler(MapLoad_FileOk);
        //    MapLoad.Title = "Open Image Map File";
        //    MapLoad.Filter = "Image Files|*.jpg;*.bmp;*.png";
        //    MapLoad.ShowDialog();
        //}

        //private void MapLoad_FileOk(object sender, CancelEventArgs e)
        //{
        //    string filename = ((OpenFileDialog)sender).FileName;
        //    race.Map.SetMapImage(filename);
        //    raceMapPath.Text = filename;
        //    raceMapImage.Image = race.Map.Image;
        //}
        //#endregion Map

        //#region Competitors
        //private void compButtonAdd_Click(object sender, EventArgs e)
        //{
        //    CompetitorForm competitorAdd = new CompetitorForm("add competitor", "add competitor", "add");
        //    competitorAdd.SubmitButtonClick += new EventHandler(competitorAdd_SubmitButtonClick);
        //    competitorAdd.ShowDialog();
        //}

        //private void competitorAdd_SubmitButtonClick(object sender, EventArgs e)
        //{
        //    CompetitorForm competitorAddForm = (CompetitorForm)sender;
        //    AddCompetitor(competitorAddForm.AcCallsign, competitorAddForm.Country, competitorAddForm.PilotFirstName,
        //                    competitorAddForm.PilotLastName, competitorAddForm.NavigatorFirstName, competitorAddForm.NavigatorLastName);
        //    competitorAddForm.Close();
        //    RefreshBinding();
        //}

        //private void compButtonEdit_Click(object sender, EventArgs e)
        //{
        //    int competitionNumber = Convert.ToInt32(CompetitorsDataGrid.SelectedRows[0].Cells[0].Value);
        //    string acCallsign = CompetitorsDataGrid.SelectedRows[0].Cells[1].Value.ToString();
        //    string country = CompetitorsDataGrid.SelectedRows[0].Cells[2].Value.ToString();
        //    string pilotFirstName = CompetitorsDataGrid.SelectedRows[0].Cells[3].Value.ToString();
        //    string pilotLastName = CompetitorsDataGrid.SelectedRows[0].Cells[4].Value.ToString();
        //    string navigatorFirstName = CompetitorsDataGrid.SelectedRows[0].Cells[5].Value.ToString();
        //    string navigatorLastName = CompetitorsDataGrid.SelectedRows[0].Cells[6].Value.ToString();
        //    CompetitorForm competitorEdit = new CompetitorForm("edit competitor", "edit competitor", "save", competitionNumber, acCallsign, country,
        //                                                        pilotFirstName, pilotLastName, navigatorFirstName, navigatorLastName); // TODO: current competitors data
        //    competitorEdit.SubmitButtonClick += new EventHandler(competitorEdit_SubmitButtonClick);
        //    competitorEdit.ShowDialog();
        //}

        //private void competitorEdit_SubmitButtonClick(object sender, EventArgs e)
        //{
        //    CompetitorForm competitorEditForm = (CompetitorForm)sender;
        //    ChangeCompetitor(competitorEditForm.CompetitorId, competitorEditForm.AcCallsign, competitorEditForm.Country, competitorEditForm.PilotFirstName,
        //                    competitorEditForm.PilotLastName, competitorEditForm.NavigatorFirstName, competitorEditForm.NavigatorLastName);
        //    competitorEditForm.Close();
        //    RefreshBinding();
        //}
        //#endregion Competitors

        //#region Groups
        //private void groupButtonAdd_Click(object sender, EventArgs e)
        //{
        //    // ToDo: Groupnumber!!!
        //    //int groupNumber = race.NextGroupNumber;
        //    int groupNumber = 1;
        //    string groupName = "Group" + groupNumber.ToString();
        //    GroupsForm GroupAddForm = new GroupsForm("add a group", "add a new group", "add", race.Competitors, null, new Guid(),
        //                                            groupName,race, race.TargetFlightDuration.Minutes.ToString(),
        //                                            race.TargetFlightDuration.Seconds.ToString(), "00", "00", true);
        //    GroupAddForm.SubmitButtonClick += new EventHandler(GroupAddForm_SubmitButtonClick);
        //    GroupAddForm.ShowDialog();
        //}

        //private void GroupAddForm_SubmitButtonClick(object sender, EventArgs e)
        //{
        //    GroupsForm groupAddForm = (GroupsForm)sender;

        //    DateTime takeOffTime = new DateTime(1, 1, 1, Convert.ToInt32(groupAddForm.TakeOffTimeHour), Convert.ToInt32(groupAddForm.TakeOffTimeMin), 0);
        //    TimeSpan parcoursTime = new TimeSpan(0, Convert.ToInt32(groupAddForm.ParcoursDurationMin), Convert.ToInt32(groupAddForm.ParcoursDurationSec));

        //    AddCompetitorGroup(Convert.ToInt32(groupAddForm.GroupNumber), groupAddForm.GroupName, takeOffTime, groupAddForm.UsesDefaultRunway,
        //                        groupAddForm.Parcours, parcoursTime, groupAddForm.Members);

        //    groupAddForm.Close();
        //    RefreshBinding();
        //}

        //private void groupButtonEdit_Click(object sender, EventArgs e)
        //{
        //    string groupId = dataGridViewGroups.SelectedRows[0].Cells[5].Value.ToString();
        //    CompetitorGroup groupToEdit = race.CompetitorGroups[new Guid(groupId)]; 
        //    GroupsForm OpenGroupAdd = new GroupsForm("edit a group", "edit an existing group", "save", race.Competitors, groupToEdit.Competitors, groupToEdit.Id,
        //                                            groupToEdit.Name, race, groupToEdit.ParcoursTime.Minutes.ToString(),
        //                                            groupToEdit.ParcoursTime.Seconds.ToString(), groupToEdit.TakeOffTime[0].Minute.ToString(),
        //                                            groupToEdit.TakeOffTime[0].Second.ToString(), groupToEdit.DefaultRunway);
        //    OpenGroupAdd.SubmitButtonClick += new EventHandler(OpenGroupEdit_SubmitButtonClick);
        //    OpenGroupAdd.ShowDialog();
        //    dataGridViewGroups.Update();
        //}

        //private void OpenGroupEdit_SubmitButtonClick(object sender, EventArgs e)
        //{
        //    GroupsForm groupEditForm = (GroupsForm)sender;

        //    DateTime takeOffTime = new DateTime(1, 1, 1, Convert.ToInt32(groupEditForm.TakeOffTimeHour), Convert.ToInt32(groupEditForm.TakeOffTimeMin), 0);
        //    TimeSpan parcoursTime = new TimeSpan(0, Convert.ToInt32(groupEditForm.ParcoursDurationMin), Convert.ToInt32(groupEditForm.ParcoursDurationSec));

        //    ChangeCompetitorGroup(groupEditForm.GroupId, groupEditForm.GroupName, takeOffTime, groupEditForm.UsesDefaultRunway, groupEditForm.Parcours, parcoursTime,
        //                          groupEditForm.Members);

        //    groupEditForm.Close();
        //    RefreshBinding();
        //}
        //#endregion Groups

        //#region Manage Flight
        //private void groupTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    if (e.Node.Tag.GetType() == typeof(Competitor))
        //    {
        //        currentCompetitor = e.Node.Tag as Competitor;
        //        currentGroup = e.Node.Parent.Tag as CompetitorGroup;
        //        flightButtonImport.Enabled = true;
        //        updateFlightView();
        //    }
        //}

        //private void updateFlightView()
        //{
        //    dataGridViewPenalties.Rows.Clear();
        //    flightMap.Image = new Bitmap(flightMap.Width, flightMap.Width);
        //    try
        //    {
        //        flightMap.Image = Common.drawFlight(race.Map, currentGroup.Parcours, currentCompetitor.Flights[currentGroup]);
        //        PenaltyCollection penalties = currentCompetitor.Flights[currentGroup].calculateForbiddenZonePenalties();
        //        foreach (Penalty penalty in penalties)
        //        {
        //            int index = dataGridViewPenalties.Rows.Add(new string[] { penalty.PenaltyPoints.ToString(), penalty.PenaltyType.ToString(), penalty.Comment.ToString() });
        //            dataGridViewPenalties.Rows[index].Tag = penalty;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private void flightButtonImport_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ImportFlight = new OpenFileDialog();
        //    ImportFlight.FileOk += new CancelEventHandler(ImportFlight_FileOk);
        //    ImportFlight.Title = "GAC File";
        //    ImportFlight.Filter = "GAC Files|*.GAC";
        //    ImportFlight.ShowDialog();
        //}

        //private void ImportFlight_FileOk(object sender, CancelEventArgs e)
        //{
        //    string filename = ((OpenFileDialog)sender).FileName;
        //    if(currentCompetitor.Flights.ContainsKey(currentGroup))
        //    {
        //        currentCompetitor.Flights.Remove(currentGroup);
        //    }
        //    currentCompetitor.Flights.Add(currentGroup, new Flight(filename, race.ParcoursCollection[0].Routes[1], race.ParcoursCollection[0]));
        //    updateFlightView();
        //}

        //private void flightMap_DoubleClick(object sender, EventArgs e)
        //{
        //    ImageViewer viewer = new ImageViewer(flightMap.Image);
        //    viewer.Show();
        //}

        //private void manageFlightExportFlightPdf_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog savePdfFileDialog = new SaveFileDialog();
        //    savePdfFileDialog.FileOk += new CancelEventHandler(savePdfFileDialog_FileOk);
        //    savePdfFileDialog.Title = "Save Flight Report as PDF";
        //    savePdfFileDialog.Filter = "PDF Files|*.pdf";
        //    savePdfFileDialog.DefaultExt = "pdf";
        //    savePdfFileDialog.ShowDialog();
        //}

        //private void savePdfFileDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    Common.savePdf(currentCompetitor,currentCompetitor.Flights[currentGroup], race, currentGroup.Parcours, ((SaveFileDialog)sender).FileName);
        //}

        //private void manageFlightSaveImage_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveImageDialog = new SaveFileDialog();
        //    saveImageDialog.Title = "Save Image Flight";
        //    saveImageDialog.Filter = "Bitmap Files|*.bmp";
        //    saveImageDialog.DefaultExt = "bmp";
        //    saveImageDialog.ShowDialog();
        //    saveImageDialog.FileOk += new CancelEventHandler(saveImageDialog_FileOk);
        //}

        //private void manageFlightButtonViewFullScreen_Click(object sender, EventArgs e)
        //{
        //    flightMap_DoubleClick(sender, e);
        //}

        //private void manageFlightEditPenalty_Click(object sender, EventArgs e)
        //{
        //    Penalty penalty = (Penalty)dataGridViewPenalties.SelectedRows[0].Tag;
        //    PenaltyForm OpenPenaltyEdit = new PenaltyForm("edit a penalty", "edit an existing penalty", "save", penalty.PenaltyPoints, penalty.Comment);
        //    OpenPenaltyEdit.PenaltySubmitButtonClick += new EventHandler(OpenPenaltyEdit_PenaltySubmitButtonClick);
        //    OpenPenaltyEdit.ShowDialog();
        //}

        //private void OpenPenaltyEdit_PenaltySubmitButtonClick(object sender, EventArgs e)
        //{
        //    PenaltyForm penaltyEditForm = (PenaltyForm)sender;
        //    Penalty penalty = (Penalty)dataGridViewPenalties.SelectedRows[0].Tag;
        //    penalty.PenaltyPoints = penaltyEditForm.PenaltyPoints;
        //    penalty.Comment = penaltyEditForm.Comment;
        //    penaltyEditForm.Close();
        //    updateFlightView();
        //}

        //private void manageFlightAddPenalty_Click(object sender, EventArgs e)
        //{
        //    PenaltyForm OpenPenaltyAdd = new PenaltyForm("add penalty", "add a penalty", "add", 0, string.Empty);
        //    OpenPenaltyAdd.PenaltySubmitButtonClick += new EventHandler(OpenPenaltyAdd_PenaltySubmitButtonClick);
        //    OpenPenaltyAdd.ShowDialog();
        //}

        //private void manageFlightDeletePenalty_Click(object sender, EventArgs e)
        //{
        //    PenaltyCollection penalties = currentCompetitor.Flights[currentGroup].Penalties;
        //    penalties.Remove((Penalty)dataGridViewPenalties.SelectedRows[0].Tag);
        //    updateFlightView();
        //}

        //private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (tabControl.SelectedTab == FlugVerw)
        //    {
        //        groupTreeView.Nodes.Clear();
        //        foreach (CompetitorGroup group in race.CompetitorGroups)
        //        {
        //            TreeNode node = new TreeNode(group.Number + ": " + group.Name);
        //            node.Tag = group;
        //            foreach (Competitor competitor in group.Competitors)
        //            {
        //                TreeNode compNode = new TreeNode(competitor.CompetitionNumber + ": " + competitor.PilotName + " / " + competitor.NavigatorName);
        //                compNode.Tag = competitor;
        //                groupTreeView.AfterSelect += new TreeViewEventHandler(groupTreeView_AfterSelect);
        //                node.Nodes.Add(compNode);
        //            }
        //            groupTreeView.Nodes.Add(node);
        //        }
        //    }
        //    else if (tabControl.SelectedTab == Rangliste)
        //    {
        //        RanklistDataGridRanks.Rows.Clear();
        //        List<ANR.Core.Common.TotalResult> ranklist = Common.calculateRankingList(race);
        //        foreach (ANR.Core.Common.TotalResult res in ranklist)
        //        {
        //            RanklistDataGridRanks.Rows.Add(new object[]
        //            {
        //                res.Result, res.Competitor.AcCallsign, res.Competitor.PilotFirstName, res.Competitor.PilotName, res.Competitor.NavigatorFirstName,
        //                res.Competitor.NavigatorName, res.Competitor.Country, res.Competitor.CompetitionNumber
        //            });
        //        }
        //    }
        //}

        //private void OpenPenaltyAdd_PenaltySubmitButtonClick(object sender, EventArgs e)
        //{
        //    PenaltyForm penaltyAddForm = (PenaltyForm)sender;
        //    PenaltyCollection penalties = currentCompetitor.Flights[currentGroup].Penalties;
        //    penalties.Add(new Penalty(penaltyAddForm.PenaltyPoints, PenaltyType.Custom, penaltyAddForm.Comment));
        //    penaltyAddForm.Close();
        //    updateFlightView();
        //}

        //private void manageFlightsGroupFlights_Click(object sender, EventArgs e)
        //{
        //    ImageViewer viewer = new ImageViewer(Common.drawGroupFlights(race.Map, currentGroup.Parcours, currentGroup));
        //    viewer.Show();
        //}

        //private void saveImageDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    Common.saveImage(flightMap.Image, ((OpenFileDialog)sender).FileName);
        //}
        //#endregion Manage Flight

        //#region Manage Competitors
        //private void manageCompetitorsCmdExportAsCsv_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveCompetitorListDialog = new SaveFileDialog();
        //    saveCompetitorListDialog.FileOk += new CancelEventHandler(saveCompetitorListDialog_FileOk);
        //    saveCompetitorListDialog.Title = "Save Competitor List";
        //    saveCompetitorListDialog.Filter = "CSV Files|*.csv";
        //    saveCompetitorListDialog.DefaultExt = "csv";
        //    saveCompetitorListDialog.ShowDialog();
        //}

        //private void saveCompetitorListDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    string csv= race.Competitors.getCsvCompetitorList();
        //    string filename = (((SaveFileDialog)sender).FileName);
        //    StreamWriter sw = new StreamWriter(filename);
        //    sw.Write(csv);
        //    sw.Close();
        //}
        //#endregion Manage Competitors

        //#region Datagrids
        //private void CompetitorsDataGrid_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (CompetitorsDataGrid.SelectedRows.Count > 0)
        //    {
        //        compButtonEdit.Enabled = true;
        //    }
        //}

        //private void dataGridViewGroups_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dataGridViewGroups.SelectedRows.Count > 0)
        //    {
        //        groupButtonEdit.Enabled = true;
        //    }
        //}
        //#endregion Datagrids

        //#region Ranklist
        //private void ranklistExport_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveRankListCsvFileDialog = new SaveFileDialog();
        //    saveRankListCsvFileDialog.FileOk += new CancelEventHandler(saveRankListCsvFileDialog_FileOk);
        //    saveRankListCsvFileDialog.Title = "Save Rank List as CSV";
        //    saveRankListCsvFileDialog.Filter = "csv Files|*.csv";
        //    saveRankListCsvFileDialog.DefaultExt = "csv";
        //    saveRankListCsvFileDialog.ShowDialog();
        //}

        //private void saveRankListCsvFileDialog_FileOk(object sender, CancelEventArgs e)
        //{
        //    Common.saveRankingList(race, (((SaveFileDialog)sender).FileName));
        //}
        //#endregion Ranklist
        //#endregion Event Handlers

        //#region Bindings
        //private void InitBindings()
        //{
        //    // competitors
        //    CompetitorsDataGrid.AutoGenerateColumns = false;

        //    DataGridViewTextBoxColumn competitionNumberColumn = new DataGridViewTextBoxColumn();
        //    competitionNumberColumn.DataPropertyName = "CompetitionNumber";
        //    competitionNumberColumn.HeaderText = "Competition Number";

        //    DataGridViewTextBoxColumn acCallsignColumn = new DataGridViewTextBoxColumn();
        //    acCallsignColumn.DataPropertyName = "AcCallsign";
        //    acCallsignColumn.HeaderText = "Ac Callsign";

        //    DataGridViewTextBoxColumn pilotFirstNameColumn = new DataGridViewTextBoxColumn();
        //    pilotFirstNameColumn.DataPropertyName = "PilotFirstName";
        //    pilotFirstNameColumn.HeaderText = "Pilot First Name";

        //    DataGridViewTextBoxColumn pilotNameColumn = new DataGridViewTextBoxColumn();
        //    pilotNameColumn.DataPropertyName = "PilotName";
        //    pilotNameColumn.HeaderText = "Pilot Name";

        //    DataGridViewTextBoxColumn navigatorFirstNameColumn = new DataGridViewTextBoxColumn();
        //    navigatorFirstNameColumn.DataPropertyName = "NavigatorFirstName";
        //    navigatorFirstNameColumn.HeaderText = "Navigator First Name";

        //    DataGridViewTextBoxColumn navigatorNameColumn = new DataGridViewTextBoxColumn();
        //    navigatorNameColumn.DataPropertyName = "NavigatorName";
        //    navigatorNameColumn.HeaderText = "Navigator Name";

        //    DataGridViewTextBoxColumn countryColumn = new DataGridViewTextBoxColumn();
        //    countryColumn.DataPropertyName = "Country";
        //    countryColumn.HeaderText = "Country";

        //    CompetitorsDataGrid.Columns.AddRange(new DataGridViewColumn[] { competitionNumberColumn, acCallsignColumn, pilotFirstNameColumn, pilotNameColumn, navigatorFirstNameColumn, navigatorNameColumn, countryColumn });


        //    // groups
        //    dataGridViewGroups.AutoGenerateColumns = false;

        //    DataGridViewTextBoxColumn groupNameColumn = new DataGridViewTextBoxColumn();
        //    groupNameColumn.DataPropertyName = "Name";
        //    groupNameColumn.HeaderText = "Group Name";

        //    DataGridViewTextBoxColumn takeOffTimeColumn = new DataGridViewTextBoxColumn();
        //    takeOffTimeColumn.DataPropertyName = "FirstTakeOffTime";
        //    takeOffTimeColumn.HeaderText = "Take Off Time";

        //    DataGridViewTextBoxColumn startingTimeColumn = new DataGridViewTextBoxColumn();
        //    startingTimeColumn.DataPropertyName = "StartingTime";
        //    startingTimeColumn.HeaderText = "Starting Time";

        //    DataGridViewTextBoxColumn runwayEighteenColumn = new DataGridViewTextBoxColumn();
        //    runwayEighteenColumn.DataPropertyName = "RunwayEighteen";
        //    runwayEighteenColumn.HeaderText = "Runway 18";

        //    DataGridViewTextBoxColumn parcoursTimeColumn = new DataGridViewTextBoxColumn();
        //    parcoursTimeColumn.DataPropertyName = "ParcoursTime";
        //    parcoursTimeColumn.HeaderText = "Parcours Time";

        //    DataGridViewTextBoxColumn groupIdColumn = new DataGridViewTextBoxColumn();
        //    groupIdColumn.DataPropertyName = "Id";
        //    groupIdColumn.Visible = false;

        //    dataGridViewGroups.Columns.AddRange(new DataGridViewColumn[] { groupNameColumn, takeOffTimeColumn, startingTimeColumn, runwayEighteenColumn, parcoursTimeColumn, groupIdColumn });

        //    RefreshBinding();
        //}

        //private void RefreshBinding()
        //{
        //    IList<Competitor> comp = new List<Competitor>();  
        //    foreach (Competitor value in race.Competitors)
        //        comp.Add(value);
        //    BindingList<Competitor> competitorsBinding = new BindingList<Competitor>(comp);
        //    CompetitorsDataGrid.DataSource = competitorsBinding;

        //    IList<CompetitorGroup> grp = new List<CompetitorGroup>();
        //    foreach (CompetitorGroup value in race.CompetitorGroups)
        //        grp.Add(value); 
        //    BindingList<CompetitorGroup> groupsBinding = new BindingList<CompetitorGroup>(grp);
        //    dataGridViewGroups.DataSource = groupsBinding;
        //}
        //#endregion Bindings

        //#region Competitors
        //private void InitCompetitionForm()
        //{
        //    raceFieldCompName.Text = string.Empty;
        //    raceFieldLocation.Text = string.Empty;
        //    raceFieldDefaultRunway.Text = string.Empty;
        //    raceFieldTakeoffDefault.Text = "0";
        //    raceFieldTakeoffAlternative.Text = "0";
        //    raceFieldStartP1BrDegree.Text = "0";
        //    raceFieldStartP1BrMin.Text = "0";
        //    raceFieldStartP1LenDegree.Text = "0";
        //    raceFieldStartP1LenMin.Text = "0";
        //    raceFieldStartP2BreDegree.Text = "0";
        //    raceFieldStartP2BreMin.Text = "0";
        //    raceFieldStartP2LenDegree.Text = "0";
        //    raceFieldStartP2LenMin.Text = "0";
        //    raceFieldDurationMin.Text = "0";
        //    raceFieldDurationSec.Text = "0";
        //}

        //private void LoadCompetitionForm()
        //{
        //    raceFieldCompName.Text = race.Name;
        //    raceFieldDate.Text = race.Date.ToString();
        //    raceFieldStartP1BrDegree.Text = race.TakeOffGate.LeftPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Latitude);
        //    raceFieldStartP1BrMin.Text = race.TakeOffGate.LeftPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Latitude);
        //    raceFieldStartP1LenDegree.Text = race.TakeOffGate.LeftPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
        //    raceFieldStartP1LenMin.Text = race.TakeOffGate.LeftPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
        //    raceFieldStartP2BreDegree.Text = race.TakeOffGate.RightPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Latitude);
        //    raceFieldStartP2BreMin.Text = race.TakeOffGate.RightPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Latitude);
        //    raceFieldStartP2LenDegree.Text = race.TakeOffGate.RightPoint.ToString(GpsPointFormatString.DegreesOnly, GpsPointComponent.Longitude);
        //    raceFieldStartP2LenMin.Text = race.TakeOffGate.RightPoint.ToString(GpsPointFormatString.MinutesOnly, GpsPointComponent.Longitude);
        //    raceFieldDurationMin.Text = race.TargetFlightDuration.Minutes.ToString();
        //    raceFieldDurationSec.Text = race.TargetFlightDuration.Seconds.ToString();
            
        //    RefreshBinding();
        //}

        //private void AddCompetitor(string acCallsign, string country, string pilotFirstName,
        //                            string pilotLastName, string navigatorFirstName, string navigatorLastName)
        //{
        //    Competitor newCompetitor = new Competitor();
        //    newCompetitor.AcCallsign = acCallsign;
        //    newCompetitor.Country = country;
        //    newCompetitor.PilotFirstName = pilotFirstName;
        //    newCompetitor.PilotName = pilotLastName;
        //    newCompetitor.NavigatorFirstName = navigatorFirstName;
        //    newCompetitor.NavigatorName = navigatorLastName;
        //    race.Competitors.Add(newCompetitor);

        //    RefreshBinding();
        //}

        //private void ChangeCompetitor(Guid competitorId, string acCallsign, string country, string pilotFirstName,
        //                                string pilotLastName, string navigatorFirstName, string navigatorLastName)
        //{
        //    Competitor competitorToEdit = race.Competitors[competitorId];
        //    competitorToEdit.AcCallsign = acCallsign;
        //    competitorToEdit.Country = country;
        //    competitorToEdit.PilotFirstName = pilotFirstName;
        //    competitorToEdit.PilotName = pilotLastName;
        //    competitorToEdit.NavigatorFirstName = navigatorFirstName;
        //    competitorToEdit.NavigatorName = navigatorLastName;

        //    RefreshBinding();
        //}
        //#endregion Competitors

        //#region CompetitorGroups
        //private void AddCompetitorGroup(int groupNumber, string groupName, DateTime takeOffTime, bool defaultRunway, Parcours parcours,
        //                                TimeSpan parcoursTime, CompetitorCollection competitors)
        //{
        //    CompetitorGroup newCompetitorGroup = new CompetitorGroup();
        //    newCompetitorGroup.Number = groupNumber;
        //    newCompetitorGroup.Name = groupName;
        //    newCompetitorGroup.setTakeOffTime(takeOffTime);
        //    newCompetitorGroup.DefaultRunway = defaultRunway;
        //    newCompetitorGroup.ParcoursTime = parcoursTime;
        //    newCompetitorGroup.Competitors = competitors;
        //    newCompetitorGroup.Parcours = parcours;
        //    race.CompetitorGroups.Add(newCompetitorGroup);
        //}

        //private void ChangeCompetitorGroup(Guid groupId, string groupName, DateTime takeOffTime, bool defaultRunway, Parcours parcours,
        //                                TimeSpan parcoursTime, CompetitorCollection competitors)
        //{
        //    CompetitorGroup groupToEdit = race.CompetitorGroups[groupId];
        //    groupToEdit.Name = groupName;
        //    groupToEdit.setTakeOffTime(takeOffTime);
        //    groupToEdit.DefaultRunway = defaultRunway;
        //    groupToEdit.Parcours = parcours;
        //    groupToEdit.ParcoursTime = parcoursTime;
        //    groupToEdit.Competitors = competitors;

        //    RefreshBinding();
        //}
        //#endregion CompetitorGroups

        //#endregion Private Methods
