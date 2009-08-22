namespace GELive
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
            this.SuspendLayout();
            // 
            // lstParcours
            // 
            this.lstParcours.FormattingEnabled = true;
            this.lstParcours.Location = new System.Drawing.Point(12, 12);
            this.lstParcours.Name = "lstParcours";
            this.lstParcours.Size = new System.Drawing.Size(250, 186);
            this.lstParcours.TabIndex = 0;
            // 
            // btnAddParcour
            // 
            this.btnAddParcour.Location = new System.Drawing.Point(12, 204);
            this.btnAddParcour.Name = "btnAddParcour";
            this.btnAddParcour.Size = new System.Drawing.Size(250, 23);
            this.btnAddParcour.TabIndex = 1;
            this.btnAddParcour.Text = "Add Selected Parcour";
            this.btnAddParcour.UseVisualStyleBackColor = true;
            this.btnAddParcour.Click += new System.EventHandler(this.btnAddParcour_Click);
            // 
            // Parcours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 233);
            this.Controls.Add(this.btnAddParcour);
            this.Controls.Add(this.lstParcours);
            this.Name = "Parcours";
            this.Text = "Parcours";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstParcours;
        private System.Windows.Forms.Button btnAddParcour;
    }
}