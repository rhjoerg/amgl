using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amgl.util
{
    public class ZipArchives : Dictionary<string, ZipArchive>, IDisposable
    {
        private List<Stream> streams = new List<Stream>();

        public void Add(string key, string path)
        {
            Stream stream = new FileStream(path, FileMode.Open);
            ZipArchive zip = new ZipArchive(stream);

            streams.Add(stream);
            this[key] = zip;
        }

        public void Dispose()
        {
            foreach (ZipArchive zip in Values)
                zip.Dispose();

            foreach (Stream stream in streams)
                stream.Dispose();

            streams.Clear();
            Clear();
        }
    }
}
