using System.Collections.Generic;

namespace Algorithms.Graph
{
    public class UndirectedAdjacencyListGraph<T> : Dictionary<T, HashSet<T>>
    {
        public UndirectedAdjacencyListGraph(IEnumerable<T> vertices, IEnumerable<(T, T)> edges)
        {
            foreach (var vertex in vertices) Add(vertex, new HashSet<T>());
            foreach (var edge in edges) AddEdge(edge);
        }

        private void AddEdge((T e1, T e2) edge)
        {
            this[edge.e1].Add(edge.e2);
            this[edge.e2].Add(edge.e1);
        }
    }
}
