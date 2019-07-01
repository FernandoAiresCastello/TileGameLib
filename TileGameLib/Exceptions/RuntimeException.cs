using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exceptions
{
    public class RuntimeException : Exception
    {
        public RuntimeException() : base("Unhandled runtime exception")
        {
        }

        public RuntimeException(string msg) : base(msg)
        {
        }

        public RuntimeException(string msg, Exception inner) : base(msg, inner)
        {
        }
    }
}
