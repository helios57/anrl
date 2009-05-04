using System;
using System.Windows.Forms;
using GEPlugin;

namespace GELive
{
    /// <summary>
    /// The GEToolStrip provides a quick way to access and set the plugin options
    /// </summary>
    public partial class GEToolStrip : ToolStrip, IGEControls
    {
        #region Private fields

        /// <summary>
        /// Use the IGEPlugin COM interface. 
        /// Equivalent to QueryInterface for COM objects
        /// </summary>
        private IGEPlugin geplugin = null;

        /// <summary>
        /// An instance of the current document
        /// </summary>
        private HtmlDocument htmlDocument = null;

        /// <summary>
        /// An instance of the current browser
        /// </summary>
        private GEWebBrowser gewb = null;

        #endregion

        /// <summary>
        /// Initializes a new instance of the GEToolStrip class.
        /// </summary>
        public GEToolStrip()
            : base()
        {
            this.InitializeComponent();
        }

        #region Public methods

        /// <summary>
        /// Loads a kml file in the GEWebBrowser.
        /// </summary>
        public void InvokeLoadKml()
        {
            WSManager ws = new WSManager();     // this line of code has to be updated when the webservice works
            string kml = ws.GetKml();           // this line of code has to be updated when the webservice works
            Object[] objArray = new Object[1];
            objArray[0] = (Object)kml;
            htmlDocument.InvokeScript("loadKml", objArray);
        }
        
        /// <summary>
        /// Set the browser instance for the control to work with
        /// </summary>
        /// <param name="browser">The GEWebBrowser instance</param>
        public void SetBrowserInstance(GEWebBrowser browser)
        {
            this.gewb = browser;
            this.geplugin = browser.GetPlugin();
            this.htmlDocument = browser.Document;
            this.Enabled = true;
        }

        #endregion

    }
}
