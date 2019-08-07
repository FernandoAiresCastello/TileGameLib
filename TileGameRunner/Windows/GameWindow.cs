using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameRunner.Windows
{
    public class GameWindow : DisplayWindow
    {
        public GameWindow(int cols, int rows) : base(cols, rows)
        {
        }
    }
}
