using Algorithms.DataStructures;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithm.Tests.Unit.DataStructures
{
    public class HeapTests
    {
        [Test]
        public void GetParent()
        {
            //             a
            //          /      \
            //       b            c
            //     /  \          /  \
            //   d      e      f      g
            //  / \    / \    / \    / \
            // h   i  j   k  l   m  n   o

            List<char> heap = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };

            Assert.That(Heap.Parent(heap.IndexOf('d')), Is.EqualTo(heap.IndexOf('b')));
            Assert.That(Heap.Parent(heap.IndexOf('n')), Is.EqualTo(heap.IndexOf('g')));
            Assert.That(Heap.Parent(heap.IndexOf('c')), Is.EqualTo(heap.IndexOf('a')));
        }

        [Test]
        public void GetLeft()
        {
            //             a
            //          /      \
            //       b            c
            //     /  \          /  \
            //   d      e      f      g
            //  / \    / \    / \    / \
            // h   i  j   k  l   m  n   o

            List<char> heap = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };

            Assert.That(Heap.Left(heap.IndexOf('d')), Is.EqualTo(heap.IndexOf('h')));
            Assert.That(Heap.Left(heap.IndexOf('e')), Is.EqualTo(heap.IndexOf('j')));
            Assert.That(Heap.Left(heap.IndexOf('a')), Is.EqualTo(heap.IndexOf('b')));
        }

        [Test]
        public void GetRight()
        {
            //             a
            //          /      \
            //       b            c
            //     /  \          /  \
            //   d      e      f      g
            //  / \    / \    / \    / \
            // h   i  j   k  l   m  n   o

            List<char> heap = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };

            Assert.That(Heap.Right(heap.IndexOf('d')), Is.EqualTo(heap.IndexOf('i')));
            Assert.That(Heap.Right(heap.IndexOf('g')), Is.EqualTo(heap.IndexOf('o')));
            Assert.That(Heap.Right(heap.IndexOf('a')), Is.EqualTo(heap.IndexOf('c')));
        }

        [Test]
        public void MaxHeapifyFixesMax()
        {
            //             3
            //          /      \
            //       6            2
            //     /  \          /  \
            //    2    5        2    5

            List<int> heap = new List<int>() { 3, 6, 2, 2, 5, 2, 5 };

            heap.MaxHeapify(0, heap.Count);

            Assert.That(heap[0], Is.EqualTo(6));
            Assert.That(heap[1], Is.EqualTo(5));
            Assert.That(heap[4], Is.EqualTo(3));

            // Part of heap which reamin unchanged
            Assert.That(heap[2], Is.EqualTo(2));
            Assert.That(heap[5], Is.EqualTo(2));
            Assert.That(heap[6], Is.EqualTo(5));
            Assert.That(heap[3], Is.EqualTo(2));
        }

        [Test]
        public void BuildMaxHeap()
        {
            //             3
            //          /      \
            //       7            2
            //     /  \          /  \
            //    6    5        1    4

            List<int> heap = new List<int>() { 3, 7, 2, 6, 5, 1, 4 };

            heap.BuildMaxHeap(heap.Count);
            
            //             7
            //          /      \
            //       6            4
            //     /  \          /  \
            //    3    5        1    2

            CollectionAssert.AreEquivalent(heap, new[] { 7, 6, 4, 3, 5, 1, 2 });
        }
    }
}
