using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.Exceptions;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;

namespace TileGameLib.Engine
{
    public class UserInterface
    {
        public int BackColor { set; get; } = 0;
        public MapRenderer MapRenderer { get; private set; }
        public List<UserInterfaceMessage> ModalMessages { get; private set; } = new List<UserInterfaceMessage>();
        public List<UserInterfaceMessage> TimedMessages { get; private set; } = new List<UserInterfaceMessage>();
        public TextInput TextInput { get; private set; }

        public TileGraphicsDriver Graphics => Display.Graphics;
        public bool MapVisible => MapRenderer != null && MapRenderer.AutoRefresh;
        public bool HasTimedMessage => TimedMessages.Count > 0;
        public bool HasModalMessage => ModalMessages.Count > 0 && ModalMessagePage < ModalMessages.Count;
        public UserInterfaceMessage CurrentModalMessage => ModalMessages[ModalMessagePage];

        private readonly TiledDisplay Display;
        private readonly Timer MessageTimer;
        private int ModalMessagePage = 0;
        private ObjectMap UiMap;
        private Palette OriginalPalette;
        private Tileset OriginalTileset;

        public Dictionary<string, UserInterfacePlaceholder>
            Placeholders { get; private set; } = new Dictionary<string, UserInterfacePlaceholder>();

        public UserInterface(TiledDisplay display)
        {
            Display = display;
            MapRenderer = new MapRenderer(display);
            TextInput = new TextInput(this);

            MessageTimer = new Timer();
            MessageTimer.Tick += MessageTimer_Tick;
        }

        public void LoadUiMap(string uiMapFile)
        {
            UiMap = MapFile.LoadFromRawBytes(uiMapFile);

            if (UiMap.Width != Display.Cols || UiMap.Height != Display.Rows)
                throw new TileGameLibException("UI map must be exactly the same dimensions as the window");
            if (UiMap.Layers.Count != 1)
                throw new TileGameLibException("UI map must have exactly 1 layer");

            BackColor = UiMap.BackColor;
            FindPlaceholders();
        }

        public void Clear()
        {
            PreserveOriginalTilesetAndPalette();
            Graphics.Clear(BackColor);
            RestoreOriginalTilesetAndPalette();
        }

        public void ClearRect(Rectangle rect)
        {
            PreserveOriginalTilesetAndPalette();
            Graphics.ClearRect(BackColor, rect.X, rect.Y, rect.Width, rect.Height);
            RestoreOriginalTilesetAndPalette();
        }

        public void SetPlaceholderVisible(string placeholder, bool visible)
        {
            UserInterfacePlaceholder ph = Placeholders[placeholder];
            GameObject indicator = UiMap.GetObject(ph.Position);

            if (indicator != null)
                indicator.Visible = visible;
        }

        public void Print(object obj, string placeholder, int offsetX = 0, int offsetY = 0)
        {
            UserInterfacePlaceholder ph = Placeholders[placeholder];
            Print(obj.ToString(), ph.Position.X + offsetX, ph.Position.Y + offsetY, ph.Tile.ForeColor, ph.Tile.BackColor);
        }

        public void Print(object obj, int x, int y, int foreColorIx, int backColorIx)
        {
            if (UiMap == null)
                return;

            string[] lines = obj.ToString().Split('\n');

            foreach (string line in lines)
                Graphics.PutString(x, y++, line, foreColorIx, backColorIx);
        }

        public void ClearTimedMessage()
        {
            TimedMessages.Clear();
            MessageTimer.Stop();
        }

        public void ClearModalMessage()
        {
            ModalMessagePage = 0;
            ModalMessages.Clear();
        }

        public void SetTimedMessage(string placeholder, string message, int duration)
        {
            ClearTimedMessage();
            ClearModalMessage();
            
            UserInterfacePlaceholder ph = Placeholders[placeholder].Copy();
            UserInterfacePlaceholder currentPlaceholder = new UserInterfacePlaceholder(ph);
            TimedMessages.Add(new UserInterfaceMessage(this, currentPlaceholder, message));

            MessageTimer.Stop();
            MessageTimer.Interval = duration;
            MessageTimer.Start();
        }

        public void SetModalMessage(string placeholder, params string[] messages)
        {
            ClearTimedMessage();
            ClearModalMessage();

            foreach (string message in messages)
            {
                UserInterfacePlaceholder ph = Placeholders[placeholder].Copy();
                ModalMessages.Add(new UserInterfaceMessage(this, new UserInterfacePlaceholder(ph), message));
            }
        }

        public void NextModalMessagePage()
        {
            if (ModalMessagePage >= ModalMessages.Count)
                ClearModalMessage();
            else
                ModalMessagePage++;
        }

        public void Draw()
        {
            if (UiMap == null)
                return;

            PreserveOriginalTilesetAndPalette();
            Graphics.Clear(BackColor);

            ObjectLayer layer = UiMap.Layers[0];

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    GameObject o = layer.GetObject(x, y);
                    if (o != null && o.Visible)
                        Graphics.PutTile(x, y, o.Animation.FirstFrame);
                }
            }

            foreach (UserInterfaceMessage message in TimedMessages)
                message.Draw();

            if (TextInput.IsActive)
                DrawInput();

            RestoreOriginalTilesetAndPalette();
        }

        private void DrawInput()
        {
            int x = TextInput.InputPlaceholderStart.Position.X;
            int y = TextInput.InputPlaceholderStart.Position.Y;
            int fgc = TextInput.InputPlaceholderStart.Tile.ForeColor;
            int bgc = TextInput.InputPlaceholderStart.Tile.BackColor;

            if (TextInput.InputPrompt != null)
            {
                Graphics.PutString(TextInput.InputPlaceholderPrompt.Position.X, TextInput.InputPlaceholderPrompt.Position.Y,
                    TextInput.InputPrompt, TextInput.InputPlaceholderPrompt.Tile.ForeColor, TextInput.InputPlaceholderPrompt.Tile.BackColor);
            }

            for (int i = 0; i < TextInput.InputString.Length; i++)
            {
                char ch = TextInput.InputString[i];
                if (x > TextInput.InputPlaceholderEnd.Position.X)
                    break;

                if (i == TextInput.InputCursor)
                    Graphics.PutTile(x, y, ch, bgc, fgc);
                else
                    Graphics.PutTile(x, y, ch, fgc, bgc);

                x++;
            }
        }

        public void DrawMap()
        {
            MapRenderer.Render();
        }

        public void SetMapViewport(int x, int y, int width, int height)
        {
            MapRenderer.Viewport = new Rectangle(x, y, width, height);
        }

        public void SetMapViewport(string topLeftplaceholder, string bottomRightplaceholder)
        {
            UserInterfacePlaceholder topLeft = Placeholders[topLeftplaceholder];
            UserInterfacePlaceholder bottomRight = Placeholders[bottomRightplaceholder];

            SetMapViewport(topLeft.Position.X, topLeft.Position.Y, 
                bottomRight.Position.X - topLeft.Position.X + 1, 
                bottomRight.Position.Y - topLeft.Position.Y + 1);
        }

        public void SetGameMap(ObjectMap map)
        {
            MapRenderer.Map = map;
        }

        public void ClearMapViewport()
        {
            ClearRect(MapRenderer.Viewport);
        }

        public void ShowMap()
        {
            MapRenderer.AutoRefresh = true;
            DrawMap();
            Display.Refresh();
        }

        public void HideMap()
        {
            MapRenderer.AutoRefresh = false;
            ClearMapViewport();
            Display.Refresh();
        }

        public void StartMapAnimation()
        {
            MapRenderer.AnimationEnabled = true;
        }

        public void StopMapAnimation()
        {
            MapRenderer.AnimationEnabled = false;
        }

        private void MessageTimer_Tick(object sender, EventArgs e)
        {
            TimedMessages.Clear();
            MessageTimer.Stop();
        }

        private void PreserveOriginalTilesetAndPalette()
        {
            OriginalPalette = Graphics.Palette;
            OriginalTileset = Graphics.Tileset;

            if (UiMap != null)
            {
                Graphics.Tileset = UiMap.Tileset;
                Graphics.Palette = UiMap.Palette;
            }
        }

        private void RestoreOriginalTilesetAndPalette()
        {
            Graphics.Palette = OriginalPalette;
            Graphics.Tileset = OriginalTileset;
        }

        private void FindPlaceholders()
        {
            if (UiMap == null)
                return;

            ObjectLayer layer = UiMap.Layers[0];

            for (int y = 0; y < layer.Height; y++)
            {
                for (int x = 0; x < layer.Width; x++)
                {
                    GameObject o = layer.GetObject(x, y);

                    if (o != null && o.HasTag)
                    {
                        bool isDuplicate = Placeholders.TryGetValue(o.Tag, out UserInterfacePlaceholder ph);
                        if (isDuplicate)
                            throw new TileGameLibException("Duplicate placeholder " + o.Tag + " in UI map");

                        Placeholders[o.Tag] = new UserInterfacePlaceholder(o.Animation.FirstFrame, x, y);
                    }
                }
            }
        }
    }
}
