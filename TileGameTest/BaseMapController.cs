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
        protected void MovePlayer(int dx, int dy)
        {
            PositionedObject player = FindPlayer();

            bool moved = Map.MoveObjectIfDestinationIsEmpty(
                player.Position, player.Position.AtDistance(dx, dy));

            if (moved)
                MapRenderer.ScrollByDistance(dx, dy);
        }

        protected PositionedObject GetObjectNextToPlayer(Point distance)
        {
            PositionedObject player = FindPlayer();
            ObjectPosition adjacentPosition = player.Position.AtDistance(distance.X, distance.Y);
            PositionedObject adjacent = new PositionedObject(Map.GetObject(adjacentPosition), adjacentPosition);

            return adjacent;
        }

        protected PositionedObject FindPlayer()
        {
            return Map.FindObjectByTag("player");
        }

        protected void CenterMapViewOnPlayer()
        {
            MapRenderer.ScrollToCenter(FindPlayer().Position.Point);
        }

        protected Point GetDirectionOffsetByKeyPressed(Keys keyPressed)
        {
            int dx = 0;
            int dy = 0;

            switch (keyPressed)
            {
                case Keys.Up: dy = -1; break;
                case Keys.Down: dy = 1; break;
                case Keys.Left: dx = -1; break;
                case Keys.Right: dx = 1; break;
            }

            return new Point(dx, dy);
        }

        protected void ShowMessage(params string[] messages)
        {
            (Engine as TestEngine).ShowMessage(messages);
        }

        protected void PrintUi(string text, int offsetX, int offsetY)
        {
            (Engine as TestEngine).PrintUi(text, offsetX, offsetY);
        }
    }
}
