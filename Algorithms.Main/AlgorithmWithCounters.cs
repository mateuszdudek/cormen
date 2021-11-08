using Algorithms.Sorting;
using System.Collections.Generic;

namespace AlgorithmsTests
{
    public class AlgorithmWithCounters
    {
        public AlgorithmWithCounters(ISort<ComparisionCounting<int>> algorithmName)
        {
            Algorithm = algorithmName;
            PermutationNo = new Counter();
            ComparisionNo = new Counter();
        }

        public void ComparisionNoPush()
        {
            lock (_comparisionNoStats)
            {
                var key = ComparisionNo.Value;
                if (!_comparisionNoStats.ContainsKey(key)) _comparisionNoStats.Add(key, 0);
                ++_comparisionNoStats[key];

                ComparisionNo.Reset();
            }
        }

        public void ChangeProblemSizeAndResetCounters(int problemSize)
        {
            ProblemSize = problemSize;
            lock (_comparisionNoStats)
            {
                _comparisionNoStats = new Dictionary<int, int>();
            }
        }

        private Dictionary<int, int> _comparisionNoStats = new Dictionary<int, int>();
        public Dictionary<int, int> GetComparisionNoStatsCopy() 
        { 
            lock (_comparisionNoStats)
            {
                return new Dictionary<int, int>(_comparisionNoStats);
            }
        }
        public ISort<ComparisionCounting<int>> Algorithm { get; }
        public Counter PermutationNo { get; }
        public Counter ComparisionNo { get; }
        public int ProblemSize { get; private set; }
    }
}
