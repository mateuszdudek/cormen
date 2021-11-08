using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class QuickSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            Sort(toSort, 0, toSort.Count - 1);
        }

        protected virtual int Partition(List<T> toSort, int startIndex, int endIndex)
        {
            T divider = toSort[endIndex];
            int dividerPosition = startIndex - 1;
            for (int i = startIndex; i < endIndex; ++i)
            {
                if (toSort[i].CompareTo(divider) != 1)
                {
                    ++dividerPosition;
                    Swap(toSort, dividerPosition, i);
                }
            }
            ++dividerPosition;
            Swap(toSort, dividerPosition, endIndex);
            return dividerPosition;
        }

        protected void Sort(List<T> toSort, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int divider = Partition(toSort, startIndex, endIndex);
                Sort(toSort, startIndex, divider - 1);
                Sort(toSort, divider + 1, endIndex);
            }
        }

        protected void Swap(List<T> toSort, int x, int y)
        {
            T temp = toSort[x];
            toSort[x] = toSort[y];
            toSort[y] = temp;
        }
    }
}
