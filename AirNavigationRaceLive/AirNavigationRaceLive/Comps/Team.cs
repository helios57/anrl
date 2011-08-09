using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Comps
{
    public partial class Team : UserControl
    {
        private Client.Client Client;
        private bool newTeam;

        public Team(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void Team_Load(object sender, EventArgs e)
        {
            UpdateListe();
            UpdateEnablement();
        }

        private void UpdateListe()
        {
            /*resetFields();
            List<ITeam> teams = null;// Client.getTeams();
            listViewTeam.Items.Clear();
            foreach (ITeam p in teams)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.Pilot.Name,(p.Navigator!=null)? p.Navigator.Name:"-" });
                lvi.Tag = p;
                listViewTeam.Items.Add(lvi);
            }

            List<IPilot> pilots = null;//Client.getPilots();
            listViewPilots.Items.Clear();
            foreach (IPilot p in pilots)
            {
                ListViewItem lvi = new ListViewItem(new string[] { p.ID.ToString(), p.Name, p.Surename });
                lvi.Tag = p;
                listViewPilots.Items.Add(lvi);
            }
            List<ITracker> trackers = null;// Client.getTrackers();
            listViewTracker.Items.Clear();
            foreach (ITracker t in trackers)
            {
                listViewTracker.Items.Add(new TrackerEntry(t));
            }
            List<IPicture> flags = null;// Client.getPictures(true);
            comboBoxCountry.Items.Clear();
            foreach (IPicture p in flags)
            {
                Flag f = new Flag(p);
                comboBoxCountry.Items.Add(f);
                if (f.ToString() == "Switzerland")
                {
                    comboBoxCountry.SelectedItem = f;
                }
            }*/

        }

        private void UpdateEnablement()
        {
            Boolean teamSelected = (listViewTeam.SelectedItems.Count == 1 || newTeam);
            Boolean pilotSelected = (listViewPilots.SelectedItems.Count == 1);
            btnSave.Enabled = teamSelected;
            btnClearNavigator.Enabled = teamSelected && textBoxNavigator.Tag != null;
            btnClearPilot.Enabled = teamSelected && textBoxPilot.Tag != null;
            btnAddNavigator.Enabled = teamSelected && pilotSelected && textBoxNavigator.Tag == null;
            btnAddPilot.Enabled = teamSelected && pilotSelected && textBoxPilot.Tag == null;
            btnClearTracker.Enabled = teamSelected && textTracker.Tag != null;
            btnAddTracker.Enabled = teamSelected && (listViewTracker.SelectedItems.Count == 1);
            btnSave.Enabled = teamSelected && textBoxPilot.Tag != null && comboBoxCountry.SelectedItem!=null;
            btnColorSelect.Enabled = teamSelected;
            comboBoxCountry.Enabled = teamSelected;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateListe();
            UpdateEnablement();
        }

        private void btnClearPilot_Click(object sender, EventArgs e)
        {
            textBoxPilot.Tag = null;
            textBoxPilot.Text = "";
            UpdateEnablement();
        }

        private void btnClearNavigator_Click(object sender, EventArgs e)
        {
            textBoxNavigator.Tag = null;
            textBoxNavigator.Text = "";
            UpdateEnablement();
        }

        private void btnClearTracker_Click(object sender, EventArgs e)
        {
            textTracker.Tag = null;
            textTracker.Text = "";
            UpdateEnablement();
        }

        private void btnAddPilot_Click(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                textBoxPilot.Tag = listViewPilots.SelectedItems[0].Tag;
                //textBoxPilot.Text = ((IPilot)listViewPilots.SelectedItems[0].Tag).Name;
            }
            UpdateEnablement();
        }

        private void btnAddNavigator_Click(object sender, EventArgs e)
        {
            if (listViewPilots.SelectedItems.Count == 1)
            {
                textBoxNavigator.Tag = listViewPilots.SelectedItems[0].Tag;
                //textBoxNavigator.Text = ((IPilot)listViewPilots.SelectedItems[0].Tag).Name;
            }
            UpdateEnablement();
        }

        private void btnAddTracker_Click(object sender, EventArgs e)
        {
            if (listViewTracker.SelectedItems.Count == 1)
            {
                textTracker.Tag = listViewTracker.SelectedItems[0].Tag;
               // textTracker.Text = ((ITracker)listViewTracker.SelectedItems[0].Tag).Name;
            }
            UpdateEnablement();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            resetFields();
            newTeam = true;
            textBoxID.Text = "-1";
            UpdateEnablement();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((textBoxID.Tag != null || newTeam) && comboBoxCountry.SelectedItem!=null)
            {
                /*IPicture flag;
                Flag f = comboBoxCountry.SelectedItem as Flag;
                flag = f.getPicture();
                TeamEntry te = new TeamEntry(long.Parse(textBoxID.Text),textBoxPilot.Tag as IPilot, textBoxNavigator.Tag as IPilot,textTracker.Tag as ITracker, btnColorSelect.BackColor.Name,flag);
                //Client.addTeam(te);
                resetFields();
                UpdateEnablement();*/
            }
            UpdateListe();
            UpdateEnablement();
        }
        private void resetFields()
        {
            newTeam = false;
            textBoxID.Tag = null;
            textBoxID.Text = "";
            textBoxPilot.Tag = null;
            textBoxPilot.Text = "";
            textBoxNavigator.Tag = null;
            textBoxNavigator.Text = ""; 
            textTracker.Tag = null;
            textTracker.Text = "";
            btnColorSelect.BackColor = Color.Gray;
        }

        private void listViewTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTeam.SelectedItems.Count == 1)
            {
                /*ITeam team = listViewTeam.SelectedItems[0].Tag as ITeam;
                textBoxID.Tag = team;
                textBoxID.Text = team.ID.ToString();
                textBoxPilot.Tag = team.Pilot;
                textBoxPilot.Text = team.Pilot.Name;
                textBoxNavigator.Tag = team.Navigator;
                textBoxNavigator.Text = (team.Navigator!=null)?team.Navigator.Name:"";
                textTracker.Tag = team.Tracker;
                textTracker.Text = team.Tracker.Name;
                Flag selected = null;
                String flagName = team.FlagPicture.Name.Trim();
                foreach (object o in comboBoxCountry.Items)
                {
                    Flag f = o as Flag;
                    if (f!= null && f.ToString() == flagName )
                    {
                        selected = f;
                    }
                }
                comboBoxCountry.SelectedItem = selected;
                btnColorSelect.BackColor = Color.FromName(team.Color.Trim());*/
            }
            else
            {
                resetFields();
            }
            UpdateEnablement();
        }

        private void listViewPilots_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }


        private void listViewTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }

        private void btnColorSelect_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.AnyColor = false;
            cd.SolidColorOnly = true;
            cd.ShowDialog();
            btnColorSelect.BackColor = cd.Color;
        }

        private void comboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnablement();
        }


    }/*
    class TeamEntry : MarshalByRefObject, ITeam
    {
        private IPilot _Pilot;
        private IPilot _Navigator;
        private IPicture _Picture;
        private ITracker _Tracker;
        private String _Color;
        private long _ID;

        internal TeamEntry(long iID, IPilot iPilot, IPilot iNavigator, ITracker iTracker, String iColor, IPicture flag)
        {
            _ID = iID;
            _Pilot = iPilot;
            _Navigator = iNavigator;
            _Tracker = iTracker;
            _Color = iColor;
            _Picture = flag;
        }

        #region ITeam Members

        public IPilot Pilot
        {
            get { return _Pilot; }
        }

        public IPilot Navigator
        {
            get {return _Navigator; }
        }

        public IPicture FlagPicture
        {
            get { return _Picture; }
        }
        
        public ITracker Tracker
        {
            get { return _Tracker; }
        }

        public String Color
        {
            get { return _Color; }
        }

        #endregion

        #region IID Members

        public long ID
        {
            get {return _ID; }
        }

        #endregion
    }
    partial class TrackerEntry : ListViewItem
    {
        private ITracker ITracker;

        public TrackerEntry(ITracker iTracker)
            : base(new String[] { iTracker.ID.ToString().Trim(), iTracker.Name.Trim(), iTracker.IMEI.Trim() })
        {
            ITracker = iTracker;
            Tag = iTracker;
        }

        public ITracker getITracker()
        {
            return ITracker;
        }
    }
    class TrackerImpl : MarshalByRefObject, ITracker
    {
        long _ID;
        string _Name;
        string _IMEI;

        public TrackerImpl(long iID, string iName, string iIMEI)
        {
            _ID = iID;
            _Name = iName;
            _IMEI = iIMEI;
        }
        public string Name
        {
            get { return _Name; }
        }

        public string IMEI
        {
            get { return _IMEI; }
        }
        public long ID
        {
            get { return _ID; }
        }

    }
    class Flag
    {
        IPicture _Picture;
        String name;
        public Flag(IPicture picture)
        {
            _Picture = picture;
            name = picture.Name.Trim();
        }
        public IPicture getPicture()
        {
            return _Picture;
        }
        public override String ToString()
        {
            return name;
        }
    }*/
}
