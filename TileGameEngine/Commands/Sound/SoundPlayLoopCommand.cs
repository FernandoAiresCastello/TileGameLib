using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameEngine.Commands.Sound
{
    public class SoundPlayLoopCommand : CommandBase
    {
        public override void Execute(List<string> immediateParams)
        {
            string file = PopStr();
            Environment.PlaySoundLoop(file);
        }
    }
}
