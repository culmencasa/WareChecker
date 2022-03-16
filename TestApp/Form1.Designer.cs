
namespace TestApp
{
    partial class Form1
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
			this.label1 = new System.Windows.Forms.Label();
			this.lblVersion = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lblProcessName = new System.Windows.Forms.Label();
			this.btnTryUpdate = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(59, 80);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "版本号:";
			// 
			// lblVersion
			// 
			this.lblVersion.AutoSize = true;
			this.lblVersion.Location = new System.Drawing.Point(120, 79);
			this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(0, 12);
			this.lblVersion.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(61, 46);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "程序进程名:";
			// 
			// lblProcessName
			// 
			this.lblProcessName.AutoSize = true;
			this.lblProcessName.Location = new System.Drawing.Point(150, 46);
			this.lblProcessName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblProcessName.Name = "lblProcessName";
			this.lblProcessName.Size = new System.Drawing.Size(41, 12);
			this.lblProcessName.TabIndex = 3;
			this.lblProcessName.Text = "label3";
			// 
			// btnTryUpdate
			// 
			this.btnTryUpdate.Location = new System.Drawing.Point(227, 180);
			this.btnTryUpdate.Name = "btnTryUpdate";
			this.btnTryUpdate.Size = new System.Drawing.Size(135, 33);
			this.btnTryUpdate.TabIndex = 4;
			this.btnTryUpdate.Text = "测试更新";
			this.btnTryUpdate.UseVisualStyleBackColor = true;
			this.btnTryUpdate.Click += new System.EventHandler(this.btnTryUpdate_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 225);
			this.Controls.Add(this.btnTryUpdate);
			this.Controls.Add(this.lblProcessName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblProcessName;
		private System.Windows.Forms.Button btnTryUpdate;
	}
}

