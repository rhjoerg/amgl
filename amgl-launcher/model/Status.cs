
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace amgl.model
{
    public class Status
    {
        public delegate void ChangedHandler();

        public static event ChangedHandler Changed;

        private static bool updateRequired = false;

        public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;

        public static readonly string Version = FileVersionInfo.GetVersionInfo(AssemblyPath).FileVersion;
        public static readonly string Directory = Path.GetDirectoryName(AssemblyPath);

        public static readonly string LauncherPath = Path.Combine(Directory, "amgl-launcher.exe");
        public static readonly string UpdaterPath = Path.Combine(Directory, "amgl-launcher-update.exe");

        public static bool UpdateRequired
        {
            get { return updateRequired; }
        }

        public static void Update(bool updateRequired)
        {
            Status.updateRequired = updateRequired;
            Status.Changed.Invoke();
        }
    }
}
