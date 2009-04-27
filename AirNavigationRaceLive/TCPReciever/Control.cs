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
        private System.Windows.Forms.Button button1;
        public bool running;

        public Control()
        {
            running = true;
            server = new Server();
            server.MessageReceived += new TCPReciever.Server.MessageReceivedHandler(Message_Received);
            InitializeComponent();
            Show();
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

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(94, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Control
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.button1);
            this.Name = "Control";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
