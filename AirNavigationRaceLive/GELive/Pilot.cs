using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using ANRL.ANRLDataService;

namespace ANRLClient
{
    public partial class Pilot : Form
    {
        public event EventHandler OnPilotOk;
        private Binary Picture=null;
        private int idSelectedPilot = 0;
        
        public Pilot()
        {
            InitializeComponent();
            if (InformationPool.Client != null && InformationPool.Client.State == System.ServiceModel.CommunicationState.Opened)
            {
                LoadPilotes();
                dataGridView1.Rows.Clear();
                DataGridViewRow Row1;
                DataGridViewImageCell im;
                MemoryStream ms;
                foreach (t_Picture p in InformationPool.Flags)
                {
                    Row1 = new DataGridViewRow();
                    DataGridViewTextBoxCell imt = new DataGridViewTextBoxCell();
                    imt.Value = p.id;
                    Row1.Cells.Add(imt);
                    imt = new DataGridViewTextBoxCell();
                    imt.Value = p.Name;
                    Row1.Cells.Add(imt);

                    im = new DataGridViewImageCell();
                    Row1.Height = 50;
                    ms = new MemoryStream(p.Data.Bytes);
                    im.Value =  System.Drawing.Image.FromStream(ms);
                    ms.Close();
                    Row1.Cells.Add(im);
                    dataGridView1.Rows.Add(Row1);
                }
            }
        }
        private void LoadPilotes()
        {
            grdVPilotToUse.Rows.Clear();
            InformationPool.PilotList.Clear();
            DataGridViewRow Row1;
            DataGridViewImageCell im;
            MemoryStream ms;
            foreach (t_Pilot p in InformationPool.Client.GetPilots())
            {
                InformationPool.PilotList.Add(p);
                Row1 = new DataGridViewRow();
                DataGridViewTextBoxCell imt = new DataGridViewTextBoxCell();
                imt.Value = p.ID;
                Row1.Cells.Add(imt);
                imt = new DataGridViewTextBoxCell();
                imt.Value = p.LastName;
                Row1.Cells.Add(imt);
                imt = new DataGridViewTextBoxCell();
                imt.Value = p.SureName;
                Row1.Cells.Add(imt);

                im = new DataGridViewImageCell();
                Row1.Height = 50;
                if (p.Picture != null)
                {
                    ms = new MemoryStream(p.Picture.Bytes);
                    im.Value = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                }
                Row1.Cells.Add(im);

                im = new DataGridViewImageCell();
                Row1.Height = 50;
                if (p.ID_Flag != null)
                {
                    ms = new MemoryStream(InformationPool.Flags.Single(pi => pi.id == p.ID_Flag).Data.Bytes);
                    im.Value = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                }
                Row1.Cells.Add(im);

                grdVPilotToUse.Rows.Add(Row1);
            }            
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (idSelectedPilot > 0)
            {
                OnPilotOk.Invoke(idSelectedPilot, null);
            }
            this.Close();
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog ColorDialog_Pilot = new ColorDialog();
            ColorDialog_Pilot.ShowDialog();
            btnColor.BackColor = ColorDialog_Pilot.Color;
        }
        private void btnAddPilot_Click(object sender, EventArgs e)
        {
            PilotEntry pe = new PilotEntry();
            pe.LastName = fldLastName.Text;
            pe.SureName = fldSureName.Text;
            pe.PilotColor = btnColor.BackColor.ToArgb().ToString();

            MemoryStream stream = new MemoryStream();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            pe.Picture = new Binary();
            pe.Picture.Bytes = stream.ToArray();
            stream.Close();
            pe.FlagId = Int32.Parse(fldFlagId.Text);
            if (fldId.Text == "")
            {
                pe.ID = InformationPool.Client.AddNewPilot(pe.LastName, pe.SureName, pe.PilotColor, pe.Picture.Bytes, pe.FlagId).ToString();
            }
            else
            {
                int TID = InformationPool.PilotList.Where(p => p.ID == idSelectedPilot).First().ID_Tracker;
                
                InformationPool.Client.AddPilot(idSelectedPilot,TID, pe.LastName, pe.SureName, pe.PilotColor, pe.Picture.Bytes, pe.FlagId);
            }
            LoadPilotes(); 
            tabControl1.SelectedIndex = 0;
        }
        public Image ResizeImage(Image img)
        {
            //create a new Bitmap the size of the new image
            Bitmap bmp = new Bitmap(100, 100);
            //create a new graphic from the Bitmap
            Graphics graphic = Graphics.FromImage((Image)bmp);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //draw the newly resized image
            graphic.DrawImage(img, 0, 0, 100, 100);
            //dispose and free up the resources
            graphic.Dispose();
            //return the image
            return (Image)bmp;
        } 
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "png Pictures | *.png";
            of.FileOk += new CancelEventHandler(of_FileOk);
            of.ShowDialog();
        }

        void of_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog of = sender as OpenFileDialog;
            if (of != null)
            {
                
                FileStream  fs = File.OpenRead(of.FileName);
                List<Byte> lb = new List<Byte>();
                int b;
                while ((b = fs.ReadByte())>=0)
                {
                    lb.Add((Byte)b);
                }
                Picture = new Binary();
                Picture.Bytes = lb.ToArray();
                MemoryStream ms = new MemoryStream(lb.ToArray());
                pictureBox1.Image = ResizeImage(System.Drawing.Image.FromStream(ms));
                ms.Close();
                fs.Close();
            //MemoryStream stream = new MemoryStream(MyData);
           // pictureBox2.Image = Image.FromStream(stream);
            //pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void grdVPilotToUse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id=0;
                if (grdVPilotToUse.SelectedRows.Count == 1)
                {
                    id = (int)grdVPilotToUse.SelectedRows[0].Cells[0].Value;
                }
                else if (grdVPilotToUse.SelectedCells.Count == 1)
                {
                    id = (int)grdVPilotToUse.Rows[grdVPilotToUse.SelectedCells[0].RowIndex].Cells[0].Value;
                }
                if (id > 0)
                {
                    idSelectedPilot = id;
                    btnModiyPilot.Enabled = true;
                    btnUsePilot.Enabled = true;
                }
                else
                {
                    btnModiyPilot.Enabled = false;
                    btnUsePilot.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine(ex.Message);
                btnModiyPilot.Enabled = false;
                btnUsePilot.Enabled = false;
            }
        }

        private void btnAddNewPilot_Click(object sender, EventArgs e)
        {
            idSelectedPilot = 0;
            LoadPilotDetail();
            tabControl1.SelectedIndex = 1;
            btnModiyPilot.Enabled = false;
            btnUsePilot.Enabled = false;
        }

        private void btnModiyPilot_Click(object sender, EventArgs e)
        {
            LoadPilotDetail();
            tabControl1.SelectedIndex = 1;
            btnModiyPilot.Enabled = false;
            btnUsePilot.Enabled = false;
        }
        private void LoadPilotDetail()
        {
            if (idSelectedPilot == 0)
            {
                fldId.Text = "";
                fldLastName.Text = "";
                fldSureName.Text = "";
                btnColor.BackColor = Color.White;
                pictureBox1.Image = null;
                fldFlagId.Text = (200).ToString();
            }
            else
            {
                if (idSelectedPilot > 0)
                {
                    try{
                        t_Pilot p = InformationPool.PilotList.Single(pi => pi.ID == idSelectedPilot);
                        fldId.Text = p.ID.ToString();

                        fldLastName.Text = p.LastName;
                        fldSureName.Text = p.SureName;
                        btnColor.BackColor = Color.FromArgb(Int32.Parse(p.Color));
                        if (p.Picture != null)
                        {
                            MemoryStream ms = new MemoryStream(p.Picture.Bytes);
                            pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                            ms.Close();
                        }
                        fldFlagId.Text = p.ID_Flag.ToString();
                    }catch{}
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            }
            else if (dataGridView1.SelectedCells.Count == 1)
            {
                id = (int)dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells[0].Value;
            }
            fldFlagId.Text =id.ToString();
        }
    }
}
