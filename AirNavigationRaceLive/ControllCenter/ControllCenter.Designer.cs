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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.drpAirplane = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAirplane = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPilot = new System.Windows.Forms.TextBox();
            this.btnAddAirplaneToTracker = new System.Windows.Forms.Button();
            this.btnAddNewAirplaneToTracker = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lstTrackers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnRemvAirplaneFromTracker = new System.Windows.Forms.Button();
            this.btnImportPenalty = new System.Windows.Forms.Button();
            this.lblPenaltyZonenLoaded = new System.Windows.Forms.Label();
            this.btnShowDebug = new System.Windows.Forms.Button();
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "4. Tracker / Flugzeuge  Einstellen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "IMEI  und ID der Trackers";
            // 
            // drpAirplane
            // 
            this.drpAirplane.Enabled = false;
            this.drpAirplane.FormattingEnabled = true;
            this.drpAirplane.Location = new System.Drawing.Point(15, 227);
            this.drpAirplane.Name = "drpAirplane";
            this.drpAirplane.Size = new System.Drawing.Size(121, 21);
            this.drpAirplane.TabIndex = 12;
            this.drpAirplane.SelectedIndexChanged += new System.EventHandler(this.drpAirplane_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Flugzeug/Pilot auswählen ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "oder neu Hinzufügen";
            // 
            // txtAirplane
            // 
            this.txtAirplane.Enabled = false;
            this.txtAirplane.Location = new System.Drawing.Point(15, 267);
            this.txtAirplane.Name = "txtAirplane";
            this.txtAirplane.Size = new System.Drawing.Size(129, 20);
            this.txtAirplane.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(150, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Flugzeug";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(152, 296);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Pilot";
            // 
            // txtPilot
            // 
            this.txtPilot.Enabled = false;
            this.txtPilot.Location = new System.Drawing.Point(15, 293);
            this.txtPilot.Name = "txtPilot";
            this.txtPilot.Size = new System.Drawing.Size(129, 20);
            this.txtPilot.TabIndex = 17;
            // 
            // btnAddAirplaneToTracker
            // 
            this.btnAddAirplaneToTracker.Enabled = false;
            this.btnAddAirplaneToTracker.Location = new System.Drawing.Point(150, 225);
            this.btnAddAirplaneToTracker.Name = "btnAddAirplaneToTracker";
            this.btnAddAirplaneToTracker.Size = new System.Drawing.Size(202, 23);
            this.btnAddAirplaneToTracker.TabIndex = 19;
            this.btnAddAirplaneToTracker.Text = "Dem ausgewählten Tracker zuweisen";
            this.btnAddAirplaneToTracker.UseVisualStyleBackColor = true;
            this.btnAddAirplaneToTracker.Click += new System.EventHandler(this.btnAddAirplaneToTracker_Click);
            // 
            // btnAddNewAirplaneToTracker
            // 
            this.btnAddNewAirplaneToTracker.Enabled = false;
            this.btnAddNewAirplaneToTracker.Location = new System.Drawing.Point(15, 319);
            this.btnAddNewAirplaneToTracker.Name = "btnAddNewAirplaneToTracker";
            this.btnAddNewAirplaneToTracker.Size = new System.Drawing.Size(337, 23);
            this.btnAddNewAirplaneToTracker.TabIndex = 20;
            this.btnAddNewAirplaneToTracker.Text = "Hinzufügen und dem Ausgewählten Tracker zuweisen";
            this.btnAddNewAirplaneToTracker.UseVisualStyleBackColor = true;
            this.btnAddNewAirplaneToTracker.Click += new System.EventHandler(this.btnAddNewAirplaneToTracker_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(155, 114);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(81, 20);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Aktualisieren";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.lstTrackers.Location = new System.Drawing.Point(15, 140);
            this.lstTrackers.MultiSelect = false;
            this.lstTrackers.Name = "lstTrackers";
            this.lstTrackers.Size = new System.Drawing.Size(531, 68);
            this.lstTrackers.TabIndex = 22;
            this.lstTrackers.UseCompatibleStateImageBehavior = false;
            this.lstTrackers.View = System.Windows.Forms.View.Details;
            this.lstTrackers.SelectedIndexChanged += new System.EventHandler(this.lstTrackers_SelectedIndexChanged);
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
            this.columnHeader3.Text = "Flugzeug";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Pilot";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Flugzeug ID";
            this.columnHeader5.Width = 80;
            // 
            // btnRemvAirplaneFromTracker
            // 
            this.btnRemvAirplaneFromTracker.Enabled = false;
            this.btnRemvAirplaneFromTracker.Location = new System.Drawing.Point(552, 140);
            this.btnRemvAirplaneFromTracker.Name = "btnRemvAirplaneFromTracker";
            this.btnRemvAirplaneFromTracker.Size = new System.Drawing.Size(120, 68);
            this.btnRemvAirplaneFromTracker.TabIndex = 23;
            this.btnRemvAirplaneFromTracker.Text = "Flugzeug von Tracker entfernen";
            this.btnRemvAirplaneFromTracker.UseVisualStyleBackColor = true;
            this.btnRemvAirplaneFromTracker.Click += new System.EventHandler(this.btnRemvAirplaneFromTracker_Click);
            // 
            // btnImportPenalty
            // 
            this.btnImportPenalty.Enabled = false;
            this.btnImportPenalty.Location = new System.Drawing.Point(15, 348);
            this.btnImportPenalty.Name = "btnImportPenalty";
            this.btnImportPenalty.Size = new System.Drawing.Size(337, 23);
            this.btnImportPenalty.TabIndex = 24;
            this.btnImportPenalty.Text = "Import Penalty-Zonen von dxf";
            this.btnImportPenalty.UseVisualStyleBackColor = true;
            this.btnImportPenalty.Click += new System.EventHandler(this.btnImportPenalty_Click);
            // 
            // lblPenaltyZonenLoaded
            // 
            this.lblPenaltyZonenLoaded.AutoSize = true;
            this.lblPenaltyZonenLoaded.Location = new System.Drawing.Point(358, 358);
            this.lblPenaltyZonenLoaded.Name = "lblPenaltyZonenLoaded";
            this.lblPenaltyZonenLoaded.Size = new System.Drawing.Size(120, 13);
            this.lblPenaltyZonenLoaded.TabIndex = 25;
            this.lblPenaltyZonenLoaded.Text = "0 Penalty Zonen loaded";
            // 
            // btnShowDebug
            // 
            this.btnShowDebug.Location = new System.Drawing.Point(612, 358);
            this.btnShowDebug.Name = "btnShowDebug";
            this.btnShowDebug.Size = new System.Drawing.Size(96, 20);
            this.btnShowDebug.TabIndex = 26;
            this.btnShowDebug.Text = "Debug-Window";
            this.btnShowDebug.UseVisualStyleBackColor = true;
            this.btnShowDebug.Click += new System.EventHandler(this.btnShowDebug_Click);
            // 
            // ControllCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 380);
            this.Controls.Add(this.btnShowDebug);
            this.Controls.Add(this.lblPenaltyZonenLoaded);
            this.Controls.Add(this.btnImportPenalty);
            this.Controls.Add(this.btnRemvAirplaneFromTracker);
            this.Controls.Add(this.lstTrackers);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddNewAirplaneToTracker);
            this.Controls.Add(this.btnAddAirplaneToTracker);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPilot);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAirplane);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.drpAirplane);
            this.Controls.Add(this.label5);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControllCenter_FormClosing);
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox drpAirplane;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtAirplane;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPilot;
        private System.Windows.Forms.Button btnAddAirplaneToTracker;
        private System.Windows.Forms.Button btnAddNewAirplaneToTracker;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lstTrackers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnRemvAirplaneFromTracker;
        private System.Windows.Forms.Button btnImportPenalty;
        private System.Windows.Forms.Label lblPenaltyZonenLoaded;
        private System.Windows.Forms.Button btnShowDebug;
    }
}

