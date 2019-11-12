using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TileGameTest
{
    class Test01Controller : BaseMapController
    {
        private int YellowKeys = 0;
        private int PinkKeys = 0;

        public Test01Controller()
        {
        }

        public override void OnEnter()
        {
            CenterMapViewOnPlayer();
        }

        public override void OnDrawUi()
        {
            if (!Engine.HasMessages)
            {
                PrintUi("Yellow keys: " + YellowKeys, 0, 0);
                PrintUi("Pink keys: " + PinkKeys, 0, 1);
            }
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            Point offset = GetDirectionOffsetByKeyPressed(e.KeyCode);
            PositionedObject adjacent = GetObjectNextToPlayer(offset);

            if (ObjectAssertion.IsKey(adjacent.Object))
                TakeKey(adjacent);
            else if (ObjectAssertion.IsDoor(adjacent.Object))
                OpenDoor(adjacent);
            else
                MovePlayer(offset.X, offset.Y);
        }

        private void TakeKey(PositionedObject key)
        {
            string takenMessage = null;

            if (ObjectAssertion.IsKey(key.Object, "yellow"))
            {
                YellowKeys++;
                takenMessage = "Got a yellow key!";
            }
            else if (ObjectAssertion.IsKey(key.Object, "pink"))
            {
                PinkKeys++;
                takenMessage = "Got a pink key!";
            }

            if (takenMessage != null)
            {
                Map.DeleteObject(key.Position);
                ShowMessage(takenMessage);
            }
        }

        private void OpenDoor(PositionedObject door)
        {
            string unlockMessage = null;

            if (ObjectAssertion.IsDoor(door.Object, "yellow"))
            {
                if (YellowKeys > 0)
                {
                    YellowKeys--;
                    unlockMessage = "Unlocked the door!";
                }
                else
                {
                    ShowMessage("The door is locked", "You need a yellow key");
                }
            }
            else if (ObjectAssertion.IsDoor(door.Object, "pink"))
            {
                if (PinkKeys > 0)
                {
                    PinkKeys--;
                    unlockMessage = "Unlocked the door!";
                }
                else
                {
                    ShowMessage("The door is locked", "You need a pink key!");
                }
            }

            if (unlockMessage != null)
            {
                Map.DeleteObject(door.Position);
                ShowMessage(unlockMessage);
            }
        }
    }
}
