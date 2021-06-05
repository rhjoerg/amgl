using System;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglDirectory
    {
        [XmlAttribute("Name")]
        public string Name;

        [XmlElement("Directory")]
        public AmglDirectory[] Directories;

        [XmlElement("Archive")]
        public AmglArchive[] Archives;

        public AmglDirectory()
        {
        }

        public AmglDirectory(string name)
        {
            Name = name;
        }

        public void Add(AmglDirectory directory)
        {
            if (Directories == null)
                Directories = new AmglDirectory[0];

            Array.Resize(ref Directories, Directories.Length + 1);
            Directories[Directories.Length - 1] = directory;
        }

        public void Add(AmglArchive archive)
        {
            if (Archives == null)
                Archives = new AmglArchive[0];

            Array.Resize(ref Archives, Archives.Length + 1);
            Archives[Archives.Length - 1] = archive;
        }
    }
}
