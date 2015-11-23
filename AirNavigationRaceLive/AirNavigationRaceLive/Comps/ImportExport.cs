using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AirNavigationRaceLive.Dialogs;
using System.IO;
using OfficeOpenXml;
using NetworkObjects;
using System.Globalization;

namespace AirNavigationRaceLive.Comps
{
    public partial class ImportExport : UserControl
    {
        private Client.DataAccess Client;
        public ImportExport(Client.DataAccess Client)
        {
            this.Client = Client;
            InitializeComponent();
        }

        private void btnExportKLM_Click(object sender, EventArgs e)
        {
            new ExportKML(Client).Show();
        }

        private void ImportExport_Load(object sender, EventArgs e)
        {
            List<QualificationRound> rounds = Client.SelectedCompetition.QualificationRound.ToList();
            comboBoxQualificationRound.Items.Clear();
            foreach (QualificationRound round in rounds)
            {
                comboBoxQualificationRound.Items.Add(new QualiComboBoxItem(round));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExportExcel.Enabled = comboBoxQualificationRound.SelectedItem != null;
            btnSyncExcel.Enabled = btnExportExcel.Enabled;
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (comboBoxQualificationRound.SelectedItem != null)
            {
                QualiComboBoxItem item = comboBoxQualificationRound.SelectedItem as QualiComboBoxItem;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "AirNavigationRaceStartList.xlsx";
                sfd.Title = "Export Startlist";
                sfd.ShowDialog();
                String filename = sfd.FileName;
                ExportToExcel(item, filename);
            }
        }


        private void btnSyncExcel_Click(object sender, EventArgs e)
        {
            if (comboBoxQualificationRound.SelectedItem != null)
            {
                QualiComboBoxItem item = comboBoxQualificationRound.SelectedItem as QualiComboBoxItem;
                OpenFileDialog sfd = new OpenFileDialog();
                sfd.FileName = "AirNavigationRaceStartList.xlsx";
                sfd.Title = "Sync Startlist";
                sfd.ShowDialog();
                String filename = sfd.FileName;
                ImportFromExcel(item, filename);
                ExportToExcel(item, filename);
            }
        }


        private void ExportToExcel(QualiComboBoxItem item, string filename)
        {
            File.WriteAllBytes(filename, Properties.Resources.Template);
            FileInfo newFile = new FileInfo(filename);
            ExcelPackage pck = new ExcelPackage(newFile);
            ExcelWorksheet Participants = pck.Workbook.Worksheets.First(p => p.Name == "Participants");
            ExcelWorksheet Teams = pck.Workbook.Worksheets.First(p => p.Name == "Crews");
            ExcelWorksheet StartList = pck.Workbook.Worksheets.First(p => p.Name == "StartList");
            int i = 2;
            foreach (Subscriber sub in Client.SelectedCompetition.Subscriber.OrderBy(p => p.LastName))
            {
                Participants.Cells[("A" + i)].Value = sub.LastName;
                Participants.Cells[("B" + i)].Value = sub.FirstName;
                i++;
            }
            i = 2;
            foreach (Team t in Client.SelectedCompetition.Team.OrderBy(p => int.Parse(p.CNumber)))
            {
                Teams.Cells[("A" + i)].Value = int.Parse(t.CNumber);
                Teams.Cells[("B" + i)].Value = t.Nationality;
                Teams.Cells[("C" + i)].Value = t.Pilot.LastName + " " + t.Pilot.FirstName;
                Teams.Cells[("D" + i)].Value = t.Navigator == null ? "" : t.Navigator.LastName + " " + t.Navigator.FirstName;
                Teams.Cells[("E" + i)].Value = t.AC;
                i++;
            }
            i = 2;
            foreach (Flight f in item.q.Flight.OrderBy(p => p.StartID))
            {
                if (i == 2)
                {
                    StartList.Cells[("J" + i)].Value = new DateTime(f.TimeTakeOff).ToString("dd.MM.yyyy");
                }
                StartList.Cells[("A" + i)].Value = f.StartID;
                StartList.Cells[("B" + i)].Value = int.Parse(f.Team.CNumber);
                StartList.Cells[("C" + i)].Value = f.Team.AC;
                string pilot = f.Team.Pilot.LastName + " " + f.Team.Pilot.FirstName;
                string navigator = "";
                if (f.Team.Navigator != null)
                {
                    navigator = " - " + f.Team.Navigator.LastName + " " + f.Team.Navigator.FirstName;
                }
                string crew = pilot + navigator;
                StartList.Cells[("D" + i)].Value = crew;
                StartList.Cells[("E" + i)].Value = new DateTime(f.TimeTakeOff);
                StartList.Cells[("F" + i)].Value = new DateTime(f.TimeStartLine);
                StartList.Cells[("G" + i)].Value = new DateTime(f.TimeEndLine);
                StartList.Cells[("H" + i)].Value = ((Route)f.Route).ToString();
                i++;
            }
            pck.Save();
        }

        private void ImportFromExcel(QualiComboBoxItem item, string filename)
        {
            FileInfo newFile = new FileInfo(filename);
            ExcelPackage pck = new ExcelPackage(newFile);
            ExcelWorksheet Participants = pck.Workbook.Worksheets.First(p => p.Name == "Participants");
            ExcelWorksheet Teams = pck.Workbook.Worksheets.First(p => p.Name == "Crews");
            ExcelWorksheet StartList = pck.Workbook.Worksheets.First(p => p.Name == "StartList");
            int i = 2;
            while (i < 200)
            {
                string LastName = Participants.Cells[("A" + i)].Value as string;
                string FirstName = Participants.Cells[("B" + i)].Value as string;
                if (LastName != null && FirstName != null&&LastName !="" && FirstName !="")
                {
                    if (!Client.SelectedCompetition.Subscriber.Any(p => p.LastName == LastName && p.FirstName == FirstName))
                    {
                        Subscriber sub = new Subscriber();
                        sub.Competition = Client.SelectedCompetition;
                        sub.LastName = LastName;
                        sub.FirstName = FirstName;
                        Client.DBContext.SubscriberSet.Add(sub);
                    }
                }
                else
                {
                    break;
                }
                i++;
            }
            Client.DBContext.SaveChanges();
            i = 2;
            while (i < 200)
            {
                double? cNumber = Teams.Cells[("A" + i)].Value as double?;
                string nationality = Teams.Cells[("B" + i)].Value as string;
                string pilot = Teams.Cells[("C" + i)].Value as string;
                string navigator = Teams.Cells[("D" + i)].Value as string;
                string ac = Teams.Cells[("E" + i)].Value as string;
                if (cNumber.HasValue && pilot != null&&pilot !="")
                {
                    Subscriber pilotS = Client.SelectedCompetition.Subscriber.First(p => pilot.Contains(p.FirstName) && pilot.Contains(p.LastName));
                    Subscriber navigatorS = null;
                    if (navigator != null&& navigator !="")
                    {
                        navigatorS = Client.SelectedCompetition.Subscriber.First(p => navigator.Contains(p.FirstName) && navigator.Contains(p.LastName));
                    }
                    Team t = null;
                    if (Client.SelectedCompetition.Team.Any(p => p.CNumber == ((int)cNumber.Value).ToString()))
                    {
                        t = Client.SelectedCompetition.Team.First(p => p.CNumber == ((int)cNumber.Value).ToString());
                    }
                    else
                    {
                        t = new Team();
                        t.Competition = Client.SelectedCompetition;
                        Client.DBContext.TeamSet.Add(t);
                    }
                    t.Pilot = pilotS;
                    t.Navigator = navigatorS;
                    t.CNumber = ((int)cNumber.Value).ToString();
                    t.Nationality = nationality;
                    t.AC = ac;
                }
                else
                {
                    break;
                }
                i++;
            }
            Client.DBContext.SaveChanges();
            i = 2;
            string date = null;
            while (i < 200)
            {
                if (i == 2)
                {
                    date = StartList.Cells[("J" + i)].Value as string;
                }
                double? startId = StartList.Cells[("A" + i)].Value as double?;
                double? cNumber = StartList.Cells[("B" + i)].Value as double?;
                double? takeOff = StartList.Cells[("E" + i)].Value as double?;
                double? start = StartList.Cells[("F" + i)].Value as double?;
                double? end = StartList.Cells[("G" + i)].Value as double?;
                string route = StartList.Cells[("H" + i)].Value as string;
                if (date != null && takeOff != null && start != null && end != null && date != "" && startId.HasValue && cNumber.HasValue && takeOff.HasValue && start.HasValue && end.HasValue && route != null)
                {
                    Flight f = null;
                    if (item.q.Flight.Any(p => p.StartID == startId.Value))
                    {
                        f = item.q.Flight.First(p => p.StartID == startId.Value);
                    }
                    else
                    {
                        f = new Flight();
                        f.QualificationRound = item.q;
                        f.StartID = ((int)startId.Value);
                        Client.DBContext.FlightSet.Add(f);
                    }
                    f.Team = Client.SelectedCompetition.Team.First(p => p.CNumber == ((int)cNumber.Value).ToString());
                    f.Route = (int)Enum.Parse(typeof(Route), route, true);
                    DateTime d = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    DateTime to = DateTime.FromOADate(takeOff.Value);
                    DateTime st = DateTime.FromOADate(start.Value);
                    DateTime en = DateTime.FromOADate(end.Value);
                    f.TimeTakeOff = new DateTime(d.Year, d.Month, d.Day, to.Hour, to.Minute, to.Second).Ticks;
                    f.TimeStartLine = new DateTime(d.Year, d.Month, d.Day, st.Hour, st.Minute, st.Second).Ticks;
                    f.TimeEndLine = new DateTime(d.Year, d.Month, d.Day, en.Hour, en.Minute, en.Second).Ticks;
                }
                else
                {
                    break;
                }
                i++;
            }
            Client.DBContext.SaveChanges();
        }

        private class QualiComboBoxItem
        {
            public QualificationRound q;
            public QualiComboBoxItem(QualificationRound q)
            {
                this.q = q;
            }

            public override string ToString()
            {
                return q.Name;
            }
        }
    }
}
