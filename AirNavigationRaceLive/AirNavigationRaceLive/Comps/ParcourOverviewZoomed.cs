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
        private t_Parcour activeParcour = new t_Parcour();

        private enum ActivePoint
        {
            A, B, O, NONE
        }

        public ParcourOverviewZoomed(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
            PictureBox1.Cursor = new Cursor(@"Resources\GPSCursor.cur");
        }
        #region load

        class ListItem
        {
            private t_Parcour parcour;
            public ListItem(t_Parcour iParcour)
            {
                parcour = iParcour;
            }

            public override String ToString()
            {
                return parcour.Name;
            }
            public t_Parcour getParcour()
            {
                return parcour;
            }
        }

        private void loadParcours()
        {
            deleteToolStripMenuItem.Enabled = false;
            PictureBox1.SetConverter(c);
            PictureBox1.Image = null;
            activeParcour = new t_Parcour();
            PictureBox1.SetParcour(activeParcour);
            PictureBox1.Invalidate();

            listBox1.Items.Clear();
            List<t_Parcour> parcours = Client.getParcours();
            foreach (t_Parcour p in parcours)
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
                t_Map map = Client.getMap(li.getParcour().ID_Map);

                MemoryStream ms = new MemoryStream(Client.gett_Picture(map.ID_Picture).Data);
                PictureBox1.Image = System.Drawing.Image.FromStream(ms);
                c = new Converter(map);
                PictureBox1.SetConverter(c);

                PictureBox1.SetParcour(li.getParcour());
                activeParcour = li.getParcour();
                PictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Resize(object sender, EventArgs e)
        {
            PictureBox1.Invalidate();
        }
    }
}
