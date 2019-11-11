using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;
using TileGameLib.Util;

namespace TestPlayground
{
    class TestMapController : MapController
    {
        private PositionedObject Player;
        private int YellowKeys = 0;
        private int PinkKeys = 0;

        public TestMapController()
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

        public override void OnKeyDown(KeyEventArgs e)
        {
            Player = Map.FindObjectByTag("player");

            int dx = 0;
            int dy = 0;

            if (e.KeyCode == Keys.Up)
                dy = -1;
            else if (e.KeyCode == Keys.Down)
                dy = 1;
            else if (e.KeyCode == Keys.Right)
                dx = 1;
            else if (e.KeyCode == Keys.Left)
                dx = -1;

            ObjectPosition pos = ObjectPosition.AtDistance(Player.Position, dx, dy);
            GameObject o = Map.GetObject(pos);

            if (o != null && o.HasTag)
            {
                if (o.Tag.Equals("key"))
                {
                    Alert.Info("Got the key!");

                    if (o.Properties.HasValue("color", "yellow"))
                        YellowKeys++;
                    else if (o.Properties.HasValue("color", "pink"))
                        PinkKeys++;

                    Map.DeleteObject(pos);
                }
                if (o.Tag.Equals("door"))
                {
                    if (o.Properties.HasValue("color", "yellow"))
                    {
                        if (YellowKeys > 0)
                        {
                            Alert.Info("Unlocked the door!");
                            Map.DeleteObject(pos);
                            YellowKeys--;
                        }
                        else
                        {
                            Alert.Info("You need a yellow key!");
                        }
                    }
                    else if (o.Properties.HasValue("color", "pink"))
                    {
                        if (PinkKeys > 0)
                        {
                            Alert.Info("Unlocked the door!");
                            Map.DeleteObject(pos);
                            PinkKeys--;
                        }
                        else
                        {
                            Alert.Info("You need a pink key!");
                        }
                    }
                }
            }
            else
            {
                Map.MoveObjectIfDestinationIsEmpty(Player.Position, ObjectPosition.AtDistance(Player.Position, dx, dy));
            }
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
        }
    }
}
