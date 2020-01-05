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
                case TilesetExportFormat.RawBytes: return "dat.tgtil";
                case TilesetExportFormat.HexadecimalCsv: return "csv.tgtil";
                case TilesetExportFormat.BinaryStrings: return "bin.tgtil";
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
