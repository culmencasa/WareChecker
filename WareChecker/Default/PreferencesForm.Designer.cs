
namespace WareCheckerApp
{
    partial class PreferencesForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PreferencesForm));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtRemoteConfig = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnGetFileInfo = new System.Windows.Forms.Button();
			this.txtAppFilePath = new System.Windows.Forms.TextBox();
			this.btnGetProcessInfo = new System.Windows.Forms.Button();
			this.txtProcessName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblTargetStatus = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnApply = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.btnCancel = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 27);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "远程配置位置:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 156);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "2.通过程序路径设定:";
			// 
			// txtRemoteConfig
			// 
			this.txtRemoteConfig.Location = new System.Drawing.Point(10, 45);
			this.txtRemoteConfig.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtRemoteConfig.Multiline = true;
			this.txtRemoteConfig.Name = "txtRemoteConfig";
			this.txtRemoteConfig.Size = new System.Drawing.Size(466, 60);
			this.txtRemoteConfig.TabIndex = 2;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.btnGetFileInfo);
			this.groupBox1.Controls.Add(this.txtAppFilePath);
			this.groupBox1.Controls.Add(this.btnGetProcessInfo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtProcessName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(2, 2);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(494, 236);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "1.升级程序配置";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(14, 27);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(142, 12);
			this.label5.TabIndex = 11;
			this.label5.Text = "通过以下两种方式设定:";
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.Color.Silver;
			this.label4.Location = new System.Drawing.Point(22, 130);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(453, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "---------------------------------- 或者 ----------------------------------";
			// 
			// btnGetFileInfo
			// 
			this.btnGetFileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGetFileInfo.Location = new System.Drawing.Point(376, 201);
			this.btnGetFileInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnGetFileInfo.Name = "btnGetFileInfo";
			this.btnGetFileInfo.Size = new System.Drawing.Size(99, 22);
			this.btnGetFileInfo.TabIndex = 8;
			this.btnGetFileInfo.Text = "从文件读取...";
			this.btnGetFileInfo.UseVisualStyleBackColor = true;
			this.btnGetFileInfo.Click += new System.EventHandler(this.btnGetFileInfo_Click);
			// 
			// txtAppFilePath
			// 
			this.txtAppFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAppFilePath.BackColor = System.Drawing.Color.White;
			this.txtAppFilePath.Location = new System.Drawing.Point(22, 176);
			this.txtAppFilePath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtAppFilePath.Name = "txtAppFilePath";
			this.txtAppFilePath.ReadOnly = true;
			this.txtAppFilePath.Size = new System.Drawing.Size(455, 21);
			this.txtAppFilePath.TabIndex = 7;
			// 
			// btnGetProcessInfo
			// 
			this.btnGetProcessInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGetProcessInfo.Location = new System.Drawing.Point(376, 103);
			this.btnGetProcessInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnGetProcessInfo.Name = "btnGetProcessInfo";
			this.btnGetProcessInfo.Size = new System.Drawing.Size(99, 22);
			this.btnGetProcessInfo.TabIndex = 5;
			this.btnGetProcessInfo.Text = "从进程读取";
			this.btnGetProcessInfo.UseVisualStyleBackColor = true;
			this.btnGetProcessInfo.Click += new System.EventHandler(this.btnGetProcessInfo_Click);
			// 
			// txtProcessName
			// 
			this.txtProcessName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtProcessName.Location = new System.Drawing.Point(22, 78);
			this.txtProcessName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtProcessName.Name = "txtProcessName";
			this.txtProcessName.Size = new System.Drawing.Size(455, 21);
			this.txtProcessName.TabIndex = 4;
			this.txtProcessName.Text = "UpdatingTestApp";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 58);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(119, 12);
			this.label3.TabIndex = 3;
			this.label3.Text = "1.通过进程名称设定:";
			// 
			// lblTargetStatus
			// 
			this.lblTargetStatus.AutoSize = true;
			this.lblTargetStatus.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.lblTargetStatus.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.lblTargetStatus.Location = new System.Drawing.Point(122, 14);
			this.lblTargetStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTargetStatus.Name = "lblTargetStatus";
			this.lblTargetStatus.Size = new System.Drawing.Size(44, 12);
			this.lblTargetStatus.TabIndex = 13;
			this.lblTargetStatus.Text = "未配置";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(21, 14);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(90, 12);
			this.label6.TabIndex = 12;
			this.label6.Text = "程序配置状态:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtRemoteConfig);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(2, 242);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox2.Size = new System.Drawing.Size(494, 114);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "2.升级服务配置";
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnApply.Location = new System.Drawing.Point(288, 9);
			this.btnApply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(99, 22);
			this.btnApply.TabIndex = 6;
			this.btnApply.Text = "确定";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(390, 9);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 22);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.AutoScroll = true;
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.Controls.Add(this.groupBox1);
			this.flowLayoutPanel1.Controls.Add(this.groupBox2);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 6);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(498, 358);
			this.flowLayoutPanel1.TabIndex = 8;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.White;
			this.panel1.Controls.Add(this.lblTargetStatus);
			this.panel1.Controls.Add(this.btnCancel);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.btnApply);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(6, 366);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(498, 40);
			this.panel1.TabIndex = 9;
			// 
			// PreferencesForm
			// 
			this.AcceptButton = this.btnApply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(510, 412);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "PreferencesForm";
			this.Padding = new System.Windows.Forms.Padding(6);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "更新程序选项";
			this.Load += new System.EventHandler(this.PreferencesForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRemoteConfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetProcessInfo;
        private System.Windows.Forms.TextBox txtProcessName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetFileInfo;
        private System.Windows.Forms.TextBox txtAppFilePath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblTargetStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}