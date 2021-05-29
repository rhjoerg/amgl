using amgl.model;
using amgl.utils;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (!File.Exists(Files.ContentPath))
            {
                progress.Report(Status.InstallationRequired());
                return;
            }

            Content content = Contents.Load(Files.ContentPath);

            progress.Report(Status.Ready());
        }
    }
}
