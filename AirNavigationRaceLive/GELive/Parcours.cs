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
            //InformationPool.Client
        }

        private void btnAddParcour_Click(object sender, EventArgs e)
        {

        }
    }
}
