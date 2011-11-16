using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetworkObjects;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using ProtoBuf;
using System.Windows.Forms;
using AirNavigationRaceLive.Comps.Helper;

namespace AirNavigationRaceLive.Comps.Client
{
    public class ClientNetwork
    {
        private String Token;
        private string IpAdress;
        private const int PORT = 1337;
        private CompetitionSet CompetitionSet = null;
        private bool ClearCache = false;

        public ClientNetwork(string ip)
        {
            this.IpAdress = ip;
        }

        internal string getServerCompetitionSetIdentifier()
        {
            return IpAdress + "_" + CompetitionSet.ID;
        }

        internal bool isLoggedIn()
        {
            return Token != null;
        }

        public bool isAuthenticated()
        {
            return Token != null && CompetitionSet != null;
        }

        public void Authenticate(String username, String password)
        {
            Root r = new Root();
            r.ObjectType = (int)EObjectType.Login;
            r.RequestType = (int)ERequestType.Login;
            r.AuthInfo = new AuthenticationInfo();
            r.AuthInfo.Username = username;
            r.AuthInfo.Password = password;
            Root response = process(r);
            if (response.AuthInfo != null  && response.ResponseParameters.Exception == "")
            {
                Token = response.AuthInfo.Token;
                Status.SetStatus("Logged in on server, please choose a Competition to continue");
            }
            else
            {
                Status.SetStatus("Login not successfull!");
            }
           
        }

        public void Register(String username, String password)
        {
            Root r = new Root();
            r.ObjectType = (int)EObjectType.Login;
            r.RequestType = (int)ERequestType.Register;
            r.AuthInfo = new AuthenticationInfo();
            r.AuthInfo.Username = username;
            r.AuthInfo.Password = password;
            if (process(r).ResponseParameters.Exception == null)
            {
               Status.SetStatus("Successfull registered on Server, you may log in now with your choosen username and password");
            }
        }

        public List<NetworkObjects.CompetitionSet> GetCompetitions()
        {
            Root r = new Root();
            r.ObjectType = (int)EObjectType.CompetitionSet;
            r.RequestType = (int)ERequestType.GetAll;
            return process(r).ResponseParameters.CompetitionSetList;
        }

        public void CreateCompetition(String name, int publicRole)
        {
            Root r = new Root();
            r.ObjectType = (int)EObjectType.CompetitionSet;
            r.RequestType = (int)ERequestType.Save;
            r.RequestParameters = new RequestParameters();
            r.RequestParameters.CompetitionSet = new CompetitionSet();
            r.RequestParameters.CompetitionSet.Name = name;
            r.RequestParameters.CompetitionSet.PublicRole = publicRole;
            process(r);
        }

        public void UseCompetition(CompetitionSet set)
        {
            CompetitionSet = set;
            Status.SetStatus("Competition selected, Ready to go!");
        }

        internal Root process(Root request)
        {
            try
            {
                if (request.RequestType != (int)ERequestType.Login && isLoggedIn())
                {
                    request.AuthInfo = new AuthenticationInfo();
                    request.AuthInfo.Token = Token;
                    if (CompetitionSet != null)
                    {
                        request.AuthInfo.ID_CompetitionSet = CompetitionSet.ID;
                    }
                }
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
                if (rootAnswer.ResponseParameters != null && rootAnswer.ResponseParameters.Exception != null && rootAnswer.ResponseParameters.Exception.Length > 0)
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


        internal void SetClearCache(bool p)
        {
            ClearCache = p;
        }

        public bool getClearCache()
        {
            return ClearCache;
        }
    }
}
