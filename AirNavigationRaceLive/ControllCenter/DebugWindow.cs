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
            listView1.Items.Clear();
            List<t_Log> List = LogManager.GetLogEntries(C.DB_Path, 200);
            List.Sort(new LogComparer());
            ListViewItem lvi;
            foreach (t_Log l in List)
            {
                lvi = new ListViewItem();
                lvi.Text = l.id.ToString();
                lvi.SubItems.Add(l.level.ToString());
                lvi.SubItems.Add(l.project);
                lvi.SubItems.Add(l.Text);
                lvi.SubItems.Add(l.timestamp.ToString());
                listView1.Items.Add(lvi);
            }
        }
    }
    public class LogComparer : Comparer<t_Log>
    {
        public override int Compare(t_Log x, t_Log y)
        {
            if (((int)x.id) < ((int)y.id)) return 1;
            if (((int)x.id) > ((int)y.id)) return -1;
            return 0;
        }
    }
}
