using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglBase
    {
        [XmlAttribute("Id")]
        public string Id;

        [XmlAttribute("Href")]
        public string Href;

        public AmglBase()
        {
        }

        public AmglBase(string id, string href)
        {
            Id = id;
            Href = href;
        }
    }
}
