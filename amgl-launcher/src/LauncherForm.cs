﻿using System;
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
        private readonly Context context;

        public LauncherForm(Context context)
        {
            this.context = context;

            InitializeComponent();

            this.directoryLabel.Text = "Directory: " + this.context.Directory;
        }

        private void instalButton_Click(object sender, EventArgs e)
        {
            instalButton.Enabled = false;
            Thread.Sleep(2000);
            instalButton.Enabled = true;
        }
    }
}
