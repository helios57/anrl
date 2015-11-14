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
    public partial class CompetitionControl : UserControl
    {
        public event EventHandler Connected;

        private Client.DataAccess c;

        private volatile bool active = false;

        public CompetitionControl(Client.DataAccess client)
        {
            InitializeComponent();
            c = client;
            reloadCompetitions();
            UpdateEnablement();
        }
        private void UpdateEnablement()
        {
            bool loggedIn = !active;
            fldCompetition.Enabled = loggedIn;
            btnUse.Enabled = loggedIn && fldCompetition.SelectedItem != null;
            fldCompetitionName.Enabled = loggedIn;
            btnCreate.Enabled = loggedIn && fldCompetitionName.Text.Length > 3;
            btnDel.Enabled = btnUse.Enabled;
        }

        private void reloadCompetitions()
        {
            List<Competition> list = c.DBContext.CompetitionSet.ToList();
            fldCompetition.Items.Clear();
            fldCompetition.SelectedItem = null;
            foreach (Competition cs in list)
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
                        c.SelectedCompetition= csc.cs;
                        UpdateEnablement();
                        Status.SetStatus("Connected to Server, download finished");
                        Connected.Invoke(c, e);
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
                Competition newComp = new Competition();
                newComp.Name = fldCompetitionName.Text;
                c.DBContext.CompetitionSet.Add(newComp);
                c.DBContext.SaveChanges();
                reloadCompetitions();
                c.SelectedCompetition= newComp;
                UpdateEnablement();
                Status.SetStatus("Connected to Server, download finished");
                Connected.Invoke(c, e);

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
                        c.DBContext.CompetitionSet.Remove(csc.cs);
                        c.DBContext.SaveChanges();
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
        internal Competition cs;
        public CompetitionSetCombo(Competition cs)
        {
            this.cs = cs;
        }
        public override string ToString()
        {
            return cs.Name;
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
