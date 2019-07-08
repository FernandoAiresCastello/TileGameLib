using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Graphics;

namespace TileGameSamples.RoguelikeSample
{
    public class GameWindow : DisplayWindow
    {
        private readonly Game Game;

        public GameWindow() : base(Game.DisplayWidth, Game.DisplayHeight)
        {
            Text = "Roguelike Sample";
            Game = new Game(this);
        }

        protected override void HandleKeyEvent(KeyEventArgs e)
        {
            Game.KeyPressed(e.KeyCode);
        }

        protected override void HandleMouseEvent(MouseEventArgs e)
        {
            // Not used
        }
    }
}
