using IWshRuntimeLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using TinyJson;
using File = System.IO.File;

namespace WareCheckerApp
{
    /// <summary>
    /// 软件更新类
    /// </summary>
    public class WareChecker : ICheck, IDownload
    {
        #region 构造

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uiContext">绑定的上下文控件</param>
        public WareChecker(IPreference config)
        {
            ProgramConfig = config;
            Initialize(ProgramConfig.RemoteConfigLocation);
        }


        public void BindUIContext(Control uiContext)
        {
            _uiContext = uiContext;
        }



        #endregion

        #region 字段

        private Control _uiContext;

        #endregion

        #region 属性

        /// <summary>
        /// 表示远程服务器上的更新配置
        /// </summary>
        public IUpdateInfo RemoteConfig { get; private set; }

        public IPreference ProgramConfig { get; set; }

        public CheckResults UpdateCheckResult { get; set; } = CheckResults.Unchecked;


        #endregion

        #region 事件

        public event Action<string> ExceptionCatch;
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler DownloadCompleted;
        /// <summary>
        /// 进度界面
        /// </summary>
        public event Func<ICheck, IDownloadProgressView> ProgressUIRequired;
        /// <summary>
        /// 对话框界面
        /// </summary>
        public event Func<ICheck, IDownloadConfirmView> DialogUIRequired;

        #endregion

        #region 公开方法

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="url">配置文件URL地址</param>
        public  void Initialize(string url)
        {
            string content = string.Empty;
            try
            {
                using (var client = new WebClient())
                {
                    content = client.DownloadString(url);
                }

                //Save(content);

                // 实例化配置
                RemoteConfig = JSONParser.FromJson<UpdateInfo>(content);
            }
            catch (WebException ex)
            {
                OnExceptionCatches(ex.Message);
            }

        }

        /// <summary>
        /// 检查是否需要继续更新
        /// </summary>
        /// <param name="currentVersion"></param>
        /// <param name="skipVersion"></param>
        /// <returns></returns>
        public CheckResults CompareVersion(string currentVersion, string skipVersion)
        {
            CheckResults result = CheckResults.Unchecked;

            bool continueUpdate = false;

            if (RemoteConfig == null)
                throw new Exception("初始化错误: RemoteConfig为空. 在 CompareVersion 之前调用 Initialize 方法");

            var v1 = new Version(currentVersion);
            var v2 = new Version(RemoteConfig.Version);


            // 1.新版本高于当前版本时, continueUpdate为true
            if (v2 > v1)
            {
                continueUpdate = true;
                result = CheckResults.HasNewUpdate;
            }
            else if (v2 <= v1)
            {
                continueUpdate = false;
                result = CheckResults.AlreadyNew;
            }

            // 2.是否跳过版本
            if (continueUpdate && !string.IsNullOrEmpty(skipVersion))
            {
                var v3 = new Version(skipVersion);
                if (v3 == v2)
                {
                    result = CheckResults.SkipVersion;
                }
            }

            return result;
        }


        public bool FeedBack { get; set; }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="runningVersion">当前程序版本</param>
        /// <param name="skipVersion">要跳过的版本</param>
        public void Start()
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(ProgramConfig.ProgramFileName);
            ProgramConfig.ProgramCurrentVersion = versionInfo.FileVersion;

            //todo: 要防止重复反复更新的问题: 记录更新次数?

            UpdateCheckResult = CompareVersion(ProgramConfig.ProgramCurrentVersion, ProgramConfig.SkipVersion);

            switch (UpdateCheckResult)
            {
                case CheckResults.HasNewUpdate:
                    {
                        // 用户的选择
                        // ForceUpdate为false时, 弹出更新提醒 
                        // ForceUpdate为true时, 强制更新但不提示
                        if (!RemoteConfig.ForceUpdate)
                        {
                            UpdateCheckResult = ShowDownloadConfirmDialog();
                        }
                        else
                        {
                            if (FeedBack)
                            {
                                MessageBox.Show("程序将退出");                                
                            }
                        }

                        // 0. 判断程序是否正在运行, 提示关闭
                        CloseApplication();

                        // 如果需要显示进度条
                        if (ProgressUIRequired != null)
                        {
                            DownloadCompleted += OnDownloadCompleted;
                            ShowDownloadProgressUI();
                        }
                        else
                        {
                            DownloadCompleted += OnDownloadCompleted;
                            BeginDownloading();
                        }
                    }
                    break;
                case CheckResults.AlreadyNew:
                case CheckResults.NoUpdate:
                    {
                        //todo:弹出提示

                        if (FeedBack)
                        {
                            MessageBox.Show("已经是最新版本.");
                            FeedBack = false;
                        }
                    }
                    break;
            } 
             
        }

        private void OnDownloadCompleted(object sender, EventArgs e)
        {
            DoUpgrade();

            if (FeedBack)
            {
                MessageBox.Show("更新完成");
            }

            RestartProcess();

            Application.ExitThread();
        }

        #endregion




        #region 私有方法

        /// <summary>
        /// 显示进度条视图
        /// </summary>
        private void ShowDownloadProgressUI()
        {
            if (_uiContext.InvokeRequired)
            {
                _uiContext.Invoke((Action)ShowDownloadProgressUI);
                return;
            }

            IDownloadProgressView view = ProgressUIRequired.Invoke(this);
            view.Executer = this;
            view.Show();

        }


        /// <summary>
        /// 显示下载对话框
        /// </summary>
        /// <returns></returns>
        private CheckResults ShowDownloadConfirmDialog()
        {
            if (_uiContext.InvokeRequired)
            {
                return (CheckResults)_uiContext.Invoke((Func<CheckResults>)ShowDownloadConfirmDialog);
            }

            CheckResults userAnswer = this.UpdateCheckResult;


            // 默认
            if (DialogUIRequired != null)
            {
                IDownloadConfirmView dialogInstance = DialogUIRequired.Invoke(this);
                dialogInstance.Title = "程序更新";
                dialogInstance.Content = "有新的版本可用,  是否下载新版本.";
                dialogInstance.Info = this.RemoteConfig;

                userAnswer = dialogInstance.ShowConfirm();
            }

            return userAnswer;
        }


        public string ZipFilePath { get; set; }

        public void BeginDownloading()
        {
            try
            {
                var client = new WebClient();
                {
                    client.DownloadProgressChanged += (a, b) => PassOnDownloadProgressStates(b);
                    client.DownloadFileCompleted += (c, d) => PassOnDownloadCompleted(d);

                    string tempDirName = "Distributions";
                    if (!Directory.Exists(tempDirName))
                    {
                        Directory.CreateDirectory(tempDirName);
                    }
                    string targetPath = Path.Combine(tempDirName, RemoteConfig.PackageFileName);
                    if (File.Exists(targetPath))
                    {
                        File.Delete(targetPath);
                    }

                    client.DownloadFileAsync(new Uri(RemoteConfig.PackageUrl), targetPath);

                    ZipFilePath = targetPath;

                    //while (client.IsBusy) { }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        private void PassOnDownloadProgressStates(DownloadProgressChangedEventArgs e)
        {
            if (DownloadProgressChanged != null)
            {
                DownloadProgressChanged(this, e);
            }
        }

        private void PassOnDownloadCompleted(AsyncCompletedEventArgs e)
        {
            if (DownloadCompleted != null)
            {
                DownloadCompleted(this, e);
            }
        }




        protected void OnExceptionCatches(string message)
        {
            if (ExceptionCatch != null)
            {
                ExceptionCatch(message);
            }
        }


        protected void DoUpgrade()
        {

            // 1.解压
            string programFileName = Path.GetFileName(ProgramConfig.ProgramFileName);
            string programDirectory = Path.GetDirectoryName(ProgramConfig.ProgramFileName);
            string unzipDirectory = programDirectory; //Path.Combine(programDirectory, RemoteConfig.Version);
            if (!Directory.Exists(unzipDirectory))
            {
                Directory.CreateDirectory(unzipDirectory);
            }


            using (var unzip = new Unzip(ZipFilePath))
            {
                unzip.ExtractToDirectory(unzipDirectory);
            }

            // 2.更新快捷方式
            string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string targetFileLocation = Path.Combine(programDirectory, programFileName);
            string shortcutName = RemoteConfig.ShortcutName;
            CreateShortcut(shortcutName, shortcutPath, targetFileLocation);


            // 3.更新本地的配置文件 
            ProgramConfig.ProgramCurrentVersion = this.RemoteConfig.Version; 
            Program.Context.SaveProgramPreferences();
        }

        protected void CloseApplication()
        {
            Process[] processArray = Process.GetProcessesByName(ProgramConfig.ProgramName);
            if (processArray.Length > 0)
            {
                foreach (Process proc in processArray)
                {
                    if (proc != null && proc.HasExited == false)
                    {
                        proc.CloseMainWindow();
                        proc.WaitForExit();
                    }
                }
            }
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = Path.Combine(shortcutPath, shortcutName + ".lnk");
            if (System.IO.File.Exists(shortcutLocation))
            {
                System.IO.File.Delete(shortcutLocation);
            }

            WshShell shell = new WshShell();
            IWshShortcut shortcut = shell.CreateShortcut(shortcutLocation) as IWshShortcut;

            shortcut.Description = "";   // The description of the shortcut
            shortcut.IconLocation = targetFileLocation;           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

        private void RestartProcess()
        {
            Process.Start(ProgramConfig.ProgramFileName);
        }


        public void Callback(Action action)
        {
            if (_uiContext.InvokeRequired)
            {
                _uiContext.Invoke(action);
            }
            else
            {
                action();
            }

        }





        private void Save(string json)
        {
            using (var sw = new StreamWriter("remoteConfig.json", false))
            {
                sw.Write(json);
            }
        }

        private void CheckMD5(string filePath)
        {
            using (FileStream file = new FileStream(filePath, System.IO.FileMode.Open))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] YourFile = md5.ComputeHash(file);
                file.Close();
                StringBuilder FileMD5 = new StringBuilder();
                for (int i = 0; i < YourFile.Length; i++)
                {
                    FileMD5.Append(YourFile[i].ToString("x2"));
                }
                FileMD5.ToString();
            }
        }


        #endregion
    }
}
