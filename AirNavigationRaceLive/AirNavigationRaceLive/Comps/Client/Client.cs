using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using NetworkObjects;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace AirNavigationRaceLive.Comps.Client
{
    public class Client
    {
        private ClientCache cache;
        private ClientCacheGPSDaten cacheGPSData;
        private ClientNetwork net;

        public Client(ClientNetwork net)
        {
            this.net = net;
            cache = new ClientCache(this);
            cacheGPSData = new ClientCacheGPSDaten(this);
        }
        public bool isAuthenticated()
        {
            return net.isAuthenticated();
        }

        internal string getServerCompetitionSetIdentifier()
        {
            return net.getServerCompetitionSetIdentifier();
        }

        public Root process(Root r)
        {
            return net.process(r);
        }

        public bool IsInitialLoadComplete()
        {
            return cache.initialLoadComplete();
        }
        
        public Picture getPicture(int ID)
        {
            return cache.cachePicture.get(ID);
        }
        public int savePicture(Picture picture)
        {
            return cache.cachePicture.add(picture);
        }
        public List<NetworkObjects.Map> getMaps()
        {
            return cache.cacheMap.getAll();
        }
        public NetworkObjects.Map getMap(int ID)
        {
            return cache.cacheMap.get(ID);
        }
        public List<NetworkObjects.Parcour> getParcours()
        {
            return cache.cacheParcour.getAll();
        }
        public void deleteMap(int ID)
        {
            cache.cacheMap.delete(ID);
        }
        public void deleteParcour(int ID)
        {
            cache.cacheParcour.delete(ID);
        }
        public int saveMap(NetworkObjects.Map m)
        {
            return cache.cacheMap.add(m);
        }
        public int saveParcour(Parcour p)
        {
            return cache.cacheParcour.add(p);
        }

        public List<NetworkObjects.Tracker> getTrackers()
        {
            return cache.cacheTracker.getAll();
        }

        public int saveTracker(NetworkObjects.Tracker t)
        {
            return cache.cacheTracker.add(t);
        }
        public void deletePilot(int ID)
        {
            cache.cachePilot.delete(ID);
        }
        public List<NetworkObjects.Pilot> getPilots()
        {
            return cache.cachePilot.getAll();
        }
        public int savePilot(NetworkObjects.Pilot p)
        {
            return cache.cachePilot.add(p);
        }

        internal List<NetworkObjects.Team> getTeams()
        {
            return cache.cacheTeam.getAll();
        }

        internal NetworkObjects.Pilot getPilot(int ID)
        {
            return cache.cachePilot.get(ID);
        }

        internal int saveTeam(NetworkObjects.Team team)
        {
            return cache.cacheTeam.add(team);
        }

        internal NetworkObjects.Team getTeam(int ID)
        {
            return cache.cacheTeam.get(ID);
        }

        internal int saveCompetition(NetworkObjects.Competition competition)
        {
            return cache.cacheCompetition.add(competition);
        }

        internal List<NetworkObjects.Competition> getCompetitions()
        {
            return cache.cacheCompetition.getAll();
        }

        internal void deleteCompetition(int ID)
        {
            cache.cacheCompetition.delete(ID);
        }

        internal void uploadGPSData(List<GPSData> list)
        {
            Root r = new Root();
            r.ObjectType = (int) NetworkObjects.EObjectType.GPSData;
            r.RequestType = (int)ERequestType.Upload;
            r.RequestParameters = new RequestParameters();
            r.RequestParameters.GPSDataList.AddRange(list);
            process(r);
        }

        internal void clearCache()
        {
            cache.clear();
        }
        internal ClientCacheGPSDaten getGPSDatenCache()
        {
            return cacheGPSData;
        }

        internal NetworkObjects.Parcour getParcour(int p)
        {
            return cache.cacheParcour.get(p);
        }

        internal void savePenalty(Penalty penalty)
        {
            cache.cachePenalty.add(penalty);
        }
        internal List<Penalty> getPenalties()
        {
            return cache.cachePenalty.getAll();
        }
        internal void deletePenalty(int ID)
        {
            cache.cachePenalty.delete(ID);
        }
    }
}
