using System;
using System.Windows.Forms;
using GEPlugin;
using System.Collections.Generic;
using System.Threading;

namespace ANRLClient
{
    /// <summary>
    /// The Client Gui
    /// </summary>
    public partial class anrl_gui : Form
    {
        public event EventHandler PluginReady;
        /// <summary>
        /// Initializes a new instance of the <see cref="anrl_gui"/> class.
        /// Loads the html directly from the library.
        /// </summary>
        public anrl_gui()
        {
            InitializeComponent();


            // This event is raised by the initCallBack javascript function in the holding page
            geWebBrowser1.PluginReady += new GEWebBorwserEventHandeler(geWebBrowser1_PluginReady);

            // This event is raised if there is a javascript error (it can also be raised manually)
            geWebBrowser1.ScriptError += new GEWebBorwserEventHandeler(geWebBrowser1_ScriptError);

            InformationPool.gweb = geWebBrowser1;

            geWebBrowser1.Show();
            this.Refresh();
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Start();
        }

        void t_Tick(object sender, EventArgs e)
        {
            // Load the html directly from the library
            geWebBrowser1.LoadEmbededPlugin();
            (sender as System.Windows.Forms.Timer).Stop();
        }

        /// <summar>y
        /// Handles the plugin ready event
        /// </summary>
        /// <param name="sender">The plugin object</param>
        /// <param name="e">The API version</param>
        void geWebBrowser1_PluginReady(object sender, GEEventArgs e)
        {
            // Here we can cast the sender to the IGEPlugin interface
            // Once this is done once can work with the plugin almost seemlessly
            InformationPool.ge = sender as IGEPlugin;
            PluginReady.Invoke(sender, e);
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
    }
}
