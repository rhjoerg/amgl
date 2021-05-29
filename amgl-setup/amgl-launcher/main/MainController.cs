using amgl.action;
using amgl.model;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.main
{
    public class MainController
    {
        private readonly MainForm form;
        private readonly MainPresenter presenter;

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private readonly Progress<Status> progress = new Progress<Status>();

        public MainController(MainForm form, MainPresenter presenter)
        {
            this.form = form;
            this.presenter = presenter;

            progress.ProgressChanged += Progress_ProgressChanged;

            form.Load += Form_Load;
            form.FormClosing += Form_FormClosing;

            form.ExitButton.Click += ExitButton_Click;
        }

        ~MainController()
        {
            form.ExitButton.Click -= ExitButton_Click;

            form.FormClosing -= Form_FormClosing;
            form.Load -= Form_Load;

            progress.ProgressChanged -= Progress_ProgressChanged;

            cancellationTokenSource.Dispose();
        }

        public void Run()
        {
            Application.Run(this.form);
        }

        private void Progress_ProgressChanged(object sender, Status status)
        {
            presenter.Update(status);
        }

        private async void Form_Load(object sender, System.EventArgs e)
        {
            try
            {
                await Verify.Run(cancellationTokenSource.Token, progress);
            }
            catch(OperationCanceledException)
            {
                presenter.Update(Status.Cancelled());
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            form.Close();
        }
    }
}
