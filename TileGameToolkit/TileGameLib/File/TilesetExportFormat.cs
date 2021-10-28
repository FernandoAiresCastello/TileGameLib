using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public enum TilesetExportFormat
    {
        RawBytes,
        HexadecimalCsv, 
        BinaryStrings
    }

    public static class TilesetExportFileExtension
    {
        public static string Get(TilesetExportFormat format)
        {
            switch (format)
            {
                case TilesetExportFormat.RawBytes: return FileExtensions.TilesetRaw;
                case TilesetExportFormat.HexadecimalCsv: return FileExtensions.TilesetCsv;
                case TilesetExportFormat.BinaryStrings: return FileExtensions.TilesetBinaryStrings;
            }

            throw new TGLException("Invalid export format: " + format.ToString());
        }
    }
}
