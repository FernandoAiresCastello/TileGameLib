using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.GameElements;
using TileGameMaker.MapEditor;

namespace TileGameMaker.Panels
{
    public partial class ObjectPropertyGridPanel : UserControl
    {
        public ObjectProperties Properties => GetProperties();

        public ObjectPropertyGridPanel()
        {
            InitializeComponent();

            Grid.Columns.Add("property", "Property");
            Grid.Columns.Add("value", "Value");
        }

        public void UpdateProperties(GameObject o)
        {
            Grid.Rows.Clear();

            if (o != null)
            {
                foreach (var prop in o.Properties.Entries)
                    Grid.Rows.Add(prop.Key, prop.Value);

                Refresh();
            }
        }

        public ObjectProperties GetProperties()
        {
            ObjectProperties properties = new ObjectProperties();

            foreach (DataGridViewRow row in Grid.Rows)
            {
                object objProperty = row.Cells["property"].Value;
                object objValue = row.Cells["value"].Value ?? "";

                if (objProperty != null && !string.IsNullOrWhiteSpace(objProperty.ToString()))
                    properties.Set(objProperty.ToString(), objValue.ToString());
            }

            return properties;
        }

        private void Grid_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
