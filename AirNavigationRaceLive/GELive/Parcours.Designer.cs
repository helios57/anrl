namespace ANRLClient
{
    partial class Parcours
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
            this.lstParcours = new System.Windows.Forms.ListBox();
            this.btnAddParcour = new System.Windows.Forms.Button();
            this.btnLoadXML = new System.Windows.Forms.Button();
            this.btnLoadDxf = new System.Windows.Forms.Button();
            this.fldNewParcourName = new System.Windows.Forms.TextBox();
            this.lblNewParcourName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstParcours
            // 
            this.lstParcours.FormattingEnabled = true;
            this.lstParcours.Location = new System.Drawing.Point(12, 12);
            this.lstParcours.Name = "lstParcours";
            this.lstParcours.Size = new System.Drawing.Size(250, 121);
            this.lstParcours.TabIndex = 0;
            // 
            // btnAddParcour
            // 
            this.btnAddParcour.Location = new System.Drawing.Point(12, 210);
            this.btnAddParcour.Name = "btnAddParcour";
            this.btnAddParcour.Size = new System.Drawing.Size(250, 23);
            this.btnAddParcour.TabIndex = 1;
            this.btnAddParcour.Text = "Add Selected Parcour";
            this.btnAddParcour.UseVisualStyleBackColor = true;
            this.btnAddParcour.Click += new System.EventHandler(this.btnAddParcour_Click);
            // 
            // btnLoadXML
            // 
            this.btnLoadXML.Enabled = false;
            this.btnLoadXML.Location = new System.Drawing.Point(137, 178);
            this.btnLoadXML.Name = "btnLoadXML";
            this.btnLoadXML.Size = new System.Drawing.Size(125, 26);
            this.btnLoadXML.TabIndex = 54;
            this.btnLoadXML.Text = "Load XML";
            this.btnLoadXML.UseVisualStyleBackColor = true;
            this.btnLoadXML.Click += new System.EventHandler(this.btnLoadXML_Click);
            // 
            // btnLoadDxf
            // 
            this.btnLoadDxf.Location = new System.Drawing.Point(12, 178);
            this.btnLoadDxf.Name = "btnLoadDxf";
            this.btnLoadDxf.Size = new System.Drawing.Size(119, 26);
            this.btnLoadDxf.TabIndex = 53;
            this.btnLoadDxf.Text = "Load DXF";
            this.btnLoadDxf.UseVisualStyleBackColor = true;
            this.btnLoadDxf.Click += new System.EventHandler(this.btnLoadDxf_Click);
            // 
            // fldNewParcourName
            // 
            this.fldNewParcourName.Location = new System.Drawing.Point(137, 139);
            this.fldNewParcourName.Name = "fldNewParcourName";
            this.fldNewParcourName.Size = new System.Drawing.Size(100, 20);
            this.fldNewParcourName.TabIndex = 55;
            // 
            // lblNewParcourName
            // 
            this.lblNewParcourName.AutoSize = true;
            this.lblNewParcourName.Location = new System.Drawing.Point(12, 146);
            this.lblNewParcourName.Name = "lblNewParcourName";
            this.lblNewParcourName.Size = new System.Drawing.Size(100, 13);
            this.lblNewParcourName.TabIndex = 56;
            this.lblNewParcourName.Text = "New Parcour Name";
            // 
            // Parcours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 239);
            this.Controls.Add(this.lblNewParcourName);
            this.Controls.Add(this.fldNewParcourName);
            this.Controls.Add(this.btnLoadXML);
            this.Controls.Add(this.btnLoadDxf);
            this.Controls.Add(this.btnAddParcour);
            this.Controls.Add(this.lstParcours);
            this.Name = "Parcours";
            this.Text = "Parcours";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstParcours;
        private System.Windows.Forms.Button btnAddParcour;
        private System.Windows.Forms.Button btnLoadXML;
        private System.Windows.Forms.Button btnLoadDxf;
        private System.Windows.Forms.TextBox fldNewParcourName;
        private System.Windows.Forms.Label lblNewParcourName;
    }
}