using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class Tile
    {
        public int TileIx { set; get; }
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        public static Tile Null { get; private set; } = new Tile(0, 0, 0);

        public Tile()
        {
            SetNull();
        }

        public Tile(Tile other)
        {
            SetEqual(other);
        }

        public Tile(int chrix, int fgcix, int bgcix)
        {
            TileIx = chrix;
            ForeColorIx = fgcix;
            BackColorIx = bgcix;
        }

        public void Set(int tileIx, int foreColorIx, int backColorIx)
        {
            TileIx = tileIx;
            ForeColorIx = foreColorIx;
            BackColorIx = backColorIx;
        }

        public void SetEqual(Tile other)
        {
            TileIx = other.TileIx;
            ForeColorIx = other.ForeColorIx;
            BackColorIx = other.BackColorIx;
        }

        public void SetNull()
        {
            TileIx = Null.TileIx;
            ForeColorIx = Null.ForeColorIx;
            BackColorIx = Null.BackColorIx;
        }

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
                return false;

            Tile other = (Tile)o;

            return
                TileIx == other.TileIx &&
                ForeColorIx == other.ForeColorIx &&
                BackColorIx == other.BackColorIx;
        }

        public Tile Copy()
        {
            return new Tile(this);
        }
    }
}
