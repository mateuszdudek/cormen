using System;
using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public static class Heap
    {
        public static int Parent(int i) => (i - 1) / 2;

        public static int Left(int i) => (i + 1) * 2 - 1;

        public static int Right(int i) => (i + 1) * 2;

        public static void MaxHeapify<T>(this List<T> heap, int i, int heapSize) where T : IComparable<T>
        {
            int left = Left(i);
            int right = Right(i);
            int largest = i;

            if (left < heapSize && heap[left].CompareTo(heap[largest]) > 0) 
                largest = left;
            if (right < heapSize && heap[right].CompareTo(heap[largest]) > 0)
                largest = right;

            if (largest != i)
            {
                heap.Swap(i, largest);
                heap.MaxHeapify(largest, heapSize);
            }
        }

        public static void BuildMaxHeap<T>(this List<T> heap, int heapSize) where T : IComparable<T>
        {
            for (int i = heapSize / 2; i >= 0; --i)
                heap.MaxHeapify(i, heapSize);
        }

        public static void Swap<T>(this List<T> heap, int i, int j)
        {
            T temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }
    }
}
