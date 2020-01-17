using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public enum MapExportFormat
    {
        RawBytes,
        Custom,
    }

    public static class MapExportFileExtension
    {
        public static string Get(MapExportFormat format)
        {
            switch (format)
            {
                case MapExportFormat.RawBytes: return "dat.tgmap";
                case MapExportFormat.Custom: return "tgmap";
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
