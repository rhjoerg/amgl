using amgl.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace amgl.ui
{
    public class MainPresenter
    {
        public delegate void Handler();

        public event Handler Load;

        private readonly MainForm form;

        private readonly ProgressPresenter progressPresenter;
        private readonly Dictionary<Phase, Presenter> presenters = new Dictionary<Phase, Presenter>();

        private Presenter currentPresenter = null;

        public MainPresenter(MainForm form, ProgressPresenter progressPresenter)
        {
            this.form = form;
            this.progressPresenter = progressPresenter;

            InitPresenters();
            InitHandlers();
        }

        private void InitPresenters()
        {
            presenters[Phase.Verifying] = progressPresenter;
        }

        private void InitHandlers()
        {
            form.Load += (s, e) => Load.Invoke();
        }

        public void Update(Status status)
        {
            ShowPresenter(presenters[status.Phase]);
            UpdatePresenter(status);
        }

        private void ShowPresenter(Presenter presenter)
        {
            if (currentPresenter == presenter)
                return;

            RemovePanel(currentPresenter);
            AddPanel(presenter);
            currentPresenter = presenter;
        }

        private void UpdatePresenter(Status status)
        {
            throw new NotImplementedException();
        }

        private void RemovePanel(Presenter presenter)
        {
            if (presenter == null)
                return;

            form.Controls.Remove(presenter.Panel);
        }

        private void AddPanel(Presenter presenter)
        {
            if (presenter == null)
                return;

            presenter.Panel.Dock = DockStyle.Fill;
            form.Controls.Add(presenter.Panel);
        }
    }
}
