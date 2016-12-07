using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class Neighbors
    {
        Field field;

        Lazy<List<Field>> fields;

        public List<Field> Fields { get { return fields.Value; } }
        public IEnumerable<Field> Unknown { get { return Fields.Where(f => !f.Known); } }
        public IEnumerable<Field> Known { get { return Fields.Where(f => f.Known); } }

        public Neighbors (Field field)
        {
            this.field = field;
            this.fields = new Lazy<List<Field>>(() => Coord.neighbors.Select(c => field.Board[field.Coord + c]).ToList());
        }

        Field this[Coord c]
        {
            get { return field.Board[field.Coord + c]; }
        }
    }
}
