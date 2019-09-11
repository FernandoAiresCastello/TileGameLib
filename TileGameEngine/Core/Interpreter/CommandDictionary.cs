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
using Environment = TileGameEngine.Core.RuntimeEnvironment.Environment;

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
            Set("SYSTEM.SPEED.SET", new SpeedSetCommand());

            // MATH
            Set("MATH.INCREMENT", new IncrementCommand());
            Set("MATH.DECREMENT", new DecrementCommand());
            Set("MATH.ADD", new AddCommand());
            Set("MATH.SUBTRACT", new SubtractCommand());
            Set("MATH.COMPARE", new CompareCommand());
            Set("MATH.MULTIPLY", new MultiplyCommand());
            Set("MATH.DIVIDE", new DivideCommand());
            Set("MATH.MODULO", new ModuloCommand());
            Set("MATH.SQRT", new SquareRootCommand());
            Set("MATH.POWER", new PowerCommand());
            Set("MATH.RANDOM", new RandomCommand());

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
            Set("WINDOW.KEY.PRESSED", new KeyPressedCommand());
            Set("WINDOW.BG.SET", new WindowBgSetCommand());
            Set("WINDOW.BG.GET", new WindowBgGetCommand());
            Set("WINDOW.CURSOR.X.SET", new WindowCursorXSetCommand());
            Set("WINDOW.CURSOR.X.GET", new WindowCursorXGetCommand());
            Set("WINDOW.CURSOR.Y.SET", new WindowCursorYSetCommand());
            Set("WINDOW.CURSOR.Y.GET", new WindowCursorYGetCommand());
            Set("WINDOW.CURSOR.MOVE", new WindowCursorMoveCommand());
            Set("WINDOW.CURSOR.UP", new WindowCursorMoveUpCommand());
            Set("WINDOW.CURSOR.DOWN", new WindowCursorMoveDownCommand());
            Set("WINDOW.CURSOR.RIGHT", new WindowCursorMoveRightCommand());
            Set("WINDOW.CURSOR.LEFT", new WindowCursorMoveLeftCommand());
            Set("WINDOW.TILE.IX.SET", new TileIxSetCommand());
            Set("WINDOW.TILE.IX.GET", new TileIxGetCommand());
            Set("WINDOW.TILE.FG.SET", new TileFgSetCommand());
            Set("WINDOW.TILE.FG.GET", new TileFgGetCommand());
            Set("WINDOW.TILE.BG.SET", new TileBgSetCommand());
            Set("WINDOW.TILE.BG.GET", new TileBgGetCommand());
            Set("WINDOW.PRINT", new PrintCommand());

            // MAP VIEW
            Set("MAPVIEW.X.SET", new MapViewXSetCommand());
            Set("MAPVIEW.Y.SET", new MapViewYSetCommand());
            Set("MAPVIEW.WIDTH.SET", new MapViewWidthSetCommand());
            Set("MAPVIEW.HEIGHT.SET", new MapViewHeightSetCommand());
            Set("MAPVIEW.SCROLL.X.SET", new MapViewScrollXSetCommand());
            Set("MAPVIEW.SCROLL.Y.SET", new MapViewScrollYSetCommand());
            
            // MAP
            Set("MAP.LOAD", new MapLoadCommand());
            Set("MAP.FILE.GET", new MapFileGetCommand());
            Set("MAP.WIDTH.GET", new MapWidthGetCommand());
            Set("MAP.HEIGHT.GET", new MapHeightGetCommand());
            Set("MAP.SHOW", new MapShowCommand());
            Set("MAP.HIDE", new MapHideCommand());
            Set("MAP.NAME.SET", new MapNameSetCommand());
            Set("MAP.NAME.GET", new MapNameGetCommand());
            Set("MAP.BG.SET", new MapBgSetCommand());
            Set("MAP.PALETTE.SET", new MapPaletteSetCommand());
            Set("MAP.TILESET.SET", new MapTilesetSetCommand());
            Set("MAP.CURSOR.MOVE", new MapCursorMoveCommand());
            Set("MAP.CURSOR.LAYER.SET", new MapCursorLayerSetCommand());
            Set("MAP.CURSOR.X.SET", new MapCursorXSetCommand());
            Set("MAP.CURSOR.Y.SET", new MapCursorYSetCommand());
            Set("MAP.CURSOR.RIGHT", new MapCursorMoveRightCommand());
            Set("MAP.CURSOR.LEFT", new MapCursorMoveLeftCommand());
            Set("MAP.CURSOR.UP", new MapCursorMoveUpCommand());
            Set("MAP.CURSOR.DOWN", new MapCursorMoveDownCommand());
            Set("MAP.CURSOR.IS_VALID", new MapCursorIsValidCommand());

            // OBJECT
            Set("OBJ.CREATE", new ObjectCreateCommand());
            Set("OBJ.EXISTS", new ObjectExistsCommand());
            Set("OBJ.COPY", new ObjectCopyCommand());
            Set("OBJ.MOVE", new ObjectMoveCommand());
            Set("OBJ.UP", new ObjectMoveUpCommand());
            Set("OBJ.DOWN", new ObjectMoveDownCommand());
            Set("OBJ.RIGHT", new ObjectMoveRightCommand());
            Set("OBJ.LEFT", new ObjectMoveLeftCommand());
            Set("OBJ.SWAP", new ObjectSwapCommand());
            Set("OBJ.DELETE", new ObjectDeleteCommand());
            Set("OBJ.TAG.SET", new ObjectTagSetCommand());
            Set("OBJ.TAG.GET", new ObjectTagGetCommand());
            Set("OBJ.PROP.SET", new ObjectPropertySetCommand());
            Set("OBJ.PROP.GET", new ObjectPropertyGetCommand());
            Set("OBJ.PROP.EXISTS", new ObjectPropertyExistsCommand());
            Set("OBJ.TILE.IX.SET", new ObjectTileIxSetCommand());
            Set("OBJ.TILE.IX.GET", new ObjectTileIxGetCommand());
            Set("OBJ.TILE.FG.SET", new ObjectTileFgSetCommand());
            Set("OBJ.TILE.FG.GET", new ObjectTileFgGetCommand());
            Set("OBJ.TILE.BG.SET", new ObjectTileBgSetCommand());
            Set("OBJ.TILE.BG.GET", new ObjectTileBgGetCommand());
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
