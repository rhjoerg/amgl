using amgl.main;
using System;
using System.Windows.Forms;

namespace amgl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();
            MainPresenter presenter = new MainPresenter(form);
            MainController controller = new MainController(form, presenter);

            controller.Run();
        }
    }
}
