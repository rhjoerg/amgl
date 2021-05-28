
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

        public static readonly string Version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;


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
