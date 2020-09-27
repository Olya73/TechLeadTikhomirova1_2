using System;
using System.Collections.Generic;
using System.Text;

namespace FindMaxElements
{
    class MaxHeap<T> : BinaryHeap<T>
        where T : IComparable<T>
    {
        public MaxHeap(T[] sourseArray): base(sourseArray){}
        public override bool DefinitionHeap(int child, int largestChild)
        {
            return list[child].CompareTo(list[largestChild]) >= 0;
        }
    }
}
