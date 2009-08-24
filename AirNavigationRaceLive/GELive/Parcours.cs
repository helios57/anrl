using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GELive.ANRLDataService;

namespace GELive
{
    public partial class Parcours : Form
    {

        public event EventHandler OnParcourOk;
        public Parcours()
        {
            InitializeComponent();
            lstParcours.Items.Clear();
            foreach (t_PolygonGroup pg in InformationPool.Client.GetPolygonGroup())
            {
                PolygonGroup PG = new PolygonGroup(pg);
                lstParcours.Items.Add(PG);
            }
        }

        private void btnAddParcour_Click(object sender, EventArgs e)
        {
            if (lstParcours.SelectedItem != null)
            {
                OnParcourOk.Invoke(lstParcours.SelectedItem, e);
                Close();
            }
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadDxf_Click(object sender, EventArgs e)
        {
            OpenFileDialog fp = new OpenFileDialog();
            fp.Filter = "Penalty-Zonen |*.dxf";
            fp.FileOk += new CancelEventHandler(fp_FileOk);
            fp.ShowDialog();
        }
        void fp_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog of = (OpenFileDialog)sender;
            PolygonGroup pg = InformationPool.importFromDxf(of.FileName);
            pg.ID = 0;
            pg.Name = fldNewParcourName.Text;
            lstParcours.Items.Add(pg);
            Refresh();
        }
    }
}
