using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.Util;

namespace TileGameEngine
{
    public class ExecutionEnvironment
    {
        private readonly GameEngine Engine;

        public Project Project { get; private set; }
        public GameWindow Window { get; private set; }

        public ExecutionEnvironment(GameEngine engine, Project project, GameWindow window)
        {
            Engine = engine;
            Project = project;
            Window = window;
        }

        public void ShowMessageBox(string msg)
        {
            Alert.Info(msg);
        }
    }
}
