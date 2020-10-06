using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FindMaxElements
{
    class FindElementsWithSortedSet<T> : FindElements<T>
        where T : IComparable<T>
    {
        SortedSet<ElemsForSort<T>> _set;
        T[] _sourse;
        int _amountMax;

        public FindElementsWithSortedSet(T[] sourse, int amount)
        {
            _sourse = sourse;
            _amountMax = amount;
            _set = new SortedSet<ElemsForSort<T>>(new SortNumbersIndex<T>());
        }

        public override void PrintElems()
        {
            foreach (var el in _set)
                Console.Write($"{el.Value} ");
            Console.WriteLine();
        }

        public override void SeekMaxElements()
        {
            for (int i = 0; i < _sourse.Length; i++)
            {
                var pair = new ElemsForSort<T>(_sourse[i], i);
                if (_set.Count < _amountMax)
                {
                    _set.Add(pair);
                }
                else if (_sourse[i].CompareTo(_set.Max.Value) == 1)
                {
                    _set.Remove(_set.Max);
                    _set.Add(pair);
                }
            }
        }

    }

    class SortNumbersIndex<T> : Comparer<ElemsForSort<T>>
        where T : IComparable<T>
    {
        public override int Compare([AllowNull] ElemsForSort<T> x, [AllowNull] ElemsForSort<T> y)
        {
            if (x.Value.CompareTo(y.Value) != 0) return -x.Value.CompareTo(y.Value);
            return x.Index.CompareTo(y.Index);
        }
    }
    public struct ElemsForSort<T>
        where T : IComparable<T>
    {
        public readonly T Value;
        public readonly int Index;

        public ElemsForSort(T value, int index)
        {
            Value = value;
            Index = index;
        }
    }
}
