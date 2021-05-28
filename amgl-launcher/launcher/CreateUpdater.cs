using amgl.launcher;
using amgl.utils;
using System;
using System.Diagnostics;
using System.IO;

namespace amgl.launcher
{
    public class CreateUpdater
    {
        private static readonly string ResourceHackerPath = Path.Combine(Files.InstallDir, "ResourceHacker.exe");

        private static readonly string RcName = "amgl-updater.rc";
        private static readonly string RcPath = Path.Combine(Files.InstallDir, RcName);

        private static readonly string ResName = "amgl-updater.res";

        private static readonly string CompilerArgs =
            "-open " + RcName + " -save " + ResName + " -action compile -log NUL";

        private static readonly string LinkerArgs =
            "-open " + Files.UpdaterName
            + " -resource " + ResName
            + " -save " + Files.UpdaterName
            + " -action addoverwrite "
            + "-mask \"Version info\"";

        public static bool CanCreate
        {
            get { return !File.Exists(Files.UpdaterPath) && File.Exists(ResourceHackerPath); }
        }

        public static void Run(Version version)
        {
            CreateResource(version);
            Processes.Run(ResourceHackerPath, CompilerArgs, false);
            File.Copy(Files.LauncherPath, Files.UpdaterPath);
            Processes.Run(ResourceHackerPath, LinkerArgs, false);
        }

        private static void CreateResource(Version v)
        {
            FileVersionInfo vi = FileVersionInfo.GetVersionInfo(Files.AssemblyPath);

            string output = UpdaterResources.VersionTemplate
                .Replace("${Major}", v.Major.ToString())
                .Replace("${Minor}", v.Minor.ToString())
                .Replace("${Build}", v.Build.ToString())
                .Replace("${Revision}", v.Revision.ToString())
                .Replace("${Comments}", vi.Comments)
                .Replace("${CompanyName}", vi.CompanyName)
                .Replace("${FileDescription}", vi.FileDescription)
                .Replace("${InternalName}", vi.InternalName)
                .Replace("${LegalCopyright}", vi.LegalCopyright)
                .Replace("${LegalTrademarks}", vi.LegalTrademarks)
                .Replace("${OriginalFilename}", vi.OriginalFilename)
                .Replace("${ProductName}", vi.ProductName);

            using (StreamWriter sw = new StreamWriter(RcPath))
            {
                sw.Write(output);
            }
        }
    }
}