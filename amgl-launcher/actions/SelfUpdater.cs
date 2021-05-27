
using amgl.model;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace amgl.actions
{
    public class SelfUpdater
    {
        public static string Update()
        {
            if (CopyNewLauncher())
                return Status.LauncherPath;

            if (IsUpdaterNewer())
                return Status.UpdaterPath;

            DeleteUpdater();

            return null;
        }

        private static bool CopyNewLauncher()
        {
            if (!Status.AssemblyPath.Equals(Status.UpdaterPath))
                return false;

            if (File.Exists(Status.LauncherPath))
            {
                Thread.Sleep(1000);
                File.Delete(Status.LauncherPath);
            }

            File.Copy(Status.UpdaterPath, Status.LauncherPath);

            return true;
        }

        private static bool IsUpdaterNewer()
        {
            if (!File.Exists(Status.UpdaterPath))
                return false;

            string launcherVersionString = FileVersionInfo.GetVersionInfo(Status.LauncherPath).FileVersion;
            string updaterVersionString = FileVersionInfo.GetVersionInfo(Status.UpdaterPath).FileVersion;

            Version launcherVersion = Version.Parse(launcherVersionString);
            Version updaterVersion = Version.Parse(updaterVersionString);

            return updaterVersion > launcherVersion;
        }

        private static void DeleteUpdater()
        {
            if (File.Exists(Status.UpdaterPath))
            {
                Thread.Sleep(1000);
                File.Delete(Status.UpdaterPath);
            }
        }
    }
}
