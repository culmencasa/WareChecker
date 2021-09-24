using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WareCheckerApp
{
    public interface ICheck
    {

        IUpdateInfo RemoteConfig { get; }

        CheckResults CompareVersion(string currentVersion, string skipVersion);
    }
}
