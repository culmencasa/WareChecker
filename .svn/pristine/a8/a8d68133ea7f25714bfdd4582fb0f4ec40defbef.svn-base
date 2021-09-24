using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using static System.Management.PropertyDataCollection;

namespace WareCheckerApp
{
    public partial class PreferencesForm : Form
    {
        public PreferencesForm()
        {
            InitializeComponent();
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            var context = Program.Context;
            var pref = context.Preferences;
            if (pref != null)
            {
                txtAppFilePath.Text = pref.ProgramFileName;
                txtProcessName.Text = pref.ProgramName;
                txtRemoteConfig.Text = pref.RemoteConfigLocation;
            }

            RefreshPrefStaus();
        }

        private void RefreshPrefStaus()
        {
            var context = Program.Context;
            if (!context.CheckPreferencesErrors())
            {
                lblTargetStatus.Text = "已配置";
                lblTargetStatus.ForeColor = Color.Green;
            }
            else
            {
                lblTargetStatus.Text = "未配置";
                lblTargetStatus.ForeColor = Color.Red;
            }

        }


        private void UpdateProgramFileConfig(string fileName)
        {
            var versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            string version = versionInfo.FileVersion;

            var context = Program.Context;
            var pref = context.Preferences;
            pref.ProgramFileName = fileName;
            pref.ProgramCurrentVersion = version;

            pref.ProgramName = Path.GetFileNameWithoutExtension(fileName);
        }


        private void btnGetProcessInfo_Click(object sender, EventArgs e)
        {
            string processName = txtProcessName.Text;
            string fileName = GetFileNameFromProcess(processName);


            //var versionInfo = FileVersionInfo.GetVersionInfo(fileName);
            //string version = versionInfo.FileVersion;

            //var context = Program.Context;
            //var pref = context.Preferences;
            //pref.ProgramName = processName;
            //pref.ProgramFileName = fileName;
            //pref.ProgramCurrentVersion = version;

            UpdateProgramFileConfig(fileName);
        }

        /// <summary>
        /// 从进程名称获取程序的路径
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        private string GetFileNameFromProcess(string processName)
        {
            string fileName = string.Empty;


            int pid = 0;
            Process[] processArray = Process.GetProcessesByName(processName);
            foreach (Process item in processArray)
            {
                pid = item.Id;

                // 异常: 32位无法访问64位进程
                //fileName = item.MainModule.FileName;
                break;
            }

            fileName = GetMainModuleFilepath(pid);

            return fileName;
        }

        /// <summary>
        /// 用WMI语句查询程序的路径 
        /// </summary>
        /// <param name="processId"></param>
        /// <returns></returns>
        private string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = $"SELECT ExecutablePath FROM Win32_Process WHERE ProcessId = {processId} ";
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["ExecutablePath"];
                    }
                }
            }
            return null;
        }


        // 点击获取文件
        private void btnGetFileInfo_Click(object sender, EventArgs e)
        {
            // 1.选择文件
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            openFileDialog1.Filter = "应用程序(*.exe)|*.exe|All files (*.*)|*.*";
            var dr = openFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                txtAppFilePath.Text = openFileDialog1.FileName; 
            }
            else
            {
                txtAppFilePath.Text = string.Empty;
            }

            // 2.更新配置 
            string fileName = txtAppFilePath.Text;
            if (!string.IsNullOrEmpty(fileName))
            {
                UpdateProgramFileConfig(fileName);
            }


            RefreshPrefStaus();
        }


        private void btnShowFileDialog_Click(object sender, EventArgs e)
        {
            RefreshPrefStaus();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRemoteConfig.Text))
            {
                MessageBox.Show("远程配置位置未指定");
                return;
            }

            var context = Program.Context;
            context.Preferences.RemoteConfigLocation = txtRemoteConfig.Text;


            context.SaveProgramPreferences();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
