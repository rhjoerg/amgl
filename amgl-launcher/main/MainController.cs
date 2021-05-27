
using amgl.actions;
using amgl.model;
using System;
using System.Threading;
using System.Windows.Forms;

namespace amgl.main
{
    class MainController
    {
        private readonly MainForm form;
        private readonly MainPresenter presenter;

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public MainController(MainForm form, MainPresenter presenter)
        {
            this.form = form;
            this.presenter = presenter;

            form.Load += Form_Load;
            form.FormClosing += Form_FormClosing;

            Status.Changed += Status_Changed; ;
        }

        public void Run()
        {
            Application.Run(form);
        }

        private async void Form_Load(object sender, EventArgs e)
        {
            presenter.UpdateButtons();
            await Initializer.Initialize(cancellationTokenSource.Token);
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                cancellationTokenSource.Cancel();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void Status_Changed()
        {
            presenter.UpdateButtons();
        }
    }
}
