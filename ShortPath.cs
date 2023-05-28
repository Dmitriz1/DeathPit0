using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Drawing;

namespace DeathPitTest
{
    public class ShortPath : GameForm
    {
        public Point Position { get; set; }
        public int PathLengthFromStart { get; set; }
        public ShortPath CameFrom { get; set; }
        public int HeuristicEstimatePathLength { get; set; }

        public int EstimateFullPathLength
        {
            get
            {
                return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
            }
        }

        public static List<Point> FindPath(Point start, Point playerpos)
        {
            var closedSet = new Collection<ShortPath>();
            var openSet = new Collection<ShortPath>();
            Boss b = new Boss();
            Hero h = new Hero();
            playerpos = b.Location;

            ShortPath startpos = new ShortPath()
            {
                Position = b.Location,
                CameFrom = null,
                PathLengthFromStart = 0,
                HeuristicEstimatePathLength = GetHeuristicPathLength(start, playerpos)
            };

            return null;
        }

        private static int GetHeuristicPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }
    }
}
