using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;

namespace AirNavigationRaceLive.Comps.Client
{
    class ClientCacheLoader<T>
    {
        Client c;
        EObjectType type;
        private int requestType;
        public ClientCacheLoader(Client c, EObjectType type)
        {
            this.c = c;
            this.type = type;
        }
        public List<T> LoadAll(int ID)
        {
            Root r = getRoot();
            r.RequestType = (int)ERequestType.GetAll;
            r.RequestParameters.ID = ID;
            Root response = c.process(r);
            if (response != null)
            {
                return parseList(response);
            }
            return null;
        }
        public List<T> LoadAll(List<int> IDS,List<int> deleted)
        {
            Root r = getRoot();
            r.RequestType = (int)ERequestType.GetAll;
            r.RequestParameters.ID = 0;
            foreach (int i in IDS)
            {
                r.RequestParameters.IDS.Add(i);
            }
            Root response = c.process(r);
            if (response != null)
            {
                deleted.AddRange(response.ResponseParameters.DeletedIDList);
                return parseList(response);
            }
            return null;
        }

        private Root getRoot()
        {
            Root r = new Root();
            r.RequestParameters = new RequestParameters();
            r.ObjectType = (int)type;
            return r;
        }
        public List<T> parseList(Root resp)
        {
            switch (type)
            {
                case EObjectType.Map: return resp.ResponseParameters.MapList as List<T>;
                case EObjectType.Parcour: return resp.ResponseParameters.ParcourList as List<T>;
                case EObjectType.Picture: return resp.ResponseParameters.PictureList as List<T>;
                case EObjectType.Pilot: return resp.ResponseParameters.PilotList as List<T>;
                case EObjectType.Tracker: return resp.ResponseParameters.TrackerList as List<T>;
                case EObjectType.Team: return resp.ResponseParameters.TeamList as List<T>;
            }
            return null;
        }
        public T Load(int ID)
        {
            Root r = getRoot();
            r.RequestType = (int)ERequestType.Get;
            r.RequestParameters.ID = ID;
            Root response = c.process(r);
            if (response != null)
            {
                List<T> result = parseList(response);
                return result.Count == 1 ? result.First() : default(T);
            }
            return default(T);
        }

        public void Delete(int ID)
        {
            Root r = getRoot();
            r.RequestType = (int)ERequestType.Delete;
            r.RequestParameters.ID = ID;
            c.process(r);
        }

        public int Add(T entry)
        {
            Root r = getRoot();
            r.RequestType = (int)ERequestType.Save;
            switch (type)
            {
                case EObjectType.Map: r.RequestParameters.Map = entry as NetworkObjects.Map; break;
                case EObjectType.Parcour: r.RequestParameters.Parcour = entry as NetworkObjects.Parcour; break;
                case EObjectType.Picture: r.RequestParameters.Picture = entry as NetworkObjects.Picture; break;
                case EObjectType.Pilot: r.RequestParameters.Pilot = entry as NetworkObjects.Pilot; break;
                case EObjectType.Tracker: r.RequestParameters.Tracker = entry as NetworkObjects.Tracker; break;
                case EObjectType.Team: r.RequestParameters.Team = entry as NetworkObjects.Team; break;
            }
            Root response = c.process(r);
            return response.ResponseParameters.ID;
        }

        internal bool IsUnmodifiable()
        {
            switch (type)
            {
                case EObjectType.Map: return true;
                case EObjectType.Parcour: return true;
                case EObjectType.Picture: return true;
                case EObjectType.Pilot: return false;
                case EObjectType.Tracker: return false;
                case EObjectType.Team: return false;
            }
            return false;
        }
    }
}
