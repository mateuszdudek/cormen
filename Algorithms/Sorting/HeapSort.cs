using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public class HeapSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> heap)
        {
            var heapSize = heap.Count;
            heap.BuildMaxHeap(heapSize);
            
            for(int i = heapSize - 1; i > 0; --i)
            {
                heap.Swap(0, i);
                --heapSize;
                heap.MaxHeapify(0, heapSize);
            }
        }        
    }
}
