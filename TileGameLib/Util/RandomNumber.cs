using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Util
{
    public static class RandomNumber
    {
        private static readonly Random Random = new Random();

        public static int Get(int max)
        {
            return Random.Next(max + 1);
        }

        public static int Get(int min, int max)
        {
            return Random.Next(min, max + 1);
        }
    }
}
