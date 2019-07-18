using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class GameEngine
    {
        public GameContext Context { get; private set; }

        private MapEngine MapEngine;
        private readonly Interpreter Interpreter;
        private readonly MapArchive MapArchive;
        private readonly Timer CycleTimer;

        public GameEngine(Interpreter interpreter, string mapArchivePath, string firstMapFilename)
        {
            Context = new GameContext();

            Interpreter = interpreter;
            Interpreter.GameContext = Context;

            MapArchive = new MapArchive(mapArchivePath);
            LoadMap(firstMapFilename);

            CycleTimer = new Timer();
            CycleTimer.Tick += Timer_Tick;
            CycleTimer.Interval = 0;
        }

        public void ExecuteCycle()
        {
            MapEngine.ExecuteCycle();
        }

        public void LoadMap(string filename)
        {
            SetMap(MapArchive.Load(filename));
        }

        public void SetMap(ObjectMap map)
        {
            Context.CurrentMap = map;
            MapEngine = new MapEngine(Context, Interpreter);
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
