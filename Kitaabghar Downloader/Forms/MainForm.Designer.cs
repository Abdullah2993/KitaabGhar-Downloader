namespace KitaabgharDownloader
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bottomStrip = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.topStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.linkText = new System.Windows.Forms.ToolStripTextBox();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.infoButton = new System.Windows.Forms.ToolStripButton();
            this.logList = new System.Windows.Forms.ListBox();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.progress = new System.Windows.Forms.ProgressBar();
            this.bottomStrip.SuspendLayout();
            this.topStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomStrip
            // 
            this.bottomStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.bottomStrip.Location = new System.Drawing.Point(0, 213);
            this.bottomStrip.Name = "bottomStrip";
            this.bottomStrip.Size = new System.Drawing.Size(638, 22);
            this.bottomStrip.TabIndex = 0;
            this.bottomStrip.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.ForeColor = System.Drawing.SystemColors.Highlight;
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(165, 17);
            this.statusText.Text = "Please enter the link to the novel";
            // 
            // topStrip
            // 
            this.topStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.linkText,
            this.startButton,
            this.stopButton,
            this.toolStripSeparator1,
            this.settingsButton,
            this.toolStripSeparator2,
            this.infoButton});
            this.topStrip.Location = new System.Drawing.Point(0, 0);
            this.topStrip.Name = "topStrip";
            this.topStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.topStrip.Size = new System.Drawing.Size(638, 25);
            this.topStrip.TabIndex = 1;
            this.topStrip.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(50, 22);
            this.toolStripLabel1.Text = "Address:";
            // 
            // linkText
            // 
            this.linkText.Name = "linkText";
            this.linkText.Size = new System.Drawing.Size(425, 25);
            this.linkText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.linkText_KeyDown);
            // 
            // startButton
            // 
            this.startButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(23, 22);
            this.startButton.Text = "Start";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopButton.Image = ((System.Drawing.Image)(resources.GetObject("stopButton.Image")));
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 22);
            this.stopButton.Text = "Stop";
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // settingsButton
            // 
            this.settingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(23, 22);
            this.settingsButton.Text = "Settings";
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoButton.Image = ((System.Drawing.Image)(resources.GetObject("infoButton.Image")));
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(23, 22);
            this.infoButton.Text = "About";
            this.infoButton.Click += new System.EventHandler(this.infoButton_Click);
            // 
            // logList
            // 
            this.logList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logList.FormattingEnabled = true;
            this.logList.Location = new System.Drawing.Point(12, 28);
            this.logList.Name = "logList";
            this.logList.Size = new System.Drawing.Size(614, 160);
            this.logList.TabIndex = 2;
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipTitle = "Download Completed";
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "KitaabGhar Downloader";
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // progress
            // 
            this.progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progress.Location = new System.Drawing.Point(12, 194);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(614, 13);
            this.progress.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 235);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.logList);
            this.Controls.Add(this.topStrip);
            this.Controls.Add(this.bottomStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(646, 269);
            this.MinimumSize = new System.Drawing.Size(646, 269);
            this.Name = "MainForm";
            this.Text = "KitaabGhar Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.bottomStrip.ResumeLayout(false);
            this.bottomStrip.PerformLayout();
            this.topStrip.ResumeLayout(false);
            this.topStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip bottomStrip;
        private System.Windows.Forms.ToolStrip topStrip;
        private System.Windows.Forms.ListBox logList;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox linkText;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton settingsButton;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton infoButton;
    }
}

