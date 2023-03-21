﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace TileGameLib
{
    public class Palette
    {
        private readonly Dictionary<string, Rgb> colors = new Dictionary<string, Rgb>();

        public void Set(string name, Rgb color)
        {
            colors[name] = color;
        }

        public Rgb Get(string name)
        {
            return colors.ContainsKey(name) ? colors[name] : 
                throw new ArgumentException("Palette does not contain color with name: " + name);
        }
    }
}
