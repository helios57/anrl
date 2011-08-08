using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;
using NetworkObjects;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace AirNavigationRaceLive.Components.Client
{
    class Client
    {
        private const int PORT = 1337;

        public Root process(Root request)
        {
            Root answer=null;
            using (TcpClient client = new TcpClient())
            {
                client.Connect(new IPEndPoint(IPAddress.Loopback, PORT));
                using (NetworkStream stream = client.GetStream())
                {
                    Serializer.SerializeWithLengthPrefix(stream, request, PrefixStyle.Base128);
                    Root rootAnswer = Serializer.DeserializeWithLengthPrefix<Root>(stream, PrefixStyle.Base128);
                    answer =rootAnswer;
                    stream.Close();
                }
                client.Close();
            }
            return answer;
        }
    }    
}
