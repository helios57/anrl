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
    public partial class Pilot : Form
    {
        public event EventHandler OnPilotOk;
        public Pilot()
        {
            InitializeComponent();
            if (InformationPool.Client != null && InformationPool.Client.State == System.ServiceModel.CommunicationState.Opened)
            {
                lstExistingPilots.Items.Clear();
                foreach (t_Pilot p in InformationPool.Client.GetPilots())
                {
                    PilotEntry P = new PilotEntry(p);
                    lstExistingPilots.Items.Add(P);
                }
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
        private void btnUse_Click(object sender, EventArgs e)
        {
            if (lstExistingPilots.SelectedItem != null)
            {
                OnPilotOk.Invoke(lstExistingPilots.SelectedItem, e);
                Close();
            }

        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog_Pilot = new ColorDialog();
            ColorDialog_Pilot.ShowDialog();
            btnColor.BackColor = ColorDialog_Pilot.Color;
        }
        private void btnAddPilot_Click(object sender, EventArgs e)
        {
            PilotEntry pe = new PilotEntry();
            pe.LastName = fldLastName.Text;
            pe.SureName = fldSureName.Text;
            pe.PilotColor = btnColor.BackColor.ToArgb().ToString();
            pe.ID = InformationPool.Client.AddNewPilot(pe.LastName, pe.SureName, pe.PilotColor).ToString();
            lstExistingPilots.Items.Add(pe);
            fldId.Text = "";
            fldLastName.Text = "";
            fldSureName.Text = "";
            btnColor.BackColor = Color.White;
        }
    }
}
