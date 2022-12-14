using System;
using System.Collections.Generic;

namespace U.DemoProject.Map
{
    public class PathNode
    {
        public int x;
        public int y;

        public int gCost;
        public int hCost;
        public int fCost;

        public PathNode cameFromNode;

        public PathNode(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void CalculateFCost() =>
            fCost = gCost + hCost;


        public override string ToString()
        {
            return x + "," + y;
        }

    }
}
