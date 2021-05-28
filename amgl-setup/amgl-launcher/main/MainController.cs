using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.main
{
    public class MainController
    {
        private readonly MainForm form;
        private readonly MainPresenter presenter;

        public MainController(MainForm form, MainPresenter presenter)
        {
            this.form = form;
            this.presenter = presenter;
        }

        public void Run()
        {
            Application.Run(this.form);
        }
    }
}
