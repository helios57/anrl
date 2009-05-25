using System;
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
    public partial class Delay_Select : Form
    {
        GEToolStrip ts;
        /// <summary>
        /// Constructor of Delay-Selection
        /// </summary>
        /// <param name="ts">Tool-Strip</param>
        public Delay_Select(GEToolStrip ts)
        {
            this.ts = ts;
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
            ts.ws.delaytimestamp = (DateTime) listBox1.SelectedItem;
            ts.ws.Delay = DateTime.Now - ts.ws.delaytimestamp;
        }
    }
}
