using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class MapController
    {
        public GameEngine Engine { set; get; }
        public GameWindow Window { set; get; }
        public ObjectMap Map { set; get; }
        public string MapFile { set; get; }

        public UserInterface Ui => Window.Ui;
        public MapRenderer MapRenderer => Window.Ui.MapRenderer;

        public MapController()
        {
        }

        public virtual void OnLoad()
        {
            // Override this to do stuff upon loading the map
            // Called whenever the map is loaded or reloaded
        }

        public virtual void OnEnter()
        {
            // Override this to do stuff upon entering the map
            // Called only once by the engine immediately after entering this map
        }

        public virtual void OnLeave()
        {
            // Override this to do stuff upon leaving the map
            // Called only once by the engine immediately before leaving this map
        }

        public virtual void OnExecuteCycle()
        {
            // Override this to do stuff on every cycle
            // Called by the engine immediately after it globally handles the cycle
            // Does not get called if the engine is paused
        }

        public virtual void OnDrawUi()
        {
            // Override this to continuously print stuff to the UI
            // Called by the engine immediately after it draws the global UI
        }

        public virtual void OnKeyDown(KeyEventArgs e)
        {
            // Override this to do stuff whenever some key is pressed down
            // Called by the engine whenever it doesn't handle this key globally
        }

        public virtual void OnKeyUp(KeyEventArgs e)
        {
            // Override this to do stuff whenever some key is released
            // Called by the engine whenever it doesn't handle this key globally
        }
    }
}
