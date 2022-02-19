using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;
using TileGameLib.Graphics;
using TileGameLib.Util;

namespace TileGameLib.File
{
    public static class TilesetFile
    {
        public static void Export(TilesetExportFormat format, Tileset tileset, string file)
        {
            switch (format)
            {
                case TilesetExportFormat.RawBytes: SaveAsRawBytes(tileset, file); break;
                case TilesetExportFormat.BinaryStrings: SaveAsBinaryStrings(tileset, file); break;
                case TilesetExportFormat.HexadecimalCsv: SaveAsHexadecimalCsv(tileset, file); break;

                default: throw new TGLException("Invalid export format: " + format.ToString());
            }
        }

        public static Tileset Import(TilesetExportFormat format, string file)
        {
            switch (format)
            {
                case TilesetExportFormat.RawBytes: return LoadFromRawBytes(file);
                case TilesetExportFormat.BinaryStrings: return LoadFromBinaryStrings(file);
                case TilesetExportFormat.HexadecimalCsv: return LoadFromHexadecimalCsv(file);

                default: throw new TGLException("Invalid export format: " + format.ToString());
            }
        }

        public static void SaveAsRawBytes(Tileset tileset, string path)
        {
            MemoryFile file = new MemoryFile();

            foreach (TilePixels pixels in tileset.Pixels)
            {
                foreach (byte row in pixels.PixelRows)
                    file.WriteByte(row);
            }

            file.SaveToPhysicalFile(path);
        }

        public static Tileset LoadFromRawBytes(string path)
        {
            MemoryFile file = new MemoryFile(path);
            Tileset tileset = new Tileset();

            int size = file.Length / 8;

            tileset.ClearToSize(size);

            try
            {
                foreach (TilePixels pixels in tileset.Pixels)
                {
                    for (int i = 0; i < pixels.PixelRows.Length; i++)
                    {
                        pixels.PixelRows[i] = file.ReadByte();
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.Error(ex.Message);
            }

            return tileset;
        }

        public static void SaveAsBinaryStrings(Tileset tileset, string path)
        {
            MemoryFile file = new MemoryFile();

            foreach (TilePixels pixels in tileset.Pixels)
            {
                StringBuilder binary = new StringBuilder();

                foreach (byte row in pixels.PixelRows)
                {
                    binary.Append(row.ToBinaryString());
                }

                file.WriteString(binary.ToString() + MemoryFile.NewLine);
            }

            file.SaveToPhysicalFile(path);
        }

        public static Tileset LoadFromBinaryStrings(string path)
        {
            throw new NotImplementedException();
        }

        public static void SaveAsHexadecimalCsv(Tileset tileset, string path)
        {
            MemoryFile file = new MemoryFile();

            foreach (TilePixels pixels in tileset.Pixels)
            {
                string line = BitConverter.ToString(pixels.PixelRows).Replace('-', ',');
                file.WriteString(line + MemoryFile.NewLine);
            }

            file.SaveToPhysicalFile(path);
        }

        public static Tileset LoadFromHexadecimalCsv(string path)
        {
            throw new NotImplementedException();
        }
    }
}
