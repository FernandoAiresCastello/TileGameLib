using System;
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
using System.Media;

namespace TileGameEngine.Core.RuntimeEnvironment
{
    public partial class Environment
    {
        private SoundPlayer SoundPlayer = new SoundPlayer();

        public void PlaySoundOnce(string file)
        {
            SoundPlayer.SoundLocation = file;
            SoundPlayer.Play();
        }

        public void PlaySoundAwait(string file)
        {
            SoundPlayer.SoundLocation = file;
            SoundPlayer.PlaySync();
        }

        public void PlaySoundLoop(string file)
        {
            SoundPlayer.SoundLocation = file;
            SoundPlayer.PlayLooping();
        }

        public void StopSound()
        {
            SoundPlayer.Stop();
        }
    }
}
