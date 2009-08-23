using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GELive
{
    public partial class Parcours : Form
    {

        public event EventHandler OnParcourOk;
        public Parcours()
        {
            InitializeComponent();
            lstParcours.Items.Clear();
            foreach (List<String> S in InformationPool.Client.GetParcours())
            {
                PolygonGroup PG = new PolygonGroup();
                PG.ID = int.Parse(S[0]);
                PG.Name = S[1];
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
