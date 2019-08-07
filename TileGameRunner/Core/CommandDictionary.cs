using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameRunner.Commands;

namespace TileGameRunner.Core
{
    public class CommandDictionary
    {
        private readonly Dictionary<string, CommandBase> Commands = new Dictionary<string, CommandBase>();
        private readonly Interpreter Interpreter;
        private readonly Environment Environment;

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

        private void InitializeCommands()
        {
            Set("NOP", new NopCommand());
            Set("PROJECT", new ProjectCommand());
            Set("EXIT", new ExitCommand());
            Set("JP", new JumpCommand());
            Set("JZ", new JumpZeroCommand());
            Set("JNZ", new JumpNotZeroCommand());
            Set("CALL", new CallCommand());
            Set("CALLZ", new CallZeroCommand());
            Set("CALLNZ", new CallNotZeroCommand());
            Set("RET", new ReturnCommand());
            Set("PUSH", new PushCommand());
            Set("STORE", new StoreCommand());
            Set("LOAD", new LoadCommand());
            Set("INC", new IncrementCommand());
            Set("DEC", new DecrementCommand());
            Set("CMP", new CompareCommand());
            Set("WINDOW", new WindowCommand());
            Set("MAPLOAD", new MapLoadCommand());
            Set("PRINT", new PrintCommand());
        }
    }
}
