namespace ANR
{
    partial class GroupMonster
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
            this.raceCrewList = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label30 = new System.Windows.Forms.Label();
            this.raceCompetitorsCmbGroupCompetitorsBy = new System.Windows.Forms.ComboBox();
            this.raceCompetitorsTreeViewCompetitors = new System.Windows.Forms.TreeView();
            this.raceCompetitorsCmdApplyCompetitorGrouping = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.raceGroupsTxtNumberOfAssignedCompetitors = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.raceGroupsTxtNumberOfGroups = new System.Windows.Forms.TextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.raceGroupsListBoxGroups = new System.Windows.Forms.ListBox();
            this.button10 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.raceGroupsListBoxGroupCompetitorRouteAssignment = new System.Windows.Forms.ListBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.maskedTextBox7 = new System.Windows.Forms.MaskedTextBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.maskedTextBox6 = new System.Windows.Forms.MaskedTextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.raceCrewList.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // raceCrewList
            // 
            this.raceCrewList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raceCrewList.Controls.Add(this.splitContainer2);
            this.raceCrewList.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ANR.Properties.Settings.Default, "raceCrewList", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.raceCrewList.Location = new System.Drawing.Point(3, 17);
            this.raceCrewList.Name = "raceCrewList";
            this.raceCrewList.Size = new System.Drawing.Size(1122, 503);
            this.raceCrewList.TabIndex = 1;
            this.raceCrewList.TabStop = false;
            this.raceCrewList.Text = global::ANR.Properties.Settings.Default.raceCrewList;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(7, 19);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(1109, 478);
            this.splitContainer2.SplitterDistance = 453;
            this.splitContainer2.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.raceCompetitorsCmbGroupCompetitorsBy);
            this.groupBox1.Controls.Add(this.raceCompetitorsTreeViewCompetitors);
            this.groupBox1.Controls.Add(this.raceCompetitorsCmdApplyCompetitorGrouping);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(453, 478);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Competitors";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(279, 436);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Create Group";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(279, 406);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(9, 406);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(264, 52);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 24);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(50, 13);
            this.label30.TabIndex = 3;
            this.label30.Text = "Group by";
            // 
            // raceCompetitorsCmbGroupCompetitorsBy
            // 
            this.raceCompetitorsCmbGroupCompetitorsBy.FormattingEnabled = true;
            this.raceCompetitorsCmbGroupCompetitorsBy.Location = new System.Drawing.Point(62, 19);
            this.raceCompetitorsCmbGroupCompetitorsBy.Name = "raceCompetitorsCmbGroupCompetitorsBy";
            this.raceCompetitorsCmbGroupCompetitorsBy.Size = new System.Drawing.Size(235, 21);
            this.raceCompetitorsCmbGroupCompetitorsBy.TabIndex = 2;
            // 
            // raceCompetitorsTreeViewCompetitors
            // 
            this.raceCompetitorsTreeViewCompetitors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.raceCompetitorsTreeViewCompetitors.Location = new System.Drawing.Point(7, 46);
            this.raceCompetitorsTreeViewCompetitors.Name = "raceCompetitorsTreeViewCompetitors";
            this.raceCompetitorsTreeViewCompetitors.Size = new System.Drawing.Size(435, 368);
            this.raceCompetitorsTreeViewCompetitors.TabIndex = 1;
            // 
            // raceCompetitorsCmdApplyCompetitorGrouping
            // 
            this.raceCompetitorsCmdApplyCompetitorGrouping.Location = new System.Drawing.Point(303, 19);
            this.raceCompetitorsCmdApplyCompetitorGrouping.Name = "raceCompetitorsCmdApplyCompetitorGrouping";
            this.raceCompetitorsCmdApplyCompetitorGrouping.Size = new System.Drawing.Size(75, 23);
            this.raceCompetitorsCmdApplyCompetitorGrouping.TabIndex = 0;
            this.raceCompetitorsCmdApplyCompetitorGrouping.Text = "Apply";
            this.raceCompetitorsCmdApplyCompetitorGrouping.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.splitContainer3);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 475);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Groups";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox8);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBox9);
            this.splitContainer3.Panel2.Controls.Add(this.button10);
            this.splitContainer3.Panel2.Controls.Add(this.button16);
            this.splitContainer3.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer3.Panel2.Controls.Add(this.button9);
            this.splitContainer3.Size = new System.Drawing.Size(644, 456);
            this.splitContainer3.SplitterDistance = 49;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label41);
            this.groupBox8.Controls.Add(this.raceGroupsTxtNumberOfAssignedCompetitors);
            this.groupBox8.Controls.Add(this.label42);
            this.groupBox8.Controls.Add(this.raceGroupsTxtNumberOfGroups);
            this.groupBox8.Location = new System.Drawing.Point(6, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(538, 40);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 16);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(93, 13);
            this.label41.TabIndex = 0;
            this.label41.Text = "Number of Groups";
            // 
            // raceGroupsTxtNumberOfAssignedCompetitors
            // 
            this.raceGroupsTxtNumberOfAssignedCompetitors.Location = new System.Drawing.Point(390, 13);
            this.raceGroupsTxtNumberOfAssignedCompetitors.Name = "raceGroupsTxtNumberOfAssignedCompetitors";
            this.raceGroupsTxtNumberOfAssignedCompetitors.ReadOnly = true;
            this.raceGroupsTxtNumberOfAssignedCompetitors.Size = new System.Drawing.Size(63, 20);
            this.raceGroupsTxtNumberOfAssignedCompetitors.TabIndex = 3;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(176, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(208, 13);
            this.label42.TabIndex = 1;
            this.label42.Text = "Number of Competitors assigned to Groups";
            // 
            // raceGroupsTxtNumberOfGroups
            // 
            this.raceGroupsTxtNumberOfGroups.Location = new System.Drawing.Point(105, 13);
            this.raceGroupsTxtNumberOfGroups.Name = "raceGroupsTxtNumberOfGroups";
            this.raceGroupsTxtNumberOfGroups.ReadOnly = true;
            this.raceGroupsTxtNumberOfGroups.Size = new System.Drawing.Size(65, 20);
            this.raceGroupsTxtNumberOfGroups.TabIndex = 2;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.raceGroupsListBoxGroups);
            this.groupBox9.Location = new System.Drawing.Point(4, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(259, 340);
            this.groupBox9.TabIndex = 7;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Groups and Members";
            // 
            // raceGroupsListBoxGroups
            // 
            this.raceGroupsListBoxGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.raceGroupsListBoxGroups.FormattingEnabled = true;
            this.raceGroupsListBoxGroups.Location = new System.Drawing.Point(3, 16);
            this.raceGroupsListBoxGroups.Name = "raceGroupsListBoxGroups";
            this.raceGroupsListBoxGroups.Size = new System.Drawing.Size(253, 316);
            this.raceGroupsListBoxGroups.TabIndex = 2;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.Location = new System.Drawing.Point(9, 363);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(114, 23);
            this.button10.TabIndex = 5;
            this.button10.Text = "Add new Group";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button16.Location = new System.Drawing.Point(129, 363);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(134, 23);
            this.button16.TabIndex = 6;
            this.button16.Text = "Remove Selected Group";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.raceGroupsListBoxGroupCompetitorRouteAssignment);
            this.groupBox3.Controls.Add(this.label38);
            this.groupBox3.Controls.Add(this.label40);
            this.groupBox3.Controls.Add(this.maskedTextBox7);
            this.groupBox3.Controls.Add(this.comboBox8);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.label36);
            this.groupBox3.Controls.Add(this.label34);
            this.groupBox3.Controls.Add(this.maskedTextBox6);
            this.groupBox3.Controls.Add(this.label39);
            this.groupBox3.Controls.Add(this.label35);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.comboBox7);
            this.groupBox3.Location = new System.Drawing.Point(363, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(278, 353);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Routes";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(251, 256);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(21, 73);
            this.button7.TabIndex = 14;
            this.button7.Text = "down -";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(251, 158);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 92);
            this.button1.TabIndex = 13;
            this.button1.Text = "+ up";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // raceGroupsListBoxGroupCompetitorRouteAssignment
            // 
            this.raceGroupsListBoxGroupCompetitorRouteAssignment.FormattingEnabled = true;
            this.raceGroupsListBoxGroupCompetitorRouteAssignment.Location = new System.Drawing.Point(12, 158);
            this.raceGroupsListBoxGroupCompetitorRouteAssignment.Name = "raceGroupsListBoxGroupCompetitorRouteAssignment";
            this.raceGroupsListBoxGroupCompetitorRouteAssignment.Size = new System.Drawing.Size(233, 173);
            this.raceGroupsListBoxGroupCompetitorRouteAssignment.TabIndex = 12;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(133, 121);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(30, 13);
            this.label38.TabIndex = 8;
            this.label38.Text = "(sec)";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(9, 72);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(46, 13);
            this.label40.TabIndex = 11;
            this.label40.Text = "Runway";
            // 
            // maskedTextBox7
            // 
            this.maskedTextBox7.Location = new System.Drawing.Point(93, 118);
            this.maskedTextBox7.Mask = "0000";
            this.maskedTextBox7.Name = "maskedTextBox7";
            this.maskedTextBox7.Size = new System.Drawing.Size(34, 20);
            this.maskedTextBox7.TabIndex = 7;
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(93, 69);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(142, 21);
            this.comboBox8.TabIndex = 9;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(9, 121);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(67, 13);
            this.label37.TabIndex = 6;
            this.label37.Text = "Start Interval";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(133, 97);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(50, 13);
            this.label36.TabIndex = 4;
            this.label36.Text = "(HH:MM)";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 25);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(67, 13);
            this.label34.TabIndex = 0;
            this.label34.Text = "Group Name";
            // 
            // maskedTextBox6
            // 
            this.maskedTextBox6.Location = new System.Drawing.Point(93, 94);
            this.maskedTextBox6.Mask = "90:00";
            this.maskedTextBox6.Name = "maskedTextBox6";
            this.maskedTextBox6.Size = new System.Drawing.Size(34, 20);
            this.maskedTextBox6.TabIndex = 3;
            this.maskedTextBox6.ValidatingType = typeof(System.DateTime);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 49);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(49, 13);
            this.label39.TabIndex = 10;
            this.label39.Text = "Parcours";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(9, 97);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(70, 13);
            this.label35.TabIndex = 2;
            this.label35.Text = "Takeoff Time";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(93, 22);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(142, 20);
            this.textBox12.TabIndex = 1;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(93, 46);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(142, 21);
            this.comboBox7.TabIndex = 5;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.Location = new System.Drawing.Point(472, 363);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(163, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "Export Startlist for all Groups";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // GroupMonster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.raceCrewList);
            this.Name = "GroupMonster";
            this.Size = new System.Drawing.Size(1206, 568);
            this.raceCrewList.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox raceCrewList;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox raceCompetitorsCmbGroupCompetitorsBy;
        private System.Windows.Forms.TreeView raceCompetitorsTreeViewCompetitors;
        private System.Windows.Forms.Button raceCompetitorsCmdApplyCompetitorGrouping;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox raceGroupsTxtNumberOfAssignedCompetitors;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox raceGroupsTxtNumberOfGroups;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ListBox raceGroupsListBoxGroups;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox raceGroupsListBoxGroupCompetitorRouteAssignment;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.MaskedTextBox maskedTextBox7;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.MaskedTextBox maskedTextBox6;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Button button9;
    }
}
