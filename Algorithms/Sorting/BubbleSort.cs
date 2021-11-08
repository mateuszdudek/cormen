using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{

    public class BubbleSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            for (int last = toSort.Count - 1; last >= 0; --last)
                for (int i = 0; i < last; ++i)
                    if (toSort[i].CompareTo(toSort[i + 1]) > 0)
                        Swap(toSort, i, i + 1);
        }

        private void Swap(List<T> toSort, int i, int v)
        {
            T temp = toSort[i];
            toSort[i] = toSort[v];
            toSort[v] = temp;
        }
    }
}
