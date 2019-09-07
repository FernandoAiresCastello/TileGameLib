using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectFindCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string tag = PopStr();

            ObjectPosition pos = Environment.FindObjectPositionByTag(tag);

            if (pos == null)
                TileGameEngineApplication.Error("SCRIPT ERROR", "Object not found with tag: " + tag);

            Push(pos.Y);
            Push(pos.X);
            Push(pos.Layer);
        }
    }
}
