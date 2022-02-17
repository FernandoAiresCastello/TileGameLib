using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameMaker.Util
{
    public static class Config
    {
        public static int ReadInt(string key)
        {
            string value = ReadString(key);
            if (value.ToLower().StartsWith("0x"))
                return Convert.ToInt32(value, 16);

            return int.Parse(value);
        }

        public static char ReadChar(string key)
        {
            return ReadString(key).First();
        }

        public static string ReadString(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
    }
}
