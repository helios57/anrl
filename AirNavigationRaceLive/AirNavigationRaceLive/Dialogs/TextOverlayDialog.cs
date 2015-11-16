using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;
using System.Globalization;

namespace AirNavigationRaceLive.Dialogs
{
    public partial class TextOverlayDialog : Form
    {
        public string text = null;
        public TextOverlayDialog()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            text = textBox.Text;
            Close();
        }
    }
}
