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
    public partial class CompetitorForm : Form
    {
        public event EventHandler SubmitButtonClick;
        private string title;
        private string groupBoxTitle;
        private string submitButtonText;
        private Guid competitorId;
        private int competitionNumber;
        private string acCallsign;
        private string country;
        private string pilotFirstName;
        private string pilotLastName;
        private string navigatorFirstName;
        private string navigatorLastName;

        public Guid CompetitorId
        {
            get { return competitorId; }
            set { competitorId = value; }
        }
        
        public int CompetitionNumber
        {
            get { return competitionNumber; }
            set { competitionNumber = value; }
        }
        public string AcCallsign
        {
            get { return acCallsign; }
            set { acCallsign = value; }
        }
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public string PilotFirstName
        {
            get { return pilotFirstName; }
            set { pilotFirstName = value; }
        }
        public string PilotLastName
        {
            get { return pilotLastName; }
            set { pilotLastName = value; }
        }
        public string NavigatorFirstName
        {
            get { return navigatorFirstName; }
            set { navigatorFirstName = value; }
        }
        public string NavigatorLastName
        {
            get { return navigatorLastName; }
            set { navigatorLastName = value; }
        }

        public CompetitorForm()
        {
            InitializeComponent();
        }

        public CompetitorForm(string title, string groupBoxTitle, string submitButtonText) : 
            this(title, groupBoxTitle, submitButtonText, 0, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public CompetitorForm(string title, string groupBoxTitle, string submitButtonText, int competitionNumber,
            string acCallsign, string country, string pilotFirstName, string pilotLastName, string navigatorFirstName, string navigatorLastName)
        {
            InitializeComponent();
            this.title = title;
            this.groupBoxTitle = groupBoxTitle;
            this.submitButtonText = submitButtonText;
            this.competitionNumber = competitionNumber;
            this.acCallsign = acCallsign;
            this.country = country;
            this.pilotFirstName = pilotFirstName;
            this.pilotLastName = pilotLastName;
            this.navigatorFirstName = navigatorFirstName;
            this.navigatorLastName = navigatorLastName;
        }

        private void competitorForm_Load(object sender, EventArgs e)
        {
            this.Text = this.title;
            this.compGroupName.Text = this.groupBoxTitle;
            this.compButtonSubmit.Text = this.submitButtonText;
            this.compAcCallsign.Text = this.acCallsign;
            this.compPilotFirstName.Text = this.pilotFirstName;
            this.compPilotLastname.Text = this.pilotLastName;
            this.compNavigatorFirstName.Text = this.navigatorFirstName;
            this.compNavigatorLastName.Text = this.navigatorLastName;
            this.compCountry.Text = this.country;
        }

        private void compAddButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void compButtonSubmit_Click(object sender, EventArgs e)
        {
            acCallsign = compAcCallsign.Text;
            country = compCountry.Text;
            pilotFirstName = compPilotFirstName.Text;
            pilotLastName = compPilotLastname.Text;
            navigatorFirstName = compNavigatorFirstName.Text;
            navigatorLastName = compNavigatorLastName.Text;
            SubmitButtonClick(this, new EventArgs());
        }
    }
}
