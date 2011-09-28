namespace AirNavigationRaceLive.Comps
{
    partial class Visualisation
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
            this.lblAdjustTrackerHeight = new System.Windows.Forms.Label();
            this.lblPenaltyZoneHeight = new System.Windows.Forms.Label();
            this.lblVisualLineWidth = new System.Windows.Forms.Label();
            this.lblVisualPlaySpeed = new System.Windows.Forms.Label();
            this.VisualChkBoxAlwaysNewest = new System.Windows.Forms.CheckBox();
            this.VisualScrollBar = new System.Windows.Forms.HScrollBar();
            this.btnStartClient = new System.Windows.Forms.Button();
            this.fldTrackerHeight = new System.Windows.Forms.NumericUpDown();
            this.fldPenaltyHeight = new System.Windows.Forms.NumericUpDown();
            this.fldVisualLineWidth = new System.Windows.Forms.NumericUpDown();
            this.fldVisualPlaySpeed = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.visualisationPictureBox1 = new AirNavigationRaceLive.Comps.VisualisationPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fldTrackerHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldPenaltyHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualPlaySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAdjustTrackerHeight
            // 
            this.lblAdjustTrackerHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdjustTrackerHeight.AutoSize = true;
            this.lblAdjustTrackerHeight.Location = new System.Drawing.Point(742, 91);
            this.lblAdjustTrackerHeight.Name = "lblAdjustTrackerHeight";
            this.lblAdjustTrackerHeight.Size = new System.Drawing.Size(110, 13);
            this.lblAdjustTrackerHeight.TabIndex = 89;
            this.lblAdjustTrackerHeight.Text = "Adjust Tracker Height";
            // 
            // lblPenaltyZoneHeight
            // 
            this.lblPenaltyZoneHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPenaltyZoneHeight.AutoSize = true;
            this.lblPenaltyZoneHeight.Location = new System.Drawing.Point(773, 65);
            this.lblPenaltyZoneHeight.Name = "lblPenaltyZoneHeight";
            this.lblPenaltyZoneHeight.Size = new System.Drawing.Size(79, 13);
            this.lblPenaltyZoneHeight.TabIndex = 88;
            this.lblPenaltyZoneHeight.Text = "Penalty Zone h";
            // 
            // lblVisualLineWidth
            // 
            this.lblVisualLineWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVisualLineWidth.AutoSize = true;
            this.lblVisualLineWidth.Location = new System.Drawing.Point(797, 37);
            this.lblVisualLineWidth.Name = "lblVisualLineWidth";
            this.lblVisualLineWidth.Size = new System.Drawing.Size(55, 13);
            this.lblVisualLineWidth.TabIndex = 87;
            this.lblVisualLineWidth.Text = "Line width";
            // 
            // lblVisualPlaySpeed
            // 
            this.lblVisualPlaySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVisualPlaySpeed.AutoSize = true;
            this.lblVisualPlaySpeed.Location = new System.Drawing.Point(785, 117);
            this.lblVisualPlaySpeed.Name = "lblVisualPlaySpeed";
            this.lblVisualPlaySpeed.Size = new System.Drawing.Size(58, 13);
            this.lblVisualPlaySpeed.TabIndex = 86;
            this.lblVisualPlaySpeed.Text = "PlaySpeed";
            // 
            // VisualChkBoxAlwaysNewest
            // 
            this.VisualChkBoxAlwaysNewest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.VisualChkBoxAlwaysNewest.AutoSize = true;
            this.VisualChkBoxAlwaysNewest.Checked = true;
            this.VisualChkBoxAlwaysNewest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VisualChkBoxAlwaysNewest.Location = new System.Drawing.Point(752, 141);
            this.VisualChkBoxAlwaysNewest.Name = "VisualChkBoxAlwaysNewest";
            this.VisualChkBoxAlwaysNewest.Size = new System.Drawing.Size(169, 17);
            this.VisualChkBoxAlwaysNewest.TabIndex = 85;
            this.VisualChkBoxAlwaysNewest.Text = "Always show the newest Entry";
            this.VisualChkBoxAlwaysNewest.UseVisualStyleBackColor = true;
            // 
            // VisualScrollBar
            // 
            this.VisualScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VisualScrollBar.Location = new System.Drawing.Point(0, 529);
            this.VisualScrollBar.Maximum = 1000;
            this.VisualScrollBar.Name = "VisualScrollBar";
            this.VisualScrollBar.Size = new System.Drawing.Size(924, 13);
            this.VisualScrollBar.TabIndex = 84;
            this.VisualScrollBar.Value = 1;
            // 
            // btnStartClient
            // 
            this.btnStartClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartClient.Location = new System.Drawing.Point(745, 3);
            this.btnStartClient.Name = "btnStartClient";
            this.btnStartClient.Size = new System.Drawing.Size(176, 28);
            this.btnStartClient.TabIndex = 83;
            this.btnStartClient.Text = "Start Google Earth";
            this.btnStartClient.UseVisualStyleBackColor = true;
            this.btnStartClient.Click += new System.EventHandler(this.btnStartClient_Click);
            // 
            // fldTrackerHeight
            // 
            this.fldTrackerHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldTrackerHeight.Location = new System.Drawing.Point(875, 89);
            this.fldTrackerHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.fldTrackerHeight.Name = "fldTrackerHeight";
            this.fldTrackerHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fldTrackerHeight.Size = new System.Drawing.Size(46, 20);
            this.fldTrackerHeight.TabIndex = 94;
            this.fldTrackerHeight.ValueChanged += new System.EventHandler(this.fldTrackerHeight_ValueChanged);
            // 
            // fldPenaltyHeight
            // 
            this.fldPenaltyHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldPenaltyHeight.Location = new System.Drawing.Point(875, 63);
            this.fldPenaltyHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.fldPenaltyHeight.Name = "fldPenaltyHeight";
            this.fldPenaltyHeight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fldPenaltyHeight.Size = new System.Drawing.Size(46, 20);
            this.fldPenaltyHeight.TabIndex = 93;
            this.fldPenaltyHeight.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.fldPenaltyHeight.ValueChanged += new System.EventHandler(this.fldPenaltyHeight_ValueChanged);
            // 
            // fldVisualLineWidth
            // 
            this.fldVisualLineWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldVisualLineWidth.Location = new System.Drawing.Point(875, 37);
            this.fldVisualLineWidth.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.fldVisualLineWidth.Name = "fldVisualLineWidth";
            this.fldVisualLineWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fldVisualLineWidth.Size = new System.Drawing.Size(46, 20);
            this.fldVisualLineWidth.TabIndex = 92;
            this.fldVisualLineWidth.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.fldVisualLineWidth.ValueChanged += new System.EventHandler(this.fldVisualLineWidth_ValueChanged);
            // 
            // fldVisualPlaySpeed
            // 
            this.fldVisualPlaySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fldVisualPlaySpeed.Location = new System.Drawing.Point(875, 115);
            this.fldVisualPlaySpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fldVisualPlaySpeed.Name = "fldVisualPlaySpeed";
            this.fldVisualPlaySpeed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fldVisualPlaySpeed.Size = new System.Drawing.Size(46, 20);
            this.fldVisualPlaySpeed.TabIndex = 91;
            this.fldVisualPlaySpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 95;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 96;
            this.label1.Text = "Competition";
            // 
            // visualisationPictureBox1
            // 
            this.visualisationPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.visualisationPictureBox1.Location = new System.Drawing.Point(7, 29);
            this.visualisationPictureBox1.Name = "visualisationPictureBox1";
            this.visualisationPictureBox1.Size = new System.Drawing.Size(729, 497);
            this.visualisationPictureBox1.TabIndex = 97;
            this.visualisationPictureBox1.TabStop = false;
            // 
            // Visualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.visualisationPictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.fldTrackerHeight);
            this.Controls.Add(this.fldPenaltyHeight);
            this.Controls.Add(this.fldVisualLineWidth);
            this.Controls.Add(this.fldVisualPlaySpeed);
            this.Controls.Add(this.lblAdjustTrackerHeight);
            this.Controls.Add(this.lblPenaltyZoneHeight);
            this.Controls.Add(this.lblVisualLineWidth);
            this.Controls.Add(this.lblVisualPlaySpeed);
            this.Controls.Add(this.VisualChkBoxAlwaysNewest);
            this.Controls.Add(this.VisualScrollBar);
            this.Controls.Add(this.btnStartClient);
            this.Name = "Visualisation";
            this.Size = new System.Drawing.Size(924, 542);
            ((System.ComponentModel.ISupportInitialize)(this.fldTrackerHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldPenaltyHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fldVisualPlaySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visualisationPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAdjustTrackerHeight;
        private System.Windows.Forms.Label lblPenaltyZoneHeight;
        private System.Windows.Forms.Label lblVisualLineWidth;
        private System.Windows.Forms.Label lblVisualPlaySpeed;
        private System.Windows.Forms.CheckBox VisualChkBoxAlwaysNewest;
        private System.Windows.Forms.HScrollBar VisualScrollBar;
        private System.Windows.Forms.Button btnStartClient;
        private System.Windows.Forms.NumericUpDown fldTrackerHeight;
        private System.Windows.Forms.NumericUpDown fldPenaltyHeight;
        private System.Windows.Forms.NumericUpDown fldVisualLineWidth;
        private System.Windows.Forms.NumericUpDown fldVisualPlaySpeed;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private VisualisationPictureBox visualisationPictureBox1;
    }
}
