using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Util
{
    public static class RandomID
    {
        private static readonly Random Random = new Random();
        private static readonly string DefaultChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string Generate(string allowedChars, int length)
        {
            StringBuilder id = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int randomChar = Random.Next(0, allowedChars.Length);
                id.Append(allowedChars[randomChar]);
            }

            return id.ToString();
        }

        public static string Generate(int length)
        {
            return Generate(DefaultChars, length);
        }
    }
}
