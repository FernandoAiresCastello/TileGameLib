using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exception
{
    public class RuntimeException : System.Exception
    {
        public RuntimeException() : base("Unhandled runtime exception")
        {
        }

        public RuntimeException(string msg) : base(msg)
        {
        }

        public RuntimeException(string msg, System.Exception inner) : base(msg, inner)
        {
        }
    }
}
