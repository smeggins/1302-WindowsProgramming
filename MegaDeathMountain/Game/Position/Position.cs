using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDeathMountain
{
    class Position
    {
        public IActor[][] Layout;

        public Position(int XSize = 8, int YSize = 8)
        {
            Layout = instantiateEmptyLayout(XSize, YSize);
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
            return ((newPosition.x <= Layout.Length) && (newPosition.y <= Layout[newPosition.x].Length));
        }

        private void AssignPosition((int x, int y) currentPosition, (int x, int y) newPosition)
        {
            if (Layout[newPosition.x][newPosition.y] == null)
            {
                Layout[newPosition.x][newPosition.y] = Layout[currentPosition.x][currentPosition.y];
            }
            else
            {
                (int x, int y) EmptyPosition = FindClosestUnusedSpot(currentPosition, newPosition);
                Layout[EmptyPosition.x][EmptyPosition.y] = Layout[currentPosition.x][currentPosition.y];
            }

            Layout[currentPosition.x][currentPosition.y] = null;
        }

        private (int x, int y) getPositionWithinBoundary((int x, int y)  newPosition)
        {
            (int x, int y) returnPosition = newPosition;
            if (newPosition.x > Layout.Length -1)
            {
                returnPosition.x = Layout.Length - 1;
            }

            if (newPosition.y > Layout[returnPosition.x].Length - 1)
            {
                returnPosition.y = Layout[returnPosition.x].Length - 1;
            }
            return returnPosition;
        }

        public void UpdatePosition(IActor actor, (int x, int y) currentPosition, (int x, int y) newPosition)
        {
            if (Layout[currentPosition.x][currentPosition.y] != null)
            {
                if (positionWithinLayout(newPosition)) 
                {
                    AssignPosition(currentPosition, newPosition);
                }
                else
                {
                    (int x, int y) inBoundaryPosition = getPositionWithinBoundary(newPosition);
                    AssignPosition(currentPosition, inBoundaryPosition);
                }
            }
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
    }
}
