using amgl.model;
using amgl.model.content;
using amgl.util;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Installer
    {
        public static async Task InstallGame(IProgress<Status> progress, CancellationToken cancel)
        {
            await Install(progress, cancel, Sites.AMGL + Files.GameXmlName, Files.GameXmlPath);
        }

        public static async Task InstallDeveloper(IProgress<Status> progress, CancellationToken cancel)
        {
            await Install(progress, cancel, Sites.AMGL + Files.DeveloperXmlName, Files.DeveloperXmlPath);
        }

        private static async Task Install(IProgress<Status> progress, CancellationToken cancel,
            string contentSrc, string contentDst)
        {
            await Task.Run(() =>
            {
                progress.Report(Status.Installing());
                Downloader.Download(contentSrc, contentDst);

                AmglContent content = AmglContent.Load(contentDst);

                Install(progress, cancel, content);
            });

            await Verifyer.Verify(progress, cancel);
        }

        private static void Install(IProgress<Status> progress, CancellationToken cancel, AmglContent content)
        {
            content.WalkDirectories(directory =>
            {
                if (!Directory.Exists(directory.Path))
                    Directory.CreateDirectory(directory.Path);

                return true;
            });
        }
    }
}
