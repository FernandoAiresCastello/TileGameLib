﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameLib.File;
using TileGameLib.GameElements;
using TileGameLib.Graphics;
using TileGameEngine.Windows;
using System.Windows.Forms;
using TileGameEngine.Util;
using TileGameLib.Util;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public partial class Environment
    {
        public Variables Variables { get; private set; } = new Variables();

        public Environment()
        {
            DeleteLogFile();
        }

        public void Reset()
        {
            DeleteLogFile();
            Variables.Clear();

            if (HasWindow)
                CloseWindow();

            Map = null;
            MapRenderer = null;
        }

        public void SetVariable(string variable, object value)
        {
            Variables.Set(variable, value);
        }

        public string GetVariable(string variable)
        {
            string name = variable;
            if (!Variables.Contains(name))
                TileGameEngineApplication.Error("SCRIPT ERROR", "Variable not found: " + name);

            return Variables.GetStr(name);
        }

        public int GetRandomNumber(int min, int max)
        {
            return RandomNumber.Get(min, max);
        }

        public void AddToVariable(string variable, int value)
        {
            Variables.Add(variable, value);
        }

        public void MultiplyVariable(string variable, int value)
        {
            Variables.Multiply(variable, value);
        }

        public void DivideVariable(string variable, int value)
        {
            Variables.Divide(variable, value);
        }
    }
}
