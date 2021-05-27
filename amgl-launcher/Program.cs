using amgl.main;
using System;
using System.Windows.Forms;

namespace amgl
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm form = new MainForm();

            Application.Run(form);
        }
    }
}
