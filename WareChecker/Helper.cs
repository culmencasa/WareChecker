using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using TinyJson;

namespace WareCheckerApp
{
    static class Helper
    {
        //public  void Save(this ProgramPreference pref)
        //{
        //    string content = JSONWriter.ToJson(pref);
        //    string fullpath = PreferenceFilePath;
        //    using (var sw = new StreamWriter(fullpath, false))
        //    {
        //        sw.Write(content);
        //    }
        //}


        /// <summary>
        /// 读取配置文件某项的值
        /// </summary>
        /// <param name="key">appSettings的key</param>
        /// <returns>appSettings的Value</returns>
        public static string GetConfig(string key)
        {
            string _value = string.Empty;
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null)
            {
                _value = config.AppSettings.Settings[key].Value;
            }
            return _value;
        }

    }
}
