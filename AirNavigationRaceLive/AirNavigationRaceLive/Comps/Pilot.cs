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
        private Client.DataAccess Client;
        private Subscriber selectedSubscriber=null;

        public Pilot(Client.DataAccess iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void Pilot_Load(object sender, EventArgs e)
        {
            UpdateListe();
        }

        private void UpdateListe()
        {
            List<Subscriber> pilots =Client.SelectedCompetition.Subscriber.ToList();
            listViewPilots.Items.Clear();
            foreach (Subscriber p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.Id.ToString(), p.LastName, p.FirstName });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            UpdateEnablement();
        }

        private void UpdateEnablement()
        {
            btnAddt_Picture.Enabled =selectedSubscriber!=null;
            textBoxLastname.Enabled = btnAddt_Picture.Enabled;
            textBoxFirstName.Enabled = btnAddt_Picture.Enabled;
            btnSave.Enabled = btnAddt_Picture.Enabled && PictureBox.Image != null;
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listViewPilots.SelectedItems[0];
                Subscriber pilot = lvi.Tag as Subscriber;
                textBoxLastname.Text = pilot.LastName;
                textBoxFirstName.Text = pilot.FirstName;
                selectedSubscriber = pilot;
                if (pilot.Picture!=null)
                {
                    MemoryStream ms = new MemoryStream(pilot.Picture.Data);
                    PictureBox.Image = System.Drawing.Image.FromStream(ms);
                }
                else
                {
                    PictureBox.Image = global::AirNavigationRaceLive.Properties.Resources._default;
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
            selectedSubscriber = new Subscriber();
            UpdateEnablement();
        }

        private void ResetFields()
        {
                textBoxLastname.Text = "";
                textBoxFirstName.Text = "";
                selectedSubscriber = null;
                PictureBox.Image = global::AirNavigationRaceLive.Properties.Resources._default;
                UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Subscriber pilot = selectedSubscriber;
            if (pilot == null)
            {
                return;
            }
            pilot.LastName = textBoxLastname.Text;
            pilot.FirstName =  textBoxFirstName.Text;
            pilot.Competition = Client.SelectedCompetition;
            if (PictureBox.Tag == null)
            {
                MemoryStream ms = new MemoryStream();
                PictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                Picture pic = new Picture();
                pic.Data = ms.ToArray();
                pilot.Picture = pic;
            }
            if(pilot.Id == 0){
                Client.DBContext.SubscriberSet.Add(pilot);
            }
            Client.DBContext.SaveChanges();
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
            PictureBox.Tag = null;
            UpdateEnablement();
        }
    }
}
