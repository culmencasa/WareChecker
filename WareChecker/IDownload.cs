using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public interface IDownload
    {

        event EventHandler<System.Net.DownloadProgressChangedEventArgs> DownloadProgressChanged;
        event EventHandler DownloadCompleted;

        /// <summary>
        /// 开始下载
        /// </summary>
        void BeginDownloading();
    }
}
