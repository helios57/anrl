using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataService;

namespace ControllCenter
{
    public partial class DebugWindow : Form
    {
        ControllCenter C;
        public DebugWindow(ControllCenter C)
        {
            this.C = C;
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<t_Log> List = LogManager.GetLogEntries(C.DB_Path, 200);
            ListViewItem lvi;
            foreach (t_Log l in List)
            {
                lvi = new ListViewItem();
                lvi.Name = l.id.ToString();
                lvi.SubItems.Add(l.level.ToString());
                lvi.SubItems.Add(l.project);
                lvi.SubItems.Add(l.Text);
                lvi.SubItems.Add(l.timestamp.ToString());
                listView1.Items.Add(lvi);
            }
        }
    }
}
