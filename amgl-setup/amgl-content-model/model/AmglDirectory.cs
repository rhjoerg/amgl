using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace amgl.model
{
    public class AmglDirectory : AmglElement
    {
        [XmlElement("Directory")]
        public List<AmglDirectory> Directories;

        [XmlElement("Archive")]
        public List<AmglArchive> Archives;

        [XmlElement("File")]
        public List<AmglFile> Files;

        public AmglDirectory(AmglDirectory parent, string name) : base(parent, name)
        {
            Directories = new List<AmglDirectory>();
            Archives = new List<AmglArchive>();
            Files = new List<AmglFile>();

            if (parent != null)
                parent.Directories.Add(this);
        }

        public AmglDirectory() : this(null, null)
        {
        }

        public override void Dispose()
        {
            WalkDirectories(i => { i.Dispose(); return true; });
            WalkArchives(i => { i.Dispose(); return true; });
            WalkFiles(i => { i.Dispose(); return true; });

            Directories.Clear();
            Archives.Clear();
            Files.Clear();

            base.Dispose();
        }

        public delegate bool WalkCallback<T>(T obj);
        public delegate bool WalkCallbackEx<T>(AmglDirectory parent, T obj);

        public bool WalkDirectories(WalkCallback<AmglDirectory> cb)
        {
            return Directories.Find(d => !(cb(d) && d.WalkDirectories(cb))) == null;
        }

        public bool WalkDirectories(WalkCallbackEx<AmglDirectory> cb)
        {
            return Directories.Find(d => !(cb(this, d) && d.WalkDirectories(cb))) == null;
        }

        public bool WalkArchives(WalkCallback<AmglArchive> cb)
        {
            return Archives.Find(a => !cb(a)) == null && Directories.Find(d => !d.WalkArchives(cb)) == null;
        }

        public bool WalkArchives(WalkCallbackEx<AmglArchive> cb)
        {
            return Archives.Find(a => !cb(this, a)) == null && Directories.Find(d => !d.WalkArchives(cb)) == null;
        }

        public bool WalkFiles(WalkCallback<AmglFile> cb)
        {
            return Files.Find(f => !cb(f)) == null && Directories.Find(d => !d.WalkFiles(cb)) == null;
        }

        public bool WalkFiles(WalkCallbackEx<AmglFile> cb)
        {
            return Files.Find(f => !cb(this, f)) == null && Directories.Find(d => !d.WalkFiles(cb)) == null;
        }
    }
}
