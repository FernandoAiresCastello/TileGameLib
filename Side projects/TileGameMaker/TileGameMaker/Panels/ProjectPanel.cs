using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.File;
using TileGameMaker.MapEditorElements;
using TileGameLib.GameElements;
using TileGameLib.Util;
using TileGameMaker.Util;

namespace TileGameMaker.Panels
{
    public partial class ProjectPanel : UserControl
    {
        private MapEditor Editor;
        private Project Project;

        private ProjectPanel()
        {
            InitializeComponent();
        }

        public ProjectPanel(MapEditor editor)
        {
            InitializeComponent();
            MapListGrid.DoubleClick += MapListGrid_DoubleClick;
            Editor = editor;
            Project = editor.Project;
            UpdateMapList();
        }

        private void MapListGrid_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedMap();
        }

        public void UpdateMapList()
        {
            ObjectMap selectedMap = GetSelectedMap();

            MapListGrid.Rows.Clear();

            foreach (ObjectMap projectMap in Project.Maps)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = projectMap;
                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = projectMap.Name;
                DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
                idCell.Value = projectMap.Id;

                row.Cells.Add(nameCell);
                row.Cells.Add(idCell);

                MapListGrid.Rows.Add(row);

                foreach (DataGridViewRow currentRow in MapListGrid.Rows)
                    foreach (DataGridViewCell currentCell in currentRow.Cells)
                        currentCell.Tag = projectMap;
            }

            Select(selectedMap);
            if (GetSelectedMap() == null)
                Select(Editor.Map);
        }

        public void Select(ObjectMap map)
        {
            if (map != null)
            {
                foreach (DataGridViewRow row in MapListGrid.Rows)
                {
                    ObjectMap current = (ObjectMap)row.Tag;
                    row.Selected = false;

                    if (current == map)
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                MapListGrid.ClearSelection();
            }
        }

        private ObjectMap GetSelectedMap()
        {
            if (MapListGrid.SelectedRows.Count == 0)
                return null;

            return (ObjectMap)MapListGrid.SelectedRows[0].Tag;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Project.AddBlankMap(Config.ReadInt("DefaultMapWidth"), Config.ReadInt("DefaultMapHeight"));
            UpdateMapList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Project.Maps.Count > 1)
            {
                ObjectMap selectedMap = GetSelectedMap();

                if (selectedMap == Editor.Map)
                {
                    Alert.Warning("Can't delete, this map is currently open");
                }
                else
                {
                    if (Alert.Confirm("Delete map " + selectedMap.Name + " with id " + selectedMap.Id + "?"))
                    {
                        Project.DeleteMap(selectedMap);
                        UpdateMapList();
                    }
                }
            }
            else
            {
                Alert.Warning("Can't delete, the project must have at least one map");
            }
        }

        private void BtnDuplicate_Click(object sender, EventArgs e)
        {
            ObjectMap original = GetSelectedMap();
            ObjectMap duplicate = new ObjectMap(original);
            duplicate.GenerateId();
            duplicate.Name = "Copy of " + original.Id;
            Project.Maps.Add(duplicate);
            UpdateMapList();
        }

        private void OpenSelectedMap()
        {
            Editor.SetMap(GetSelectedMap());
            Editor.MapEditorControl.ResetViewScroll();
        }
    }
}
