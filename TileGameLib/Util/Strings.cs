using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Util
{
    public class Strings
    {
        public string[] Array { get; private set; }

        public Strings(params string[] array)
        {
            Array = new string[array.Length];
            array.CopyTo(Array, 0);
        }
    }
}
