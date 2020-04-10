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
using TileGameMaker.MapEditorElements;

namespace TileGameMaker.Windows
{
    public partial class ObjectEditWindow : Form
    {
        public GameObject EditedObject => NewData.Object;

        private readonly PositionedObject OriginalData;
        private PositionedObject NewData;

        private ObjectEditWindow()
        {
            InitializeComponent();
        }

        public ObjectEditWindow(MapEditor editor, PositionedObject po, ObjectMap map, ObjectPosition pos)
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += ObjectEditWindow_KeyDown;

            if (po.Object == null)
            {
                Text = "Set new object";
                po.Object = new GameObject(editor.SelectedTile);
            }
            else
            {
                Text = "Edit object";
            }

            OriginalData = po;
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
            ObjectPosition position = OriginalData.Position;
            TxtPosition.Text = $"Layer:{position.Layer} X:{position.X} Y:{position.Y}";
            TxtPosition.Select(0, 0);

            NewData = OriginalData.Copy();
            NewData.Object.Id = OriginalData.Object.Id;

            UpdateInterface();

            return base.ShowDialog(parent);
        }

        private void UpdateInterface()
        {
            ChkVisible.Checked = NewData.Object.Visible;
            PropertyGrid.UpdateProperties(NewData.Object);
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            NewData.Object.Visible = ChkVisible.Checked;
            NewData.Object.Properties = PropertyGrid.Properties;
            Close();
        }

        private void BtnRevert_Click(object sender, EventArgs e)
        {
            NewData.Object = OriginalData.Object.Copy();
            NewData.Object.Id = OriginalData.Object.Id;
            UpdateInterface();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            NewData.Object.Visible = true;
            NewData.Object.Properties.RemoveAll();
            NewData.Object.Id = OriginalData.Object.Id;
            UpdateInterface();
        }
    }
}
