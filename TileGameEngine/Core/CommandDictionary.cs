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
using TileGameEngine.Commands.String;
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
            // MISC
            Set("NOP", new NopCommand());

            // CONTROL FLOW
            Set("JMP", new JumpCommand());
            Set("JZ", new JumpZeroCommand());
            Set("JNZ", new JumpNotZeroCommand());
            Set("CALL", new CallCommand());
            Set("CLZ", new CallZeroCommand());
            Set("CLNZ", new CallNotZeroCommand());
            Set("RET", new ReturnCommand());

            // STACK
            Set("PUSH", new PushCommand());
            Set("POP", new PopCommand());
            Set("STORE", new StoreCommand());
            Set("LOAD", new LoadCommand());

            // SYSTEM
            Set("SYSTEM.EXIT", new ExitCommand());
            Set("SYSTEM.SLEEP", new SleepCommand());
            Set("SYSTEM.LOG", new LogCommand());
            Set("SYSTEM.RESET", new ResetCommand());
            Set("SYSTEM.HALT", new HaltCommand());

            // MATH
            Set("MATH.INC", new IncrementCommand());
            Set("MATH.DEC", new DecrementCommand());
            Set("MATH.ADD", new AddCommand());
            Set("MATH.SUB", new SubtractCommand());
            Set("MATH.CMP", new CompareCommand());
            Set("MATH.MUL", new MultiplyCommand());
            Set("MATH.DIV", new DivideCommand());
            Set("MATH.MOD", new ModuloCommand());
            Set("MATH.SQRT", new SquareRootCommand());
            Set("MATH.POW", new PowerCommand());

            // STRING
            Set("STRING.FORMAT", new FormatCommand());
            Set("STRING.CONCAT", new ConcatCommand());
            Set("STRING.JOIN", new JoinCommand());

            // WINDOW
            Set("WINDOW.OPEN", new OpenCommand());
            Set("WINDOW.REFRESH", new RefreshCommand());
            Set("WINDOW.PRINT", new PrintCommand());

            // MAP
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
