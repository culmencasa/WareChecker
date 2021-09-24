
namespace WareCheckerApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ntfMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlsCheckUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsShowOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntfMain
            // 
            this.ntfMain.ContextMenuStrip = this.ctxMain;
            this.ntfMain.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfMain.Icon")));
            this.ntfMain.Text = "条码打印更新程序";
            this.ntfMain.Visible = true;
            // 
            // ctxMain
            // 
            this.ctxMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsCheckUpdate,
            this.tlsShowOptions,
            this.toolStripMenuItem1,
            this.tlsExit});
            this.ctxMain.Name = "ctxMain";
            this.ctxMain.Size = new System.Drawing.Size(185, 124);
            // 
            // tlsCheckUpdate
            // 
            this.tlsCheckUpdate.Name = "tlsCheckUpdate";
            this.tlsCheckUpdate.Size = new System.Drawing.Size(184, 38);
            this.tlsCheckUpdate.Text = "检查更新";
            this.tlsCheckUpdate.Click += new System.EventHandler(this.tlsCheckUpdate_Click);
            // 
            // tlsShowOptions
            // 
            this.tlsShowOptions.Name = "tlsShowOptions";
            this.tlsShowOptions.Size = new System.Drawing.Size(184, 38);
            this.tlsShowOptions.Text = "选项";
            this.tlsShowOptions.Click += new System.EventHandler(this.tlsShowOptions_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // tlsExit
            // 
            this.tlsExit.Name = "tlsExit";
            this.tlsExit.Size = new System.Drawing.Size(184, 38);
            this.tlsExit.Text = "退出";
            this.tlsExit.Click += new System.EventHandler(this.tlsExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ctxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon ntfMain;
        private System.Windows.Forms.ContextMenuStrip ctxMain;
        private System.Windows.Forms.ToolStripMenuItem tlsExit;
        private System.Windows.Forms.ToolStripMenuItem tlsCheckUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tlsShowOptions;
    }
}

