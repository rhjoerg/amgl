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

        public static event ChangedHandler Changed;

        private static bool installRequired = false;
        private static bool updateAvailable = false;
        private static bool valid = false;

        public static bool InstallRequired
        {
            get { return valid && installRequired; }
        }

        public static bool UpdateAvailable
        {
            get { return valid && updateAvailable; }
        }

        public static bool Playable
        {
            get { return valid && !installRequired; } // TODO and not installing/updating
        }

        public static async Task Update()
        {
            bool installRequired = true;
            bool updateAvailable = false;

            await Task.Run(() =>
            {
                installRequired = Installer.Check();

                if (!installRequired)
                {
                    // TODO Updater.Check
                }
            });

            Status.installRequired = installRequired;
            Status.updateAvailable = updateAvailable;
            Status.valid = true;
            Changed.Invoke();
        }
    }
}
