using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exceptions
{
    public class TileGameLibException : Exception
    {
        public TileGameLibException() : base("Unhandled TileGameLib exception")
        {
        }

        public TileGameLibException(string msg) : base(msg)
        {
        }

        public TileGameLibException(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}
