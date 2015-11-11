using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps
{
    public partial class Competition : UserControl
    {
        public event EventHandler Connected;

        private Client.Client c;

        private volatile bool active = false;

        public Competition(Client.Client client)
        {
            InitializeComponent();
            c = client;
            reloadCompetitions();
            UpdateEnablement();
        }
        private void UpdateEnablement()
        {
            bool loggedIn = !active;
            btnRefresh.Enabled = loggedIn;
            fldCompetition.Enabled = loggedIn;
            fldOwner.Enabled = loggedIn;
            btnUse.Enabled = loggedIn && fldCompetition.SelectedItem != null;
            fldCompetitionName.Enabled = loggedIn;
            btnCreate.Enabled = loggedIn && fldCompetitionName.Text.Length > 3;
            btnDel.Enabled = btnUse.Enabled;
        }

        private void reloadCompetitions()
        {
            List<t_CompetitionSet> list = c.GetCompetitionSets();
            fldCompetition.Items.Clear();
            fldCompetition.SelectedItem = null;
            foreach (t_CompetitionSet cs in list)
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
                        //c.SetClearCache(checkBoxClearCache.Checked);
                        UpdateEnablement();
                        Status.SetStatus("Connected to Server, downloading data");
                        Client.Client chachedClient = Client.Client.getClient();

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
                t_CompetitionSet newComp = c.CreateCompetitionSet(fldCompetitionName.Text);
                reloadCompetitions();
                c.UseCompetition(newComp);
                //c.SetClearCache(checkBoxClearCache.Checked);
                UpdateEnablement();
                Status.SetStatus("Connected to Server, downloading data");
                Client.Client chachedClient = Client.Client.getClient();
                Status.SetStatus("Connected to Server, download finished");
                Connected.Invoke(chachedClient, e);

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

        private void btnDel_Click(object sender, EventArgs e)
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
                        fldCompetition.SelectedItem = null;
                        fldCompetition.Text = "";
                        UpdateEnablement();
                        Status.SetStatus("Connected to Server, deleting Competition");
                        c.deleteCompetitionSet(csc.cs);
                        reloadCompetitions();
                        Status.SetStatus("");
                    }
                }
            }
            finally
            {
                active = false;
                UpdateEnablement();
            }
        }
    }
    class CompetitionSetCombo
    {
        internal t_CompetitionSet cs;
        public CompetitionSetCombo(t_CompetitionSet cs)
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
