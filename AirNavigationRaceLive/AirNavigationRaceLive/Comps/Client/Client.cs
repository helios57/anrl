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
        private const int PORT = 1337;
        private String Token;
        private string IpAdress;
        private ClientCache cache;

        public Client(string IpAdress)
        {
            this.IpAdress = IpAdress;
            cache = new ClientCache(this);
        }
        public bool isAuthenticated()
        {
            return Token != null;
        }
        public void Authenticate(String username, String password)
        {
            Root r = new Root();
            r.AuthInfo = new AuthenticationInfo();
            r.AuthInfo.Username = username;
            r.AuthInfo.Password = password;
            Token = process(r).AuthInfo.Token;
        }
        public bool IsInitialLoadComplete()
        {
            return cache.initialLoadComplete();
        }
        internal Root process(Root request)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(new IPEndPoint(IPAddress.Parse(IpAdress), PORT));
                int wait = 0;
                while (!client.Connected && wait < 100)
                {
                    wait++;
                    Thread.Sleep(10);
                }
                NetworkStream stream = client.GetStream();

                Serializer.SerializeWithLengthPrefix(stream, request, PrefixStyle.Base128);
                stream.Flush();
                Root rootAnswer = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                if (rootAnswer.ResponseParameters != null && rootAnswer.ResponseParameters.Exception != null && rootAnswer.ResponseParameters.Exception.Length >0)
                {
                    MessageBox.Show("Exception on Server: " + rootAnswer.ResponseParameters.Exception);
                }
                stream.Close();
                client.Close();
                return rootAnswer;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception on Server: " + ex.ToString());
                return null;
            }
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
        internal NetworkObjects.Group getGroup(int ID)
        {
            return cache.cacheGroup.get(ID);
        }
        internal int saveGroup(NetworkObjects.Group group)
        {
            return cache.cacheGroup.add(group);
        }

        internal List<NetworkObjects.Group> getGroups()
        {
            return cache.cacheGroup.getAll();
        }

        internal NetworkObjects.Team getTeam(int ID)
        {
            return cache.cacheTeam.get(ID);
        }

        internal void deleteGroup(int ID)
        {
            cache.cacheGroup.delete(ID);
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
    }
}
