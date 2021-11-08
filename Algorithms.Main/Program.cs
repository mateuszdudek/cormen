using Algorithms.Permutations;
using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var algorithms = new ISort<ComparisionCounting<int>>[]
            {
                new HeapSort<ComparisionCounting<int>>(),
                new BubbleSort<ComparisionCounting<int>>(),
                new QuickSort<ComparisionCounting<int>>(),
                new RandomizedQuickSort<ComparisionCounting<int>>(),
                new InsertionSort<ComparisionCounting<int>>(),
                new CsSort<ComparisionCounting<int>>(),
                new LinqSort<ComparisionCounting<int>>(),
                new MergeSort<ComparisionCounting<int>>()
            };

            var algorithmsWithStatistics = algorithms.Select(a => new AlgorithmWithCounters(a)).ToArray();
            int minProblemSize = 1;
            int maxProblemSize = 12;

            string directory = $"Results" + Path.DirectorySeparatorChar.ToString() + MakeValidFileName($"{DateTime.UtcNow:u}");

            var jobs = algorithmsWithStatistics
                .Select(a => new Task(() => RunTests(a, minProblemSize, maxProblemSize, directory)))
                .ToList();

            CancellationTokenSource programFinished = new CancellationTokenSource();
            var screen = new Task(() => new Screen(60, 50, programFinished.Token, algorithmsWithStatistics).Draw());
            screen.Start();

            jobs.ForEach(t => t.Start());

            await Task.WhenAll(jobs.ToArray());
            programFinished.Cancel();
        }

        public static void RunTests(AlgorithmWithCounters sortingAlgorithm, int minProblemSize, int maxProblemSize, string saveDir)
        {
            for (int i = minProblemSize; i <= maxProblemSize; ++i)
                RunTest(sortingAlgorithm, i, saveDir);
        }

        public static void RunTest(AlgorithmWithCounters sortingAlgorithm, int problemSize, string saveDir)
        {
            var data = new List<ComparisionCounting<int>>();
            data.AddRange(Enumerable.Range(1, problemSize).Select(x => new ComparisionCounting<int>(x, sortingAlgorithm.ComparisionNo)));
            var permutator = new RandomNextPermutator<ComparisionCounting<int>>();
            var heapAlgorithm = new HeapAlgorithm<ComparisionCounting<int>>();
            sortingAlgorithm.ChangeProblemSizeAndResetCounters(problemSize);

            foreach (var input in heapAlgorithm.GetAllPermutations(data))
            {
                sortingAlgorithm.PermutationNo.Increment();
                sortingAlgorithm.Algorithm.Sort(input);

                sortingAlgorithm.ComparisionNoPush();
            }

            string filename = MakeValidFileName($"{sortingAlgorithm.Algorithm.Name}_{problemSize}");
            string fullPath = saveDir + Path.DirectorySeparatorChar.ToString() + filename + ".csv";
            Directory.CreateDirectory(saveDir);

            File.WriteAllText(fullPath, PrintSortingStats(sortingAlgorithm));
        }

        private static string MakeValidFileName(string name)
        {
            string invalidChars = System.Text.RegularExpressions.Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return System.Text.RegularExpressions.Regex.Replace(name, invalidRegStr, "_");
        }

        private static string PrintSortingStats(AlgorithmWithCounters algorithm)
        {
            Dictionary<int, int> copy = algorithm.GetComparisionNoStatsCopy();
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Number of comparisions,How many times");

            foreach (var row in copy.ToList().OrderBy(a => a.Key))
                builder.AppendLine($"{row.Key},{row.Value}");
            return builder.ToString();
        }
    }
}
