using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace TCPServerTutorial
{
    public partial class Form1 : Form
    {
        public delegate void AddText(string message);
        Server server;
        public AddText MyDelegate;
        public Form1()
        {
            InitializeComponent();
            server = new Server();
            server.MessageReceived += new TCPServerTutorial.Server.MessageReceivedHandler(Message_Received);
        }
        void Message_Received(string message)
        {
            MyDelegate = new AddText(AddTextDelegate);
            this.Invoke(MyDelegate, new string[]{message});
            //MyDelegate = new AddText(AddTextDelegate);
            //MyDelegate.Method.
            //this.Invoke(MyDelegate);
        }

        public void AddTextDelegate(string s)
        {
            textBox1.Text += s;
        }

        public void Send()
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("Hello Server!");

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.Stop();
            Close();
        }
    }
}

