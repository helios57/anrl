using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCacheEntry<T>
    {
        public EventHandler<ClientCacheDirtyEvent> DirtyChanged;
        private T entry;
        private bool _Dirty = false;
        public ClientCacheEntry(T entry)
        {
            this.entry = entry;
            Dirty = false;
        }
        public T getEntry()
        {
            return entry;
        }
        public bool Dirty
        {
            get
            {
                return _Dirty;
            }
            set
            {
                if (DirtyChanged != null && value != _Dirty)
                {
                    DirtyChanged.Invoke(this, new ClientCacheDirtyEvent(value));
                }
                _Dirty = value;
            }
        }
    }
}
