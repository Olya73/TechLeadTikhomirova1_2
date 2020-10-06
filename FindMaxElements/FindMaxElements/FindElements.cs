using System;
using System.Collections.Generic;
using System.Text;


namespace FindMaxElements
{
    abstract class FindElements<T> where T: IComparable<T>
    {
        protected T[] maxElements;
        public abstract void SeekMaxElements();  
        public virtual void PrintElems()
        {
            foreach(var i in maxElements)
            {
                Console.Write($"{i} ");                
            }
            Console.WriteLine();
        }
        public void Swap(T[] elements, int i, int j)
        {
            T temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }
    }
}
