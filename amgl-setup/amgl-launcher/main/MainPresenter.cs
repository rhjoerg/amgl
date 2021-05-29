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
        private readonly Dictionary<Status.StateEnum, Color> messageColors = new Dictionary<Status.StateEnum, Color>();
        private readonly Dictionary<Status.StateEnum, Color> barColors = new Dictionary<Status.StateEnum, Color>();

        public MainPresenter(MainForm form)
        {
            this.form = form;

            installable[Status.StateEnum.Cancelled] = false;
            installable[Status.StateEnum.Verifying] = false;
            installable[Status.StateEnum.Ready] = false;

            playable[Status.StateEnum.Cancelled] = false;
            playable[Status.StateEnum.Verifying] = false;
            playable[Status.StateEnum.Ready] = true;

            messages[Status.StateEnum.Cancelled] = "Cancelled.";
            messages[Status.StateEnum.Verifying] = "Verifying Installation...";
            messages[Status.StateEnum.Ready] = "Ready.";

            messageColors[Status.StateEnum.Cancelled] = Color.Red;
            messageColors[Status.StateEnum.Verifying] = Color.Black;
            messageColors[Status.StateEnum.Ready] = Color.Black;

            barColors[Status.StateEnum.Cancelled] = Color.Red;
            barColors[Status.StateEnum.Verifying] = Color.Green;
            barColors[Status.StateEnum.Ready] = Color.Green;
        }

        public void Update(Status status)
        {
            form.InstallDirText.Text = status.InstallDir;

            form.InstallButton.Enabled = installable[status.State];
            form.PlayButton.Enabled = playable[status.State];

            form.MessageLabel.Text = messages[status.State];
            form.MessageLabel.ForeColor = messageColors[status.State];

            form.ProgressBar.Value = (int) Math.Round(1000 * status.Progress);
            form.ProgressBar.ForeColor = barColors[status.State];
        }
    }
}
