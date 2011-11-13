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
            List<NetworkObjects.Pilot> pilots =Client.getPilots();
            listViewPilots.Items.Clear();
            foreach (NetworkObjects.Pilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.Name, p.Surename });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            UpdateEnablement();
        }

        private void UpdateEnablement()
        {
            btnAddPicture.Enabled =((listViewPilots.SelectedItems.Count == 1) || newPilot);
            textBoxLastname.Enabled = btnAddPicture.Enabled;
            textBoxSurename.Enabled = btnAddPicture.Enabled;
            btnSave.Enabled = btnAddPicture.Enabled && pictureBox.Image != null;
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPilots.SelectedItems[0];
                NetworkObjects.Pilot pilot = lvi.Tag as NetworkObjects.Pilot;
                textBoxID.Text = pilot.ID.ToString();
                textBoxLastname.Text = pilot.Name;
                textBoxSurename.Text = pilot.Surename;
                newPilot = false;
                if (pilot.ID_Picture > 0)
                {
                    MemoryStream ms = new MemoryStream(Client.getPicture(pilot.ID_Picture).Image);
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                    textBoxPictureId.Text = Client.getPicture(pilot.ID_Picture).ID.ToString(); 
                }
                else
                {
                    pictureBox.Image = null;
                    textBoxPictureId.Text ="0";
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
                textBoxID.Text = "0";
                textBoxLastname.Text = "";
                textBoxSurename.Text = "";
                pictureBox.Image = null;
                textBoxPictureId.Text = "0"; 
                UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id=Int32.Parse(textBoxID.Text);
            int picId = Int32.Parse(textBoxPictureId.Text);
            if (picId == -1)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Picture picture = new Picture();
                picture.Image = ms.ToArray();
                picture.Name = textBoxLastname.Text + textBoxSurename.Text;
                picId = Client.savePicture(picture);
            }
            NetworkObjects.Pilot pilot = new NetworkObjects.Pilot();
            pilot.ID = id;
            pilot.Name = textBoxLastname.Text;
            pilot.Surename =  textBoxSurename.Text;
            pilot.ID_Picture = picId;
            Client.savePilot(pilot);
            newPilot = false;
            ResetFields();
            UpdateListe();
            UpdateEnablement();
        }

        

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            string FileFilter = "JPG Dateien (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|" 
            + "Bitmap Dateien (*.bmp)|*.bmp|"
            + "Gif Dateien (*.gif)|*.gif|" 
            + "Png Dateien (*.png)|*.png";
            string GraphicFileFilter = "Alle Bilddateien|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Picture";
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
            pictureBox.Image = Image.FromFile(ofd.FileName);
            textBoxPictureId.Text = "-1";
            UpdateEnablement();
        }
    }
}
