﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GELive.ANRLDataService;

namespace GELive
{
    /// <summary>
    /// For demo and Debug-Use
    /// Select a delay to show old Data
    /// </summary>
    public partial class Delay_Select : Form
    {
        WSManager wsm;
        /// <summary>
        /// Constructor of Delay-Selection
        /// </summary>
        /// <param name="wsm">Tool-Strip</param>
        public Delay_Select(WSManager wsm)
        {
            this.wsm = wsm;
            InitializeComponent();

            //Add Delay-Selector

            ANRLDataServiceClient Client = new ANRLDataServiceClient();
            List<DateTime> Timestamps = Client.GetTimestamps();
            foreach (DateTime d in Timestamps)
            {
                listBox1.Items.Add(d);
            }
            listBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wsm.delaytimestamp = (DateTime)listBox1.SelectedItem;
            wsm.Delay = DateTime.Now - wsm.delaytimestamp;
        }
    }
}
