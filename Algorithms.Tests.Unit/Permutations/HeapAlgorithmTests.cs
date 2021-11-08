using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Permutations;

namespace AlgorithmTestsUnit.Permutations
{
    public class HeapAlgorithmTests
    {
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        public void NumberorPermutationsIsEqualToFactorialLegth(int numberOfElements)
        {
            var sut = new HeapAlgorithm<int>();
            List<int> input = Enumerable.Range(1, numberOfElements).ToList();

            List<int>[] ret = sut.GetAllPermutations(input).ToArray();

            Assert.That(ret.Length, Is.EqualTo(Factorial(input.Count)));
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(7)]
        public void EachPermutationIsDifferent(int numberOfElements)
        {
            var sut = new HeapAlgorithm<int>();
            List<int> input = Enumerable.Range(1, numberOfElements).ToList();

            List<int>[] ret = sut.GetAllPermutations(input).ToArray();

            for (int i = 0; i < input.Count; ++i)
            {
                for (int j = i + 1; j < input.Count; ++j)
                {
                    CollectionAssert.AreNotEqual(ret[i], ret[j]);
                }
            }
        }

        [TestCase(15)]
        [Ignore("Long lasting test (~7s), not suitable to CI")]
        public void HugePermutationNumberDoesNotCauseStackOverflow(int numberOfElements)
        {
            var sut = new HeapAlgorithm<int>();
            List<int> input = Enumerable.Range(1, numberOfElements).ToList();

            IEnumerable<List<int>> ret = sut.GetAllPermutations(input);

            foreach (var row in ret)
                Assert.That(row.Count, Is.EqualTo(numberOfElements));
        }

        private int Factorial(int n)
        {
            if (n == 1) return 1;
            return n * Factorial(n-1);
        }
    }
}