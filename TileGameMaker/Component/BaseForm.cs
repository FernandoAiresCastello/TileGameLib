using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Component
{
    public class BaseForm : Form
    {
        protected List<Control> SubscribedControls = new List<Control>();

        public void Subscribe(Control control)
        {
            SubscribedControls.Add(control);
        }

        protected void RefreshSubscribed()
        {
            foreach (Control control in SubscribedControls)
                control.Refresh();
        }
    }
}
