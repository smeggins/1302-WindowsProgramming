using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    public class Position
    {
        public IActor[][] Layout;
        private ILogger Logger;

        public Position(ILogger logger, int XSize = 8, int YSize = 8)
        {
            Layout = instantiateEmptyLayout(XSize, YSize);
            Logger = logger;
        }

        private (int x, int y) FindClosestUnusedSpot((int x, int y) currentPosition, (int x, int y) newPosition)
        {
            int loop = 1;
            while (true)
            {
                if (Layout[newPosition.x - loop][newPosition.y] == null)
                {
                    return (newPosition.x - loop, newPosition.y);
                }
                else if (Layout[newPosition.x][newPosition.y - loop] == null)
                {
                    return (newPosition.x, newPosition.y - loop);
                }
            }
        }

        private bool positionWithinLayout((int x, int y) newPosition)
        {
            Logger.logDebugInformation($"positionWithinLayout(): x = {newPosition.x}, y = {newPosition.y}");
            return ((newPosition.x <= Layout.Length - 1) && (newPosition.x >= 0) && (newPosition.y >= 0) && (newPosition.y <= Layout[newPosition.x].Length - 1));
        }

        private void AssignPosition(Actor actor, (int x, int y) newPosition)
        {
            if (Layout[newPosition.x][newPosition.y] == null || Layout[newPosition.x][newPosition.y] == actor)
            {
                Layout[newPosition.x][newPosition.y] = Layout[actor.LayoutPosition.X][actor.LayoutPosition.Y];
            }
            else
            {
                (int x, int y) EmptyPosition = FindClosestUnusedSpot(actor.LayoutPosition, newPosition);
                Layout[EmptyPosition.x][EmptyPosition.y] = Layout[actor.LayoutPosition.X][actor.LayoutPosition.Y];
            }

            if (actor.LayoutPosition != newPosition)
            {
                Layout[actor.LayoutPosition.X][actor.LayoutPosition.Y] = null;
            }
        }

        private (int x, int y) getPositionWithinBoundary((int x, int y) newPosition)
        {
            (int x, int y) returnPosition = newPosition;
            if (newPosition.x > Layout.Length - 1)
            {
                returnPosition.x = Layout.Length - 1;
            }
            else if (newPosition.x < 0)
            {
                returnPosition.x = 0;
            }

            if (newPosition.y > Layout[returnPosition.x].Length - 1)
            {
                returnPosition.y = Layout[returnPosition.x].Length - 1;
            }
            else if (newPosition.y < 0)
            {
                returnPosition.y = 0;
            }

            return returnPosition;
        }

        public (int x, int y) UpdatePosition(Actor actor, (int x, int y) newPosition)
        {
            (int X, int Y) newSetPosition = actor.LayoutPosition;
            if (Layout[actor.LayoutPosition.X][actor.LayoutPosition.Y] != null)
            {
                Logger.logDebugInformation("UpdatePosition(): Layout[actor.LayoutPosition.X][actor.LayoutPosition.Y] != null");
                newSetPosition = newPosition;
                if (positionWithinLayout(newSetPosition)) 
                {
                    Logger.logDebugInformation("UpdatePosition(): position within layout");
                    AssignPosition(actor, newSetPosition);
                }
                else
                {
                    Logger.logDebugInformation("UpdatePosition(): position not within layout. about to set new position within bounds");
                    newSetPosition = getPositionWithinBoundary(newSetPosition);
                    Logger.logDebugInformation($"UpdatePosition(): new setPosition within boundary = {newSetPosition}");
                    AssignPosition(actor, newSetPosition);
                }
            }
            else
            {
                Logger.logDebugInformation("UpdatePosition(): player position null in layout");
            }
            actor.LayoutPosition = newSetPosition;
            return newSetPosition;

        }

        private IActor[][] instantiateEmptyLayout(int x, int y)
        {
            int xVal = (x > 5) ? x : 5;
            int yVal = (y > 5) ? x : 5;

            IActor[][] returnLayout = new IActor[x][];
            for (int i = 0; i < x; i++)
            {
                returnLayout[i] = new IActor[y];
                for (int j = 0; j < y; j++)
                {
                    returnLayout[i][j] = null;
                }
            }

            return returnLayout;
        }

        public void move(Actor actor, int X, int Y)
        {
            (int X, int Y) newPos = UpdatePosition(actor, (actor.LayoutPosition.X + X, actor.LayoutPosition.Y + Y));
            actor.LayoutPosition = newPos;
        }
    }
}
