﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.Exceptions;

namespace TileGameLib.File
{
    public enum MapExportFormat
    {
        Raw,
        Json
    }

    public static class MapExportFileExtension
    {
        public static string Get(MapExportFormat format)
        {
            switch (format)
            {
                case MapExportFormat.Raw: return FileExtensions.MapRaw;
                case MapExportFormat.Json: return FileExtensions.MapJson;
            }

            throw new TileGameLibException("Invalid export format: " + format.ToString());
        }
    }
}