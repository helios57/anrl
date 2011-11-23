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
    public partial class Competition : UserControl
    {
        public event EventHandler Connected;

        private Client.ClientNetwork c;

        private volatile bool active = false;

        public Competition(Client.ClientNetwork client)
        {
            InitializeComponent();
            c = client;
            fldPublicRole.Items.Add(new RoleCombo(Access.None));
            fldPublicRole.Items.Add(new RoleCombo(Access.Read));
            fldPublicRole.Items.Add(new RoleCombo(Access.Write));
            reloadCompetitions();
            UpdateEnablement();
        }
        private void UpdateEnablement()
        {
            bool loggedIn = c.isLoggedIn() && !active;
            btnRefresh.Enabled = loggedIn;
            fldCompetition.Enabled = loggedIn;
            fldOwner.Enabled = loggedIn;
            btnUse.Enabled = loggedIn && fldCompetition.SelectedItem != null;
            fldCompetitionName.Enabled = loggedIn;
            fldPublicRole.Enabled = loggedIn;
            btnCreate.Enabled = loggedIn && fldCompetitionName.Text.Length > 3;
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

        private void btnUse_Click(object sender, EventArgs e)
        {
            try
            {
                active = true;
                UpdateEnablement();
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
            finally
            {
                active = false;
                UpdateEnablement();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                active = true;
                UpdateEnablement();
                if (fldPublicRole.SelectedItem == null)
                {
                    MessageBox.Show("Please select a Public Role");
                }
                else
                {
                    NetworkObjects.CompetitionSet newComp = c.CreateCompetition(fldCompetitionName.Text, (int)(fldPublicRole.SelectedItem as RoleCombo).role);
                    reloadCompetitions();
                    c.UseCompetition(newComp);
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
                UpdateEnablement();
            }
            finally
            {
                active = false;
                UpdateEnablement();
            }
        }

        private void fldCompetition_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void fldCompetitionName_TextChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reloadCompetitions();
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
