using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TileGameLib.Exceptions;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.File
{
    public static class MapFile
    {
        private static readonly string Header = "TGLMAP01";
        private static readonly char Separator = '§';

        public static void Save(ObjectMap map, string path)
        {
            StringBuilder text = new StringBuilder();
            
            void Append(object o) => text.Append((o != null ? o.ToString() : "") + Separator.ToString());

            Append(Header);
            Append(map.Id);
            Append(map.Name);
            Append(map.Width);
            Append(map.Height);
            Append(map.BackColor);
            Append(map.Layers.Count);

            for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
            {
                ObjectLayer layer = map.Layers[layerIndex];

                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        GameObject o = layer.GetObject(x, y);
                        
                        if (o != null)
                        {
                            Append(1);
                            Append(o.Visible ? 1 : 0);

                            Append(o.Animation.Size);
                            foreach (Tile tile in o.Animation.Frames)
                            {
                                Append((short)tile.Index);
                                Append((byte)tile.ForeColor);
                                Append((byte)tile.BackColor);
                            }

                            Append(o.Properties.Entries.Count);
                            foreach (var property in o.Properties.Entries)
                            {
                                Append(property.Key);
                                Append(property.Value);
                            }
                        }
                        else
                        {
                            Append(0);
                        }
                    }
                }
            }

            Append(map.Palette.Size);
            foreach (int argb in map.Palette.Colors)
            {
                Color color = Color.FromArgb(argb);
                Append(color.R);
                Append(color.G);
                Append(color.B);
            }

            Append(map.Tileset.Size);
            foreach (TilePixels pixels in map.Tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    Append(row);
            }

            GameObject oob = map.OutOfBoundsObject;
            if (oob != null)
            {
                Append(1);

                Append(oob.Animation.Size);
                foreach (Tile tile in oob.Animation.Frames)
                {
                    Append((short)tile.Index);
                    Append((byte)tile.ForeColor);
                    Append((byte)tile.BackColor);
                }
            }
            else
            {
                Append(0);
            }

            Append(map.Extra);

            MemoryFile file = new MemoryFile();
            file.WriteString(text.ToString());
            file.SaveToPhysicalFile(path);
        }

        public static ObjectMap Load(string path)
        {
            MemoryFile file = new MemoryFile(path);
            string text = file.ReadAllText();
            string[] data = text.Split(Separator);
            int ptr = 0;

            string NextString() => data[ptr++];
            int NextNumber() => int.Parse(data[ptr++]);

            string header = NextString();
            if (header != Header)
            {
                Alert.Error("Invalid file format");
                return null;
            }

            string id = NextString();
            string name = NextString();
            int width = NextNumber();
            int height = NextNumber();
            int backColor = NextNumber();
            int layerCount = NextNumber();

            ObjectMap map = new ObjectMap(name, layerCount, width, height, backColor);
            map.Id = id;

            for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
            {
                ObjectLayer layer = map.Layers[layerIndex];

                for (int y = 0; y < layer.Height; y++)
                {
                    for (int x = 0; x < layer.Width; x++)
                    {
                        int occupiedCell = NextNumber();
                        if (occupiedCell == 1)
                        {
                            GameObject o = new GameObject();
                            o.Visible = NextNumber() > 0;

                            o.Animation.Clear();
                            int animSize = NextNumber();
                            for (int i = 0; i < animSize; i++)
                            {
                                int index = NextNumber();
                                int fgc = NextNumber();
                                int bgc = NextNumber();
                                o.Animation.AddFrame(new Tile(index, fgc, bgc));
                            }

                            o.Properties.RemoveAll();
                            int propCount = NextNumber();
                            for (int i = 0; i < propCount; i++)
                            {
                                string key = NextString();
                                string value = NextString();
                                o.Properties.Set(key, value);
                            }

                            layer.SetObject(o, x, y);
                        }
                    }
                }
            }

            int paletteSize = NextNumber();
            map.Palette.Clear(paletteSize, Color.White);
            for (int i = 0; i < paletteSize; i++)
            {
                int r = NextNumber();
                int g = NextNumber();
                int b = NextNumber();
                map.Palette.Set(i, r, g, b);
            }

            int tilesetSize = NextNumber();
            map.Tileset.ClearToSize(tilesetSize);
            for (int i = 0; i < tilesetSize; i++)
            {
                byte row1 = (byte)NextNumber();
                byte row2 = (byte)NextNumber();
                byte row3 = (byte)NextNumber();
                byte row4 = (byte)NextNumber();
                byte row5 = (byte)NextNumber();
                byte row6 = (byte)NextNumber();
                byte row7 = (byte)NextNumber();
                byte row8 = (byte)NextNumber();
                map.Tileset.Set(i, row1, row2, row3, row4, row5, row6, row7, row8);
            }

            int hasOob = NextNumber();
            if (hasOob > 0)
            {
                GameObject o = new GameObject();
                o.Animation.Clear();
                int animSize = NextNumber();
                for (int i = 0; i < animSize; i++)
                {
                    int index = NextNumber();
                    int fgc = NextNumber();
                    int bgc = NextNumber();
                    o.Animation.AddFrame(new Tile(index, fgc, bgc));
                }
                map.OutOfBoundsObject = o;
            }

            map.Extra = NextString();

            return map;
        }

        public static void Load(ref ObjectMap map, string path)
        {
            ObjectMap loadedMap = Load(path);
            map.SetEqual(loadedMap);
        }
    }
}
