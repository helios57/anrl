using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANR
{
    public partial class ImageViewer : Form
    {

        public ImageViewer(Image img)
        {
            InitializeComponent();
            imgImage.Image = img;
            this.MaximizeBox = true;
       
        }
    }
}
