using amgl.model;
using System;

namespace amgl.main
{
    public class MainPresenter
    {
        private readonly MainForm form;

        public MainPresenter(MainForm form)
        {
            this.form = form;
        }

        public void Update(Status status)
        {
            form.InstallDirText.Text = status.InstallDir;

            switch (status.State)
            {
                case Status.StateEnum.Cancelled:
                    form.MessageLabel.Text = "Cancelled.";
                    break;

                case Status.StateEnum.Verifying:
                    form.MessageLabel.Text = "Verifying Installation...";
                    break;

                case Status.StateEnum.Ready:
                    form.MessageLabel.Text = "Ready.";
                    break;
            }

            form.ProgressBar.Value = (int) Math.Round(1000 * status.Progress);
        }
    }
}
