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
            this.btnLogin = new System.Windows.Forms.Button();
            this.fldPassword = new System.Windows.Forms.TextBox();
            this.fldUsername = new System.Windows.Forms.TextBox();
            this.checkBoxClearCache = new System.Windows.Forms.CheckBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.fldCompetition = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fldOwner = new System.Windows.Forms.TextBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fldCompetitionName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.fldPublicRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAnrlServer
            // 
            this.lblAnrlServer.AutoSize = true;
            this.lblAnrlServer.Location = new System.Drawing.Point(2, 6);
            this.lblAnrlServer.Name = "lblAnrlServer";
            this.lblAnrlServer.Size = new System.Drawing.Size(70, 13);
            this.lblAnrlServer.TabIndex = 8;
            this.lblAnrlServer.Text = "ARNL Server";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(2, 59);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 13;
            this.lblPassword.Text = "Password";
            // 
            // fldServer
            // 
            this.fldServer.FormattingEnabled = true;
            this.fldServer.Items.AddRange(new object[] {
            "46.163.65.74",
            "127.0.0.1",
            "83.169.11.154"});
            this.fldServer.Location = new System.Drawing.Point(78, 3);
            this.fldServer.Name = "fldServer";
            this.fldServer.Size = new System.Drawing.Size(98, 21);
            this.fldServer.TabIndex = 1;
            this.fldServer.Text = "46.163.65.74";
            this.fldServer.SelectedIndexChanged += new System.EventHandler(this.fldServer_SelectedIndexChanged);
            this.fldServer.TextChanged += new System.EventHandler(this.fldServer_SelectedIndexChanged);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(2, 33);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 12;
            this.lblUsername.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(182, 28);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(57, 48);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // fldPassword
            // 
            this.fldPassword.Location = new System.Drawing.Point(78, 56);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.PasswordChar = '*';
            this.fldPassword.Size = new System.Drawing.Size(98, 20);
            this.fldPassword.TabIndex = 3;
            this.fldPassword.UseSystemPasswordChar = true;
            // 
            // fldUsername
            // 
            this.fldUsername.Location = new System.Drawing.Point(78, 30);
            this.fldUsername.Name = "fldUsername";
            this.fldUsername.Size = new System.Drawing.Size(98, 20);
            this.fldUsername.TabIndex = 2;
            // 
            // checkBoxClearCache
            // 
            this.checkBoxClearCache.AutoSize = true;
            this.checkBoxClearCache.Checked = true;
            this.checkBoxClearCache.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxClearCache.Location = new System.Drawing.Point(182, 157);
            this.checkBoxClearCache.Name = "checkBoxClearCache";
            this.checkBoxClearCache.Size = new System.Drawing.Size(84, 17);
            this.checkBoxClearCache.TabIndex = 8;
            this.checkBoxClearCache.Text = "Clear Cache";
            this.checkBoxClearCache.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(245, 28);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(57, 48);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Competition";
            // 
            // fldCompetition
            // 
            this.fldCompetition.FormattingEnabled = true;
            this.fldCompetition.Location = new System.Drawing.Point(78, 125);
            this.fldCompetition.Name = "fldCompetition";
            this.fldCompetition.Size = new System.Drawing.Size(224, 21);
            this.fldCompetition.TabIndex = 6;
            this.fldCompetition.SelectedIndexChanged += new System.EventHandler(this.fldCompetition_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Owner";
            this.label2.Visible = false;
            // 
            // fldOwner
            // 
            this.fldOwner.Location = new System.Drawing.Point(383, 125);
            this.fldOwner.Name = "fldOwner";
            this.fldOwner.Size = new System.Drawing.Size(98, 20);
            this.fldOwner.TabIndex = 20;
            this.fldOwner.Visible = false;
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(78, 152);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(98, 24);
            this.btnUse.TabIndex = 7;
            this.btnUse.Text = "Use";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 230);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Create new Competition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Name";
            // 
            // fldCompetitionName
            // 
            this.fldCompetitionName.Location = new System.Drawing.Point(78, 255);
            this.fldCompetitionName.Name = "fldCompetitionName";
            this.fldCompetitionName.Size = new System.Drawing.Size(224, 20);
            this.fldCompetitionName.TabIndex = 9;
            this.fldCompetitionName.TextChanged += new System.EventHandler(this.fldCompetitionName_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(78, 308);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 24);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // fldPublicRole
            // 
            this.fldPublicRole.FormattingEnabled = true;
            this.fldPublicRole.Location = new System.Drawing.Point(78, 281);
            this.fldPublicRole.Name = "fldPublicRole";
            this.fldPublicRole.Size = new System.Drawing.Size(98, 21);
            this.fldPublicRole.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Public Role";
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fldPublicRole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fldCompetitionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fldOwner);
            this.Controls.Add(this.fldCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.checkBoxClearCache);
            this.Controls.Add(this.lblAnrlServer);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.fldServer);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogin);
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
        private System.Windows.Forms.Button btnLogin;
        protected System.Windows.Forms.TextBox fldPassword;
        protected System.Windows.Forms.TextBox fldUsername;
        private System.Windows.Forms.CheckBox checkBoxClearCache;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fldCompetition;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox fldOwner;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox fldCompetitionName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox fldPublicRole;
        private System.Windows.Forms.Label label5;
    }
}
