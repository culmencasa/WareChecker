﻿
namespace WareCheckerApp
{
    partial class DownloadProcessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadProcessForm));
            this.prgDownload = new System.Windows.Forms.ProgressBar();
            this.pnlDownloadProgress = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlDownloadProgress.SuspendLayout();
            this.SuspendLayout();
            // 
            // prgDownload
            // 
            this.prgDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgDownload.Location = new System.Drawing.Point(53, 32);
            this.prgDownload.Name = "prgDownload";
            this.prgDownload.Size = new System.Drawing.Size(604, 23);
            this.prgDownload.TabIndex = 0;
            // 
            // pnlDownloadProgress
            // 
            this.pnlDownloadProgress.Controls.Add(this.prgDownload);
            this.pnlDownloadProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDownloadProgress.Location = new System.Drawing.Point(0, 47);
            this.pnlDownloadProgress.Name = "pnlDownloadProgress";
            this.pnlDownloadProgress.Size = new System.Drawing.Size(710, 87);
            this.pnlDownloadProgress.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "正在下载更新...";
            // 
            // DownloadProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlDownloadProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DownloadProcessForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DownloadProcessForm_Load);
            this.pnlDownloadProgress.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgDownload;
        private System.Windows.Forms.Panel pnlDownloadProgress;
        private System.Windows.Forms.Label label1;
    }
}