
using System;
using System.Collections.Generic;
using System.Text;

namespace FindMaxElements
{
    class FindElementsWithSelection<T> : FindElements<T>
        where T : IComparable<T>
    {
        T[] elements;
        int _amountMax;
        public FindElementsWithSelection(T[] sourseArray, int amountMax)
        {
            _amountMax = amountMax;
            elements = sourseArray;
            maxElements = new T[_amountMax];
        }
        public override void SeekMaxElements()
        {
            T max;
            int kmax; 
            for (int i = 0; i < _amountMax; i++)
            {
                max = elements[i];
                kmax = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[j].CompareTo(max) > 0)
                    {
                        max = elements[j]; kmax = j;
                    }
                }
                Swap(elements, i, kmax);
                maxElements[i] = max;
            }
        }        
    }
}
