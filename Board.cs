using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Board
    {
        Expanding2DArea<Field> board;
        public IMinesweeper Minesweeper { get; private set; }

        public Board(IMinesweeper minesweeper, Dictionary<Coord, bool> isMine = null)
        {
            board = new Expanding2DArea<Field>((x, y) => new Field(this, new Coord(x, y)));
            this.Minesweeper = minesweeper;

            foreach (var e in isMine ?? new Dictionary<Coord, bool> { { new Coord(0, 0), false } })
            {
                if (e.Value) // is mine
                {
                    this[e.Key].Flag();
                }
                else
                {
                    this[e.Key].Uncover();
                }
            }
        }

        public Field this[Coord c]
        {
            get { return board[c]; }
        }

        public Field this[int x, int y]
        {
            get { return board[x, y]; }
        }

        public void Print(bool drawCoords)
        {
            Func<int, int, string> getChar = (x, y) => { var f = board[x, y]; return f.Known ? f.Number == -1 ? "*" : f.Number.ToString() : " "; };
            // save boarders, as they change 
            var top = board.Top;
            var bottom = board.Bottom;
            var left = board.Left;
            var right = board.Right;

            for (int y = board.Top; y <= board.Bottom; y++)

            {
                for (int x = board.Left; x <= board.Right; x++)
                {
                    Console.Write(getChar(x, y));
                    if (drawCoords && x % 10 == 0)
                        Console.Write(" " + Math.Abs(y % 10) + " ");
                }
                Console.WriteLine();

                if (drawCoords && y % 10 == 0)
                {
                    Console.WriteLine();
                    for (int x = board.Left; x <= board.Right; x++)
                    {
                        Console.Write(Math.Abs(x % 10));
                        if (x == 0 && y == 0)
                        {
                            Console.Write(" @ ");
                        }
                        else if (x % 10 == 0)
                            Console.Write("   ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
