using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;

namespace TileGameSamples.RoguelikeSample
{
    public class Game
    {
        public static readonly int DisplayWidth = 32;
        public static readonly int DisplayHeight = 24;

        private readonly GameWindow Window;
        private readonly GameEngine Engine;

        public Game(GameWindow window)
        {
            Window = window;
            Engine = new GameEngine(new GameInterpreter(), Application.StartupPath + "\\maps.zip", "FirstMap.dat");
        }

        public void KeyPressed(Keys keyCode)
        {
            Engine.ExecuteCycle();
        }
    }
}
