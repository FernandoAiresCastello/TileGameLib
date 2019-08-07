﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;

namespace TileGameEngine.Core
{
    public class ProjectArchive
    {
        public string Path { get; private set; }

        public ProjectArchive(string path)
        {
            Path = path;
        }

        public bool Contains(string filename)
        {
            return Archive.Contains(Path, filename);
        }

        public void LoadMap(ref ObjectMap map, string filename)
        {
            MapArchive arch = new MapArchive(Path);
            arch.Load(ref map, filename);
        }

        public Script LoadScript(string filename)
        {
            MemoryFile file = Archive.Load(Path, filename);
            return new Script(file.ReadAllText());
        }
    }
}
