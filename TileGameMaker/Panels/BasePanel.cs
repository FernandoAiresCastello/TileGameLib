using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Panels
{
    public class BasePanel : UserControl
    {
        public BasePanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.Name = "BasePanel";
            this.ResumeLayout(false);
        }
    }
}
