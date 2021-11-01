using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TestApp
{
    static class Program
    {
        static Process checkerProcess;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ApplicationExit += Application_ApplicationExit;


            // 假设IIS服务地址为http://172.160.9.10:666
            // update.zip是程序压缩包, 需自己创建, 放在IIS上
            // config.json文件放在IIS上

            // 启动更新程序
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = string.Format(@"{0}WareChecker\WareChecker.exe", AppDomain.CurrentDomain.BaseDirectory);
            psi.Arguments = $"\"{Process.GetCurrentProcess().MainModule.FileName}\" http://172.160.9.10:666/config.json"; 
            psi.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory + "WareChecker";
            checkerProcess = Process.Start(psi);


            Application.Run(new Form1());
        }
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //todo:区分正常退出和更新退出
            if (checkerProcess != null && !checkerProcess.HasExited)
            {
                checkerProcess.Kill();
            }
        }

    }
}
