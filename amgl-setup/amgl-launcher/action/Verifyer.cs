using amgl.model;
using amgl.model.content;
using amgl.util;
using System;
using System.Collections.Generic;
using System.IO;
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
            await Task.Run(() =>
            {
                progress.Report(Status.Verifying());

                bool gameInstalled = Verify(Files.GameXmlPath);
                bool developerInstalled = Verify(Files.DeveloperXmlPath);

                progress.Report(Status.Ready(gameInstalled, developerInstalled));
            });
        }

        private static bool Verify(string contentPath)
        {
            if (!File.Exists(contentPath))
                return false;

            AmglContent content = AmglContent.Load(contentPath);

            return Verify(content);
        }

        private static bool Verify(AmglContent content)
        {
            return content.WalkDirectories(directory => Directory.Exists(directory.Path));
        }
    }
}
