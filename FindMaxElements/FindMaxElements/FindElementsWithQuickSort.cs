using System;
using System.Collections.Generic;
using System.Text;

namespace FindMaxElements
{
    class FindElementsWithQuickSort<T>: FindElements<T>
        where T: IComparable<T>
    {
        T[] elements;
        int _amountMax;
        public FindElementsWithQuickSort(T[] sourseArray, int amountMax)
        {
            _amountMax = amountMax;
            elements = sourseArray;
            maxElements = new T[_amountMax];
        }
        public override void SeekMaxElements()
        {
            Sort(0, elements.Length - 1);
            Array.Copy(elements, 0, maxElements, 0, _amountMax);
        }
        public void Sort(int l, int r)
        {
            int i = r;
            int j = l;
            T x = elements[(l + r) / 2];
            while (j <= i)
            {
                while (elements[i].CompareTo(x) < 0) i--;
                while (elements[j].CompareTo(x) > 0) j++;

                if (j <= i)
                {
                    Swap(elements, i, j);
                    i--;
                    j++;
                }
            }
            if (l < i) Sort(l, i);
            if (j < r) Sort(j, r);
        }
        
    }
}
