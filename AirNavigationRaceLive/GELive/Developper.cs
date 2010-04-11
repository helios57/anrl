using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ANRLClient
{
    public partial class Developper : Form
    {
        private int trans = 0;
        public Developper()
        {
            InitializeComponent();
            setTrans();
            Timer t = new Timer();
            t.Interval = 40;
            t.Tick += new EventHandler(t_Tick);
            t.Start();    
        }
        void t_Tick(object sender, EventArgs e)
        {
            trans++;
            setTrans();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void setTrans()
        {
            btnClose.Visible = trans > 100;

            SetAlpha(lblDeveloppedBy, 5);

            SetAlpha(lblLuc, 2);
            SetAlpha(lblLucMail, 1.8);
            SetAlpha(lblLuc1, 1.5);
            SetAlpha(lblLuc2, 1.4);
            SetAlpha(lblLuc3, 1.3);
            SetAlpha(lblLuc4, 1.2);

            SetAlpha(lblThanks, 0.7);
            SetAlpha(lblMaurice, 0.6);
            SetAlpha(lblFrieden, 0.5);
            SetAlpha(lblPfa, 0.49);
            SetAlpha(lblNick, 0.48);
            SetAlpha(lblRobin, 0.47);
            SetAlpha(lblHeini, 0.46);

            SetAlpha(lblLuca, 1);
            SetAlpha(lblLucaMail, 0.8);
            SetAlpha(lblLucaTested, 0.8);
            SetAlpha(lblLuca1, 0.8);
            SetAlpha(lblDomi, 1);
            SetAlpha(lblDomi1, 0.8);
        }
        private byte getAlpha(double multiplier)
        {
            int result = (int)(trans * multiplier);
            return (byte) ((result < 255)?result:255);
        }
        private void SetAlpha(Label l,double multiplier)
        {
            int R = this.BackColor.R - getAlpha(multiplier);
            byte Rb = (byte)((R > 0) ? R : 0);
            int G = this.BackColor.G - getAlpha(multiplier);
            byte Gb = (byte)((G > 0) ? G : 0);
            int B =  this.BackColor.B - getAlpha(multiplier);
            byte Bb = (byte)((B > 0) ? B : 0);
            l.ForeColor = Color.FromArgb(Rb, Gb, Bb);
        }
    }
}
