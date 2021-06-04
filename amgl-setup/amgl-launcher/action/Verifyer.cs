using amgl.model;
using amgl.model.content;
using amgl.util;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Verifyer
    {
        private static readonly ProgressRange gameProgressRange = new ProgressRange(0.0, 0.5);
        private static readonly ProgressRange developerProgressRange = new ProgressRange(0.5, 1.0);

        public static async Task Verify(IProgress<Status> progress, CancellationToken cancel)
        {
            await Task.Run(() =>
            {
                progress.Report(Status.Verifying(0.0));

                bool gameInstalled = Verify(progress, gameProgressRange, FileUtils.GameXmlPath);
                bool developerInstalled = Verify(progress, developerProgressRange, FileUtils.DeveloperXmlPath);

                progress.Report(Status.Ready(gameInstalled, developerInstalled));
            });
        }

        private static bool Verify(IProgress<Status> progress, ProgressRange progressRange, string contentPath)
        {
            if (!File.Exists(contentPath))
                return false;

            AmglContent content = AmglContent.Load(contentPath);

            return Verify(progress, progressRange, content);
        }

        private static bool Verify(IProgress<Status> progress, ProgressRange progressRange, AmglContent content)
        {
            int steps = 0;
            int step = 0;

            content.WalkDirectories((parent, directory) => { ++steps; return true;  });
            content.WalkFiles((parent, file) => { ++steps; return true; });

            return
                content.WalkDirectories((parent, directory) =>
                {
                    progress.Report(Status.Verifying(progressRange.Interpolate(++step, steps)));

                    return Directory.Exists(directory.Path);
                })
                &&
                content.WalkFiles((parent, file) =>
                {
                    progress.Report(Status.Verifying(progressRange.Interpolate(++step, steps)));

                    return File.Exists(file.Path);
                });
        }
    }
}
