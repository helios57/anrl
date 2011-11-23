namespace AirNavigationRaceLive.Comps
{
    partial class Competition
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
            this.checkBoxClearCache = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fldCompetition = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fldOwner = new System.Windows.Forms.TextBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fldCompetitionName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.fldPublicRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxClearCache
            // 
            this.checkBoxClearCache.AutoSize = true;
            this.checkBoxClearCache.Location = new System.Drawing.Point(184, 35);
            this.checkBoxClearCache.Name = "checkBoxClearCache";
            this.checkBoxClearCache.Size = new System.Drawing.Size(84, 17);
            this.checkBoxClearCache.TabIndex = 8;
            this.checkBoxClearCache.Text = "Clear Cache";
            this.checkBoxClearCache.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Competition";
            // 
            // fldCompetition
            // 
            this.fldCompetition.FormattingEnabled = true;
            this.fldCompetition.Location = new System.Drawing.Point(80, 3);
            this.fldCompetition.Name = "fldCompetition";
            this.fldCompetition.Size = new System.Drawing.Size(224, 21);
            this.fldCompetition.TabIndex = 6;
            this.fldCompetition.SelectedIndexChanged += new System.EventHandler(this.fldCompetition_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Owner";
            this.label2.Visible = false;
            // 
            // fldOwner
            // 
            this.fldOwner.Location = new System.Drawing.Point(385, 3);
            this.fldOwner.Name = "fldOwner";
            this.fldOwner.Size = new System.Drawing.Size(98, 20);
            this.fldOwner.TabIndex = 20;
            this.fldOwner.Visible = false;
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(80, 30);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(98, 24);
            this.btnUse.TabIndex = 7;
            this.btnUse.Text = "Use";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Create new Competition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Name";
            // 
            // fldCompetitionName
            // 
            this.fldCompetitionName.Location = new System.Drawing.Point(80, 155);
            this.fldCompetitionName.Name = "fldCompetitionName";
            this.fldCompetitionName.Size = new System.Drawing.Size(224, 20);
            this.fldCompetitionName.TabIndex = 9;
            this.fldCompetitionName.TextChanged += new System.EventHandler(this.fldCompetitionName_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(80, 208);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 24);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // fldPublicRole
            // 
            this.fldPublicRole.FormattingEnabled = true;
            this.fldPublicRole.Location = new System.Drawing.Point(80, 181);
            this.fldPublicRole.Name = "fldPublicRole";
            this.fldPublicRole.Size = new System.Drawing.Size(98, 21);
            this.fldPublicRole.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Public Role";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(499, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(98, 24);
            this.btnRefresh.TabIndex = 28;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Competition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.fldPublicRole);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fldCompetitionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fldOwner);
            this.Controls.Add(this.fldCompetition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxClearCache);
            this.Name = "Competition";
            this.Size = new System.Drawing.Size(600, 400);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxClearCache;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fldCompetition;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox fldOwner;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox fldCompetitionName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.ComboBox fldPublicRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRefresh;
    }
}
