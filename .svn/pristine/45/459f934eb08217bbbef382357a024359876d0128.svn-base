using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinyJson;

namespace WareCheckerApp
{
    /// <summary>
    /// 
    /// </summary>
    public class LogicContext : ApplicationContext
    {
        #region 字段

        private ProgramPreference _preferences;

        private const string PreferenceFilePath = "preference.json";


        private BackgroundWorker _updateBackgroundWorker;

        protected BackgroundWorker UpdateBackgroundWorker
        {
            get
            {
                if (_updateBackgroundWorker == null)
                {
                    _updateBackgroundWorker = new BackgroundWorker();
                    _updateBackgroundWorker.WorkerReportsProgress = true;
                    _updateBackgroundWorker.WorkerSupportsCancellation = true;
                    _updateBackgroundWorker.ProgressChanged += _updateBackgroundWorker_ProgressChanged;
                    _updateBackgroundWorker.DoWork += _updateBackgroundWorker_DoWork;
                    _updateBackgroundWorker.RunWorkerCompleted += _updateBackgroundWorker_RunWorkerCompleted;
                }

                return _updateBackgroundWorker;
            }
        }

        private void _updateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgw = sender as BackgroundWorker;

            bool feedBack = false;
            if (e.Argument != null)
            {
                feedBack = (bool)e.Argument;
            }

            try
            {
                WareChecker wareChecker = new WareChecker(Preferences);
                wareChecker.ExceptionCatch += WareChecker_ExceptionCatch;
                wareChecker.ProgressUIRequired += WareChecker_ProgressInterfaceRequired;
                wareChecker.DialogUIRequired += WareChecker_DialogInterfaceRequired;
                wareChecker.BindUIContext(this.MainForm);

                if (feedBack)
                {
                    wareChecker.FeedBack = true;
                }

                wareChecker.Start();

            }
            catch
            {
                throw;
            }
        }
        private void _updateBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch(e.ProgressPercentage)
            {
                case 200:
                    //WareChecker.CheckResults result = (WareChecker.CheckResults)e.UserState;
                    //if (result == WareChecker.CheckResults.NoUpdate)
                    //{
                    //    MessageBox.Show("没有更新");
                    //}
                    //else if (result == WareChecker.CheckResults.CanUpdate)
                    //{ 
                        
                    //}
                    break;            
            }

        }
        private void _updateBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }



        public readonly string ContextName = "升级服务";

        #endregion

        #region 属性

        /// <summary>
        /// 程序选项。
        /// 在LoadProgramPreferences或者SetupProgramFileConfig方法中实例化。
        /// </summary>
        public ProgramPreference Preferences
        {
            get
            {
                if (_preferences == null)
                {
                    throw new Exception("未能正常加载程序配置");
                }

                return _preferences;
            }
            set
            {
                _preferences = value;
            }
        }

        #endregion

        #region 构造

        public LogicContext(Form mainForm)
        {
            MainForm = mainForm;

            // 主程序不显示
            MainForm.WindowState = FormWindowState.Minimized;
            MainForm.Closed += (a, b) => Application.Exit();

            MainForm.Show();
        }

        #endregion

        #region 公开方法 

        /// <summary>
        /// 跳过指定的版本
        /// </summary>
        /// <param name="version"></param>
        public void SkipVersion(string version)
        {
            Preferences.SkipVersion = version;
            WritePreference(Preferences);
        }



        /// <summary>
        /// 开始检查更新
        /// </summary>
        public void TakeATrip(bool feedbackCheckResult=false)
        {
            if (!UpdateBackgroundWorker.IsBusy)
            {
                UpdateBackgroundWorker.RunWorkerAsync(feedbackCheckResult);
            }
        }

        public void SaveProgramPreferences()
        {
            WritePreference(Preferences);
        }

        /// <summary>
        /// 加载程序的设置选项
        /// </summary>
        public void LoadProgramPreferences()
        {
            _preferences = ReadPreference();

            if (_preferences == null)
            {
                // 默认设置
                _preferences = ProgramPreference.Default;

                WritePreference(_preferences);
            }
        }


        /// <summary>
        /// 由外部传进来的程序配置
        /// </summary>
        /// <param name="fileName">主程序文件名</param>
        /// <param name="remoteUrl">远程更新信息的地址</param>
        public void SetupProgramFileConfig(string fileName, string remoteUrl)
        {
            //string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            string version = versionInfo.FileVersion;

            ProgramPreference pref = new ProgramPreference();
            pref.ProgramFileName = fileName;
            pref.ProgramCurrentVersion = version;
            pref.RemoteConfigLocation = remoteUrl;
            pref.ProgramName = Path.GetFileNameWithoutExtension(fileName);
            pref.RemoteConfigLocation = remoteUrl;

            WritePreference(pref);

            // 设置
            _preferences = pref;
        }


        #endregion

        #region 私有方法 

        /// <summary>
        /// 读取配置
        /// </summary>
        protected ProgramPreference ReadPreference()
        {
            string content = string.Empty;

            if (!string.IsNullOrEmpty(PreferenceFilePath) && File.Exists(PreferenceFilePath))
            {
                using (var sr = new StreamReader(PreferenceFilePath, false))
                {
                    content = sr.ReadToEnd();
                }
                return JSONParser.FromJson<ProgramPreference>(content);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 保存配置 
        /// </summary>
        /// <param name="pref"></param>
        protected void WritePreference(ProgramPreference pref)
        {
            string content = JSONWriter.ToJson(pref);
            string fullpath = PreferenceFilePath;
            using (var sw = new StreamWriter(fullpath, false))
            {
                sw.Write(content);
            }
        }

        public bool CheckPreferencesErrors()
        {
            bool hasError = string.IsNullOrEmpty(this.Preferences.ProgramFileName) ||
                string.IsNullOrEmpty(Preferences.ProgramCurrentVersion) ||
                string.IsNullOrEmpty(Preferences.RemoteConfigLocation);

            

            return hasError;
        }


        #endregion


        #region 事件处理


        private void WareChecker_ExceptionCatch(string obj)
        {
            Debug.WriteLine(obj);
        }

        private IDownloadConfirmView WareChecker_DialogInterfaceRequired(ICheck check)
        {
            var form = new UpdateConfirmDialog();

            return form;
        }

        private IDownloadProgressView WareChecker_ProgressInterfaceRequired(ICheck checker)
        {
            IDownloadProgressView form = new DownloadProcessForm();
            return form;
        }
        #endregion

    }
}
