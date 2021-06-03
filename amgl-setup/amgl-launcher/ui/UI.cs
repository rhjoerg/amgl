using amgl.action;
using System.Windows.Forms;

namespace amgl.ui
{
    public class UI
    {
        private readonly ProgressPanel progressPanel;
        private readonly InstallPanel installPanel;

        private readonly MainForm mainForm;
        private readonly MainPresenter mainPresenter;
        private readonly MainController mainController;

        public UI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            progressPanel = new ProgressPanel();
            installPanel = new InstallPanel();

            mainForm = new MainForm();
            mainPresenter = new MainPresenter(mainForm, progressPanel, installPanel);
            mainController = new MainController(mainPresenter);
        }

        public void Run()
        {
            Application.Run(mainForm);
        }
    }
}
