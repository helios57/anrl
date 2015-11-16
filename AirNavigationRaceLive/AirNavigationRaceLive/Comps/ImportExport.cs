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

        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {

        }

        private void btnSyncExcel_Click(object sender, EventArgs e)
        {

        }
        private class QualiComboBoxItem
        {
            QualificationRound q;
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
