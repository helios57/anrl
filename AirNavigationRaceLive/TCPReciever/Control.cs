using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPReciever
{
    class Control:System.Windows.Forms.Form
    {
        public delegate void RecievedGPS(string message);
        Server server;
        public RecievedGPS MyDelegate;
        public bool running;

        public Control()
        {
            running = true;
            server = new Server();
            server.MessageReceived += new TCPReciever.Server.MessageReceivedHandler(Message_Received);
        }

        void Message_Received(string message)
        {
            MyDelegate = new RecievedGPS(ProcessRecievedGPSData);  
              // this.invoke (MyDelegate, new string[] { message });
            MyDelegate.Invoke(message);
        }

        public void ProcessRecievedGPSData(string GPSData)
        {
            String[] GPScoords = GPSData.Split(',');

           /* textBox1.Text += "\r\n";
            foreach (String ss in GPScoords)
            {
                textBox1.Text += ss + "  ";
            }*/
        }
    }
}
