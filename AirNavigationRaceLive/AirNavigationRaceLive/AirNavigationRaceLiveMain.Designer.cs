﻿namespace AirNavigationRaceLive
{
    partial class AirNavigationRaceLiveMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AirNavigationRaceLiveMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.competitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromWorldfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromMapsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parcourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overviewZoomedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateSingleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pilotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualificationRoundsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplistFlightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toplistLandingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.individualToplistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addLandingResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adjustResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualisationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 691);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(956, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip";
            // 
            // StatusStripLabel
            // 
            this.StatusStripLabel.Name = "StatusStripLabel";
            this.StatusStripLabel.Size = new System.Drawing.Size(91, 17);
            this.StatusStripLabel.Text = "StatusStripLabel";
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.competitionToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.parcourToolStripMenuItem,
            this.pilotsToolStripMenuItem,
            this.teamsToolStripMenuItem,
            this.qualificationRoundsToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.resultsToolStripMenuItem,
            this.visualisationToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.creditsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(956, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "Menu";
            // 
            // competitionToolStripMenuItem
            // 
            this.competitionToolStripMenuItem.Name = "competitionToolStripMenuItem";
            this.competitionToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.competitionToolStripMenuItem.Text = "Competition";
            this.competitionToolStripMenuItem.Click += new System.EventHandler(this.competitionToolStripMenuItem1_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.legacyToolStripMenuItem,
            this.importFromWorldfileToolStripMenuItem,
            this.importFromMapsToolStripMenuItem});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.mapToolStripMenuItem.Text = "Maps";
            // 
            // legacyToolStripMenuItem
            // 
            this.legacyToolStripMenuItem.Name = "legacyToolStripMenuItem";
            this.legacyToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.legacyToolStripMenuItem.Text = "Legacy";
            this.legacyToolStripMenuItem.Click += new System.EventHandler(this.legacyToolStripMenuItem_Click);
            // 
            // importFromWorldfileToolStripMenuItem
            // 
            this.importFromWorldfileToolStripMenuItem.Name = "importFromWorldfileToolStripMenuItem";
            this.importFromWorldfileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importFromWorldfileToolStripMenuItem.Text = "Import from Worldfile";
            this.importFromWorldfileToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // importFromMapsToolStripMenuItem
            // 
            this.importFromMapsToolStripMenuItem.Name = "importFromMapsToolStripMenuItem";
            this.importFromMapsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importFromMapsToolStripMenuItem.Text = "Import from Maps";
            this.importFromMapsToolStripMenuItem.Click += new System.EventHandler(this.importFromMapsToolStripMenuItem_Click);
            // 
            // parcourToolStripMenuItem
            // 
            this.parcourToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overviewToolStripMenuItem,
            this.overviewZoomedToolStripMenuItem,
            this.generateToolStripMenuItem,
            this.importToolStripMenuItem,
            this.editToolStripMenuItem,
            this.generateSingleToolStripMenuItem});
            this.parcourToolStripMenuItem.Enabled = false;
            this.parcourToolStripMenuItem.Name = "parcourToolStripMenuItem";
            this.parcourToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.parcourToolStripMenuItem.Text = "Parcours";
            this.parcourToolStripMenuItem.Click += new System.EventHandler(this.parcourToolStripMenuItem_Click);
            // 
            // overviewToolStripMenuItem
            // 
            this.overviewToolStripMenuItem.Name = "overviewToolStripMenuItem";
            this.overviewToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.overviewToolStripMenuItem.Text = "Overview";
            this.overviewToolStripMenuItem.Click += new System.EventHandler(this.overviewToolStripMenuItem_Click);
            // 
            // overviewZoomedToolStripMenuItem
            // 
            this.overviewZoomedToolStripMenuItem.Name = "overviewZoomedToolStripMenuItem";
            this.overviewZoomedToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.overviewZoomedToolStripMenuItem.Text = "Overview Zoomed";
            this.overviewZoomedToolStripMenuItem.Click += new System.EventHandler(this.overviewZoomedToolStripMenuItem_Click);
            // 
            // generateToolStripMenuItem
            // 
            this.generateToolStripMenuItem.Name = "generateToolStripMenuItem";
            this.generateToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.generateToolStripMenuItem.Text = "Generate";
            this.generateToolStripMenuItem.Click += new System.EventHandler(this.generateToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // generateSingleToolStripMenuItem
            // 
            this.generateSingleToolStripMenuItem.Name = "generateSingleToolStripMenuItem";
            this.generateSingleToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.generateSingleToolStripMenuItem.Text = "Generate Single";
            this.generateSingleToolStripMenuItem.Click += new System.EventHandler(this.generateSingleToolStripMenuItem_Click);
            // 
            // pilotsToolStripMenuItem
            // 
            this.pilotsToolStripMenuItem.Enabled = false;
            this.pilotsToolStripMenuItem.Name = "pilotsToolStripMenuItem";
            this.pilotsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.pilotsToolStripMenuItem.Text = "Participants";
            this.pilotsToolStripMenuItem.Click += new System.EventHandler(this.pilotsToolStripMenuItem_Click);
            // 
            // teamsToolStripMenuItem
            // 
            this.teamsToolStripMenuItem.Enabled = false;
            this.teamsToolStripMenuItem.Name = "teamsToolStripMenuItem";
            this.teamsToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.teamsToolStripMenuItem.Text = "Crews";
            this.teamsToolStripMenuItem.Click += new System.EventHandler(this.teamsToolStripMenuItem_Click);
            // 
            // qualificationRoundsToolStripMenuItem
            // 
            this.qualificationRoundsToolStripMenuItem.Enabled = false;
            this.qualificationRoundsToolStripMenuItem.Name = "qualificationRoundsToolStripMenuItem";
            this.qualificationRoundsToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.qualificationRoundsToolStripMenuItem.Text = "Qualification Rounds";
            this.qualificationRoundsToolStripMenuItem.Click += new System.EventHandler(this.racesToolStripMenuItem_Click);
            // 
            // rulesToolStripMenuItem
            // 
            this.rulesToolStripMenuItem.Enabled = false;
            this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
            this.rulesToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.rulesToolStripMenuItem.Text = "Rules";
            this.rulesToolStripMenuItem.Visible = false;
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toplistToolStripMenuItem,
            this.toplistFlightToolStripMenuItem,
            this.toplistLandingToolStripMenuItem,
            this.individualToplistToolStripMenuItem,
            this.toolStripSeparator2,
            this.addLandingResultsToolStripMenuItem,
            this.adjustResultsToolStripMenuItem});
            this.resultsToolStripMenuItem.Enabled = false;
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.resultsToolStripMenuItem.Text = "Results";
            this.resultsToolStripMenuItem.Click += new System.EventHandler(this.resultsToolStripMenuItem_Click);
            // 
            // toplistToolStripMenuItem
            // 
            this.toplistToolStripMenuItem.Enabled = false;
            this.toplistToolStripMenuItem.Name = "toplistToolStripMenuItem";
            this.toplistToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toplistToolStripMenuItem.Text = "Toplist";
            this.toplistToolStripMenuItem.Visible = false;
            // 
            // toplistFlightToolStripMenuItem
            // 
            this.toplistFlightToolStripMenuItem.Enabled = false;
            this.toplistFlightToolStripMenuItem.Name = "toplistFlightToolStripMenuItem";
            this.toplistFlightToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toplistFlightToolStripMenuItem.Text = "Toplist Flight";
            this.toplistFlightToolStripMenuItem.Visible = false;
            // 
            // toplistLandingToolStripMenuItem
            // 
            this.toplistLandingToolStripMenuItem.Enabled = false;
            this.toplistLandingToolStripMenuItem.Name = "toplistLandingToolStripMenuItem";
            this.toplistLandingToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.toplistLandingToolStripMenuItem.Text = "Toplist Landing";
            this.toplistLandingToolStripMenuItem.Visible = false;
            // 
            // individualToplistToolStripMenuItem
            // 
            this.individualToplistToolStripMenuItem.Enabled = false;
            this.individualToplistToolStripMenuItem.Name = "individualToplistToolStripMenuItem";
            this.individualToplistToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.individualToplistToolStripMenuItem.Text = "Individual Toplist";
            this.individualToplistToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            this.toolStripSeparator2.Visible = false;
            // 
            // addLandingResultsToolStripMenuItem
            // 
            this.addLandingResultsToolStripMenuItem.Enabled = false;
            this.addLandingResultsToolStripMenuItem.Name = "addLandingResultsToolStripMenuItem";
            this.addLandingResultsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.addLandingResultsToolStripMenuItem.Text = "Add Landing Results";
            this.addLandingResultsToolStripMenuItem.Visible = false;
            this.addLandingResultsToolStripMenuItem.Click += new System.EventHandler(this.addLandingResultsToolStripMenuItem_Click);
            // 
            // adjustResultsToolStripMenuItem
            // 
            this.adjustResultsToolStripMenuItem.Enabled = false;
            this.adjustResultsToolStripMenuItem.Name = "adjustResultsToolStripMenuItem";
            this.adjustResultsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.adjustResultsToolStripMenuItem.Text = "Adjust Results";
            this.adjustResultsToolStripMenuItem.Visible = false;
            this.adjustResultsToolStripMenuItem.Click += new System.EventHandler(this.adjustResultsToolStripMenuItem_Click);
            // 
            // visualisationToolStripMenuItem
            // 
            this.visualisationToolStripMenuItem.Enabled = false;
            this.visualisationToolStripMenuItem.Name = "visualisationToolStripMenuItem";
            this.visualisationToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.visualisationToolStripMenuItem.Text = "Visualisation";
            this.visualisationToolStripMenuItem.Click += new System.EventHandler(this.visualisationToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.exportToolStripMenuItem.Text = "Import/Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(956, 667);
            this.MainPanel.TabIndex = 2;
            this.MainPanel.Resize += new System.EventHandler(this.MainPanel_Resize);
            // 
            // AirNavigationRaceLiveMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 713);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "AirNavigationRaceLiveMain";
            this.Text = "Air Navigation Race Scoring & Visualisation";
            this.Load += new System.EventHandler(this.AirNavigationRaceLive_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusStripLabel;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolStripMenuItem pilotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qualificationRoundsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualisationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem teamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parcourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplistToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplistFlightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toplistLandingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem individualToplistToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem addLandingResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adjustResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overviewZoomedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem competitionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromWorldfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromMapsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateSingleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
    }
}

