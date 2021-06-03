using amgl.action;
using amgl.model;
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
        private readonly Worker worker;
        private readonly MainPresenter presenter;

        public MainController(Worker worker, MainPresenter presenter)
        {
            this.worker = worker;
            this.presenter = presenter;

            worker.Changed += Worker_Changed;
            presenter.Load += OnLoad;
        }

        private void OnLoad()
        {
            worker.Initialize();
        }

        private void Worker_Changed(Status status)
        {
            presenter.Update(status);
        }
    }
}
