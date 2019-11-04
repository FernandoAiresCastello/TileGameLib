using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public static class TilesetFile
    {
        public static MemoryFile Save(Tileset tileset)
        {
            MemoryFile file = new MemoryFile();

            file.WriteShort(tileset.Size);

            foreach (TilePixels pixels in tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    file.WriteByte(row);
            }

            return file;
        }

        public static void Save(Tileset tileset, string path)
        {
            MemoryFile file = Save(tileset);
            file.SaveToPhysicalFile(path);
        }

        public static Tileset Load(MemoryFile file)
        {
            Tileset tileset = new Tileset();

            int tilesetSize = file.ReadShort();

            tileset.Clear(tilesetSize);

            foreach (TilePixels pixels in tileset.Pixels)
            {
                for (int i = 0; i < pixels.PixelRows.Length; i++)
                    pixels.PixelRows[i] = file.ReadByte();
            }

            return tileset;
        }

        public static Tileset Load(string path)
        {
            MemoryFile file = new MemoryFile(path);
            return Load(file);
        }
    }
}
