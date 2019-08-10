﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands
{
    public class RefreshCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            Environment.RefreshWindow();
        }
    }
}
