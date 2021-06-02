using amgl.ui;
using System;

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
            MainController controller = new MainController();

            controller.Run();
        }
    }
}
