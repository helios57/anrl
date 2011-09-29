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
        private Timer t;
        private NetworkObjects.Competition comp;
        private List<int> trackerlist = new List<int>();
        private List<NetworkObjects.Team> teamlist = new List<NetworkObjects.Team>();
        private volatile bool updating = false;
        private NetworkObjects.Parcour parcour;

        public Visualisation(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            t = new Timer();
            t.Interval = 5000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            if (this.Visible && comp != null && !updating)
            {
                updating = true;
                foreach (NetworkObjects.CompetitionGroup g in comp.CompetitionGroupList)
                {
                    NetworkObjects.Group group = Client.getGroup(g.ID_Group);
                    trackerlist.Clear();
                    teamlist.Clear();
                    foreach (NetworkObjects.GroupTeam gt in group.GroupTeamList)
                    {
                        NetworkObjects.Team t = Client.getTeam(gt.ID_Team);
                        teamlist.Add(t);
                        trackerlist.AddRange(t.ID_Tracker);
                    }
                }
                Client.getGPSDatenCache().requestGPSData(trackerlist, comp.TimeTakeOff - 100000, comp.TimeEndLine + 100000, new AsyncCallback(recieveData));
            }
        }
        public void recieveData(IAsyncResult result)
        {
            List<NetworkObjects.GPSData> data = result.AsyncState as List<NetworkObjects.GPSData>;
            if (data != null)
            {
                controll.SetDaten(data, teamlist.ToList());
                visualisationPictureBox1.SetData(data, teamlist.ToList());
                visualisationPictureBox1.Invalidate();
            }
            updating = false;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                CompetitionComboEntry cce = comboBox1.SelectedItem as CompetitionComboEntry;
                if (cce != null)
                {
                    comp = cce.comp;

                    parcour = Client.getParcour(comp.ID_Parcour);
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
            if (parcour != null)
            {
                controll.SetParcour(parcour);
            }
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
            if (parcour != null)
            {
                controll.SetParcour(parcour);
            }
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
