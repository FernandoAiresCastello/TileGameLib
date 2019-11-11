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
            Engine.PrintUi("bottom", 0, 1, "Yellow keys: " + YellowKeys);
            Engine.PrintUi("bottom", 0, 2, "Pink keys: " + PinkKeys);
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            Point offset = GetDirectionOffsetByKeyPressed(e.KeyCode);
            PositionedObject player = FindPlayer();
            ObjectPosition pos = ObjectPosition.AtDistance(player.Position, offset.X, offset.Y);
            PositionedObject o = new PositionedObject(Map.GetObject(pos), pos);

            if (IsKey(o.Object))
                TakeKey(o);
            else if (IsDoor(o.Object))
                OpenDoor(o);
            else
                MovePlayer(player, offset.X, offset.Y);
        }

        private void TakeKey(PositionedObject key)
        {
            string takenMessage = null;

            if (IsYellowKey(key.Object))
            {
                YellowKeys++;
                takenMessage = "Got a yellow key!";
            }
            else if (IsPinkKey(key.Object))
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

            if (IsYellowDoor(door.Object))
            {
                if (YellowKeys > 0)
                {
                    YellowKeys--;
                    unlock = true;
                }
                else
                {
                    ShowMessage("You need a yellow key!");
                }
            }
            else if (IsPinkDoor(door.Object))
            {
                if (PinkKeys > 0)
                {
                    PinkKeys--;
                    unlock = true;
                }
                else
                {
                    ShowMessage("You need a pink key!");
                }
            }

            if (unlock)
            {
                Map.DeleteObject(door.Position);
                ShowMessage("Unlocked the door!");
            }
        }

        private bool IsDoor(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("door");
        }

        private bool IsYellowDoor(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("door") && o.Properties.HasValue("color", "yellow");
        }

        private bool IsPinkDoor(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("door") && o.Properties.HasValue("color", "pink");
        }

        private bool IsKey(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("key");
        }

        private bool IsYellowKey(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("key") && o.Properties.HasValue("color", "yellow");
        }

        private bool IsPinkKey(GameObject o)
        {
            return o != null && o.HasTag && o.Tag.Equals("key") && o.Properties.HasValue("color", "pink");
        }

        private void MovePlayer(PositionedObject player, int dx, int dy)
        {
            Map.MoveObjectIfDestinationIsEmpty(player.Position,
                ObjectPosition.AtDistance(player.Position, dx, dy));
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

        private void ShowMessage(string text)
        {
            (Engine as TestEngine).ShowMessage(text);
        }
    }
}
