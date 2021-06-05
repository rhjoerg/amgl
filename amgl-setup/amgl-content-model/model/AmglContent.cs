using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace amgl.model
{
    [XmlRoot("Content")]
    public class AmglContent : AmglDirectory
    {
        [XmlElement("Base")]
        public AmglBase[] Bases;

        public void Add(AmglBase Base)
        {
            if (Bases == null)
                Bases = new AmglBase[0];

            Array.Resize(ref Bases, Bases.Length + 1);
            Bases[Bases.Length - 1] = Base;
        }
    }
}
