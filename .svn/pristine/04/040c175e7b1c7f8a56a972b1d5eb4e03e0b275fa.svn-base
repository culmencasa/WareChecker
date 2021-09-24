using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public class ProgramPreference : IPreference
    {

        #region 单例

        public static ProgramPreference Default { get; }
        static ProgramPreference()
        {
            Default = new ProgramPreference()
            {
                RemoteConfigLocation = "http://172.160.9.10:666/config.json"
            };
        }

        #endregion

        /// <summary>
        /// 最后一次跳过的版本
        /// </summary>
        public string SkipVersion
        {
            get;
            set;
        }

        /// <summary>
        /// 远程配置的位置
        /// </summary>
        public string RemoteConfigLocation { get; set; }

        /// <summary>
        /// 程序名(进程名)
        /// </summary>
        public string ProgramName { get; set; }

        /// <summary>
        /// 程序路径
        /// </summary>
        public string ProgramFileName { get; set; }

        /// <summary>
        /// 程序当前版本
        /// </summary>
        public string ProgramCurrentVersion { get; set; }
    }
}
