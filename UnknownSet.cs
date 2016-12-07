using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    class UnknownSet
    {
        public UnknownSet(HashSet<Field> fields, int min, int max)
        {
            this.Min = int.MinValue;
            this.Max = int.MaxValue;
            this.fields = fields;
            this.Update(min, max);
        }
        HashSet<Field> fields;
        public int Max { get; private set; }
        public int Min { get; private set; }

        //public static void Intersection(UnknownSet a, UnknownSet b, List<UnknownSet> sets)
        //{
        //    HashSet<Field> newFieldSet = new HashSet<Field>(a.fields);
        //    newFieldSet.IntersectWith(b.fields);

        //    if (newFieldSet.Count == 0) { return; }

        //    int aCount = a.fields.Count;
        //    int bCount = b.fields.Count;
        //    int newCount = newFieldSet.Count;

        //    int minA = a.Min - (aCount - newCount);
        //    int maxA = a.Max;

        //    int minB = b.Min - (bCount - newCount);
        //    int maxB = b.Max;

        //    int min = JRapp.Numeric.Max(0, minA, minB);
        //    int max = JRapp.Numeric.Min(newCount, maxA, maxB);

        //    UnknownSet finalSet;
        //    if (newCount == aCount) { a.Update(min, max); finalSet = a; }
        //    else if (newCount == bCount) { b.Update(min, max); finalSet = b; }
        //    else { finalSet = AddOrUpdateSet(new UnknownSet(newFieldSet, min, max), sets); }

        //    var newAComp = new HashSet<Field>(a.fields);
        //    newAComp.ExceptWith(finalSet.fields);
        //}

        //public static void Partial(UnknownSet a, UnknownSet b, List<UnknownSet> sets, bool rev = true)
        //{
        //    HashSet<Field> newFieldSet = new HashSet<Field>(a.fields);
        //    newFieldSet.IntersectWith(b.fields);

        //    if (newFieldSet.Count == 0) { return; }
            
        //    int aCount = a.fields.Count;
        //    int bCount = b.fields.Count;
        //    int newCount = newFieldSet.Count;

        //    int min = a.Min - b.Max;
        //    int max = a.Max - b.Min;

        //    if      (newCount == aCount) { a.Update(min, max); } 
        //    else if (newCount == bCount) { b.Update(min, max); }
        //    else { AddOrUpdateSet(new UnknownSet(newFieldSet, min, max), sets); }

        //    if (rev) { Partial(b,a,sets,false); }
        //}

        public static void Compute(UnknownSet a, UnknownSet b, WorkingSets sets)
        {
            int C_a = a.fields.Count;
            int C_b = b.fields.Count;

            var set = Process(a, b, sets, operation: (a_, b_) => a_.IntersectWith(b_),
                min: (nS) => JRapp.Numeric.Max(0, a.Min - (C_a - nS.Count), b.Min - (C_b - nS.Count)),
                max: (nS) => JRapp.Numeric.Min(nS.Count, a.Max, b.Max)
                );

            if (set == null) return;

            Process(a, set, sets, operation: (a_, nS) => a_.ExceptWith(nS),
                min: (nS) => JRapp.Numeric.Max(a.Min - set.Max, 0),
                max: (nS) => JRapp.Numeric.Min(a.Max - set.Min, nS.Count)
                );

            Process(b, set, sets, operation: (b_, nS) => b_.ExceptWith(nS),
                min: (nS) => JRapp.Numeric.Max(b.Min - set.Max, 0),
                max: (nS) => JRapp.Numeric.Min(b.Max - set.Min, nS.Count)
                );
        }

        public static UnknownSet Process(UnknownSet a, UnknownSet b,
            WorkingSets sets,
            Action<HashSet<Field>, HashSet<Field>> operation,
            Func<HashSet<Field>, int> min, Func<HashSet<Field>, int> max)
        {
            HashSet<Field> newFieldSet = new HashSet<Field>(a.fields);
            operation(newFieldSet, b.fields);

            if (newFieldSet.Count == 0) { return null; }

            int aCount = a.fields.Count;
            int bCount = b.fields.Count;
            int newCount = newFieldSet.Count;

            int myMin = min(newFieldSet);
            int myMax = max(newFieldSet);

            UnknownSet finalSet = AddOrUpdateSet(new UnknownSet(newFieldSet, myMin, myMax), sets);
            return finalSet;
        }


        public void Update(int min, int max)
        {
            Min = Math.Max(Min, min);
            Max = Math.Min(Max, max);
        }

        public static UnknownSet AddOrUpdateSet(UnknownSet newSet, WorkingSets sets)
        {
            {
            }
            
            var existingSet = sets.Find(newSet);
            if (existingSet != null)
            {
                existingSet.Update(newSet.Min, newSet.Max);
                return existingSet;
            }
            else
            {
                sets.Add(newSet);
                return newSet;
            }
        }

        public IEnumerable<Field> TryFindMine()
        {
            if (Max == 0)
            {
                foreach (var f in fields)
                    f.Uncover();
                return fields;
            }

            if (Min == fields.Count)
            {
                foreach (var f in fields)
                {
                    f.Flag();
                }
            }

            return Enumerable.Empty<Field>();
        }

        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            b.Append("{");
            foreach (var f in fields)
            {
                b.Append(f.Coord.ToString());
                b.Append(",");
            }
            b.Append("}");
            return b.ToString();
        }

        public override int GetHashCode()
        {
            return fields.GetHashCode();
        }

        public class WorkingSets : IEnumerable<UnknownSet>
        {
            List<UnknownSet> sets = new List<UnknownSet>();
            Dictionary<Field, List<UnknownSet>> nearbySets = new Dictionary<Field, List<UnknownSet>>();

            public void Add(UnknownSet s)
            {
                sets.Add(s);

                foreach (var f in s.fields)
                {
                    if (!nearbySets.ContainsKey(f))
                        nearbySets.Add(f,new List<UnknownSet>());
                    nearbySets[f].Add(s);
                }
            }

            public int Count { get { return sets.Count; } }

            public UnknownSet this[int i]
            {
                get
                {
                    return sets[i];
                }
            }

            public IEnumerator<UnknownSet> GetEnumerator()
            {
                return sets.GetEnumerator();
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            internal UnknownSet Find(UnknownSet newSet)
            {
                var fs = newSet.fields;
                List<UnknownSet> l;
                if (nearbySets.TryGetValue(fs.First(), out l))
                    return l.Where(s => s.fields.SetEquals(newSet.fields)).SingleOrDefault();
                else
                    return null;
            }
        }
    }
}
