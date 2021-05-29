using amgl.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace amgl.utils
{
    public class Contents
    {
        public static Content Load(string path)
        {
            using (TextReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Content));

                return (Content) serializer.Deserialize(reader);
            }
        }
    }
}
