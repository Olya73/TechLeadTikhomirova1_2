
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace FindMaxElements
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] init = new int[10000];
            int amountMax = 3;

            Random rnd = new Random();
            for (int i = 0; i < init.Length; i++)
                init[i] = rnd.Next(-10000000, 10000000);

            FindElements<int> fel = new FindElementsWithBinaryHeap<int>(init, amountMax);
            Console.WriteLine($"Time spend to find with heap: " +
                $"{TimeOfSearchingMaxElements(fel)}"
                );
            fel.PrintElems();

            fel = new FindElementsWithSortedSet<int>(init, amountMax);
            Console.WriteLine($"Time spend to find with heap: " +
                $"{TimeOfSearchingMaxElements(fel)}"
                );
            fel.PrintElems();

            fel = new FindElementsWithSelection<int>(init, amountMax);
            Console.WriteLine($"Time spend to find with selection: " +
                $"{TimeOfSearchingMaxElements(fel)}"
                );
            fel.PrintElems();

            fel = new FindElementsWithQuickSort<int>(init, amountMax);
            Console.WriteLine($"Time spend find with quick sort: " +
                $"{TimeOfSearchingMaxElements(fel)}"
                );
            fel.PrintElems();

            Console.ReadKey();
        }
        public static TimeSpan TimeOfSearchingMaxElements(FindElements<int> findElem)
        {
            Stopwatch stpw = new Stopwatch();
            stpw.Start();

            findElem.SeekMaxElements();

            stpw.Stop();

            return stpw.Elapsed;
        }
        public static int ParseInt(string input)
        {
            int value;
            if (Int32.TryParse(input, out value))
                return value;
            else
                return -1;
        }
    }
}
