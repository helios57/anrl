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
            this.geWebBrowser1 = new GELive.GEWebBrowser();
            this.geToolStrip1 = new GELive.GEToolStrip();
            this.ToolStrip1 = new System.Windows.Forms.ToolStripButton();
            this.geToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // geWebBrowser1
            // 
            this.geWebBrowser1.AllowNavigation = false;
            this.geWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.geWebBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.geWebBrowser1.Location = new System.Drawing.Point(0, 25);
            this.geWebBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.geWebBrowser1.Name = "geWebBrowser1";
            this.geWebBrowser1.ScrollBarsEnabled = false;
            this.geWebBrowser1.Size = new System.Drawing.Size(633, 499);
            this.geWebBrowser1.TabIndex = 2;
            this.geWebBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // geToolStrip1
            // 
            this.geToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStrip1});
            this.geToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.geToolStrip1.Name = "geToolStrip1";
            this.geToolStrip1.Size = new System.Drawing.Size(633, 25);
            this.geToolStrip1.TabIndex = 1;
            this.geToolStrip1.Text = "geToolStrip1";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ToolStrip1.Image = ((System.Drawing.Image)(resources.GetObject("ToolStrip1.Image")));
            this.ToolStrip1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Size = new System.Drawing.Size(72, 22);
            this.ToolStrip1.Text = "Load Kml File";
            this.ToolStrip1.Click += new System.EventHandler(this.LoadKml_Click);
            // 
            // anrl_gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 524);
            this.Controls.Add(this.geWebBrowser1);
            this.Controls.Add(this.geToolStrip1);
            this.Name = "anrl_gui";
            this.Text = "Air Navigation Race LIVE";
            this.geToolStrip1.ResumeLayout(false);
            this.geToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GEToolStrip geToolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStrip1;
        private GEWebBrowser geWebBrowser1;


    }
}

