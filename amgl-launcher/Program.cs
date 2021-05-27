using amgl.main;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace amgl
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            Console.WriteLine(fileVersion);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MainPresenter presenter = new MainPresenter(form);
            MainController controller = new MainController(form, presenter);

            controller.Run();
        }
    }
}
