using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Components;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameLib.Util;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Panels;
using TileGameMaker.Util;

namespace TileGameMaker.Windows
{
    public partial class TemplateObjectWindow : Form
    {
        private MainWindow MainWindow;
        private MapEditor MapEditor;
        private Project Project;
        private TiledDisplay Display;
        private MapRenderer MapRenderer;
        private ObjectMap TemplateMap;

        private TemplateObjectWindow()
        {
            InitializeComponent();
        }

        public TemplateObjectWindow(MainWindow mainWindow, MapEditor editor)
        {
            InitializeComponent();
            Icon = Global.WindowIcon;
            KeyPreview = true;
            MainWindow = mainWindow;
            MapEditor = editor;
            Project = editor.Project;
            TemplateMap = editor.Project.TemplateObjects;
            Display = new TiledDisplay(TemplateMapPanel, 16, 16, 3);
            Display.ShowGrid = true;
            Display.Graphics.Clear(Color.White);
            Display.MouseDown += Display_MouseDown;
            MapRenderer = new MapRenderer(TemplateMap, Display);
            UpdateTemplateList();
            TemplateList.Click += TemplateList_Click;
            Shown += TemplateObjectWindow_Shown;
            KeyDown += TemplateObjectWindow_KeyDown;
        }

        private string GetTemplateId(GameObject o)
        {
            return o.Properties.GetAsString("template_id");
        }

        private void SetTemplateId(GameObject o, string templateId)
        {
            o.Properties.Set("template_id", templateId);
        }

        private void TemplateObjectWindow_Shown(object sender, EventArgs e)
        {
            TemplateList.ClearSelection();
        }

        private void TemplateObjectWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                WindowState = FormWindowState.Minimized;
            else if (e.KeyCode == Keys.F2)
                RenameSelectedTemplate();
            else if (e.KeyCode == Keys.Delete)
                DeleteSelectedTemplate();
        }

        private void TemplateList_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (TemplateList.SelectedRows.Count > 0 && me.Button == MouseButtons.Left)
                SelectTemplateInMapWithId(GetIdOfSelectedTemplateInList(), updateMapEditorClipboard: true);
        }

        private void Display_MouseDown(object sender, MouseEventArgs e)
        {
            Point pos = Display.GetMouseToCellPos(e.Location);
            ObjectCell cell = TemplateMap.GetCell(new ObjectPosition(0, pos));

            if (e.Button == MouseButtons.Left)
            {
                SelectObject(cell,
                    updateMapEditorClipboard: true,
                    updateTemplateListSelection: true,
                    updateTemplatePropertyList: true);
            }
            else if (e.Button == MouseButtons.Right)
            {
                EditObject(cell);
            }
        }

        private void SelectObject(ObjectCell cell, bool updateMapEditorClipboard, bool updateTemplateListSelection, bool updateTemplatePropertyList)
        {
            GameObject o = cell.Object;

            if (o == null)
            {
                Alert.Warning("This cell is empty.\nRight-click to create a new object here.");
                return;
            }

            if (updateMapEditorClipboard)
            {
                MapEditor.CopyObjectToClipboard(o);
                MapEditor.GameObjectPanel.UpdateClipboardView();
            }

            if (updateTemplatePropertyList)
                UpdateProperties(o);

            if (updateTemplateListSelection)
                SelectTemplateInListWithId(o.Properties.GetAsString("template_id"));
        }

        private void SelectTemplateInListWithId(string id)
        {
            foreach (DataGridViewRow row in TemplateList.Rows)
            {
                if ((string)row.Cells[0].Value == id)
                {
                    row.Selected = true;
                    return;
                }
            }
        }

        private void SelectTemplateInMapWithId(string id, bool updateMapEditorClipboard)
        {
            for (int y = 0; y < TemplateMap.Height; y++)
            {
                for (int x = 0; x < TemplateMap.Width; x++)
                {
                    GameObject o = TemplateMap.GetObject(new ObjectPosition(0, x, y));

                    if (o != null && GetTemplateId(o) == id)
                    {
                        SelectObject(TemplateMap.GetCell(new ObjectPosition(0, x, y)), 
                            updateMapEditorClipboard: updateMapEditorClipboard, 
                            updateTemplateListSelection: false,
                            updateTemplatePropertyList: true);

                        break;
                    }
                }
            }
        }

        private void EditObject(ObjectCell cell)
        {
            GameObject o = cell.Object;
            bool newObject = o == null;

            if (newObject)
                o = new GameObject(new Tile(0, 0, 1));

            ObjectEditWindow win = new ObjectEditWindow(MapEditor, o);
            DialogResult result = win.ShowDialog(this, "Select tile graphics");
            bool ok = result == DialogResult.OK;

            if (ok)
            {
                GameObject editedObject = win.EditedObject;

                if (newObject)
                {
                    bool idValid = false;
                    while (!idValid)
                    {
                        StringInputWindow nameWindow = new StringInputWindow("New template object", "Enter an ID for this template:");
                        SetTemplateId(editedObject, nameWindow.ShowDialog(this));

                        if (nameWindow.DialogResult == DialogResult.Cancel)
                            return;

                        string id = GetTemplateId(editedObject);

                        if (string.IsNullOrWhiteSpace(id))
                            Alert.Warning("Please enter an ID or press ESC to cancel.");
                        else if (IsDuplicateId(id))
                            Alert.Warning($"There already is a template with the ID: {id}\nPlease enter a different ID.");
                        else
                            idValid = true;
                    }
                }

                cell.PutObject(o);
                cell.SetObjectEqual(editedObject);

                if (newObject)
                    UpdateTemplateList();
            }
        }

        private bool IsDuplicateId(string id)
        {
            return GetObjectWithIdInMap(id) != null;
        }

        private void UpdateProperties(GameObject o)
        {
            PropertyList.Rows.Clear();

            if (o != null)
            {
                foreach (var property in o.Properties.Entries)
                    PropertyList.Rows.Add(property.Key, property.Value);

                PropertyList.Refresh();
            }
        }

        private void UpdateTemplateList()
        {
            TemplateList.Rows.Clear();

            for (int y = 0; y < TemplateMap.Height; y++)
            {
                for (int x = 0; x < TemplateMap.Width; x++)
                {
                    GameObject o = TemplateMap.GetObject(new ObjectPosition(0, x, y));
                    if (o != null)
                        TemplateList.Rows.Add(GetTemplateId(o));
                }
            }

            TemplateList.ClearSelection();
            TemplateList.Refresh();
            PropertyList.Rows.Clear();
        }

        private void DeleteSelectedTemplate()
        {
            ObjectCell cell = GetCellOfSelectedTemplateInMap();
            if (cell == null)
                return;
            
            cell.DeleteObject();
            UpdateTemplateList();
        }

        private void RenameSelectedTemplate()
        {
            if (TemplateList.SelectedRows.Count == 0)
                return;

            StringInputWindow win = new StringInputWindow("Rename template object", "Rename this template with a new ID:");
            string newId = win.ShowDialog(this);
            if (string.IsNullOrWhiteSpace(newId))
                return;

            GameObject o = GetObjectOfSelectedTemplateInMap();
            SetTemplateId(o, newId);
            UpdateTemplateList();
        }

        private string GetIdOfSelectedTemplateInList()
        {
            if (TemplateList.SelectedRows.Count > 0)
                return (string)TemplateList.SelectedRows[0].Cells[0].Value;

            return null;
        }

        private ObjectCell GetCellOfSelectedTemplateInMap()
        {
            string selectedIdInList = GetIdOfSelectedTemplateInList();
            if (selectedIdInList == null)
                return null;

            for (int y = 0; y < TemplateMap.Height; y++)
            {
                for (int x = 0; x < TemplateMap.Width; x++)
                {
                    ObjectPosition pos = new ObjectPosition(0, x, y);
                    GameObject o = TemplateMap.GetObject(pos);

                    if (o != null && GetTemplateId(o) == selectedIdInList)
                        return TemplateMap.GetCell(pos);
                }
            }

            return null;
        }

        private GameObject GetObjectOfSelectedTemplateInMap()
        {
            ObjectCell cell = GetCellOfSelectedTemplateInMap();
            return cell?.Object;
        }

        private GameObject GetObjectWithIdInMap(string id)
        {
            for (int y = 0; y < TemplateMap.Height; y++)
            {
                for (int x = 0; x < TemplateMap.Width; x++)
                {
                    ObjectPosition pos = new ObjectPosition(0, x, y);
                    GameObject o = TemplateMap.GetObject(pos);

                    if (o != null && GetTemplateId(o) == id)
                        return o;
                }
            }

            return null;
        }

        private void CreateNewTemplateInFirstEmptyCell()
        {
            ObjectCell firstEmptyCell = GetFirstEmptyCell();
            if (firstEmptyCell == null)
            {
                ShowWarningNoMoreEmptyCells();
                return;
            }

            EditObject(firstEmptyCell);
        }

        private ObjectCell GetFirstEmptyCell()
        {
            for (int y = 0; y < TemplateMap.Height; y++)
            {
                for (int x = 0; x < TemplateMap.Width; x++)
                {
                    ObjectCell cell = TemplateMap.GetCell(new ObjectPosition(0, x, y));
                    if (cell.IsEmpty)
                        return cell;
                }
            }

            return null;
        }

        private void DuplicateSelectedTemplate()
        {
            GameObject original = GetObjectOfSelectedTemplateInMap();
            if (original == null)
                return;

            ObjectCell firstEmptyCell = GetFirstEmptyCell();
            if (firstEmptyCell == null)
            {
                ShowWarningNoMoreEmptyCells();
                return;
            }

            firstEmptyCell.SetObjectEqual(original);
            SetTemplateId(firstEmptyCell.Object, "Copy of " + GetTemplateId(original));
            UpdateTemplateList();
            EditObject(firstEmptyCell);
        }

        private void ShowWarningNoMoreEmptyCells()
        {
            Alert.Warning("There are no more empty cells.\nYou can either delete or edit existing objects.");
        }

        private void BtnNewTemplate_Click(object sender, EventArgs e)
        {
            CreateNewTemplateInFirstEmptyCell();
        }

        private void BtnEditSelected_Click(object sender, EventArgs e)
        {
            ObjectCell cell = GetCellOfSelectedTemplateInMap();
            if (cell != null)
                EditObject(cell);
        }

        private void BtnDeleteSelected_Click(object sender, EventArgs e)
        {
            DeleteSelectedTemplate();
        }

        private void BtnDuplicateSelected_Click(object sender, EventArgs e)
        {
            DuplicateSelectedTemplate();
        }

        private void BtnRearrange_Click(object sender, EventArgs e)
        {
            // todo
        }
    }
}
