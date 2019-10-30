using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Components;
using TileGameLib.Exceptions;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class UserInterface
    {
        public int BackColor { set; get; } = 0;

        private ObjectMap UiMap;
        private readonly MapRenderer MapRenderer;
        private readonly GraphicsAdapter Graphics;
        private Palette OriginalPalette;
        private Tileset OriginalTileset;

        private readonly Dictionary<string, UserInterfacePlaceholder>
            Placeholders = new Dictionary<string, UserInterfacePlaceholder>();

        public UserInterface(GraphicsAdapter gr, TiledDisplay disp)
        {
            Graphics = gr;
            MapRenderer = new MapRenderer(disp);
        }

        public void LoadUiMap(string uiMapFile)
        {
            UiMap = MapFile.Load(uiMapFile);

            if (UiMap.Width != Graphics.Cols || UiMap.Height != Graphics.Rows)
                throw new TileGameLibException("UI map must be exactly the same dimensions as the window");
            if (UiMap.Layers.Count != 1)
                throw new TileGameLibException("UI map must have exactly 1 layer");

            BackColor = UiMap.BackColor;
            FindPlaceholders();
        }

        public void Clear()
        {
            PreserveOriginalTilesetAndPalette();
            Graphics.Clear(BackColor);
            RestoreOriginalTilesetAndPalette();
        }

        public void ClearRect(Rectangle rect)
        {
            PreserveOriginalTilesetAndPalette();
            Graphics.ClearRect(BackColor, rect.X, rect.Y, rect.Width, rect.Height);
            RestoreOriginalTilesetAndPalette();
        }

        public void Print(string placeholderObjectTag, string text)
        {
            if (UiMap == null)
                return;

            UserInterfacePlaceholder ph = Placeholders[placeholderObjectTag];
            Graphics.PutString(ph.Position.X, ph.Position.Y, text, ph.Tile.ForeColorIx, ph.Tile.BackColorIx);
        }

        public void DrawUiMap()
        {
            if (UiMap == null)
                return;

            PreserveOriginalTilesetAndPalette();
            Graphics.Clear(BackColor);

            ObjectLayer layer = UiMap.Layers[0];

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    GameObject o = layer.GetObjectRef(x, y);
                    if (o != null)
                        Graphics.PutTile(x, y, o.Animation.GetFirstFrame());
                }
            }

            RestoreOriginalTilesetAndPalette();
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            MapRenderer.Viewport = new Rectangle(x, y, width, height);
        }

        public void SetMapViewport(string topLeftPlaceholderObjectTag, string bottomRightPlaceholderObjectTag)
        {
            UserInterfacePlaceholder topLeft = Placeholders[topLeftPlaceholderObjectTag];
            UserInterfacePlaceholder bottomRight = Placeholders[bottomRightPlaceholderObjectTag];

            SetMapViewport(topLeft.Position.X, topLeft.Position.Y, 
                bottomRight.Position.X - topLeft.Position.X + 1, 
                bottomRight.Position.Y - topLeft.Position.Y + 1);
        }

        public void SetGameMap(ObjectMap map)
        {
            MapRenderer.Map = map;
        }

        public void EnableMapAnimation(bool enable)
        {
            MapRenderer.AnimationEnabled = enable;
        }

        public void ClearMapViewport()
        {
            ClearRect(MapRenderer.Viewport);
        }

        public void ShowGameMap(bool show)
        {
            if (show)
            {
                MapRenderer.AutoRefresh = true;
            }
            else
            {
                MapRenderer.AutoRefresh = false;
                DrawUiMap();
            }
        }

        public void ScrollMapViewport(int dx, int dy)
        {
            MapRenderer.Scroll = new Point(MapRenderer.Scroll.X + dx, MapRenderer.Scroll.Y + dy);
        }

        private void PreserveOriginalTilesetAndPalette()
        {
            OriginalPalette = Graphics.Palette;
            OriginalTileset = Graphics.Tileset;

            if (UiMap != null)
            {
                Graphics.Tileset = UiMap.Tileset;
                Graphics.Palette = UiMap.Palette;
            }
        }

        private void RestoreOriginalTilesetAndPalette()
        {
            Graphics.Palette = OriginalPalette;
            Graphics.Tileset = OriginalTileset;
        }

        private void FindPlaceholders()
        {
            if (UiMap == null)
                return;

            ObjectLayer layer = UiMap.Layers[0];

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    GameObject o = layer.GetObjectRef(x, y);

                    if (o != null && o.HasTag)
                    {
                        bool isDuplicate = Placeholders.TryGetValue(o.Tag, out UserInterfacePlaceholder ph);
                        if (isDuplicate)
                            throw new TileGameLibException("Duplicate placeholder " + o.Tag + " in UI map");

                        Placeholders[o.Tag] = new UserInterfacePlaceholder(o.Animation.GetFirstFrame(), x, y);
                    }
                }
            }
        }
    }
}
