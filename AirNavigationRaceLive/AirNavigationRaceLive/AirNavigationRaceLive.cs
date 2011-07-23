using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AnrlInterfaces;
using AirNavigationRaceLive.Components;

namespace AirNavigationRaceLive
{
    public partial class AirNavigationRaceLive : Form
    {
        IAnrlClient Client;
        Connect Connect;
        Credits Credits;
        Tracker Tracker;
        Pilot Pilot;
        Team Team;
        Race Race;
        Map Map;
        Visualisation Visualisation;


        public AirNavigationRaceLive()
        {
            Client = null;
            InitializeComponent();
        }

        public void UpdateEnablement()
        {
            Boolean connected = Client != null;
            disconnectToolStripMenuItem.Enabled = connected;
            mapToolStripMenuItem.Enabled = connected;
            parcourToolStripMenuItem.Enabled = connected;
            trackerToolStripMenuItem.Enabled = connected;
            connectToolStripMenuItem.Enabled = !connected;
            pilotsToolStripMenuItem.Enabled = connected;
            teamsToolStripMenuItem.Enabled = connected;
            groupsToolStripMenuItem.Enabled = connected;
            competitionToolStripMenuItem.Enabled = connected;
            rulesToolStripMenuItem.Enabled = connected;
            resultsToolStripMenuItem.Enabled = connected;
            toplistToolStripMenuItem.Enabled = connected;
            toplistFlightToolStripMenuItem.Enabled = connected;
            toplistLandingToolStripMenuItem.Enabled = connected;
            individualToplistToolStripMenuItem.Enabled = connected;
            addLandingResultsToolStripMenuItem.Enabled = connected;
            adjustResultsToolStripMenuItem.Enabled = connected;
            visualisationToolStripMenuItem.Enabled = connected;
        }

        private void AirNavigationRaceLive_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Credits == null)
            {
                Credits = new Components.Credits();
            }
            enableControl(Credits);
            StatusStripLabel.Text = "Ready";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Client == null)
            {
                MainPanel.Controls.Clear();
                if (Connect == null)
                {
                    Connect = new Components.Connect();
                    Connect.Connected += new EventHandler(Connect_Connected);
                }
                enableControl(Connect);
                StatusStripLabel.Text = "Ready to Connect to Server";
            }
            else
            {
                StatusStripLabel.Text = "Already connected to Server";
            }
            UpdateEnablement();
        }

        private void Connect_Connected(object sender, EventArgs e)
        {
            AnrlInterfaces.IAnrlClient c = sender as IAnrlClient;
            if (c != null)
            {
                Client = c;
                StatusStripLabel.Text = "Connected to Server";
                MainPanel.Controls.Clear();
            }
            enableControl(Credits);
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = null;
            Connect = null;
            Tracker = null;
            Pilot = null;
            Team = null;
            Race = null;
            Visualisation = null;
            Map = null;
            StatusStripLabel.Text = "Disconnected from Server";
            UpdateEnablement();
            enableControl(Credits);
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableControl(Credits);
        }

        private void trackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Tracker == null)
            {
                Tracker = new Tracker(Client);
            }
            enableControl(Tracker);
        }

        private void pilotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Pilot == null)
            {
                Pilot = new Pilot(Client);
            }
            enableControl(Pilot);
        }

        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Team == null)
            {
                Team = new Team(Client);
            }
            enableControl(Team);
        }

        private void racesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Race == null)
            {
                Race = new Race(Client);
            }
            enableControl(Race);
        }

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visualisation == null)
            {
                Visualisation = new Visualisation(Client);
            }
            enableControl(Visualisation);
        }

        private void MainPanel_Resize(object sender, EventArgs e)
        {
            if (MainPanel.Controls.Count == 1)
            {
                resize();
            }
        }

        private void enableControl(Control c)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(c);
            UpdateEnablement();
            resize();
        }
        private void resize()
        {
            MainPanel.Controls[0].SetBounds(0, 0, MainPanel.Width, MainPanel.Height);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Visualisation == null)
            {
                Map = new Map(Client);
            }
            enableControl(Map);
        }
    }
}
