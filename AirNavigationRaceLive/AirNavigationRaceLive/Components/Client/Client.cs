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

namespace AirNavigationRaceLive.Components.Client
{
    public class Client
    {
        private const int PORT = 1337;
        private String Token;
        private string IpAdress;
        private TcpClient client;
        private NetworkStream stream;
        private Dictionary<int, Picture> pictureCache = new Dictionary<int, Picture>();

        public Client(string IpAdress)
        {
            this.IpAdress = IpAdress;
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

        private Root process(Root request)
        {
            try
            {
                if (client == null || !client.Connected)
                {
                    client = new TcpClient();
                    client.Connect(new IPEndPoint(IPAddress.Parse(IpAdress), PORT));
                    stream = client.GetStream();
                }
                Serializer.SerializeWithLengthPrefix(stream, request, PrefixStyle.Base128);
                Root rootAnswer = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                if (rootAnswer.ResponseParameters != null && rootAnswer.ResponseParameters.Exception != null)
                {
                    MessageBox.Show("Exception on Server: " + rootAnswer.ResponseParameters.Exception);
                }
                //optimize without this ?
                stream.Close();
                client.Close();
                client = null;
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
            Picture p = pictureCache[ID];
            if (p == null)
            {
                Root r = new Root();
                r.RequestParameters = new RequestParameters();
                r.RequestType = (int)RequestType.GetPicture;
                r.RequestParameters.ID = ID;
                p= process(r).ResponseParameters.Picture;
                if (p != null)
                {
                    pictureCache.Add(p.ID, p);
                }
            }
            return p;
        }
        public int savePicture(Picture picture)
        {
            Root pic = new Root();
            pic.RequestParameters = new RequestParameters();
            pic.RequestParameters.Picture = picture;
            pic.RequestType = (int)RequestType.SavePicture;
            Root picId = process(pic);
            return picId.ResponseParameters.ID;
        }
        public List<NetworkObjects.Map> getMaps()
        {
            Root r = new Root();
            r.RequestType = (int)RequestType.GetMaps;
            List<NetworkObjects.Map> maps = process(r).ResponseParameters.MapList.Maps;
            return maps;
        }
        public void deleteMap(int ID)
        {
            Root r = new Root();
            r.RequestType = (int)RequestType.DeleteMap;
            r.RequestParameters = new RequestParameters();
            r.RequestParameters.ID = ID;
            process(r);
        }
        public int saveMap(NetworkObjects.Map m)
        {
            Root map = new Root();
            map.RequestType = (int)RequestType.SaveMap;
            map.RequestParameters = new RequestParameters();
            map.RequestParameters.Map = m;
            Root mapId = process(map);
            return mapId.ResponseParameters.ID;
        }
    }
}
