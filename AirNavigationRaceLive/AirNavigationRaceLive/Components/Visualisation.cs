﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components
{
    public partial class Visualisation : UserControl
    {     
        private AnrlInterfaces.IAnrlClient Client;
        public Visualisation(AnrlInterfaces.IAnrlClient iClient)
        {
            Client = iClient;
            InitializeComponent();
        }
    }
}