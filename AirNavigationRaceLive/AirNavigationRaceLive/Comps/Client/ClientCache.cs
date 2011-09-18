﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using ProtoBuf;
using NetworkObjects;

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
        public readonly ClientCacheList<NetworkObjects.Group> cacheGroup;
        public readonly ClientCacheList<NetworkObjects.Competition> cacheCompetition;
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
            cacheGroup = new ClientCacheList<NetworkObjects.Group>(new ClientCacheLoader<NetworkObjects.Group>(c, NetworkObjects.EObjectType.Group));
            cacheCompetition = new ClientCacheList<NetworkObjects.Competition>(new ClientCacheLoader<NetworkObjects.Competition>(c, NetworkObjects.EObjectType.Competition));
            t = new Timer(10);
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);
            t.Start();
        }

        public void Persist()
        {
            String file = Path.GetTempPath() + @"\ANRL"+c.getIpAdress()+".tmp";
            FileInfo fileInfo = new FileInfo(file);
            NetworkObjects.Root r = new NetworkObjects.Root();
            r.ResponseParameters = new NetworkObjects.ResponseParameters();
            r.ResponseParameters.MapList.AddRange(cacheMap.getAll());
            r.ResponseParameters.PictureList.AddRange(cachePicture.getAll());
            r.ResponseParameters.ParcourList.AddRange(cacheParcour.getAll());
            r.ResponseParameters.PilotList.AddRange(cachePilot.getAll());
            r.ResponseParameters.TrackerList.AddRange(cacheTracker.getAll());
            r.ResponseParameters.TeamList.AddRange(cacheTeam.getAll());
            r.ResponseParameters.GroupList.AddRange(cacheGroup.getAll());
            r.ResponseParameters.CompetitionList.AddRange(cacheCompetition.getAll());
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            Stream s = fileInfo.Create();
            Serializer.SerializeWithLengthPrefix(s, r, PrefixStyle.Base128);
            s.Close();
        }

        public bool LoadPersisted()
        {
            String file = Path.GetTempPath() + @"\ANRL" + c.getIpAdress() + ".tmp";
            FileInfo fileInfo = new FileInfo(file);
            if (fileInfo.Exists)
            {
                try
                {
                    Stream s = fileInfo.OpenRead();
                    Root root = Serializer.DeserializeWithLengthPrefix<Root>(s, PrefixStyle.Base128);
                    cacheMap.addAll(root.ResponseParameters.MapList);
                    cachePicture.addAll(root.ResponseParameters.PictureList);
                    cacheParcour.addAll(root.ResponseParameters.ParcourList);
                    cachePilot.addAll(root.ResponseParameters.PilotList);
                    cacheTracker.addAll(root.ResponseParameters.TrackerList);
                    cacheTeam.addAll(root.ResponseParameters.TeamList);
                    cacheGroup.addAll(root.ResponseParameters.GroupList);
                    cacheCompetition.addAll(root.ResponseParameters.CompetitionList);
                    s.Close();
                    return true;
                }
                catch { }
            }
            return false;
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
                if (first)
                {
                    partial = LoadPersisted();
                }
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
            cacheGroup.update(partial);
            cacheCompetition.update(partial);
            Persist();
            updating = false;
        }
        public bool initialLoadComplete()
        {
            return !first && !updating;
        }
    }
}