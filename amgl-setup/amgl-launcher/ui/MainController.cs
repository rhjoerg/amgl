using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.ui
{
    public class MainController
    {
        private readonly MainPresenter presenter;

        public MainController()
        {
            presenter = new MainPresenter();
        }

        public void Run()
        {
            Application.Run(presenter.Form);
        }
    }
}
