namespace AirNavigationRaceLive.Comps
{
    partial class Competition
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
            this.label7 = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.timeTakeOff = new System.Windows.Forms.DateTimePicker();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
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
            this.listViewSelectedGroup = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listViewGroups = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddToCompetition = new System.Windows.Forms.Button();
            this.btnRefreshGroup = new System.Windows.Forms.Button();
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
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID_Competition";
            this.columnHeader1.Width = 35;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 210;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(264, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 33);
            this.label7.TabIndex = 26;
            this.label7.Text = "Competition";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(327, 113);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(146, 20);
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
            this.textID.Size = new System.Drawing.Size(84, 20);
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
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(267, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Date";
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(327, 139);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(84, 20);
            this.date.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Take Off";
            // 
            // timeTakeOff
            // 
            this.timeTakeOff.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeTakeOff.Location = new System.Drawing.Point(327, 165);
            this.timeTakeOff.Name = "timeTakeOff";
            this.timeTakeOff.ShowUpDown = true;
            this.timeTakeOff.Size = new System.Drawing.Size(84, 20);
            this.timeTakeOff.TabIndex = 34;
            // 
            // timeStart
            // 
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(327, 191);
            this.timeStart.Name = "timeStart";
            this.timeStart.ShowUpDown = true;
            this.timeStart.Size = new System.Drawing.Size(84, 20);
            this.timeStart.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(267, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Start";
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(327, 217);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.ShowUpDown = true;
            this.timeEnd.Size = new System.Drawing.Size(84, 20);
            this.timeEnd.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(267, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "End";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(267, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Parcour";
            // 
            // parcours
            // 
            this.parcours.FormattingEnabled = true;
            this.parcours.Location = new System.Drawing.Point(327, 241);
            this.parcours.Name = "parcours";
            this.parcours.Size = new System.Drawing.Size(146, 21);
            this.parcours.TabIndex = 40;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(264, 56);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(203, 25);
            this.btnNew.TabIndex = 41;
            this.btnNew.Text = "New Competition";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 272);
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
            this.label10.Location = new System.Drawing.Point(267, 291);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(102, 13);
            this.label10.TabIndex = 43;
            this.label10.Text = "Left Point Longitude";
            // 
            // takeOffLeftLongitude
            // 
            this.takeOffLeftLongitude.Location = new System.Drawing.Point(375, 288);
            this.takeOffLeftLongitude.Name = "takeOffLeftLongitude";
            this.takeOffLeftLongitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffLeftLongitude.TabIndex = 44;
            // 
            // takeOffLeftLatitude
            // 
            this.takeOffLeftLatitude.Location = new System.Drawing.Point(375, 313);
            this.takeOffLeftLatitude.Name = "takeOffLeftLatitude";
            this.takeOffLeftLatitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffLeftLatitude.TabIndex = 46;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(267, 316);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Left Point Latitude";
            // 
            // takeOffRightLatitude
            // 
            this.takeOffRightLatitude.Location = new System.Drawing.Point(375, 365);
            this.takeOffRightLatitude.Name = "takeOffRightLatitude";
            this.takeOffRightLatitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffRightLatitude.TabIndex = 50;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(267, 368);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 13);
            this.label12.TabIndex = 49;
            this.label12.Text = "Right Point Latitude";
            // 
            // takeOffRightLongitude
            // 
            this.takeOffRightLongitude.Location = new System.Drawing.Point(375, 340);
            this.takeOffRightLongitude.Name = "takeOffRightLongitude";
            this.takeOffRightLongitude.Size = new System.Drawing.Size(98, 20);
            this.takeOffRightLongitude.TabIndex = 48;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(267, 343);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 47;
            this.label13.Text = "Right Point Longitude";
            // 
            // btnCalc
            // 
            this.btnCalc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCalc.Location = new System.Drawing.Point(397, 264);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(76, 21);
            this.btnCalc.TabIndex = 51;
            this.btnCalc.Text = "Calculator";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // listViewSelectedGroup
            // 
            this.listViewSelectedGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewSelectedGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewSelectedGroup.FullRowSelect = true;
            this.listViewSelectedGroup.GridLines = true;
            this.listViewSelectedGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSelectedGroup.HideSelection = false;
            this.listViewSelectedGroup.Location = new System.Drawing.Point(264, 391);
            this.listViewSelectedGroup.MultiSelect = false;
            this.listViewSelectedGroup.Name = "listViewSelectedGroup";
            this.listViewSelectedGroup.Size = new System.Drawing.Size(388, 117);
            this.listViewSelectedGroup.TabIndex = 52;
            this.listViewSelectedGroup.UseCompatibleStateImageBehavior = false;
            this.listViewSelectedGroup.View = System.Windows.Forms.View.Details;
            this.listViewSelectedGroup.SelectedIndexChanged += new System.EventHandler(this.listViewSelectedGroup_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Position";
            this.columnHeader3.Width = 54;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ID_Group";
            this.columnHeader4.Width = 58;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 267;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(658, 417);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(49, 27);
            this.btnUp.TabIndex = 53;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(658, 450);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(49, 27);
            this.btnDown.TabIndex = 54;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(264, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(203, 28);
            this.btnSave.TabIndex = 55;
            this.btnSave.Text = "Save Competition";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listViewGroups
            // 
            this.listViewGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listViewGroups.FullRowSelect = true;
            this.listViewGroups.GridLines = true;
            this.listViewGroups.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewGroups.HideSelection = false;
            this.listViewGroups.Location = new System.Drawing.Point(531, 3);
            this.listViewGroups.MultiSelect = false;
            this.listViewGroups.Name = "listViewGroups";
            this.listViewGroups.Size = new System.Drawing.Size(212, 312);
            this.listViewGroups.TabIndex = 56;
            this.listViewGroups.UseCompatibleStateImageBehavior = false;
            this.listViewGroups.View = System.Windows.Forms.View.Details;
            this.listViewGroups.SelectedIndexChanged += new System.EventHandler(this.listViewGroups_SelectedIndexChanged);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "ID_Group";
            this.columnHeader7.Width = 58;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Name";
            this.columnHeader8.Width = 150;
            // 
            // btnAddToCompetition
            // 
            this.btnAddToCompetition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddToCompetition.Location = new System.Drawing.Point(531, 321);
            this.btnAddToCompetition.Name = "btnAddToCompetition";
            this.btnAddToCompetition.Size = new System.Drawing.Size(212, 29);
            this.btnAddToCompetition.TabIndex = 57;
            this.btnAddToCompetition.Text = "Add to Competition";
            this.btnAddToCompetition.UseVisualStyleBackColor = true;
            this.btnAddToCompetition.Click += new System.EventHandler(this.btnAddToCompetition_Click);
            // 
            // btnRefreshGroup
            // 
            this.btnRefreshGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshGroup.Location = new System.Drawing.Point(531, 356);
            this.btnRefreshGroup.Name = "btnRefreshGroup";
            this.btnRefreshGroup.Size = new System.Drawing.Size(212, 29);
            this.btnRefreshGroup.TabIndex = 58;
            this.btnRefreshGroup.Text = "Refresh Group List";
            this.btnRefreshGroup.UseVisualStyleBackColor = true;
            this.btnRefreshGroup.Click += new System.EventHandler(this.btnRefreshGroup_Click);
            // 
            // Competition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshGroup);
            this.Controls.Add(this.btnAddToCompetition);
            this.Controls.Add(this.listViewGroups);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.listViewSelectedGroup);
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
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timeTakeOff);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnDeleteCompetitions);
            this.Controls.Add(this.btnRefreshCompetitions);
            this.Controls.Add(this.listViewCompetition);
            this.Name = "Competition";
            this.Size = new System.Drawing.Size(746, 548);
            this.Load += new System.EventHandler(this.Competition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDeleteCompetitions;
        private System.Windows.Forms.Button btnRefreshCompetitions;
        private System.Windows.Forms.ListView listViewCompetition;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker timeTakeOff;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.Label label6;
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
        private System.Windows.Forms.ListView listViewSelectedGroup;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView listViewGroups;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnAddToCompetition;
        private System.Windows.Forms.Button btnRefreshGroup;


    }
}
