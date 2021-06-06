using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglFile : AmglElement
    {
        [XmlIgnore]
        public AmglArchive Archive;

        [XmlAttribute("Archive")]
        public string ArchiveId;

        [XmlAttribute("Entry")]
        public string Entry;

        [XmlIgnore]
        public AmglBase Base;

        [XmlAttribute("Base")]
        public string BaseId;

        [XmlAttribute("Source")]
        public string Source;

        protected AmglFile(AmglDirectory parent, string name, AmglArchive archive, string entry, AmglBase bas, string source)
            : base(parent, name)
        {
            Archive = archive;
            Entry = entry;
            Base = bas;
            Source = source;

            if (parent != null) parent.Files.Add(this);
            if (archive != null) ArchiveId = archive.Id;
            if (bas != null) BaseId = bas.Id;
        }

        public AmglFile() : this(null, null, null, null, null, null)
        {
        }

        public AmglFile(AmglDirectory parent, string name, AmglArchive archive, string entry)
            : this(parent, name, archive, entry, null, null)
        {
        }

        public AmglFile(AmglDirectory parent, string name, AmglBase bas, string source)
            : this(parent, name, null, null, bas, source)
        {
        }

        public AmglFile(AmglDirectory parent, string name, string source)
            : this(parent, name, null, null, null, source)
        {
        }

        public override void Dispose()
        {
            Archive = null;
            Base = null;

            base.Dispose();
        }
    }
}
