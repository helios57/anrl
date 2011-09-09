using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCacheDirtyEvent:EventArgs
    {
        private bool value;

        public ClientCacheDirtyEvent(bool value)
        {
            this.value = value;
        }
        public bool IsDirty()
        {
            return value;
        }
    }
}
