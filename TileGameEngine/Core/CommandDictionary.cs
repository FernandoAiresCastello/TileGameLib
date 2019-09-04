using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Commands;
using TileGameEngine.Commands.ControlFlow;
using TileGameEngine.Commands.Map;
using TileGameEngine.Commands.Math;
using TileGameEngine.Commands.Misc;
using TileGameEngine.Commands.Stack;
using TileGameEngine.Commands.System;
using TileGameEngine.Commands.Window;

namespace TileGameEngine.Core
{
    public class CommandDictionary
    {
        private readonly Dictionary<string, CommandBase> Commands = new Dictionary<string, CommandBase>();

        private readonly Interpreter Interpreter;
        private readonly Environment Environment;

        private void InitializeCommands()
        {
            // Misc
            Set("NOP", new NopCommand());

            // Control flow
            Set("JMP", new JumpCommand());
            Set("JZ", new JumpZeroCommand());
            Set("JNZ", new JumpNotZeroCommand());
            Set("CALL", new CallCommand());
            Set("CLZ", new CallZeroCommand());
            Set("CLNZ", new CallNotZeroCommand());
            Set("RET", new ReturnCommand());

            // Stack
            Set("PUSH", new PushCommand());
            Set("STORE", new StoreCommand());
            Set("LOAD", new LoadCommand());

            // System
            Set("SYSTEM.EXIT", new ExitCommand());
            Set("SYSTEM.SLEEP", new SleepCommand());

            // Arithmetic
            Set("MATH.INC", new IncrementCommand());
            Set("MATH.DEC", new DecrementCommand());
            Set("MATH.ADD", new AddCommand());
            Set("MATH.SUBTR", new SubtractCommand());
            Set("MATH.COMPARE", new CompareCommand());
            Set("MATH.MULT", new MultiplyCommand());
            Set("MATH.DIVIDE", new DivideCommand());
            Set("MATH.MODULO", new ModuloCommand());
            Set("MATH.SQRT", new SquareRootCommand());
            Set("MATH.POWER", new PowerCommand());

            // Graphics
            Set("WINDOW.OPEN", new OpenCommand());
            Set("WINDOW.REFRESH", new RefreshCommand());
            Set("WINDOW.PRINT", new PrintCommand());

            // Map
            Set("MAP.LOAD", new MapLoadCommand());
        }

        public CommandDictionary(Interpreter interpreter, Environment environment)
        {
            Interpreter = interpreter;
            Environment = environment;
            InitializeCommands();
        }

        public bool HasCommand(string name)
        {
            return Commands.ContainsKey(name);
        }

        public CommandBase Get(string name)
        {
            return Commands[name];
        }

        private void Set(string name, CommandBase command)
        {
            command.Interpreter = Interpreter;
            command.Environment = Environment;
            Commands[name] = command;
        }
    }
}
