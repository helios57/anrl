namespace GELive
{
    partial class Pilot
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
            this.lblId = new System.Windows.Forms.Label();
            this.fldId = new System.Windows.Forms.TextBox();
            this.btnUsePilot = new System.Windows.Forms.Button();
            this.fldLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.fldSureName = new System.Windows.Forms.TextBox();
            this.lblSureName = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnSavePilot = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDataGridCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnModiyPilot = new System.Windows.Forms.Button();
            this.btnAddNewPilot = new System.Windows.Forms.Button();
            this.grdVPilotToUse = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CelllHeader1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CellHeaderPicture = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.fldFlagId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdVPilotToUse)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(8, 9);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // fldId
            // 
            this.fldId.Enabled = false;
            this.fldId.Location = new System.Drawing.Point(67, 6);
            this.fldId.Name = "fldId";
            this.fldId.Size = new System.Drawing.Size(100, 20);
            this.fldId.TabIndex = 2;
            // 
            // btnUsePilot
            // 
            this.btnUsePilot.Location = new System.Drawing.Point(8, 270);
            this.btnUsePilot.Name = "btnUsePilot";
            this.btnUsePilot.Size = new System.Drawing.Size(159, 23);
            this.btnUsePilot.TabIndex = 3;
            this.btnUsePilot.Text = "Use Selected Pilot";
            this.btnUsePilot.UseVisualStyleBackColor = true;
            this.btnUsePilot.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // fldLastName
            // 
            this.fldLastName.Location = new System.Drawing.Point(67, 32);
            this.fldLastName.Name = "fldLastName";
            this.fldLastName.Size = new System.Drawing.Size(100, 20);
            this.fldLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(8, 35);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(53, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Lastname";
            // 
            // fldSureName
            // 
            this.fldSureName.Location = new System.Drawing.Point(67, 58);
            this.fldSureName.Name = "fldSureName";
            this.fldSureName.Size = new System.Drawing.Size(100, 20);
            this.fldSureName.TabIndex = 7;
            // 
            // lblSureName
            // 
            this.lblSureName.AutoSize = true;
            this.lblSureName.Location = new System.Drawing.Point(8, 61);
            this.lblSureName.Name = "lblSureName";
            this.lblSureName.Size = new System.Drawing.Size(55, 13);
            this.lblSureName.TabIndex = 6;
            this.lblSureName.Text = "Surename";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(14, 122);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Color";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(67, 120);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(106, 20);
            this.btnColor.TabIndex = 9;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnSavePilot
            // 
            this.btnSavePilot.Location = new System.Drawing.Point(17, 277);
            this.btnSavePilot.Name = "btnSavePilot";
            this.btnSavePilot.Size = new System.Drawing.Size(156, 23);
            this.btnSavePilot.TabIndex = 10;
            this.btnSavePilot.Text = "Save Pilot";
            this.btnSavePilot.UseVisualStyleBackColor = true;
            this.btnSavePilot.Click += new System.EventHandler(this.btnAddPilot_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(67, 171);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(17, 142);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(156, 23);
            this.btnAddPicture.TabIndex = 12;
            this.btnAddPicture.Text = "Add Picture (100x100)";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NameDataGridCol,
            this.Image});
            this.dataGridView1.Location = new System.Drawing.Point(208, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(346, 258);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // NameDataGridCol
            // 
            this.NameDataGridCol.HeaderText = "Name";
            this.NameDataGridCol.Name = "NameDataGridCol";
            this.NameDataGridCol.ReadOnly = true;
            // 
            // Image
            // 
            this.Image.HeaderText = "Flag";
            this.Image.Name = "Image";
            this.Image.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(570, 327);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnModiyPilot);
            this.tabPage1.Controls.Add(this.btnAddNewPilot);
            this.tabPage1.Controls.Add(this.grdVPilotToUse);
            this.tabPage1.Controls.Add(this.btnUsePilot);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(562, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pilot list";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnModiyPilot
            // 
            this.btnModiyPilot.Location = new System.Drawing.Point(334, 270);
            this.btnModiyPilot.Name = "btnModiyPilot";
            this.btnModiyPilot.Size = new System.Drawing.Size(155, 23);
            this.btnModiyPilot.TabIndex = 16;
            this.btnModiyPilot.Text = "Modify Selectet Pilot";
            this.btnModiyPilot.UseVisualStyleBackColor = true;
            this.btnModiyPilot.Click += new System.EventHandler(this.btnModiyPilot_Click);
            // 
            // btnAddNewPilot
            // 
            this.btnAddNewPilot.Location = new System.Drawing.Point(173, 270);
            this.btnAddNewPilot.Name = "btnAddNewPilot";
            this.btnAddNewPilot.Size = new System.Drawing.Size(155, 23);
            this.btnAddNewPilot.TabIndex = 15;
            this.btnAddNewPilot.Text = "Add a new Pilot";
            this.btnAddNewPilot.UseVisualStyleBackColor = true;
            this.btnAddNewPilot.Click += new System.EventHandler(this.btnAddNewPilot_Click);
            // 
            // grdVPilotToUse
            // 
            this.grdVPilotToUse.AllowUserToAddRows = false;
            this.grdVPilotToUse.AllowUserToDeleteRows = false;
            this.grdVPilotToUse.AllowUserToOrderColumns = true;
            this.grdVPilotToUse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdVPilotToUse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdVPilotToUse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.CelllHeader1,
            this.CellHeaderPicture,
            this.dataGridViewImageColumn1});
            this.grdVPilotToUse.Location = new System.Drawing.Point(8, 6);
            this.grdVPilotToUse.Name = "grdVPilotToUse";
            this.grdVPilotToUse.ReadOnly = true;
            this.grdVPilotToUse.Size = new System.Drawing.Size(546, 261);
            this.grdVPilotToUse.TabIndex = 14;
            this.grdVPilotToUse.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVPilotToUse_CellContentClick);
            this.grdVPilotToUse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVPilotToUse_CellContentClick);
            this.grdVPilotToUse.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdVPilotToUse_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // CelllHeader1
            // 
            this.CelllHeader1.HeaderText = "Vorname";
            this.CelllHeader1.Name = "CelllHeader1";
            this.CelllHeader1.ReadOnly = true;
            // 
            // CellHeaderPicture
            // 
            this.CellHeaderPicture.HeaderText = "Picture";
            this.CellHeaderPicture.Name = "CellHeaderPicture";
            this.CellHeaderPicture.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Flag";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.fldFlagId);
            this.tabPage2.Controls.Add(this.fldLastName);
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.lblId);
            this.tabPage2.Controls.Add(this.btnAddPicture);
            this.tabPage2.Controls.Add(this.fldId);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Controls.Add(this.lblLastName);
            this.tabPage2.Controls.Add(this.btnSavePilot);
            this.tabPage2.Controls.Add(this.lblSureName);
            this.tabPage2.Controls.Add(this.btnColor);
            this.tabPage2.Controls.Add(this.fldSureName);
            this.tabPage2.Controls.Add(this.lblColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(562, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pilot Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "FlagId";
            // 
            // fldFlagId
            // 
            this.fldFlagId.Location = new System.Drawing.Point(67, 84);
            this.fldFlagId.Name = "fldFlagId";
            this.fldFlagId.Size = new System.Drawing.Size(100, 20);
            this.fldFlagId.TabIndex = 15;
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 327);
            this.Controls.Add(this.tabControl1);
            this.Name = "Pilot";
            this.Text = "Pilot";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdVPilotToUse)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox fldId;
        private System.Windows.Forms.Button btnUsePilot;
        private System.Windows.Forms.TextBox fldLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox fldSureName;
        private System.Windows.Forms.Label lblSureName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnSavePilot;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDataGridCol;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView grdVPilotToUse;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnModiyPilot;
        private System.Windows.Forms.Button btnAddNewPilot;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CelllHeader1;
        private System.Windows.Forms.DataGridViewImageColumn CellHeaderPicture;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fldFlagId;
    }
}