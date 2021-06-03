using amgl.model;
using System;

namespace amgl.action
{
    public class Worker
    {
        public delegate void ChangedHandler(Status status);
        public event ChangedHandler Changed;

        private readonly Progress<Status> progress = new Progress<Status>();

        public Worker()
        {
            progress.ProgressChanged += Progress_ProgressChanged;
        }

        private void Progress_ProgressChanged(object sender, Status status)
        {
            Changed.Invoke(status);
        }

        public void Initialize()
        {
            Report(Status.Verifying());
        }

        private void Report(Status status)
        {
            ((IProgress<Status>) progress).Report(status);
        }
    }
}
