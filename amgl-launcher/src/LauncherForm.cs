using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl_launcher
{
    public partial class LauncherForm : Form
    {
        private readonly Status status;

        public LauncherForm(Status status)
        {
            this.status = status;
            this.status.Changed += new Status.ChangedHandler(this.status_Changed);

            InitializeComponent();

            directoryText.Text = status.Directory;

            status_Changed();
            status.Update();
        }

        private void status_Changed()
        {
            installButton.Enabled = status.InstallRequired;
            updateButton.Enabled = status.UpdateAvailable;
            playButton.Enabled = status.Playable;
        }

        private void installButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
