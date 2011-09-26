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
using swisstopo.geodesy.gpsref;
using NetworkObjects;
using AirNavigationRaceLive.Comps.Helper;

namespace AirNavigationRaceLive.Comps
{
    public partial class MapLegacy : UserControl
    {
        private Client.Client Client;

        public MapLegacy(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();   
        }
      

       

        private void btnImportANR_Click(object sender, EventArgs e)
        {
            btnImportANR.Enabled = false;
            OpenFileDialog ofd = new OpenFileDialog();
            string FileFilter = "JPG Dateien (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|"
                    + "Bitmap Dateien (*.bmp)|*.bmp|"
                    + "Gif Dateien (*.gif)|*.gif|"
                    + "Png Dateien (*.png)|*.png";
            string GraphicFileFilter = "Alle Bilddateien|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png";
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
            PictureBox p = new PictureBox();
            p.Image = Image.FromFile(ofd.FileName);
            NetworkObjects.Map m = new NetworkObjects.Map();
            m.Name = fldName.Text;
            string[] coordinatesFromPath = ofd.FileName.Remove(ofd.FileName.LastIndexOf(".")).Substring(ofd.FileName.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            foreach (string coordinate in coordinatesFromPath)
            {
                if (coordinate.Length != 6 || coordinate == null || coordinate == string.Empty)
                {
                    throw (new FormatException("Coordinates in image name not in correct format!"));
                }
            }

            double topLeftLatitude = Converter.CHtoWGSlat(Convert.ToDouble(coordinatesFromPath[0]), Convert.ToDouble(coordinatesFromPath[1]));
            double topLeftLongitude = Converter.CHtoWGSlng(Convert.ToDouble(coordinatesFromPath[0]), Convert.ToDouble(coordinatesFromPath[1]));
            double bottomRightLatitude = Converter.CHtoWGSlat(Convert.ToDouble(coordinatesFromPath[2]), Convert.ToDouble(coordinatesFromPath[3]));
            double bottomRightLongitude = Converter.CHtoWGSlng(Convert.ToDouble(coordinatesFromPath[2]), Convert.ToDouble(coordinatesFromPath[3]));

            m.XSize = (bottomRightLongitude - topLeftLongitude) / p.Image.Width;
            m.YSize = (bottomRightLatitude - topLeftLatitude) / p.Image.Height;
            m.XRot = 0;
            m.YRot = 0;
            m.XTopLeft = topLeftLongitude;
            m.YTopLeft = topLeftLatitude;
            MemoryStream ms = new MemoryStream();
            p.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Picture picture = new Picture();
            picture.Image = ms.ToArray();
            picture.Name = m.Name;
            m.ID_Picture = Client.savePicture(picture);
            Client.saveMap(m);
            btnImportANR.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            OpenFileDialog ofd = new OpenFileDialog();
            string FileFilter = "JPG Dateien (*.jpg, *.jpeg, *.jpe, *.jfif)|*.jpg;*.jpeg;*.jpe;*.jfif|"
                    + "Bitmap Dateien (*.bmp)|*.bmp|"
                    + "Gif Dateien (*.gif)|*.gif|"
                    + "Png Dateien (*.png)|*.png";
            string GraphicFileFilter = "Alle Bilddateien|*.jpg;*.jpeg;*.jpe;*.jfif;*.bmp;*.gif;*.png";
            ofd.Title = "Picture";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = false;
            ofd.Filter = FileFilter + "|" + GraphicFileFilter;
            ofd.FilterIndex = 5;
            ofd.FileOk += new CancelEventHandler(ofd_FileOk2);    
            ofd.ShowDialog();
        }

        void ofd_FileOk2(object sender, CancelEventArgs e)
        {
            OpenFileDialog ofd = sender as OpenFileDialog;
            PictureBox p = new PictureBox();
            p.Image = Image.FromFile(ofd.FileName);
            NetworkObjects.Map m = new NetworkObjects.Map();
            m.Name = fldName.Text;
            double topLeftLatitude;
            double topLeftLongitude;
            double bottomRightLatitude;
            double bottomRightLongitude;
            string[] coordinatesFromPath = ofd.FileName.Remove(ofd.FileName.LastIndexOf(".")).Substring(ofd.FileName.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            topLeftLatitude = Convert.ToDouble(coordinatesFromPath[0]); 
            topLeftLongitude = Convert.ToDouble(coordinatesFromPath[1]);
            bottomRightLatitude = Convert.ToDouble(coordinatesFromPath[2]);
            bottomRightLongitude = Convert.ToDouble(coordinatesFromPath[3]);

            m.XSize = (bottomRightLongitude -topLeftLongitude ) / p.Image.Width;
            m.YSize = (bottomRightLatitude - topLeftLatitude) / p.Image.Height;
            m.XRot = 0;
            m.YRot = 0;
            m.XTopLeft = topLeftLongitude;
            m.YTopLeft = topLeftLatitude;
            MemoryStream ms = new MemoryStream();
            p.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            Picture picture = new Picture();
            picture.Image = ms.ToArray();
            picture.Name = m.Name;
            m.ID_Picture = Client.savePicture(picture);
            Client.saveMap(m);
            button1.Enabled = true;
        }
    }

   
}
