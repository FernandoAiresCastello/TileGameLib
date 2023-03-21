using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileGameLib
{
    public class TileAnimation
    {
        public int Frame => frame;

        private bool enabled = true;
        private int frame = 0;
        private int speed = 85;
        private int advanceCounter = 0;
        private readonly int advanceCounterMax = 100;

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        public void NextFrame()
        {
            if (!enabled)
                return;

            advanceCounter++;
            if (advanceCounter >= advanceCounterMax - speed)
            {
                frame++;
                advanceCounter = 0;
            }
        }

        public void Speed(int newSpeed)
        {
            if (speed > 0)
            {
                Enable();
                speed = newSpeed;
            }
            else
            {
                Disable();
            }
        }
    }
}
