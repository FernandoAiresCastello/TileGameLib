using System;
using System.Collections.Generic;

namespace TileGameLib
{
    public class Viewset
    {
        public View Selected => selected;
        public bool IsDefaultSelected => selected.IsDefault;

        private readonly Dictionary<string, View> views = new Dictionary<string, View>();
        private View selected;

        public View Get(string id)
        {
            return views.ContainsKey(id) ? views[id] : 
                throw new ArgumentException("View not found with id: " + id);
        }

        public void AddDefault(int x1, int y1, int x2, int y2, Rgb backColor)
        {
            if (!views.ContainsKey(View.DefaultId))
                views[View.DefaultId] = View.Default(x1, y1, x2, y2, backColor);
        }

        public void Add(string id, int x1, int y1, int x2, int y2, Rgb backColor)
        {
            if (views.ContainsKey(id))
            {
                views[id].Set(x1, y1, x2, y2, backColor);
            }
            else
            {
                views[id] = new View(id, x1, y1, x2, y2, backColor);
            }
        }

        public void SelectDefault()
        {
            Select(View.DefaultId);
        }

        public bool Select(string id)
        {
            if (views.ContainsKey(id))
            {
                selected = views[id];
                return true;
            }
            else
            {
                throw new ArgumentException("View not found with id: " + id);
            }
        }
    }
}
