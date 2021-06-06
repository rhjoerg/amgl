using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace amgl.model
{
    [XmlRoot("Content")]
    public class AmglContent : AmglDirectory
    {
        [XmlIgnore]
        public override AmglContent Content => this;

        [XmlIgnore]
        public override string Path => "";

        [XmlAttribute("Version")]
        public string VersionString;

        [XmlIgnore]
        public Version Version => Version.Parse(VersionString);

        [XmlElement("Base")]
        public List<AmglBase> Bases;

        [XmlIgnore]
        public Dictionary<string, AmglArchive> ArchivesMap
        {
            get
            {
                Dictionary<string, AmglArchive> map = new Dictionary<string, AmglArchive>();
                WalkArchives(a => { map[a.Id] = a; return true; });
                return map;
            }
        }

        [XmlIgnore]
        public Dictionary<string, AmglBase> BasesMap
        {
            get
            {
                Dictionary<string, AmglBase> map = new Dictionary<string, AmglBase>();
                Bases.ForEach(b => { map[b.Id] = b; });
                return map;
            }
        }

        public AmglContent()
        {
            Bases = new List<AmglBase>();
        }

        public AmglContent(string version) : this()
        {
            VersionString = version;
        }

        public override void Dispose()
        {
            WalkBases(b => { b.Dispose(); return true; });
            Bases.Clear();

            base.Dispose();
        }

        public bool WalkBases(WalkCallback<AmglBase> cb)
        {
            return Bases.Find(b => !cb(b)) == null;
        }

        public bool WalkBases(WalkCallbackEx<AmglBase> cb)
        {
            return Bases.Find(b => !cb(this, b)) == null;
        }

        private void Link()
        {
            WalkDirectories((p, i) => { i.Parent = p; return true; });
            WalkArchives((p, i) => { i.Parent = p; return true; });
            WalkFiles((p, i) => { i.Parent = p; return true; });
            WalkBases((p, i) => { i.Parent = p; return true; });

            Dictionary<string, AmglBase> basesMap = BasesMap;
            Dictionary<string, AmglArchive> archivesMap = ArchivesMap;

            WalkArchives(i => { if (i.BaseId != null) i.Base = basesMap[i.BaseId]; return true; });

            WalkFiles(i => { if (i.BaseId != null) i.Base = basesMap[i.BaseId]; return true; });
            WalkFiles(i => { if(i.ArchiveId != null) i.Archive = archivesMap[i.ArchiveId]; return true; });
        }

        public void Write(string path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlSerializer serializer = new XmlSerializer(typeof(AmglContent));

            settings.Encoding = System.Text.Encoding.UTF8;
            settings.Indent = true;

            if (File.Exists(path))
                File.Delete(path);

            using Stream stream = new FileStream(path, FileMode.Create);
            using XmlWriter writer = XmlWriter.Create(stream, settings);

            serializer.Serialize(writer, this);
        }

        public static AmglContent Read(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AmglContent));
            using Stream stream = new FileStream(path, FileMode.Open);
            AmglContent content = (AmglContent)serializer.Deserialize(stream);

            content.Link();

            return content;
        }
    }
}
