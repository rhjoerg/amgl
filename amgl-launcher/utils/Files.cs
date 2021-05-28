
using System.IO;
using System.Reflection;

namespace amgl.utils
{
    public class Files
    {
        public static readonly string InstallDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;

        public static readonly string LauncherName = "amgl-launcher.exe";
        public static readonly string LauncherPath = Path.Combine(InstallDir, LauncherName);

        public static readonly string UpdaterName = "amgl-updater.exe";
        public static readonly string UpdaterPath = Path.Combine(InstallDir, UpdaterName);
    }
}
