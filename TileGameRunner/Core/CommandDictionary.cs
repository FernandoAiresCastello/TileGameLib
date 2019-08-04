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
            Add("PUSH", new CommandBase());
            Add("LOAD", new CommandBase());
            Add("STORE", new CommandBase());
            Add("CMP", new CommandBase());
            Add("INC", new CommandBase());
            Add("DEC", new CommandBase());
            Add("CALL", new CallCommand());
            Add("CALLZ", new CommandBase());
            Add("CALLNZ", new CommandBase());
            Add("RET", new ReturnCommand());
            Add("JP", new JumpCommand());
            Add("JZ", new CommandBase());
            Add("JNZ", new CommandBase());
            Add("INKEY", new CommandBase());
            Add("MAPVIEW", new CommandBase());
            Add("MAPRENDER", new CommandBase());
        }
    }
}
