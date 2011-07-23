namespace ANR
{
    partial class GroupCompetitorSelection
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
            this.cmdApplyRankList = new System.Windows.Forms.Button();
            this.dataGridCompetitors = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRaceResults = new System.Windows.Forms.ComboBox();
            this.cmdSubmit = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdReset = new System.Windows.Forms.Button();
            this.selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompetitionNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AcCallsign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PilotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PilotFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NavigatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NavigatorFirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdApplyRankList
            // 
            this.cmdApplyRankList.Location = new System.Drawing.Point(486, 8);
            this.cmdApplyRankList.Name = "cmdApplyRankList";
            this.cmdApplyRankList.Size = new System.Drawing.Size(75, 23);
            this.cmdApplyRankList.TabIndex = 0;
            this.cmdApplyRankList.Text = "Apply";
            this.cmdApplyRankList.UseVisualStyleBackColor = true;
            this.cmdApplyRankList.Click += new System.EventHandler(this.cmdApplyRankList_Click);
            // 
            // dataGridCompetitors
            // 
            this.dataGridCompetitors.AllowUserToAddRows = false;
            this.dataGridCompetitors.AllowUserToDeleteRows = false;
            this.dataGridCompetitors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCompetitors.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCompetitors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selected,
            this.rank,
            this.CompetitionNo,
            this.AcCallsign,
            this.PilotName,
            this.PilotFirstname,
            this.NavigatorName,
            this.NavigatorFirstname,
            this.Country});
            this.dataGridCompetitors.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridCompetitors.Location = new System.Drawing.Point(12, 37);
            this.dataGridCompetitors.MultiSelect = false;
            this.dataGridCompetitors.Name = "dataGridCompetitors";
            this.dataGridCompetitors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCompetitors.Size = new System.Drawing.Size(768, 550);
            this.dataGridCompetitors.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display Competitors by Result of Race:";
            // 
            // cmbRaceResults
            // 
            this.cmbRaceResults.FormattingEnabled = true;
            this.cmbRaceResults.Location = new System.Drawing.Point(209, 10);
            this.cmbRaceResults.Name = "cmbRaceResults";
            this.cmbRaceResults.Size = new System.Drawing.Size(271, 21);
            this.cmbRaceResults.TabIndex = 3;
            // 
            // cmdSubmit
            // 
            this.cmdSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSubmit.Location = new System.Drawing.Point(705, 593);
            this.cmdSubmit.Name = "cmdSubmit";
            this.cmdSubmit.Size = new System.Drawing.Size(75, 23);
            this.cmdSubmit.TabIndex = 4;
            this.cmdSubmit.Text = "Save";
            this.cmdSubmit.UseVisualStyleBackColor = true;
            this.cmdSubmit.Click += new System.EventHandler(this.cmdSubmit_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.Location = new System.Drawing.Point(624, 593);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdReset
            // 
            this.cmdReset.Location = new System.Drawing.Point(567, 8);
            this.cmdReset.Name = "cmdReset";
            this.cmdReset.Size = new System.Drawing.Size(75, 23);
            this.cmdReset.TabIndex = 6;
            this.cmdReset.Text = "Reset";
            this.cmdReset.UseVisualStyleBackColor = true;
            this.cmdReset.Click += new System.EventHandler(this.cmdReset_Click);
            // 
            // selected
            // 
            this.selected.HeaderText = "Selected";
            this.selected.Name = "selected";
            // 
            // rank
            // 
            this.rank.HeaderText = "Rank";
            this.rank.Name = "rank";
            this.rank.ReadOnly = true;
            this.rank.Visible = false;
            // 
            // CompetitionNo
            // 
            this.CompetitionNo.HeaderText = "Competition Number";
            this.CompetitionNo.Name = "CompetitionNo";
            this.CompetitionNo.ReadOnly = true;
            // 
            // AcCallsign
            // 
            this.AcCallsign.HeaderText = "AC Callsign";
            this.AcCallsign.Name = "AcCallsign";
            this.AcCallsign.ReadOnly = true;
            // 
            // PilotName
            // 
            this.PilotName.HeaderText = "Pilot Name";
            this.PilotName.Name = "PilotName";
            this.PilotName.ReadOnly = true;
            // 
            // PilotFirstname
            // 
            this.PilotFirstname.HeaderText = "Pilot Firstname";
            this.PilotFirstname.Name = "PilotFirstname";
            this.PilotFirstname.ReadOnly = true;
            // 
            // NavigatorName
            // 
            this.NavigatorName.HeaderText = "Navigator Name";
            this.NavigatorName.Name = "NavigatorName";
            this.NavigatorName.ReadOnly = true;
            // 
            // NavigatorFirstname
            // 
            this.NavigatorFirstname.HeaderText = "Navigator Firstname";
            this.NavigatorFirstname.Name = "NavigatorFirstname";
            this.NavigatorFirstname.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // GroupCompetitorSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 618);
            this.Controls.Add(this.cmdReset);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdSubmit);
            this.Controls.Add(this.cmbRaceResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridCompetitors);
            this.Controls.Add(this.cmdApplyRankList);
            this.Name = "GroupCompetitorSelection";
            this.Text = "GroupCompetitorSelection";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdApplyRankList;
        private System.Windows.Forms.DataGridView dataGridCompetitors;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRaceResults;
        private System.Windows.Forms.Button cmdSubmit;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdReset;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompetitionNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AcCallsign;
        private System.Windows.Forms.DataGridViewTextBoxColumn PilotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PilotFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn NavigatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NavigatorFirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
    }
}