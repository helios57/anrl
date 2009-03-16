namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.kmlTreeView1 = new FC.GEPluginCtrls.KmlTreeView();
            this.geToolStrip1 = new FC.GEPluginCtrls.GEToolStrip();
            this.geWebBrowser1 = new FC.GEPluginCtrls.GEWebBrowser();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.kmlTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.geWebBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(884, 613);
            this.splitContainer1.SplitterDistance = 294;
            this.splitContainer1.TabIndex = 2;
            // 
            // kmlTreeView1
            // 
            this.kmlTreeView1.CheckBoxes = true;
            this.kmlTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kmlTreeView1.ExpandVisibleFeatures = false;
            this.kmlTreeView1.ImageIndex = 0;
            this.kmlTreeView1.Location = new System.Drawing.Point(0, 0);
            this.kmlTreeView1.Name = "kmlTreeView1";
            this.kmlTreeView1.SelectedImageIndex = 0;
            this.kmlTreeView1.ShowNodeToolTips = true;
            this.kmlTreeView1.Size = new System.Drawing.Size(294, 613);
            this.kmlTreeView1.TabIndex = 0;
            // 
            // geToolStrip1
            // 
            this.geToolStrip1.Enabled = false;
            this.geToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.geToolStrip1.Name = "geToolStrip1";
            this.geToolStrip1.Size = new System.Drawing.Size(884, 25);
            this.geToolStrip1.TabIndex = 1;
            this.geToolStrip1.Text = "geToolStrip1";
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
            this.geWebBrowser1.Size = new System.Drawing.Size(586, 613);
            this.geWebBrowser1.TabIndex = 0;
            this.geWebBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.geToolStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FC.GEPluginCtrls.GEToolStrip geToolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private FC.GEPluginCtrls.KmlTreeView kmlTreeView1;
        private FC.GEPluginCtrls.GEWebBrowser geWebBrowser1;
    }
}

