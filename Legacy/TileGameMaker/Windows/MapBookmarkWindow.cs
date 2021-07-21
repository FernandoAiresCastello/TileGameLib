using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameMaker.MapEditorElements;
using TileGameMaker.Panels;

namespace TileGameMaker.Windows
{
    public partial class MapBookmarkWindow : Form
    {
        private string MapId;
        private List<MapBookmark> Bookmarks;
        private MapEditorPanel MapPanel;
        private int CurrentX;
        private int CurrentY;

        private MapBookmarkWindow()
        {
            InitializeComponent();
        }

        public MapBookmarkWindow(MapBookmarks bookmarks, string mapid, MapEditorPanel mapPanel)
        {
            InitializeComponent();
            MapId = mapid;
            MapPanel = mapPanel;
            CurrentX = mapPanel.ViewScrollX;
            CurrentY = mapPanel.ViewScrollY;
            Bookmarks = bookmarks.FindByMapId(mapid);
            UpdateList();
            LstBookmarks.DoubleClick += LstBookmarks_DoubleClick;
        }

        private void UpdateList()
        {
            LstBookmarks.Items.Clear();

            foreach (MapBookmark bm in Bookmarks)
            {
                LstBookmarks.Items.Add(bm);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                Bookmarks.Add(new MapBookmark(MapId, name, CurrentX, CurrentY));
                TxtName.Clear();
                UpdateList();
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            string name = TxtName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                for (int i = 0; i < Bookmarks.Count; i++)
                {
                    MapBookmark bm = Bookmarks[i];

                    if (bm.Name == name)
                    {
                        Bookmarks.Remove(bm);
                        break;
                    }
                }

                TxtName.Clear();
                UpdateList();
            }
        }

        private void LstBookmarks_DoubleClick(object sender, EventArgs e)
        {
            MapBookmark bm = LstBookmarks.SelectedItem as MapBookmark;
            if (bm == null)
                return;

            MapPanel.ScrollViewTo(bm.X, bm.Y);
        }
    }
}
