using amgl.util;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace amgl.model.content
{
    [XmlRoot("Content")]
    public class AmglContent : AmglDirectory
    {
        public static readonly XmlSerializer Serializer = new XmlSerializer(typeof(AmglContent));

        [XmlIgnore]
        public override string Path => Files.InstallDir;

        public static AmglContent Load(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                AmglContent content = (AmglContent)Serializer.Deserialize(stream);

                content.Link();

                return content;
            }
        }
    }
}
