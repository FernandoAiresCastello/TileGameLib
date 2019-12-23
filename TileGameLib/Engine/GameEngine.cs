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
using TileGameLib.Util;

namespace TileGameLib.Engine
{
    public class GameEngine
    {
        public GameWindow Window { get; private set; }
        public string MapsBasePath { set; get; }
        public bool Paused { set; get; }

        public UserInterface Ui => Window.Ui;
        public bool HasTimedMessage => Window.Ui.HasTimedMessage;
        public bool HasModalMessage => Window.Ui.HasModalMessage;

        protected MapController MapController;
        protected MapController PreviousMapController;
        protected readonly MapControllerCollection MapControllers;

        private readonly Timer CycleTimer;
        private readonly Timer GfxRefreshTimer;
        private readonly SoundPlayer SoundPlayer;

        public GameEngine(string winTitle, int winCols, int winRows, int gfxRefreshInterval, int cycleInterval, string mapsBasePath) :
            this(winTitle, winCols, winRows, gfxRefreshInterval, cycleInterval, true, true, mapsBasePath)
        {
        }

        public GameEngine(string winTitle, int winCols, int winRows, int gfxRefreshInterval, int cycleInterval,
            bool allowFullscreenWindow, bool allowResizeWindow, string mapsBasePath)
        {
            Window = new GameWindow(this, winTitle, winCols, winRows, allowFullscreenWindow, allowResizeWindow);
            MapControllers = new MapControllerCollection();
            SoundPlayer = new SoundPlayer();
            MapsBasePath = mapsBasePath;

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

        public virtual void OnDrawUi()
        {
            // Override this to globally and continuously print stuff to the UI
            // Called whenever the graphics refresh timer interval elapses
        }

        public virtual void OnExecuteCycle()
        {
            // Override this to globally do stuff on every cycle
            // Called whenever the cycle timer interval elapses
        }

        public virtual bool OnKeyDown(KeyEventArgs e)
        {
            // Override this to globally do stuff whenever some key is pressed down
            // Return true if the keydown event was handled, false otherwise
            // If this is handled, the event won't be sent to the map controller

            return false;
        }

        public virtual bool OnKeyUp(KeyEventArgs e)
        {
            // Override this to globally do stuff whenever some key is released
            // Return true if the keyup event was handled, false otherwise
            // If this is handled, the event won't be sent to the map controller

            return false;
        }

        public virtual bool OnMapTransition(MapController currentController, MapController nextController)
        {
            // Override this to do stuff whenever there is a transition from one map to another
            // Return false to cancel the transition, true otherwise

            return true;
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

        protected string GetMapPath(string mapFile)
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

        public ObjectMap LoadMap(string mapFile, MapController controller)
        {
            ObjectMap map = MapControllers.AddController(GetMapPath(mapFile), controller);
            controller.OnLoad();
            return map;
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

            bool transitionNotCancelled = OnMapTransition(MapController, nextController);

            if (transitionNotCancelled)
            {
                if (MapController != null)
                    MapController.OnLeave();

                SetMapController(nextController);
                MapController.OnEnter();

                if (MapController.Map.HasMusic)
                    PlayMusicLoop(MapController.Map.MusicFile);
            }
        }

        public void EnterPreviousMap()
        {
            if (PreviousMapController != null)
                EnterMap(PreviousMapController.Map);
        }

        public void ReloadMap(string name)
        {
            MapController controller = MapControllers.Get(name);
            controller.Map.SetEqual(MapFile.Load(GetMapPath(controller.MapFile)));
            SetMapController(controller);
            controller.OnLoad();
        }

        public void ShowTimedMessage(Strings message, string placeholderObjectTag, int duration)
        {
            Ui.ShowTimedMessage(placeholderObjectTag, duration, message.Array);
        }

        public void ShowModalMessage(Strings message)
        {
            Ui.SetModalMessage(message.Array);
        }

        private void SetMapController(MapController controller)
        {
            PreviousMapController = MapController;
            MapController = controller;
            MapController.Engine = this;
            MapController.Window = Window;
            Window.Ui.SetGameMap(MapController.Map);
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
    }
}
