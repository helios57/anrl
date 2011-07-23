namespace WindowsFormsApplication1
{
    partial class CompetitorForm
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
            this.compGroupName = new System.Windows.Forms.GroupBox();
            this.compCountry = new System.Windows.Forms.TextBox();
            this.lblLand = new System.Windows.Forms.Label();
            this.compAcCallsign = new System.Windows.Forms.TextBox();
            this.compButtonSubmit = new System.Windows.Forms.Button();
            this.compNavigatorLastName = new System.Windows.Forms.TextBox();
            this.compNavigatorFirstName = new System.Windows.Forms.TextBox();
            this.compButtonCancel = new System.Windows.Forms.Button();
            this.compPilotLastname = new System.Windows.Forms.TextBox();
            this.compPilotFirstName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFlugzeug = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNachname = new System.Windows.Forms.Label();
            this.lblVorname = new System.Windows.Forms.Label();
            this.compGroupName.SuspendLayout();
            this.SuspendLayout();
            // 
            // compGroupName
            // 
            this.compGroupName.Controls.Add(this.compCountry);
            this.compGroupName.Controls.Add(this.lblLand);
            this.compGroupName.Controls.Add(this.compAcCallsign);
            this.compGroupName.Controls.Add(this.compButtonSubmit);
            this.compGroupName.Controls.Add(this.compNavigatorLastName);
            this.compGroupName.Controls.Add(this.compNavigatorFirstName);
            this.compGroupName.Controls.Add(this.compButtonCancel);
            this.compGroupName.Controls.Add(this.compPilotLastname);
            this.compGroupName.Controls.Add(this.compPilotFirstName);
            this.compGroupName.Controls.Add(this.label2);
            this.compGroupName.Controls.Add(this.lblFlugzeug);
            this.compGroupName.Controls.Add(this.label1);
            this.compGroupName.Controls.Add(this.lblNachname);
            this.compGroupName.Controls.Add(this.lblVorname);
            this.compGroupName.Location = new System.Drawing.Point(4, 5);
            this.compGroupName.Name = "compGroupName";
            this.compGroupName.Size = new System.Drawing.Size(255, 208);
            this.compGroupName.TabIndex = 8;
            this.compGroupName.TabStop = false;
            // 
            // compCountry
            // 
            this.compCountry.Location = new System.Drawing.Point(129, 149);
            this.compCountry.Name = "compCountry";
            this.compCountry.Size = new System.Drawing.Size(120, 20);
            this.compCountry.TabIndex = 5;
            // 
            // lblLand
            // 
            this.lblLand.AutoSize = true;
            this.lblLand.Location = new System.Drawing.Point(81, 152);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(42, 13);
            this.lblLand.TabIndex = 8;
            // 
            // compAcCallsign
            // 
            this.compAcCallsign.Location = new System.Drawing.Point(129, 19);
            this.compAcCallsign.Name = "compAcCallsign";
            this.compAcCallsign.Size = new System.Drawing.Size(120, 20);
            this.compAcCallsign.TabIndex = 0;
            // 
            // compButtonSubmit
            // 
            this.compButtonSubmit.Location = new System.Drawing.Point(193, 175);
            this.compButtonSubmit.Name = "compButtonSubmit";
            this.compButtonSubmit.Size = new System.Drawing.Size(56, 23);
            this.compButtonSubmit.TabIndex = 7;
            this.compButtonSubmit.UseVisualStyleBackColor = true;
            this.compButtonSubmit.Click += new System.EventHandler(this.compButtonSubmit_Click);
            // 
            // compNavigatorLastName
            // 
            this.compNavigatorLastName.Location = new System.Drawing.Point(129, 123);
            this.compNavigatorLastName.Name = "compNavigatorLastName";
            this.compNavigatorLastName.Size = new System.Drawing.Size(120, 20);
            this.compNavigatorLastName.TabIndex = 4;
            // 
            // compNavigatorFirstName
            // 
            this.compNavigatorFirstName.Location = new System.Drawing.Point(129, 97);
            this.compNavigatorFirstName.Name = "compNavigatorFirstName";
            this.compNavigatorFirstName.Size = new System.Drawing.Size(120, 20);
            this.compNavigatorFirstName.TabIndex = 3;
            // 
            // compButtonCancel
            // 
            this.compButtonCancel.Location = new System.Drawing.Point(129, 175);
            this.compButtonCancel.Name = "compButtonCancel";
            this.compButtonCancel.Size = new System.Drawing.Size(56, 23);
            this.compButtonCancel.TabIndex = 6;
            this.compButtonCancel.UseVisualStyleBackColor = true;
            this.compButtonCancel.Click += new System.EventHandler(this.compAddButtonCancel_Click);
            // 
            // compPilotLastname
            // 
            this.compPilotLastname.Location = new System.Drawing.Point(129, 71);
            this.compPilotLastname.Name = "compPilotLastname";
            this.compPilotLastname.Size = new System.Drawing.Size(120, 20);
            this.compPilotLastname.TabIndex = 2;
            // 
            // compPilotFirstName
            // 
            this.compPilotFirstName.Location = new System.Drawing.Point(129, 45);
            this.compPilotFirstName.Name = "compPilotFirstName";
            this.compPilotFirstName.Size = new System.Drawing.Size(120, 20);
            this.compPilotFirstName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 2;
            // 
            // lblFlugzeug
            // 
            this.lblFlugzeug.AutoSize = true;
            this.lblFlugzeug.Location = new System.Drawing.Point(66, 22);
            this.lblFlugzeug.Name = "lblFlugzeug";
            this.lblFlugzeug.Size = new System.Drawing.Size(57, 13);
            this.lblFlugzeug.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            // 
            // lblNachname
            // 
            this.lblNachname.AutoSize = true;
            this.lblNachname.Location = new System.Drawing.Point(49, 74);
            this.lblNachname.Name = "lblNachname";
            this.lblNachname.Size = new System.Drawing.Size(74, 13);
            this.lblNachname.TabIndex = 2;
            // 
            // lblVorname
            // 
            this.lblVorname.AutoSize = true;
            this.lblVorname.Location = new System.Drawing.Point(49, 48);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(74, 13);
            this.lblVorname.TabIndex = 0;
            // 
            // CompetitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 221);
            this.ControlBox = false;
            this.Controls.Add(this.compGroupName);
            this.Name = "CompetitorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.competitorForm_Load);
            this.compGroupName.ResumeLayout(false);
            this.compGroupName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox compGroupName;
        private System.Windows.Forms.Button compButtonSubmit;
        private System.Windows.Forms.Label lblLand;
        private System.Windows.Forms.Label lblFlugzeug;
        private System.Windows.Forms.Label lblNachname;
        private System.Windows.Forms.Label lblVorname;
        private System.Windows.Forms.Button compButtonCancel;
        private System.Windows.Forms.TextBox compCountry;
        private System.Windows.Forms.TextBox compAcCallsign;
        private System.Windows.Forms.TextBox compPilotLastname;
        private System.Windows.Forms.TextBox compPilotFirstName;
        private System.Windows.Forms.TextBox compNavigatorLastName;
        private System.Windows.Forms.TextBox compNavigatorFirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}