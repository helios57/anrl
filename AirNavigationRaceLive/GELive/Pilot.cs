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
    public partial class Pilot : Form
    {
        public EventHandler OnPilotOk;
        public Pilot()
        {
            InitializeComponent();
            if (InformationPool.Client != null && InformationPool.Client.State == System.ServiceModel.CommunicationState.Opened)
            {
                lstExistingPilots.Items.Clear();
                //foreach (
                //Fill Pilots-List
            }
        }
        private void lstExistingPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstExistingPilots.SelectedItem != null)
            {
                try
                {
                    PilotEntry PlEntry = (PilotEntry)lstExistingPilots.SelectedItem;
                    fldId.Text = PlEntry.ID;
                    fldLastName.Text = PlEntry.LastName;
                    fldSureName.Text = PlEntry.SureName;
                    btnColor.BackColor = Color.FromArgb( int.Parse(PlEntry.PilotColor));
                }
                catch
                {}
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            fldId.Text = "";
            fldLastName.Text = "";
            fldSureName.Text = "";
            btnColor.BackColor = Color.White;
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog_Pilot = new ColorDialog();
            ColorDialog_Pilot.ShowDialog();
            btnColor.BackColor = ColorDialog_Pilot.Color;
        }
        private void btnAddPilot_Click(object sender, EventArgs e)
        {
            PilotEntry PlEntry = new PilotEntry();
            PlEntry.ID = fldId.Text;
            PlEntry.LastName = fldLastName.Text;
            PlEntry.SureName = fldSureName.Text;
            PlEntry.PilotColor = btnColor.BackColor.ToArgb().ToString();

            OnPilotOk.Invoke(PlEntry, e);
            Close();
        }
    }
}
