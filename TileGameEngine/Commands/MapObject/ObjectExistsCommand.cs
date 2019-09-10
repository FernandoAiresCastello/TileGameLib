using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectExistsCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            if (Environment.MapCursor.IsValid)
            {
                GameObject o = Environment.GetObjectRef();
                Push(o != null ? 1 : 0);
            }
            else
            {
                Push(0);
            }
        }
    }
}
