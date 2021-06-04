using amgl.model;
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

                bool gameInstalled = VerifyGame();
                bool developerInstalled = VerifyDeveloper();

                progress.Report(Status.Ready(gameInstalled, developerInstalled));
            });
        }

        private static bool VerifyGame()
        {
            if (!File.Exists(Files.GameXmlPath))
                return false;

            return true;
        }

        private static bool VerifyDeveloper()
        {
            if (!File.Exists(Files.DeveloperXmlPath))
                return false;

            return true;
        }
    }
}
