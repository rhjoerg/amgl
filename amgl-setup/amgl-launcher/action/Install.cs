using amgl.model;
using amgl.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Install
    {
        public static async Task Run(CancellationToken cancellationToken, IProgress<Status> progress)
        {

            try
            {
                Content content = GetContent();
            }
            catch (Exception ex)
            {
                progress.Report(Status.Error(ex.Message));
                return;
            }

            progress.Report(Status.Ready());
        }

        private static Content GetContent()
        {
            if (!File.Exists(Files.ContentPath))
                DownloadContent();

            return Contents.Load(Files.ContentPath);
        }

        private static void DownloadContent()
        {
            WebClient wc = new WebClient();
            Uri address = new Uri("https://github.com/rhjoerg/amgl/wiki/files/amgl-content.xml");

            wc.DownloadFile(address, Files.ContentPath + ".part");
        }
    }
}
