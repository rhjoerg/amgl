using amgl.util;
using System.Xml.Serialization;

namespace amgl.model.content
{
    public class AmglFile
    {
        [XmlAttribute("Name")]
        public string Name;

        [XmlAttribute("Archive")]
        public string ArchiveId;

        [XmlAttribute("Entry")]
        public string Entry;

        [XmlIgnore]
        public AmglDirectory Parent;

        [XmlIgnore]
        public AmglArchive Archive;

        [XmlIgnore]
        public string Path => FileUtils.Combine(Parent.Path, Name);
    }
}
