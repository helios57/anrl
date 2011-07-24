namespace AirNavigationRaceLive.Components
{
    partial class MapLegacy
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportANR = new System.Windows.Forms.Button();
            this.fldName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(114, 26);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // btnImportANR
            // 
            this.btnImportANR.Location = new System.Drawing.Point(0, 26);
            this.btnImportANR.Name = "btnImportANR";
            this.btnImportANR.Size = new System.Drawing.Size(442, 23);
            this.btnImportANR.TabIndex = 1;
            this.btnImportANR.Text = "Import File with Topleft, BottomRight in Filename (like in ANR) Swiss coordinates" +
                "";
            this.btnImportANR.UseVisualStyleBackColor = true;
            this.btnImportANR.Click += new System.EventHandler(this.btnImportANR_Click);
            // 
            // fldName
            // 
            this.fldName.Location = new System.Drawing.Point(44, 0);
            this.fldName.Name = "fldName";
            this.fldName.Size = new System.Drawing.Size(304, 20);
            this.fldName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(617, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import File wgs84 with filename like LatitudeTopLeft_LongitureTopleft_LatitudeBot" +
                "tomRight_LongitudeBottomRight.jpg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MapLegacy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldName);
            this.Controls.Add(this.btnImportANR);
            this.Controls.Add(this.button1);
            this.Name = "MapLegacy";
            this.Size = new System.Drawing.Size(1110, 580);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.Button btnImportANR;
        private System.Windows.Forms.TextBox fldName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
