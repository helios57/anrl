﻿namespace AirNavigationRaceLive.Comps
{
    partial class Tracker
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
            this.lblTrackers = new System.Windows.Forms.Label();
            this.btnTrackersRefresh = new System.Windows.Forms.Button();
            this.listViewTracker = new System.Windows.Forms.ListView();
            this.IDl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Namel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IMEIl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxIMEI = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTrackers
            // 
            this.lblTrackers.AutoSize = true;
            this.lblTrackers.Location = new System.Drawing.Point(4, 4);
            this.lblTrackers.Name = "lblTrackers";
            this.lblTrackers.Size = new System.Drawing.Size(147, 13);
            this.lblTrackers.TabIndex = 1;
            this.lblTrackers.Text = "Trackers registered on Server";
            // 
            // btnTrackersRefresh
            // 
            this.btnTrackersRefresh.Location = new System.Drawing.Point(474, 21);
            this.btnTrackersRefresh.Name = "btnTrackersRefresh";
            this.btnTrackersRefresh.Size = new System.Drawing.Size(123, 23);
            this.btnTrackersRefresh.TabIndex = 2;
            this.btnTrackersRefresh.Text = "Refresh";
            this.btnTrackersRefresh.UseVisualStyleBackColor = true;
            this.btnTrackersRefresh.Click += new System.EventHandler(this.btnTrackersRefresh_Click);
            // 
            // listViewTracker
            // 
            this.listViewTracker.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewTracker.AutoArrange = false;
            this.listViewTracker.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDl,
            this.Namel,
            this.IMEIl});
            this.listViewTracker.FullRowSelect = true;
            this.listViewTracker.GridLines = true;
            this.listViewTracker.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewTracker.LabelWrap = false;
            this.listViewTracker.Location = new System.Drawing.Point(7, 21);
            this.listViewTracker.MultiSelect = false;
            this.listViewTracker.Name = "listViewTracker";
            this.listViewTracker.ShowGroups = false;
            this.listViewTracker.Size = new System.Drawing.Size(461, 128);
            this.listViewTracker.TabIndex = 3;
            this.listViewTracker.UseCompatibleStateImageBehavior = false;
            this.listViewTracker.View = System.Windows.Forms.View.Details;
            this.listViewTracker.SelectedIndexChanged += new System.EventHandler(this.listViewTracker_SelectedIndexChanged);
            // 
            // IDl
            // 
            this.IDl.Tag = "IDl";
            this.IDl.Text = "ID";
            this.IDl.Width = 70;
            // 
            // Namel
            // 
            this.Namel.Tag = "Namel";
            this.Namel.Text = "Name";
            this.Namel.Width = 128;
            // 
            // IMEIl
            // 
            this.IMEIl.Tag = "IMEIl";
            this.IMEIl.Text = "IMEI";
            this.IMEIl.Width = 191;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 194);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IMEI";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(66, 165);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.ReadOnly = true;
            this.textBoxID.Size = new System.Drawing.Size(149, 20);
            this.textBoxID.TabIndex = 7;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(66, 191);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(149, 20);
            this.textBoxName.TabIndex = 8;
            // 
            // textBoxIMEI
            // 
            this.textBoxIMEI.Enabled = false;
            this.textBoxIMEI.Location = new System.Drawing.Point(66, 219);
            this.textBoxIMEI.Name = "textBoxIMEI";
            this.textBoxIMEI.ReadOnly = true;
            this.textBoxIMEI.Size = new System.Drawing.Size(149, 20);
            this.textBoxIMEI.TabIndex = 9;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(66, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 23);
            this.buttonSave.TabIndex = 10;
            this.buttonSave.Text = "Save Name";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxIMEI);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewTracker);
            this.Controls.Add(this.btnTrackersRefresh);
            this.Controls.Add(this.lblTrackers);
            this.Name = "Tracker";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.Tracker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTrackers;
        private System.Windows.Forms.Button btnTrackersRefresh;
        private System.Windows.Forms.ListView listViewTracker;
        private System.Windows.Forms.ColumnHeader IDl;
        private System.Windows.Forms.ColumnHeader Namel;
        private System.Windows.Forms.ColumnHeader IMEIl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxIMEI;
        private System.Windows.Forms.Button buttonSave;
    }
}