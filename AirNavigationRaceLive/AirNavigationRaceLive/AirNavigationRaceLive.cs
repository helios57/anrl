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
            trackerToolStripMenuItem.Enabled = connected;
            connectToolStripMenuItem.Enabled = !connected;
            pilotsToolStripMenuItem.Enabled = connected;
            visualisationToolStripMenuItem.Enabled = connected;
            racesToolStripMenuItem.Enabled = connected;
            teamsToolStripMenuItem.Enabled = connected;
        }

        private void AirNavigationRaceLive_Load(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Credits == null)
            {
                Credits = new Components.Credits();
            }
            MainPanel.Controls.Add(Credits);
            StatusStripLabel.Text = "Ready";
            UpdateEnablement();
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
                MainPanel.Controls.Add(Connect);
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
            UpdateEnablement();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = null;
            Connect = null;
            Credits = null;
            Tracker = null;
            Pilot = null;
            Team = null;
            Race = null;
            Visualisation = null;
            StatusStripLabel.Text = "Disconnected from Server";
            UpdateEnablement();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(Credits);
            UpdateEnablement();
        }

        private void trackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Tracker == null)
            {
                Tracker = new Tracker(Client);
            }
            MainPanel.Controls.Add(Tracker);
            UpdateEnablement();
        }

        private void pilotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Pilot == null)
            {
                Pilot = new Pilot(Client);
            }
            MainPanel.Controls.Add(Pilot);
            UpdateEnablement();
        }

        private void teamsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Team == null)
            {
                Team = new Team(Client);
            }
            MainPanel.Controls.Add(Team);
            UpdateEnablement();
        }

        private void racesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Race == null)
            {
                Race = new Race(Client);
            }
            MainPanel.Controls.Add(Race);
            UpdateEnablement();
        }

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainPanel.Controls.Clear();
            if (Visualisation == null)
            {
                Visualisation = new Visualisation(Client);
            }
            MainPanel.Controls.Add(Visualisation);
            UpdateEnablement();

        }
    }
}
