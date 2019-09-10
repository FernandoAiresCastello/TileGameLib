using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectPropertySetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string value = PopStr();
            string property = PopStr();
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();

            Environment.SetObjectProperty(layer, x, y, property, value);
        }
    }
}
