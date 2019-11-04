using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public static class PaletteFile
    {
        public static MemoryFile Save(Palette palette)
        {
            MemoryFile file = new MemoryFile();

            file.WriteShort(palette.Size);

            foreach (int argb in palette.Colors)
            {
                Color color = Color.FromArgb(argb);
                file.WriteByte(color.R);
                file.WriteByte(color.G);
                file.WriteByte(color.B);
            }

            return file;
        }

        public static void Save(Palette palette, string path)
        {
            MemoryFile file = Save(palette);
            file.SaveToPhysicalFile(path);
        }

        public static Palette Load(MemoryFile file)
        {
            Palette palette = new Palette();

            int paletteSize = file.ReadShort();

            palette.Clear(paletteSize, Color.White);

            for (int i = 0; i < palette.Size; i++)
            {
                int r = file.ReadByte();
                int g = file.ReadByte();
                int b = file.ReadByte();
                palette.Set(i, r, g, b);
            }

            return palette;
        }

        public static Palette Load(string path)
        {
            MemoryFile file = new MemoryFile(path);
            return Load(file);
        }
    }
}
