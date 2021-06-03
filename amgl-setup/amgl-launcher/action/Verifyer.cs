using amgl.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Verifyer
    {
        public static async Task Verify(IProgress<Status> progress, CancellationToken cancel)
        {
            progress.Report(Status.Verifying());
            progress.Report(Status.Ready());
        }
    }
}
