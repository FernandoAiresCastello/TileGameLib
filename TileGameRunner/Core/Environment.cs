using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Windows;

namespace TileGameRunner.Core
{
    public class Environment
    {
        public GameWindow Window { get; set; }
        public Variables Variables { get; private set; } = new Variables();

        public Environment()
        {
        }

        public void Reset()
        {
            Variables.Clear();
        }
    }
}
