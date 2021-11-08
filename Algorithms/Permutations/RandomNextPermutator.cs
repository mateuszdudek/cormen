using System;
using System.Collections.Generic;

namespace Algorithms.Permutations
{
    public class RandomNextPermutator<T>
    {
        Random _random;
        public RandomNextPermutator()
        {
            _random = new Random();
        }

        public RandomNextPermutator(int seed)
        {
            _random = new Random(seed);
        }

        public IEnumerable<List<T>> GetAllPermutations(IEnumerable<T> input)
        {
            while (true)
            {
                var ret = new List<T>(input);
                for (int i = 0; i < ret.Count; ++i)
                {
                    Swap(ret, i, _random.Next(ret.Count - 1));
                }
                yield return ret;
            }
        }

        private void Swap(List<T> input, int i, int j)
        {
            T temp = input[i];
            input[i] = input[j];
            input[j] = temp;
        }
    }
}
