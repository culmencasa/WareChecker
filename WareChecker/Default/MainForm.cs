using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TinyJson;

namespace WareCheckerApp
{
    /// <summary>
    /// 主程序: 仅用作托盘组件的承载容器
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }


        private void tlsExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tlsCheckUpdate_Click(object sender, EventArgs e)
        {

            if (Helper.GetConfig("debug")?.ToLower() == "true")
            {
                Debugger.Launch();
            }
            //todo: 检查并提示结果
            Program.Context.TakeATrip(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //使关闭时窗口向右下角缩小的效果
                WindowState = FormWindowState.Minimized;
                ntfMain.Visible = true;
                //this.m_cartoonForm.CartoonClose();
                this.Hide();
                return;
            }
        }

        private void tlsShowOptions_Click(object sender, EventArgs e)
        {
            var preferencesForm = FormManager.Single<PreferencesForm>();
            preferencesForm.Show();
        }
    }
}
