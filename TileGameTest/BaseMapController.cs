using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TileGameLib.Engine;
using TileGameLib.GameElements;

namespace TileGameTest
{
    public class BaseMapController : MapController
    {
        public Player Player { set; get; }

        public BaseMapController()
        {
        }

        public override void OnEnter()
        {
            Player = (Engine as TestEngine).Player;
            CenterMapViewOnPlayer();
        }

        protected void MovePlayer(int dx, int dy)
        {
            PositionedObject player = FindPlayer();
            ObjectPosition adjacentPosUnderPlayer = player.Position.AtDistance(dx, dy).Under();
            GameObject adjacentObjectUnder = Map.GetObject(adjacentPosUnderPlayer);

            bool moved = false;

            if (adjacentObjectUnder == null || !adjacentObjectUnder.Visible)
            {
                moved = Map.MoveObjectIfDestinationIsEmpty(
                    player.Position, adjacentPosUnderPlayer.Above());
            }

            if (moved)
                MapRenderer.ScrollByDistance(dx, dy);
        }

        protected PositionedObject GetObjectNextToPlayer(Point distance)
        {
            PositionedObject player = FindPlayer();
            ObjectPosition adjacentPosition = player.Position.AtDistance(distance.X, distance.Y).Under();
            PositionedObject adjacent = new PositionedObject(Map.GetObject(adjacentPosition), adjacentPosition);

            return adjacent;
        }

        protected PositionedObject FindPlayer()
        {
            return (Engine as TestEngine).Player.Find();
        }

        protected void CenterMapViewOnPlayer()
        {
            MapRenderer.ScrollToCenter(FindPlayer().Position.Point);
        }

        protected void ShowMessage(params string[] messages)
        {
            Ui.ShowMessage(TestEngine.BottomPanelTag, TestEngine.MessageDuration, messages);
        }

        protected Point GetDirectionOffsetByKeyPressed(Keys keyPressed)
        {
            int dx = 0;
            int dy = 0;

            switch (keyPressed)
            {
                case Keys.Up:
                case Keys.W:
                case Keys.NumPad8:
                    dy = -1;
                    break;
                case Keys.Down:
                case Keys.S:
                case Keys.NumPad2:
                    dy = 1;
                    break;
                case Keys.Left:
                case Keys.A:
                case Keys.NumPad4:
                    dx = -1;
                    break;
                case Keys.Right:
                case Keys.D:
                case Keys.NumPad6:
                    dx = 1;
                    break;
                case Keys.Q:
                case Keys.NumPad7:
                    dx = -1;
                    dy = -1;
                    break;
                case Keys.E:
                case Keys.NumPad9:
                    dx = 1;
                    dy = -1;
                    break;
                case Keys.Z:
                case Keys.NumPad1:
                    dx = -1;
                    dy = 1;
                    break;
                case Keys.X:
                case Keys.NumPad3:
                    dx = 1;
                    dy = 1;
                    break;
            }

            return new Point(dx, dy);
        }
    }
}
