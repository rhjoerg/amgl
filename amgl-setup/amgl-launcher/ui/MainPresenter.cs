using amgl.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace amgl.ui
{
    public class MainPresenter
    {
        public delegate void Handler();

        public event Handler Load;
        public event Handler Closing;

        private readonly MainForm form;

        private readonly ProgressPanel progressPanel;
        private readonly InstallPanel installPanel;
        private Control currentPanel = null;

        private readonly Dictionary<Phase, Control> panels = new Dictionary<Phase, Control>();

        public MainPresenter(MainForm form, ProgressPanel progressPanel, InstallPanel installPanel)
        {
            this.form = form;
            this.form.ClientSize = new Size(600, 400);

            this.progressPanel = progressPanel;
            this.installPanel = installPanel;

            InitPanels();
            InitButtons();
            InitHandlers();
        }

        private void InitPanels()
        {
            panels[Phase.Verifying] = progressPanel;
            panels[Phase.Ready] = installPanel;

            progressPanel.Visible = false;
            progressPanel.Dock = DockStyle.Fill;

            installPanel.Visible = false;
            installPanel.Dock = DockStyle.Fill;

            form.Controls.Add(progressPanel);
            form.Controls.Add(installPanel);
        }

        private void InitButtons()
        {
            if (Status.IsAdmin)
                return;

            Icon icon = Icon.FromHandle(SystemIcons.Shield.Handle);
            Size size = SystemInformation.SmallIconSize;
            Bitmap bitmap = new Bitmap(size.Width, size.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawIcon(icon, new Rectangle(0, 0, size.Width, size.Height));
            }

            installPanel.InstallGameButton.Image = bitmap;
        }

        private void InitHandlers()
        {
            form.Load += (s, e) => Load.Invoke();
            form.FormClosing += (s, e) => Closing.Invoke();
        }

        public void Update(Status status)
        {
            ShowPanel(panels[status.Phase]);
        }

        private void ShowPanel(Control panel)
        {
            if (currentPanel == panel)
                return;

            if (currentPanel != null)
                currentPanel.Visible = false;

            if (panel != null)
                panel.Visible = true;

            currentPanel = panel;
        }
    }
}
