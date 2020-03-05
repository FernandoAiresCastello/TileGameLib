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
        Json
    }

    public static class MapExportFileExtension
    {
        public static string Get(MapExportFormat format)
        {
            switch (format)
            {
                case MapExportFormat.Json: return "json.tgmap";
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}
