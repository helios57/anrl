namespace AirNavigationRaceLive.Comps
{
    partial class QualificationRound
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
            this.btnDeleteCompetitions = new System.Windows.Forms.Button();
            this.btnRefreshCompetitions = new System.Windows.Forms.Button();
            this.listViewCompetition = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitel = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.timeTakeOff = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.parcours = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.takeOffLeftLongitude = new System.Windows.Forms.TextBox();
            this.takeOffLeftLatitude = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.takeOffRightLatitude = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.takeOffRightLongitude = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.listViewCompetitionTeam = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleteCompetitionTeam = new System.Windows.Forms.Button();
            this.btnNewCompetitionTeam = new System.Windows.Forms.Button();
            this.textBoxStartId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxRoute = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnSaveCompetitionTeam = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.listViewTrackers = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExportToPDF = new System.Windows.Forms.Button();
            this.timeTakeOffIntervall = new System.Windows.Forms.DateTimePicker();
            this.timeParcourIntervall = new System.Windows.Forms.DateTimePicker();
            this.timeParcourLength = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.timeTakeOffStartgate = new System.Windows.Forms.DateTimePicker();
            this.btnAddCompetitionTeam = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDeleteCompetitions
            // 
            this.btnDeleteCompetitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteCompetitions.Location = new System.Drawing.Point(3, 514);
            this.btnDeleteCompetitions.Name = "btnDeleteCompetitions";
            this.btnDeleteCompetitions.Size = new System.Drawing.Size(255, 28);
            this.btnDeleteCompetitions.TabIndex = 5;
            this.btnDeleteCompetitions.Text = "Delete";
            this.btnDeleteCompetitions.UseVisualStyleBackColor = true;
            this.btnDeleteCompetitions.Click += new System.EventHandler(this.btnDeleteCompetitions_Click);
            // 
            // btnRefreshCompetitions
            // 
            this.btnRefreshCompetitions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshCompetitions.Location = new System.Drawing.Point(3, 479);
            this.btnRefreshCompetitions.Name = "btnRefreshCompetitions";
            this.btnRefreshCompetitions.Size = new System.Drawing.Size(255, 29);
            this.btnRefreshCompetitions.TabIndex = 4;
            this.btnRefreshCompetitions.Text = "Refresh";
            this.btnRefreshCompetitions.UseVisualStyleBackColor = true;
            this.btnRefreshCompetitions.Click += new System.EventHandler(this.btnRefreshCompetitions_Click);
            // 
            // listViewCompetition
            // 
            this.listViewCompetition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewCompetition.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewCompetition.FullRowSelect = true;
            this.listViewCompetition.GridLines = true;
            this.listViewCompetition.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCompetition.HideSelection = false;
            this.listViewCompetition.Location = new System.Drawing.Point(3, 3);
            this.listViewCompetition.MultiSelect = false;
            this.listViewCompetition.Name = "listViewCompetition";
            this.listViewCompetition.Size = new System.Drawing.Size(255, 470);
            this.listViewCompetition.TabIndex = 3;
            this.listViewCompetition.UseCompatibleStateImageBehavior = false;
            this.listViewCompetition.View = System.Windows.Forms.View.Details;
            this.listViewCompetition.SelectedIndexChanged += new System.EventHandler(this.listViewCompetition_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 210;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(264, 3);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(343, 33);
            this.lblTitel.TabIndex = 26;
            this.lblTitel.Text = "Qualification Rounds for: ";
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(327, 113);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(140, 20);
            this.textName.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Name";
            // 
            // textID
            // 
            this.textID.Enabled = false;
            this.textID.Location = new System.Drawing.Point(327, 87);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(140, 20);
            this.textID.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(267, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "ID";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(433, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Date (all UTC)";
            // 
            // date
            // 
            this.date.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(436, 395);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(73, 20);
            this.date.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(512, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Take Off";
            // 
            // timeTakeOff
            // 
            this.timeTakeOff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTakeOff.CustomFormat = "HH:mm";
            this.timeTakeOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeTakeOff.Location = new System.Drawing.Point(515, 395);
            this.timeTakeOff.Name = "timeTakeOff";
            this.timeTakeOff.ShowUpDown = true;
            this.timeTakeOff.Size = new System.Drawing.Size(50, 20);
            this.timeTakeOff.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Parcour";
            // 
            // parcours
            // 
            this.parcours.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.parcours.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.parcours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.parcours.FormattingEnabled = true;
            this.parcours.Location = new System.Drawing.Point(327, 139);
            this.parcours.Name = "parcours";
            this.parcours.Size = new System.Drawing.Size(140, 21);
            this.parcours.TabIndex = 40;
            this.parcours.SelectedIndexChanged += new System.EventHandler(this.parcours_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(264, 56);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(203, 25);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "New Qualification Round";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(475, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Take Off Line in WGS84";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(475, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Left Point Longitude";
            // 
            // takeOffLeftLongitude
            // 
            this.takeOffLeftLongitude.Location = new System.Drawing.Point(583, 90);
            this.takeOffLeftLongitude.Name = "takeOffLeftLongitude";
            this.takeOffLeftLongitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffLeftLongitude.TabIndex = 44;
            this.takeOffLeftLongitude.TextChanged += new System.EventHandler(this.takeOffLeftLongitude_TextChanged);
            // 
            // takeOffLeftLatitude
            // 
            this.takeOffLeftLatitude.Location = new System.Drawing.Point(583, 115);
            this.takeOffLeftLatitude.Name = "takeOffLeftLatitude";
            this.takeOffLeftLatitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffLeftLatitude.TabIndex = 46;
            this.takeOffLeftLatitude.TextChanged += new System.EventHandler(this.takeOffLeftLatitude_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(475, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Left Point Latitude";
            // 
            // takeOffRightLatitude
            // 
            this.takeOffRightLatitude.Location = new System.Drawing.Point(583, 167);
            this.takeOffRightLatitude.Name = "takeOffRightLatitude";
            this.takeOffRightLatitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffRightLatitude.TabIndex = 50;
            this.takeOffRightLatitude.TextChanged += new System.EventHandler(this.takeOffRightLatitude_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(475, 170);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Right Point Latitude";
            // 
            // takeOffRightLongitude
            // 
            this.takeOffRightLongitude.Location = new System.Drawing.Point(583, 142);
            this.takeOffRightLongitude.Name = "takeOffRightLongitude";
            this.takeOffRightLongitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffRightLongitude.TabIndex = 48;
            this.takeOffRightLongitude.TextChanged += new System.EventHandler(this.takeOffRightLongitude_TextChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(475, 145);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Right Point Longitude";
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(605, 64);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(76, 21);
            this.btnCalc.TabIndex = 51;
            this.btnCalc.Text = "Calculator";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // listViewCompetitionTeam
            // 
            this.listViewCompetitionTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCompetitionTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader9,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader10});
            this.listViewCompetitionTeam.FullRowSelect = true;
            this.listViewCompetitionTeam.GridLines = true;
            this.listViewCompetitionTeam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewCompetitionTeam.HideSelection = false;
            this.listViewCompetitionTeam.Location = new System.Drawing.Point(264, 193);
            this.listViewCompetitionTeam.MultiSelect = false;
            this.listViewCompetitionTeam.Name = "listViewCompetitionTeam";
            this.listViewCompetitionTeam.Size = new System.Drawing.Size(602, 183);
            this.listViewCompetitionTeam.TabIndex = 52;
            this.listViewCompetitionTeam.UseCompatibleStateImageBehavior = false;
            this.listViewCompetitionTeam.View = System.Windows.Forms.View.Details;
            this.listViewCompetitionTeam.SelectedIndexChanged += new System.EventHandler(this.listViewCompetitionTeam_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start ID";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID_Crew";
            this.columnHeader4.Width = 58;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "AC";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Crew";
            this.columnHeader5.Width = 207;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Take Off";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Start";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "End";
            this.columnHeader8.Width = 51;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Route";
            this.columnHeader10.Width = 48;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(264, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(245, 28);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save Qualification Round";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleteCompetitionTeam
            // 
            this.btnDeleteCompetitionTeam.Location = new System.Drawing.Point(308, 420);
            this.btnDeleteCompetitionTeam.Name = "btnDeleteCompetitionTeam";
            this.btnDeleteCompetitionTeam.Size = new System.Drawing.Size(48, 28);
            this.btnDeleteCompetitionTeam.TabIndex = 56;
            this.btnDeleteCompetitionTeam.Text = "Delete";
            this.btnDeleteCompetitionTeam.UseVisualStyleBackColor = true;
            this.btnDeleteCompetitionTeam.Click += new System.EventHandler(this.btnDeleteCompetitionTeam_Click);
            // 
            // btnNewCompetitionTeam
            // 
            this.btnNewCompetitionTeam.Location = new System.Drawing.Point(264, 420);
            this.btnNewCompetitionTeam.Name = "btnNewCompetitionTeam";
            this.btnNewCompetitionTeam.Size = new System.Drawing.Size(38, 28);
            this.btnNewCompetitionTeam.TabIndex = 57;
            this.btnNewCompetitionTeam.Text = "New";
            this.btnNewCompetitionTeam.UseVisualStyleBackColor = true;
            this.btnNewCompetitionTeam.Click += new System.EventHandler(this.btnNewCompetitionTeam_Click);
            // 
            // textBoxStartId
            // 
            this.textBoxStartId.Enabled = false;
            this.textBoxStartId.Location = new System.Drawing.Point(264, 394);
            this.textBoxStartId.Name = "textBoxStartId";
            this.textBoxStartId.Size = new System.Drawing.Size(38, 20);
            this.textBoxStartId.TabIndex = 58;
            this.textBoxStartId.TextChanged += new System.EventHandler(this.textBoxStartId_TextChanged);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(264, 379);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "Start ID";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(313, 379);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(31, 13);
            this.label15.TabIndex = 60;
            this.label15.Text = "Crew";
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTeam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTeam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(308, 393);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(119, 21);
            this.comboBoxTeam.TabIndex = 61;
            this.comboBoxTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeam_SelectedIndexChanged);
            // 
            // timeStart
            // 
            this.timeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeStart.CustomFormat = "HH:mm";
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeStart.Location = new System.Drawing.Point(571, 395);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(50, 20);
            this.timeStart.TabIndex = 63;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(568, 379);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 13);
            this.label16.TabIndex = 62;
            this.label16.Text = "Start Gate";
            // 
            // timeEnd
            // 
            this.timeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeEnd.CustomFormat = "HH:mm";
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeEnd.Location = new System.Drawing.Point(627, 395);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(50, 20);
            this.timeEnd.TabIndex = 64;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(624, 379);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 65;
            this.label17.Text = "End Gate";
            // 
            // comboBoxRoute
            // 
            this.comboBoxRoute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRoute.FormattingEnabled = true;
            this.comboBoxRoute.Location = new System.Drawing.Point(683, 393);
            this.comboBoxRoute.Name = "comboBoxRoute";
            this.comboBoxRoute.Size = new System.Drawing.Size(54, 21);
            this.comboBoxRoute.TabIndex = 66;
            this.comboBoxRoute.SelectedIndexChanged += new System.EventHandler(this.comboBoxRoute_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(682, 379);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 67;
            this.label18.Text = "Route";
            // 
            // btnSaveCompetitionTeam
            // 
            this.btnSaveCompetitionTeam.Location = new System.Drawing.Point(362, 420);
            this.btnSaveCompetitionTeam.Name = "btnSaveCompetitionTeam";
            this.btnSaveCompetitionTeam.Size = new System.Drawing.Size(49, 28);
            this.btnSaveCompetitionTeam.TabIndex = 68;
            this.btnSaveCompetitionTeam.Text = "Modify";
            this.btnSaveCompetitionTeam.UseVisualStyleBackColor = true;
            this.btnSaveCompetitionTeam.Click += new System.EventHandler(this.btnSaveCompetitionTeam_Click);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(743, 379);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 13);
            this.label19.TabIndex = 69;
            this.label19.Text = "Tracker(s)";
            // 
            // listViewTrackers
            // 
            this.listViewTrackers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTrackers.CheckBoxes = true;
            this.listViewTrackers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12});
            this.listViewTrackers.FullRowSelect = true;
            this.listViewTrackers.GridLines = true;
            this.listViewTrackers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTrackers.HideSelection = false;
            this.listViewTrackers.Location = new System.Drawing.Point(743, 396);
            this.listViewTrackers.Name = "listViewTrackers";
            this.listViewTrackers.Size = new System.Drawing.Size(123, 152);
            this.listViewTrackers.TabIndex = 70;
            this.listViewTrackers.UseCompatibleStateImageBehavior = false;
            this.listViewTrackers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ID";
            this.columnHeader11.Width = 35;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Name";
            this.columnHeader12.Width = 100;
            // 
            // btnExportToPDF
            // 
            this.btnExportToPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToPDF.Location = new System.Drawing.Point(515, 514);
            this.btnExportToPDF.Name = "btnExportToPDF";
            this.btnExportToPDF.Size = new System.Drawing.Size(222, 28);
            this.btnExportToPDF.TabIndex = 71;
            this.btnExportToPDF.Text = "Export Startlist To PDF";
            this.btnExportToPDF.UseVisualStyleBackColor = true;
            this.btnExportToPDF.Click += new System.EventHandler(this.btnExportToPDF_Click);
            // 
            // timeTakeOffIntervall
            // 
            this.timeTakeOffIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTakeOffIntervall.CustomFormat = "mm";
            this.timeTakeOffIntervall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeTakeOffIntervall.Location = new System.Drawing.Point(151, 3);
            this.timeTakeOffIntervall.Name = "timeTakeOffIntervall";
            this.timeTakeOffIntervall.ShowUpDown = true;
            this.timeTakeOffIntervall.Size = new System.Drawing.Size(49, 20);
            this.timeTakeOffIntervall.TabIndex = 72;
            // 
            // timeParcourIntervall
            // 
            this.timeParcourIntervall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeParcourIntervall.CustomFormat = "mm";
            this.timeParcourIntervall.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeParcourIntervall.Location = new System.Drawing.Point(151, 27);
            this.timeParcourIntervall.Name = "timeParcourIntervall";
            this.timeParcourIntervall.ShowUpDown = true;
            this.timeParcourIntervall.Size = new System.Drawing.Size(49, 20);
            this.timeParcourIntervall.TabIndex = 73;
            // 
            // timeParcourLength
            // 
            this.timeParcourLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeParcourLength.CustomFormat = "mm";
            this.timeParcourLength.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeParcourLength.Location = new System.Drawing.Point(150, 3);
            this.timeParcourLength.Name = "timeParcourLength";
            this.timeParcourLength.ShowUpDown = true;
            this.timeParcourLength.Size = new System.Drawing.Size(50, 20);
            this.timeParcourLength.TabIndex = 74;
            this.timeParcourLength.Value = new System.DateTime(2012, 4, 5, 13, 13, 48, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 75;
            this.label5.Text = "Take Off Intervall";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 76;
            this.label6.Text = "Intervall between Starttime";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Parcour duration";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(118, 13);
            this.label20.TabIndex = 79;
            this.label20.Text = "TakeOff-Startgate-Time";
            // 
            // timeTakeOffStartgate
            // 
            this.timeTakeOffStartgate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTakeOffStartgate.CustomFormat = "mm";
            this.timeTakeOffStartgate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timeTakeOffStartgate.Location = new System.Drawing.Point(150, 25);
            this.timeTakeOffStartgate.Name = "timeTakeOffStartgate";
            this.timeTakeOffStartgate.ShowUpDown = true;
            this.timeTakeOffStartgate.Size = new System.Drawing.Size(50, 20);
            this.timeTakeOffStartgate.TabIndex = 78;
            this.timeTakeOffStartgate.Value = new System.DateTime(2012, 4, 5, 13, 13, 48, 0);
            // 
            // btnAddCompetitionTeam
            // 
            this.btnAddCompetitionTeam.Location = new System.Drawing.Point(417, 420);
            this.btnAddCompetitionTeam.Name = "btnAddCompetitionTeam";
            this.btnAddCompetitionTeam.Size = new System.Drawing.Size(65, 27);
            this.btnAddCompetitionTeam.TabIndex = 80;
            this.btnAddCompetitionTeam.Text = "Add";
            this.btnAddCompetitionTeam.UseVisualStyleBackColor = true;
            this.btnAddCompetitionTeam.Click += new System.EventHandler(this.btnAddCompetitionTeam_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.93578F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.06422F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeTakeOffIntervall, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeParcourIntervall, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(264, 458);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(203, 44);
            this.tableLayoutPanel1.TabIndex = 81;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.35573F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.64427F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.timeParcourLength, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.timeTakeOffStartgate, 1, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(478, 458);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(203, 44);
            this.tableLayoutPanel2.TabIndex = 82;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(490, 428);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(109, 13);
            this.label21.TabIndex = 83;
            this.label21.Text = "The timeunit is minute";
            // 
            // QualificationRound
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label21);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnAddCompetitionTeam);
            this.Controls.Add(this.btnExportToPDF);
            this.Controls.Add(this.listViewTrackers);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnSaveCompetitionTeam);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.comboBoxRoute);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxStartId);
            this.Controls.Add(this.btnNewCompetitionTeam);
            this.Controls.Add(this.btnDeleteCompetitionTeam);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewCompetitionTeam);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.takeOffRightLatitude);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.takeOffRightLongitude);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.takeOffLeftLatitude);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.takeOffLeftLongitude);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.parcours);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.timeTakeOff);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.btnDeleteCompetitions);
            this.Controls.Add(this.btnRefreshCompetitions);
            this.Controls.Add(this.listViewCompetition);
            this.Name = "QualificationRound";
            this.Size = new System.Drawing.Size(869, 548);
            this.Load += new System.EventHandler(this.Competition_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCompetitions;
        private System.Windows.Forms.Button btnRefreshCompetitions;
        private System.Windows.Forms.ListView listViewCompetition;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timeTakeOff;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox parcours;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox takeOffLeftLongitude;
        private System.Windows.Forms.TextBox takeOffLeftLatitude;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox takeOffRightLatitude;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox takeOffRightLongitude;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.ListView listViewCompetitionTeam;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button btnDeleteCompetitionTeam;
        private System.Windows.Forms.Button btnNewCompetitionTeam;
        private System.Windows.Forms.TextBox textBoxStartId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnSaveCompetitionTeam;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListView listViewTrackers;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnExportToPDF;
        private System.Windows.Forms.DateTimePicker timeTakeOffIntervall;
        private System.Windows.Forms.DateTimePicker timeParcourIntervall;
        private System.Windows.Forms.DateTimePicker timeParcourLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DateTimePicker timeTakeOffStartgate;
        private System.Windows.Forms.Button btnAddCompetitionTeam;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label21;


    }
}
