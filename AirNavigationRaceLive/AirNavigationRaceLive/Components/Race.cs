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
    public partial class Race : UserControl
    {
        private Client.Client Client;
        public Race(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }
    }
}
