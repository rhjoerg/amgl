using System.IO;
using System.Reflection;

namespace amgl.util
{
    public static class FileUtils
    {
        public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string InstallDir = Path.GetDirectoryName(AssemblyPath);

        public static readonly string GameXmlName = "game.xml";
        public static readonly string GameXmlPath = Path.Combine(InstallDir, GameXmlName);

        public static readonly string DeveloperXmlName = "developer.xml";
        public static readonly string DeveloperXmlPath = Path.Combine(InstallDir, DeveloperXmlName);

        public static string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2);
        }

        public static string Get(string relativePath)
        {
            return Path.Combine(InstallDir, relativePath);
        }
    }
}

