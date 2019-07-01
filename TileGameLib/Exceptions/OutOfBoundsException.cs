using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exceptions
{
    public class OutOfBoundsException : RuntimeException
    {
        public OutOfBoundsException() : base("Out of bounds access")
        {
        }

        public OutOfBoundsException(string msg) : base(msg)
        {
        }
    }
}
