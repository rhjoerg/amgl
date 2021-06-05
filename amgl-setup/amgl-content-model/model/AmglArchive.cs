using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglArchive : AmglFile
    {
        [XmlAttribute("Id")]
        public string Id;

        [XmlIgnore]
        public bool Required = false;

        public AmglArchive()
        {
        }

        public AmglArchive(string id, string name, AmglBase @base, string source) : base(name, @base, source)
        {
            Id = id;
        }

        public AmglArchive(string id, string name, string source) : base(name, source)
        {
            Id = id;
        }
    }
}
