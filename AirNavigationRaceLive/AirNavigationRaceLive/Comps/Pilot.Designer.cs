namespace AirNavigationRaceLive.Comps
{
    partial class Pilot
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
            this.listViewPilots = new System.Windows.Forms.ListView();
            this.IDl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Namel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vornamel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxLastname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSurename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAddPicture = new System.Windows.Forms.Button();
            this.textBoxPictureId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // listViewPilots
            // 
            this.listViewPilots.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listViewPilots.AutoArrange = false;
            this.listViewPilots.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDl,
            this.Namel,
            this.Vornamel});
            this.listViewPilots.FullRowSelect = true;
            this.listViewPilots.GridLines = true;
            this.listViewPilots.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewPilots.LabelWrap = false;
            this.listViewPilots.Location = new System.Drawing.Point(6, 3);
            this.listViewPilots.MultiSelect = false;
            this.listViewPilots.Name = "listViewPilots";
            this.listViewPilots.ShowGroups = false;
            this.listViewPilots.Size = new System.Drawing.Size(413, 394);
            this.listViewPilots.TabIndex = 4;
            this.listViewPilots.UseCompatibleStateImageBehavior = false;
            this.listViewPilots.View = System.Windows.Forms.View.Details;
            this.listViewPilots.SelectedIndexChanged += new System.EventHandler(this.listViewPilots_SelectedIndexChanged);
            // 
            // IDl
            // 
            this.IDl.Tag = "IDl";
            this.IDl.Text = "ID";
            this.IDl.Width = 53;
            // 
            // Namel
            // 
            this.Namel.Tag = "Namel";
            this.Namel.Text = "Lastname";
            this.Namel.Width = 183;
            // 
            // Vornamel
            // 
            this.Vornamel.Tag = "Vornamel";
            this.Vornamel.Text = "Firstname";
            this.Vornamel.Width = 172;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(425, 20);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(158, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // textBoxID
            // 
            this.textBoxID.Enabled = false;
            this.textBoxID.Location = new System.Drawing.Point(483, 76);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(100, 20);
            this.textBoxID.TabIndex = 8;
            // 
            // textBoxLastname
            // 
            this.textBoxLastname.Location = new System.Drawing.Point(483, 102);
            this.textBoxLastname.Name = "textBoxLastname";
            this.textBoxLastname.Size = new System.Drawing.Size(100, 20);
            this.textBoxLastname.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lastname";
            // 
            // textBoxSurename
            // 
            this.textBoxSurename.Location = new System.Drawing.Point(483, 128);
            this.textBoxSurename.Name = "textBoxSurename";
            this.textBoxSurename.Size = new System.Drawing.Size(100, 20);
            this.textBoxSurename.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(422, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Firstname";
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(483, 155);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 100);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 13;
            this.pictureBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Picture";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(427, 49);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(508, 49);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.Location = new System.Drawing.Point(483, 261);
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(100, 23);
            this.btnAddPicture.TabIndex = 17;
            this.btnAddPicture.Text = "Add Picture";
            this.btnAddPicture.UseVisualStyleBackColor = true;
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // textBoxPictureId
            // 
            this.textBoxPictureId.Enabled = false;
            this.textBoxPictureId.Location = new System.Drawing.Point(483, 290);
            this.textBoxPictureId.Name = "textBoxPictureId";
            this.textBoxPictureId.Size = new System.Drawing.Size(100, 20);
            this.textBoxPictureId.TabIndex = 18;
            this.textBoxPictureId.Visible = false;
            // 
            // Pilot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxPictureId);
            this.Controls.Add(this.btnAddPicture);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.textBoxSurename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxLastname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.listViewPilots);
            this.Name = "Pilot";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.Pilot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewPilots;
        private System.Windows.Forms.ColumnHeader IDl;
        private System.Windows.Forms.ColumnHeader Namel;
        private System.Windows.Forms.ColumnHeader Vornamel;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxLastname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSurename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAddPicture;
        private System.Windows.Forms.TextBox textBoxPictureId;
    }
}
