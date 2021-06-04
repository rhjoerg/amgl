using amgl.action;
using amgl.ui;
using System;
using System.Drawing;

namespace amgl
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            UI ui = new UI();

            ui.Run();
        }
    }
}
