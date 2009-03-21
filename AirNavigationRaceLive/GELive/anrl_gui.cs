using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GEPlugin;

namespace GELive
{
    public struct DragInfo
    {
        public IKmlPlacemark placemark;
        public bool dragged;
        public DragInfo(IKmlPlacemark pm, bool drag)
        {
            placemark = pm;
            dragged = drag;
        }
    }
    
    public partial class anrl_gui : Form
    {
        /// <summary>
        /// The plugin instance
        /// </summary>
        private IGEPlugin ge = null;

        private readonly string kmlSamples = "http://code.google.com/apis/kml/documentation/KML_Samples.kml";
        
        private DragInfo di;
        private IKmlPlacemark pm1;
        private IKmlPlacemark pm2;
        private IKmlPlacemark linestring;
        
        public anrl_gui()
        {
            InitializeComponent();

            // Load the html directly from the library.
            geWebBrowser1.LoadEmbededPlugin();

            // This event is raised by the initCallBack javascript function in the holding page
            geWebBrowser1.PluginReady += new GEWebBorwserEventHandeler(geWebBrowser1_PluginReady);

            // This event is raised by the loadKmlCallBack javascript function in the holding page
            geWebBrowser1.KmlLoaded += new GEWebBorwserEventHandeler(geWebBrowser1_KmlLoaded);

            // This event is raised if there is a javascript error (it can also be raised manually)
            geWebBrowser1.ScriptError += new GEWebBorwserEventHandeler(geWebBrowser1_ScriptError);

            // This event is raised if there is an active kml event
            geWebBrowser1.KmlEvent += new GEWebBorwserEventHandeler(geWebBrowser1_KmlEvent);
        }

        /// <summary>
        /// Handles the KML mouse events.
        /// </summary>
        /// <param name="mouseEvent">The mouse event.</param>
        /// <param name="action">The action.</param>
        void handleKmlMouseEvents(IKmlMouseEvent mouseEvent, string action)
        {
            string currentTarget = mouseEvent.getCurrentTarget().getType();

            if (action == "mousedown" && currentTarget == "GEWindow")
            {
                // pick-up
                if (mouseEvent.getTarget().getType() == "KmlPlacemark")
                {
                    IKmlPlacemark pm = (IKmlPlacemark)mouseEvent.getTarget();
                    if (pm.getId() == "dpm1" || pm.getId() == "dpm2") // The two ids
                    {
                        di = new DragInfo(pm, false);
                    }
                }
            }
            else if (action == "mousemove" && currentTarget == "GEGlobe")
            {
                // drag
                if (di.placemark != null)
                {
                    mouseEvent.preventDefault();
                    IKmlPoint point = (IKmlPoint)di.placemark.getGeometry();
                    point.setLatitude(mouseEvent.getLatitude());
                    point.setLongitude(mouseEvent.getLongitude());
                    di.placemark.setDescription("[" + mouseEvent.getLatitude() + "," + mouseEvent.getLongitude() + "]");
                    di.dragged = true;

                    if (linestring != null)
                    {
                        ge.getFeatures().removeChild(linestring);
                    }

                    linestring = GEHelpers.DrawLineString(
                        ge,
                        (IKmlPoint)pm1.getGeometry(),
                        (IKmlPoint)pm2.getGeometry());
                    ge.getFeatures().appendChild(linestring);
                }
            }
            else if (action == "mouseup" && currentTarget == "GEWindow")
            {
                // put-down
                if (di.placemark != null && di.dragged)
                {
                    // if the placemark was dragged, prevent balloons from popping up
                    mouseEvent.preventDefault();

                    // but show a balloon for the distance
                    double distance = Maths.DistanceVincenty((IKmlPoint)pm1.getGeometry(), (IKmlPoint)pm2.getGeometry());
                    var b = ge.createHtmlStringBalloon("");
                    b.setContentString(Math.Round((distance / 1000), 2).ToString() + " Km");
                    b.setFeature(linestring);
                    ge.setBalloon(b);
                }

                di.placemark = null;
            }
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
            ////MessageBox.Show(GEHelpers.GetTypeFromRcw(sender));
            ge = sender as IGEPlugin;

            if (ge != null)
            {
                // Tell various the controls the browser instance to work with
                //geToolStrip1.SetBrowserInstance(geWebBrowser1);
                //kmlTreeView1.SetBrowserInstance(geWebBrowser1);

                // Load some kml 
                //geWebBrowser1.FetchKml(kmlSamples);

                // Create some event listners using the AddEventListener wrapper
                geWebBrowser1.AddEventListener(ge.getWindow(), "mousedown");
                geWebBrowser1.AddEventListener(ge.getGlobe(), "mousemove");
                geWebBrowser1.AddEventListener(ge.getWindow(), "mouseup");

                // Create first dragable placemark
                //var p1 = ge.createPoint("");
                //p1.set(50, 50, 0, 0, 0, 0);
                //pm1 = ge.createPlacemark("dpm1");
                //pm1.setGeometry(p1);
                //pm1.setName("Dragable placemark 1");
                //ge.getFeatures().appendChild(pm1);

                // Create second dragable placemark
                //var p2 = ge.createPoint("");
                //p2.set(55, 55, 0, 0, 0, 0);
                //pm2 = ge.createPlacemark("dpm2");
                //pm2.setGeometry(p2);
                //pm2.setName("Dragable placemark 2");
                //ge.getFeatures().appendChild(pm2);

                // Add the placemark to the tree
                //kmlTreeView1.ParsekmlObject(new object[] { pm1, pm2 });
            }
        }

        /// <summary>
        /// Handles incomming KmlEvents from any added Event Listeners
        /// </summary>
        /// <param name="sender">The Kml event</param>
        /// <param name="e">message:eventId</param>
        void geWebBrowser1_KmlEvent(object sender, GEEventArgs e)
        {
            // if it is a mouse event
            if (null != sender as IKmlMouseEvent)
            {
                handleKmlMouseEvents((IKmlMouseEvent)sender, e.Message);
            }
            else
            {
                MessageBox.Show(GEHelpers.GetTypeFromRcw(sender).ToString());
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
            //string type = GEHelpers.GetType(sender);
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
    }
}
