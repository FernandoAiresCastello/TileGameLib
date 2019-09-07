using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Commands;
using TileGameEngine.Commands.ControlFlow;
using TileGameEngine.Commands.LogicalOperators;
using TileGameEngine.Commands.Map;
using TileGameEngine.Commands.MapView;
using TileGameEngine.Commands.Math;
using TileGameEngine.Commands.Misc;
using TileGameEngine.Commands.NumericConversions;
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
            Set("DUP", new DuplicateCommand());

            // LOGICAL OPERATORS
            Set("AND", new LogicalAndCommand());
            Set("OR", new LogicalOrCommand());
            Set("XOR", new LogicalXorCommand());
            Set("NOT", new LogicalNotCommand());

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

            // CONVERT
            Set("CONVERT.BYTE", new ConvertToByteCommand());

            // STRING
            Set("STRING.FORMAT", new FormatCommand());
            Set("STRING.CONCAT", new ConcatCommand());
            Set("STRING.JOIN", new JoinCommand());

            // WINDOW
            Set("WINDOW.OPEN", new OpenCommand());
            Set("WINDOW.CLEAR", new ClearCommand());
            Set("WINDOW.REFRESH", new RefreshCommand());
            Set("WINDOW.PALETTE.SET", new WindowPaletteSetCommand());
            Set("WINDOW.TILESET.SET", new WindowTilesetSetCommand());
            Set("WINDOW.PRINT", new PrintCommand());
            Set("WINDOW.KEY.PRESSED", new KeyPressedCommand());
            Set("WINDOW.BACKCOLOR.SET", new WindowBackColorSetCommand());

            Set("WINDOW.TILE.X.SET", new TileXSetCommand());
            Set("WINDOW.TILE.Y.SET", new TileYSetCommand());
            Set("WINDOW.TILE.FORECOLOR.SET", new TileForeColorSetCommand());
            Set("WINDOW.TILE.BACKCOLOR.SET", new TileBackColorSetCommand());

            // MAP VIEW
            Set("MAPVIEW.X.SET", new MapViewXSetCommand());
            Set("MAPVIEW.Y.SET", new MapViewYSetCommand());
            Set("MAPVIEW.WIDTH.SET", new MapViewWidthSetCommand());
            Set("MAPVIEW.HEIGHT.SET", new MapViewHeightSetCommand());
            Set("MAPVIEW.SCROLL.X.SET", new MapViewScrollXSetCommand());
            Set("MAPVIEW.SCROLL.Y.SET", new MapViewScrollYSetCommand());
            
            // MAP
            Set("MAP.LOAD", new MapLoadCommand());
            Set("MAP.FILE.GET", new CommandBase());
            Set("MAP.SHOW", new MapShowCommand());
            Set("MAP.HIDE", new MapHideCommand());
            Set("MAP.NAME.SET", new MapNameSetCommand());
            Set("MAP.NAME.GET", new MapNameGetCommand());
            Set("MAP.BACKCOLOR.SET", new MapBackColorSetCommand());
            Set("MAP.PALETTE.SET", new MapPaletteSetCommand());
            Set("MAP.TILESET.SET", new MapTilesetSetCommand());
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
