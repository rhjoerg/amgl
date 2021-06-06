using System;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglElement : IDisposable
    {
        [XmlIgnore]
        public AmglDirectory Parent;

        [XmlAttribute("Name")]
        public string Name;

        [XmlIgnore]
        public virtual AmglContent Content => Parent.Content;

        [XmlIgnore]
        public virtual string Path => System.IO.Path.Combine(Parent.Path, Name);

        protected AmglElement(AmglDirectory parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        public virtual void Dispose()
        {
            Parent = null;
        }
    }
}
