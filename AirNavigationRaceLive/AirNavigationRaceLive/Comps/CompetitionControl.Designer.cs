namespace AirNavigationRaceLive.Comps
{
    partial class CompetitionControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.fldCompetition = new System.Windows.Forms.ComboBox();
            this.btnUse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fldCompetitionName = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 18;
            this.label1.Text = "Competition";
            // 
            // fldCompetition
            // 
            this.fldCompetition.FormattingEnabled = true;
            this.fldCompetition.Location = new System.Drawing.Point(213, 7);
            this.fldCompetition.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldCompetition.Name = "fldCompetition";
            this.fldCompetition.Size = new System.Drawing.Size(591, 39);
            this.fldCompetition.TabIndex = 6;
            this.fldCompetition.SelectedIndexChanged += new System.EventHandler(this.fldCompetition_SelectedIndexChanged);
            // 
            // btnUse
            // 
            this.btnUse.Location = new System.Drawing.Point(213, 72);
            this.btnUse.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(261, 57);
            this.btnUse.TabIndex = 7;
            this.btnUse.Text = "Use";
            this.btnUse.UseVisualStyleBackColor = true;
            this.btnUse.Click += new System.EventHandler(this.btnUse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 310);
            this.label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 32);
            this.label3.TabIndex = 23;
            this.label3.Text = "Create new Competition";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 377);
            this.label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 32);
            this.label4.TabIndex = 25;
            this.label4.Text = "Name";
            // 
            // fldCompetitionName
            // 
            this.fldCompetitionName.Location = new System.Drawing.Point(213, 370);
            this.fldCompetitionName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.fldCompetitionName.Name = "fldCompetitionName";
            this.fldCompetitionName.Size = new System.Drawing.Size(591, 38);
            this.fldCompetitionName.TabIndex = 9;
            this.fldCompetitionName.TextChanged += new System.EventHandler(this.fldCompetitionName_TextChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(213, 432);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(261, 57);
            this.btnCreate.TabIndex = 11;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(213, 143);
            this.btnDel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(261, 57);
            this.btnDel.TabIndex = 29;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // CompetitionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fldCompetitionName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnUse);
            this.Controls.Add(this.fldCompetition);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "CompetitionControl";
            this.Size = new System.Drawing.Size(1600, 954);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox fldCompetition;
        private System.Windows.Forms.Button btnUse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox fldCompetitionName;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDel;
    }
}
