using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Solver
    {
        public Board board { get; private set; }
        public int Step { get; private set; }
        List<Field> knownFree;

        public Solver(Board board, List<Field> knownFree = null)
        {
            this.knownFree = knownFree ?? new List<Field> { board[new Coord(0, 0)] };
            this.board = board;
            Step = 1;
        }

        public void SolveStep()
        {
            Step = Step + 1;

            var sets = new UnknownSet.WorkingSets();
            foreach (var s in knownFree)
            {
                var unknown = s.Neighbors.Unknown;

                if (unknown.Count() > 0)
                {
                    int remainingMines = s.Remaing;
                    UnknownSet.AddOrUpdateSet(
                        new UnknownSet(new HashSet<Field>(s.Neighbors.Unknown),
                            s.Remaing, s.Remaing)
                        , sets);
                }
            }

            int prevCount = 0;
            while (sets.Count != prevCount)
            {
                int startPos = prevCount;
                prevCount = sets.Count;

                for (int i = 0; i < prevCount; i++)
                    for (int j = i + 1; j < prevCount; j++)
                        UnknownSet.Compute(sets[i], sets[j], sets);
            }

            foreach (var s in sets)
                knownFree.AddRange(s.TryFindMine());
        }
    }
}
