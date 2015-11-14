namespace AirNavigationRaceLive.Comps
{
    partial class TeamControl
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
            this.listViewTeam = new System.Windows.Forms.ListView();
            this.CNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nationality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pilot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Navigator = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.listViewPilots = new System.Windows.Forms.ListView();
            this.Namel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vornamel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxNavigator = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPilot = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.btnAddPilot = new System.Windows.Forms.Button();
            this.btnAddNavigator = new System.Windows.Forms.Button();
            this.btnClearPilot = new System.Windows.Forms.Button();
            this.btnClearNavigator = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnColorSelect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNationality = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.fldAC = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.textBoxCNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewTeam
            // 
            this.listViewTeam.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewTeam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTeam.AutoArrange = false;
            this.listViewTeam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CNumber,
            this.Nationality,
            this.Pilot,
            this.Navigator,
            this.AC,
            this.ColumnColor});
            this.listViewTeam.FullRowSelect = true;
            this.listViewTeam.GridLines = true;
            this.listViewTeam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTeam.LabelWrap = false;
            this.listViewTeam.Location = new System.Drawing.Point(8, 7);
            this.listViewTeam.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listViewTeam.MultiSelect = false;
            this.listViewTeam.Name = "listViewTeam";
            this.listViewTeam.ShowGroups = false;
            this.listViewTeam.Size = new System.Drawing.Size(1761, 665);
            this.listViewTeam.TabIndex = 5;
            this.listViewTeam.UseCompatibleStateImageBehavior = false;
            this.listViewTeam.View = System.Windows.Forms.View.Details;
            this.listViewTeam.SelectedIndexChanged += new System.EventHandler(this.listViewTeam_SelectedIndexChanged);
            // 
            // CNumber
            // 
            this.CNumber.Text = "CNumber";
            this.CNumber.Width = 58;
            // 
            // Nationality
            // 
            this.Nationality.Text = "Nationality";
            this.Nationality.Width = 220;
            // 
            // Pilot
            // 
            this.Pilot.Tag = "Pilot";
            this.Pilot.Text = "Pilot";
            this.Pilot.Width = 131;
            // 
            // Navigator
            // 
            this.Navigator.Tag = "Navigator";
            this.Navigator.Text = "Navigator";
            this.Navigator.Width = 150;
            // 
            // AC
            // 
            this.AC.Text = "AC";
            // 
            // ColumnColor
            // 
            this.ColumnColor.Text = "Color";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(1808, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(651, 55);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // listViewPilots
            // 
            this.listViewPilots.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPilots.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewPilots.AutoArrange = false;
            this.listViewPilots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Namel,
            this.Vornamel});
            this.listViewPilots.FullRowSelect = true;
            this.listViewPilots.GridLines = true;
            this.listViewPilots.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPilots.LabelWrap = false;
            this.listViewPilots.Location = new System.Drawing.Point(8, 692);
            this.listViewPilots.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listViewPilots.MultiSelect = false;
            this.listViewPilots.Name = "listViewPilots";
            this.listViewPilots.ShowGroups = false;
            this.listViewPilots.Size = new System.Drawing.Size(644, 250);
            this.listViewPilots.TabIndex = 7;
            this.listViewPilots.UseCompatibleStateImageBehavior = false;
            this.listViewPilots.View = System.Windows.Forms.View.Details;
            this.listViewPilots.SelectedIndexChanged += new System.EventHandler(this.listViewPilots_SelectedIndexChanged);
            // 
            // Namel
            // 
            this.Namel.Tag = "Namel";
            this.Namel.Text = "Lastname";
            this.Namel.Width = 89;
            // 
            // Vornamel
            // 
            this.Vornamel.Tag = "Vornamel";
            this.Vornamel.Text = "Firstname";
            this.Vornamel.Width = 108;
            // 
            // textBoxNavigator
            // 
            this.textBoxNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNavigator.Enabled = false;
            this.textBoxNavigator.Location = new System.Drawing.Point(1953, 338);
            this.textBoxNavigator.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxNavigator.Name = "textBoxNavigator";
            this.textBoxNavigator.Size = new System.Drawing.Size(324, 38);
            this.textBoxNavigator.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1791, 345);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 32);
            this.label4.TabIndex = 17;
            this.label4.Text = "Navigator";
            // 
            // textBoxPilot
            // 
            this.textBoxPilot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPilot.Enabled = false;
            this.textBoxPilot.Location = new System.Drawing.Point(1953, 276);
            this.textBoxPilot.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxPilot.Name = "textBoxPilot";
            this.textBoxPilot.Size = new System.Drawing.Size(324, 38);
            this.textBoxPilot.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1791, 283);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Pilot";
            // 
            // textBoxID
            // 
            this.textBoxID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(1951, 580);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(324, 38);
            this.textBoxID.TabIndex = 14;
            this.textBoxID.Visible = false;
            // 
            // btnAddPilot
            // 
            this.btnAddPilot.Location = new System.Drawing.Point(675, 692);
            this.btnAddPilot.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddPilot.Name = "btnAddPilot";
            this.btnAddPilot.Size = new System.Drawing.Size(251, 55);
            this.btnAddPilot.TabIndex = 19;
            this.btnAddPilot.Text = "Add Pilot";
            this.btnAddPilot.UseVisualStyleBackColor = true;
            this.btnAddPilot.Click += new System.EventHandler(this.btnAddPilot_Click);
            // 
            // btnAddNavigator
            // 
            this.btnAddNavigator.Location = new System.Drawing.Point(675, 761);
            this.btnAddNavigator.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnAddNavigator.Name = "btnAddNavigator";
            this.btnAddNavigator.Size = new System.Drawing.Size(251, 55);
            this.btnAddNavigator.TabIndex = 19;
            this.btnAddNavigator.Text = "Add Navigator";
            this.btnAddNavigator.UseVisualStyleBackColor = true;
            this.btnAddNavigator.Click += new System.EventHandler(this.btnAddNavigator_Click);
            // 
            // btnClearPilot
            // 
            this.btnClearPilot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearPilot.Location = new System.Drawing.Point(2300, 271);
            this.btnClearPilot.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClearPilot.Name = "btnClearPilot";
            this.btnClearPilot.Size = new System.Drawing.Size(149, 55);
            this.btnClearPilot.TabIndex = 20;
            this.btnClearPilot.Text = "Clear";
            this.btnClearPilot.UseVisualStyleBackColor = true;
            this.btnClearPilot.Click += new System.EventHandler(this.btnClearPilot_Click);
            // 
            // btnClearNavigator
            // 
            this.btnClearNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearNavigator.Location = new System.Drawing.Point(2300, 333);
            this.btnClearNavigator.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnClearNavigator.Name = "btnClearNavigator";
            this.btnClearNavigator.Size = new System.Drawing.Size(149, 55);
            this.btnClearNavigator.TabIndex = 21;
            this.btnClearNavigator.Text = "Clear";
            this.btnClearNavigator.UseVisualStyleBackColor = true;
            this.btnClearNavigator.Click += new System.EventHandler(this.btnClearNavigator_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(2152, 145);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(301, 55);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(1808, 145);
            this.btnNew.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(328, 55);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1791, 474);
            this.label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 32);
            this.label5.TabIndex = 30;
            this.label5.Text = "AC";
            // 
            // btnColorSelect
            // 
            this.btnColorSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColorSelect.Location = new System.Drawing.Point(1953, 400);
            this.btnColorSelect.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnColorSelect.Name = "btnColorSelect";
            this.btnColorSelect.Size = new System.Drawing.Size(323, 55);
            this.btnColorSelect.TabIndex = 31;
            this.btnColorSelect.Text = "Color Select";
            this.btnColorSelect.UseVisualStyleBackColor = true;
            this.btnColorSelect.Click += new System.EventHandler(this.btnColorSelect_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1788, 412);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 32);
            this.label6.TabIndex = 32;
            this.label6.Text = "Color";
            // 
            // textBoxName
            // 
            this.textBoxNationality.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNationality.Enabled = false;
            this.textBoxNationality.Location = new System.Drawing.Point(1953, 528);
            this.textBoxNationality.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxNationality.Name = "textBoxName";
            this.textBoxNationality.Size = new System.Drawing.Size(324, 38);
            this.textBoxNationality.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1791, 536);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 32);
            this.label7.TabIndex = 35;
            this.label7.Text = "Nationality";
            // 
            // fldAC
            // 
            this.fldAC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldAC.Enabled = false;
            this.fldAC.Location = new System.Drawing.Point(1953, 466);
            this.fldAC.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldAC.Name = "fldAC";
            this.fldAC.Size = new System.Drawing.Size(324, 38);
            this.fldAC.TabIndex = 37;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(1808, 76);
            this.btnExport.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(651, 55);
            this.btnExport.TabIndex = 38;
            this.btnExport.Text = "Export Participants To PDF";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // textBoxCNumber
            // 
            this.textBoxCNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCNumber.Location = new System.Drawing.Point(1951, 214);
            this.textBoxCNumber.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxCNumber.Name = "textBoxCNumber";
            this.textBoxCNumber.Size = new System.Drawing.Size(324, 38);
            this.textBoxCNumber.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1788, 221);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 32);
            this.label1.TabIndex = 39;
            this.label1.Text = "CNumber";
            // 
            // TeamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxCNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.fldAC);
            this.Controls.Add(this.textBoxNationality);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnColorSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnClearNavigator);
            this.Controls.Add(this.btnClearPilot);
            this.Controls.Add(this.btnAddNavigator);
            this.Controls.Add(this.btnAddPilot);
            this.Controls.Add(this.textBoxNavigator);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPilot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.listViewPilots);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listViewTeam);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "TeamControl";
            this.Size = new System.Drawing.Size(2467, 954);
            this.Load += new System.EventHandler(this.Team_Load);
            this.VisibleChanged += new System.EventHandler(this.Team_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewTeam;
        private System.Windows.Forms.ColumnHeader Pilot;
        private System.Windows.Forms.ColumnHeader Navigator;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView listViewPilots;
        private System.Windows.Forms.ColumnHeader Namel;
        private System.Windows.Forms.ColumnHeader Vornamel;
        private System.Windows.Forms.TextBox textBoxNavigator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPilot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Button btnAddPilot;
        private System.Windows.Forms.Button btnAddNavigator;
        private System.Windows.Forms.Button btnClearPilot;
        private System.Windows.Forms.Button btnClearNavigator;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnColorSelect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNationality;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader Nationality;
        private System.Windows.Forms.TextBox fldAC;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox textBoxCNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader CNumber;
        private System.Windows.Forms.ColumnHeader AC;
        private System.Windows.Forms.ColumnHeader ColumnColor;
    }
}
