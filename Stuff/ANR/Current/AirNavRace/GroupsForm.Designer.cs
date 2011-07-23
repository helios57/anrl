namespace ANR
{
    partial class GroupsForm
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
            this.groupAddGroup = new System.Windows.Forms.GroupBox();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdRemove = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.Button();
            this.groupCompGroupBox = new System.Windows.Forms.GroupBox();
            this.dataGridCompetitors = new System.Windows.Forms.DataGridView();
            this.groupAddGroup.SuspendLayout();
            this.groupCompGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAddGroup
            // 
            this.groupAddGroup.Controls.Add(this.cmdAdd);
            this.groupAddGroup.Controls.Add(this.cmdRemove);
            this.groupAddGroup.Controls.Add(this.listView1);
            this.groupAddGroup.Controls.Add(this.cmdCancel);
            this.groupAddGroup.Controls.Add(this.cmdSave);
            this.groupAddGroup.Controls.Add(this.groupCompGroupBox);
            this.groupAddGroup.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ANR.Properties.Settings.Default, "groupAddGroup", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupAddGroup.Location = new System.Drawing.Point(12, 12);
            this.groupAddGroup.Name = "groupAddGroup";
            this.groupAddGroup.Size = new System.Drawing.Size(806, 522);
            this.groupAddGroup.TabIndex = 0;
            this.groupAddGroup.TabStop = false;
            this.groupAddGroup.Text = global::ANR.Properties.Settings.Default.groupAddGroup;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Enabled = false;
            this.cmdAdd.Location = new System.Drawing.Point(253, 387);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(101, 23);
            this.cmdAdd.TabIndex = 5;
            this.cmdAdd.Text = "Add to Group";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdRemove
            // 
            this.cmdRemove.Enabled = false;
            this.cmdRemove.Location = new System.Drawing.Point(360, 386);
            this.cmdRemove.Name = "cmdRemove";
            this.cmdRemove.Size = new System.Drawing.Size(129, 23);
            this.cmdRemove.TabIndex = 4;
            this.cmdRemove.Text = "Remove from Group";
            this.cmdRemove.UseVisualStyleBackColor = true;
            this.cmdRemove.Click += new System.EventHandler(this.cmdRemove_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 415);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(787, 65);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(644, 493);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 2;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Location = new System.Drawing.Point(725, 493);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 1;
            this.cmdSave.Text = "Save";
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // groupCompGroupBox
            // 
            this.groupCompGroupBox.Controls.Add(this.dataGridCompetitors);
            this.groupCompGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ANR.Properties.Settings.Default, "groupAddComp", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.groupCompGroupBox.Location = new System.Drawing.Point(6, 19);
            this.groupCompGroupBox.Name = "groupCompGroupBox";
            this.groupCompGroupBox.Size = new System.Drawing.Size(794, 361);
            this.groupCompGroupBox.TabIndex = 0;
            this.groupCompGroupBox.TabStop = false;
            this.groupCompGroupBox.Text = global::ANR.Properties.Settings.Default.groupAddComp;
            // 
            // dataGridCompetitors
            // 
            this.dataGridCompetitors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridCompetitors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCompetitors.Location = new System.Drawing.Point(6, 19);
            this.dataGridCompetitors.Name = "dataGridCompetitors";
            this.dataGridCompetitors.Size = new System.Drawing.Size(782, 336);
            this.dataGridCompetitors.TabIndex = 0;
            this.dataGridCompetitors.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCompetitors_CellContentDoubleClick);
            this.dataGridCompetitors.SelectionChanged += new System.EventHandler(this.dataGridCompetitors_SelectionChanged);
            // 
            // GroupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 546);
            this.ControlBox = false;
            this.Controls.Add(this.groupAddGroup);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ANR.Properties.Settings.Default, "groupAddText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Name = "GroupsForm";
            this.Text = global::ANR.Properties.Settings.Default.groupAddText;
            this.Load += new System.EventHandler(this.GroupsForm_Load);
            this.groupAddGroup.ResumeLayout(false);
            this.groupCompGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCompetitors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAddGroup;
        private System.Windows.Forms.GroupBox groupCompGroupBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.DataGridView dataGridCompetitors;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdRemove;
    }
}