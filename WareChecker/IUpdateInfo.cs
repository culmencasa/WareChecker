using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public interface IUpdateInfo
    {
        string PackageUrl { get; set; }
        bool ForceUpdate { get; set; }
        string PackageFileName { get; set; }
        string Version { get; set; }

        string ShortcutName { get; set; }

    }
}
