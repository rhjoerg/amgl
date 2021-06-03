using amgl.action;
using amgl.ui;
using System;
using System.Drawing;

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
            Worker worker = new Worker();
            UI ui = new UI(worker);

            ui.Run();
        }
    }
}
