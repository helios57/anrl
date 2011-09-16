using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;

namespace AirNavigationRaceLive.Dialogs
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnToWGS_Click(object sender, EventArgs e)
        {
            try
            {
                double east = double.Parse(textEast.Text);
                double north = double.Parse(textNorth.Text);
                textLatitude.Text = Converter.CHtoWGSlat(east, north).ToString();
                textLongitude.Text = Converter.CHtoWGSlng(east, north).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnToCh_Click(object sender, EventArgs e)
        {
            try
            {
                double latitude = double.Parse(textLatitude.Text);
                double longitude = double.Parse(textLongitude.Text);
                textEast.Text = Converter.WGStoChEastY(longitude, latitude).ToString();
                textNorth.Text = Converter.WGStoChNorthX(longitude, latitude).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
