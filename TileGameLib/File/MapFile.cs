﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.File
{
    public static class MapFile
    {
        private static readonly string Header = "TGLMAP01";

        public static MemoryFile Save(ObjectMap map)
        {
            MemoryFile file = new MemoryFile();

            file.WriteString(Header);
            file.WriteString(map.Name);
            file.WriteShort(map.Width);
            file.WriteShort(map.Height);
            file.WriteByte((byte)map.Layers.Count);

            foreach (ObjectLayer layer in map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        file.WriteByte((byte)o.Animation.Size);

                        foreach (Tile tile in o.Animation.Frames)
                        {
                            file.WriteByte((byte)tile.TileIx);
                            file.WriteByte((byte)tile.ForeColorIx);
                            file.WriteByte((byte)tile.BackColorIx);
                        }

                        file.WriteString(o.Extra);
                    }
                }
            }

            file.WriteShort(map.Palette.Size);
            foreach (int argb in map.Palette.Colors)
            {
                Color color = Color.FromArgb(argb);
                file.WriteByte(color.R);
                file.WriteByte(color.G);
                file.WriteByte(color.B);
            }

            file.WriteShort(map.Tileset.Size);
            foreach (TilePixels pixels in map.Tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    file.WriteByte(row);
            }

            return file;
        }

        public static void Load(ref ObjectMap map, string path)
        {
            map.SetEqual(Load(path));
        }

        public static ObjectMap Load(string path)
        {
            MemoryFile file = new MemoryFile(path);
            return Load(file);
        }

        public static ObjectMap Load(MemoryFile file)
        {
            string header = file.ReadString();
            if (!Header.Equals(header))
                throw new FileException("Invalid file format");

            string name = file.ReadString();
            int width = file.ReadShort();
            int height = file.ReadShort();

            ObjectMap map = new ObjectMap(name, width, height);

            int layerCount = file.ReadByte();
            map.Layers.Clear();
            map.AddLayers(layerCount);

            foreach (ObjectLayer layer in map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        int frameCount = file.ReadByte();
                        o.Animation.Clear(null);
                        o.Animation.AddFrames(frameCount, new Tile());

                        foreach (Tile tile in o.Animation.Frames)
                        {
                            tile.TileIx = file.ReadByte();
                            tile.ForeColorIx = file.ReadByte();
                            tile.BackColorIx = file.ReadByte();
                        }

                        o.Extra = file.ReadString();
                    }
                }
            }

            int paletteSize = file.ReadShort();
            map.Palette.Clear(paletteSize, Color.White);
            for (int i = 0; i < map.Palette.Size; i++)
            {
                int r = file.ReadByte();
                int g = file.ReadByte();
                int b = file.ReadByte();
                map.Palette.Set(i, r, g, b);
            }

            int tilesetSize = file.ReadShort();
            map.Tileset.Clear(tilesetSize);
            foreach (TilePixels pixels in map.Tileset.Pixels)
            {
                for (int i = 0; i < pixels.PixelRows.Length; i++)
                    pixels.PixelRows[i] = file.ReadByte();
            }

            return map;
        }
    }
}
