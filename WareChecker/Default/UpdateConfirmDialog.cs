using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WareCheckerApp
{
    public partial class UpdateConfirmDialog : Form, IDownloadConfirmView
    {
        #region 构造

        public UpdateConfirmDialog()
        {
            InitializeComponent();
        }

        #endregion

        #region 属性

        /// <summary>
        /// 表示更新信息的对象
        /// </summary>
        public IUpdateInfo Info { get; set; }

        /// <summary>
        /// 标题 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        #endregion

        #region 事件处理

        private void UpdateDialog_Load(object sender, EventArgs e)
        {
            Text = Title;
            lblContent.Text = Content;

            //lblVersionOld = Info.
        }

        public CheckResults CheckResult { get; private set; }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            string newVersion = Info.Version;
            LogicContext context = Program.Context;
            context.SkipVersion(newVersion);

            DialogResult = DialogResult.Ignore;
            CheckResult = CheckResults.SkipVersion;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            LogicContext context = Program.Context;
            context.SkipVersion(string.Empty);

            DialogResult = DialogResult.Yes;
            CheckResult = CheckResults.HasNewUpdate;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            CheckResult = CheckResults.DontUpdate;
        }

        public CheckResults ShowConfirm()
        {
            this.ShowDialog();

            return CheckResult;
        }


        #endregion
    }
}
