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
        private ExecutionEnvironment Environment;
        private Timer CycleTimer;
        
        public long Cycle { get; private set; }

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
                Project.EngineWindowCols, Project.EngineWindowRows, Project.EngineWindowMagnification,
                Project.EngineWindowWidth, Project.EngineWindowHeight, 1);

            Window.FormClosed += Window_FormClosed;

            Cycle = 0;
            CycleTimer = new Timer();
            CycleTimer.Interval = 1;
            CycleTimer.Tick += (sender, args) => Cycle++;

            Environment = new ExecutionEnvironment(this, Project, Window);
            Interpreter = new Interpreter(this, Environment);
            Interpreter.Start();
            CycleTimer.Start();

            Application.Run(Window);
        }

        private void Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            Interpreter.Exit();
        }

        public void Error(string msg)
        {
            Alert.Error(msg);
            Interpreter.Exit();
            CycleTimer.Stop();
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
