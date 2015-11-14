using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using AirNavigationRaceLive.Comps.Model;
using NetworkObjects;
using System.Globalization;

namespace AirNavigationRaceLive.Comps
{
    public partial class MapControl : UserControl
    {
        private Client.DataAccess Client;
        private ToolTip Tooltip;

        public MapControl(Client.DataAccess iClient)
        {
            Client = iClient;
            InitializeComponent();
            Tooltip = new ToolTip();
            Tooltip.AutomaticDelay = 0;
            Tooltip.AutoPopDelay = 0;
            Tooltip.InitialDelay = 0;
            Tooltip.ReshowDelay = 0;
            Tooltip.ShowAlways = true;
            Tooltip.UseAnimation = true;
            Tooltip.UseFading = true;
            Tooltip.IsBalloon = true;
            Tooltip.SetToolTip(fldSizeX, "pixel size in the x-direction in map units/pixel; unit is degree as the position! Example: 1.669E-4");
            Tooltip.SetToolTip(fldSizeY, "pixel size in the y-direction in map units/pixel; unit is degree as the position! Example: -9.278E-5");
            Tooltip.SetToolTip(fldRotationX, "rotation about x-axis; unit is degree as the position! Example: 0");
            Tooltip.SetToolTip(fldRotationY, "rotation about y-axis; unit is degree as the position! Example: 0");
            Tooltip.SetToolTip(fldX, "x-coordinate of the center of the upper left pixel; unit is degree! Example: 8.491");
            Tooltip.SetToolTip(fldY, "y-coordinate of the center of the upper left pixel; unit is degree! Example: 50.058");
        }
        #region load
        private void loadMaps()
        {
            listBox1.Items.Clear();
            List<Map> maps = Client.DBContext.MapSet.ToList();
            foreach (Map m in maps)
            {
                listBox1.Items.Add(new ListItem(m));
            }
        }

        class ListItem
        {
            private Map map;
            public ListItem(Map imap)
            {
                map = imap;
            }

            public override String ToString()
            {
                return map.Name;
            }
            public Map getMap()
            {
                return map;
            }
        }


        private void Map_VisibleChanged(object sender, EventArgs e)
        {
            loadMaps();
        }
        private void Map_Load(object sender, EventArgs e)
        {
            loadMaps();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMaps();
        }
        #endregion

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            btnSelectMap.Enabled = false;
            btnSelectWorldFile.Enabled = false;
            btnSave.Enabled = false;
            fldName.Enabled = false;
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                fldName.Text = li.getMap().Name;
                fldSizeX.Text = li.getMap().XSize.ToString();
                fldSizeY.Text = li.getMap().YSize.ToString();
                fldRotationX.Text = li.getMap().XRot.ToString();
                fldRotationY.Text = li.getMap().YRot.ToString();
                fldX.Text = li.getMap().XTopLeft.ToString();
                fldY.Text = li.getMap().YTopLeft.ToString();

                MemoryStream ms = new MemoryStream(li.getMap().Picture.Data);
                PictureBox1.Image = System.Drawing.Image.FromStream(ms);
                btnDelete.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ListItem li = listBox1.SelectedItem as ListItem;
            if (li != null)
            {
                Client.DBContext.MapSet.Remove(li.getMap());
                Client.DBContext.SaveChanges();
                loadMaps();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            fldName.Text = "";
            fldSizeX.Text = "";
            fldSizeY.Text = "";
            fldRotationX.Text = "";
            fldRotationY.Text = "";
            fldX.Text = "";
            fldY.Text = "";
            PictureBox1.Image = null;
            btnSelectMap.Enabled = true;
            btnSelectWorldFile.Enabled = true;
            fldName.Enabled = true;
        }

        private void btnSelectMap_Click(object sender, EventArgs e)
        {
            string FileFilter = "JPG Dateien (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|"
                                + "Bitmap Dateien (*.bmp)|*.bmp|"
                                + "Gif Dateien (*.gif)|*.gif|"
                                + "Png Dateien (*.png)|*.png";
            string GraphicFileFilter = "Alle Bilddateien|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "t_Picture";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = FileFilter + "|" + GraphicFileFilter;
            ofd.FilterIndex = 5;
            ofd.FileOk += new CancelEventHandler(ofd_FileOk);
            ofd.ShowDialog();
        }


        void ofd_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            PictureBox1.Image = Image.FromFile(ofd.FileName);
            btnSave.Enabled = true;
        }

        private void btnSelectWorldFile_Click(object sender, EventArgs e)
        {
            string FileFilter = "World file (*.jgw, *.pgw, *.gfw, *.tfw)|*.jgw;*.pgw;*.gfw;*.tfw";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "t_Picture";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = FileFilter;
            ofd.FilterIndex = 5;
            ofd.FileOk += new CancelEventHandler(ofd_FileOkWorld);
            ofd.ShowDialog();
        }

        void ofd_FileOkWorld(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            try
            {
                string[] world = File.ReadAllLines(ofd.FileName);
                fldSizeX.Text = Double.Parse(world[0], NumberFormatInfo.InvariantInfo).ToString();
                fldSizeY.Text = Double.Parse(world[3], NumberFormatInfo.InvariantInfo).ToString();
                fldRotationX.Text = Double.Parse(world[2], NumberFormatInfo.InvariantInfo).ToString();
                fldRotationY.Text = Double.Parse(world[1], NumberFormatInfo.InvariantInfo).ToString();
                fldX.Text = Double.Parse(world[4], NumberFormatInfo.InvariantInfo).ToString();
                fldY.Text = Double.Parse(world[5], NumberFormatInfo.InvariantInfo).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while reading World-File");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                btnDelete.Enabled = false;
                btnSelectMap.Enabled = false;
                btnSelectWorldFile.Enabled = false;
                btnSave.Enabled = false;
                fldName.Enabled = false;
                Map m = new Map();
                m.Name = fldName.Text;
                m.XSize = Double.Parse(fldSizeX.Text, NumberFormatInfo.InvariantInfo);
                m.YSize = Double.Parse(fldSizeY.Text, NumberFormatInfo.InvariantInfo);
                m.XRot = Double.Parse(fldRotationX.Text, NumberFormatInfo.InvariantInfo);
                m.YRot = Double.Parse(fldRotationY.Text, NumberFormatInfo.InvariantInfo);
                m.XTopLeft = Double.Parse(fldX.Text, NumberFormatInfo.InvariantInfo);
                m.YTopLeft = Double.Parse(fldY.Text, NumberFormatInfo.InvariantInfo);
                MemoryStream ms = new MemoryStream();
                PictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                m.Picture = new Picture();
                m.Picture.Data = ms.ToArray();
                m.Competition = Client.SelectedCompetition;
                Client.DBContext.MapSet.Add(m);
                Client.DBContext.SaveChanges();
                loadMaps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error while Saving");
            }
        }

    }
}
