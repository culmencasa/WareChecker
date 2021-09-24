using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace WareCheckerApp
{
    /// <summary>
    /// 表示下载进度界面的接口
    /// </summary>
    public interface IDownloadProgressView
    {
        /// <summary>
        /// 显示界面
        /// </summary>
        void Show();

        /// <summary>
        /// 自动开始
        /// True表示界面显示后自动开始下载; False表示先显示更新内容
        /// </summary>
        //public bool AutoStart { get; set; }


        IDownload Executer { get; set; }


        /// <summary>
        /// 处理下载进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleDownloadProgress(object sender, DownloadProgressChangedEventArgs e);

        /// <summary>
        /// 处理下载完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleDownloadComplete(object sender, EventArgs e);




    }
}
