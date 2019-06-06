using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class UIContext
    {
        public GraphicsAdapter Graphics { set; get; }
        public Tileset Tileset { set; get; }
        public Palette Palette { set; get; }
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        public UIContext(GraphicsAdapter gr)
        {
            Graphics = gr;
            Tileset = new Tileset();
            Palette = new Palette();
            ForeColorIx = 1;
            BackColorIx = 0;
        }
    }
}
