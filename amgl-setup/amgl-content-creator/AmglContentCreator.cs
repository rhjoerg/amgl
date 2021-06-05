using amgl.model;
using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Xml.Serialization;

namespace amgl
{
    class AmglContentCreator
    {
        static void Main(string[] args)
        {
            AmglContent content = new AmglContent("0.0.0.1");
            AmglBase eclipseBase = new AmglBase("eclipse", "https://download.eclipse.org/");
            AmglDirectory downloadsDir = new AmglDirectory("downloads");

            AmglArchive jreArchive = new AmglArchive("jre", "jre.zip", eclipseBase,
                "justj/jres/15/updates/release/15.0.2/plugins/org.eclipse.justj.openjdk.hotspot.jre.full.win32.x86_64_15.0.2.v20210201-0955.jar");

            content.AddBase(eclipseBase);
            content.AddDirectory(downloadsDir);
            downloadsDir.AddArchive(jreArchive);

            content.Write("game.xml");
        }

        private void Download(string src, string dst)
        {
            if (File.Exists(dst)) return;

            WebClient webClient = new WebClient();

            webClient.DownloadFile(src, dst);
        }
    }
}
