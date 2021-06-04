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

        private Status(Phase phase, Installed installed)
        {
            Phase = phase;
            Installed = installed;
        }

        public static Status Verifying()
        {
            return new Status(Phase.Verifying, Installed.NotInstalled);
        }

        public static Status Ready(bool gameInstalled, bool developerInstalled)
        {
            return new Status(Phase.Ready, new Installed(gameInstalled, developerInstalled));
        }

        public static Status Installing()
        {
            return new Status(Phase.Installing, Installed.NotInstalled);
        }
    }
}
