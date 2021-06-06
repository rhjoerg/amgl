using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglArchive : AmglElement
    {
        [XmlAttribute("Id")]
        public string Id;

        [XmlIgnore]
        public AmglBase Base;

        [XmlAttribute("Base")]
        public string BaseId;

        [XmlAttribute("Source")]
        public string Source;

        [XmlIgnore]
        public bool Required = false;

        public AmglArchive(AmglDirectory parent, string id, string name, AmglBase bas, string source) : base(parent, name)
        {
            Id = id;
            Base = bas;
            Source = source;

            if (parent != null) parent.Archives.Add(this);
            if (bas != null) BaseId = bas.Id;
        }

        public AmglArchive()
            : this(null, null, null, null, null)
        {
        }

        public AmglArchive(AmglDirectory parent, string id, string name, string source)
            : this(parent, id, name, null, source)
        {
        }

        public override void Dispose()
        {
            Base = null;

            base.Dispose();
        }
    }
}
