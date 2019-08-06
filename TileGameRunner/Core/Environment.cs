using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameRunner.Windows;

namespace TileGameRunner.Core
{
    public class Environment
    {
        public Variables Variables { get; private set; } = new Variables();
        public Rectangle MapViewport { get; set; } = new Rectangle();
        public Point MapOffset { get; set; } = new Point();
        public Point PrintCursor { get; set; } = new Point();
        public int PrintForeColor { get; set; } = 0;
        public int PrintBackColor { get; set; } = 0;

        private GameWindow Window;
        private ObjectMap Map;
        private MapRenderer MapRenderer;

        private readonly ProjectArchive ProjectArchive;

        public Environment(ProjectArchive projectArchive)
        {
            ProjectArchive = projectArchive;
        }

        public void CreateWindow(int cols, int rows)
        {
            Window = new GameWindow(cols, rows);
            Window.Show();
        }

        public void CloseWindow()
        {
            if (Window != null)
                Window.Close();
        }

        public bool HasWindow()
        {
            return Window != null;
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            MapViewport = new Rectangle(x, y, width, height);
        }

        public void SetMapOffset(int x, int y)
        {
            MapOffset = new Point(x, y);
        }

        public void LoadMap(string filename)
        {
            ProjectArchive.LoadMap(ref Map, filename);
            if (Window != null)
                MapRenderer = new MapRenderer(Map, Window.Display, MapViewport, MapOffset);
        }

        public void StartMapRenderer()
        {
            if (MapRenderer != null)
                MapRenderer.AutoRefresh = true;
        }

        public void StopMapRenderer()
        {
            if (MapRenderer != null)
                MapRenderer.AutoRefresh = false;
        }

        public void Print(string text)
        {
            Window.Graphics.PutString(PrintCursor.X, PrintCursor.Y, text, PrintForeColor, PrintBackColor);
            Window.Graphics.Refresh();
        }
    }
}
