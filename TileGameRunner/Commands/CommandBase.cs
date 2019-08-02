using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Core;
using TileGameRunner.Exceptions;
using Environment = TileGameRunner.Core.Environment;

namespace TileGameRunner.Commands
{
    public class CommandBase
    {
        public Interpreter Interpreter { set; get; }
        public Environment Environment { set; get; }

        public CommandBase()
        {
        }

        public void FatalError(string msg)
        {
            Interpreter.FatalError(msg);
        }

        public virtual void Execute(List<string> paramList)
        {
        }
    }
}
