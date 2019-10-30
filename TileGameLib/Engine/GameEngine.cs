using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Exceptions;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class GameEngine
    {
        public GameWindow Window { get; private set; }
        public Variables Variables { get; private set; }
        public bool Paused { set; get; } = false;

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
            CycleTimer.Tick += CycleTimer_Tick;
        }

        public void Run()
        {
            CycleTimer.Start();
            Application.Run(Window);
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            DrawUi();

            if (!Paused)
            {
                OnExecuteCycle();
                if (MapController != null)
                    MapController.OnExecuteCycle();
            }
        }

        public void DrawUi()
        {
            Window.Ui.DrawUiMap();
            OnDrawUi();
        }

        public void PrintUi(string placeholderObjectTag, string text)
        {
            Window.Ui.Print(placeholderObjectTag, text);
        }

        public virtual void OnDrawUi()
        {
        }

        public virtual void OnExecuteCycle()
        {
        }

        public void Log(object obj)
        {
            Debug.WriteLine(obj);
        }

        public void OnKeyDown(KeyEventArgs e)
        {
            bool global = OnGlobalKeyDown(e);
            if (!global && MapController != null)
                MapController.OnKeyDown(e);
        }

        public void OnKeyUp(KeyEventArgs e)
        {
            bool global = OnGlobalKeyUp(e);
            if (!global && MapController != null)
                MapController.OnKeyUp(e);
        }

        public virtual bool OnGlobalKeyDown(KeyEventArgs e)
        {
            return false;
        }

        public virtual bool OnGlobalKeyUp(KeyEventArgs e)
        {
            return false;
        }

        public void LoadUiMap(string uiMapFile)
        {
            Window.Ui.LoadUiMap(uiMapFile);
        }

        public void SetMapViewport(string topLeftPlaceholderObjectTag, string bottomRightPlaceholderObjectTag)
        {
            Window.Ui.SetMapViewport(topLeftPlaceholderObjectTag, bottomRightPlaceholderObjectTag);
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            Window.Ui.SetMapViewport(x, y, width, height);
        }

        public void AddMapController(MapController controller)
        {
            MapControllerCollection.AddController(controller);
        }

        public void EnterMap(string mapName)
        {
            MapController next = MapControllerCollection.Get(mapName);
            if (next == null)
                throw new TileGameLibException("Map " + mapName + " not found");

            if (MapController != null)
                MapController.OnLeave();

            SetMapController(next);
            MapController.OnEnter();
        }

        private void SetMapController(MapController controller)
        {
            MapController = controller;
            MapController.Engine = this;
            MapController.Window = Window;
            Window.Ui.SetGameMap(MapController.Map);
        }
    }
}
