using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglBase : AmglElement
    {
        [XmlAttribute("Id")]
        public string Id;

        [XmlAttribute("Href")]
        public string Href;

        public AmglBase(AmglContent parent, string id, string href) : base(parent, "")
        {
            Id = id;
            Href = href;

            if (parent != null)
                parent.Bases.Add(this);
        }
        public AmglBase() : this(null, null, null)
        {
        }
    }
}
