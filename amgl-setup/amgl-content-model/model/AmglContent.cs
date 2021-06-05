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
        public override string Path => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [XmlAttribute("Version")]
        public string VersionString;

        [XmlIgnore]
        public Version Version => Version.Parse(VersionString);

        [XmlElement("Base")]
        public AmglBase[] BasesArray;

        [XmlIgnore]
        public List<AmglBase> Bases => new List<AmglBase>(BasesArray ?? new AmglBase[0]);

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
        }

        public AmglContent(string version)
        {
            VersionString = version;
        }

        public void AddBase(AmglBase bas)
        {
            if (BasesArray == null)
                BasesArray = new AmglBase[0];

            Array.Resize(ref BasesArray, BasesArray.Length + 1);
            BasesArray[^1] = bas;
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

            return (AmglContent) serializer.Deserialize(stream);
        }
    }
}
