namespace GELive
{
    partial class anrl_gui
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(anrl_gui));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.geWebBrowser1 = new GELive.GEWebBrowser();
            this.geToolStrip1 = new GELive.GEToolStrip();
            this.LoadKml = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.geToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.geWebBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(633, 524);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 0;
            // 
            // geWebBrowser1
            // 
            this.geWebBrowser1.AllowNavigation = false;
            this.geWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geWebBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.geWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.geWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.geWebBrowser1.Name = "geWebBrowser1";
            this.geWebBrowser1.ScrollBarsEnabled = false;
            this.geWebBrowser1.Size = new System.Drawing.Size(418, 524);
            this.geWebBrowser1.TabIndex = 0;
            this.geWebBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // geToolStrip1
            // 
            this.geToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadKml});
            this.geToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.geToolStrip1.Name = "geToolStrip1";
            this.geToolStrip1.Size = new System.Drawing.Size(633, 25);
            this.geToolStrip1.TabIndex = 1;
            this.geToolStrip1.Text = "geToolStrip1";
            // 
            // LoadKml
            // 
            this.LoadKml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadKml.Image = ((System.Drawing.Image)(resources.GetObject("LoadKml.Image")));
            this.LoadKml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadKml.Name = "LoadKml";
            this.LoadKml.Size = new System.Drawing.Size(82, 22);
            this.LoadKml.Text = "Load Kml File";
            this.LoadKml.Click += new System.EventHandler(this.LoadKml_Click);
            // 
            // anrl_gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 524);
            this.Controls.Add(this.geToolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "anrl_gui";
            this.Text = "Form1";
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.geToolStrip1.ResumeLayout(false);
            this.geToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GELive.GEWebBrowser geWebBrowser1;
        private GEToolStrip geToolStrip1;
        private System.Windows.Forms.ToolStripButton LoadKml;


    }
}

