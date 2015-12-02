namespace WPUpCheck
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.plugincheck = new System.Windows.Forms.Label();
            this.corecheck = new System.Windows.Forms.Label();
            this.themecheck = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelNextRun = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordPressSitesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.targetSiteLabel = new System.Windows.Forms.LinkLabel();
            this.countdownBox = new System.Windows.Forms.Label();
            this.imgCore = new System.Windows.Forms.PictureBox();
            this.imgPlugins = new System.Windows.Forms.PictureBox();
            this.imgThemes = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlugins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgThemes)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 21);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check for WordPress updates";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plugincheck
            // 
            this.plugincheck.AutoSize = true;
            this.plugincheck.Location = new System.Drawing.Point(238, 67);
            this.plugincheck.Name = "plugincheck";
            this.plugincheck.Size = new System.Drawing.Size(47, 13);
            this.plugincheck.TabIndex = 1;
            this.plugincheck.Text = "Plugins?";
            this.plugincheck.Click += new System.EventHandler(this.label1_Click);
            // 
            // corecheck
            // 
            this.corecheck.AutoSize = true;
            this.corecheck.Location = new System.Drawing.Point(66, 67);
            this.corecheck.Name = "corecheck";
            this.corecheck.Size = new System.Drawing.Size(35, 13);
            this.corecheck.TabIndex = 2;
            this.corecheck.Text = "Core?";
            // 
            // themecheck
            // 
            this.themecheck.AutoSize = true;
            this.themecheck.Location = new System.Drawing.Point(397, 67);
            this.themecheck.Name = "themecheck";
            this.themecheck.Size = new System.Drawing.Size(51, 13);
            this.themecheck.TabIndex = 3;
            this.themecheck.Text = "Themes?";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(272, 108);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(73, 10);
            this.progressBar.TabIndex = 4;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // labelNextRun
            // 
            this.labelNextRun.AutoSize = true;
            this.labelNextRun.Location = new System.Drawing.Point(23, 142);
            this.labelNextRun.Name = "labelNextRun";
            this.labelNextRun.Size = new System.Drawing.Size(117, 13);
            this.labelNextRun.TabIndex = 6;
            this.labelNextRun.Text = "No next run scheduled.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(589, 24);
            this.menuStrip1.TabIndex = 10;
            // 
            // optionsToolStripMenuItem2
            // 
            this.optionsToolStripMenuItem2.Name = "optionsToolStripMenuItem2";
            this.optionsToolStripMenuItem2.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem2.Text = "Options";
            this.optionsToolStripMenuItem2.Click += new System.EventHandler(this.optionsToolStripMenuItem2_Click);
            // 
            // optionsToolStripMenuItem1
            // 
            this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
            this.optionsToolStripMenuItem1.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem1.Text = "Options";
            this.optionsToolStripMenuItem1.Click += new System.EventHandler(this.optionsToolStripMenuItem1_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // wordPressSitesToolStripMenuItem
            // 
            this.wordPressSitesToolStripMenuItem.Name = "wordPressSitesToolStripMenuItem";
            this.wordPressSitesToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.wordPressSitesToolStripMenuItem.Text = "WordPress Sites";
            this.wordPressSitesToolStripMenuItem.Click += new System.EventHandler(this.wordPressSitesToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(201, 103);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(65, 21);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipText = "AWPUpdate";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Restore";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // targetSiteLabel
            // 
            this.targetSiteLabel.AutoSize = true;
            this.targetSiteLabel.Location = new System.Drawing.Point(23, 30);
            this.targetSiteLabel.Name = "targetSiteLabel";
            this.targetSiteLabel.Size = new System.Drawing.Size(16, 13);
            this.targetSiteLabel.TabIndex = 8;
            this.targetSiteLabel.TabStop = true;
            this.targetSiteLabel.Text = "---";
            this.targetSiteLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.targetSiteLabel_LinkClicked);
            // 
            // countdownBox
            // 
            this.countdownBox.AutoSize = true;
            this.countdownBox.Location = new System.Drawing.Point(198, 142);
            this.countdownBox.Name = "countdownBox";
            this.countdownBox.Size = new System.Drawing.Size(0, 13);
            this.countdownBox.TabIndex = 9;
            // 
            // imgCore
            // 
            this.imgCore.Image = global::WPUpCheck.Properties.Resources.error;
            this.imgCore.Location = new System.Drawing.Point(26, 58);
            this.imgCore.Name = "imgCore";
            this.imgCore.Size = new System.Drawing.Size(33, 30);
            this.imgCore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgCore.TabIndex = 11;
            this.imgCore.TabStop = false;
            this.imgCore.Click += new System.EventHandler(this.imgCore_Click);
            // 
            // imgPlugins
            // 
            this.imgPlugins.Image = global::WPUpCheck.Properties.Resources.error;
            this.imgPlugins.Location = new System.Drawing.Point(197, 58);
            this.imgPlugins.Name = "imgPlugins";
            this.imgPlugins.Size = new System.Drawing.Size(33, 30);
            this.imgPlugins.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgPlugins.TabIndex = 12;
            this.imgPlugins.TabStop = false;
            // 
            // imgThemes
            // 
            this.imgThemes.Image = global::WPUpCheck.Properties.Resources.error;
            this.imgThemes.Location = new System.Drawing.Point(356, 58);
            this.imgThemes.Name = "imgThemes";
            this.imgThemes.Size = new System.Drawing.Size(33, 30);
            this.imgThemes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgThemes.TabIndex = 13;
            this.imgThemes.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 185);
            this.Controls.Add(this.imgThemes);
            this.Controls.Add(this.imgPlugins);
            this.Controls.Add(this.imgCore);
            this.Controls.Add(this.countdownBox);
            this.Controls.Add(this.targetSiteLabel);
            this.Controls.Add(this.labelNextRun);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.themecheck);
            this.Controls.Add(this.corecheck);
            this.Controls.Add(this.plugincheck);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "WPUpCheck";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgCore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlugins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgThemes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label plugincheck;
        private System.Windows.Forms.Label corecheck;
        private System.Windows.Forms.Label themecheck;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelNextRun;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordPressSitesToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.LinkLabel targetSiteLabel;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem1;
        private System.Windows.Forms.Label countdownBox;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem2;
        private System.Windows.Forms.PictureBox imgCore;
        private System.Windows.Forms.PictureBox imgPlugins;
        private System.Windows.Forms.PictureBox imgThemes;
    }
}

