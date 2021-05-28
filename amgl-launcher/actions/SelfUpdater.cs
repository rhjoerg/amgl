
using amgl.model;
using amgl.utils;
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
                return Files.LauncherPath;

            if (IsUpdaterNewer())
                return Files.UpdaterPath;

            DeleteUpdater();

            return null;
        }

        private static bool CopyNewLauncher()
        {
            if (!Files.AssemblyPath.Equals(Files.UpdaterPath))
                return false;

            Thread.Sleep(1000);
            File.Copy(Files.UpdaterPath, Files.LauncherPath, true);

            return true;
        }

        private static bool IsUpdaterNewer()
        {
            return Versions.UpdaterVersion > Versions.LauncherVersion;
        }

        private static void DeleteUpdater()
        {
            if (File.Exists(Files.UpdaterPath))
            {
                Thread.Sleep(1000);
                File.Delete(Files.UpdaterPath);
            }
        }
    }
}
