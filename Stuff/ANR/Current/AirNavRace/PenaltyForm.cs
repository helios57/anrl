using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class PenaltyForm : Form
    {
        public event EventHandler PenaltySubmitButtonClick;
        private string title;
        private string groupBoxTitle;
        private string submitButtonText;
        private int penaltyPoints;
        private string comment;

        public int PenaltyPoints
        {
            get { return penaltyPoints; }
            set { penaltyPoints = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        
        public PenaltyForm()
        {
            InitializeComponent();
        }

        public PenaltyForm(string title, string groupBoxTitle, string submitButtonText) : 
            this(title, groupBoxTitle, submitButtonText, 0, string.Empty)
        {
        }

        public PenaltyForm(string title, string groupBoxTitle, string submitButtonText, int penaltyPoints, string comment)
        {
            InitializeComponent();
            this.title = title;
            this.groupBoxTitle = groupBoxTitle;
            this.submitButtonText = submitButtonText;
            this.penaltyPoints = penaltyPoints;
            this.comment = comment;
        }

        private void competitorForm_Load(object sender, EventArgs e)
        {
            this.Text = this.title;
            this.penGroupName.Text = this.groupBoxTitle;
            this.penButtonSubmit.Text = this.submitButtonText;
            if (this.penaltyPoints > 0)
            {
                this.penFormPenPointsTextBox.Text = this.penaltyPoints.ToString();
            }
            this.penFormCommentTextBox.Text = this.comment;
        }

        private void compAddButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void compButtonSubmit_Click(object sender, EventArgs e)
        {
            int tmpPenaltyPoints;
            if (int.TryParse(penFormPenPointsTextBox.Text, out tmpPenaltyPoints))
            {
                penaltyPoints = tmpPenaltyPoints;
                comment = penFormCommentTextBox.Text;
                PenaltySubmitButtonClick(this, new EventArgs());
            }
            else
            {
                penFormPenPointsLabel.ForeColor = Color.Red;
            }
        }
    }
}
