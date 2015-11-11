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

namespace AirNavigationRaceLive.Comps
{
    public partial class Pilot : UserControl
    {
        private Client.Client Client;
        private int selectedId=0;
        private bool newPilot;

        public Pilot(Client.Client iClient)
        {
            Client = iClient;
            newPilot = false;
            InitializeComponent();
        }

        private void Pilot_Load(object sender, EventArgs e)
        {
            UpdateListe();
        }

        private void UpdateListe()
        {
            List<t_Pilot> pilots =Client.getPilots();
            listViewPilots.Items.Clear();
            foreach (t_Pilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.LastName, p.SureName });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            UpdateEnablement();
        }

        private void UpdateEnablement()
        {
            btnAddt_Picture.Enabled =((listViewPilots.SelectedItems.Count == 1) || newPilot);
            textBoxLastname.Enabled = btnAddt_Picture.Enabled;
            textBoxSurename.Enabled = btnAddt_Picture.Enabled;
            btnSave.Enabled = btnAddt_Picture.Enabled && PictureBox.Image != null;
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPilots.SelectedItems[0];
                t_Pilot pilot = lvi.Tag as t_Pilot;
                textBoxLastname.Text = pilot.LastName;
                textBoxSurename.Text = pilot.SureName;
                selectedId = pilot.ID;
                newPilot = false;
                if (pilot.ID_Picture > 0)
                {
                    MemoryStream ms = new MemoryStream(pilot.t_Picture.Data);
                    PictureBox.Image = System.Drawing.Image.FromStream(ms);
                    textBoxt_PictureId.Text = pilot.t_Picture.ID.ToString(); 
                }
                else
                {
                    PictureBox.Image = global::AirNavigationRaceLive.Properties.Resources._default;
                    textBoxt_PictureId.Text ="0";
                }
            }
            else
            {
                ResetFields();
            }
            UpdateEnablement();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetFields();
            UpdateListe();
            UpdateEnablement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ResetFields();
            newPilot = true;
            UpdateEnablement();
        }

        private void ResetFields()
        {
                newPilot = false;
                textBoxLastname.Text = "";
                textBoxSurename.Text = "";
                selectedId = 0;
                PictureBox.Image = global::AirNavigationRaceLive.Properties.Resources._default;
                textBoxt_PictureId.Text = "0"; 
                UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = selectedId;
            int picId = Int32.Parse(textBoxt_PictureId.Text);
            if (picId == -1)
            {
                MemoryStream ms = new MemoryStream();
                PictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                t_Picture t_Picture = new t_Picture();
                t_Picture.Data = ms.ToArray();
                t_Picture.Name = textBoxLastname.Text + textBoxSurename.Text;
                picId = Client.savePicture(t_Picture);
            }
            t_Pilot pilot = new t_Pilot();
            pilot.ID = id;
            pilot.LastName = textBoxLastname.Text;
            pilot.SureName =  textBoxSurename.Text;
            pilot.ID_Picture = picId;
            pilot.t_CompetitionSet = Client.getSelectedCompetitionSet();
            Client.savePilot(pilot);
            newPilot = false;
            ResetFields();
            UpdateListe();
            UpdateEnablement();
        }

        

        private void btnAddt_Picture_Click(object sender, EventArgs e)
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
            PictureBox.Image = Image.FromFile(ofd.FileName);
            textBoxt_PictureId.Text = "-1";
            UpdateEnablement();
        }
    }
}
