using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Components;
using System.Drawing;
using TileGameLib.Exceptions;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        public ObjectMap Map { set; get; }
        public Rectangle Viewport { set; get; }
        public bool ClearViewportBeforeRender { set; get; }
        public bool AnimationEnabled { set; get; }
        public bool AutoRefresh { set; get; }
        public bool RenderInvisibleObjects { set; get; }

        private Point Scroll { set; get; }

        public int RefreshInterval
        {
            set { RefreshTimer.Interval = value; }
            get { return RefreshTimer.Interval; }
        }

        public int AnimationInterval
        {
            set { AnimationTimer.Interval = value; }
            get { return AnimationTimer.Interval; }
        }

        private int AnimationFrame;
        private bool RenderSingleLayer;
        private int SingleLayerToRender;

        private readonly TiledDisplay Disp;
        private readonly Timer RefreshTimer;
        private readonly Timer AnimationTimer;

        private static readonly int DefaultRefreshInterval = 60;
        private static readonly int DefaultAnimationInterval = 256;

        public MapRenderer(TiledDisplay disp) 
            : this(null, disp, new Rectangle(0, 0, 0, 0), new Point(0, 0))
        {
        }

        public MapRenderer(ObjectMap map, TiledDisplay disp)
            : this(map, disp, new Rectangle(0, 0, disp.Cols, disp.Rows), new Point(0, 0))
        {
        }

        public MapRenderer(ObjectMap map, TiledDisplay disp, Rectangle viewport)
            : this(map, disp, viewport, new Point(0, 0))
        {
        }

        public MapRenderer(ObjectMap map, TiledDisplay disp, Rectangle viewport, Point scroll)
        {
            Map = map;
            Disp = disp;
            Viewport = viewport;
            Scroll = scroll;
            RenderSingleLayer = false;
            SingleLayerToRender = 0;
            RenderInvisibleObjects = false;
            ClearViewportBeforeRender = true;

            AutoRefresh = true;
            RefreshTimer = new Timer();
            RefreshTimer.Interval = DefaultRefreshInterval;
            RefreshTimer.Tick += RefreshTimer_Tick;
            RefreshTimer.Start();

            AnimationFrame = 0;
            AnimationEnabled = true;
            AnimationTimer = new Timer();
            AnimationTimer.Interval = DefaultAnimationInterval;
            AnimationTimer.Tick += AnimationTimer_Tick;
            AnimationTimer.Start();
        }

        public void Start()
        {
            RefreshTimer.Start();
            AnimationTimer.Start();
        }

        public void Stop()
        {
            RefreshTimer.Stop();
            AnimationTimer.Stop();
        }

        public void SetRenderSingleLayer(bool renderSingleLayer, int layer)
        {
            RenderSingleLayer = renderSingleLayer;
            SingleLayerToRender = layer;
        }

        public void SetSingleLayerToRender(int layer)
        {
            SingleLayerToRender = layer;
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            if (AutoRefresh)
                Render();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (AnimationEnabled)
                AdvanceAnimation();
        }

        public void AdvanceAnimation()
        {
            AnimationFrame++;
        }

        public void ScrollByDistance(Point distance)
        {
            ScrollByDistance(distance.X, distance.Y);
        }

        public void ScrollByDistance(int dx, int dy)
        {
            Scroll = new Point(Scroll.X + dx, Scroll.Y + dy);
        }

        public void ScrollToPoint(Point point)
        {
            Scroll = new Point(point.X, point.Y);
        }

        public void ScrollToCenter(Point point)
        {
            int offsetX = (Viewport.Width / 2);
            int offsetY = (Viewport.Height / 2);

            Scroll = new Point(point.X - offsetX, point.Y - offsetY);
        }

        public void Render()
        {
            if (Map == null)
                return;

            if (Viewport.IsEmpty)
                throw new TGLException("Unable to render map. Map viewport has size 0");
            if (Viewport.X < 0 || Viewport.Y < 0)
                throw new TGLException("Unable to render map. Map viewport has a negative position");
            if (Viewport.X + Viewport.Width > Disp.Cols || Viewport.Y + Viewport.Height > Disp.Rows)
                throw new TGLException("Unable to render map. Map viewport extends beyond display area");

            Tileset originalTileset = Disp.Graphics.Tileset;
            Palette originalPalette = Disp.Graphics.Palette;

            Disp.Graphics.Tileset = Map.Tileset;
            Disp.Graphics.Palette = Map.Palette;

            if (ClearViewportBeforeRender)
                Disp.Graphics.ClearRect(Map.BackColor, Viewport.X, Viewport.Y, Viewport.Width, Viewport.Height);

            if (RenderSingleLayer)
            {
                RenderLayer(Map.Layers[SingleLayerToRender]);
            }
            else
            {
                for (int i = 0; i < Map.Layers.Count; i++)
                    RenderLayer(Map.Layers[i]);
            }

            Disp.Refresh();
            Disp.Graphics.Tileset = originalTileset;
            Disp.Graphics.Palette = originalPalette;
        }

        private void RenderLayer(ObjectLayer layer)
        {
            for (int y = 0; y < Viewport.Height; y++)
            {
                for (int x = 0; x < Viewport.Width; x++)
                {
                    int sourceX = x + Scroll.X;
                    int sourceY = y + Scroll.Y;
                    int destX = Viewport.X + x;
                    int destY = Viewport.Y + y;

                    if (sourceX >= 0 && sourceY >= 0 && sourceX < Map.Width && sourceY < Map.Height)
                        RenderCell(layer.GetCell(sourceX, sourceY), destX, destY);
                    else
                        RenderOutOfBoundsObject(destX, destY);
                }
            }
        }

        private void RenderCell(ObjectCell cell, int x, int y)
        {
            GameObject o = cell.Object;

            if (o != null && (o.Visible || RenderInvisibleObjects))
            {
                Tile tile = o.Animation.GetFrame(AnimationFrame);
                if (tile != null)
                    Disp.Graphics.PutTile(x, y, tile.Index, tile.ForeColor, tile.BackColor);
            }
        }

        private void RenderOutOfBoundsObject(int x, int y)
        {
            GameObject oob = Map.OutOfBoundsObject;

            if (oob != null && (oob.Visible || RenderInvisibleObjects))
            {
                Tile tile = Map.OutOfBoundsObject.Animation.GetFrame(AnimationFrame);
                if (tile != null)
                    Disp.Graphics.PutTile(x, y, tile.Index, tile.ForeColor, tile.BackColor);
            }
        }
    }
}
