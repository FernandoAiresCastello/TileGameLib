using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class TileGameEngineException : Exception
    {
        public TileGameEngineException(string title, string message)
            : base(title + "\n\n" + message)
        {
        }
    }
}
