namespace AirNavigationRaceLive.Comps
{
    partial class ImportExport
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
            this.btnExportKLM = new System.Windows.Forms.Button();
            this.comboBoxQualificationRound = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnSyncExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExportKLM
            // 
            this.btnExportKLM.Location = new System.Drawing.Point(4, 4);
            this.btnExportKLM.Name = "btnExportKLM";
            this.btnExportKLM.Size = new System.Drawing.Size(183, 23);
            this.btnExportKLM.TabIndex = 0;
            this.btnExportKLM.Text = "Export KLM";
            this.btnExportKLM.UseVisualStyleBackColor = true;
            this.btnExportKLM.Click += new System.EventHandler(this.btnExportKLM_Click);
            // 
            // comboBox1
            // 
            this.comboBoxQualificationRound.FormattingEnabled = true;
            this.comboBoxQualificationRound.Location = new System.Drawing.Point(110, 80);
            this.comboBoxQualificationRound.Name = "comboBox1";
            this.comboBoxQualificationRound.Size = new System.Drawing.Size(186, 21);
            this.comboBoxQualificationRound.TabIndex = 1;
            this.comboBoxQualificationRound.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "QualificationRound:";
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Location = new System.Drawing.Point(146, 119);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(150, 23);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnSyncExcel
            // 
            this.btnSyncExcel.Location = new System.Drawing.Point(146, 148);
            this.btnSyncExcel.Name = "btnSyncExcel";
            this.btnSyncExcel.Size = new System.Drawing.Size(150, 23);
            this.btnSyncExcel.TabIndex = 4;
            this.btnSyncExcel.Text = "Syncronize Excel";
            this.btnSyncExcel.UseVisualStyleBackColor = true;
            this.btnSyncExcel.Click += new System.EventHandler(this.btnSyncExcel_Click);
            // 
            // ImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSyncExcel);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxQualificationRound);
            this.Controls.Add(this.btnExportKLM);
            this.Name = "ImportExport";
            this.Size = new System.Drawing.Size(696, 436);
            this.Load += new System.EventHandler(this.ImportExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExportKLM;
        private System.Windows.Forms.ComboBox comboBoxQualificationRound;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnSyncExcel;
    }
}
