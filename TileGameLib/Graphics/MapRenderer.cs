﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Components;
using System.Drawing;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        public ObjectMap Map { set; get; }
        public bool AnimationEnabled { set; get; }
        public bool AutoRefresh { set; get; }

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

        private Rectangle Viewport;
        private Point MapOffset;
        private int AnimationFrame;
        private bool RenderSingleLayer;
        private int SingleLayerToRender;

        private readonly TiledDisplay Disp;
        private readonly Timer RefreshTimer;
        private readonly Timer AnimationTimer;

        private static readonly int DefaultRefreshInterval = 60;
        private static readonly int DefaultAnimationInterval = 256;

        public MapRenderer(ObjectMap map, TiledDisplay disp)
            : this(map, disp, new Rectangle(0, 0, disp.Cols, disp.Rows), new Point(0, 0))
        {
        }

        public MapRenderer(ObjectMap map, TiledDisplay disp, Rectangle viewport, Point mapOffset)
        {
            Map = map;
            Disp = disp;
            Viewport = viewport;
            MapOffset = mapOffset;
            RenderSingleLayer = false;
            SingleLayerToRender = 0;

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

        public void SetViewport(int x, int y, int width, int height)
        {
            Viewport = new Rectangle(x, y, width, height);
        }

        public void AdvanceAnimation()
        {
            AnimationFrame++;
        }

        public void Render()
        {
            Tileset originalTileset = Disp.Graphics.Tileset;
            Palette originalPalette = Disp.Graphics.Palette;

            Disp.Graphics.Tileset = Map.Tileset;
            Disp.Graphics.Palette = Map.Palette;
            Disp.Graphics.Clear(Map.BackColor);

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
                    int sourceX = x + MapOffset.X;
                    int sourceY = y + MapOffset.Y;
                    int destX = Viewport.X + x;
                    int destY = Viewport.Y + y;

                    if (sourceX >= 0 && sourceY >= 0 && sourceX < Map.Width && sourceY < Map.Height)
                        RenderCell(layer.GetCell(sourceX, sourceY), destX, destY);
                }
            }
        }

        private void RenderCell(LayerCell cell, int x, int y)
        {
            GameObject o = cell.GetObject();

            if (o != null)
            {
                Tile tile = o.Animation.GetFrame(AnimationFrame);
                Disp.Graphics.PutTile(x, y, tile.TileIx, tile.ForeColorIx, tile.BackColorIx);
            }
        }
    }
}
