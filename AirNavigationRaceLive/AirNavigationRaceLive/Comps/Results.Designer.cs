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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.listViewPenalty = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.fldTotalPoints = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPenaltyID = new System.Windows.Forms.TextBox();
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.visualisationPictureBox1 = new AirNavigationRaceLive.Comps.VisualisationPictureBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
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
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "Competition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 20);
            this.label2.TabIndex = 99;
            this.label2.Text = "Team";
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.Enabled = false;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(103, 35);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(161, 21);
            this.comboBoxTeam.TabIndex = 98;
            this.comboBoxTeam.SelectedIndexChanged += new System.EventHandler(this.comboBoxTeam_SelectedIndexChanged);
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
            this.listViewPenalty.Location = new System.Drawing.Point(270, 3);
            this.listViewPenalty.Name = "listViewPenalty";
            this.listViewPenalty.Size = new System.Drawing.Size(651, 154);
            this.listViewPenalty.TabIndex = 100;
            this.listViewPenalty.UseCompatibleStateImageBehavior = false;
            this.listViewPenalty.View = System.Windows.Forms.View.Details;
            this.listViewPenalty.SelectedIndexChanged += new System.EventHandler(this.listViewPenalty_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 30;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "Total";
            // 
            // fldTotalPoints
            // 
            this.fldTotalPoints.Location = new System.Drawing.Point(103, 78);
            this.fldTotalPoints.Name = "fldTotalPoints";
            this.fldTotalPoints.ReadOnly = true;
            this.fldTotalPoints.Size = new System.Drawing.Size(161, 20);
            this.fldTotalPoints.TabIndex = 102;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 103;
            this.label4.Text = "ID";
            // 
            // textBoxPenaltyID
            // 
            this.textBoxPenaltyID.Location = new System.Drawing.Point(103, 163);
            this.textBoxPenaltyID.Name = "textBoxPenaltyID";
            this.textBoxPenaltyID.ReadOnly = true;
            this.textBoxPenaltyID.Size = new System.Drawing.Size(161, 20);
            this.textBoxPenaltyID.TabIndex = 104;
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.Location = new System.Drawing.Point(103, 189);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.Size = new System.Drawing.Size(161, 20);
            this.textBoxPoints.TabIndex = 106;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 105;
            this.label5.Text = "Points";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Location = new System.Drawing.Point(103, 215);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(161, 103);
            this.textBoxReason.TabIndex = 108;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 107;
            this.label6.Text = "Reason";
            // 
            // visualisationPictureBox1
            // 
            this.visualisationPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.visualisationPictureBox1.Location = new System.Drawing.Point(270, 163);
            this.visualisationPictureBox1.Name = "visualisationPictureBox1";
            this.visualisationPictureBox1.Size = new System.Drawing.Size(651, 376);
            this.visualisationPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.visualisationPictureBox1.TabIndex = 97;
            this.visualisationPictureBox1.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(103, 134);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(161, 23);
            this.btnNew.TabIndex = 109;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(103, 324);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 23);
            this.btnAdd.TabIndex = 110;
            this.btnAdd.Text = "Add to List";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(103, 353);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(161, 23);
            this.btnDelete.TabIndex = 111;
            this.btnDelete.Text = "Delete from List";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(103, 382);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(161, 23);
            this.btnSubmit.TabIndex = 112;
            this.btnSubmit.Text = "Save List to Server";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Controls.Add(this.fldTotalPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewPenalty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.visualisationPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCompetition);
            this.Name = "Results";
            this.Size = new System.Drawing.Size(924, 542);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.ListView listViewPenalty;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fldTotalPoints;
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
    }
}
