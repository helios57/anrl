namespace AirNavigationRaceLive.Comps
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
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(232, 50);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(231, 46);
            this.refreshToolStripMenuItem.Text = "Refresh";
            // 
            // btnImportANR
            // 
            this.btnImportANR.Location = new System.Drawing.Point(0, 82);
            this.btnImportANR.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnImportANR.Name = "btnImportANR";
            this.btnImportANR.Size = new System.Drawing.Size(1179, 55);
            this.btnImportANR.TabIndex = 1;
            this.btnImportANR.Text = "Import File with Topleft, BottomRight in Filename (like in ANR) Swiss coordinates" +
    "";
            this.btnImportANR.UseVisualStyleBackColor = true;
            this.btnImportANR.Click += new System.EventHandler(this.btnImportANR_Click);
            // 
            // fldName
            // 
            this.fldName.Location = new System.Drawing.Point(117, 20);
            this.fldName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldName.Name = "fldName";
            this.fldName.Size = new System.Drawing.Size(804, 38);
            this.fldName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 151);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1645, 55);
            this.button1.TabIndex = 4;
            this.button1.Text = "Import File wgs84 with filename like LatitudeTopLeft_LongitureTopleft_LatitudeBot" +
    "tomRight_LongitudeBottomRight.jpg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MapLegacy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fldName);
            this.Controls.Add(this.btnImportANR);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "MapLegacy";
            this.Size = new System.Drawing.Size(2960, 1383);
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
