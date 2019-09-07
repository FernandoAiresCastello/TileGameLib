﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameEngine.Commands.Map
{
    public class ObjectAtCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int y = PopInt();
            int x = PopInt();
            int layer = PopInt();
            string tag = PopStr();

            GameObject o = Environment.GetObjectRefAt(layer, x, y);

            if (o != null && o.HasTag && o.Tag.Equals(tag))
                Push(1);
            else
                Push(0);
        }
    }
}
