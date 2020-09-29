using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameLib.GameElements;
using TileGameLib.Components;
using TileGameMaker.Windows;

namespace TileGameMaker.Panels
{
    public partial class GameObjectPanel : UserControl
    {
        public MapEditor MapEditor { get; set; }

        private TiledDisplay ClipboardDisplay;

        public GameObjectPanel() : this(null)
        {
        }

        public GameObjectPanel(MapEditor editor)
        {
            MapEditor = editor;
            InitializeComponent();
            ClipboardDisplay = new TiledDisplay(ClipboardPanel, 1, 1, 5);
            ClipboardDisplay.Graphics.Palette = editor.Palette;
            ClipboardDisplay.Graphics.Tileset = editor.Tileset;
            ClipboardDisplay.Click += ClipboardDisplay_Click;
        }

        private void ClipboardDisplay_Click(object sender, EventArgs e)
        {
            ObjectEditWindow win = new ObjectEditWindow(MapEditor, MapEditor.GetClipboardObject());
            if (win.ShowDialog(this, "Edit clipboard object") == DialogResult.OK)
            {
                MapEditor.CopyObjectToClipboard(win.EditedObject);
                UpdateClipboardView();
                Update();
            }
        }

        private void Clear(TextBox field)
        {
            field.Clear();
        }

        public void Clear()
        {
            ClearPointedToObjectView();
            ClearClipboardObjectView();
        }

        public void ClearPointedToObjectView()
        {
            Clear(TxtObject);
        }

        public void ClearClipboardObjectView()
        {
            Clear(TxtClipboard);
        }

        private void Print(TextBox field, string line = null)
        {
            if (line != null)
                field.AppendText(line + Environment.NewLine);
            else
                field.AppendText(Environment.NewLine);
        }

        public void Update(PositionedCell pc)
        {
            UpdatePointedToObjectView(pc);
            UpdateClipboardView();
            Update();
        }

        public void UpdateClipboardView()
        {
            ClearClipboardObjectView();

            GameObject clipboardObject = MapEditor.GetClipboardObject();

            if (clipboardObject != null)
            {
                ClipboardDisplay.Graphics.PutTile(0, 0, clipboardObject.Tile);
                ClipboardDisplay.Refresh();

                Print(TxtClipboard, $"[ClipboardObject]");
                Print(TxtClipboard, $"    Visible: {clipboardObject.Visible}");
                Print(TxtClipboard, $"    Frames: {clipboardObject.Animation.Size}");
                Print(TxtClipboard, $"    Properties: ");

                if (clipboardObject.Properties.Size > 0)
                {
                    foreach (KeyValuePair<string, string> prop in clipboardObject.Properties.Entries)
                        Print(TxtClipboard, $"        {prop.Key} = {prop.Value}");
                }
                else
                {
                    Print(TxtClipboard, $"        <empty>");
                }
            }
        }

        public void UpdatePointedToObjectView(PositionedCell pc)
        {
            ClearPointedToObjectView();

            GameObject o = pc.Cell.Object;
            ObjectPosition pos = pc.Position;

            Print(TxtObject, $"[Cell]");
            Print(TxtObject, $"    Layer: {pos.Layer}, X: {pos.X}, Y: {pos.Y}");

            if (o != null)
            {
                Print(TxtObject);
                Print(TxtObject, $"[Object]");
                Print(TxtObject, $"    ID: {o.Id}");
                Print(TxtObject, $"    Visible: {o.Visible}");
                Print(TxtObject, $"    Frames: {o.Animation.Size}");
                Print(TxtObject, $"    Properties: ");

                if (o.Properties.Size > 0)
                {
                    foreach (KeyValuePair<string, string> prop in o.Properties.Entries)
                        Print(TxtObject, $"        {prop.Key} = {prop.Value}");
                }
                else
                {
                    Print(TxtObject, $"        <empty>");
                }
            }
        }
    }
}
