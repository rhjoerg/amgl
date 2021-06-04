using amgl.model;
using amgl.model.content;
using amgl.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Installer
    {
        public static async Task InstallGame(IProgress<Status> progress, CancellationToken cancel)
        {
            await Install(progress, cancel, Sites.AMGL + FileUtils.GameXmlName, FileUtils.GameXmlPath);
        }

        public static async Task InstallDeveloper(IProgress<Status> progress, CancellationToken cancel)
        {
            await Install(progress, cancel, Sites.AMGL + FileUtils.DeveloperXmlName, FileUtils.DeveloperXmlPath);
        }

        private static async Task Install(IProgress<Status> progress, CancellationToken cancel,
            string contentSrc, string contentDst)
        {
            await Task.Run(() =>
            {
                progress.Report(Status.Installing(0.0, ""));
                Downloader.Download(contentSrc, contentDst);

                AmglContent content = AmglContent.Load(contentDst);

                Install(progress, cancel, content);
            });

            await Verifyer.Verify(progress, cancel);
        }

        private static void Install(IProgress<Status> progress, CancellationToken cancel, AmglContent content)
        {
            ProgressRange range = new ProgressRange(0.0, 1.0);
            int steps = 0;
            int step = 0;

            content.WalkDirectories((parent, directory) => { ++steps; return true; });
            content.WalkArchives((parent, archive) => { ++steps; return true; });
            content.WalkFiles((parent, file) => { ++steps; return true; });

            content.WalkDirectories((parent, directory) =>
            {
                progress.Report(Status.Installing(range.Interpolate(++step, steps), directory.Name));

                if (!Directory.Exists(directory.Path))
                    Directory.CreateDirectory(directory.Path);

                return true;
            });

            content.WalkFiles((parent, file) =>
            {
                if (!File.Exists(file.Path))
                {
                    if (file.Archive != null)
                        file.Archive.Required = true;
                }

                return true;
            });

            using (ZipArchives zips = new ZipArchives())
            {
                content.WalkArchives((parent, archive) =>
                {
                    progress.Report(Status.Installing(range.Interpolate(++step, steps), archive.Name));

                    if (!archive.Required)
                        return true;

                    Downloader.Download(archive.Source, archive.Path);
                    zips.Add(archive.Id, archive.Path);

                    return true;
                });

                content.WalkFiles((parent, file) => {

                    progress.Report(Status.Installing(range.Interpolate(++step, steps), file.Name));

                    if (File.Exists(file.Path))
                        return true;

                    if (file.Archive != null)
                    {
                        ZipArchive zip = zips[file.Archive.Id];
                        ZipArchiveEntry entry = zip.GetEntry(file.Entry);

                        using (Stream input = entry.Open())
                        {
                            using (Stream output = new FileStream(file.Path, FileMode.Create))
                            {
                                input.CopyTo(output);
                            }
                        }
                    }

                    return true;
                });
            }

            content.WalkArchives((parent, archive) =>
            {
                if (File.Exists(archive.Path))
                    File.Delete(archive.Path);

                return true;
            });
        }
    }
}
