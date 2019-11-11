using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
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
        public string MapsBasePath { set; get; }
        public bool Paused { set; get; }
        public bool CancelMapTransition { set; get; }

        private MapController MapController;
        private readonly GameWindow Window;
        private readonly MapControllerCollection MapControllers;
        private readonly Timer CycleTimer;
        private readonly Timer GfxRefreshTimer;
        private readonly SoundPlayer SoundPlayer;

        public GameEngine(string winTitle, int winCols, int winRows, int gfxRefreshInterval, int cycleInterval)
        {
            Window = new GameWindow(this, winTitle, winCols, winRows);
            MapControllers = new MapControllerCollection();
            SoundPlayer = new SoundPlayer();

            CycleTimer = new Timer();
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Tick += CycleTimer_Tick;

            GfxRefreshTimer = new Timer();
            GfxRefreshTimer.Interval = gfxRefreshInterval;
            GfxRefreshTimer.Tick += GfxRefreshTimer_Tick;
        }

        public void Run()
        {
            CycleTimer.Start();
            GfxRefreshTimer.Start();
            Application.Run(Window);
        }

        private void GfxRefreshTimer_Tick(object sender, EventArgs e)
        {
            Window.Ui.Draw();
            OnDrawUi();

            if (MapController != null)
                MapController.OnDrawUi();
        }

        private void CycleTimer_Tick(object sender, EventArgs e)
        {
            if (!Paused)
            {
                OnExecuteCycle();
                if (MapController != null)
                    MapController.OnExecuteCycle();
            }
        }

        public void PrintUi(string placeholderObjectTag, object obj)
        {
            Window.Ui.Print(placeholderObjectTag, obj);
        }

        public void PrintUi(string placeholderObjectTag, int offsetX, int offsetY, object obj)
        {
            Window.Ui.Print(placeholderObjectTag, offsetX, offsetY, obj);
        }

        public void ShowMessage(string placeholderObjectTag, string text, int duration)
        {
            Window.Ui.ShowMessage(placeholderObjectTag, text, duration);
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

        public void HandleKeyDownEvent(KeyEventArgs e)
        {
            bool global = OnKeyDown(e);
            if (!global && !Paused && MapController != null)
                MapController.OnKeyDown(e);

            Window.Ui.DrawMap();
        }

        public void HandleKeyUpEvent(KeyEventArgs e)
        {
            bool global = OnKeyUp(e);
            if (!global && !Paused && MapController != null)
                MapController.OnKeyUp(e);

            Window.Ui.DrawMap();
        }

        public virtual bool OnKeyDown(KeyEventArgs e)
        {
            return false;
        }

        public virtual bool OnKeyUp(KeyEventArgs e)
        {
            return false;
        }

        public virtual void OnMapTransition(MapController currentController, MapController nextController)
        {
        }

        public void PlayMusicOnce(string musicFile)
        {
            StopMusic();
            SoundPlayer.SoundLocation = musicFile;
            SoundPlayer.Play();
        }

        public void PlayMusicLoop(string musicFile)
        {
            StopMusic();
            SoundPlayer.SoundLocation = musicFile;
            SoundPlayer.PlayLooping();
        }

        public void AwaitPlayMusic(string musicFile)
        {
            StopMusic();
            SoundPlayer.SoundLocation = musicFile;
            SoundPlayer.PlaySync();
        }

        public void StopMusic()
        {
            SoundPlayer.Stop();
        }

        public string GetMapPath(string mapFile)
        {
            string basePath = MapsBasePath.Replace('\\', '/');
            string mapPath = "";

            if (string.IsNullOrWhiteSpace(basePath))
            {
                mapPath = mapFile;
            }
            else
            {
                if (basePath.EndsWith("/"))
                    mapPath = basePath + mapFile;
                else
                    mapPath = basePath + "/" + mapFile;
            }

            return mapPath;
        }

        public void LoadUiMap(string uiMapFile)
        {
            Window.Ui.LoadUiMap(GetMapPath(uiMapFile));
        }

        public void SetMapViewport(string topLeftPlaceholderObjectTag, string bottomRightPlaceholderObjectTag)
        {
            Window.Ui.SetMapViewport(topLeftPlaceholderObjectTag, bottomRightPlaceholderObjectTag);
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            Window.Ui.SetMapViewport(x, y, width, height);
        }

        public ObjectMap LoadMap(string mapFile, MapController controller)
        {
            return MapControllers.AddController(GetMapPath(mapFile), controller);
        }

        public void EnterMap(ObjectMap map)
        {
            EnterMap(map.Name);
        }

        public void EnterMap(string mapName)
        {
            MapController nextController = MapControllers.Get(mapName);
            if (nextController == null)
                throw new TileGameLibException($"Map {mapName} not found");

            OnMapTransition(MapController, nextController);

            if (!CancelMapTransition)
            {
                if (MapController != null)
                    MapController.OnLeave();

                SetMapController(nextController);
                MapController.OnEnter();

                if (MapController.Map.HasMusic)
                    PlayMusicLoop(MapController.Map.MusicFile);
            }

            CancelMapTransition = false;
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
