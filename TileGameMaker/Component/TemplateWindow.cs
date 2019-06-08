using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Core;
using TileGameLib.Graphics;
using TileGameMaker.Modules;

namespace TileGameMaker.Component
{
    public partial class TemplateWindow : Form
    {
        public GameObject Object { set; get; }
        public AnimationStrip AnimationStrip { set; get; }
        public ObjectAnim Animation { get { return AnimationStrip.Animation; } }

        public ObjectAnim CroppedAnimation
        {
            get
            {
                return AnimationStrip.Animation.CopyFrames(AnimationFrameCount);
            }
        }

        public int AnimationFrameCount
        {
            get
            {
                int.TryParse(TxtFrames.Text, out int frames);
                return frames;
            }

            set
            {
                TxtFrames.Text = value.ToString();
                Refresh();
            }
        }

        private MapEditor MapEditor;
        private readonly int MaxFrames = 13;

        public TemplateWindow(MapEditor editor)
        {
            InitializeComponent();

            MapEditor = editor;
            Object = new GameObject();
            AnimationStrip = new AnimationStrip(AnimationPanel, MaxFrames, 1, 3);
            AnimationStrip.Graphics.Tileset = editor.Map.Tileset;
            AnimationStrip.Graphics.Palette = editor.Map.Palette;
            AnimationStrip.MouseDown += AnimationStrip_MouseDown;
            TxtFrames.Text = 1.ToString();
            Shown += TemplateWindow_Shown;
        }

        private void TemplateWindow_Shown(object sender, EventArgs e)
        {
            Refresh();
        }

        public override void Refresh()
        {
            base.Refresh();
            TxtType.Text = Object.Type.ToString();
            TxtParam.Text = Object.Param.ToString();
            TxtData.Text = Object.Data;
        }

        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtType.Text, out int type);
            int.TryParse(TxtParam.Text, out int param);

            Object.Type = type;
            Object.Param = param;
            Object.Data = TxtData.Text;
        }

        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtFrames_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TxtFrames.Text, out int frames);
            if (frames <= 0)
                TxtFrames.Text = 1.ToString();
            else if (frames > MaxFrames)
                TxtFrames.Text = MaxFrames.ToString();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Object.SetNull();
            AnimationStrip.Clear();
            TxtFrames.Text = 1.ToString();
            Refresh();
        }

        private void AnimationStrip_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = AnimationStrip.GetMouseToCellPos(e.Location);
            Animation.SetFrame(p.X, MapEditor.GetSelectedTile());
            AnimationStrip.Refresh();
        }

        public void UpdateAnimation(ObjectAnim anim)
        {
            Animation.SetEqual(anim);
            AnimationFrameCount = anim.Size;

            while (Animation.Size < MaxFrames)
                Animation.AddFrame(new Tile(0, 0, AnimationStrip.Graphics.Palette.Size - 1));
        }
    }
}
