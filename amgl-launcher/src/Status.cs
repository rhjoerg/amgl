using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amgl_launcher
{
    public class Status
    {
        public delegate void ChangedHandler();

        public event ChangedHandler Changed;

        private bool valid = false;
        private bool installRequired = false;
        private bool updateAvailable = false;

        public readonly string Directory = AppDomain.CurrentDomain.BaseDirectory;

        public bool InstallRequired
        {
            get { return valid && installRequired; }

            set
            {
                installRequired = value; Changed.Invoke();
                
                if (installRequired)
                {
                    updateAvailable = false;
                }

                Changed.Invoke();
            }
        }

        public bool UpdateAvailable
        {
            get { return valid && updateAvailable; }
            set { updateAvailable = value; Changed.Invoke(); }
        }

        public bool Playable
        {
            get { return valid && !installRequired; } // TODO and not installing/updating
        }

        public void Update()
        {
        }
    }
}
