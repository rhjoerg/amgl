using amgl.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace amgl.model.content
{
    public class AmglDirectory
    {
        [XmlAttribute("name")]
        public string Name;

        [XmlElement("Directory")]
        public AmglDirectory[] Directories;

        [XmlIgnore]
        public AmglDirectory Parent;

        [XmlIgnore]
        public virtual string Path => System.IO.Path.Combine(Parent.Path, Name);

        protected void Link()
        {
            if (Directories == null)
                return;

            foreach (AmglDirectory directory in Directories)
            {
                directory.Parent = this;
                directory.Link();
            }
        }

        public delegate bool WalkDirectoriesCallback(AmglDirectory directory);

        public bool WalkDirectories(WalkDirectoriesCallback callback)
        {
            if (Directories == null)
                return true;

            foreach (AmglDirectory directory in Directories)
            {
                if (!callback(directory))
                    return false;

                if (!directory.WalkDirectories(callback))
                    return false;
            }

            return true;
        }
    }
}
