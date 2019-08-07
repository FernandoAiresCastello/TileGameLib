﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Exceptions;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public class MapArchive
    {
        private readonly string Path;

        public MapArchive(string path)
        {
            Path = path;
        }

        public void Save(ObjectMap map, string filename)
        {
            MemoryFile file = MapFile.Save(map);
            Archive.Save(Path, filename, file);
        }

        public void Load(ref ObjectMap map, string filename)
        {
            ObjectMap loadedMap = Load(filename);
            map.SetEqual(loadedMap);
        }

        public ObjectMap Load(string filename)
        {
            MemoryFile file = Archive.Load(Path, filename);
            return MapFile.Load(file);
        }
    }
}
