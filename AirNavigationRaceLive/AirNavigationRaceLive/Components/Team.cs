using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Components
{
    public partial class Team : UserControl
    {        
        private AnrlInterfaces.IAnrlClient Client;
        public Team(AnrlInterfaces.IAnrlClient iClient)
        {
            Client = iClient;
            InitializeComponent();
        }
    }
}
