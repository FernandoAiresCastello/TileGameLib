using System;
using System.Collections.Generic;
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
    public class GameEngine
    {
        public GameContext Context { get; private set; }

        private MapEngine MapEngine;
        private readonly Interpreter Interpreter;
        private readonly MapArchive MapArchive;
        private readonly Timer CycleTimer;
        private readonly TiledDisplay Display;
        private MapRenderer MapRenderer;

        public GameEngine(Interpreter interpreter, string projectPath, string firstMapFilename, TiledDisplay display)
        {
            Context = new GameContext();

            Interpreter = interpreter;
            Interpreter.GameContext = Context;

            CycleTimer = new Timer();
            CycleTimer.Tick += Timer_Tick;
            CycleTimer.Interval = 0;

            Display = display;
            MapArchive = new MapArchive(projectPath);
            LoadMap(firstMapFilename);
        }

        public void ExecuteCycle()
        {
            MapEngine.ExecuteCycle();
            MapRenderer.Render();
        }

        public void LoadMap(string filename)
        {
            SetMap(MapArchive.Load(filename));
        }

        public void SetMap(ObjectMap map)
        {
            Context.CurrentMap = map;
            MapEngine = new MapEngine(Context, Interpreter);
            MapRenderer = new MapRenderer(map, Display);
        }

        public void StartAutoCycle(int cycleInterval)
        {
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Start();
        }

        public void StopAutoCycle()
        {
            CycleTimer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ExecuteCycle();
        }
    }
}
