using amgl.model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace amgl.main
{
    public class MainPresenter
    {
        private readonly MainForm form;
        private readonly Dictionary<Status.StateEnum, bool> installable = new Dictionary<Status.StateEnum, bool>();
        private readonly Dictionary<Status.StateEnum, bool> playable = new Dictionary<Status.StateEnum, bool>();

        private readonly Dictionary<Status.StateEnum, string> messages = new Dictionary<Status.StateEnum, string>();
        private readonly Dictionary<Status.StateEnum, Color> colors = new Dictionary<Status.StateEnum, Color>();

        public MainPresenter(MainForm form)
        {
            this.form = form;

            installable[Status.StateEnum.Cancelled] = false;
            installable[Status.StateEnum.Error] = false;
            installable[Status.StateEnum.Ready] = false;
            installable[Status.StateEnum.InstallationRequired] = true;
            installable[Status.StateEnum.Verifying] = false;

            playable[Status.StateEnum.Cancelled] = false;
            playable[Status.StateEnum.Error] = false;
            playable[Status.StateEnum.Ready] = true;
            playable[Status.StateEnum.InstallationRequired] = false;
            playable[Status.StateEnum.Verifying] = false;

            messages[Status.StateEnum.Cancelled] = "Cancelled.";
            messages[Status.StateEnum.Error] = "Error: {0}";
            messages[Status.StateEnum.Ready] = "Ready.";
            messages[Status.StateEnum.InstallationRequired] = "Installation required!";
            messages[Status.StateEnum.Verifying] = "Verifying installation...";

            colors[Status.StateEnum.Cancelled] = Color.Red;
            colors[Status.StateEnum.Error] = Color.Red;
            colors[Status.StateEnum.Ready] = Color.Black;
            colors[Status.StateEnum.InstallationRequired] = Color.Red;
            colors[Status.StateEnum.Verifying] = Color.Black;
        }

        public void Update(Status status)
        {
            form.InstallDirText.Text = status.InstallDir;

            form.InstallButton.Enabled = installable[status.State];
            form.PlayButton.Enabled = playable[status.State];

            form.MessageLabel.Text = messages[status.State];
            form.MessageLabel.ForeColor = colors[status.State];

            form.ProgressBar.Value = (int) Math.Round(1000 * status.Progress);

            if (status.State == Status.StateEnum.Error)
                form.MessageLabel.Text = string.Format(messages[status.State], status.Message);
        }
    }
}
