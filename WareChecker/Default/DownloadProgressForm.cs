using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WareCheckerApp
{
    public partial class DownloadProcessForm : Form, IDownloadProgressView
    {
        #region 构造

        public DownloadProcessForm()
        {
            InitializeComponent();
            
            
            // 默认窗体显示后自动开始下载
            AutoStart = true;
        }

        #endregion


        #region 实现接口 IDownloadProgressView 的成员

        public bool AutoStart { get; set; }

        public IDownload Executer { get; set; }

        public void HandleDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.prgDownload.Value = e.ProgressPercentage;
            }
        }

        public void HandleDownloadComplete(object sender, EventArgs e)
        {
            if (this.IsHandleCreated)
            {
                this.prgDownload.Value = 100;
            }
        }
        

        #endregion

        // todo: 用户强制关闭窗口的处理

        private void DownloadProcessForm_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            Executer.DownloadProgressChanged -= HandleDownloadProgress;
            Executer.DownloadCompleted -= HandleDownloadComplete;
            Executer.DownloadProgressChanged += HandleDownloadProgress;
            Executer.DownloadCompleted += HandleDownloadComplete;
            Executer.BeginDownloading();
        }

    }
}
