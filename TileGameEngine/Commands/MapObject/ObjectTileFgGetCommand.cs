using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectTileFgGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int frame = PopInt();

            int? color = Environment.GetObjectTileForeColor(frame);

            if (color != null)
                Push(color.Value);
            else
                TileGameEngineApplication.Error("SCRIPT ERROR", $"Object not found");
        }
    }
}
