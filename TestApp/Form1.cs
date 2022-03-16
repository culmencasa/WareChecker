using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            lblProcessName.Text = Process.GetCurrentProcess().ProcessName;
            this.lblVersion.Text = Application.ProductVersion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

		private void btnTryUpdate_Click(object sender, EventArgs e)
		{


            // 假设IIS服务地址为http://172.160.9.10:666
            // update.zip是程序压缩包, 需自己创建, 放在IIS上
            // config.json文件放在IIS上


            //WareCheckerApp.Program.Main(new string[] {$"\"{GetPath("BarCodePrint")}\"", @"http://172.160.9.10:666/config.json"});

            WareCheckerApp.Program.InitializeLogicContext();
            WareCheckerApp.Program.Context.TakeATrip(true);
        }

         
        static string GetPath(string fileNameOnCurrentFolder)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileNameOnCurrentFolder);
        }
    }
}
