using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Graphics
{
    public class Tile
    {
        public int Index { set; get; }
        public int ForeColor { set; get; }
        public int BackColor { set; get; }

        public static Tile Blank => new Tile(0, 0, 0);

        public Tile()
        {
            SetBlank();
        }

        public Tile(Tile other)
        {
            SetEqual(other);
        }

        public Tile(int chrix, int fgcix, int bgcix)
        {
            Index = chrix;
            ForeColor = fgcix;
            BackColor = bgcix;
        }

        public void Set(int tileIx, int foreColorIx, int backColorIx)
        {
            Index = tileIx;
            ForeColor = foreColorIx;
            BackColor = backColorIx;
        }

        public void SetEqual(Tile other)
        {
            Index = other.Index;
            ForeColor = other.ForeColor;
            BackColor = other.BackColor;
        }

        public void SetBlank()
        {
            Index = Blank.Index;
            ForeColor = Blank.ForeColor;
            BackColor = Blank.BackColor;
        }

        public Tile Copy()
        {
            return new Tile(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Tile other = (Tile)obj;

            return
                Index == other.Index &&
                ForeColor == other.ForeColor &&
                BackColor == other.BackColor;
        }

        public override int GetHashCode()
        {
            return Tuple.Create(Index, ForeColor, BackColor).GetHashCode();
        }
    }
}
