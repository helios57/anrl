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
            this.btnAddPilotToTracker = new System.Windows.Forms.Button();
            this.btnRemvPilotFromTracker = new System.Windows.Forms.Button();
            this.btnRefreshTrackerList = new System.Windows.Forms.Button();
            this.lstTrackers = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.panelRace = new System.Windows.Forms.Panel();
            this.fldRaceParcour = new System.Windows.Forms.TextBox();
            this.btnShowRanking = new System.Windows.Forms.Button();
            this.lblParcour = new System.Windows.Forms.Label();
            this.btnSelectParcour = new System.Windows.Forms.Button();
            this.fldRacePolygonsLoaded = new System.Windows.Forms.TextBox();
            this.lblPolygons = new System.Windows.Forms.Label();
            this.btnRacesRefresh = new System.Windows.Forms.Button();
            this.btnRacePilotD = new System.Windows.Forms.Button();
            this.btnRacePilotC = new System.Windows.Forms.Button();
            this.btnRacePilotB = new System.Windows.Forms.Button();
            this.btnRacePilotA = new System.Windows.Forms.Button();
            this.fldRacePilotD = new System.Windows.Forms.TextBox();
            this.fldRacePilotC = new System.Windows.Forms.TextBox();
            this.fldRacePilotB = new System.Windows.Forms.TextBox();
            this.fldRacePilotA = new System.Windows.Forms.TextBox();
            this.lblPilotB = new System.Windows.Forms.Label();
            this.lblPilotC = new System.Windows.Forms.Label();
            this.lblPilotD = new System.Windows.Forms.Label();
            this.lblPilotA = new System.Windows.Forms.Label();
            this.fldRaceDuration = new System.Windows.Forms.NumericUpDown();
            this.lblRaceDuration = new System.Windows.Forms.Label();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.fldRaceTime = new System.Windows.Forms.DateTimePicker();
            this.btnSaveRace = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.fldRaceDate = new System.Windows.Forms.DateTimePicker();
            this.lblRace = new System.Windows.Forms.Label();
            this.fldRaceName = new System.Windows.Forms.TextBox();
            this.btnRemvRace = new System.Windows.Forms.Button();
            this.btnNewRace = new System.Windows.Forms.Button();
            this.lstRace = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.panelStarterPanel = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lstVisualPilotsToShow = new System.Windows.Forms.CheckedListBox();
            this.lstVisualRacesToShow = new System.Windows.Forms.CheckedListBox();
            this.lblPilotsToShow = new System.Windows.Forms.Label();
            this.lblVisualRacesToShow = new System.Windows.Forms.Label();
            this.btnVisualLoadOlder = new System.Windows.Forms.Button();
            this.lblVisualPlaySpeed = new System.Windows.Forms.Label();
            this.fldVisualPlaySpeed = new System.Windows.Forms.NumericUpDown();
            this.VisualChkBoxAlwaysNewest = new System.Windows.Forms.CheckBox();
            this.VisualScrollBar = new System.Windows.Forms.HScrollBar();
            this.btnStartClient = new System.Windows.Forms.Button();
            this.panelConnection.SuspendLayout();
            this.panelTrackerPilot.SuspendLayout();
            this.panelRace.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldRaceDuration)).BeginInit();
            this.panelStarterPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualPlaySpeed)).BeginInit();
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
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // fldUsername
            // 
            this.fldUsername.Location = new System.Drawing.Point(79, 34);
            this.fldUsername.Name = "fldUsername";
            this.fldUsername.Size = new System.Drawing.Size(121, 20);
            this.fldUsername.TabIndex = 3;
            this.fldUsername.Text = "anrl";
            // 
            // fldPassword
            // 
            this.fldPassword.Location = new System.Drawing.Point(79, 60);
            this.fldPassword.Name = "fldPassword";
            this.fldPassword.PasswordChar = '*';
            this.fldPassword.Size = new System.Drawing.Size(121, 20);
            this.fldPassword.TabIndex = 4;
            this.fldPassword.Text = "anrl";
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
            this.panelTrackerPilot.Location = new System.Drawing.Point(12, 12);
            this.panelTrackerPilot.Name = "panelTrackerPilot";
            this.panelTrackerPilot.Size = new System.Drawing.Size(657, 99);
            this.panelTrackerPilot.TabIndex = 8;
            // 
            // btnAddPilotToTracker
            // 
            this.btnAddPilotToTracker.Location = new System.Drawing.Point(537, 67);
            this.btnAddPilotToTracker.Name = "btnAddPilotToTracker";
            this.btnAddPilotToTracker.Size = new System.Drawing.Size(120, 26);
            this.btnAddPilotToTracker.TabIndex = 26;
            this.btnAddPilotToTracker.Text = "Add Pilot";
            this.btnAddPilotToTracker.UseVisualStyleBackColor = true;
            this.btnAddPilotToTracker.Click += new System.EventHandler(this.btnAddPilotToTracker_Click);
            // 
            // btnRemvPilotFromTracker
            // 
            this.btnRemvPilotFromTracker.Location = new System.Drawing.Point(537, 35);
            this.btnRemvPilotFromTracker.Name = "btnRemvPilotFromTracker";
            this.btnRemvPilotFromTracker.Size = new System.Drawing.Size(120, 26);
            this.btnRemvPilotFromTracker.TabIndex = 25;
            this.btnRemvPilotFromTracker.Text = "Remove Pilot";
            this.btnRemvPilotFromTracker.UseVisualStyleBackColor = true;
            this.btnRemvPilotFromTracker.Click += new System.EventHandler(this.btnRemvPilotFromTracker_Click);
            // 
            // btnRefreshTrackerList
            // 
            this.btnRefreshTrackerList.Location = new System.Drawing.Point(537, 3);
            this.btnRefreshTrackerList.Name = "btnRefreshTrackerList";
            this.btnRefreshTrackerList.Size = new System.Drawing.Size(120, 26);
            this.btnRefreshTrackerList.TabIndex = 24;
            this.btnRefreshTrackerList.Text = "Refresh";
            this.btnRefreshTrackerList.UseVisualStyleBackColor = true;
            this.btnRefreshTrackerList.Click += new System.EventHandler(this.btnRefreshTrackerList_Click);
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
            this.columnHeader3.Text = "Pilot ID";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Lastname";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Surename";
            this.columnHeader5.Width = 80;
            // 
            // panelRace
            // 
            this.panelRace.Controls.Add(this.fldRaceParcour);
            this.panelRace.Controls.Add(this.btnShowRanking);
            this.panelRace.Controls.Add(this.lblParcour);
            this.panelRace.Controls.Add(this.btnSelectParcour);
            this.panelRace.Controls.Add(this.fldRacePolygonsLoaded);
            this.panelRace.Controls.Add(this.lblPolygons);
            this.panelRace.Controls.Add(this.btnRacesRefresh);
            this.panelRace.Controls.Add(this.btnRacePilotD);
            this.panelRace.Controls.Add(this.btnRacePilotC);
            this.panelRace.Controls.Add(this.btnRacePilotB);
            this.panelRace.Controls.Add(this.btnRacePilotA);
            this.panelRace.Controls.Add(this.fldRacePilotD);
            this.panelRace.Controls.Add(this.fldRacePilotC);
            this.panelRace.Controls.Add(this.fldRacePilotB);
            this.panelRace.Controls.Add(this.fldRacePilotA);
            this.panelRace.Controls.Add(this.lblPilotB);
            this.panelRace.Controls.Add(this.lblPilotC);
            this.panelRace.Controls.Add(this.lblPilotD);
            this.panelRace.Controls.Add(this.lblPilotA);
            this.panelRace.Controls.Add(this.fldRaceDuration);
            this.panelRace.Controls.Add(this.lblRaceDuration);
            this.panelRace.Controls.Add(this.lblStartTime);
            this.panelRace.Controls.Add(this.fldRaceTime);
            this.panelRace.Controls.Add(this.btnSaveRace);
            this.panelRace.Controls.Add(this.lblDate);
            this.panelRace.Controls.Add(this.fldRaceDate);
            this.panelRace.Controls.Add(this.lblRace);
            this.panelRace.Controls.Add(this.fldRaceName);
            this.panelRace.Controls.Add(this.btnRemvRace);
            this.panelRace.Controls.Add(this.btnNewRace);
            this.panelRace.Controls.Add(this.lstRace);
            this.panelRace.Location = new System.Drawing.Point(12, 116);
            this.panelRace.Name = "panelRace";
            this.panelRace.Size = new System.Drawing.Size(657, 160);
            this.panelRace.TabIndex = 9;
            // 
            // fldRaceParcour
            // 
            this.fldRaceParcour.Enabled = false;
            this.fldRaceParcour.Location = new System.Drawing.Point(424, 102);
            this.fldRaceParcour.Name = "fldRaceParcour";
            this.fldRaceParcour.Size = new System.Drawing.Size(131, 20);
            this.fldRaceParcour.TabIndex = 58;
            // 
            // btnShowRanking
            // 
            this.btnShowRanking.Location = new System.Drawing.Point(257, 131);
            this.btnShowRanking.Name = "btnShowRanking";
            this.btnShowRanking.Size = new System.Drawing.Size(96, 26);
            this.btnShowRanking.TabIndex = 1;
            this.btnShowRanking.Text = "Show Ranking";
            this.btnShowRanking.UseVisualStyleBackColor = true;
            this.btnShowRanking.Click += new System.EventHandler(this.btnShowRanking_Click);
            // 
            // lblParcour
            // 
            this.lblParcour.AutoSize = true;
            this.lblParcour.Location = new System.Drawing.Point(381, 105);
            this.lblParcour.Name = "lblParcour";
            this.lblParcour.Size = new System.Drawing.Size(44, 13);
            this.lblParcour.TabIndex = 57;
            this.lblParcour.Text = "Parcour";
            // 
            // btnSelectParcour
            // 
            this.btnSelectParcour.Enabled = false;
            this.btnSelectParcour.Location = new System.Drawing.Point(561, 101);
            this.btnSelectParcour.Name = "btnSelectParcour";
            this.btnSelectParcour.Size = new System.Drawing.Size(83, 21);
            this.btnSelectParcour.TabIndex = 56;
            this.btnSelectParcour.Text = "Select";
            this.btnSelectParcour.UseVisualStyleBackColor = true;
            this.btnSelectParcour.Click += new System.EventHandler(this.btnSelectParcour_Click);
            // 
            // fldRacePolygonsLoaded
            // 
            this.fldRacePolygonsLoaded.Enabled = false;
            this.fldRacePolygonsLoaded.Location = new System.Drawing.Point(272, 105);
            this.fldRacePolygonsLoaded.Name = "fldRacePolygonsLoaded";
            this.fldRacePolygonsLoaded.Size = new System.Drawing.Size(80, 20);
            this.fldRacePolygonsLoaded.TabIndex = 55;
            // 
            // lblPolygons
            // 
            this.lblPolygons.AutoSize = true;
            this.lblPolygons.Location = new System.Drawing.Point(177, 112);
            this.lblPolygons.Name = "lblPolygons";
            this.lblPolygons.Size = new System.Drawing.Size(89, 13);
            this.lblPolygons.TabIndex = 54;
            this.lblPolygons.Text = "Polygons Loaded";
            // 
            // btnRacesRefresh
            // 
            this.btnRacesRefresh.Location = new System.Drawing.Point(6, 132);
            this.btnRacesRefresh.Name = "btnRacesRefresh";
            this.btnRacesRefresh.Size = new System.Drawing.Size(75, 26);
            this.btnRacesRefresh.TabIndex = 53;
            this.btnRacesRefresh.Text = "Refresh";
            this.btnRacesRefresh.UseVisualStyleBackColor = true;
            this.btnRacesRefresh.Click += new System.EventHandler(this.btnRacesRefresh_Click);
            // 
            // btnRacePilotD
            // 
            this.btnRacePilotD.Location = new System.Drawing.Point(561, 70);
            this.btnRacePilotD.Name = "btnRacePilotD";
            this.btnRacePilotD.Size = new System.Drawing.Size(83, 20);
            this.btnRacePilotD.TabIndex = 51;
            this.btnRacePilotD.Text = "Add Pilot";
            this.btnRacePilotD.UseVisualStyleBackColor = true;
            this.btnRacePilotD.Click += new System.EventHandler(this.btnRacePilotD_Click);
            // 
            // btnRacePilotC
            // 
            this.btnRacePilotC.Location = new System.Drawing.Point(561, 47);
            this.btnRacePilotC.Name = "btnRacePilotC";
            this.btnRacePilotC.Size = new System.Drawing.Size(83, 20);
            this.btnRacePilotC.TabIndex = 50;
            this.btnRacePilotC.Text = "Add Pilot";
            this.btnRacePilotC.UseVisualStyleBackColor = true;
            this.btnRacePilotC.Click += new System.EventHandler(this.btnRacePilotC_Click);
            // 
            // btnRacePilotB
            // 
            this.btnRacePilotB.Location = new System.Drawing.Point(561, 26);
            this.btnRacePilotB.Name = "btnRacePilotB";
            this.btnRacePilotB.Size = new System.Drawing.Size(83, 20);
            this.btnRacePilotB.TabIndex = 49;
            this.btnRacePilotB.Text = "Add Pilot";
            this.btnRacePilotB.UseVisualStyleBackColor = true;
            this.btnRacePilotB.Click += new System.EventHandler(this.btnRacePilotB_Click);
            // 
            // btnRacePilotA
            // 
            this.btnRacePilotA.Location = new System.Drawing.Point(561, 3);
            this.btnRacePilotA.Name = "btnRacePilotA";
            this.btnRacePilotA.Size = new System.Drawing.Size(83, 20);
            this.btnRacePilotA.TabIndex = 48;
            this.btnRacePilotA.Text = "Add Pilot";
            this.btnRacePilotA.UseVisualStyleBackColor = true;
            this.btnRacePilotA.Click += new System.EventHandler(this.btnRacePilotA_Click);
            // 
            // fldRacePilotD
            // 
            this.fldRacePilotD.Enabled = false;
            this.fldRacePilotD.Location = new System.Drawing.Point(424, 71);
            this.fldRacePilotD.Name = "fldRacePilotD";
            this.fldRacePilotD.Size = new System.Drawing.Size(131, 20);
            this.fldRacePilotD.TabIndex = 47;
            // 
            // fldRacePilotC
            // 
            this.fldRacePilotC.Enabled = false;
            this.fldRacePilotC.Location = new System.Drawing.Point(424, 48);
            this.fldRacePilotC.Name = "fldRacePilotC";
            this.fldRacePilotC.Size = new System.Drawing.Size(131, 20);
            this.fldRacePilotC.TabIndex = 46;
            // 
            // fldRacePilotB
            // 
            this.fldRacePilotB.Enabled = false;
            this.fldRacePilotB.Location = new System.Drawing.Point(424, 26);
            this.fldRacePilotB.Name = "fldRacePilotB";
            this.fldRacePilotB.Size = new System.Drawing.Size(131, 20);
            this.fldRacePilotB.TabIndex = 45;
            // 
            // fldRacePilotA
            // 
            this.fldRacePilotA.Enabled = false;
            this.fldRacePilotA.Location = new System.Drawing.Point(424, 3);
            this.fldRacePilotA.Name = "fldRacePilotA";
            this.fldRacePilotA.Size = new System.Drawing.Size(131, 20);
            this.fldRacePilotA.TabIndex = 44;
            // 
            // lblPilotB
            // 
            this.lblPilotB.AutoSize = true;
            this.lblPilotB.Location = new System.Drawing.Point(381, 29);
            this.lblPilotB.Name = "lblPilotB";
            this.lblPilotB.Size = new System.Drawing.Size(37, 13);
            this.lblPilotB.TabIndex = 43;
            this.lblPilotB.Text = "Pilot B";
            // 
            // lblPilotC
            // 
            this.lblPilotC.AutoSize = true;
            this.lblPilotC.Location = new System.Drawing.Point(381, 51);
            this.lblPilotC.Name = "lblPilotC";
            this.lblPilotC.Size = new System.Drawing.Size(37, 13);
            this.lblPilotC.TabIndex = 42;
            this.lblPilotC.Text = "Pilot C";
            // 
            // lblPilotD
            // 
            this.lblPilotD.AutoSize = true;
            this.lblPilotD.Location = new System.Drawing.Point(381, 74);
            this.lblPilotD.Name = "lblPilotD";
            this.lblPilotD.Size = new System.Drawing.Size(38, 13);
            this.lblPilotD.TabIndex = 41;
            this.lblPilotD.Text = "Pilot D";
            // 
            // lblPilotA
            // 
            this.lblPilotA.AutoSize = true;
            this.lblPilotA.Location = new System.Drawing.Point(381, 6);
            this.lblPilotA.Name = "lblPilotA";
            this.lblPilotA.Size = new System.Drawing.Size(37, 13);
            this.lblPilotA.TabIndex = 40;
            this.lblPilotA.Text = "Pilot A";
            // 
            // fldRaceDuration
            // 
            this.fldRaceDuration.Location = new System.Drawing.Point(232, 81);
            this.fldRaceDuration.Name = "fldRaceDuration";
            this.fldRaceDuration.Size = new System.Drawing.Size(120, 20);
            this.fldRaceDuration.TabIndex = 39;
            this.fldRaceDuration.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fldRaceDuration.ValueChanged += new System.EventHandler(this.fldRaceDuration_ValueChanged);
            // 
            // lblRaceDuration
            // 
            this.lblRaceDuration.AutoSize = true;
            this.lblRaceDuration.Location = new System.Drawing.Point(176, 88);
            this.lblRaceDuration.Name = "lblRaceDuration";
            this.lblRaceDuration.Size = new System.Drawing.Size(47, 13);
            this.lblRaceDuration.TabIndex = 38;
            this.lblRaceDuration.Text = "Duration";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(177, 62);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(55, 13);
            this.lblStartTime.TabIndex = 36;
            this.lblStartTime.Text = "Start Time";
            // 
            // fldRaceTime
            // 
            this.fldRaceTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.fldRaceTime.Location = new System.Drawing.Point(232, 55);
            this.fldRaceTime.Name = "fldRaceTime";
            this.fldRaceTime.Size = new System.Drawing.Size(121, 20);
            this.fldRaceTime.TabIndex = 35;
            this.fldRaceTime.Value = new System.DateTime(2009, 8, 21, 19, 46, 0, 0);
            this.fldRaceTime.ValueChanged += new System.EventHandler(this.fldRaceTime_ValueChanged);
            // 
            // btnSaveRace
            // 
            this.btnSaveRace.Location = new System.Drawing.Point(561, 131);
            this.btnSaveRace.Name = "btnSaveRace";
            this.btnSaveRace.Size = new System.Drawing.Size(83, 26);
            this.btnSaveRace.TabIndex = 33;
            this.btnSaveRace.Text = "Save Race";
            this.btnSaveRace.UseVisualStyleBackColor = true;
            this.btnSaveRace.Click += new System.EventHandler(this.btnSaveRace_Click);
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
            // fldRaceDate
            // 
            this.fldRaceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.fldRaceDate.Location = new System.Drawing.Point(232, 29);
            this.fldRaceDate.Name = "fldRaceDate";
            this.fldRaceDate.Size = new System.Drawing.Size(121, 20);
            this.fldRaceDate.TabIndex = 31;
            this.fldRaceDate.ValueChanged += new System.EventHandler(this.fldRaceDate_ValueChanged);
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
            this.fldRaceName.TextChanged += new System.EventHandler(this.fldRaceName_TextChanged);
            // 
            // btnRemvRace
            // 
            this.btnRemvRace.Location = new System.Drawing.Point(87, 131);
            this.btnRemvRace.Name = "btnRemvRace";
            this.btnRemvRace.Size = new System.Drawing.Size(83, 26);
            this.btnRemvRace.TabIndex = 28;
            this.btnRemvRace.Text = "Remove";
            this.btnRemvRace.UseVisualStyleBackColor = true;
            this.btnRemvRace.Click += new System.EventHandler(this.btnRemvRace_Click);
            // 
            // btnNewRace
            // 
            this.btnNewRace.Location = new System.Drawing.Point(176, 131);
            this.btnNewRace.Name = "btnNewRace";
            this.btnNewRace.Size = new System.Drawing.Size(75, 26);
            this.btnNewRace.TabIndex = 27;
            this.btnNewRace.Text = "New";
            this.btnNewRace.UseVisualStyleBackColor = true;
            this.btnNewRace.Click += new System.EventHandler(this.btnNewRace_Click);
            // 
            // lstRace
            // 
            this.lstRace.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.lstRace.FullRowSelect = true;
            this.lstRace.Location = new System.Drawing.Point(6, 3);
            this.lstRace.MultiSelect = false;
            this.lstRace.Name = "lstRace";
            this.lstRace.Size = new System.Drawing.Size(164, 122);
            this.lstRace.TabIndex = 0;
            this.lstRace.UseCompatibleStateImageBehavior = false;
            this.lstRace.View = System.Windows.Forms.View.Details;
            this.lstRace.SelectedIndexChanged += new System.EventHandler(this.lstRace_SelectedIndexChanged);
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
            // panelStarterPanel
            // 
            this.panelStarterPanel.Controls.Add(this.checkBox1);
            this.panelStarterPanel.Controls.Add(this.lstVisualPilotsToShow);
            this.panelStarterPanel.Controls.Add(this.lstVisualRacesToShow);
            this.panelStarterPanel.Controls.Add(this.lblPilotsToShow);
            this.panelStarterPanel.Controls.Add(this.lblVisualRacesToShow);
            this.panelStarterPanel.Controls.Add(this.btnVisualLoadOlder);
            this.panelStarterPanel.Controls.Add(this.lblVisualPlaySpeed);
            this.panelStarterPanel.Controls.Add(this.fldVisualPlaySpeed);
            this.panelStarterPanel.Controls.Add(this.VisualChkBoxAlwaysNewest);
            this.panelStarterPanel.Controls.Add(this.VisualScrollBar);
            this.panelStarterPanel.Controls.Add(this.btnStartClient);
            this.panelStarterPanel.Location = new System.Drawing.Point(12, 282);
            this.panelStarterPanel.Name = "panelStarterPanel";
            this.panelStarterPanel.Size = new System.Drawing.Size(657, 169);
            this.panelStarterPanel.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(2, 118);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 17);
            this.checkBox1.TabIndex = 64;
            this.checkBox1.Text = "Show Ranking for this Races";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lstVisualPilotsToShow
            // 
            this.lstVisualPilotsToShow.FormattingEnabled = true;
            this.lstVisualPilotsToShow.Location = new System.Drawing.Point(179, 22);
            this.lstVisualPilotsToShow.Name = "lstVisualPilotsToShow";
            this.lstVisualPilotsToShow.Size = new System.Drawing.Size(167, 109);
            this.lstVisualPilotsToShow.TabIndex = 63;
            this.lstVisualPilotsToShow.SelectedIndexChanged += new System.EventHandler(this.lstVisualPilotsToShow_SelectedIndexChanged);
            // 
            // lstVisualRacesToShow
            // 
            this.lstVisualRacesToShow.FormattingEnabled = true;
            this.lstVisualRacesToShow.Location = new System.Drawing.Point(3, 22);
            this.lstVisualRacesToShow.Name = "lstVisualRacesToShow";
            this.lstVisualRacesToShow.Size = new System.Drawing.Size(167, 94);
            this.lstVisualRacesToShow.TabIndex = 62;
            this.lstVisualRacesToShow.SelectedIndexChanged += new System.EventHandler(this.lstVisualRacesToShow_SelectedIndexChanged);
            // 
            // lblPilotsToShow
            // 
            this.lblPilotsToShow.AutoSize = true;
            this.lblPilotsToShow.Location = new System.Drawing.Point(177, 6);
            this.lblPilotsToShow.Name = "lblPilotsToShow";
            this.lblPilotsToShow.Size = new System.Drawing.Size(74, 13);
            this.lblPilotsToShow.TabIndex = 61;
            this.lblPilotsToShow.Text = "Pilots to Show";
            // 
            // lblVisualRacesToShow
            // 
            this.lblVisualRacesToShow.AutoSize = true;
            this.lblVisualRacesToShow.Location = new System.Drawing.Point(3, 6);
            this.lblVisualRacesToShow.Name = "lblVisualRacesToShow";
            this.lblVisualRacesToShow.Size = new System.Drawing.Size(80, 13);
            this.lblVisualRacesToShow.TabIndex = 60;
            this.lblVisualRacesToShow.Text = "Races to Show";
            // 
            // btnVisualLoadOlder
            // 
            this.btnVisualLoadOlder.Location = new System.Drawing.Point(0, 136);
            this.btnVisualLoadOlder.Name = "btnVisualLoadOlder";
            this.btnVisualLoadOlder.Size = new System.Drawing.Size(73, 28);
            this.btnVisualLoadOlder.TabIndex = 57;
            this.btnVisualLoadOlder.Text = "Load Older";
            this.btnVisualLoadOlder.UseVisualStyleBackColor = true;
            this.btnVisualLoadOlder.Click += new System.EventHandler(this.btnVisualLoadOlder_Click);
            // 
            // lblVisualPlaySpeed
            // 
            this.lblVisualPlaySpeed.AutoSize = true;
            this.lblVisualPlaySpeed.Location = new System.Drawing.Point(555, 57);
            this.lblVisualPlaySpeed.Name = "lblVisualPlaySpeed";
            this.lblVisualPlaySpeed.Size = new System.Drawing.Size(58, 13);
            this.lblVisualPlaySpeed.TabIndex = 55;
            this.lblVisualPlaySpeed.Text = "PlaySpeed";
            // 
            // fldVisualPlaySpeed
            // 
            this.fldVisualPlaySpeed.Location = new System.Drawing.Point(503, 50);
            this.fldVisualPlaySpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fldVisualPlaySpeed.Name = "fldVisualPlaySpeed";
            this.fldVisualPlaySpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fldVisualPlaySpeed.Size = new System.Drawing.Size(46, 20);
            this.fldVisualPlaySpeed.TabIndex = 3;
            this.fldVisualPlaySpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.fldVisualPlaySpeed.ValueChanged += new System.EventHandler(this.fldVisualPlaySpeed_ValueChanged);
            // 
            // VisualChkBoxAlwaysNewest
            // 
            this.VisualChkBoxAlwaysNewest.AutoSize = true;
            this.VisualChkBoxAlwaysNewest.Checked = true;
            this.VisualChkBoxAlwaysNewest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VisualChkBoxAlwaysNewest.Location = new System.Drawing.Point(503, 32);
            this.VisualChkBoxAlwaysNewest.Name = "VisualChkBoxAlwaysNewest";
            this.VisualChkBoxAlwaysNewest.Size = new System.Drawing.Size(141, 17);
            this.VisualChkBoxAlwaysNewest.TabIndex = 2;
            this.VisualChkBoxAlwaysNewest.Text = "Always the newest Entry";
            this.VisualChkBoxAlwaysNewest.UseVisualStyleBackColor = true;
            this.VisualChkBoxAlwaysNewest.CheckedChanged += new System.EventHandler(this.VisualChkBoxAlwaysNewest_CheckedChanged);
            // 
            // VisualScrollBar
            // 
            this.VisualScrollBar.Location = new System.Drawing.Point(73, 151);
            this.VisualScrollBar.Maximum = 1000;
            this.VisualScrollBar.Name = "VisualScrollBar";
            this.VisualScrollBar.Size = new System.Drawing.Size(584, 13);
            this.VisualScrollBar.TabIndex = 1;
            this.VisualScrollBar.Value = 1;
            this.VisualScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.VisualScrollBar_Scroll);
            // 
            // btnStartClient
            // 
            this.btnStartClient.Location = new System.Drawing.Point(503, 3);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Size = new System.Drawing.Size(141, 23);
            this.btnStartClient.TabIndex = 0;
            this.btnStartClient.Text = "Start Visualisation";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // AnrlClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 456);
            this.Controls.Add(this.panelStarterPanel);
            this.Controls.Add(this.panelRace);
            this.Controls.Add(this.panelTrackerPilot);
            this.Controls.Add(this.panelConnection);
            this.Name = "AnrlClient";
            this.Text = "AnrlClient";
            this.panelConnection.ResumeLayout(false);
            this.panelConnection.PerformLayout();
            this.panelTrackerPilot.ResumeLayout(false);
            this.panelRace.ResumeLayout(false);
            this.panelRace.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldRaceDuration)).EndInit();
            this.panelStarterPanel.ResumeLayout(false);
            this.panelStarterPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualPlaySpeed)).EndInit();
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
        private System.Windows.Forms.Panel panelRace;
        private System.Windows.Forms.ListView lstRace;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnRemvRace;
        private System.Windows.Forms.Button btnNewRace;
        private System.Windows.Forms.Label lblRace;
        protected System.Windows.Forms.TextBox fldRaceName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker fldRaceDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.DateTimePicker fldRaceTime;
        private System.Windows.Forms.Button btnSaveRace;
        private System.Windows.Forms.Label lblRaceDuration;
        private System.Windows.Forms.NumericUpDown fldRaceDuration;
        private System.Windows.Forms.TextBox fldRacePilotD;
        private System.Windows.Forms.TextBox fldRacePilotC;
        private System.Windows.Forms.TextBox fldRacePilotB;
        private System.Windows.Forms.TextBox fldRacePilotA;
        private System.Windows.Forms.Label lblPilotB;
        private System.Windows.Forms.Label lblPilotC;
        private System.Windows.Forms.Label lblPilotD;
        private System.Windows.Forms.Label lblPilotA;
        private System.Windows.Forms.Button btnRacePilotD;
        private System.Windows.Forms.Button btnRacePilotC;
        private System.Windows.Forms.Button btnRacePilotB;
        private System.Windows.Forms.Button btnRacePilotA;
        private System.Windows.Forms.Button btnRacesRefresh;
        private System.Windows.Forms.TextBox fldRacePolygonsLoaded;
        private System.Windows.Forms.Label lblPolygons;
        private System.Windows.Forms.Button btnSelectParcour;
        private System.Windows.Forms.TextBox fldRaceParcour;
        private System.Windows.Forms.Label lblParcour;
        private System.Windows.Forms.Panel panelStarterPanel;
        private System.Windows.Forms.Button btnStartClient;
        private System.Windows.Forms.Button btnShowRanking;
        private System.Windows.Forms.HScrollBar VisualScrollBar;
        private System.Windows.Forms.Label lblVisualPlaySpeed;
        private System.Windows.Forms.NumericUpDown fldVisualPlaySpeed;
        private System.Windows.Forms.Button btnVisualLoadOlder;
        private System.Windows.Forms.Label lblVisualRacesToShow;
        private System.Windows.Forms.Label lblPilotsToShow;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckedListBox lstVisualPilotsToShow;
        private System.Windows.Forms.CheckedListBox lstVisualRacesToShow;
        private System.Windows.Forms.CheckBox VisualChkBoxAlwaysNewest;
    }
}