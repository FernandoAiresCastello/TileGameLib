﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Commands;

namespace TileGameEngine.Core
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
            // Misc
            Set("NOP", new NopCommand());

            // Project
            Set("PRJLOAD", new ProjectLoadCommand());

            // Control flow
            Set("EXIT", new ExitCommand());
            Set("JP", new JumpCommand());
            Set("JZ", new JumpZeroCommand());
            Set("JNZ", new JumpNotZeroCommand());
            Set("CALL", new CallCommand());
            Set("CALLZ", new CallZeroCommand());
            Set("CALLNZ", new CallNotZeroCommand());
            Set("RET", new ReturnCommand());

            // Parameter stack
            Set("PUSH", new PushCommand());
            Set("STORE", new StoreCommand());
            Set("LOAD", new LoadCommand());

            // Arithmetic
            Set("INC", new IncrementCommand());
            Set("DEC", new DecrementCommand());
            Set("CMP", new CompareCommand());
            
            // Object map
            Set("MAPLOAD", new MapLoadCommand());

            // Graphics
            Set("WINDOW", new WindowCommand());
            Set("REFRESH", new RefreshCommand());
            Set("PRINT", new PrintCommand());
        }
    }
}
