using amgl.model;
using System.IO;
using System.Net;

namespace amgl
{
    class AmglContentCreator
    {
        static void Main(string[] args)
        {
            AmglContent content = new AmglContent("0.0.0.1");
            AmglBase eclipseBase = new AmglBase(content, "eclipse", "https://download.eclipse.org/");
            AmglDirectory downloadsDir = new AmglDirectory(content, "downloads");

            _ = new AmglArchive(downloadsDir, "jre", "jre.zip", eclipseBase,
                "justj/jres/15/updates/release/15.0.2/plugins/org.eclipse.justj.openjdk.hotspot.jre.full.win32.x86_64_15.0.2.v20210201-0955.jar");

            content.Write("game.xml");

            AmglContent content2 = AmglContent.Read("game.xml");
        }

        private void Download(string src, string dst)
        {
            if (File.Exists(dst)) return;

            WebClient webClient = new WebClient();

            webClient.DownloadFile(src, dst);
        }
    }
}
