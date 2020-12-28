using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameLib.Util;

namespace TileGameEngine
{
    public class GameEngine
    {
        private const string DefaultGameFile = "game.tgpro";

        private Project Project;
        private GameWindow Window;
        private Interpreter Interpreter;
        private Environment Environment;

        public GameEngine()
        {
        }

        public void Start()
        {
            Start(DefaultGameFile);
        }

        public void Start(string gameFile)
        {
            if (!File.Exists(gameFile))
            {
                Alert.Error($"Game file \"{gameFile}\" not found");
                Application.Exit();
                return;
            }

            Project = new Project();
            Project.Load(gameFile);

            Window = new GameWindow(this, 
                Project.EngineWindowCols, Project.EngineWindowRows, Project.EngineWindowMagnification);

            Application.Run(Window);

            Environment = new Environment(Project, Window);
            Interpreter = new Interpreter(Environment);
            Interpreter.Start();
        }

        public void HandleKeyDownEvent(KeyEventArgs e)
        {
        }

        public void HandleKeyUpEvent(KeyEventArgs e)
        {
        }

        public void HandleMouseDownEvent(MouseEventArgs e)
        {
        }
    }
}
