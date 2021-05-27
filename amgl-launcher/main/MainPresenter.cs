
using amgl.model;

namespace amgl.main
{
    public class MainPresenter
    {
        private readonly MainForm form;

        public MainPresenter(MainForm form)
        {
            this.form = form;
        }

        public void UpdateButtons()
        {
            form.InstallButton.Enabled = Status.UpdateRequired;
        }
    }
}
