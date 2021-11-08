using Algorithms.Graph;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Algorithms.Graphs
{
    public class Search
    {
        [Pure]
        public static IEnumerable<T> BFS<T>(UndirectedAdjacencyListGraph<T> graph, T start)
        {
            Queue<T> q = new Queue<T>();
            HashSet<T> visited = new HashSet<T>();
            q.Enqueue(start);
            
            while (q.TryDequeue(out T visiting))
            {
                if (visited.Contains(visiting)) continue;
                visited.Add(visiting);
                yield return visiting;
                foreach (var v in graph[visiting])
                    if (!visited.Contains(v))
                        q.Enqueue(v);
            }
        }

        [Pure]
        public static IEnumerable<T> DFS<T>(UndirectedAdjacencyListGraph<T> graph, T start)
        {
            Stack<T> q = new Stack<T>();
            HashSet<T> visited = new HashSet<T>();
            q.Push(start);

            while (q.TryPop(out T visiting))
            {
                if (visited.Contains(visiting)) continue;
                visited.Add(visiting);
                yield return visiting;
                foreach (var v in graph[visiting])
                    if (!visited.Contains(v))
                        q.Push(v);
            }
        }
    }
}
