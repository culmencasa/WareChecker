using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace WareCheckerApp
{
    public static class Program
    {
        #region 常量

        public const string APP_NAME = "WareChecker";

        #endregion


        static EZLogger logger;
        static Program()
        { 
            //string logFile = AppDomain.CurrentDomain.BaseDirectory
            logger = new EZLogger("warechecker.log", false, (uint)EZLogger.Level.Error);
            logger.Start();
        }


        public static void InitializeLogicContext()
        {
            if (Context == null)
            {
                Context = new LogicContext();
            }
            // 1. 加载更新程序配置
            Context.LoadProgramPreferences();

            // 2. 检查配置
            if (Context.CheckPreferencesErrors())
            {
                MessageBox.Show("程序未正确配置. ", Context.ContextName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                var prefForm = FormManager.Single<PreferencesForm>();
                prefForm.ShowDialog();
            }
        }


        [STAThread]
        public static void Main(string[] args)
        {
            #region 唯一实例判断

            bool isFirstSyncElement;
            _ = new Mutex(false, APP_NAME, out isFirstSyncElement);
            if (isFirstSyncElement == false)
            {
                Process sameAppProc = GetProcessInstance();
                if (sameAppProc != null)
                {
                    // 如果找到已有的实例则前置
                    //Win32.SetForegroundWindow(SameAppProc.MainWindowHandle);
                }
                else
                {
                    Environment.Exit(0);
                }
                return;
            }

            #endregion

            #region 初始化

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {

                Exception ex = (Exception)e.ExceptionObject;
                logger.Error(ex.StackTrace);
                
                MessageBox.Show("非线程：存在未处理的异常:"  + ex.Message);  
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #endregion

            #region 更新逻辑

            Context = new LogicContext();

            if (Helper.GetConfig("debug")?.ToLower() == "true")
            {
                Debugger.Launch();
            }
            // 1. 加载更新程序配置
            if (args.Length > 0)
            {
                Context.SetupProgramFileConfig(args[0], args[1]);
            }
            else
            {
                Context.LoadProgramPreferences();
            }
            // 2. 检查配置
            if (Context.CheckPreferencesErrors())
            {
                MessageBox.Show("程序未正确配置. ", Context.ContextName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                var prefForm = FormManager.Single<PreferencesForm>();
                prefForm.Show();
                prefForm.Activate();
            }
            else
            {
                // 3. 检查更新
                Context.TakeATrip();
            }

            #endregion


            Application.Run(Context);
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            logger.Error(e.Exception.StackTrace);
            MessageBox.Show(e.Exception.Message);
        }

        /// <summary>
        /// 获取处理逻辑的应用程序上下文
        /// </summary>
        public static LogicContext Context
        {
            get;
            private set;
        }

        public static Process GetProcessInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (current.MainModule.FileName == Assembly.GetExecutingAssembly().Location.Replace("/", "\\"))
                    {
                        return process;
                    }
                }
            }
            return null;
        }


    }
}
