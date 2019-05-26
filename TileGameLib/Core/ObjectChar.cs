using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Core
{
    public class ObjectChar
    {
        public int CharIx { set; get; }
        public int ForeColorIx { set; get; }
        public int BackColorIx { set; get; }

        public ObjectChar()
        {
            CharIx = 0;
            ForeColorIx = 0;
            BackColorIx = 0;
        }

        public ObjectChar(ObjectChar other)
        {
            SetEqual(other);
        }

        public ObjectChar(int chrix, int fgcix, int bgcix)
        {
            CharIx = chrix;
            ForeColorIx = fgcix;
            BackColorIx = bgcix;
        }

        public void SetEqual(ObjectChar other)
        {
            CharIx = other.CharIx;
            ForeColorIx = other.ForeColorIx;
            BackColorIx = other.BackColorIx;
        }

        public override bool Equals(object o)
        {
            if (o == null || GetType() != o.GetType())
                return false;

            ObjectChar other = (ObjectChar)o;

            return
                CharIx == other.CharIx &&
                ForeColorIx == other.ForeColorIx &&
                BackColorIx == other.BackColorIx;
        }

        public ObjectChar Copy()
        {
            return new ObjectChar(this);
        }
    }
}
