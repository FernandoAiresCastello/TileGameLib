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
    public class GameWindow : DisplayWindow
    {
        public UserInterface Ui { get; private set; }

        private readonly GameEngine Engine;

        public GameWindow(GameEngine engine, string title, int cols, int rows) 
            : base(cols, rows, false, false)
        {
            Text = title;
            Engine = engine;
            Ui = new UserInterface(Graphics, Display);
        }

        protected override void HandleKeyDownEvent(KeyEventArgs e)
        {
            Engine.OnKeyDown(e);
        }

        protected override void HandleKeyUpEvent(KeyEventArgs e)
        {
            Engine.OnKeyUp(e);
        }
    }
}
