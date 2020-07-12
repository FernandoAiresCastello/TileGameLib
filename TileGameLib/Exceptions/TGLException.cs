using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exceptions
{
    public class TGLException : Exception
    {
        public TGLException() : base("Unhandled TileGameLib exception")
        {
        }

        public TGLException(string msg) : base(msg)
        {
        }

        public TGLException(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}
