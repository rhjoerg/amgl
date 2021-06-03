using amgl.action;
using System.Windows.Forms;

namespace amgl.ui
{
    public class UI
    {
        private readonly ProgressPanel progressPanel;
        private readonly ProgressPresenter progressPresenter;

        private readonly InstallPanel installPanel;
        private readonly InstallPresenter installPresenter;

        private readonly MainForm mainForm;
        private readonly MainPresenter mainPresenter;
        private readonly MainController mainController;

        public UI(Worker worker)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            progressPanel = new ProgressPanel();
            progressPresenter = new ProgressPresenter(progressPanel);

            installPanel = new InstallPanel();
            installPresenter = new InstallPresenter(installPanel);

            mainForm = new MainForm();
            mainPresenter = new MainPresenter(mainForm, progressPresenter);
            mainController = new MainController(worker, mainPresenter);
        }

        public void Run()
        {
            Application.Run(mainForm);
        }
    }
}
