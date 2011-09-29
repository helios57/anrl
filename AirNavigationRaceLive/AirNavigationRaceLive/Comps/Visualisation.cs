using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Dialogs;
using AirNavigationRaceLive.Comps.Helper;
using System.IO;

namespace AirNavigationRaceLive.Comps
{
    public partial class Visualisation : UserControl
    {
        private Client.Client Client;
        private VisualisationPopup vp;
        private GEControll controll = new GEControll();
        public Visualisation(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CompetitionComboEntry cce = comboBox1.SelectedItem as CompetitionComboEntry;
                if (cce != null)
                {
                    NetworkObjects.Competition comp = cce.comp;

                    NetworkObjects.Parcour parcour = Client.getParcour(comp.ID_Parcour);
                    NetworkObjects.Map map = Client.getMap(parcour.ID_Map);
                    MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                    visualisationPictureBox1.Image = System.Drawing.Image.FromStream(ms);
                    visualisationPictureBox1.SetConverter(new Converter(map));
                    visualisationPictureBox1.SetParcour(parcour);
                    visualisationPictureBox1.Invalidate();
                    visualisationPictureBox1.Refresh();
                    controll.SetParcour(parcour);
                }
            }
        }

        private void btnStartClient_Click(object sender, EventArgs e)
        {
            if (vp != null && !vp.IsDisposed)
            {
                vp.Close();
            }
            vp = new VisualisationPopup();
            vp.Show();
            while (vp.getPlugin() == null) Application.DoEvents();
            controll.SetPlugin(vp.getPlugin());
        }


        private void Visualisation_Load(object sender, EventArgs e)
        {
            List<NetworkObjects.Competition> comps = Client.getCompetitions();
            comboBox1.Items.Clear();
            foreach (NetworkObjects.Competition c in comps)
            {
                comboBox1.Items.Add(new CompetitionComboEntry(c));
            }
        }

        private void fldVisualLineWidth_ValueChanged(object sender, EventArgs e)
        {
            controll.SetLineWidth((int)fldVisualLineWidth.Value);
        }

        private void fldPenaltyHeight_ValueChanged(object sender, EventArgs e)
        {
            controll.SetHeightPenalty((int)fldPenaltyHeight.Value);
        }

        private void fldTrackerHeight_ValueChanged(object sender, EventArgs e)
        {
            controll.SetTrackerHeightAdjustment((int)fldTrackerHeight.Value);
        }
    }
    class CompetitionComboEntry
    {
        public readonly NetworkObjects.Competition comp;
        public CompetitionComboEntry(NetworkObjects.Competition comp)
        {
            this.comp = comp;
        }
        public override string ToString()
        {
            return comp.ID + " " + comp.Name;
        }
    }
}
