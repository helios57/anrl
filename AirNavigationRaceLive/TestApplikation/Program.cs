using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AnrlDB;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using ProtoBuf;
using System.Threading;
using NetworkObjects.GPSInput;

namespace TestApplikation
{
    class Program
    {
        static void Main(string[] args)
        {
            AnrlService.AnrlService service = new AnrlService.AnrlService();
            service.start();
            Thread.Sleep(Int32.MaxValue);
            /*int PORT = 1337;
            TcpListener server;
            server = new TcpListener(IPAddress.Any, PORT);
            server.Start();
            server.BeginAcceptTcpClient(ClientConnected, server);
            Thread.Sleep(Int32.MaxValue);
            /*
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            db.DatabaseExists();
            db.CreateDatabase();*/

            /*
            string path = @"C:\Users\Helios6x\Downloads\flags_style1_medium";
            DirectoryInfo dir = new DirectoryInfo(path);
            AnrlDB.AnrlDataContext db = new AnrlDB.AnrlDataContext();
            foreach (FileInfo fi in dir.GetFiles().Where(p=>p.Extension==".png"))
            {
                Image i = Image.FromFile(fi.FullName);
                t_Picture pic = new t_Picture();
                pic.Name = fi.Name.Replace(fi.Extension,"").Trim();
                pic.isFlag = true;
                
                MemoryStream ms = new MemoryStream();
                i.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                pic.Data = ms.ToArray();
                db.t_Pictures.InsertOnSubmit(pic);
            }
            db.SubmitChanges();*/
        }
        /*static void ClientConnected(IAsyncResult result)
        {
            try
            {
                TcpListener server = (TcpListener)result.AsyncState;
                using (TcpClient client = server.EndAcceptTcpClient(result))
                {
                    server.BeginAcceptTcpClient(ClientConnected, server);
                    using (NetworkStream stream = client.GetStream())
                    {
                        RootMessage reqest = Serializer.DeserializeWithLengthPrefix<RootMessage>(stream, PrefixStyle.Fixed32BigEndian);
                        RootMessage response = new RootMessage();
                        response.response = new Response();
                        response.response.countAdded = 99;
                        Serializer.SerializeWithLengthPrefix(stream, response, PrefixStyle.Fixed32BigEndian);
                        stream.Close();
                        client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Console.Out.WriteLine("Unable to recieve Connection " + ex.InnerException.Message);
            }
        }*/
    }
}
