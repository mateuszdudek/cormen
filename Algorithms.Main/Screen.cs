using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AlgorithmsTests
{
    public class Screen
    {
        private readonly CancellationToken _cancellationToken;
        AlgorithmWithCounters[] _algorithms;

        public Screen(
            int width, 
            int height,
            CancellationToken token,
            params AlgorithmWithCounters[] algorithms)
        {
            _cancellationToken = token;
            _algorithms = algorithms;

            Console.CursorVisible = false;
            Console.SetWindowSize(width, height);
        }

        public void Draw()
        {
            int lastPrintedRows = 0;
            int multiplier = 1;
            int lastHeight = Console.WindowHeight;
            bool shouldClear = false;
            while (!_cancellationToken.IsCancellationRequested)
            {
                string buffer = BuildResponse(multiplier);
                int newRows = buffer.ToCharArray().Count(c => c == '\n');

                if (lastPrintedRows != newRows || lastHeight != Console.WindowHeight)
                {
                    lastHeight = Console.WindowHeight;

                    shouldClear = true;
                    for (int i = 1; i < int.MaxValue; i*=2)
                    {
                        if (i == 0) break;

                        buffer = BuildResponse(i);
                        newRows = buffer.ToCharArray().Count(c => c == '\n');

                        if (newRows < Console.WindowHeight)
                        {
                            multiplier = i;
                            break;
                        }
                    }

                    lastPrintedRows = newRows;
                }

                if (shouldClear)
                {
                    shouldClear = false;
                    Clear();
                }
                Console.SetCursorPosition(0, 0);
                Console.Out.Write(buffer);
            }
        }

        private void Clear()
        {
            Console.CursorVisible = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Console.WindowHeight; ++i)
                sb.AppendLine(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 0);
            Console.Out.Write(sb.ToString());
        }

        private string BuildResponse(int multiplier)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var a in _algorithms.OrderByDescending(a => a.PermutationNo.Value))
            {
                sb.AppendLine(Center(a.Algorithm.Name, 40));
                sb.AppendLine($"  ProblemSize: {a.ProblemSize,25}");
                sb.AppendLine($"  PermutationNo: {a.PermutationNo.Value,23}");
                sb.AppendLine($"  Number of comparision : Size of bucket");

                var comparisionNoStats = a.GetComparisionNoStatsCopy();

                if (multiplier == 1)
                {
                    foreach (var row in comparisionNoStats.OrderBy(a => a.Key))
                    {
                        sb.AppendLine($"    [{row.Key,6}] : {row.Value,8}");
                    }
                }
                else
                {
                    foreach (var row in Merge(comparisionNoStats, multiplier))
                    {
                        sb.AppendLine($"    [{row.Key,6} +{multiplier,2}] : {row.Value,8}");
                    }
                }

            }
            return sb.ToString();
        }

        private string Center(string text, int width)
        {
            var center = width / 2;
            var startPos = center - text.Length / 2;
            return new string(' ', startPos) + text;
        }

        private IOrderedEnumerable<KeyValuePair<int, int>> Merge(Dictionary<int, int> source, int multiplier)
        {
            Dictionary<int, int> ret = new Dictionary<int, int>();
            foreach(var row in source)
            {
                int key = (row.Key / multiplier) * multiplier;
                if (!ret.ContainsKey(key)) ret.Add(key, 0);
                ret[key] += row.Value;
            }
            return ret.ToList().OrderBy(a => a.Key);
        }
    }
}
