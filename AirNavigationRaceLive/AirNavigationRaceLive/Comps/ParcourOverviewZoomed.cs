using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AirNavigationRaceLive.Comps.Model;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class ParcourOverviewZoomed : UserControl
    {
        private Client.Client Client;
        Converter c = null;
        private Line activeLine;
        private ActivePoint ap = ActivePoint.NONE;
        private Line selectedLine = null;
        private Line hoverLine = null;
        private NetworkObjects.Parcour activeParcour = new NetworkObjects.Parcour();

        private enum ActivePoint
        {
            A, B, O, NONE
        }

        public ParcourOverviewZoomed(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            pictureBox1.Cursor = new Cursor(@"Resources\GPSCursor.cur");
        }
        #region load

        class ListItem
        {
            private NetworkObjects.Parcour parcour;
            public ListItem(NetworkObjects.Parcour iParcour)
            {
                parcour = iParcour;
            }

            public override String ToString()
            {
                return parcour.Name;
            }
            public NetworkObjects.Parcour getParcour()
            {
                return parcour;
            }
        }

        private void loadParcours()
        {
            deleteToolStripMenuItem.Enabled = false;
            pictureBox1.SetConverter(c);
            pictureBox1.Image = null;
            activeParcour = new NetworkObjects.Parcour();
            pictureBox1.SetParcour(activeParcour);
            pictureBox1.Invalidate();

            listBox1.Items.Clear();
            List<NetworkObjects.Parcour> parcours = Client.getParcours();
            foreach (NetworkObjects.Parcour p in parcours)
            {
                listBox1.Items.Add(new ListItem(p));
            }
        }
        #endregion
        private void ParcourGen_VisibleChanged(object sender, EventArgs e)
        {
            loadParcours();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadParcours();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                Client.deleteParcour(li.getParcour().ID);
                loadParcours();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                deleteToolStripMenuItem.Enabled = true;
                NetworkObjects.Map map = Client.getMap(li.getParcour().ID_Map);

                MemoryStream ms = new MemoryStream(Client.getPicture(map.ID_Picture).Image);
                pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(map);
                pictureBox1.SetConverter(c);

                pictureBox1.SetParcour(li.getParcour());
                activeParcour = li.getParcour();
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }
    }
}
