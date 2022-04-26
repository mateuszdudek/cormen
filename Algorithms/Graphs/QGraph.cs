using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Graphs
{
    public class QGraph : Dictionary<string, Dictionary<string, int>>
    {
        public QGraph(IEnumerable<(string from, string to)> edges)
        {
            foreach(var edge in edges)
            {
                if (!this.ContainsKey(edge.from)) this.Add(edge.from, new Dictionary<string, int>());
                if (!this[edge.from].ContainsKey(edge.to)) this[edge.from].Add(edge.to, 0);
                this[edge.from][edge.to]++;
            }
        }
    }

    public class QSolution
    {
        public bool DFS(QGraph graph, int noTrips, string start, string end)
        {
            if (noTrips == 0) return start == end;
            if (!graph.ContainsKey(start)) return false;
            
            foreach (var to in graph[start].Where(e => e.Value > 0).ToArray())
            {
                graph[start][to.Key]--;
                if (DFS(graph, noTrips - 1, to.Key, end)) return true;
                graph[start][to.Key]++;
            }

            return false;
        }

        public bool HasConnection(IEnumerable<(string from, string to)> edges, int noTrips, string start, string end)
        {
            var graph = new QGraph(edges);
            return DFS(graph, noTrips, start, end);
        }
    }
}
