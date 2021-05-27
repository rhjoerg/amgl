using amgl.model;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.actions
{
    class Initializer
    {
        public static async Task Initialize(CancellationToken cancellationToken)
        {
            try
            {
                bool updaterExists = File.Exists(Status.UpdaterPath);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
