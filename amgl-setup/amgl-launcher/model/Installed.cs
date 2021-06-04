using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace amgl.model
{
    public class Installed
    {
        public readonly bool GameInstalled;
        public readonly bool DeveloperInstalled;

        public Installed(bool gameInstalled, bool developerInstalled)
        {
            GameInstalled = gameInstalled;
            DeveloperInstalled = developerInstalled;
        }

        public static readonly Installed NotInstalled = new Installed(false, false);
    }
}
