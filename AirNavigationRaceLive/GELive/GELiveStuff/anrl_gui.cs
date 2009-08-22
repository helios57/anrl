﻿using System;
using System.Windows.Forms;
using GEPlugin;
using GELive.ANRLDataService;
using System.Collections.Generic;

namespace GELive
{
    /// <summary>
    /// The Client Gui
    /// </summary>
    public partial class anrl_gui : Form
    {

        /// <summary>
        /// The plugin instance
        /// </summary>
        private IGEPlugin ge = null;
        public RankingForm rankingForm = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="anrl_gui"/> class.
        /// Loads the html directly from the library.
        /// </summary>
        public anrl_gui()
        {
            InitializeComponent();

            // Load the html directly from the library
            geWebBrowser1.LoadEmbededPlugin();

            // This event is raised by the initCallBack javascript function in the holding page
            geWebBrowser1.PluginReady += new GEWebBorwserEventHandeler(geWebBrowser1_PluginReady);

            // This event is raised if there is a javascript error (it can also be raised manually)
            geWebBrowser1.ScriptError += new GEWebBorwserEventHandeler(geWebBrowser1_ScriptError);

        
        }

        /// <summary>
        /// Handles the plugin ready event
        /// </summary>
        /// <param name="sender">The plugin object</param>
        /// <param name="e">The API version</param>
        void geWebBrowser1_PluginReady(object sender, GEEventArgs e)
        {
            // Here we can cast the sender to the IGEPlugin interface
            // Once this is done once can work with the plugin almost seemlessly
            ge = sender as IGEPlugin;
        }

        /// <summary>
        /// Handles the script error event
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The error message</param>
        void geWebBrowser1_ScriptError(object sender, GEEventArgs e)
        {
            MessageBox.Show(
                sender.ToString()
                + Environment.NewLine
                + e.Message,
                "Error " + e.Data);
        }

        /// <summary>
        /// Invokes geToolStrip1.InvokeLoadKml(); to load the kml.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoadKml_Click(object sender, EventArgs e)
        {
            if (ge != null)
            {
                WSManager ws = new WSManager(geWebBrowser1,this);
                Delay_Select d = new Delay_Select(ws);
                d.Show();
            }
        }

        /// <summary>
        /// Opens a new form to show the ranking.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ShowRanking_Click(object sender, EventArgs e)
        {

            ANRLDataService.ANRLDataServiceClient a = new GELive.ANRLDataService.ANRLDataServiceClient(
                "WSHttpBinding_IANRLDataService", "http://127.0.0.1:5555/");
            List<DateTime> d = a.GetTimestamps();

            foreach (DateTime bla in d)
            {
                System.Console.Out.WriteLine(bla.ToString());
            }

          //  rankingForm = new RankingForm();
          //  rankingForm.Show();
        }
    }
}