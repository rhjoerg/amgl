using amgl.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace amgl.action
{
    public class Downloader
    {
        private static readonly WebClient webClient = new WebClient();

        public static void Download(string src, string dst)
        {
            if (File.Exists(dst))
                return;

            string part = dst + ".part";

            if (File.Exists(part))
                File.Delete(part);

            webClient.DownloadFile(src, part);

            File.Move(part, dst);
        }
    }
}
