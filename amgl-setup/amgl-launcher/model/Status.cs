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

        private Status(Phase phase)
        {
            Phase = phase;
        }

        public static Status Verifying()
        {
            return new Status(Phase.Verifying);
        }

        public static Status Ready()
        {
            return new Status(Phase.Ready);
        }
    }
}
