using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    struct Coord
    {
        public static List<Coord> neighbors = new List<Coord>()
            { 
            new Coord(-1,-1), new Coord(+0,-1), new Coord(+1,-1),
            new Coord(-1,+0),                   new Coord(+1,+0),
            new Coord(-1,+1), new Coord(+0,+1), new Coord(+1,+1)
            };

        public static readonly List<Coord> neigborsAndSelf =
            neighbors.Concat(Enumerable.Repeat(new Coord(0, 0),1)).ToList();

        public Coord(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Coord operator +(Coord c1, Coord c2)
        {
            return new Coord(c1.x + c2.x, c1.y + c2.y);
        }
        public static Coord operator -(Coord c1, Coord c2)
        {
            return new Coord(c1.x - c2.x, c1.y - c2.y);
        }
        public static Coord operator -(Coord c1)
        {
            return new Coord(-c1.x, -c1.y);
        }

        public int x;
        public int y;

        public override string ToString()
        {
            return "(" + x + "," + y + ")";
        }
    }
}
