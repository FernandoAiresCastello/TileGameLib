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
        public Test01Controller()
        {
        }

        public override void OnDrawUi()
        {
            Ui.Print("Stats", TestEngine.RightPanelTag, 0, 0);

            if (!Engine.HasMessages)
                Ui.Print("Messages", TestEngine.BottomPanelTag, 0, 0);
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            Point offset = GetDirectionOffsetByKeyPressed(e.KeyCode);
            PositionedObject adjacent = GetObjectNextToPlayer(offset);

            if (ObjectAssertion.IsKey(adjacent.Object))
                TakeKey(adjacent);
            else if (ObjectAssertion.IsDoor(adjacent.Object))
                OpenDoor(adjacent);
            else if (ObjectAssertion.IsTeleport(adjacent.Object))
                Teleport(adjacent);
            else if (ObjectAssertion.IsButton(adjacent.Object))
                PushButton(adjacent);
            else
                MovePlayer(offset.X, offset.Y);
        }

        private void PushButton(PositionedObject button)
        {
            if (!button.Object.Properties.HasValue("active", "false"))
            {
                Map.MoveObjectBlock("blksrc", "blkdest", "width", "height");
                button.Object.Properties.Set("active", "false");
            }
        }

        private void TakeKey(PositionedObject key)
        {
            string takenMessage = null;

            if (ObjectAssertion.IsKey(key.Object, "yellow"))
            {
                Player.YellowKeys++;
                takenMessage = "Got a yellow key!";
            }
            else if (ObjectAssertion.IsKey(key.Object, "pink"))
            {
                Player.PinkKeys++;
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
                if (Player.YellowKeys > 0)
                {
                    Player.YellowKeys--;
                    unlockMessage = "Unlocked the door!";
                }
                else
                {
                    ShowMessage("The door is locked", "You need a yellow key");
                }
            }
            else if (ObjectAssertion.IsDoor(door.Object, "pink"))
            {
                if (Player.PinkKeys > 0)
                {
                    Player.PinkKeys--;
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

        private void Teleport(PositionedObject teleport)
        {
            string nextMap = teleport.Object.Properties.GetAsString("map");
            Engine.EnterMap(nextMap);
        }
    }
}
