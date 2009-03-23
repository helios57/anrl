using System;
using System.ComponentModel;
using System.Drawing;
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

        public void LoadKml()
        {
            string input = "http://www.webcams.travel/webcams.kml";
            if (input.Length > 1)
            {
                if (input.StartsWith("http", true, System.Globalization.CultureInfo.CurrentCulture))
                {
                    try
                    {
                        new Uri(input);
                    }
                    catch (UriFormatException)
                    {
                        return;
                    }

                    this.InvokeLoadKml(input);
                }
                else
                {
                    this.InvokeDoGeocode(input);
                }
            }
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
        private IKmlObject InvokeLoadKml(string url)
        {
            if (this.htmlDocument == null)
            {
                return null;
            }

            return (IKmlObject)this.htmlDocument.InvokeScript("jsFetchKml", new object[] { url });
        }

        #endregion

    }
}
