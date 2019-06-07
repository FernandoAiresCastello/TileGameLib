﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib.Exception
{
    public class FileException : RuntimeException
    {
        public FileException(string msg) : base(msg)
        {
        }
    }
}
