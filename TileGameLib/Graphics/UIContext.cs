using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class UIContext
    {
        public GraphicsAdapter Gr { set; get; }
        public Tileset Chars { set; get; }
        public Palette Pal { set; get; }
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        public UIContext(GraphicsAdapter gr)
        {
            Gr = gr;
            Chars = new Tileset();
            Pal = new Palette();
            ForeColorIx = 1;
            BackColorIx = 0;
        }
    }
}
