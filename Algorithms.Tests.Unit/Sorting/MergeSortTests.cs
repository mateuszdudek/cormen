using Algorithms.Permutations;
using Algorithms.Sorting;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Tests.Unit.Sorting
{
    public class MergeSortTests
    {
        [Test]
        public void BasicSortTest()
        {
            var data = new List<int> { 5, 4, 2, 3, 1 };
            var sortingAlgorithm = new MergeSort<int>();

            sortingAlgorithm.Sort(data);

            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, data);
        }

        [Test]
        public void SortingUsesComparision()
        {
            var data = new List<ComparisionCounting<int>> { 5, 4, 3, 2, 1 };
            var sortingAlgorithm = new MergeSort<ComparisionCounting<int>>();

            Assert.That(data.Sum(d => d.Comparisions), Is.EqualTo(0));

            sortingAlgorithm.Sort(data);

            Assert.That(data.Sum(d => d.Comparisions), Is.GreaterThan(0));
        }

        [Test]
        public void CheckAllPossibleInput()
        {
            var data = new List<ComparisionCounting<int>>();
            data.AddRange(Enumerable.Range(1, 9).Select(x => new ComparisionCounting<int>(x)));
            var permutator = new HeapAlgorithm<ComparisionCounting<int>>();
            var permutations = permutator.GetAllPermutations(data);
            var sortingAlgorithm = new MergeSort<ComparisionCounting<int>>();

            int permutationNo = 1;
            int lastComparisions = 0;
            foreach (var input in permutations)
            {
                sortingAlgorithm.Sort(input);
                int currentComparisions = data.Sum(d => d.Comparisions);
                TestContext.WriteLine($"PermutationNo: {permutationNo++}, Comparisions: {currentComparisions - lastComparisions}");
                lastComparisions = currentComparisions;
            }
        }
    }
}
