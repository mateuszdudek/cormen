using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class InsertionSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            for (int i = 1; i < toSort.Count; ++i)
            {
                T key = toSort[i];
                int j = i - 1;
                for (; j >= 0 && key.CompareTo(toSort[j]) == -1; --j)
                    toSort[j + 1] = toSort[j];
                toSort[j + 1] = key;
            }
        }
    }
}
