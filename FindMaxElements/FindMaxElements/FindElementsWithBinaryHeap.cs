using System;
using System.Collections.Generic;
using System.Text;
using FindMaxElements.IO;

namespace FindMaxElements
{
    class FindElementsWithBinaryHeap<T> : FindElements<T>
        where T: IComparable<T>
    {
        BinaryHeap<T> binaryHeap;

        int _amountMax;
        public FindElementsWithBinaryHeap(T[] array, int amountMax)
        {
            _amountMax = amountMax;
            maxElements = new T[_amountMax];
            binaryHeap = new MaxHeap<T>(array);
        }
        public override void SeekMaxElements()
        {
            maxElements = binaryHeap.HeapSort(_amountMax);
        }

    }
}
