using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameEngine.Windows
{
    public class GameWindow : DisplayWindow
    {
        public GameWindow(int cols, int rows) : base(cols, rows)
        {
        }
    }
}
