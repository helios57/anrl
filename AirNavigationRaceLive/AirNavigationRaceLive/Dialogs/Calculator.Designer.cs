namespace AirNavigationRaceLive.Dialogs
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            this.textEast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textNorth = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textLatitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textLongitude = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnToWGS = new System.Windows.Forms.Button();
            this.btnToCh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textEast
            // 
            this.textEast.Location = new System.Drawing.Point(79, 40);
            this.textEast.Name = "textEast";
            this.textEast.Size = new System.Drawing.Size(84, 20);
            this.textEast.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "East";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Swiss Coordinates (ch1903)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "WGS84 Coordinates";
            // 
            // textNorth
            // 
            this.textNorth.Location = new System.Drawing.Point(79, 66);
            this.textNorth.Name = "textNorth";
            this.textNorth.Size = new System.Drawing.Size(84, 20);
            this.textNorth.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "North";
            // 
            // textLatitude
            // 
            this.textLatitude.Location = new System.Drawing.Point(79, 143);
            this.textLatitude.Name = "textLatitude";
            this.textLatitude.Size = new System.Drawing.Size(84, 20);
            this.textLatitude.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Latitude";
            // 
            // textLongitude
            // 
            this.textLongitude.Location = new System.Drawing.Point(79, 117);
            this.textLongitude.Name = "textLongitude";
            this.textLongitude.Size = new System.Drawing.Size(84, 20);
            this.textLongitude.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Longitude";
            // 
            // btnToWGS
            // 
            this.btnToWGS.Location = new System.Drawing.Point(169, 40);
            this.btnToWGS.Name = "btnToWGS";
            this.btnToWGS.Size = new System.Drawing.Size(56, 46);
            this.btnToWGS.TabIndex = 15;
            this.btnToWGS.Text = "To WGS84";
            this.btnToWGS.UseVisualStyleBackColor = true;
            this.btnToWGS.Click += new System.EventHandler(this.btnToWGS_Click);
            // 
            // btnToCh
            // 
            this.btnToCh.Location = new System.Drawing.Point(169, 117);
            this.btnToCh.Name = "btnToCh";
            this.btnToCh.Size = new System.Drawing.Size(56, 46);
            this.btnToCh.TabIndex = 16;
            this.btnToCh.Text = "To CH1903";
            this.btnToCh.UseVisualStyleBackColor = true;
            this.btnToCh.Click += new System.EventHandler(this.btnToCh_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 180);
            this.Controls.Add(this.btnToCh);
            this.Controls.Add(this.btnToWGS);
            this.Controls.Add(this.textLatitude);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textLongitude);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textNorth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEast);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textEast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textNorth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textLatitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textLongitude;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnToWGS;
        private System.Windows.Forms.Button btnToCh;
    }
}