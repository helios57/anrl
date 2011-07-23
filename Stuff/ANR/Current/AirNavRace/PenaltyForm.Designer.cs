namespace WindowsFormsApplication1
{
    partial class PenaltyForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.penGroupName = new System.Windows.Forms.GroupBox();
            this.penButtonSubmit = new System.Windows.Forms.Button();
            this.penFormCommentTextBox = new System.Windows.Forms.TextBox();
            this.penButtonCancel = new System.Windows.Forms.Button();
            this.penFormPenPointsTextBox = new System.Windows.Forms.TextBox();
            this.penFormPenPointsLabel = new System.Windows.Forms.Label();
            this.penFormCommentLabel = new System.Windows.Forms.Label();
            this.penGroupName.SuspendLayout();
            this.SuspendLayout();
            // 
            // penGroupName
            // 
            this.penGroupName.Controls.Add(this.penButtonSubmit);
            this.penGroupName.Controls.Add(this.penFormCommentTextBox);
            this.penGroupName.Controls.Add(this.penButtonCancel);
            this.penGroupName.Controls.Add(this.penFormPenPointsTextBox);
            this.penGroupName.Controls.Add(this.penFormPenPointsLabel);
            this.penGroupName.Controls.Add(this.penFormCommentLabel);
            this.penGroupName.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "penGroupBoxTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.penGroupName.Location = new System.Drawing.Point(4, 5);
            this.penGroupName.Name = "penGroupName";
            this.penGroupName.Size = new System.Drawing.Size(446, 153);
            this.penGroupName.TabIndex = 8;
            this.penGroupName.TabStop = false;
            this.penGroupName.Text = global::WindowsFormsApplication1.Properties.Settings.Default.penGroupBoxTitle;
            // 
            // penButtonSubmit
            // 
            this.penButtonSubmit.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "compSave", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.penButtonSubmit.Location = new System.Drawing.Point(384, 123);
            this.penButtonSubmit.Name = "penButtonSubmit";
            this.penButtonSubmit.Size = new System.Drawing.Size(56, 23);
            this.penButtonSubmit.TabIndex = 7;
            this.penButtonSubmit.Text = global::WindowsFormsApplication1.Properties.Settings.Default.compSave;
            this.penButtonSubmit.UseVisualStyleBackColor = true;
            this.penButtonSubmit.Click += new System.EventHandler(this.compButtonSubmit_Click);
            // 
            // penFormCommentTextBox
            // 
            this.penFormCommentTextBox.Location = new System.Drawing.Point(11, 97);
            this.penFormCommentTextBox.Name = "penFormCommentTextBox";
            this.penFormCommentTextBox.Size = new System.Drawing.Size(429, 20);
            this.penFormCommentTextBox.TabIndex = 3;
            // 
            // penButtonCancel
            // 
            this.penButtonCancel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "compCancel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.penButtonCancel.Location = new System.Drawing.Point(320, 123);
            this.penButtonCancel.Name = "penButtonCancel";
            this.penButtonCancel.Size = new System.Drawing.Size(56, 23);
            this.penButtonCancel.TabIndex = 6;
            this.penButtonCancel.Text = global::WindowsFormsApplication1.Properties.Settings.Default.compCancel;
            this.penButtonCancel.UseVisualStyleBackColor = true;
            this.penButtonCancel.Click += new System.EventHandler(this.compAddButtonCancel_Click);
            // 
            // penFormPenPointsTextBox
            // 
            this.penFormPenPointsTextBox.Location = new System.Drawing.Point(11, 45);
            this.penFormPenPointsTextBox.Name = "penFormPenPointsTextBox";
            this.penFormPenPointsTextBox.Size = new System.Drawing.Size(71, 20);
            this.penFormPenPointsTextBox.TabIndex = 1;
            // 
            // penFormPenPointsLabel
            // 
            this.penFormPenPointsLabel.AutoSize = true;
            this.penFormPenPointsLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "penFormPenaltyPoints", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.penFormPenPointsLabel.Location = new System.Drawing.Point(8, 22);
            this.penFormPenPointsLabel.Name = "penFormPenPointsLabel";
            this.penFormPenPointsLabel.Size = new System.Drawing.Size(72, 13);
            this.penFormPenPointsLabel.TabIndex = 6;
            this.penFormPenPointsLabel.Text = global::WindowsFormsApplication1.Properties.Settings.Default.penFormPenaltyPoints;
            // 
            // penFormCommentLabel
            // 
            this.penFormCommentLabel.AutoSize = true;
            this.penFormCommentLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "penFormComment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.penFormCommentLabel.Location = new System.Drawing.Point(8, 74);
            this.penFormCommentLabel.Name = "penFormCommentLabel";
            this.penFormCommentLabel.Size = new System.Drawing.Size(50, 13);
            this.penFormCommentLabel.TabIndex = 2;
            this.penFormCommentLabel.Text = global::WindowsFormsApplication1.Properties.Settings.Default.penFormComment;
            // 
            // PenaltyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 160);
            this.ControlBox = false;
            this.Controls.Add(this.penGroupName);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::WindowsFormsApplication1.Properties.Settings.Default, "penFormTitle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "PenaltyForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = global::WindowsFormsApplication1.Properties.Settings.Default.penFormTitle;
            this.Load += new System.EventHandler(this.competitorForm_Load);
            this.penGroupName.ResumeLayout(false);
            this.penGroupName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox penGroupName;
        private System.Windows.Forms.Button penButtonSubmit;
        private System.Windows.Forms.Label penFormPenPointsLabel;
        private System.Windows.Forms.Label penFormCommentLabel;
        private System.Windows.Forms.Button penButtonCancel;
        private System.Windows.Forms.TextBox penFormPenPointsTextBox;
        private System.Windows.Forms.TextBox penFormCommentTextBox;

    }
}