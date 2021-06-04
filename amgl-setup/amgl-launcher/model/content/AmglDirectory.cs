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
        [XmlAttribute("Name")]
        public string Name;

        [XmlElement("Directory")]
        public AmglDirectory[] Directories;

        [XmlElement("Archive")]
        public AmglArchive[] Archives;

        [XmlElement("File")]
        public AmglFile[] Files;

        [XmlIgnore]
        public AmglDirectory Parent;

        [XmlIgnore]
        public virtual string Path => FileUtils.Combine(Parent.Path, Name);

        public delegate bool WalkDirectoriesCallback(AmglDirectory parent, AmglDirectory directory);

        public bool WalkDirectories(WalkDirectoriesCallback callback)
        {
            if (Directories == null)
                return true;

            foreach (AmglDirectory directory in Directories)
            {
                if (!callback(this, directory))
                    return false;

                if (!directory.WalkDirectories(callback))
                    return false;
            }

            return true;
        }

        public delegate bool WalkArchivesCallback(AmglDirectory parent, AmglArchive archive);

        public bool WalkArchives(WalkArchivesCallback callback)
        {
            if (Archives != null)
            {
                foreach (AmglArchive archive in Archives)
                {
                    if (!callback(this, archive))
                        return false;
                }
            }

            if (Directories != null)
            {
                foreach (AmglDirectory directory in Directories)
                {
                    if (!directory.WalkArchives(callback))
                        return false;
                }
            }

            return true;
        }

        public delegate bool WalkFilesCallback(AmglDirectory parent, AmglFile file);

        public bool WalkFiles(WalkFilesCallback callback)
        {
            if (Files != null)
            {
                foreach (AmglFile file in Files)
                {
                    if (!callback(this, file))
                        return false;
                }
            }

            if (Directories != null)
            {
                foreach (AmglDirectory directory in Directories)
                {
                    if (!directory.WalkFiles(callback))
                        return false;
                }
            }

            return true;
        }
    }
}
