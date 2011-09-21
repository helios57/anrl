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
    public partial class UploadGPS : UserControl
    {
        private Client.Client Client;

        public UploadGPS(Client.Client iClient)
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
            if (listViewTracker.SelectedItems.Count == 1)
            {
                TrackerEntry t = listViewTracker.SelectedItems[0] as TrackerEntry;
                textBoxID.Text = t.getTracker().ID.ToString();
                textBoxName.Text = t.getTracker().Name;
                textBoxIMEI.Text = t.getTracker().IMEI;
            }
            else
            {
                textBoxID.Text = "";
                textBoxName.Text ="";
                textBoxIMEI.Text ="";
            }
            UpdateEnablement();
        }

        private void UpdateTrackerList()
        {
            List<NetworkObjects.Tracker> trackers = Client.getTrackers();
            listViewTracker.Items.Clear();
            foreach (NetworkObjects.Tracker t in trackers)
            {
                listViewTracker.Items.Add(new TrackerEntry(t));
            }
            textBoxID.Text = "";
            textBoxName.Text = "";
            textBoxIMEI.Text = "";
            UpdateEnablement();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            TrackerEntry t = listViewTracker.SelectedItems[0] as TrackerEntry;
            if (t != null)
            {
                NetworkObjects.Tracker tracker = t.getTracker();
                tracker.Name = textBoxName.Text;
                Client.saveTracker(tracker);
            }
            UpdateTrackerList();
        }

        public void UpdateEnablement()
        {
            buttonNewTracker.Enabled = listViewTracker.SelectedItems.Count == 1;
        }

        partial class TrackerEntry : ListViewItem
        {
            private NetworkObjects.Tracker Tracker;

            public TrackerEntry(NetworkObjects.Tracker iTracker)
                : base(new String[] { iTracker.ID.ToString().Trim(),iTracker.Name!=null?iTracker.Name.Trim():"", iTracker.IMEI.Trim() })
            {
                Tracker = iTracker;
            }

            public NetworkObjects.Tracker getTracker()
            {
                return Tracker;
            }
        }
    }
}
