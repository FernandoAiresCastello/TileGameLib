using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Components;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        public ObjectMap Map { set; get; }
        public bool AnimationEnabled { set; get; }

        private TiledDisplay Disp;
        private Timer AnimationTimer;
        private int AnimationFrame;

        public MapRenderer(ObjectMap map, TiledDisplay disp, int animationInterval)
        {
            Map = map;
            Disp = disp;
            Disp.Graphics.Tileset = Map.Tileset;
            Disp.Graphics.Palette = Map.Palette;
            AnimationFrame = 0;
            AnimationEnabled = true;
            AnimationTimer = new Timer();
            AnimationTimer.Interval = animationInterval;
            AnimationTimer.Tick += AnimationTimer_Tick;
            AnimationTimer.Start();
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
            for (int y = 0; y < layer.Height; y++)
                for (int x = 0; x < layer.Width; x++)
                    RenderObject(layer.GetObject(x, y), x, y);
        }

        public void RenderObject(GameObject o, int x, int y)
        {
            Tile ch = o.Animation.GetFrame(AnimationFrame);
            Disp.Graphics.PutTile(x, y, ch.TileIx, ch.ForeColorIx, ch.BackColorIx);
        }
    }
}
