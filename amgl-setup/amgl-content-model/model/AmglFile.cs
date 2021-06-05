using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglFile
    {
        [XmlAttribute("Name")]
        public string Name;

        [XmlAttribute("Archive")]
        public string ArchiveId;

        [XmlAttribute("Entry")]
        public string Entry;

        [XmlAttribute("Base")]
        public string BaseId;

        [XmlAttribute("Source")]
        public string Source;

        public AmglFile()
        {
        }

        public AmglFile(string name, AmglArchive archive, string entry)
        {
            Name = name;
            ArchiveId = archive.Id;
            Entry = entry;
        }

        public AmglFile(string name, AmglBase @base, string source)
        {
            Name = name;
            BaseId = @base.Id;
            Source = source;
        }

        public AmglFile(string name, string source)
        {
            Name = name;
            Source = source;
        }
    }
}
