using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class GameEngine
    {
        public GameWindow Window { get; private set; }
        public Variables Variables { get; private set; }

        private MapController MapController;
        private readonly MapControllerCollection MapControllerCollection;
        private readonly Timer CycleTimer;

        public GameEngine(string winTitle, int winCols, int winRows, int cycleInterval)
        {
            Window = new GameWindow(this, winTitle, winCols, winRows);
            Variables = new Variables();

            MapControllerCollection = new MapControllerCollection();

            CycleTimer = new Timer();
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Tick += EngineTimer_Tick;
        }

        public void Run()
        {
            CycleTimer.Start();
            Application.Run(Window);
        }

        private void EngineTimer_Tick(object sender, EventArgs e)
        {
            if (MapController != null)
                MapController.OnExecuteCycle();
        }

        public void Log(string message)
        {
            Debug.WriteLine(message);
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            if (MapController != null)
                MapController.OnKeyDown(e);
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            if (MapController != null)
                MapController.OnKeyUp(e);
        }

        public ObjectMap LoadMap(string mapFile, MapController controller)
        {
            return MapControllerCollection.LoadMapSetController(mapFile, controller);
        }

        public void EnterMap(string mapName)
        {
            SetMapController(MapControllerCollection.Get(mapName));
        }

        private void SetMapController(MapController controller)
        {
            MapController = controller;
            MapController.Engine = this;
            MapController.Window = Window;
            Window.SetMap(MapController.Map);
        }
    }
}
