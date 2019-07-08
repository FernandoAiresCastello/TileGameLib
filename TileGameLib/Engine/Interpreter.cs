using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.GameElements;

namespace TileGameLib.Engine
{
    public class Interpreter
    {
        public GameContext GameContext { set; get; }

        protected ScriptedGameObject ScriptedGameObject;
        protected int CommandPointer = 0;
        protected bool Branching;
        protected readonly Stack ParamStack = new Stack();
        protected readonly Variables LocalVars = new Variables();

        public Interpreter()
        {
        }

        public void ExecuteObject(ScriptedGameObject o)
        {
            if (GameContext == null)
                throw new InvalidOperationException("GameContext cannot be null");

            CommandPointer = 0;
            ScriptedGameObject = o;
            List<Command> commands = o.Script.Commands;

            while (CommandPointer != commands.Count)
            {
                Branching = false;
                InterpretCommand(commands[CommandPointer]);
                if (!Branching)
                    CommandPointer++;
            }
        }

        protected virtual void InterpretCommand(Command cmd)
        {
            throw new NotImplementedException("InterpretCommand must be overriden by a subclass");
        }
    }
}
