﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.Util;

namespace TileGameMaker.Test
{
    public class TestController : MapController
    {
        public override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
                Engine.ScrollMapByDistance(1, 0);
            else if (e.KeyCode == Keys.Left)
                Engine.ScrollMapByDistance(-1, 0);
            else if (e.KeyCode == Keys.Up)
                Engine.ScrollMapByDistance(0, -1);
            else if (e.KeyCode == Keys.Down)
                Engine.ScrollMapByDistance(0, 1);
        }
    }
}
