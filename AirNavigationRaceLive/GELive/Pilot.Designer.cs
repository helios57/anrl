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
            this.lstExistingPilots = new System.Windows.Forms.ListBox();
            this.lblId = new System.Windows.Forms.Label();
            this.fldId = new System.Windows.Forms.TextBox();
            this.btnUsePilot = new System.Windows.Forms.Button();
            this.fldLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.fldSureName = new System.Windows.Forms.TextBox();
            this.lblSureName = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnAddPilot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstExistingPilots
            // 
            this.lstExistingPilots.FormattingEnabled = true;
            this.lstExistingPilots.Location = new System.Drawing.Point(12, 12);
            this.lstExistingPilots.Name = "lstExistingPilots";
            this.lstExistingPilots.Size = new System.Drawing.Size(207, 121);
            this.lstExistingPilots.TabIndex = 0;
            this.lstExistingPilots.SelectedIndexChanged += new System.EventHandler(this.lstExistingPilots_SelectedIndexChanged);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(12, 217);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 1;
            this.lblId.Text = "ID";
            // 
            // fldId
            // 
            this.fldId.Enabled = false;
            this.fldId.Location = new System.Drawing.Point(71, 214);
            this.fldId.Name = "fldId";
            this.fldId.Size = new System.Drawing.Size(100, 20);
            this.fldId.TabIndex = 2;
            // 
            // btnUsePilot
            // 
            this.btnUsePilot.Location = new System.Drawing.Point(12, 141);
            this.btnUsePilot.Name = "btnUsePilot";
            this.btnUsePilot.Size = new System.Drawing.Size(207, 23);
            this.btnUsePilot.TabIndex = 3;
            this.btnUsePilot.Text = "Use Selected Pilot";
            this.btnUsePilot.UseVisualStyleBackColor = true;
            this.btnUsePilot.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // fldLastName
            // 
            this.fldLastName.Location = new System.Drawing.Point(71, 240);
            this.fldLastName.Name = "fldLastName";
            this.fldLastName.Size = new System.Drawing.Size(100, 20);
            this.fldLastName.TabIndex = 5;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 243);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(53, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Lastname";
            // 
            // fldSureName
            // 
            this.fldSureName.Location = new System.Drawing.Point(71, 266);
            this.fldSureName.Name = "fldSureName";
            this.fldSureName.Size = new System.Drawing.Size(100, 20);
            this.fldSureName.TabIndex = 7;
            // 
            // lblSureName
            // 
            this.lblSureName.AutoSize = true;
            this.lblSureName.Location = new System.Drawing.Point(12, 269);
            this.lblSureName.Name = "lblSureName";
            this.lblSureName.Size = new System.Drawing.Size(55, 13);
            this.lblSureName.TabIndex = 6;
            this.lblSureName.Text = "Surename";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(12, 294);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 8;
            this.lblColor.Text = "Color";
            // 
            // btnColor
            // 
            this.btnColor.Location = new System.Drawing.Point(71, 292);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 20);
            this.btnColor.TabIndex = 9;
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnAddPilot
            // 
            this.btnAddPilot.Location = new System.Drawing.Point(15, 318);
            this.btnAddPilot.Name = "btnAddPilot";
            this.btnAddPilot.Size = new System.Drawing.Size(204, 23);
            this.btnAddPilot.TabIndex = 10;
            this.btnAddPilot.Text = "Add new Pilot";
            this.btnAddPilot.UseVisualStyleBackColor = true;
            this.btnAddPilot.Click += new System.EventHandler(this.btnAddPilot_Click);
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 353);
            this.Controls.Add(this.btnAddPilot);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.fldSureName);
            this.Controls.Add(this.lblSureName);
            this.Controls.Add(this.fldLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.btnUsePilot);
            this.Controls.Add(this.fldId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lstExistingPilots);
            this.Name = "Pilot";
            this.Text = "Pilot";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstExistingPilots;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox fldId;
        private System.Windows.Forms.Button btnUsePilot;
        private System.Windows.Forms.TextBox fldLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox fldSureName;
        private System.Windows.Forms.Label lblSureName;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnAddPilot;
    }
}