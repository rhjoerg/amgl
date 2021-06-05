using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglDirectory
    {
        [XmlAttribute("Name")]
        public string Name;

        [XmlElement("Directory")]
        public AmglDirectory[] DirectoriesArray;

        [XmlIgnore]
        public List<AmglDirectory> Directories => new List<AmglDirectory>(DirectoriesArray ?? new AmglDirectory[0]);

        [XmlElement("Archive")]
        public AmglArchive[] ArchivesArray;

        [XmlIgnore]
        public List<AmglArchive> Archives => new List<AmglArchive>(ArchivesArray ?? new AmglArchive[0]);

        [XmlElement("File")]
        public AmglFile[] FilesArray;

        [XmlIgnore]
        public List<AmglFile> Files => new List<AmglFile>(FilesArray ?? new AmglFile[0]);

        [XmlIgnore]
        public AmglDirectory Parent;

        [XmlIgnore]
        public virtual string Path => System.IO.Path.Combine(Parent.Path, Name);

        public AmglDirectory()
        {
        }

        public AmglDirectory(string name)
        {
            Name = name;
        }

        public void AddDirectory(AmglDirectory directory)
        {
            if (DirectoriesArray == null) DirectoriesArray = new AmglDirectory[0];
            Array.Resize(ref DirectoriesArray, DirectoriesArray.Length + 1);
            DirectoriesArray[^1] = directory;
        }

        public void AddArchive(AmglArchive archive)
        {
            if (ArchivesArray == null) ArchivesArray = new AmglArchive[0];
            Array.Resize(ref ArchivesArray, ArchivesArray.Length + 1);
            ArchivesArray[^1] = archive;
        }

        public void AddFile(AmglFile file)
        {
            if (FilesArray == null) FilesArray = new AmglFile[0];
            Array.Resize(ref FilesArray, FilesArray.Length + 1);
            FilesArray[^1] = file;
        }

        public delegate bool WalkCallback<T>(T obj);
        public delegate bool WalkCallbackEx<T>(AmglDirectory parent, T obj);

        public bool WalkDirectories(WalkCallback<AmglDirectory> callback)
        {
            foreach (AmglDirectory directory in Directories)
            {
                if (!callback(directory)) return false;
                if (!directory.WalkDirectories(callback)) return false;
            }
            return true;
        }

        public bool WalkDirectories(WalkCallbackEx<AmglDirectory> callback)
        {
            foreach (AmglDirectory directory in Directories)
            {
                if (!callback(this, directory)) return false;
                if (!directory.WalkDirectories(callback)) return false;
            }
            return true;
        }

        public bool WalkArchives(WalkCallback<AmglArchive> callback)
        {
            foreach (AmglArchive archive in Archives)
                if (!callback(archive)) return false;

            foreach (AmglDirectory directory in Directories)
                if (!directory.WalkArchives(callback)) return false;

            return true;
        }

        public bool WalkArchives(WalkCallbackEx<AmglArchive> callback)
        {
            foreach (AmglArchive archive in Archives)
                if (!callback(this, archive)) return false;

            foreach (AmglDirectory directory in Directories)
                if (!directory.WalkArchives(callback)) return false;

            return true;
        }

        public bool WalkFiles(WalkCallback<AmglFile> callback)
        {
            foreach (AmglFile file in Files)
                if (!callback(file)) return false;

            foreach (AmglDirectory directory in Directories)
                if (!directory.WalkFiles(callback)) return false;

            return true;
        }

        public bool WalkFiles(WalkCallbackEx<AmglFile> callback)
        {
            foreach (AmglFile file in Files)
                if (!callback(this, file)) return false;

            foreach (AmglDirectory directory in Directories)
                if (!directory.WalkFiles(callback)) return false;

            return true;
        }
    }
}
