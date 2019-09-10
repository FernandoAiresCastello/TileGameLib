using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectTileIxGetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int frame = PopInt();

            int? ix = Environment.GetObjectTileIx(frame);

            if (ix != null)
                Push(ix.Value);
            else
                TileGameEngineApplication.Error("SCRIPT ERROR", $"Object not found");
        }
    }
}
