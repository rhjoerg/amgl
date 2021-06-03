using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace amgl.ui
{
    public class Presenter
    {
        public readonly Control Panel;

        protected Presenter(Control panel)
        {
            Panel = panel;
        }
    }
}
