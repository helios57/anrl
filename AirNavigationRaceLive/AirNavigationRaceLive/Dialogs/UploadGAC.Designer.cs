namespace AirNavigationRaceLive.Dialogs
{
    partial class UploadGAC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadGAC));
            this.btnUploadData = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPositions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateGAC = new System.Windows.Forms.DateTimePicker();
            this.btnImportGAC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUploadData
            // 
            this.btnUploadData.Location = new System.Drawing.Point(113, 87);
            this.btnUploadData.Name = "btnUploadData";
            this.btnUploadData.Size = new System.Drawing.Size(149, 23);
            this.btnUploadData.TabIndex = 22;
            this.btnUploadData.Text = "Upload Positions";
            this.btnUploadData.UseVisualStyleBackColor = true;
            this.btnUploadData.Click += new System.EventHandler(this.btnUploadData_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "GAC - Date";
            // 
            // textBoxPositions
            // 
            this.textBoxPositions.Enabled = false;
            this.textBoxPositions.Location = new System.Drawing.Point(113, 61);
            this.textBoxPositions.Name = "textBoxPositions";
            this.textBoxPositions.ReadOnly = true;
            this.textBoxPositions.Size = new System.Drawing.Size(149, 20);
            this.textBoxPositions.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Imported Positions";
            // 
            // dateGAC
            // 
            this.dateGAC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateGAC.Location = new System.Drawing.Point(113, 8);
            this.dateGAC.Name = "dateGAC";
            this.dateGAC.Size = new System.Drawing.Size(149, 20);
            this.dateGAC.TabIndex = 18;
            // 
            // btnImportGAC
            // 
            this.btnImportGAC.Location = new System.Drawing.Point(113, 32);
            this.btnImportGAC.Name = "btnImportGAC";
            this.btnImportGAC.Size = new System.Drawing.Size(149, 23);
            this.btnImportGAC.TabIndex = 17;
            this.btnImportGAC.Text = "Import GAC";
            this.btnImportGAC.UseVisualStyleBackColor = true;
            this.btnImportGAC.Click += new System.EventHandler(this.btnImportGAC_Click);
            // 
            // UploadGAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 116);
            this.Controls.Add(this.btnUploadData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPositions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateGAC);
            this.Controls.Add(this.btnImportGAC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadGAC";
            this.Text = "UploadGAC";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUploadData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPositions;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateGAC;
        private System.Windows.Forms.Button btnImportGAC;
    }
}