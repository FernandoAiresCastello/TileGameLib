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
        private static readonly int DefaultCycleInterval = 500;

        public bool AutoCycleEnabled
        {
            get
            {
                return CycleTimer.Enabled;
            }

            set
            {
                if (value)
                    StartAutoCycle();
                else
                    StopAutoCycle();
            }
        }

        public int AutoCycleInterval
        {
            get { return CycleTimer.Interval; }
            set { CycleTimer.Interval = value; }
        }

        private readonly MapArchive MapArchive;
        private readonly Timer CycleTimer;

        public GameEngine(Interpreter interpreter, string mapArchivePath, string firstMapFilename)
            : this(interpreter)
        {
            MapArchive = new MapArchive(mapArchivePath);
            LoadMap(firstMapFilename);
        }

        public GameEngine(Interpreter interpreter, ObjectMap map)
            : this(interpreter)
        {
            SetMap(map);
        }

        public GameEngine(Interpreter interpreter)
        {
            Context = new GameContext();

            Interpreter = interpreter;
            Interpreter.GameContext = Context;

            CycleTimer = new Timer();
            CycleTimer.Tick += Timer_Tick;
            CycleTimer.Interval = DefaultCycleInterval;
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

        private void StartAutoCycle()
        {
            CycleTimer.Start();
        }

        private void StopAutoCycle()
        {
            CycleTimer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ExecuteCycle();
        }
    }
}
