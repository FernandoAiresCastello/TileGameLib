﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.ControlFlow
{
    public class JumpZeroCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            int top = PopInt();

            if (top == 0)
            {
                string label = immediateParams[0];
                Jump(label);
            }
        }
    }
}
