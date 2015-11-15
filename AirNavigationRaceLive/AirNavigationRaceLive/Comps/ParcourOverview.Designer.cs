namespace AirNavigationRaceLive.Comps
{
    partial class ParcourOverview
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fldLongitude = new System.Windows.Forms.TextBox();
            this.fldLatitude = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fldCursorY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fldCursorX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lineBox = new System.Windows.Forms.GroupBox();
            this.fldLineTyp = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numLongO = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.numLatO = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numLongB = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numLatB = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numLongA = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.numLatA = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExport100k = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.columnHeaderParcour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PictureBox1 = new AirNavigationRaceLive.Comps.ParcourPictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.lineBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatA)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 533F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.5784526F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.42155F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2960, 1383);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.listBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.lineBox);
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Controls.Add(this.btnExport100k);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 14);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(517, 1362);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // listBox1
            // 
            this.listBox1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderParcour});
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FullRowSelect = true;
            this.listBox1.GridLines = true;
            this.listBox1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listBox1.LabelEdit = true;
            this.listBox1.Location = new System.Drawing.Point(8, 7);
            this.listBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBox1.MultiSelect = false;
            this.listBox1.Name = "listBox1";
            this.listBox1.ShowGroups = false;
            this.listBox1.Size = new System.Drawing.Size(503, 531);
            this.listBox1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listBox1.TabIndex = 19;
            this.listBox1.UseCompatibleStateImageBehavior = false;
            this.listBox1.View = System.Windows.Forms.View.List;
            this.listBox1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listBox1_AfterLabelEdit);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(232, 96);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(231, 46);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(231, 46);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fldLongitude);
            this.groupBox1.Controls.Add(this.fldLatitude);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.fldCursorY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.fldCursorX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 552);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.groupBox1.Size = new System.Drawing.Size(499, 145);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursor";
            // 
            // fldLongitude
            // 
            this.fldLongitude.Location = new System.Drawing.Point(307, 83);
            this.fldLongitude.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldLongitude.Name = "fldLongitude";
            this.fldLongitude.ReadOnly = true;
            this.fldLongitude.Size = new System.Drawing.Size(169, 38);
            this.fldLongitude.TabIndex = 7;
            // 
            // fldLatitude
            // 
            this.fldLatitude.Location = new System.Drawing.Point(307, 21);
            this.fldLatitude.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldLatitude.Name = "fldLatitude";
            this.fldLatitude.ReadOnly = true;
            this.fldLatitude.Size = new System.Drawing.Size(169, 38);
            this.fldLatitude.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(149, 83);
            this.label8.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(141, 32);
            this.label8.TabIndex = 5;
            this.label8.Text = "longitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(149, 38);
            this.label7.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 32);
            this.label7.TabIndex = 4;
            this.label7.Text = "latitude:";
            // 
            // fldCursorY
            // 
            this.fldCursorY.Location = new System.Drawing.Point(51, 76);
            this.fldCursorY.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldCursorY.Name = "fldCursorY";
            this.fldCursorY.ReadOnly = true;
            this.fldCursorY.Size = new System.Drawing.Size(76, 38);
            this.fldCursorY.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Y:";
            // 
            // fldCursorX
            // 
            this.fldCursorX.Location = new System.Drawing.Point(51, 31);
            this.fldCursorX.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldCursorX.Name = "fldCursorX";
            this.fldCursorX.ReadOnly = true;
            this.fldCursorX.Size = new System.Drawing.Size(76, 38);
            this.fldCursorX.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "X:";
            // 
            // lineBox
            // 
            this.lineBox.Controls.Add(this.fldLineTyp);
            this.lineBox.Controls.Add(this.label16);
            this.lineBox.Controls.Add(this.label15);
            this.lineBox.Controls.Add(this.numLongO);
            this.lineBox.Controls.Add(this.label13);
            this.lineBox.Controls.Add(this.numLatO);
            this.lineBox.Controls.Add(this.label14);
            this.lineBox.Controls.Add(this.numLongB);
            this.lineBox.Controls.Add(this.label11);
            this.lineBox.Controls.Add(this.numLatB);
            this.lineBox.Controls.Add(this.label12);
            this.lineBox.Controls.Add(this.numLongA);
            this.lineBox.Controls.Add(this.label10);
            this.lineBox.Controls.Add(this.numLatA);
            this.lineBox.Controls.Add(this.label9);
            this.lineBox.Enabled = false;
            this.lineBox.Location = new System.Drawing.Point(8, 711);
            this.lineBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lineBox.Name = "lineBox";
            this.lineBox.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.lineBox.Size = new System.Drawing.Size(499, 420);
            this.lineBox.TabIndex = 18;
            this.lineBox.TabStop = false;
            this.lineBox.Text = "Line";
            // 
            // fldLineTyp
            // 
            this.fldLineTyp.Location = new System.Drawing.Point(208, 31);
            this.fldLineTyp.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldLineTyp.Name = "fldLineTyp";
            this.fldLineTyp.ReadOnly = true;
            this.fldLineTyp.Size = new System.Drawing.Size(260, 38);
            this.fldLineTyp.TabIndex = 14;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(19, 38);
            this.label16.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 32);
            this.label16.TabIndex = 13;
            this.label16.Text = "Line Typ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 281);
            this.label15.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(442, 32);
            this.label15.TabIndex = 12;
            this.label15.Text = "Point O is used for the Orientation";
            // 
            // numLongO
            // 
            this.numLongO.DecimalPlaces = 12;
            this.numLongO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLongO.Location = new System.Drawing.Point(211, 362);
            this.numLongO.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLongO.Name = "numLongO";
            this.numLongO.Size = new System.Drawing.Size(267, 38);
            this.numLongO.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 367);
            this.label13.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 32);
            this.label13.TabIndex = 10;
            this.label13.Text = "Longitude O:";
            // 
            // numLatO
            // 
            this.numLatO.DecimalPlaces = 12;
            this.numLatO.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLatO.Location = new System.Drawing.Point(211, 317);
            this.numLatO.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLatO.Name = "numLatO";
            this.numLatO.Size = new System.Drawing.Size(267, 38);
            this.numLatO.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 322);
            this.label14.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 32);
            this.label14.TabIndex = 8;
            this.label14.Text = "Latitude O:";
            // 
            // numLongB
            // 
            this.numLongB.DecimalPlaces = 12;
            this.numLongB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLongB.Location = new System.Drawing.Point(208, 231);
            this.numLongB.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLongB.Name = "numLongB";
            this.numLongB.Size = new System.Drawing.Size(267, 38);
            this.numLongB.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 236);
            this.label11.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(176, 32);
            this.label11.TabIndex = 6;
            this.label11.Text = "Longitude B:";
            // 
            // numLatB
            // 
            this.numLatB.DecimalPlaces = 12;
            this.numLatB.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLatB.Location = new System.Drawing.Point(208, 186);
            this.numLatB.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLatB.Name = "numLatB";
            this.numLatB.Size = new System.Drawing.Size(267, 38);
            this.numLatB.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 191);
            this.label12.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(152, 32);
            this.label12.TabIndex = 4;
            this.label12.Text = "Latitude B:";
            // 
            // numLongA
            // 
            this.numLongA.DecimalPlaces = 12;
            this.numLongA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLongA.Location = new System.Drawing.Point(211, 131);
            this.numLongA.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLongA.Name = "numLongA";
            this.numLongA.Size = new System.Drawing.Size(267, 38);
            this.numLongA.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 136);
            this.label10.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 32);
            this.label10.TabIndex = 2;
            this.label10.Text = "Longitude A:";
            // 
            // numLatA
            // 
            this.numLatA.DecimalPlaces = 12;
            this.numLatA.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.numLatA.Location = new System.Drawing.Point(211, 86);
            this.numLatA.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numLatA.Name = "numLatA";
            this.numLatA.Size = new System.Drawing.Size(267, 38);
            this.numLatA.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 91);
            this.label9.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Latitude A:";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(8, 1145);
            this.btnExport.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(499, 55);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export Competition Map 1:200\'000";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExport100k
            // 
            this.btnExport100k.Location = new System.Drawing.Point(8, 1214);
            this.btnExport100k.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnExport100k.Name = "btnExport100k";
            this.btnExport100k.Size = new System.Drawing.Size(499, 55);
            this.btnExport100k.TabIndex = 21;
            this.btnExport100k.Text = "Export Competition Map 1:100\'000";
            this.btnExport100k.UseVisualStyleBackColor = true;
            this.btnExport100k.Click += new System.EventHandler(this.btnExport100k_Click);
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Controls.Add(this.PictureBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(541, 7);
            this.panel6.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panel6.Name = "panel6";
            this.tableLayoutPanel1.SetRowSpan(this.panel6, 2);
            this.panel6.Size = new System.Drawing.Size(2411, 1369);
            this.panel6.TabIndex = 3;
            // 
            // columnHeaderParcour
            // 
            this.columnHeaderParcour.Text = "Parcour";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(8, 7);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(500, 500);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PictureBox1.TabIndex = 1;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_Click);
            this.PictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // ParcourOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "ParcourOverview";
            this.Size = new System.Drawing.Size(2960, 1383);
            this.Load += new System.EventHandler(this.ParcourGen_VisibleChanged);
            this.VisibleChanged += new System.EventHandler(this.ParcourGen_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.lineBox.ResumeLayout(false);
            this.lineBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numLongO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLongA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLatA)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox fldCursorY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox fldCursorX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private ParcourPictureBox PictureBox1;
        private System.Windows.Forms.TextBox fldLongitude;
        private System.Windows.Forms.TextBox fldLatitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox lineBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numLongO;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numLatO;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numLongB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numLatB;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numLongA;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numLatA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fldLineTyp;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ListView listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExport100k;
        private System.Windows.Forms.ColumnHeader columnHeaderParcour;
    }
}
