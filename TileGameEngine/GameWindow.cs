using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;

namespace TileGameEngine
{
    public class GameWindow : TiledDisplayWindow
    {
        private readonly GameEngine Engine;
        private readonly Timer RefreshTimer;

        public GameWindow(GameEngine engine, int cols, int rows, int zoom, int width, int height, int refreshRate) :
            base(cols, rows, zoom, width, height, false, true, true)
        {
            Engine = engine;
            RefreshTimer = new Timer();
            RefreshTimer.Interval = refreshRate;
            RefreshTimer.Tick += RefreshTimer_Tick;
            RefreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        protected override void HandleKeyDownEvent(KeyEventArgs e)
        {
            Engine.HandleKeyDownEvent(e);
        }

        protected override void HandleKeyUpEvent(KeyEventArgs e)
        {
            Engine.HandleKeyUpEvent(e);
        }

        protected override void HandleMouseDownEvent(MouseEventArgs e)
        {
            Engine.HandleMouseDownEvent(e);
        }
    }
}
