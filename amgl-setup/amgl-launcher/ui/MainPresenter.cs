using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.ui
{
    public class MainPresenter
    {
        public readonly MainForm Form;

        public MainPresenter()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form = new MainForm();
        }
    }
}
