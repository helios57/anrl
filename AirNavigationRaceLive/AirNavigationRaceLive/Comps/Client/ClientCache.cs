using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCache
    {
        public readonly ClientCacheList<NetworkObjects.Map> cacheMap;
        public readonly ClientCacheList<NetworkObjects.Picture> cachePicture;
        public readonly ClientCacheList<NetworkObjects.Parcour> cacheParcour;
        public readonly ClientCacheList<NetworkObjects.Pilot> cachePilot;
        public readonly ClientCacheList<NetworkObjects.Tracker> cacheTracker;
        public readonly ClientCacheList<NetworkObjects.Team> cacheTeam;
        private bool first = true;
        private Timer t;
        private Client c;
        private volatile bool updating = false;
        public ClientCache(Client c)
        {
            this.c = c;
            cacheMap = new ClientCacheList<NetworkObjects.Map>(new ClientCacheLoader<NetworkObjects.Map>(c, NetworkObjects.EObjectType.Map));
            cachePicture = new ClientCacheList<NetworkObjects.Picture>(new ClientCacheLoader<NetworkObjects.Picture>(c, NetworkObjects.EObjectType.Picture));
            cacheParcour = new ClientCacheList<NetworkObjects.Parcour>(new ClientCacheLoader<NetworkObjects.Parcour>(c, NetworkObjects.EObjectType.Parcour));
            cachePilot = new ClientCacheList<NetworkObjects.Pilot>(new ClientCacheLoader<NetworkObjects.Pilot>(c, NetworkObjects.EObjectType.Pilot));
            cacheTracker = new ClientCacheList<NetworkObjects.Tracker>(new ClientCacheLoader<NetworkObjects.Tracker>(c, NetworkObjects.EObjectType.Tracker));
            cacheTeam = new ClientCacheList<NetworkObjects.Team>(new ClientCacheLoader<NetworkObjects.Team>(c, NetworkObjects.EObjectType.Team));
            t = new Timer(10);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
        }

        public void update()
        {
            t.Interval = 10;
        }

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (c.isAuthenticated() && !updating)
            {
                t.Interval = 10000;
                bool partial = !first;
                updateCaches(partial);
                first = false;
            }
        }

        private void updateCaches(bool partial)
        {
            updating = true;
            cacheTracker.update(partial);
            cacheMap.update(partial);
            cachePilot.update(partial);
            cachePicture.update(partial);
            cacheParcour.update(partial);
            cacheTeam.update(partial);
            updating = false;
        }
    }
}
