using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameMaker.Panels
{
    public class BaseControl : UserControl
    {

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseControl
            // 
            this.Name = "BaseControl";
            this.ResumeLayout(false);

        }
    }
}
