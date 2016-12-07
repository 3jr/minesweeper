using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    interface IMinesweeper
    {
        int GetNumber(Coord c);
    }
    class Minesweeper : IMinesweeper
    {
        Random rand;
        int seed;
        Dictionary<Coord, bool> isMine;

        readonly double mineProbability;

        public Minesweeper(double mineProbability, Dictionary<Coord, bool> isMine = null, int? seed = null)
        {
            this.seed = seed ?? Environment.TickCount % 10000;
            rand = new Random(this.seed);
            this.isMine = isMine ?? Coord.neigborsAndSelf.ToDictionary(c => c, c => false);
            this.isMine = new Dictionary<Coord, bool>(this.isMine); // copy
            this.mineProbability = mineProbability;
        }

        bool GetOrAddMine(Coord c)
        {
            bool res;
            if(!isMine.TryGetValue(c, out res))
            {
                bool b = rand.NextDouble() < mineProbability;
                isMine.Add(c, b);
                return b;
            }
            return res;
        }

        public int GetNumber(Coord c)
        {
            if (GetOrAddMine(c))
                throw new Exception("You Lost");

            int n = Coord.neighbors.Select(r => GetOrAddMine(c+r)).Count(mine => mine);
            return n;
        }
    }
}
