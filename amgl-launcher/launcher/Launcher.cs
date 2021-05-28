
using amgl.utils;
using System;
using System.Windows.Forms;

namespace amgl.launcher
{
    public class Launcher
    {
        public static readonly bool IsLauncher = Files.AssemblyPath.Equals(Files.LauncherPath);
        public static readonly bool IsUpdater = Files.AssemblyPath.Equals(Files.UpdaterPath);

        public static bool Update()
        {
            if (IsLauncher && CreateUpdater.CanCreate)
                CreateUpdater.Run(new Version(0, 0, 0, 2));

            if (IsLauncher && (Versions.UpdaterVersion > Versions.LauncherVersion))
            {
                Processes.Start(Files.UpdaterPath, "", true);
                return true;
            }

            return false;
        }
    }
}
