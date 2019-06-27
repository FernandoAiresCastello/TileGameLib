using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Engine
{
    public class Script
    {
        public List<Command> Commands { get; private set; } = new List<Command>();

        public void AddCommand(Command cmd)
        {
            Commands.Add(cmd);
        }
    }
}
