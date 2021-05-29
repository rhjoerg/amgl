using amgl.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    class Verify
    {
        public static async Task Run(CancellationToken cancellationToken, IProgress<Status> progress)
        {
            for (int i = 0; i < 10; ++i)
            {
                await Task.Delay(1000);
                progress.Report(Status.Verifying((i + 1) / 10.0));
                cancellationToken.ThrowIfCancellationRequested();
            }

            progress.Report(Status.Ready());
        }
    }
}
