using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class KnownMinesweeper : IMinesweeper
    {
        Dictionary<Coord, int> known;
        public List<Coord> SoverTriedToUncover{ get; private set; }
        public KnownMinesweeper(Dictionary<Coord, int> known)
        {
            SoverTriedToUncover = new List<Coord>();
            this.known = known;
        }

        public int GetNumber(Coord c)
        {
            if (known.ContainsKey(c))
            {
                return known[c];
            }
            else
            {
                SoverTriedToUncover.Add(c);
                // we don't know
                return -2;
            }
        }
    }
}
