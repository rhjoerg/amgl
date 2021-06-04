using amgl.action;
using amgl.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.ui
{
    public class MainController
    {
        private readonly MainPresenter presenter;

        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        private IProgress<Status> Progress
        {
            get { return new Progress<Status>(status => presenter.Update(status)); }
        }

        private CancellationToken Token
        {
            get { return cancellationTokenSource.Token; }
        }

        public MainController(MainPresenter presenter)
        {
            this.presenter = presenter;

            presenter.Load += OnLoad;
            presenter.Closing += OnClosing;

            presenter.InstallGame += OnInstallGame;
        }

        private async void OnLoad()
        {
            try
            {
                await Verifyer.Verify(Progress, Token);
            }
            catch (OperationCanceledException)
            {
                // ignored
            }
        }

        private void OnClosing()
        {
            cancellationTokenSource.Cancel();
        }

        private async void OnInstallGame()
        {
            try
            {
                await Installer.InstallGame(Progress, Token);
            }
            catch (OperationCanceledException)
            {
                // ignored
            }
        }
    }
}
