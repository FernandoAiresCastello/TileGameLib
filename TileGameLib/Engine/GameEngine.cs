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
        public GameWindow Window { get; private set; }
        public Variables Variables { get; private set; }
        public bool Paused { set; get; } = false;
        public UserInterface Ui => Window?.Ui;

        private MapController MapController;
        private readonly MapControllerCollection MapControllers;
        private readonly Timer CycleTimer;
        private readonly Timer GfxRefreshTimer;
        private readonly SoundPlayer SoundPlayer;

        public GameEngine(string winTitle, int winCols, int winRows, int cycleInterval)
        {
            Window = new GameWindow(this, winTitle, winCols, winRows);
            Variables = new Variables();
            MapControllers = new MapControllerCollection();
            SoundPlayer = new SoundPlayer();

            CycleTimer = new Timer();
            CycleTimer.Interval = cycleInterval;
            CycleTimer.Tick += CycleTimer_Tick;

            GfxRefreshTimer = new Timer();
            GfxRefreshTimer.Interval = 60;
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
        }

        public void HandleKeyUpEvent(KeyEventArgs e)
        {
            bool global = OnKeyUp(e);
            if (!global && !Paused && MapController != null)
                MapController.OnKeyUp(e);
        }

        public virtual bool OnKeyDown(KeyEventArgs e)
        {
            return false;
        }

        public virtual bool OnKeyUp(KeyEventArgs e)
        {
            return false;
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

        public void AddMapController(string mapFile, MapController controller)
        {
            MapControllers.AddController(mapFile, controller);
        }

        public void EnterMap(string mapName)
        {
            MapController next = MapControllers.Get(mapName);
            if (next == null)
                throw new TileGameLibException("Map " + mapName + " not found");

            if (MapController != null)
                MapController.OnLeave();

            SetMapController(next);
            MapController.OnEnter();

            if (MapController.Map.HasMusic)
                PlayMusicLoop(MapController.Map.MusicFile);
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
