﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            ANRL_Service_reference.ANRLDataServiceClient dataContext = new Controlls.ANRL_Service_reference.ANRLDataServiceClient();
            
            //@todo Fill the List with information
            List<List<List<double>>> ForbiddenZones = new List<List<List<double>>>();

            dataContext.AddPolygons(ForbiddenZones);
        }
    }
}
