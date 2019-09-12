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

        public void CreateFile(string path)
        {
            File.Create(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void OpenFile(string path)
        {
            MemoryFile = new MemoryFile(path);
        }

        public void FlushFile()
        {
            if (MemoryFile != null)
                MemoryFile.SaveToPhysicalFile(MemoryFile.Path);
        }
    }
}
