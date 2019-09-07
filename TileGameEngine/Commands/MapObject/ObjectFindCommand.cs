using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Exceptions;
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
                throw new ScriptException("Object not found with tag: " + tag);

            Push(pos.Y);
            Push(pos.X);
            Push(pos.Layer);
        }
    }
}
