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
        private readonly GameContext GameContext;
        private readonly ObjectMap Map;
        private ScriptedGameObject ScriptedGameObject;
        private int CommandPointer = 0;
        private bool Branching;

        public Interpreter(GameContext ctx, ObjectMap map)
        {
            GameContext = ctx;
            Map = map;
        }

        public void Run(ScriptedGameObject o)
        {
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

        private void InterpretCommand(Command cmd)
        {
            // todo
        }
    }
}
