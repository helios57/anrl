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
    public partial class Tracker : UserControl
    {
        private Client.Client Client;

        public Tracker(Client.Client iClient)
        {
            Client = iClient;
            InitializeComponent();
        }

        private void Tracker_Load(object sender, EventArgs e)
        {
            UpdateTrackerList();
        }


        private void btnTrackersRefresh_Click(object sender, EventArgs e)
        {
            UpdateTrackerList();
        }


        private void listViewTracker_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (listViewTracker.SelectedItems.Count == 1)
            {
                TrackerEntry t = listViewTracker.SelectedItems[0] as TrackerEntry;
                textBoxID.Text = t.getITracker().ID.ToString();
                textBoxName.Text = t.getITracker().Name;
                textBoxIMEI.Text = t.getITracker().IMEI;
            }
            else
            {
                textBoxID.Text = "";
                textBoxName.Text ="";
                textBoxIMEI.Text ="";
            }
            UpdateEnablement();*/
        }

        private void UpdateTrackerList()
        {
            /*List<ITracker> trackers = null;//Client.getTrackers();
            listViewTracker.Items.Clear();
            foreach(ITracker t in trackers)
            {
                listViewTracker.Items.Add(new TrackerEntry(t));
            }
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxIMEI.Text = "";
            UpdateEnablement();*/
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*TrackerEntry t = listViewTracker.SelectedItems[0] as TrackerEntry;
            if (t != null)
            {
                ITracker tracker = t.getITracker();
                //Client.addName(new TrackerImpl(tracker.ID,textBoxName.Text,tracker.IMEI));
            }
            UpdateTrackerList();
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxIMEI.Text = "";*/
        }

        public void UpdateEnablement()
        {
            buttonSave.Enabled = listViewTracker.SelectedItems.Count == 1;
        }

        partial class TrackerEntry : ListViewItem
        {
            /*private ITracker ITracker;

            public TrackerEntry(ITracker iTracker)
                : base(new String[] { iTracker.ID.ToString().Trim(), iTracker.Name.Trim(), iTracker.IMEI.Trim() })
            {
                ITracker = iTracker;
            }

            public ITracker getITracker()
            {
                return ITracker;
            }*/
        }
        class TrackerImpl : MarshalByRefObject/*, ITracker*/
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
                get {return _IMEI; }
            }
            public long ID
            {
                get { return _ID; }
            }

        }
    }
}
