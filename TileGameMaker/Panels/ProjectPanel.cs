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

            TxtProjectName.Click += TxtProjectName_Click;
            TxtProjectName.LostFocus += TxtProjectName_LostFocus;
            TxtProjectName.TextChanged += TxtProjectName_TextChanged;
            MapListGrid.DoubleClick += MapListGrid_DoubleClick;

            Editor = editor;
            Project = editor.Project;
            TxtProjectName.Text = Project.Name;

            UpdateMapList();
        }

        private void TxtProjectName_LostFocus(object sender, EventArgs e)
        {
            TxtProjectName.Text = Project.Name;
        }

        private void TxtProjectName_Click(object sender, EventArgs e)
        {
            TxtProjectName.SelectAll();
        }

        private void TxtProjectName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtProjectName.Text))
                TxtProjectName.Text = Project.Name;
            else
                Project.Name = TxtProjectName.Text.Trim();
        }

        private void MapListGrid_DoubleClick(object sender, EventArgs e)
        {
            OpenSelectedMap();
        }

        public void UpdateMapList()
        {
            ObjectMap selectedMap = GetSelectedMap();

            MapListGrid.Rows.Clear();

            foreach (ObjectMap map in Project.Maps)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = map;
                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = map.Name;
                DataGridViewTextBoxCell idCell = new DataGridViewTextBoxCell();
                idCell.Value = map.Id;

                row.Cells.Add(nameCell);
                row.Cells.Add(idCell);

                MapListGrid.Rows.Add(row);

                foreach (DataGridViewRow currentRow in MapListGrid.Rows)
                    foreach (DataGridViewCell currentCell in currentRow.Cells)
                        currentCell.Tag = map;
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
            Project.AddBlankMap();
            UpdateMapList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (Project.Maps.Count > 1)
            {
                ObjectMap map = GetSelectedMap();

                if (map == Editor.Map)
                {
                    Alert.Warning("Can't delete, this map is currently open");
                }
                else
                {
                    if (Alert.Confirm("Delete map " + map.Name + " with id " + map.Id + "?"))
                    {
                        Project.DeleteMap(map);
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
            Project.Save();
            Editor.SetMap(GetSelectedMap());
        }
    }
}
