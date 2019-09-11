using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameEngine.Windows;
using System.Windows.Forms;
using TileGameEngine.Util;
using TileGameLib.Util;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public partial class Environment
    {
        public MemoryFile MemoryFile { get; private set; }

        public void OpenFile(string path)
        {
            MemoryFile = new MemoryFile(path);
        }
    }
}
