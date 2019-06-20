using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Util;

namespace TileGameMaker.Windows
{
    public class DebugWindow : DisplayWindow
    {
        public DebugWindow(int cols, int rows) : base(cols, rows)
        {
            Text = "Debug Window";
        }

        protected override void HandleKeyEvent(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
            else
                Alert.Info("Key event: " + e.KeyCode);
        }

        protected override void HandleMouseEvent(MouseEventArgs e)
        {
            Alert.Info("Mouse event: " + e.Button);
        }
    }
}
