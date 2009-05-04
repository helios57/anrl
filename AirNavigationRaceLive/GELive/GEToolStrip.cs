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
        public void InvokeLoadKml(String kml)
        {
            Object[] args = new Object[1];
            args[0] = (Object)kml;
            htmlDocument.InvokeScript("loadKml", args);
         
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

        #region Private methods

        /// <summary>
        /// Invokes the javascript function 'doGeocode'
        /// Automatically flys to the location if one is found
        /// </summary>
        /// <param name="input">the location to geocode</param>
        /// <returns>the point object (if any)</returns>
        private IKmlPoint InvokeDoGeocode(string input)
        {
            if (this.htmlDocument == null)
            {
                return null;
            }

            return (IKmlPoint)this.htmlDocument.InvokeScript("jsDoGeocode", new object[] { input });
        }

        /// <summary>
        /// Invokes the javascitp function 'LoadKml'
        /// </summary>
        /// <param name="url">The url of the file to load</param>
        /// <returns>The resulting kml object (if any)</returns>
        //private IKmlObject InvokeLoadKml(string url)
        //{
        //    if (this.htmlDocument == null)
        //    {
        //        return null;
        //    }

        //    return (IKmlObject)this.htmlDocument.InvokeScript("jsFetchKml", new object[] { url });
        //}

        #endregion

    }
}
