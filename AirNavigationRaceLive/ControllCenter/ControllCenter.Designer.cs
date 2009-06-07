namespace ControllCenter
{
    partial class ControllCenter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPfad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartReciever = new System.Windows.Forms.Button();
            this.lblRecieverStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStartWebservice = new System.Windows.Forms.Button();
            this.lblStatusWebservice = new System.Windows.Forms.Label();
            this.btnStartANRLGUI = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPfad
            // 
            this.txtPfad.Location = new System.Drawing.Point(131, 4);
            this.txtPfad.Name = "txtPfad";
            this.txtPfad.Size = new System.Drawing.Size(496, 20);
            this.txtPfad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "1. Pfad zur DB wählen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "2. Reciever Starten";
            // 
            // btnStartReciever
            // 
            this.btnStartReciever.Location = new System.Drawing.Point(131, 28);
            this.btnStartReciever.Name = "btnStartReciever";
            this.btnStartReciever.Size = new System.Drawing.Size(168, 23);
            this.btnStartReciever.TabIndex = 4;
            this.btnStartReciever.Text = "Starte Reciever Port 5000";
            this.btnStartReciever.UseVisualStyleBackColor = true;
            this.btnStartReciever.Click += new System.EventHandler(this.btnStartReciever_Click);
            // 
            // lblRecieverStatus
            // 
            this.lblRecieverStatus.AutoSize = true;
            this.lblRecieverStatus.Location = new System.Drawing.Point(305, 33);
            this.lblRecieverStatus.Name = "lblRecieverStatus";
            this.lblRecieverStatus.Size = new System.Drawing.Size(47, 13);
            this.lblRecieverStatus.TabIndex = 5;
            this.lblRecieverStatus.Text = "Stopped";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "3. Webservice Starten";
            // 
            // btnStartWebservice
            // 
            this.btnStartWebservice.Location = new System.Drawing.Point(131, 58);
            this.btnStartWebservice.Name = "btnStartWebservice";
            this.btnStartWebservice.Size = new System.Drawing.Size(168, 23);
            this.btnStartWebservice.TabIndex = 7;
            this.btnStartWebservice.Text = "Starte Webservice Port 5555";
            this.btnStartWebservice.UseVisualStyleBackColor = true;
            this.btnStartWebservice.Click += new System.EventHandler(this.btnStartWebservice_Click);
            // 
            // lblStatusWebservice
            // 
            this.lblStatusWebservice.AutoSize = true;
            this.lblStatusWebservice.Location = new System.Drawing.Point(305, 63);
            this.lblStatusWebservice.Name = "lblStatusWebservice";
            this.lblStatusWebservice.Size = new System.Drawing.Size(47, 13);
            this.lblStatusWebservice.TabIndex = 8;
            this.lblStatusWebservice.Text = "Stopped";
            // 
            // btnStartANRLGUI
            // 
            this.btnStartANRLGUI.Location = new System.Drawing.Point(131, 87);
            this.btnStartANRLGUI.Name = "btnStartANRLGUI";
            this.btnStartANRLGUI.Size = new System.Drawing.Size(168, 23);
            this.btnStartANRLGUI.TabIndex = 10;
            this.btnStartANRLGUI.Text = "Starte ANRL GUI";
            this.btnStartANRLGUI.UseVisualStyleBackColor = true;
            this.btnStartANRLGUI.Click += new System.EventHandler(this.btnStartANRLGUI_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "4. Visualisierung Starten";
            // 
            // ControllCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 299);
            this.Controls.Add(this.btnStartANRLGUI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatusWebservice);
            this.Controls.Add(this.btnStartWebservice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblRecieverStatus);
            this.Controls.Add(this.btnStartReciever);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPfad);
            this.Name = "ControllCenter";
            this.Text = "ANRL - Air Navigation Race Live Controll Center";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPfad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartReciever;
        private System.Windows.Forms.Label lblRecieverStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStartWebservice;
        private System.Windows.Forms.Label lblStatusWebservice;
        private System.Windows.Forms.Button btnStartANRLGUI;
        private System.Windows.Forms.Label label4;
    }
}

