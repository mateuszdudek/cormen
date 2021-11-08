using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Algorithms.Permutations
{
    public class HeapAlgorithm<T>
    { 
        [Pure]
        public IEnumerable<List<T>> GetAllPermutations(IEnumerable<T> input)
        {
            var localCopy = new List<T>(input);
            return InternalGetAllPermutations(localCopy.Count, localCopy);
        }

        private IEnumerable<List<T>> InternalGetAllPermutations(int k, List<T> input)
        {
            if (k == 1)
                yield return new List<T>(input);
            else
                foreach (var row in InternalGetAllPermutations(k - 1, input))
                    yield return row;
            
            for (int i = 0; i < k - 1; ++i)
            {
                if (k % 2 == 0) 
                    Swap(input, i, k - 1);
                else 
                    Swap(input, 0, k - 1);

                foreach (var row in InternalGetAllPermutations(k - 1, input))
                    yield return row;
            }
        }

        private static void Swap(List<T> input, int a, int b)
        {
            T temp = input[a];
            input[a] = input[b];
            input[b] = temp;
        }
    }
}
