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
            Set("WINDOW.BG.SET", new WindowBackColorSetCommand());
            Set("WINDOW.TILE.X.SET", new TileXSetCommand());
            Set("WINDOW.TILE.Y.SET", new TileYSetCommand());
            Set("WINDOW.TILE.FG.SET", new TileForeColorSetCommand());
            Set("WINDOW.TILE.BG.SET", new TileBackColorSetCommand());
            Set("WINDOW.TILE.PUT", new TilePutCommand());
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
            Set("MAP.FILE.GET", new CommandBase());
            Set("MAP.SHOW", new MapShowCommand());
            Set("MAP.HIDE", new MapHideCommand());
            Set("MAP.NAME.SET", new MapNameSetCommand());
            Set("MAP.NAME.GET", new MapNameGetCommand());
            Set("MAP.BG.SET", new MapBackColorSetCommand());
            Set("MAP.PALETTE.SET", new MapPaletteSetCommand());
            Set("MAP.TILESET.SET", new MapTilesetSetCommand());

            // OBJECT
            Set("OBJ.CREATE", new ObjectCreateCommand());
            Set("OBJ.EXISTS_ANY_AT", new ObjectAnyCommand());
            Set("OBJ.EXISTS_TAG_AT", new ObjectAtCommand());
            Set("OBJ.EXISTS_TAG", new ObjectExistsCommand());
            Set("OBJ.FIND_BY_TAG", new ObjectFindCommand());
            Set("OBJ.COPY", new ObjectCopyCommand());
            Set("OBJ.MOVE", new ObjectMoveCommand());
            Set("OBJ.MOVE_UP", new CommandBase());
            Set("OBJ.MOVE_DOWN", new CommandBase());
            Set("OBJ.MOVE_RIGHT", new CommandBase());
            Set("OBJ.MOVE_LEFT", new CommandBase());
            Set("OBJ.SWAP", new ObjectSwapCommand());
            Set("OBJ.DELETE", new ObjectDeleteCommand());
            Set("OBJ.ID.SET", new ObjectIdSetCommand());
            Set("OBJ.ID.GET", new CommandBase());
            Set("OBJ.TAG.SET", new ObjectTagSetCommand());
            Set("OBJ.TAG.GET", new CommandBase());
            Set("OBJ.PROP.SET", new ObjectPropertySetCommand());
            Set("OBJ.PROP.GET", new CommandBase());
            Set("OBJ.TILE.IX.SET", new ObjectTileIxSetCommand());
            Set("OBJ.TILE.IX.GET", new CommandBase());
            Set("OBJ.TILE.FG.SET", new ObjectTileFgSetCommand());
            Set("OBJ.TILE.FG.GET", new CommandBase());
            Set("OBJ.TILE.BG.SET", new ObjectTileBgSetCommand());
            Set("OBJ.TILE.BG.GET", new CommandBase());
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
