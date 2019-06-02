using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameMaker.Component;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        private ObjectMap Map;
        private Display Disp;
        private Timer AnimationTimer;
        private int AnimationFrame;

        public MapRenderer(ObjectMap map, Display disp, int animationInterval)
        {
            Map = map;
            Disp = disp;
            Disp.Graphics.Tileset = Map.Charset;
            Disp.Graphics.Palette = Map.Palette;
            AnimationFrame = 0;
            AnimationTimer = new Timer();
            AnimationTimer.Interval = animationInterval;
            AnimationTimer.Tick += AnimationTimer_Tick;
            AnimationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            Render();
            Disp.Refresh();
            AdvanceAnimation();
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
            Disp.Graphics.DrawTile(x, y, ch.TileIx, ch.ForeColorIx, ch.BackColorIx);
        }
    }
}
