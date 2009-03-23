using System;
using System.Windows.Forms;
using GEPlugin;

namespace GELive
{    
    public partial class anrl_gui : Form
    {
        /// <summary>
        /// The plugin instance
        /// </summary>
        private IGEPlugin ge = null;
        
        public anrl_gui()
        {
            InitializeComponent();

            // Load the html directly from the library
            geWebBrowser1.LoadEmbededPlugin();

            // This event is raised by the initCallBack javascript function in the holding page
            geWebBrowser1.PluginReady += new GEWebBorwserEventHandeler(geWebBrowser1_PluginReady);

            // This event is raised by the loadKmlCallBack javascript function in the holding page
            geWebBrowser1.KmlLoaded += new GEWebBorwserEventHandeler(geWebBrowser1_KmlLoaded);

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
            /// Here we can cast the sender to the IGEPlugin interface
            /// Once this is done once can work with the plugin almost seemlessly
            ge = sender as IGEPlugin;

            if (ge != null)
            {
                // Tell various the controls the browser instance to work with
                geToolStrip1.SetBrowserInstance(geWebBrowser1);
                //kmlTreeView1.SetBrowserInstance(geWebBrowser1);
            }
        }

        /// <summary>
        /// Handles the Kml Loaded event
        /// </summary>
        /// <param name="sender">The Kml object</param>
        /// <param name="e">Empty arguments</param>
        void geWebBrowser1_KmlLoaded(object sender, GEEventArgs e)
        {
            // The kml object returned from javascript
            IKmlObject kmlObject = (IKmlObject)sender;

            // Add the kml to the plugin 
            ge.getFeatures().appendChild(kmlObject);

            // Add the kml into the tree view control
            //kmlTreeView1.ParsekmlObject(kmlObject);
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

        private void LoadKml_Click(object sender, EventArgs e)
        {
            geToolStrip1.LoadKml();
        }
    }
}
