using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Engine;
using TileGameMaker.Engine;

namespace TileGameMaker.Windows
{
    public class GameWindow : DisplayWindow
    {
        private readonly GameEngine GameEngine;

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
