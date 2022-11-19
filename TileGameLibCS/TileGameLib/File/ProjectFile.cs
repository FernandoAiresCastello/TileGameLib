using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.File
{
    public static class ProjectFile
    {
        private static readonly string Header = "TGLPRO01";
        private static readonly char Separator = '§';

        public static void Save(Project project)
        {
            StringBuilder text = new StringBuilder();
            void Append(object o) => text.Append((o != null ? o.ToString() : "") + Separator.ToString());

            // === FILE HEADER ===
            Append(Header);

            // === PROJECT METADATA ===
            project.Name = Path.GetFileNameWithoutExtension(project.Path);
            Append(project.Name);
            Append(project.CreationDate);

            // === PALETTE ===
            Append(project.Palette.Size);
            foreach (int argb in project.Palette.Colors)
            {
                Color color = Color.FromArgb(argb);
                Append(color.R);
                Append(color.G);
                Append(color.B);
            }

            // === TILESET ===
            Append(project.Tileset.Size);
            foreach (TilePixels pixels in project.Tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    Append(row);
            }

            // === MAPS ===
            Append(project.Maps.Count);
            foreach (ObjectMap map in project.Maps)
            {
                Append(map.Id);
                Append(map.Name);
                Append(map.Width);
                Append(map.Height);
                Append(map.BackColor);
                Append(map.Layers.Count);

                // === LAYERS ===
                for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
                {
                    ObjectLayer layer = map.Layers[layerIndex];

                    for (int y = 0; y < layer.Height; y++)
                    {
                        for (int x = 0; x < layer.Width; x++)
                        {
                            // === OBJECT ===
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

                // === OUT-OF-BOUNDS OBJECT ===
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
            }

            // === TEMPLATE OBJECTS ===
            for (int y = 0; y < project.TemplateObjects.Height; y++)
            {
                for (int x = 0; x < project.TemplateObjects.Width; x++)
                {
                    GameObject o = project.TemplateObjects.GetObject(new ObjectPosition(0, x, y));

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

            // === CONFIG ===
            string config = project.Config.ToString();
            Append(config);

            MemoryFile file = new MemoryFile();
            file.WriteString(text.ToString());
            file.SaveToPhysicalFile(project.Path);
        }

        public static bool Load(Project project)
        {
            if (!System.IO.File.Exists(project.Path))
                return false;

            project.Maps.Clear();

            MemoryFile file = new MemoryFile(project.Path);
            string text = file.ReadAllText();
            string[] data = text.Split(Separator);
            int ptr = 0;

            string NextString() => data[ptr++];
            int NextNumber() => int.Parse(data[ptr++]);

            // === FILE HEADER ===
            string header = NextString();
            if (header != Header)
            {
                Alert.Error("Invalid file format");
                return false;
            }

            // === PROJECT METADATA ===
            project.Name = NextString();
            project.CreationDate = NextString();

            // === PALETTE ===
            int paletteSize = NextNumber();
            project.Palette.Clear(paletteSize);
            for (int i = 0; i < paletteSize; i++)
            {
                int r = NextNumber();
                int g = NextNumber();
                int b = NextNumber();
                project.Palette.Set(i, r, g, b);
            }

            // === TILESET ===
            int tilesetSize = NextNumber();
            project.Tileset.ClearToSize(tilesetSize);
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
                project.Tileset.Set(i, row1, row2, row3, row4, row5, row6, row7, row8);
            }

            // === MAPS ===
            int mapCount = NextNumber();
            for (int mi = 0; mi < mapCount; mi++)
            {
                string id = NextString();
                string name = NextString();
                int width = NextNumber();
                int height = NextNumber();
                int backColor = NextNumber();
                int layerCount = NextNumber();

                ObjectMap map = new ObjectMap(project, name, layerCount, width, height, backColor);
                map.Id = id;

                // === LAYERS ===
                for (int layerIndex = 0; layerIndex < map.Layers.Count; layerIndex++)
                {
                    ObjectLayer layer = map.Layers[layerIndex];

                    for (int y = 0; y < layer.Height; y++)
                    {
                        for (int x = 0; x < layer.Width; x++)
                        {
                            // === OBJECT ===
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

                // === OUT-OF-BOUNDS OBJECT ===
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

                project.Maps.Add(map);
            }

            // === TEMPLATE OBJECTS ===
            project.TemplateObjects.Clear();
            ObjectLayer templates = project.TemplateObjects.Layers[0];

            for (int y = 0; y < templates.Height; y++)
            {
                for (int x = 0; x < templates.Width; x++)
                {
                    // === TEMPLATE ===
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

                        templates.SetObject(o, x, y);
                    }
                }
            }

            // === CONFIG ===
            string config = NextString();
            if (!string.IsNullOrWhiteSpace(config))
                project.Config.Parse(config);

            return true;
        }
    }
}
