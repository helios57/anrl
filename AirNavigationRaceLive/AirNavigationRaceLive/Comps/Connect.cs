using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Client;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class Connect : UserControl
    {
        public event EventHandler Connected;

        private Client.ClientNetwork c;

        public Connect()
        {
            InitializeComponent();
            c = new Client.ClientNetwork(fldServer.Text);
            fldPublicRole.Items.Add(new RoleCombo(Access.None));
            fldPublicRole.Items.Add(new RoleCombo(Access.Read));
            fldPublicRole.Items.Add(new RoleCombo(Access.Write));
            UpdateEnablement();
        }
        private void UpdateEnablement()
        {
            bool loggedIn = c.isLoggedIn();
            btnLogin.Enabled = !loggedIn;
            btnRegister.Enabled = !loggedIn;
            fldServer.Enabled = !loggedIn;
            fldUsername.Enabled = !loggedIn;
            fldPassword.Enabled = !loggedIn;
            fldCompetition.Enabled = loggedIn;
            fldOwner.Enabled = loggedIn;
            btnUse.Enabled = loggedIn && fldCompetition.SelectedItem != null;
            fldCompetitionName.Enabled = loggedIn;
            fldPublicRole.Enabled = loggedIn;
            btnCreate.Enabled = loggedIn && fldCompetitionName.Text.Length > 3;
        }

        private void Connect_Load(object sender, EventArgs e)
        {
            AirNavigationRaceLiveMain.SetStatusText("");
            UpdateEnablement();
        }

        private void fldServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            c = new Client.ClientNetwork(fldServer.Text);
            UpdateEnablement();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            c.Authenticate(fldUsername.Text, fldPassword.Text);
            if (c.isLoggedIn())
            {
                Status.SetStatus("Logged in, please choose a Competition");
                reloadCompetitions();
            }
            else
            {
                Status.SetStatus("Login was not successfull!");
            }
            UpdateEnablement();
        }

        private void reloadCompetitions()
        {
            List<CompetitionSet> list = c.GetCompetitions();
            fldCompetition.Items.Clear();
            fldCompetition.SelectedItem = null;
            foreach (CompetitionSet cs in list)
            {
                fldCompetition.Items.Add(new CompetitionSetCombo(cs));
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            c.Register(fldUsername.Text, fldPassword.Text);
            UpdateEnablement();
        }

        private void btnUse_Click(object sender, EventArgs e)
        {
            if (fldCompetition.SelectedItem != null)
            {
                CompetitionSetCombo csc = fldCompetition.SelectedItem as CompetitionSetCombo;
                if (csc != null)
                {
                    c.UseCompetition(csc.cs);
                    c.SetClearCache(checkBoxClearCache.Checked);
                    UpdateEnablement();
                    Status.SetStatus("Connected to Server, downloading data");
                    Client.Client chachedClient = new Client.Client(c);
                    
                    while (!chachedClient.IsInitialLoadComplete())
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                    Status.SetStatus("Connected to Server, download finished");
                    Connected.Invoke(chachedClient, e);
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            c.CreateCompetition(fldCompetitionName.Text, (int)(fldPublicRole.SelectedItem as RoleCombo).role);
            reloadCompetitions();
            UpdateEnablement();
        }

        private void fldCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void fldCompetitionName_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }
    }
    class CompetitionSetCombo
    {
        internal CompetitionSet cs;
        public CompetitionSetCombo(CompetitionSet cs)
        {
            this.cs = cs;
        }
        public override string ToString()
        {
            return cs.ID + " " + cs.Name;
        }
    }
    class RoleCombo
    {
        public NetworkObjects.Access role;
        public RoleCombo(NetworkObjects.Access role)
        {
            this.role = role;
        }
        public override string ToString()
        {
            return System.Enum.GetName(NetworkObjects.Access.Admin.GetType(), role);
        }
    }
}
