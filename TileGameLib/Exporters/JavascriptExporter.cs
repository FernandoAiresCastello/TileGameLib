using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Exporters
{
    public static class JavascriptExporter
    {
        public static void Export(ObjectMap map, string path)
        {
            StringBuilder js = new StringBuilder();



            System.IO.File.WriteAllText(path, js.ToString());
        }
    }
}
