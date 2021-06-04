using amgl.util;
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
        public override string Path => FileUtils.InstallDir;

        [XmlIgnore]
        public Dictionary<string, AmglArchive> ArchiveMap = new Dictionary<string, AmglArchive>();

        protected void Link()
        {
            WalkDirectories((parent, directory) => { directory.Parent = parent; return true; });
            WalkArchives((parent, archive) => { archive.Parent = parent; return true; });
            WalkFiles((parent, file) => { file.Parent = parent; return true; });

            WalkArchives((parent, archive) => { ArchiveMap[archive.Id] = archive; return true; });

            WalkFiles((parent, file) =>
            {
                if (file.ArchiveId != null)
                    file.Archive = ArchiveMap[file.ArchiveId];

                return true;
            });
        }

        public static AmglContent Load(string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                AmglContent content = (AmglContent) Serializer.Deserialize(stream);

                content.Link();

                return content;
            }
        }
    }
}
