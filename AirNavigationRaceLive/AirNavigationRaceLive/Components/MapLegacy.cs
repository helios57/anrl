using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnrlInterfaces;
using System.IO;
using AirNavigationRaceLive.Components.Model;
using swisstopo.geodesy.gpsref;

namespace AirNavigationRaceLive.Components
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
            MapImpl m = new MapImpl();
            m._Name = fldName.Text;
            double topLeftLatitude;
            double topLeftLongitude;
            double bottomRightLatitude;
            double bottomRightLongitude;
            string[] coordinatesFromPath = ofd.FileName.Remove(ofd.FileName.LastIndexOf(".")).Substring(ofd.FileName.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            foreach (string coordinate in coordinatesFromPath)
            {
                if (coordinate.Length != 6 || coordinate == null || coordinate == string.Empty)
                {
                    throw (new FormatException("Coordinates in image name not in correct format!"));
                }
            }
            topLeftLongitude = Convert.ToDouble(coordinatesFromPath[0]);
            topLeftLatitude = Convert.ToDouble(coordinatesFromPath[1]);
            bottomRightLongitude = Convert.ToDouble(coordinatesFromPath[2]);
            bottomRightLatitude = Convert.ToDouble(coordinatesFromPath[3]);
            double dummyHeight = 0;
            ApproxSwissProj.LV03toWGS84(topLeftLongitude, topLeftLatitude, 500.0f, ref topLeftLatitude, ref topLeftLongitude, ref dummyHeight);
            ApproxSwissProj.LV03toWGS84(bottomRightLongitude, bottomRightLatitude, 500.0f, ref bottomRightLatitude, ref bottomRightLongitude, ref dummyHeight);

            m._XSize = (bottomRightLongitude - topLeftLongitude) / p.Image.Width;
            m._YSize = (bottomRightLatitude - topLeftLatitude) / p.Image.Height;
            m._XRot = 0;
            m._YRot = 0;
            m._XTopLeft = topLeftLongitude;
            m._YTopLeft = topLeftLatitude;
            MemoryStream ms = new MemoryStream();
            p.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            IPicture picture = new PictureEntry(0, ms.ToArray());
            m._Picture = picture;
            //Client.addMap(m);
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            MapImpl m = new MapImpl();
            m._Name = fldName.Text;
            double topLeftLatitude;
            double topLeftLongitude;
            double bottomRightLatitude;
            double bottomRightLongitude;
            string[] coordinatesFromPath = ofd.FileName.Remove(ofd.FileName.LastIndexOf(".")).Substring(ofd.FileName.LastIndexOf(@"\") + 1).Split("_".ToCharArray());
            topLeftLatitude = Convert.ToDouble(coordinatesFromPath[0]); 
            topLeftLongitude = Convert.ToDouble(coordinatesFromPath[1]);
            bottomRightLatitude = Convert.ToDouble(coordinatesFromPath[2]);
            bottomRightLongitude = Convert.ToDouble(coordinatesFromPath[3]);

            m._XSize = (bottomRightLongitude -topLeftLongitude ) / p.Image.Width;
            m._YSize = (bottomRightLatitude - topLeftLatitude) / p.Image.Height;
            m._XRot = 0;
            m._YRot = 0;
            m._XTopLeft = topLeftLongitude;
            m._YTopLeft = topLeftLatitude;
            MemoryStream ms = new MemoryStream();
            p.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            IPicture picture = new PictureEntry(0, ms.ToArray());
            m._Picture = picture;
           //Client.addMap(m);
        }
    }

   
}
