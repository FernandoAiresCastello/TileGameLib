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

namespace TileGameLib.EngineFramework
{
    public class GameEngineBase
    {
        public GameWindow Window { get; private set; }

        private readonly Timer CycleTimer;
        private MapController MapController;

        public GameEngineBase(string winTitle, int winCols, int winRows, int cycleInterval)
        {
            Window = new GameWindow(this, winTitle, winCols, winRows);

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

        public void SetMapViewport(int x, int y, int width, int height)
        {
            Window.SetMapViewport(x, y, width, height);
        }

        public void SetMapController(MapController controller)
        {
            MapController = controller;
            MapController.Engine = this;
            Window.SetMap(MapController.Map);
        }

        public void ScrollMapViewport(int dx, int dy)
        {
            Window.ScrollMapViewport(dx, dy);
        }
    }
}
