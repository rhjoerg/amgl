using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace amgl.model.content
{
    public class AmglArchive : AmglFile
    {
        [XmlAttribute("Id")]
        public string Id;

        [XmlAttribute("Source")]
        public string Source;

        [XmlIgnore]
        public bool Required = false;
    }
}
