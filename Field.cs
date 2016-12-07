using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Field
    {
        public Board Board { get; private set; }
        public Coord Coord { get; private set; }
        public Neighbors Neighbors { get; private set; }

        private int number = -2; // -2 means Unknown; -1 means Knonw Mine
        public int Number { get { if (number == -2) { throw new Exception(); } return number; } }
        public int Remaing
        {
            get
            {
                if (number == -1) { throw new Exception(); }
                return number - Neighbors.Known.Count(f => f.IsMine);
            }
        }
        public bool IsMine { get { if (number == -2) { throw new Exception(); } return number == -1; } }
        public bool Known { get { return number != -2; } }

        public void Uncover() { number = Board.Minesweeper.GetNumber(Coord); }
        public void Flag() { number = -1; }

        public Field(Board board, Coord coord)
        {
            this.Board = board;
            this.Coord = coord;
            this.Neighbors = new Neighbors(this);
        }

        public override string ToString()
        {
            return String.Format("{{{0}|{1}}}", Coord, Known ? IsMine ? "Mine" : Number.ToString() : "Unknown");
        }
    }
}
