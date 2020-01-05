using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public enum ExportFormat
    {
        RawBytes,
        HexadecimalCsv, 
        BinaryStrings
    }

    public static class ExportFormatFileExtension
    {
        public static string Get(ExportFormat format)
        {
            switch (format)
            {
                case ExportFormat.RawBytes: return "dat";
                case ExportFormat.HexadecimalCsv: return "hex";
                case ExportFormat.BinaryStrings: return "bin";
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
