using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace amgl.utils
{
    class Files
    {
        public static readonly string AssemblyPath = Assembly.GetExecutingAssembly().Location;
        public static readonly string InstallDir = Path.GetDirectoryName(AssemblyPath);
    }
}
