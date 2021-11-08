using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorting
{
    public class MergeSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            Sort(toSort, 0, toSort.Count);
        }

        private void Sort(List<T> toSort, int from, int to)
        {
            if (to - from > 1)
            {
                int mid = (from + to) / 2;
                Sort(toSort, from, mid);
                Sort(toSort, mid, to);
                Merge(toSort, from, mid, to);
            }
        }

        private void Merge(List<T> toSort, int firstIndex, int mid, int lastIndex)
        {
            int leftSize = mid - firstIndex;
            T[] leftTemp = new T[leftSize];
            for (int i = 0; i < leftSize; ++i)
                leftTemp[i] = toSort[i + firstIndex];

            int rightSize = lastIndex - mid;
            T[] rightTemp = new T[rightSize];
            for (int i = 0; i < rightSize; ++i)
                rightTemp[i] = toSort[i + mid];

            int l = 0, r = 0;
            for (int i = firstIndex; i < lastIndex; ++i)
            {
                if (r == rightSize)
                {
                    toSort[i] = leftTemp[l];
                    ++l;
                    continue;
                }

                if (l == leftSize)
                {
                    toSort[i] = rightTemp[r];
                    ++r;
                    continue;
                }

                if (leftTemp[l].CompareTo(rightTemp[r]) == -1)
                {
                    toSort[i] = leftTemp[l];
                    ++l;
                } 
                else
                {
                    toSort[i] = rightTemp[r];
                    ++r;
                }
            }
        }
    }
}
