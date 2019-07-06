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

        private MapArchive MapArchive;
        private Timer CycleTimer;

        public GameEngine(Interpreter interpreter, string mapArchivePath)
        {
            Context = new GameContext(interpreter);
            MapArchive = new MapArchive(mapArchivePath);
            CycleTimer = new Timer();
            CycleTimer.Tick += Timer_Tick;
        }

        public void ExecuteCycle()
        {
            Context.ExecuteCycle();
        }

        public void LoadMap(string filename)
        {
            ObjectMap loadedMap = MapArchive.Load(filename);
            Context.SetCurrentMap(loadedMap);
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
