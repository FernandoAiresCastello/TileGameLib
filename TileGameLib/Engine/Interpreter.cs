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

        protected bool Branching;
        protected int CommandPointer = 0;
        protected ScriptedGameObject ScriptedGameObject;
        protected readonly Stack ParamStack = new Stack();

        public void ExecuteObject(ScriptedGameObject o)
        {
            if (GameContext == null)
                throw new InvalidOperationException("GameContext cannot be null");

            CommandPointer = 0;
            ScriptedGameObject = o;
            List<Command> commands = o.Script.Commands;

            while (CommandPointer >= 0 && CommandPointer < commands.Count)
            {
                Branching = false;
                InterpretCommand(commands[CommandPointer], o.GameObject);
                if (!Branching)
                    CommandPointer++;
            }
        }

        protected virtual void InterpretCommand(Command cmd, GameObject obj)
        {
            throw new NotImplementedException("InterpretCommand must be overriden by a subclass");
        }
    }
}
