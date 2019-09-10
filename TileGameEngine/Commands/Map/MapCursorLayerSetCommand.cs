﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Map
{
    public class MapCursorLayerSetCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int layer = PopInt();

            Environment.MapCursor.Position.Layer = layer;
        }
    }
}
