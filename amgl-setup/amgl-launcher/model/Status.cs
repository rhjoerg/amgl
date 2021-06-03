using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amgl.model
{
    public class Status
    {
        public readonly Phase Phase;

        private Status(Phase phase)
        {
            Phase = phase;
        }

        public static Status Verifying()
        {
            return new Status(Phase.Verifying);
        }
    }
}
