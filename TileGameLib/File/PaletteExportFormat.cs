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
                case PaletteExportFormat.RawBytes: return FileExtensions.PaletteRaw;
                case PaletteExportFormat.HexadecimalRgb: return FileExtensions.PaletteRgb;
                case PaletteExportFormat.HexadecimalCsv: return FileExtensions.PaletteCsv;
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
