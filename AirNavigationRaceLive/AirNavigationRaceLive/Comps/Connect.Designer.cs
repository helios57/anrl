namespace AirNavigationRaceLive.Comps
{
    partial class Connect
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAnrlServer = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.fldServer = new System.Windows.Forms.ComboBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.fldPassword = new System.Windows.Forms.TextBox();
            this.fldUsername = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAnrlServer
            // 
            this.lblAnrlServer.AutoSize = true;
            this.lblAnrlServer.Location = new System.Drawing.Point(105, 135);
            this.lblAnrlServer.Name = "lblAnrlServer";
            this.lblAnrlServer.Size = new System.Drawing.Size(70, 13);
            this.lblAnrlServer.TabIndex = 8;
            this.lblAnrlServer.Text = "ARNL Server";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(105, 188);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password";
            // 
            // fldServer
            // 
            this.fldServer.FormattingEnabled = true;
            this.fldServer.Items.AddRange(new object[] {
            "127.0.0.1",
            "83.169.11.154"});
            this.fldServer.Location = new System.Drawing.Point(181, 132);
            this.fldServer.Name = "fldServer";
            this.fldServer.Size = new System.Drawing.Size(210, 21);
            this.fldServer.TabIndex = 7;
            this.fldServer.Text = "127.0.0.1";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(105, 162);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(397, 130);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(57, 75);
            this.btnConnect.TabIndex = 9;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // fldPassword
            // 
            this.fldPassword.Location = new System.Drawing.Point(181, 185);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.PasswordChar = '*';
            this.fldPassword.Size = new System.Drawing.Size(210, 20);
            this.fldPassword.TabIndex = 11;
            this.fldPassword.Text = "anrl";
            this.fldPassword.UseSystemPasswordChar = true;
            // 
            // fldUsername
            // 
            this.fldUsername.Location = new System.Drawing.Point(181, 159);
            this.fldUsername.Name = "fldUsername";
            this.fldUsername.Size = new System.Drawing.Size(210, 20);
            this.fldUsername.TabIndex = 10;
            this.fldUsername.Text = "anrl";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Status";
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(181, 269);
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(210, 20);
            this.textStatus.TabIndex = 15;
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblAnrlServer);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.fldServer);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.fldPassword);
            this.Controls.Add(this.fldUsername);
            this.Name = "Connect";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.Connect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAnrlServer;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox fldServer;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnConnect;
        protected System.Windows.Forms.TextBox fldPassword;
        protected System.Windows.Forms.TextBox fldUsername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textStatus;
    }
}
