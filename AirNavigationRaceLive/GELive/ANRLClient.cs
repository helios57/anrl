using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GEPlugin;

namespace GELive
{
    class ANRLClient
    {
        #region Private fields
        /// <summary>
        /// Use the IGEPlugin COM interface. 
        /// Equivalent to QueryInterface for COM objects
        /// </summary>
        private IGEPlugin geplugin;

        /// <summary>
        /// An instance of the current browser
        /// </summary>
        private GEWebBrowser gewb;

        /// <summary>
        /// WebServiceClient manager, generates KML-FIles
        /// </summary>
        public WSManager ws;
        #endregion
        public ANRLClient(GEWebBrowser gewb)
        {
            this.gewb = gewb;
            this.geplugin = gewb.GetPlugin();
        }

    }
}
