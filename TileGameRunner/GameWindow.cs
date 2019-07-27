using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Engine;

namespace TileGameRunner
{
    public class GameWindow : DisplayWindow
    {
        private readonly GameEngine GameEngine;

        public GameWindow() : base(32, 24)
        {
            GameEngine = null;
        }

        public GameWindow(int cols, int rows, string projectPath, string initialMapName) : base(cols, rows)
        {
            GameEngine = new GameEngine(new GameInterpreter(), projectPath, initialMapName, Display);
        }

        protected override void HandleMouseEvent(MouseEventArgs e)
        {
            // Nothing to do
        }

        protected override void HandleKeyEvent(KeyEventArgs e)
        {
            if (GameEngine == null)
                return;

            GameEngine.ExecuteCycle();
        }
    }
}
