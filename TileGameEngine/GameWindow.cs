using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameEngine
{
    public class GameWindow : TiledDisplayWindow
    {
        private readonly GameEngine Engine;

        public GameWindow(GameEngine engine, int cols, int rows, int zoom, int width, int height) :
            base(cols, rows, zoom, width, height, false, true, true)
        {
            Engine = engine;
        }

        protected override void HandleKeyDownEvent(KeyEventArgs e)
        {
            Engine.HandleKeyDownEvent(e);
        }

        protected override void HandleKeyUpEvent(KeyEventArgs e)
        {
            Engine.HandleKeyUpEvent(e);
        }

        protected override void HandleMouseDownEvent(MouseEventArgs e)
        {
            Engine.HandleMouseDownEvent(e);
        }
    }
}
