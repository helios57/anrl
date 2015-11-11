using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;

namespace AirNavigationRaceLive.Comps.Client
{
    public class Client
    {
        private Client()
        {

        }

        private static Client client = new Client();
        private anrlEntities entities = new anrlEntities();
        private t_CompetitionSet CompetitionSet = null;

        public static Client getClient()
        {
            return client;
        }
        public t_Picture gett_Picture(int ID)
        {
            return entities.t_Picture.First(p=>p.ID==ID);
        }

        public int savePicture(t_Picture t_Picture)
        {
            var iD = entities.t_Picture.Add(t_Picture).ID;
            entities.SaveChanges();
            return iD;
        }
        public List<t_Map> getMaps()
        {
            return entities.t_Map.ToList();
        }
        public t_Map getMap(int ID)
        {
            return entities.t_Map.First(p => p.ID == ID);
        }
        public List<t_Parcour> getParcours()
        {
            return entities.t_Parcour.ToList();
        }
        public void deleteMap(int ID)
        {
            entities.t_Map.Remove(entities.t_Map.First(p => p.ID == ID));
            entities.SaveChanges();
        }

        internal List<t_CompetitionSet> GetCompetitionSets()
        {
            return entities.t_CompetitionSet.ToList();
        }

        public void deleteParcour(int ID)
        {
            entities.t_Parcour.Remove(entities.t_Parcour.First(p => p.ID == ID));
            entities.SaveChanges();
        }
        public int saveMap(t_Map map)
        {
            var iD = entities.t_Map.Add(map).ID;
            entities.SaveChanges();
            return iD;
        }
        public int saveParcour(t_Parcour p)
        {
            var iD = entities.t_Parcour.Add(p).ID;
            entities.SaveChanges();
            return iD;
        }
        public List<t_Tracker> getTrackers()
        {
            return entities.t_Tracker.ToList();
        }

        public int saveTracker(t_Tracker t)
        {
            var iD = entities.t_Tracker.Add(t).ID;
            entities.SaveChanges();
            return iD;
        }
        public void deletePilot(int ID)
        {
            entities.t_Pilot.Remove(entities.t_Pilot.First(p => p.ID == ID));
            entities.SaveChanges();
        }
        public List<t_Pilot> getPilots()
        {
            return entities.t_Pilot.ToList();
        }
        public int savePilot(t_Pilot p)
        {
            var iD = entities.t_Pilot.Add(p).ID;
            entities.SaveChanges();
            return iD;
        }
        public t_CompetitionSet getSelectedCompetitionSet()
        {
            return CompetitionSet;
        }
        public void UseCompetition(t_CompetitionSet set)
        {
            CompetitionSet = set;
            Status.SetStatus("Competition selected, Ready to go!");
        }
        internal List<t_Team> getTeams()
        {
            return entities.t_Team.ToList();
        }

        internal t_CompetitionSet CreateCompetitionSet(string text)
        {
            t_CompetitionSet result = new t_CompetitionSet();
            result.Name = text;
            entities.t_CompetitionSet.Add(result);
            entities.SaveChanges();
            return result;
        }

        internal t_Pilot getPilot(int ID)
        {
            return entities.t_Pilot.First(p => p.ID == ID);
        }

        internal int saveTeam(t_Team team)
        {
            var iD = entities.t_Team.Add(team).ID;
            entities.SaveChanges();
            return iD;
        }

        internal t_Team getTeam(int ID)
        {
            return entities.t_Team.First(p => p.ID == ID);
        }

        internal int saveCompetition(t_Competition competition)
        {
            var iD = entities.t_Competition.Add(competition).ID;
            entities.SaveChanges();
            return iD;
        }

        internal List<t_Competition> getCompetitions()
        {
            return entities.t_Competition.ToList();
        }

        internal void deleteCompetition(int ID)
        {
            entities.t_Competition.Remove(entities.t_Competition.First(p => p.ID == ID));
            entities.SaveChanges();
        }

        internal t_Parcour getParcour(int ID)
        {
            return entities.t_Parcour.First(p => p.ID == ID);
        }

        internal int savePenalty(t_Penalty penalty)
        {
            var iD = entities.t_Penalty.Add(penalty).ID;
            entities.SaveChanges();
            return iD;
        }
        internal List<t_Penalty> getPenalties()
        {
            return entities.t_Penalty.ToList();
        }
        internal void deletePenalty(int ID)
        {
            entities.t_Penalty.Remove(entities.t_Penalty.First(p => p.ID == ID));
            entities.SaveChanges();
        }

        internal t_Tracker getTracker(int ID)
        {
            return entities.t_Tracker.First(p => p.ID == ID);
        }

        internal void deleteCompetitionSet(t_CompetitionSet cs)
        {
            entities.t_CompetitionSet.Remove(cs);
            entities.SaveChanges();
        }

        internal int uploadGPSData(List<t_GPSPoint> subList)
        {
            int trackerid = 0;
            foreach(t_GPSPoint p in subList)
            {
                t_Tracker tracker=  entities.t_Tracker.First(t => t.Name == p.identifier);
                if (tracker== null)
                {
                    tracker = new t_Tracker();
                    tracker.Name = p.identifier;
                    saveTracker(tracker);
                    p.t_Tracker = tracker;
                }
                entities.t_GPSPoint.Add(p);
                trackerid = tracker.ID;
            }
            entities.SaveChanges();
            return trackerid;
        }
    }
}
