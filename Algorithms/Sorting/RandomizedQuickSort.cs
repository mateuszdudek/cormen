using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class RandomizedQuickSort<T> : QuickSort<T> where T : IComparable<T>
    {
        Random _random = new Random();

        protected override int Partition(List<T> toSort, int startIndex, int endIndex)
        {
            int rnd = _random.Next(startIndex, endIndex - 1);
            Swap(toSort, rnd, endIndex);
            return base.Partition(toSort, startIndex, endIndex);
        }
    }
}
