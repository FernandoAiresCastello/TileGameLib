﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Components;
using System.Drawing;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        public static readonly int DefaultAnimationInterval = 256;

        public ObjectMap Map { set; get; }
        public bool AnimationEnabled { set; get; }
        public Tile OutOfBoundsTile { set; get; }

        public int AnimationInterval
        {
            set { AnimationTimer.Interval = value; }
            get { return AnimationTimer.Interval; }
        }

        private TiledDisplay Disp;
        private Rectangle Viewport;
        private Point MapOffset;
        private Timer AnimationTimer;
        private int AnimationFrame;

        public MapRenderer(ObjectMap map, TiledDisplay disp)
            : this(map, disp, new Rectangle(0, 0, disp.Cols, disp.Rows), new Point(0, 0))
        {
        }

        public MapRenderer(ObjectMap map, TiledDisplay disp, Rectangle viewport, Point mapOffset)
        {
            Map = map;
            Disp = disp;
            Disp.Graphics.Tileset = Map.Tileset;
            Disp.Graphics.Palette = Map.Palette;
            Viewport = viewport;
            MapOffset = mapOffset;
            OutOfBoundsTile = new Tile(0, 0, 0);
            AnimationFrame = 0;
            AnimationEnabled = true;
            AnimationTimer = new Timer();
            AnimationTimer.Interval = DefaultAnimationInterval;
            AnimationTimer.Tick += AnimationTimer_Tick;
            AnimationTimer.Start();
            Render();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            if (AnimationEnabled)
            {
                Render();
                AdvanceAnimation();
            }
        }

        public void AdvanceAnimation()
        {
            AnimationFrame++;
        }

        public void Render()
        {
            foreach (ObjectLayer layer in Map.Layers)
                RenderLayer(layer);

            Disp.Refresh();
        }

        public void RenderLayer(ObjectLayer layer)
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
                        RenderObject(layer.GetObject(sourceX, sourceY), destX, destY);
                    else
                        RenderObject(null, destX, destY);
                }
            }
        }

        public void RenderObject(GameObject o, int x, int y)
        {
            Tile ch = o != null ? o.Animation.GetFrame(AnimationFrame) : OutOfBoundsTile;
            Disp.Graphics.PutTile(x, y, ch.TileIx, ch.ForeColorIx, ch.BackColorIx);
        }
    }
}
