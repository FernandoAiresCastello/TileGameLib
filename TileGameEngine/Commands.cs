using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine
{
    public class Commands
    {
        private readonly Dictionary<string, Action> CommandMap;
        private readonly ExecutionEnvironment Env;

        public Commands(ExecutionEnvironment env)
        {
            Env = env;
            CommandMap = new Dictionary<string, Action>();
            InitCommandMap();
        }

        public void Execute(string command)
        {
            if (CommandMap.ContainsKey(command))
                CommandMap[command]();
            else
                throw new Exception($"Invalid command: {command}");
        }

        private void InitCommandMap()
        {
            CommandMap["NOP"] = Nop;
        }

        private void Nop()
        {
        }
    }
}
