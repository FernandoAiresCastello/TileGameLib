using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TileGameLib.Util
{
    public class Alert
    {
        public static bool EnableAlerts { set; get; } = false;

        public static void Warning(string msg)
        {
            if (EnableAlerts)
                MessageBox.Show(msg, "TileGameLib Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string msg)
        {
            if (EnableAlerts)
            {
                MessageBox.Show(msg, "TileGameLib Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(msg);
            }
        }
    }
}
