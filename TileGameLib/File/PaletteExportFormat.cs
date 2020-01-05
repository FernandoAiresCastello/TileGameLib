using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public enum PaletteExportFormat
    {
        RawBytes,
        HexadecimalRgb,
        HexadecimalCsv
    }

    public static class PaletteExportFileExtension
    {
        public static string Get(PaletteExportFormat format)
        {
            switch (format)
            {
                case PaletteExportFormat.RawBytes: return "dat.tgpal";
                case PaletteExportFormat.HexadecimalRgb: return "rgb.tgpal";
                case PaletteExportFormat.HexadecimalCsv: return "csv.tgpal";
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
