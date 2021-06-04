using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace amgl.util
{
    public static class Files
    {
        public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string InstallDir = Path.GetDirectoryName(AssemblyPath);

        public static readonly string GameXmlName = "game.xml";
        public static readonly string GameXmlPath = Path.Combine(InstallDir, GameXmlName);

        public static readonly string DeveloperXmlName = "developer.xml";
        public static readonly string DeveloperXmlPath = Path.Combine(InstallDir, DeveloperXmlName);
    }
}

