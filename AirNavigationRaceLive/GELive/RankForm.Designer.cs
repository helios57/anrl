namespace GELive
{
    partial class RankForm
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
            this.TestRanking = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rng1Name = new System.Windows.Forms.Label();
            this.rng2Name = new System.Windows.Forms.Label();
            this.rng3Name = new System.Windows.Forms.Label();
            this.rng4Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rng1Punkte = new System.Windows.Forms.Label();
            this.rng2Punkte = new System.Windows.Forms.Label();
            this.rng3Punkte = new System.Windows.Forms.Label();
            this.rng4Punkte = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TestRanking
            // 
            this.TestRanking.Location = new System.Drawing.Point(655, 580);
            this.TestRanking.Name = "TestRanking";
            this.TestRanking.Size = new System.Drawing.Size(75, 23);
            this.TestRanking.TabIndex = 5;
            this.TestRanking.Text = "Test";
            this.TestRanking.UseVisualStyleBackColor = true;
            this.TestRanking.Click += new System.EventHandler(this.TestRanking_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(319, 76);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rangliste";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.74892F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.25108F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Controls.Add(this.rng4Punkte, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.rng3Punkte, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.rng2Punkte, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.rng1Punkte, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rng1Name, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.rng2Name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rng3Name, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.rng4Name, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(53, 141);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(583, 374);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // rng1Name
            // 
            this.rng1Name.AutoSize = true;
            this.rng1Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng1Name.Location = new System.Drawing.Point(80, 0);
            this.rng1Name.Name = "rng1Name";
            this.rng1Name.Size = new System.Drawing.Size(0, 46);
            this.rng1Name.TabIndex = 0;
            // 
            // rng2Name
            // 
            this.rng2Name.AutoSize = true;
            this.rng2Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng2Name.Location = new System.Drawing.Point(80, 93);
            this.rng2Name.Name = "rng2Name";
            this.rng2Name.Size = new System.Drawing.Size(0, 46);
            this.rng2Name.TabIndex = 1;
            // 
            // rng3Name
            // 
            this.rng3Name.AutoSize = true;
            this.rng3Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng3Name.Location = new System.Drawing.Point(80, 186);
            this.rng3Name.Name = "rng3Name";
            this.rng3Name.Size = new System.Drawing.Size(0, 46);
            this.rng3Name.TabIndex = 2;
            // 
            // rng4Name
            // 
            this.rng4Name.AutoSize = true;
            this.rng4Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng4Name.Location = new System.Drawing.Point(80, 279);
            this.rng4Name.Name = "rng4Name";
            this.rng4Name.Size = new System.Drawing.Size(0, 46);
            this.rng4Name.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "1.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "2.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "3.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "4.";
            // 
            // rng1Punkte
            // 
            this.rng1Punkte.AutoSize = true;
            this.rng1Punkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng1Punkte.Location = new System.Drawing.Point(441, 0);
            this.rng1Punkte.Name = "rng1Punkte";
            this.rng1Punkte.Size = new System.Drawing.Size(0, 46);
            this.rng1Punkte.TabIndex = 8;
            // 
            // rng2Punkte
            // 
            this.rng2Punkte.AutoSize = true;
            this.rng2Punkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng2Punkte.Location = new System.Drawing.Point(441, 93);
            this.rng2Punkte.Name = "rng2Punkte";
            this.rng2Punkte.Size = new System.Drawing.Size(0, 46);
            this.rng2Punkte.TabIndex = 9;
            // 
            // rng3Punkte
            // 
            this.rng3Punkte.AutoSize = true;
            this.rng3Punkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng3Punkte.Location = new System.Drawing.Point(441, 186);
            this.rng3Punkte.Name = "rng3Punkte";
            this.rng3Punkte.Size = new System.Drawing.Size(0, 46);
            this.rng3Punkte.TabIndex = 10;
            // 
            // rng4Punkte
            // 
            this.rng4Punkte.AutoSize = true;
            this.rng4Punkte.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rng4Punkte.Location = new System.Drawing.Point(441, 279);
            this.rng4Punkte.Name = "rng4Punkte";
            this.rng4Punkte.Size = new System.Drawing.Size(0, 46);
            this.rng4Punkte.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 547);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(556, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Dieses Ranking ist nur provisorisch und besitzt keine Gültigkeit!";
            // 
            // RankForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 605);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TestRanking);
            this.Name = "RankForm";
            this.Text = "RankingForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestRanking;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label rng1Name;
        private System.Windows.Forms.Label rng2Name;
        private System.Windows.Forms.Label rng3Name;
        private System.Windows.Forms.Label rng4Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rng4Punkte;
        private System.Windows.Forms.Label rng3Punkte;
        private System.Windows.Forms.Label rng2Punkte;
        private System.Windows.Forms.Label rng1Punkte;
        private System.Windows.Forms.Label label6;
    }
}