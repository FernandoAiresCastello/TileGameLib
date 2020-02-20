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

namespace TileGameMaker.Windows
{
    public partial class ObjectPropertiesEditWindow : Form
    {
        public string ObjectTag => TxtTag.Text.Trim();
        public bool ObjectVisible => ChkVisible.Checked;
        public PropertyList ObjectProperties { set; get; }

        public ObjectPropertiesEditWindow()
        {
            InitializeComponent();
            Text = "Enter object data";
            ObjectProperties = new PropertyList();
        }

        public DialogResult ShowDialog(Control parent, GameObject o, ObjectPosition position)
        {
            TxtPosition.Text = $"Layer:{position.Layer} X:{position.X} Y:{position.Y}";
            TxtPosition.Select(0, 0);
            TxtTag.Text = o.Tag;
            ChkVisible.Checked = o.Visible;
            TxtTag.Select(0, 0);
            ObjectProperties.SetEqual(o.Properties);
            PropertyGrid.UpdateProperties(o);
            
            return ShowDialog(parent);
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ObjectProperties.SetEqual(PropertyGrid.Properties);
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
