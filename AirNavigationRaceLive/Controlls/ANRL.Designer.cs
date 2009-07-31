namespace Controlls
{
    partial class ANRL
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
            this.btnAddForbiddenZones = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddForbiddenZones
            // 
            this.btnAddForbiddenZones.Location = new System.Drawing.Point(3, 76);
            this.btnAddForbiddenZones.Name = "btnAddForbiddenZones";
            this.btnAddForbiddenZones.Size = new System.Drawing.Size(213, 23);
            this.btnAddForbiddenZones.TabIndex = 0;
            this.btnAddForbiddenZones.Text = "Add Forbidden Zones to ARNL - Server";
            this.btnAddForbiddenZones.UseVisualStyleBackColor = true;
            this.btnAddForbiddenZones.Click += new System.EventHandler(this.btnAddForbiddenZones_Click);
            // 
            // ANRL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAddForbiddenZones);
            this.Name = "ANRL";
            this.Size = new System.Drawing.Size(593, 392);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddForbiddenZones;
    }
}
