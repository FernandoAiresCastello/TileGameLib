using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Core;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public class ObjectMapFile
    {
        private static readonly string Header = "TGLMAP01";

        private readonly ObjectMap Map;
        private readonly MemoryFile File = new MemoryFile();
        private readonly string ArchivePath;
        private readonly string Filename;

        public ObjectMapFile(ObjectMap map, string archivePath, string filename)
        {
            Map = map;
            ArchivePath = archivePath;
            Filename = filename;
        }

        public void Save()
        {
            File.WriteString(Header);
            File.WriteString(Map.Name);
            File.WriteShort(Map.Width);
            File.WriteShort(Map.Height);
            File.WriteByte((byte)Map.Layers.Count);

            foreach (ObjectLayer layer in Map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        File.WriteByte((byte)o.Type);
                        File.WriteByte((byte)o.Param);
                        File.WriteByte((byte)o.Animation.Size);

                        foreach (Tile tile in o.Animation.Frames)
                        {
                            File.WriteByte((byte)tile.TileIx);
                            File.WriteByte((byte)tile.ForeColorIx);
                            File.WriteByte((byte)tile.BackColorIx);
                        }

                        File.WriteString(o.Data);
                    }
                }
            }

            File.WriteShort(Map.Palette.Size);
            foreach (int argb in Map.Palette.Colors)
            {
                Color color = Color.FromArgb(argb);
                File.WriteByte(color.R);
                File.WriteByte(color.G);
                File.WriteByte(color.B);
            }

            File.WriteShort(Map.Tileset.Size);
            foreach (TilePixels pixels in Map.Tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    File.WriteByte(row);
            }

            Zip.Save(ArchivePath, Filename, File);
        }

        public void Load()
        {
            throw new NotImplementedException();
        }
    }
}
