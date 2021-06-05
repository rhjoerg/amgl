using amgl.model;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace amgl
{
    class AmglContentCreator
    {
        private static readonly XmlWriterSettings Settings = new XmlWriterSettings();
        private static readonly XmlSerializer Serializer = new XmlSerializer(typeof(AmglContent));

        static void Main(string[] args)
        {
            Initialize();

            AmglContent content = new AmglContent();
            AmglBase eclipse = new AmglBase("eclipse", "https://download.eclipse.org/");
            AmglDirectory downloads = new AmglDirectory("downloads");

            AmglArchive jreArchive = new AmglArchive("jre", "jre.zip", eclipse,
                "justj/jres/15/updates/release/15.0.2/plugins/org.eclipse.justj.openjdk.hotspot.jre.full.win32.x86_64_15.0.2.v20210201-0955.jar");

            content.Add(eclipse);
            content.Add(downloads);
            downloads.Add(jreArchive);

            Write(content, "game.xml");
        }

        private static void Initialize()
        {
            Settings.Encoding = System.Text.Encoding.UTF8;
            Settings.Indent = true;
        }

        private static void Write(AmglContent content, string path)
        {
            if (File.Exists(path))
                File.Delete(path);

            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                using (XmlWriter writer = XmlWriter.Create(stream, Settings))
                {
                    Serializer.Serialize(writer, content);
                }
            }
        }
    }
}
