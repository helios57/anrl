namespace AirNavigationRaceLive.Comps
{
    partial class Group
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
            this.listViewGroup = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefreshGroup = new System.Windows.Forms.Button();
            this.btnDeleteGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textID = new System.Windows.Forms.TextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTeamA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textTeamB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTeamC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textTeamD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.listViewTeam = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefreshTeam = new System.Windows.Forms.Button();
            this.btnAddSelectedA = new System.Windows.Forms.Button();
            this.btnClearA = new System.Windows.Forms.Button();
            this.btnClearB = new System.Windows.Forms.Button();
            this.btnAddSelectedB = new System.Windows.Forms.Button();
            this.btnClearC = new System.Windows.Forms.Button();
            this.btnAddSelectedC = new System.Windows.Forms.Button();
            this.btnClearD = new System.Windows.Forms.Button();
            this.btnAddSelectedD = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewGroup
            // 
            this.listViewGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewGroup.FullRowSelect = true;
            this.listViewGroup.GridLines = true;
            this.listViewGroup.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewGroup.HideSelection = false;
            this.listViewGroup.Location = new System.Drawing.Point(3, 3);
            this.listViewGroup.MultiSelect = false;
            this.listViewGroup.Name = "listViewGroup";
            this.listViewGroup.Size = new System.Drawing.Size(255, 413);
            this.listViewGroup.TabIndex = 0;
            this.listViewGroup.UseCompatibleStateImageBehavior = false;
            this.listViewGroup.View = System.Windows.Forms.View.Details;
            this.listViewGroup.SelectedIndexChanged += new System.EventHandler(this.listViewGroup_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID_Group";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 189;
            // 
            // btnRefreshGroup
            // 
            this.btnRefreshGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefreshGroup.Location = new System.Drawing.Point(3, 422);
            this.btnRefreshGroup.Name = "btnRefreshGroup";
            this.btnRefreshGroup.Size = new System.Drawing.Size(255, 29);
            this.btnRefreshGroup.TabIndex = 1;
            this.btnRefreshGroup.Text = "Refresh";
            this.btnRefreshGroup.UseVisualStyleBackColor = true;
            this.btnRefreshGroup.Click += new System.EventHandler(this.btnRefreshGroup_Click);
            // 
            // btnDeleteGroup
            // 
            this.btnDeleteGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteGroup.Location = new System.Drawing.Point(3, 457);
            this.btnDeleteGroup.Name = "btnDeleteGroup";
            this.btnDeleteGroup.Size = new System.Drawing.Size(255, 28);
            this.btnDeleteGroup.TabIndex = 2;
            this.btnDeleteGroup.Text = "Delete";
            this.btnDeleteGroup.UseVisualStyleBackColor = true;
            this.btnDeleteGroup.Click += new System.EventHandler(this.btnDeleteGroup_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID";
            // 
            // textID
            // 
            this.textID.Enabled = false;
            this.textID.Location = new System.Drawing.Point(324, 83);
            this.textID.Name = "textID";
            this.textID.Size = new System.Drawing.Size(84, 20);
            this.textID.TabIndex = 4;
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(324, 109);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(146, 20);
            this.textName.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // textTeamA
            // 
            this.textTeamA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTeamA.Location = new System.Drawing.Point(324, 135);
            this.textTeamA.Name = "textTeamA";
            this.textTeamA.ReadOnly = true;
            this.textTeamA.Size = new System.Drawing.Size(146, 20);
            this.textTeamA.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Team A";
            // 
            // textTeamB
            // 
            this.textTeamB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTeamB.Location = new System.Drawing.Point(324, 189);
            this.textTeamB.Name = "textTeamB";
            this.textTeamB.ReadOnly = true;
            this.textTeamB.Size = new System.Drawing.Size(146, 20);
            this.textTeamB.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Team B";
            // 
            // textTeamC
            // 
            this.textTeamC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTeamC.Location = new System.Drawing.Point(324, 244);
            this.textTeamC.Name = "textTeamC";
            this.textTeamC.ReadOnly = true;
            this.textTeamC.Size = new System.Drawing.Size(146, 20);
            this.textTeamC.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Team C";
            // 
            // textTeamD
            // 
            this.textTeamD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textTeamD.Location = new System.Drawing.Point(324, 301);
            this.textTeamD.Name = "textTeamD";
            this.textTeamD.ReadOnly = true;
            this.textTeamD.Size = new System.Drawing.Size(146, 20);
            this.textTeamD.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 304);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Team D";
            // 
            // listViewTeam
            // 
            this.listViewTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.listViewTeam.FullRowSelect = true;
            this.listViewTeam.GridLines = true;
            this.listViewTeam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTeam.HideSelection = false;
            this.listViewTeam.Location = new System.Drawing.Point(476, 3);
            this.listViewTeam.MultiSelect = false;
            this.listViewTeam.Name = "listViewTeam";
            this.listViewTeam.Size = new System.Drawing.Size(267, 448);
            this.listViewTeam.TabIndex = 15;
            this.listViewTeam.UseCompatibleStateImageBehavior = false;
            this.listViewTeam.View = System.Windows.Forms.View.Details;
            this.listViewTeam.SelectedIndexChanged += new System.EventHandler(this.listViewTeam_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "ID_Group";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 198;
            // 
            // btnRefreshTeam
            // 
            this.btnRefreshTeam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshTeam.Location = new System.Drawing.Point(476, 456);
            this.btnRefreshTeam.Name = "btnRefreshTeam";
            this.btnRefreshTeam.Size = new System.Drawing.Size(270, 29);
            this.btnRefreshTeam.TabIndex = 16;
            this.btnRefreshTeam.Text = "Refresh";
            this.btnRefreshTeam.UseVisualStyleBackColor = true;
            this.btnRefreshTeam.Click += new System.EventHandler(this.btnRefreshTeam_Click);
            // 
            // btnAddSelectedA
            // 
            this.btnAddSelectedA.Location = new System.Drawing.Point(324, 161);
            this.btnAddSelectedA.Name = "btnAddSelectedA";
            this.btnAddSelectedA.Size = new System.Drawing.Size(84, 22);
            this.btnAddSelectedA.TabIndex = 17;
            this.btnAddSelectedA.Text = "Add Selected";
            this.btnAddSelectedA.UseVisualStyleBackColor = true;
            this.btnAddSelectedA.Click += new System.EventHandler(this.btnAddSelectedA_Click);
            // 
            // btnClearA
            // 
            this.btnClearA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearA.Location = new System.Drawing.Point(414, 161);
            this.btnClearA.Name = "btnClearA";
            this.btnClearA.Size = new System.Drawing.Size(56, 22);
            this.btnClearA.TabIndex = 18;
            this.btnClearA.Text = "Clear";
            this.btnClearA.UseVisualStyleBackColor = true;
            this.btnClearA.Click += new System.EventHandler(this.btnClearA_Click);
            // 
            // btnClearB
            // 
            this.btnClearB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearB.Location = new System.Drawing.Point(414, 215);
            this.btnClearB.Name = "btnClearB";
            this.btnClearB.Size = new System.Drawing.Size(56, 22);
            this.btnClearB.TabIndex = 20;
            this.btnClearB.Text = "Clear";
            this.btnClearB.UseVisualStyleBackColor = true;
            this.btnClearB.Click += new System.EventHandler(this.btnClearB_Click);
            // 
            // btnAddSelectedB
            // 
            this.btnAddSelectedB.Location = new System.Drawing.Point(324, 215);
            this.btnAddSelectedB.Name = "btnAddSelectedB";
            this.btnAddSelectedB.Size = new System.Drawing.Size(84, 22);
            this.btnAddSelectedB.TabIndex = 19;
            this.btnAddSelectedB.Text = "Add Selected";
            this.btnAddSelectedB.UseVisualStyleBackColor = true;
            this.btnAddSelectedB.Click += new System.EventHandler(this.btnAddSelectedB_Click);
            // 
            // btnClearC
            // 
            this.btnClearC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearC.Location = new System.Drawing.Point(414, 270);
            this.btnClearC.Name = "btnClearC";
            this.btnClearC.Size = new System.Drawing.Size(56, 22);
            this.btnClearC.TabIndex = 22;
            this.btnClearC.Text = "Clear";
            this.btnClearC.UseVisualStyleBackColor = true;
            this.btnClearC.Click += new System.EventHandler(this.btnClearC_Click);
            // 
            // btnAddSelectedC
            // 
            this.btnAddSelectedC.Location = new System.Drawing.Point(324, 270);
            this.btnAddSelectedC.Name = "btnAddSelectedC";
            this.btnAddSelectedC.Size = new System.Drawing.Size(84, 22);
            this.btnAddSelectedC.TabIndex = 21;
            this.btnAddSelectedC.Text = "Add Selected";
            this.btnAddSelectedC.UseVisualStyleBackColor = true;
            this.btnAddSelectedC.Click += new System.EventHandler(this.btnAddSelectedC_Click);
            // 
            // btnClearD
            // 
            this.btnClearD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearD.Location = new System.Drawing.Point(414, 327);
            this.btnClearD.Name = "btnClearD";
            this.btnClearD.Size = new System.Drawing.Size(56, 22);
            this.btnClearD.TabIndex = 24;
            this.btnClearD.Text = "Clear";
            this.btnClearD.UseVisualStyleBackColor = true;
            this.btnClearD.Click += new System.EventHandler(this.btnClearD_Click);
            // 
            // btnAddSelectedD
            // 
            this.btnAddSelectedD.Location = new System.Drawing.Point(324, 327);
            this.btnAddSelectedD.Name = "btnAddSelectedD";
            this.btnAddSelectedD.Size = new System.Drawing.Size(84, 22);
            this.btnAddSelectedD.TabIndex = 23;
            this.btnAddSelectedD.Text = "Add Selected";
            this.btnAddSelectedD.UseVisualStyleBackColor = true;
            this.btnAddSelectedD.Click += new System.EventHandler(this.btnAddSelectedD_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(318, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 33);
            this.label7.TabIndex = 25;
            this.label7.Text = "Groups";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(267, 52);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(203, 25);
            this.btnNew.TabIndex = 26;
            this.btnNew.Text = "New Group";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(267, 355);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(203, 25);
            this.btnSave.TabIndex = 27;
            this.btnSave.Text = "Save Group";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Group
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClearD);
            this.Controls.Add(this.btnAddSelectedD);
            this.Controls.Add(this.btnClearC);
            this.Controls.Add(this.btnAddSelectedC);
            this.Controls.Add(this.btnClearB);
            this.Controls.Add(this.btnAddSelectedB);
            this.Controls.Add(this.btnClearA);
            this.Controls.Add(this.btnAddSelectedA);
            this.Controls.Add(this.btnRefreshTeam);
            this.Controls.Add(this.listViewTeam);
            this.Controls.Add(this.textTeamD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textTeamC);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textTeamB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textTeamA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteGroup);
            this.Controls.Add(this.btnRefreshGroup);
            this.Controls.Add(this.listViewGroup);
            this.Name = "Group";
            this.Size = new System.Drawing.Size(746, 491);
            this.Load += new System.EventHandler(this.Group_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewGroup;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnRefreshGroup;
        private System.Windows.Forms.Button btnDeleteGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTeamA;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textTeamB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textTeamC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textTeamD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listViewTeam;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnRefreshTeam;
        private System.Windows.Forms.Button btnAddSelectedA;
        private System.Windows.Forms.Button btnClearA;
        private System.Windows.Forms.Button btnClearB;
        private System.Windows.Forms.Button btnAddSelectedB;
        private System.Windows.Forms.Button btnClearC;
        private System.Windows.Forms.Button btnAddSelectedC;
        private System.Windows.Forms.Button btnClearD;
        private System.Windows.Forms.Button btnAddSelectedD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;

    }
}
