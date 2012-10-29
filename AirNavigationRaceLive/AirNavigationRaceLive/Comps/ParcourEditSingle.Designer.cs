﻿namespace AirNavigationRaceLive.Comps
{
    partial class ParcourEditSingle
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxParcours = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbMap = new System.Windows.Forms.GroupBox();
            this.comboBoxMaps = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fldLengthSummed = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.fldLengthDirect = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.fldLongitude = new System.Windows.Forms.TextBox();
            this.fldLatitude = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.fldCursorY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.fldCursorX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.fldChannelLength = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.channelWide = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.lineBox = new System.Windows.Forms.GroupBox();
            this.btnSetEndPoint = new System.Windows.Forms.Button();
            this.btnSetStartPoint = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPoint = new System.Windows.Forms.ComboBox();
            this.manualPointLongitude = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.manualPointLatitude = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.fldName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new AirNavigationRaceLive.Comps.ParcourPictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbMap.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldChannelLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelWide)).BeginInit();
            this.lineBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualPointLongitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualPointLatitude)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.793103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.20689F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 580);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.comboBoxParcours);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 15);
            this.panel1.TabIndex = 1;
            // 
            // comboBoxParcours
            // 
            this.comboBoxParcours.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxParcours.FormattingEnabled = true;
            this.comboBoxParcours.Location = new System.Drawing.Point(56, -3);
            this.comboBoxParcours.Name = "comboBoxParcours";
            this.comboBoxParcours.Size = new System.Drawing.Size(135, 21);
            this.comboBoxParcours.TabIndex = 1;
            this.comboBoxParcours.SelectedIndexChanged += new System.EventHandler(this.comboBoxParcours_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parcour:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbMap);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.lineBox);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.btnSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(194, 553);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // gbMap
            // 
            this.gbMap.Controls.Add(this.comboBoxMaps);
            this.gbMap.Location = new System.Drawing.Point(3, 3);
            this.gbMap.Name = "gbMap";
            this.gbMap.Size = new System.Drawing.Size(187, 41);
            this.gbMap.TabIndex = 18;
            this.gbMap.TabStop = false;
            this.gbMap.Text = "Map";
            // 
            // comboBoxMaps
            // 
            this.comboBoxMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMaps.FormattingEnabled = true;
            this.comboBoxMaps.Location = new System.Drawing.Point(6, 14);
            this.comboBoxMaps.Name = "comboBoxMaps";
            this.comboBoxMaps.Size = new System.Drawing.Size(181, 21);
            this.comboBoxMaps.TabIndex = 3;
            this.comboBoxMaps.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaps_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fldLengthSummed);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.fldLengthDirect);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.fldLongitude);
            this.groupBox1.Controls.Add(this.fldLatitude);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.fldCursorY);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.fldCursorX);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 107);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cursor";
            // 
            // fldLengthSummed
            // 
            this.fldLengthSummed.Location = new System.Drawing.Point(115, 87);
            this.fldLengthSummed.Name = "fldLengthSummed";
            this.fldLengthSummed.ReadOnly = true;
            this.fldLengthSummed.Size = new System.Drawing.Size(66, 20);
            this.fldLengthSummed.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 90);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Leg length (summed):";
            // 
            // fldLengthDirect
            // 
            this.fldLengthDirect.Location = new System.Drawing.Point(115, 61);
            this.fldLengthDirect.Name = "fldLengthDirect";
            this.fldLengthDirect.ReadOnly = true;
            this.fldLengthDirect.Size = new System.Drawing.Size(66, 20);
            this.fldLengthDirect.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Start to End (direct):";
            // 
            // fldLongitude
            // 
            this.fldLongitude.Location = new System.Drawing.Point(115, 35);
            this.fldLongitude.Name = "fldLongitude";
            this.fldLongitude.ReadOnly = true;
            this.fldLongitude.Size = new System.Drawing.Size(66, 20);
            this.fldLongitude.TabIndex = 7;
            // 
            // fldLatitude
            // 
            this.fldLatitude.Location = new System.Drawing.Point(115, 9);
            this.fldLatitude.Name = "fldLatitude";
            this.fldLatitude.ReadOnly = true;
            this.fldLatitude.Size = new System.Drawing.Size(66, 20);
            this.fldLatitude.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 35);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "longitude:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "latitude:";
            // 
            // fldCursorY
            // 
            this.fldCursorY.Location = new System.Drawing.Point(19, 32);
            this.fldCursorY.Name = "fldCursorY";
            this.fldCursorY.ReadOnly = true;
            this.fldCursorY.Size = new System.Drawing.Size(31, 20);
            this.fldCursorY.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Y:";
            // 
            // fldCursorX
            // 
            this.fldCursorX.Location = new System.Drawing.Point(19, 13);
            this.fldCursorX.Name = "fldCursorX";
            this.fldCursorX.ReadOnly = true;
            this.fldCursorX.Size = new System.Drawing.Size(31, 20);
            this.fldCursorX.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "X:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.fldChannelLength);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.channelWide);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 163);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 54);
            this.panel2.TabIndex = 21;
            // 
            // fldChannelLength
            // 
            this.fldChannelLength.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fldChannelLength.Location = new System.Drawing.Point(119, 29);
            this.fldChannelLength.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.fldChannelLength.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.fldChannelLength.Name = "fldChannelLength";
            this.fldChannelLength.Size = new System.Drawing.Size(62, 20);
            this.fldChannelLength.TabIndex = 4;
            this.fldChannelLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.fldChannelLength.ValueChanged += new System.EventHandler(this.fldChannelLength_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 13);
            this.label15.TabIndex = 3;
            this.label15.Text = "Leg length (SUM, NM):";
            // 
            // channelWide
            // 
            this.channelWide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.channelWide.DecimalPlaces = 4;
            this.channelWide.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.channelWide.Location = new System.Drawing.Point(119, 5);
            this.channelWide.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.channelWide.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.channelWide.Name = "channelWide";
            this.channelWide.Size = new System.Drawing.Size(62, 20);
            this.channelWide.TabIndex = 2;
            this.channelWide.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.channelWide.ValueChanged += new System.EventHandler(this.channelWide_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Corridor width (NM):";
            // 
            // lineBox
            // 
            this.lineBox.Controls.Add(this.btnSetEndPoint);
            this.lineBox.Controls.Add(this.btnSetStartPoint);
            this.lineBox.Location = new System.Drawing.Point(3, 223);
            this.lineBox.Name = "lineBox";
            this.lineBox.Size = new System.Drawing.Size(187, 46);
            this.lineBox.TabIndex = 18;
            this.lineBox.TabStop = false;
            this.lineBox.Text = "Points";
            // 
            // btnSetEndPoint
            // 
            this.btnSetEndPoint.Location = new System.Drawing.Point(98, 15);
            this.btnSetEndPoint.Name = "btnSetEndPoint";
            this.btnSetEndPoint.Size = new System.Drawing.Size(83, 23);
            this.btnSetEndPoint.TabIndex = 8;
            this.btnSetEndPoint.Text = "Set End Point";
            this.btnSetEndPoint.UseVisualStyleBackColor = true;
            this.btnSetEndPoint.Click += new System.EventHandler(this.btnSetEndPoint_Click);
            // 
            // btnSetStartPoint
            // 
            this.btnSetStartPoint.Location = new System.Drawing.Point(6, 15);
            this.btnSetStartPoint.Name = "btnSetStartPoint";
            this.btnSetStartPoint.Size = new System.Drawing.Size(83, 23);
            this.btnSetStartPoint.TabIndex = 7;
            this.btnSetStartPoint.Text = "Set Start Point";
            this.btnSetStartPoint.UseVisualStyleBackColor = true;
            this.btnSetStartPoint.Click += new System.EventHandler(this.btnSetStartPoint_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.comboBoxPoint);
            this.groupBox2.Controls.Add(this.manualPointLongitude);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.manualPointLatitude);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Location = new System.Drawing.Point(3, 275);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 125);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manual Point Adjustment";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(82, 98);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(99, 23);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Point:";
            // 
            // comboBoxPoint
            // 
            this.comboBoxPoint.FormattingEnabled = true;
            this.comboBoxPoint.Location = new System.Drawing.Point(82, 19);
            this.comboBoxPoint.Name = "comboBoxPoint";
            this.comboBoxPoint.Size = new System.Drawing.Size(99, 21);
            this.comboBoxPoint.TabIndex = 4;
            this.comboBoxPoint.SelectedIndexChanged += new System.EventHandler(this.comboBoxPoint_SelectedIndexChanged);
            // 
            // manualPointLongitude
            // 
            this.manualPointLongitude.DecimalPlaces = 12;
            this.manualPointLongitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.manualPointLongitude.Location = new System.Drawing.Point(81, 72);
            this.manualPointLongitude.Name = "manualPointLongitude";
            this.manualPointLongitude.Size = new System.Drawing.Size(100, 20);
            this.manualPointLongitude.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Longitude:";
            // 
            // manualPointLatitude
            // 
            this.manualPointLatitude.DecimalPlaces = 12;
            this.manualPointLatitude.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.manualPointLatitude.Location = new System.Drawing.Point(81, 46);
            this.manualPointLatitude.Name = "manualPointLatitude";
            this.manualPointLatitude.Size = new System.Drawing.Size(100, 20);
            this.manualPointLatitude.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Latitude:";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel4.Controls.Add(this.fldName);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(3, 406);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(190, 28);
            this.panel4.TabIndex = 20;
            // 
            // fldName
            // 
            this.fldName.Location = new System.Drawing.Point(81, 3);
            this.fldName.Name = "fldName";
            this.fldName.Size = new System.Drawing.Size(106, 20);
            this.fldName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(3, 440);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(187, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(203, 3);
            this.panel6.Name = "panel6";
            this.tableLayoutPanel1.SetRowSpan(this.panel6, 2);
            this.panel6.Size = new System.Drawing.Size(904, 574);
            this.panel6.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ParcourEditSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ParcourEditSingle";
            this.Size = new System.Drawing.Size(1110, 580);
            this.Load += new System.EventHandler(this.ParcourGen_Load);
            this.VisibleChanged += new System.EventHandler(this.ParcourGen_VisibleChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbMap.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fldChannelLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channelWide)).EndInit();
            this.lineBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.manualPointLongitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.manualPointLatitude)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private ParcourPictureBox pictureBox1;
        private System.Windows.Forms.TextBox fldLongitude;
        private System.Windows.Forms.TextBox fldLatitude;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox lineBox;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox fldName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown channelWide;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPoint;
        private System.Windows.Forms.NumericUpDown manualPointLongitude;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown manualPointLatitude;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox fldLengthSummed;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox fldLengthDirect;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown fldChannelLength;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox gbMap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxParcours;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMaps;
        private System.Windows.Forms.Button btnSetEndPoint;
        private System.Windows.Forms.Button btnSetStartPoint;
    }
}
