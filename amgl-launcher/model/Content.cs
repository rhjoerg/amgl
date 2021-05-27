
using System.Xml.Serialization;

namespace amgl.model
{
    public class LauncherModel
    {
        [XmlAttribute("version")]
        public string Version;
    }

    [XmlRoot(ElementName = "content")]
    public class ContentModel
    {
        [XmlElement(ElementName = "launcher")]
        public LauncherModel Launcher;
    }
}
