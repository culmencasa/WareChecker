using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public class UpdateInfo : IUpdateInfo
    {
        public string PackageUrl { get; set; }
        public bool ForceUpdate { get; set; }
        public string PackageFileName { get; set; }
        public string Output { get; set; }
        public string ProcessStart { get; set; }
        public int CheckEvery { get; set; }
        public string IntervalType { get; set; }
        public string Version { get; set; }
        public string ShortcutName { get; set; }
    }
}
