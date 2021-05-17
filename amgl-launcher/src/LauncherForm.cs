using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl_launcher
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            Status.Changed += new Status.ChangedHandler(this.Status_Changed);

            InitializeComponent();
            Status_Changed();
            timer.Enabled = true;
        }
        private async void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            await Status.Update();
        }

        private void Status_Changed()
        {
            installButton.Enabled = Status.InstallRequired;
            updateButton.Enabled = Status.UpdateAvailable;
            playButton.Enabled = Status.Playable;
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
