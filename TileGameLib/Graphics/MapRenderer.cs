using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TileGameLib.Core;

namespace TileGameLib.Graphics
{
    public class MapRenderer
    {
        public ObjectMap Map { set; get; }
        public GraphicsAdapter Gr { set; get; }

        private int AnimationFrame;
        private Timer AnimationTimer;
        private readonly int AnimationInterval;

        public MapRenderer(ObjectMap map, GraphicsAdapter gr)
        {
            Map = map;
            Gr = gr;
            AnimationFrame = 0;
            AnimationInterval = 100;
            AnimationTimer = new Timer((e) => { Render(); }, null, 
                TimeSpan.Zero, TimeSpan.FromMilliseconds(AnimationInterval));
        }

        private void Render()
        {
            foreach (ObjectLayer layer in Map.Layers)
                RenderLayer(layer);
        }

        private void RenderLayer(ObjectLayer layer)
        {
            for (int y = 0; y < layer.Height; y++)
                for (int x = 0; x < layer.Width; x++)
                    RenderObject(layer.GetObject(x, y), x, y);
        }

        private void RenderObject(GameObject o, int x, int y)
        {
            ObjectChar ch = o.Animation.GetFrame(AnimationFrame);
            Gr.DrawChar(Map.Charset, Map.Palette, x, y,
                ch.CharIx, ch.ForeColorIx, ch.BackColorIx);
        }
    }
}
