using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameMaker.MapEditorElements
{
    public class MacroPlayer
    {
        private readonly ObjectMap Map;

        public MacroPlayer(ObjectMap map)
        {
            Map = map;
        }

        public string Execute(string macro)
        {
            string result = "Ok";
            
            // TODO

            return result;
        }
    }
}
