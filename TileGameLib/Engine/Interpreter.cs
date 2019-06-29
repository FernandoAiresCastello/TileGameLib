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
        public ObjectMap Map { set; get; }

        protected ScriptedGameObject ScriptedGameObject;
        protected int CommandPointer = 0;
        protected bool Branching;

        public Interpreter()
        {
            GameContext = null;
            Map = null;
        }

        public void Run(ScriptedGameObject o)
        {
            if (GameContext == null || Map == null)
                throw new InvalidOperationException();

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
            throw new NotImplementedException();
        }
    }
}
