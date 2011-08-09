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
            /*List<IPilot> pilots = null;//Client.getPilots();
            listViewPilots.Items.Clear();
            foreach (IPilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.Name, p.Surename });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            UpdateEnablement();*/
        }

        private void UpdateEnablement()
        {
            btnAddPicture.Enabled =((listViewPilots.SelectedItems.Count == 1) || newPilot);
            btnSave.Enabled = btnAddPicture.Enabled && pictureBox.Image != null;
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
               /* ListViewItem lvi = listViewPilots.SelectedItems[0];
                IPilot pilot = lvi.Tag as IPilot;
                textBoxID.Text = pilot.ID.ToString();
                textBoxLastname.Text = pilot.Name;
                textBoxSurename.Text = pilot.Surename;
                newPilot = false;
                if (pilot.Picture != null)
                {
                    MemoryStream ms = new MemoryStream(pilot.Picture.Image);
                    pictureBox.Image = System.Drawing.Image.FromStream(ms);
                    textBoxPictureId.Text = pilot.Picture.ID.ToString(); 
                }
                else
                {
                    pictureBox.Image = null;
                    textBoxPictureId.Text ="0"; 
                }*/
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
            long id=Int32.Parse(textBoxID.Text);
            long picId = Int32.Parse(textBoxPictureId.Text);
            MemoryStream ms = new MemoryStream();
            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

            /*IPicture picture = new PictureEntry(picId, ms.ToArray());
            PilotEntry pe = new PilotEntry(id, textBoxLastname.Text, textBoxSurename.Text, picture);
            //Client.addPilot(pe);
            newPilot = false;
            ResetFields();
            UpdateListe();
            UpdateEnablement();*/
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
            UpdateEnablement();
        }
    }
}
