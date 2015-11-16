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
            btnSyncExcel.Enabled = false;//TODO btnExportExcel.Enabled;
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
                File.WriteAllBytes(filename, Properties.Resources.Template);
                FileInfo newFile = new FileInfo(filename);
                ExcelPackage pck = new ExcelPackage(newFile);
                ExcelWorksheet Participants = pck.Workbook.Worksheets.First(p => p.Name == "Participants");
                ExcelWorksheet Teams = pck.Workbook.Worksheets.First(p => p.Name == "Crews");
                ExcelWorksheet StartList = pck.Workbook.Worksheets.First(p => p.Name == "StartList");
                int i = 2;
                foreach(Subscriber sub in Client.SelectedCompetition.Subscriber)
                {
                    Participants.Cells[("A" + i)].Value = sub.LastName;
                    Participants.Cells[("B" + i)].Value = sub.FirstName;
                    i++;
                }
                i = 2;
                foreach(Team t in Client.SelectedCompetition.Team)
                {
                    Teams.Cells[("A" + i)].Value = int.Parse(t.CNumber);
                    Teams.Cells[("B" + i)].Value = t.Nationality;
                    Teams.Cells[("C" + i)].Value = t.Pilot.LastName +" "+t.Pilot.FirstName;
                    Teams.Cells[("D" + i)].Value = t.Navigator==null ? "": t.Navigator.LastName +" "+t.Navigator.FirstName;
                    Teams.Cells[("E" + i)].Value = t.AC;
                    i++;
                }
                i = 2;
                List<Flight> flights = item.q.Flight.ToList();//.OrderBy(p => p.StartID).ToList();
                foreach (Flight f in flights)
                {
                    StartList.Cells[("A" + i)].Value = f.StartID;
                    StartList.Cells[("B" + i)].Value = int.Parse(f.Team.CNumber);
                    StartList.Cells[("C" + i)].Value = f.Team.AC;
                    string pilot = f.Team.Pilot.LastName + " " + f.Team.Pilot.FirstName;
                    string navigator = "";
                    if (f.Team.Navigator!= null)
                    {
                        navigator = " - " + f.Team.Navigator.LastName + " " + f.Team.Navigator.FirstName;
                    }
                    string crew = pilot + navigator;
                    StartList.Cells[("D" + i)].Value = crew;
                    StartList.Cells[("E" + i)].Value = new DateTime(f.TimeTakeOff).ToString("dd.MM.yyyy HH:mm");
                    StartList.Cells[("F" + i)].Value = new DateTime(f.TimeStartLine).ToString("dd.MM.yyyy HH:mm");
                    StartList.Cells[("G" + i)].Value = new DateTime(f.TimeEndLine).ToString("dd.MM.yyyy HH:mm");
                    StartList.Cells[("H" + i)].Value = ((Route) f.Route).ToString();
                    i++;
                }
                pck.Save();
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
                FileInfo newFile = new FileInfo(filename);
                ExcelPackage pck = new ExcelPackage(newFile);

            }
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
