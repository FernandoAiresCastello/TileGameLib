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

        private void Add(string name, CommandBase command)
        {
            command.Interpreter = Interpreter;
            command.Environment = Environment;
            Commands[name] = command;
        }

        private void InitializeCommands()
        {
            Add("EXIT", new ExitCommand());
            Add("PUSH", new PushCommand());
            Add("JP", new JumpCommand());
            Add("CALL", new CallCommand());
            Add("RET", new ReturnCommand());
            Add("STORE", new StoreCommand());
            Add("LOAD", new LoadCommand());
            Add("CMP", new CompareCommand());
            Add("INC", new IncrementCommand());
            Add("DEC", new DecrementCommand());
            Add("JZ", new JumpZeroCommand());
            Add("JNZ", new JumpNotZeroCommand());
            Add("CALLZ", new CallZeroCommand());
            Add("CALLNZ", new CallNotZeroCommand());
            Add("WINDOW", new WindowCommand());

            Add("MAPLOAD", new CommandBase());
            Add("MAPVIEW", new CommandBase());
            Add("MAPRENDER", new CommandBase());
            Add("INKEY", new CommandBase());
        }
    }
}
