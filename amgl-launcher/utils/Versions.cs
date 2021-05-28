
using System;
using System.Diagnostics;
using System.IO;

namespace amgl.utils
{
    public class Versions
    {
        public static Version AssemblyVersion
        {
            get { return Version.Parse(FileVersionInfo.GetVersionInfo(Files.AssemblyPath).FileVersion); }
        }

        public static Version LauncherVersion
        {
            get
            {
                if (!File.Exists(Files.LauncherPath))
                    return new Version(0, 0, 0, 0);

                return Version.Parse(FileVersionInfo.GetVersionInfo(Files.LauncherPath).FileVersion);
            }
        }

        public static Version UpdaterVersion
        {
            get
            {
                if (!File.Exists(Files.UpdaterPath))
                    return new Version(0, 0, 0, 0);

                return Version.Parse(FileVersionInfo.GetVersionInfo(Files.UpdaterPath).FileVersion);
            }
        }
    }
}
