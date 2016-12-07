using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Expanding2DArea<T>
    {
        // invariant: All Lists have the same length;
        List<List<T>>[][] fieldParts = new[]
            {new [] {new List<List<T>>(), new List<List<T>>()},  // for upper left  and lower left  quadrant
             new [] {new List<List<T>>(), new List<List<T>>()}}; // for upper right and lower right quadrant
        // the inner list is a row
        // the outer list has all the rows of a quadrant

        Func<int, int, T> ctor;

        public Expanding2DArea(Func<int, int, T> ctor)
        {
            this.ctor = ctor;

            fieldParts[0][0].Add(new List<T>());
            fieldParts[0][1].Add(new List<T>());
            fieldParts[1][0].Add(new List<T>());
            fieldParts[1][1].Add(new List<T>());

            fieldParts[0][0][0].Add(ctor(0, 0));
            SquareRadius = 1;
            Top = 0;
            Left = 0;
            Right = 0;
            Bottom = 0;
        }

        void Add(int nx, int ny)
        {
            int yValue = ny <= 0 ? 0 : 1;
            int xValue = nx <= 0 ? 0 : 1;
            var quad = fieldParts[yValue][xValue];
            int ay = Math.Abs(ny) - yValue;
            int ax = Math.Abs(nx) - xValue;
            while (!(ay < quad.Count))
            {
                quad.Add(new List<T>());
            }
            var row = quad[ay];
            while (!(ax < row.Count))
            {
                row.Add(ctor(Math.Sign(nx) * (row.Count + xValue), ny));
            }
        }

        public T this[int x, int y]
        {
            get
            {
                Add(x, y);
                SquareRadius = JRapp.Numeric.Max(SquareRadius, Math.Abs(x), Math.Abs(y));
                Top = JRapp.Numeric.Min(Top, y);
                Bottom = JRapp.Numeric.Max(Bottom, y);
                Left = JRapp.Numeric.Min(Left, x);
                Right = JRapp.Numeric.Max(Right, x);
                int yValue = y <= 0 ? 0 : 1;
                int xValue = x <= 0 ? 0 : 1;
                int ay = Math.Abs(y) - yValue;
                int ax = Math.Abs(x) - xValue;
                return fieldParts[yValue][xValue][ay][ax];
            }
        }
        public T this[Coord c]
        {
            get { return this[c.x, c.y]; }
        }

        public int SquareRadius { get; private set; }
        public int Top { get; private set; }
        public int Left { get; private set; }
        public int Right { get; private set; }
        public int Bottom { get; private set; }
    }
}
