using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public interface IPreference
    {
        public string RemoteConfigLocation { get; set; }
        public string SkipVersion
        {
            get;
            set;
        }

        public string ProgramName { get; set; }

        public string ProgramFileName { get; set; }


        public string ProgramCurrentVersion { get; set; }
    }
}
