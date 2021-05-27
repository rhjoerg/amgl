using amgl.actions;
using amgl.main;
using amgl.model;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace amgl
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            if (SelfUpdate())
                return;

            XmlSerializer serializer = new XmlSerializer(typeof(ContentModel));
            string filename = Path.Combine(Status.Directory, "amgl.content.xml");

            using (Stream reader = new FileStream(filename, FileMode.Open))
            {
                ContentModel content = (ContentModel) serializer.Deserialize(reader);
            }

            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            Console.WriteLine(fileVersion);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MainPresenter presenter = new MainPresenter(form);
            MainController controller = new MainController(form, presenter);

            controller.Run();
        }

        private static bool SelfUpdate()
        {
            string path = SelfUpdater.Update();

            if (path == null)
                return false;

            Process.Start(path);

            return true;
        }
    }
}
