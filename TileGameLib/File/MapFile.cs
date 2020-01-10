using System;
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

        private static readonly byte EmptyCell = 0;
        private static readonly byte OccupiedCell = 1;

        public static void Export(MapExportFormat format, ObjectMap map, string file)
        {
            switch (format)
            {
                case MapExportFormat.RawBytes: SaveAsRawBytes(map, file); break;

                default: throw new TileGameLibException("Invalid export format: " + format.ToString());
            }
        }

        public static MemoryFile SaveAsRawBytes(ObjectMap map)
        {
            MemoryFile file = new MemoryFile();

            file.WriteStringNullTerminated(Header);
            file.WriteStringNullTerminated(StringOrEmpty(map.Name));
            file.WriteShort(map.Width);
            file.WriteShort(map.Height);
            file.WriteShort(map.BackColor);
            file.WriteStringNullTerminated(StringOrEmpty(map.MusicFile));
            file.WriteStringNullTerminated(StringOrEmpty(map.Script));
            file.WriteByte((byte)map.Layers.Count);

            foreach (ObjectLayer layer in map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);

                        if (o != null)
                        {
                            file.WriteByte(OccupiedCell);
                            file.WriteStringNullTerminated(o.Tag);
                            file.WriteByte(o.Visible ? (byte)1 : (byte)0);
                            file.WriteByte((byte)o.Animation.Size);

                            foreach (Tile tile in o.Animation.Frames)
                            {
                                file.WriteShort((short)tile.Index);
                                file.WriteByte((byte)tile.ForeColor);
                                file.WriteByte((byte)tile.BackColor);
                            }

                            file.WriteInt(o.Properties.Entries.Count);

                            foreach (var property in o.Properties.Entries)
                            {
                                file.WriteStringNullTerminated(property.Key);
                                file.WriteStringNullTerminated(property.Value);
                            }
                        }
                        else
                        {
                            file.WriteByte(EmptyCell);
                        }
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

        public static void SaveAsRawBytes(ObjectMap map, string path)
        {
            MemoryFile file = SaveAsRawBytes(map);
            file.SaveToPhysicalFile(path);
        }

        public static ObjectMap LoadFromRawBytes(MemoryFile file)
        {
            string header = file.ReadStringNullTerminated();
            if (!Header.Equals(header))
                throw new TileGameLibException("Invalid file format");

            string name = file.ReadStringNullTerminated();
            int width = file.ReadShort();
            int height = file.ReadShort();
            int backColor = file.ReadShort();
            string musicFile = file.ReadStringNullTerminated();
            string script = file.ReadStringNullTerminated();

            ObjectMap map = new ObjectMap(name, width, height, backColor);

            int layerCount = file.ReadByte();
            map.Layers.Clear();
            map.AddLayers(layerCount);
            map.MusicFile = musicFile;
            map.Script = script;

            foreach (ObjectLayer layer in map.Layers)
            {
                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        byte cellState = file.ReadByte();

                        if (cellState == OccupiedCell)
                        {
                            string tag = file.ReadStringNullTerminated();
                            bool visible = file.ReadByte() > 0;
                            int frameCount = file.ReadByte();

                            GameObject o = new GameObject();
                            o.Tag = tag;
                            o.Visible = visible;
                            o.Animation.Clear();
                            o.Animation.AddFrames(frameCount, Tile.Blank);

                            foreach (Tile tile in o.Animation.Frames)
                            {
                                tile.Index = file.ReadShort();
                                tile.ForeColor = file.ReadByte();
                                tile.BackColor = file.ReadByte();
                            }

                            int propertyCount = file.ReadInt();

                            for (int i = 0; i < propertyCount; i++)
                            {
                                string prop = file.ReadStringNullTerminated();
                                string value = file.ReadStringNullTerminated();
                                o.Properties.Set(prop, value);
                            }

                            layer.SetObject(o, x, y);
                        }
                        else
                        {
                            layer.DeleteObject(x, y);
                        }
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

        public static ObjectMap LoadFromRawBytes(string path)
        {
            MemoryFile file = new MemoryFile(path);
            return LoadFromRawBytes(file);
        }

        public static void LoadFromRawBytes(ref ObjectMap map, string path)
        {
            if (map != null)
                map.SetEqual(LoadFromRawBytes(path));
            else
                map = LoadFromRawBytes(path);
        }

        private static string StringOrEmpty(string str)
        {
            return !string.IsNullOrWhiteSpace(str) ? str : "";
        }
    }
}
