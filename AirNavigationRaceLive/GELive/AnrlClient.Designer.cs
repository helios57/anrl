namespace GELive
{
    partial class AnrlClient
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
            this.fldServer = new System.Windows.Forms.ComboBox();
            this.lblAnrlServer = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.fldUsername = new System.Windows.Forms.TextBox();
            this.fldPassword = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.panelConnection = new System.Windows.Forms.Panel();
            this.panelTrackerPilot = new System.Windows.Forms.Panel();
            this.lstTrackers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnRefreshTrackerList = new System.Windows.Forms.Button();
            this.btnRemvPilotFromTracker = new System.Windows.Forms.Button();
            this.btnAddPilotToTracker = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstRace = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.btnNewRace = new System.Windows.Forms.Button();
            this.btnRemvRace = new System.Windows.Forms.Button();
            this.lblRace = new System.Windows.Forms.Label();
            this.fldRaceName = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelConnection.SuspendLayout();
            this.panelTrackerPilot.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fldServer
            // 
            this.fldServer.FormattingEnabled = true;
            this.fldServer.Items.AddRange(new object[] {
            "http://127.0.0.1:5555/",
            "http://92.51.137.17:5555/"});
            this.fldServer.Location = new System.Drawing.Point(79, 7);
            this.fldServer.Name = "fldServer";
            this.fldServer.Size = new System.Drawing.Size(121, 21);
            this.fldServer.TabIndex = 0;
            // 
            // lblAnrlServer
            // 
            this.lblAnrlServer.AutoSize = true;
            this.lblAnrlServer.Location = new System.Drawing.Point(3, 10);
            this.lblAnrlServer.Name = "lblAnrlServer";
            this.lblAnrlServer.Size = new System.Drawing.Size(70, 13);
            this.lblAnrlServer.TabIndex = 1;
            this.lblAnrlServer.Text = "ARNL Server";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(206, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(57, 75);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // fldUsername
            // 
            this.fldUsername.Location = new System.Drawing.Point(79, 34);
            this.fldUsername.Name = "fldUsername";
            this.fldUsername.Size = new System.Drawing.Size(121, 20);
            this.fldUsername.TabIndex = 3;
            // 
            // fldPassword
            // 
            this.fldPassword.Location = new System.Drawing.Point(79, 60);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.PasswordChar = '*';
            this.fldPassword.Size = new System.Drawing.Size(121, 20);
            this.fldPassword.TabIndex = 4;
            this.fldPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(3, 37);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 5;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 63);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password";
            // 
            // panelConnection
            // 
            this.panelConnection.Controls.Add(this.lblAnrlServer);
            this.panelConnection.Controls.Add(this.lblPassword);
            this.panelConnection.Controls.Add(this.fldServer);
            this.panelConnection.Controls.Add(this.lblUsername);
            this.panelConnection.Controls.Add(this.btnConnect);
            this.panelConnection.Controls.Add(this.fldPassword);
            this.panelConnection.Controls.Add(this.fldUsername);
            this.panelConnection.Location = new System.Drawing.Point(12, 12);
            this.panelConnection.Name = "panelConnection";
            this.panelConnection.Size = new System.Drawing.Size(267, 86);
            this.panelConnection.TabIndex = 7;
            // 
            // panelTrackerPilot
            // 
            this.panelTrackerPilot.Controls.Add(this.btnAddPilotToTracker);
            this.panelTrackerPilot.Controls.Add(this.btnRemvPilotFromTracker);
            this.panelTrackerPilot.Controls.Add(this.btnRefreshTrackerList);
            this.panelTrackerPilot.Controls.Add(this.lstTrackers);
            this.panelTrackerPilot.Location = new System.Drawing.Point(12, 104);
            this.panelTrackerPilot.Name = "panelTrackerPilot";
            this.panelTrackerPilot.Size = new System.Drawing.Size(657, 99);
            this.panelTrackerPilot.TabIndex = 8;
            // 
            // lstTrackers
            // 
            this.lstTrackers.AllowColumnReorder = true;
            this.lstTrackers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lstTrackers.FullRowSelect = true;
            this.lstTrackers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstTrackers.Location = new System.Drawing.Point(3, 3);
            this.lstTrackers.MultiSelect = false;
            this.lstTrackers.Name = "lstTrackers";
            this.lstTrackers.Size = new System.Drawing.Size(528, 95);
            this.lstTrackers.TabIndex = 23;
            this.lstTrackers.UseCompatibleStateImageBehavior = false;
            this.lstTrackers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tracker ID";
            this.columnHeader1.Width = 67;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "IMEI";
            this.columnHeader2.Width = 139;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LastName";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "SureName";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Pilot ID";
            this.columnHeader5.Width = 80;
            // 
            // btnRefreshTrackerList
            // 
            this.btnRefreshTrackerList.Location = new System.Drawing.Point(537, 3);
            this.btnRefreshTrackerList.Name = "btnRefreshTrackerList";
            this.btnRefreshTrackerList.Size = new System.Drawing.Size(120, 26);
            this.btnRefreshTrackerList.TabIndex = 24;
            this.btnRefreshTrackerList.Text = "Refresh";
            this.btnRefreshTrackerList.UseVisualStyleBackColor = true;
            // 
            // btnRemvPilotFromTracker
            // 
            this.btnRemvPilotFromTracker.Location = new System.Drawing.Point(537, 35);
            this.btnRemvPilotFromTracker.Name = "btnRemvPilotFromTracker";
            this.btnRemvPilotFromTracker.Size = new System.Drawing.Size(120, 26);
            this.btnRemvPilotFromTracker.TabIndex = 25;
            this.btnRemvPilotFromTracker.Text = "Remove Pilot";
            this.btnRemvPilotFromTracker.UseVisualStyleBackColor = true;
            // 
            // btnAddPilotToTracker
            // 
            this.btnAddPilotToTracker.Location = new System.Drawing.Point(537, 67);
            this.btnAddPilotToTracker.Name = "btnAddPilotToTracker";
            this.btnAddPilotToTracker.Size = new System.Drawing.Size(120, 26);
            this.btnAddPilotToTracker.TabIndex = 26;
            this.btnAddPilotToTracker.Text = "Add Pilot";
            this.btnAddPilotToTracker.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.lblRace);
            this.panel1.Controls.Add(this.fldRaceName);
            this.panel1.Controls.Add(this.btnRemvRace);
            this.panel1.Controls.Add(this.btnNewRace);
            this.panel1.Controls.Add(this.lstRace);
            this.panel1.Location = new System.Drawing.Point(12, 208);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(657, 150);
            this.panel1.TabIndex = 9;
            // 
            // lstRace
            // 
            this.lstRace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lstRace.Location = new System.Drawing.Point(6, 3);
            this.lstRace.Name = "lstRace";
            this.lstRace.Size = new System.Drawing.Size(164, 97);
            this.lstRace.TabIndex = 0;
            this.lstRace.UseCompatibleStateImageBehavior = false;
            this.lstRace.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Race ID";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Race";
            this.columnHeader7.Width = 100;
            // 
            // btnNewRace
            // 
            this.btnNewRace.Location = new System.Drawing.Point(6, 106);
            this.btnNewRace.Name = "btnNewRace";
            this.btnNewRace.Size = new System.Drawing.Size(75, 26);
            this.btnNewRace.TabIndex = 27;
            this.btnNewRace.Text = "New";
            this.btnNewRace.UseVisualStyleBackColor = true;
            // 
            // btnRemvRace
            // 
            this.btnRemvRace.Location = new System.Drawing.Point(87, 106);
            this.btnRemvRace.Name = "btnRemvRace";
            this.btnRemvRace.Size = new System.Drawing.Size(83, 26);
            this.btnRemvRace.TabIndex = 28;
            this.btnRemvRace.Text = "Remove";
            this.btnRemvRace.UseVisualStyleBackColor = true;
            // 
            // lblRace
            // 
            this.lblRace.AutoSize = true;
            this.lblRace.Location = new System.Drawing.Point(177, 6);
            this.lblRace.Name = "lblRace";
            this.lblRace.Size = new System.Drawing.Size(33, 13);
            this.lblRace.TabIndex = 30;
            this.lblRace.Text = "Race";
            // 
            // fldRaceName
            // 
            this.fldRaceName.Location = new System.Drawing.Point(232, 3);
            this.fldRaceName.Name = "fldRaceName";
            this.fldRaceName.Size = new System.Drawing.Size(121, 20);
            this.fldRaceName.TabIndex = 29;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(232, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(121, 20);
            this.dateTimePicker1.TabIndex = 31;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(177, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(30, 13);
            this.lblDate.TabIndex = 32;
            this.lblDate.Text = "Date";
            // 
            // AnrlClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 371);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTrackerPilot);
            this.Controls.Add(this.panelConnection);
            this.Name = "AnrlClient";
            this.Text = "AnrlClient";
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.panelTrackerPilot.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox fldServer;
        private System.Windows.Forms.Label lblAnrlServer;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        protected System.Windows.Forms.TextBox fldPassword;
        protected System.Windows.Forms.TextBox fldUsername;
        private System.Windows.Forms.Panel panelConnection;
        private System.Windows.Forms.Panel panelTrackerPilot;
        private System.Windows.Forms.Button btnRemvPilotFromTracker;
        private System.Windows.Forms.Button btnRefreshTrackerList;
        private System.Windows.Forms.ListView lstTrackers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnAddPilotToTracker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lstRace;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnRemvRace;
        private System.Windows.Forms.Button btnNewRace;
        private System.Windows.Forms.Label lblRace;
        protected System.Windows.Forms.TextBox fldRaceName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}