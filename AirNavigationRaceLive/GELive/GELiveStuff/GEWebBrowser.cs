namespace GELive
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using GEPlugin;
    using System.Threading;

    /// <summary>
    /// Main delegate event handler
    /// </summary>
    /// <param name="sender">The sending object</param>
    /// <param name="e">The event arguments</param>
    public delegate void GEWebBorwserEventHandeler(object sender, GEEventArgs e);

    /// <summary>
    /// This control simplifies working with the Google Earth Plugin
    /// </summary>
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public partial class GEWebBrowser : WebBrowser
    {
        #region Private fields

        /// <summary>
        /// External is A COM Visible class that holds all the public methods
        /// to be called from javascript. An instance of this is set
        /// to the base object's ObjectForScripting property in the constuctor.
        /// </summary>
        private External external = new External();

        /// <summary>
        /// Use the IGEPlugin COM interface. 
        /// Equivalent to QueryInterface for COM objects
        /// </summary>
        private IGEPlugin geplugin = null;

        #endregion

        /// <summary>
        /// Initializes a new instance of the GEWebBrowser class.
        /// </summary>
        public GEWebBrowser()
            : base()
        {
            // External - COM visible class
            this.external.KmlLoaded += new ExternalEventHandeler(this.External_KmlLoaded);
            this.external.PluginReady += new ExternalEventHandeler(this.External_PluginReady);
            this.external.ScriptError += new ExternalEventHandeler(this.External_ScriptError);

            // Setup the control
            this.AllowNavigation = false;
            this.IsWebBrowserContextMenuEnabled = false;
            this.ScrollBarsEnabled = false;
            this.WebBrowserShortcutsEnabled = false;
            this.ObjectForScripting = this.external;
            this.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.GEWebBrowser_DocumentCompleted);
        }

        #region Public events

        /// <summary>
        /// Raised when the plugin is ready
        /// </summary>
        public event GEWebBorwserEventHandeler PluginReady;

        /// <summary>
        /// Raised when a kml/kmz file has loaded
        /// </summary>
        public event GEWebBorwserEventHandeler KmlLoaded;

        /// <summary>
        /// Raised when there is a script error in the document 
        /// </summary>
        public event GEWebBorwserEventHandeler ScriptError;

        #endregion

        #region Public methods

        /// <summary>
        /// Get the plugin instance associated with the control
        /// </summary>
        /// <returns>The plugin instance</returns>
        public IGEPlugin GetPlugin()
        {
            return this.geplugin;
        }

        /// <summary>
        /// Load the embeded html document into the browser 
        /// </summary>
        public void LoadEmbededPlugin()
        {
            try
            {
                // Get the html string from the embebed reasource
                string html = GELive.Properties.Resources.Plugin;

                // Create a temp file and get the full path
                string path = Path.GetTempFileName();

                // Write the html to the temp file
                TextWriter tw = new StreamWriter(path);
                tw.Write(html);

                // Close the temp file
                tw.Close();

                // Navigate to the temp file
                this.Navigate(path);

                // NB: Windows deletes the temp file automatially when the Windows session quits.
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Protected method for raising the PluginReady event
        /// </summary>
        /// <param name="plugin">The plugin object</param>
        /// <param name="e">Event arguments</param>
        protected virtual void OnPluginReady(object plugin, GEEventArgs e)
        {
            if (this.PluginReady != null)
            {
                this.PluginReady(plugin, e);
            }
        }

        /// <summary>
        /// Protected method for raising the KmlLoaded event
        /// </summary>
        /// <param name="kmlObject">The kmlObject object</param>
        /// <param name="e">Event arguments</param>
        protected virtual void OnKmlLoaded(object kmlObject, GEEventArgs e)
        {
            if (this.KmlLoaded != null)
            {
                this.KmlLoaded(kmlObject, e);
            }
        }

        /// <summary>
        /// Protected method for raising the ScriptError event
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">Event arguments</param>
        protected virtual void OnScriptError(object sender, GEEventArgs e)
        {
            if (this.ScriptError != null)
            {
                this.ScriptError(sender, e);
            }
        }

        #endregion

        #region Event handlers

        /// <summary>
        /// Called when the document has a ScriptError
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">Event arguments</param>
        private void External_ScriptError(object sender, GEEventArgs e)
        {
            this.OnScriptError(sender, e);
        }

        /// <summary>
        /// Called when the Plugin is Ready 
        /// </summary>
        /// <param name="plugin">The plugin instance</param>
        /// <param name="e">Event arguments</param>
        private void External_PluginReady(object plugin, GEEventArgs e)
        {
            this.geplugin = (IGEPlugin)plugin;

            // A label for the data
            e.Message = "ApiVersion";

            // The data is just the version info
            e.Data = this.geplugin.getApiVersion();

            // Raise the ready event
            this.OnPluginReady(this.geplugin, e);
        }

        /// <summary>
        /// Called when a Kml/Kmz file has loaded
        /// </summary>
        /// <param name="kmlFeature">The kml feature</param>
        /// <param name="e">Event arguments</param>
        private void External_KmlLoaded(object kmlFeature, GEEventArgs e)
        {
            this.OnKmlLoaded(kmlFeature, e);
        }

        /// <summary>
        /// Called when the Html document has finished loading
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">Event arguments</param>
        private void GEWebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Set up the error handler for a loaded Document
            this.Document.Window.Error += new HtmlElementErrorEventHandler(this.Window_Error);
        }

        /// <summary>
        /// Called when there is a script error in the window
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">Event arguments</param>
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Handle the original error
            e.Handled = true;

            // Copy the error data
            GEEventArgs ea = new GEEventArgs();
            ea.Message = e.Description;
            ea.Data = e.LineNumber.ToString();

            // Bubble the error
            this.OnScriptError(this, ea);
        }

        #endregion
    }
}
