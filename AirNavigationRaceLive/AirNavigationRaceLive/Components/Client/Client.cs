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

        public Root process(Root request)
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
            return rootAnswer;
        }
    }
}
