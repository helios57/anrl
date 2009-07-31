﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Controlls.ANRL_Service_reference;

namespace Controlls
{
    public partial class ANRL : UserControl
    {
        public ANRL()
        {
            InitializeComponent();
        }

        private void btnAddForbiddenZones_Click(object sender, EventArgs e)
        {
            //@todo Fill the List with information
            List<List<List<double>>> ForbiddenZones = new List<List<List<double>>>();

            //Loop through all Forbiddenzones
            for (int i = 0; i < 10; i++)
            {
                List<List<double>> Zone = new List<List<double>>();
                //Loop through all Points
                for (int j = 0; j < 10; j++)
                {
                    List<double> Point = new List<double>();
                    double longitude = i * j;
                    double latitude = Math.Abs((i - j) * j / (i+1));
                    Point.Add(longitude);
                    Point.Add(latitude);
                    Zone.Add(Point);
                }
                ForbiddenZones.Add(Zone);
            }

            ANRLDataServiceClient dataContext = new ANRLDataServiceClient();

            dataContext.AddPolygons(ForbiddenZones.ToList());
        }
    }
}
