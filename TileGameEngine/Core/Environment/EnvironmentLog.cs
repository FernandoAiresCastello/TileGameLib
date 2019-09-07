using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TileGameEngine.Util;

namespace TileGameEngine.Core
{
    public partial class Environment
    {
        public static readonly string LogFile = Config.ReadString("LogFile");

        public void DeleteLogFile()
        {
            if (File.Exists(LogFile))
                File.Delete(LogFile);
        }

        public void WriteLog(string message)
        {
            using (var stream = File.AppendText(LogFile))
                stream.WriteLine(message);
        }
    }
}
