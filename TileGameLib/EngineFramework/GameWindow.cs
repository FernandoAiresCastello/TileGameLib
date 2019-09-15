using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.EngineFramework
{
    public class GameWindow : DisplayWindow
    {
        public new int BackColor { set; get; } = 0;
        public int TileBackColor { set; get; } = 0;
        public int TileForeColor { set; get; } = 64;
        public Point TileCursor { set; get; } = new Point(0, 0);

        private readonly GameEngineBase Engine;
        private readonly MapRenderer MapRenderer;

        public GameWindow(GameEngineBase engine, string title, int cols, int rows) 
            : base(cols, rows, false, false)
        {
            Text = title;
            Engine = engine;
            MapRenderer = new MapRenderer(Display);
        }

        protected override void HandleKeyDownEvent(KeyEventArgs e)
        {
            Engine.OnKeyDown(e);
        }

        protected override void HandleKeyUpEvent(KeyEventArgs e)
        {
            Engine.OnKeyUp(e);
        }

        public void SetColors(int tileForeColor, int tileBackColor, int windowBackColor)
        {
            BackColor = windowBackColor;
            TileBackColor = tileBackColor;
            TileForeColor = tileForeColor;
        }

        public void SetCursor(int x, int y)
        {
            TileCursor = new Point(x, y);
        }

        public void MoveCursor(int dx, int dy)
        {
            TileCursor = new Point(TileCursor.X + dx, TileCursor.Y + dy);
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            MapRenderer.Viewport = new Rectangle(x, y, width, height);
        }

        public void SetMap(ObjectMap map)
        {
            MapRenderer.Map = map;
        }

        public void Clear()
        {
            Graphics.Clear(BackColor);
        }

        public void ClearRect(Rectangle rect)
        {
            Graphics.ClearRect(BackColor, rect.X, rect.Y, rect.Width, rect.Height);
        }

        public void ClearMapViewport()
        {
            ClearRect(MapRenderer.Viewport);
        }

        public void EnableMapAnimation(bool enable)
        {
            MapRenderer.AnimationEnabled = enable;
        }

        public void ShowMap(bool show)
        {
            if (show)
            {
                MapRenderer.AutoRefresh = true;
            }
            else
            {
                MapRenderer.AutoRefresh = false;
                ClearMapViewport();
            }
        }

        public void Print(string text)
        {
            Graphics.PutString(TileCursor.X, TileCursor.Y, text, TileForeColor, TileBackColor);
        }

        public void ScrollMapViewport(int dx, int dy)
        {
            MapRenderer.Scroll = new Point(MapRenderer.Scroll.X + dx, MapRenderer.Scroll.Y + dy);
        }
    }
}
