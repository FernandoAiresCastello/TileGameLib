using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Panels;
using TileGameMaker.TiledDisplays;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class ObjectEditWindow : Form
    {
        public GameObject EditedObject
        {
            get
            {
                if (NewData != null)
                    return NewData.Object;
                else if (NewObject != null)
                    return NewObject;
                else
                    return null;
            }
        }

        public ObjectAnimation Animation => AnimationStrip.Animation;

        private readonly MapEditor Editor;
        private readonly PositionedObject OriginalData;
        private PositionedObject NewData;
        private readonly GameObject OriginalObject;
        private GameObject NewObject;
        private readonly AnimationStripDisplay AnimationStrip;
        private const int MaxFrames = 8;
        private readonly bool IsNewObject;

        private ObjectEditWindow()
        {
            InitializeComponent();
        }

        public ObjectEditWindow(MapEditor editor, GameObject o)
        {
            InitializeComponent();
            Editor = editor;
            KeyPreview = true;
            KeyDown += ObjectEditWindow_KeyDown;
            IsNewObject = o == null;

            if (o == null)
                o = editor.BlankObject;

            OriginalObject = o;

            AnimationStrip = new AnimationStripDisplay(AnimationPanel,
                MaxFrames, 1, 3, Editor.BlankObject.Animation.FirstFrame);

            AnimationStrip.Graphics.Tileset = editor.Map.Tileset;
            AnimationStrip.Graphics.Palette = editor.Map.Palette;

            TxtFrames.Minimum = 1;
            TxtFrames.Maximum = MaxFrames;
            TxtFrames.ValueChanged += TxtFrames_ValueChanged;

            AnimationStrip.MouseDown += AnimationStrip_MouseDown;
        }

        public ObjectEditWindow(MapEditor editor, PositionedObject po, ObjectMap map, ObjectPosition pos)
        {
            InitializeComponent();
            Editor = editor;
            KeyPreview = true;
            KeyDown += ObjectEditWindow_KeyDown;

            IsNewObject = po.Object == null;

            if (po.Object == null)
                po.Object = editor.BlankObject;

            OriginalData = po;
            OriginalObject = po.Object;

            AnimationStrip = new AnimationStripDisplay(AnimationPanel,
                MaxFrames, 1, 3, Editor.BlankObject.Animation.FirstFrame);

            AnimationStrip.Graphics.Tileset = editor.Map.Tileset;
            AnimationStrip.Graphics.Palette = editor.Map.Palette;

            TxtFrames.Minimum = 1;
            TxtFrames.Maximum = MaxFrames;
            TxtFrames.ValueChanged += TxtFrames_ValueChanged;

            AnimationStrip.MouseDown += AnimationStrip_MouseDown;
        }

        private void TxtFrames_ValueChanged(object sender, EventArgs e)
        {
            int frames = (int)TxtFrames.Value;

            if (frames < Animation.Size)
            {
                Animation.Frames.RemoveRange(frames, Animation.Size - frames);
                Refresh();
            }
        }

        private void AnimationStrip_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = AnimationStrip.GetMouseToCellPos(e.Location);

            if (e.Button == MouseButtons.Left)
                EditAnimationFrame(p.X);
            else if (e.Button == MouseButtons.Right)
                DuplicateAnimationFrame(p.X);
        }

        private void EditAnimationFrame(int frame)
        {
            TileSelectorWindow win = new TileSelectorWindow(Editor, 
                frame < Animation.Size ? Animation.Frames[frame] : null);

            if (win.ShowDialog(this) == DialogResult.OK)
            {
                if (frame >= Animation.Size)
                {
                    Animation.AddFrames(frame - Animation.Size + 1, Editor.BlankObject.Tile);
                    TxtFrames.Value = Animation.Size;
                }

                Animation.Frames[frame] = win.Tile;
                Refresh();
            }
        }

        private void DuplicateAnimationFrame(int frame)
        {
            if (frame < Animation.Size && Animation.Size <= MaxFrames - 1)
            {
                Animation.AddFrame(Animation.Frames[frame]);
                TxtFrames.Value = Animation.Size;
                Refresh();
            }
        }

        private void ObjectEditWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Close();
            }
        }

        public DialogResult ShowDialog(Control parent)
        {
            if (OriginalData != null)
            {
                ObjectPosition position = OriginalData.Position;

                Text = (IsNewObject ? "Create new object" : "Edit object") +
                    $" @ L{position.Layer} X{position.X} Y{position.Y}";

                NewData = new PositionedObject(OriginalData);
                NewData.Object.Id = OriginalData.Object.Id;
            }
            else if (OriginalObject != null)
            {
                Text = IsNewObject ? "Set out of bounds object" : "Edit out of bounds object";

                NewObject = new GameObject(OriginalObject);
                NewObject.Id = OriginalObject.Id;
            }

            UpdateInterface();

            return base.ShowDialog(parent);
        }

        private void UpdateInterface()
        {
            if (NewData != null)
            {
                ChkVisible.Checked = NewData.Object.Visible;
                PropertyGrid.UpdateProperties(NewData.Object);
                TxtFrames.Value = NewData.Object.Animation.Size;
                AnimationStrip.Animation = NewData.Object.Animation;
            }
            else if (NewObject != null)
            {
                ChkVisible.Checked = NewObject.Visible;
                PropertyGrid.UpdateProperties(NewObject);
                TxtFrames.Value = NewObject.Animation.Size;
                AnimationStrip.Animation = NewObject.Animation;
            }
            
            Refresh();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            int frames = (int)TxtFrames.Value;

            if (frames >= Animation.Size)
                Animation.AddFrames(frames - Animation.Size, Editor.BlankObject.Tile);
            else if (frames < Animation.Size)
                Animation.Frames.RemoveRange(frames, Animation.Size - frames);

            if (NewData != null)
            {
                NewData.Object.Animation = new ObjectAnimation(Animation);
                NewData.Object.Visible = ChkVisible.Checked;
                NewData.Object.Properties = PropertyGrid.Properties;
            }
            else if (NewObject != null)
            {
                NewObject.Animation = new ObjectAnimation(Animation);
                NewObject.Visible = ChkVisible.Checked;
                NewObject.Properties = PropertyGrid.Properties;
            }

            Close();
        }

        private void BtnRevert_Click(object sender, EventArgs e)
        {
            if (NewData != null)
            {
                NewData.Object = OriginalData.Object.Copy();
                NewData.Object.Id = OriginalData.Object.Id;
            }
            else if (NewObject != null)
            {
                NewObject = OriginalObject.Copy();
                NewObject.Id = OriginalObject.Id;
            }

            UpdateInterface();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            ClearObject();
            UpdateInterface();
        }

        private void BtnClearAnim_Click(object sender, EventArgs e)
        {
            ClearAnimation();
        }

        private void ClearObject()
        {
            if (NewData != null)
            {
                NewData.Object.Visible = true;
                NewData.Object.Properties.RemoveAll();
                NewData.Object.Id = OriginalData.Object.Id;
            }
            else if (NewObject != null)
            {
                NewObject.Visible = true;
                NewObject.Properties.RemoveAll();
                NewObject.Id = OriginalObject.Id;
            }

            ClearAnimation();
        }

        private void ClearAnimation()
        {
            if (NewData != null)
            {
                NewData.Object.Animation.Clear();
                NewData.Object.Animation.AddFrame(Editor.BlankObject.Tile);
                AnimationStrip.Animation = NewData.Object.Animation;
            }
            else if (NewObject != null)
            {
                NewObject.Animation.Clear();
                NewObject.Animation.AddFrame(Editor.BlankObject.Tile);
                AnimationStrip.Animation = NewObject.Animation;
            }

            AnimationStrip.Refresh();
            UpdateAnimationFrameCounter();
        }

        private void UpdateAnimationFrameCounter()
        {
            TxtFrames.Value = Animation.Size;
        }

        private void BtnSetEqualToClipboard_Click(object sender, EventArgs e)
        {
            if (NewData != null)
            {
                NewData.Object.SetEqual(Editor.GetClipboardObject());
                NewData.Object.Id = OriginalData.Object.Id;
            }
            else if (NewObject != null)
            {
                NewObject.SetEqual(Editor.GetClipboardObject());
                NewObject.Id = OriginalObject.Id;
            }

            UpdateInterface();
        }
    }
}
