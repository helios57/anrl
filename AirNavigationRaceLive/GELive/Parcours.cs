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
            //InformationPool.Client
        }

        private void btnAddParcour_Click(object sender, EventArgs e)
        {
            if (lstParcours.SelectedItem != null)
            {
                OnParcourOk.Invoke(lstParcours.SelectedItem, e);
                Close();
            }
        }
    }
}
