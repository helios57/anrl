namespace AirNavigationRaceLive.Comps
{
    partial class Results
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
            this.comboBoxCompetition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewPenalty = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPenaltyID = new System.Windows.Forms.TextBox();
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnPdf = new System.Windows.Forms.Button();
            this.listViewCompetitionTeam = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnUpload = new System.Windows.Forms.Button();
            this.visualisationPictureBox1 = new AirNavigationRaceLive.Comps.VisualisationPictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportToplist = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCompetition
            // 
            this.comboBoxCompetition.FormattingEnabled = true;
            this.comboBoxCompetition.Location = new System.Drawing.Point(103, 3);
            this.comboBoxCompetition.Name = "comboBoxCompetition";
            this.comboBoxCompetition.Size = new System.Drawing.Size(161, 21);
            this.comboBoxCompetition.TabIndex = 95;
            this.comboBoxCompetition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "Q-Round";
            // 
            // listViewPenalty
            // 
            this.listViewPenalty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewPenalty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewPenalty.FullRowSelect = true;
            this.listViewPenalty.GridLines = true;
            this.listViewPenalty.HideSelection = false;
            this.listViewPenalty.Location = new System.Drawing.Point(270, 29);
            this.listViewPenalty.Name = "listViewPenalty";
            this.listViewPenalty.Size = new System.Drawing.Size(651, 171);
            this.listViewPenalty.TabIndex = 100;
            this.listViewPenalty.UseCompatibleStateImageBehavior = false;
            this.listViewPenalty.View = System.Windows.Forms.View.Details;
            this.listViewPenalty.SelectedIndexChanged += new System.EventHandler(this.listViewPenalty_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 31;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Points";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Reason";
            this.columnHeader3.Width = 555;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "ID";
            // 
            // textBoxPenaltyID
            // 
            this.textBoxPenaltyID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPenaltyID.Location = new System.Drawing.Point(103, 235);
            this.textBoxPenaltyID.Name = "textBoxPenaltyID";
            this.textBoxPenaltyID.ReadOnly = true;
            this.textBoxPenaltyID.Size = new System.Drawing.Size(161, 20);
            this.textBoxPenaltyID.TabIndex = 104;
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxPoints.Location = new System.Drawing.Point(103, 261);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.Size = new System.Drawing.Size(161, 20);
            this.textBoxPoints.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Points";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxReason.Location = new System.Drawing.Point(103, 287);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(161, 103);
            this.textBoxReason.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "Reason";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(103, 206);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(161, 23);
            this.btnNew.TabIndex = 109;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(103, 396);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 23);
            this.btnAdd.TabIndex = 110;
            this.btnAdd.Text = "Add / Save";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(103, 425);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(161, 23);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "Delete from List";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubmit.Location = new System.Drawing.Point(103, 454);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(161, 23);
            this.btnSubmit.TabIndex = 112;
            this.btnSubmit.Text = "Save List to Server";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnPdf
            // 
            this.btnPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPdf.Location = new System.Drawing.Point(103, 483);
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.Size = new System.Drawing.Size(161, 23);
            this.btnPdf.TabIndex = 113;
            this.btnPdf.Text = "Export Results to PDF";
            this.btnPdf.UseVisualStyleBackColor = true;
            this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // listViewCompetitionTeam
            // 
            this.listViewCompetitionTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewCompetitionTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.listViewCompetitionTeam.Location = new System.Drawing.Point(7, 29);
            this.listViewCompetitionTeam.MultiSelect = false;
            this.listViewCompetitionTeam.Name = "listViewCompetitionTeam";
            this.listViewCompetitionTeam.Size = new System.Drawing.Size(261, 141);
            this.listViewCompetitionTeam.TabIndex = 114;
            this.listViewCompetitionTeam.UseCompatibleStateImageBehavior = false;
            this.listViewCompetitionTeam.View = System.Windows.Forms.View.Details;
            this.listViewCompetitionTeam.SelectedIndexChanged += new System.EventHandler(this.listViewCompetitionTeam_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Start ID";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Points";
            this.columnHeader9.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Team";
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
            // btnUpload
            // 
            this.btnUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpload.Enabled = false;
            this.btnUpload.Location = new System.Drawing.Point(103, 176);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(161, 23);
            this.btnUpload.TabIndex = 115;
            this.btnUpload.Text = "Upload GAC-File";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // visualisationPictureBox1
            // 
            this.visualisationPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.visualisationPictureBox1.Location = new System.Drawing.Point(270, 206);
            this.visualisationPictureBox1.Name = "visualisationPictureBox1";
            this.visualisationPictureBox1.Size = new System.Drawing.Size(651, 328);
            this.visualisationPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.visualisationPictureBox1.TabIndex = 97;
            this.visualisationPictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(270, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 23);
            this.btnRefresh.TabIndex = 116;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportToplist
            // 
            this.btnExportToplist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToplist.Location = new System.Drawing.Point(103, 511);
            this.btnExportToplist.Name = "btnExportToplist";
            this.btnExportToplist.Size = new System.Drawing.Size(161, 23);
            this.btnExportToplist.TabIndex = 117;
            this.btnExportToplist.Text = "Export Toplist to PDF";
            this.btnExportToplist.UseVisualStyleBackColor = true;
            this.btnExportToplist.Click += new System.EventHandler(this.btnExportToplist_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportToplist);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.listViewCompetitionTeam);
            this.Controls.Add(this.btnPdf);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.textBoxReason);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPoints);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPenaltyID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewPenalty);
            this.Controls.Add(this.visualisationPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCompetition);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(924, 537);
            this.Load += new System.EventHandler(this.Visualisation_Load);
            this.VisibleChanged += new System.EventHandler(this.Visualisation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCompetition;
        private System.Windows.Forms.Label label1;
        private VisualisationPictureBox visualisationPictureBox1;
        private System.Windows.Forms.ListView listViewPenalty;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPenaltyID;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnPdf;
        private System.Windows.Forms.ListView listViewCompetitionTeam;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportToplist;
    }
}
