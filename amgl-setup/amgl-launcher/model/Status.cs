using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace amgl.model
{
    public class Status
    {
        public static readonly bool IsAdmin = DetermineIsAdmin();

        private static bool DetermineIsAdmin()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);

                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public readonly Phase Phase;
        public readonly Installed Installed;

        public readonly string Message;
        public readonly double Progress;

        private Status(Phase phase, Installed installed)
        {
            Phase = phase;
            Installed = installed;
            Message = "";
            Progress = 0;
        }

        private Status(Phase phase, string message, double progress)
        {
            Phase = phase;
            Installed = Installed.NotInstalled;
            Message = message;
            Progress = progress;
        }

        public static Status Verifying(double progress)
        {
            return new Status(Phase.Verifying, "Verifying Installation...", progress);
        }

        public static Status Ready(bool gameInstalled, bool developerInstalled)
        {
            return new Status(Phase.Ready, new Installed(gameInstalled, developerInstalled));
        }

        public static Status Installing(double progress, string component)
        {
            return new Status(Phase.Installing, "Installing: " + component, progress);
        }
    }
}
