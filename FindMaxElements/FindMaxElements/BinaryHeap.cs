using System;
using System.Collections.Generic;
using System.Text;


namespace FindMaxElements
{
    abstract public class BinaryHeap<T> where T : IComparable<T>
    {
        public List<T> list { get; private set; }
        public int heapSize { get { return this.list.Count; } }
        public int heapHeight { get { return (int)Math.Log2(heapSize); } }
        public BinaryHeap(T[] sourceArray)
        {
            BuildHeap(sourceArray);
        }
        public void BuildHeap(T[] sourceArray)
        {
            list = new List<T>(sourceArray);
            for (int i = heapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }
        public void Heapify(int i)
        {
            int left, 
                right,
                largest;

            while(true)
            {
                left = 2 * i + 1;
                right = 2 * i + 2;
                largest = i;

                if (left < heapSize && DefinitionHeap(left, largest))
                    largest = left;

                if (right < heapSize && DefinitionHeap(right, largest))
                    largest = right;

                if (largest == i)
                    break;

                T temp = list[i];
                list[i] = list[largest];
                list[largest] = temp;
                i = largest;
            }
        }
        public abstract bool DefinitionHeap(int child, int largeChild);

        public T[] HeapSort(int? amount = null)
        {
            int size = amount ?? heapSize;
            T[] array = new T[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = GetMax();
                Heapify(0);
            }
            return array;
        }

        public T GetMax()
        {
            T result = list[0];
            list[0] = list[heapSize - 1];
            list.RemoveAt(heapSize - 1);
            return result;
        }
    }
}
