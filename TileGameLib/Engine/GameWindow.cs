using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class GameWindow : TiledDisplayWindow
    {
        public UserInterface Ui { get; private set; }

        private readonly GameEngine Engine;

        public GameWindow(GameEngine engine, string title, int cols, int rows, int zoom) :
            this(engine, title, cols, rows, zoom, true, true)
        {
        }

        public GameWindow(GameEngine engine, string title, int cols, int rows, int zoom, bool allowFullscreen, bool allowResize) :
            base(cols, rows, zoom, false, allowFullscreen, allowResize)
        {
            Text = title;
            Engine = engine;
            Ui = new UserInterface(Display);
        }

        protected override void HandleKeyDownEvent(KeyEventArgs e)
        {
            Engine.HandleKeyDownEvent(e);
        }

        protected override void HandleKeyUpEvent(KeyEventArgs e)
        {
            Engine.HandleKeyUpEvent(e);
        }
    }
}
