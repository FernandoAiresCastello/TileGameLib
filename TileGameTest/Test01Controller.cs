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
    class Test01Controller : MapController
    {
        private int YellowKeys = 0;
        private int PinkKeys = 0;

        public Test01Controller()
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnLeave()
        {
        }

        public override void OnExecuteCycle()
        {
        }

        public override void OnDrawUi()
        {
            if (!Engine.HasMessages)
            {
                PrintUi("Yellow keys: " + YellowKeys, 0, 0);
                PrintUi("Pink keys: " + PinkKeys, 0, 1);
            }
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            Point offset = GetDirectionOffsetByKeyPressed(e.KeyCode);
            PositionedObject player = FindPlayer();
            ObjectPosition adjacentPos = player.Position.AtDistance(offset.X, offset.Y);
            PositionedObject adjacent = new PositionedObject(Map.GetObject(adjacentPos), adjacentPos);

            if (IsKey(adjacent.Object))
                TakeKey(adjacent);
            else if (IsDoor(adjacent.Object))
                OpenDoor(adjacent);
            else
                MovePlayer(player, offset.X, offset.Y);
        }

        private void TakeKey(PositionedObject key)
        {
            string takenMessage = null;

            if (IsKey(key.Object, "yellow"))
            {
                YellowKeys++;
                takenMessage = "Got a yellow key!";
            }
            else if (IsKey(key.Object, "pink"))
            {
                PinkKeys++;
                takenMessage = "Got a pink key!";
            }

            if (!string.IsNullOrWhiteSpace(takenMessage))
            {
                Map.DeleteObject(key.Position);
                ShowMessage(takenMessage);
            }
        }

        private void OpenDoor(PositionedObject door)
        {
            bool unlock = false;

            if (IsDoor(door.Object, "yellow"))
            {
                if (YellowKeys > 0)
                {
                    YellowKeys--;
                    unlock = true;
                }
                else
                {
                    ShowMessage("The door is locked", "You need a yellow key");
                }
            }
            else if (IsDoor(door.Object, "pink"))
            {
                if (PinkKeys > 0)
                {
                    PinkKeys--;
                    unlock = true;
                }
                else
                {
                    ShowMessage("The door is locked", "You need a pink key!");
                }
            }

            if (unlock)
            {
                Map.DeleteObject(door.Position);
                ShowMessage("Unlocked the door!");
            }
        }

        private bool IsDoor(GameObject o, string color = null)
        {
            if (o == null)
                return false;

            bool isDoor = o.HasTag && o.Tag.Equals("door");

            if (color != null)
                return isDoor && o.Properties.HasValue("color", color);

            return isDoor;
        }

        private bool IsKey(GameObject o, string color = null)
        {
            if (o == null)
                return false;

            bool isKey = o.HasTag && o.Tag.Equals("key");

            if (color != null)
                return isKey && o.Properties.HasValue("color", color);

            return isKey;
        }

        private void MovePlayer(PositionedObject player, int dx, int dy)
        {
            Map.MoveObjectIfDestinationIsEmpty(
                player.Position, player.Position.AtDistance(dx, dy));
        }

        private PositionedObject FindPlayer()
        {
            return Map.FindObjectByTag("player");
        }

        private Point GetDirectionOffsetByKeyPressed(Keys keyPressed)
        {
            int dx = 0;
            int dy = 0;

            if      (keyPressed == Keys.Up)     dy = -1;
            else if (keyPressed == Keys.Down)   dy = 1;
            else if (keyPressed == Keys.Right)  dx = 1;
            else if (keyPressed == Keys.Left)   dx = -1;

            return new Point(dx, dy);
        }

        private void ShowMessage(params string[] messages)
        {
            (Engine as TestEngine).ShowMessage(messages);
        }

        private void PrintUi(string text, int offsetX, int offsetY)
        {
            (Engine as TestEngine).PrintUi(text, offsetX, offsetY);
        }
    }
}
