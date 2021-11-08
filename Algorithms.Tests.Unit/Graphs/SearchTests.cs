using Algorithms.Graph;
using Algorithms.Graphs;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Tests.Unit.Graphs
{
    public class SearchTests
    {
        // 1 - 2 - 3
        //  \
        //   \ 4 - 5
        [Test]
        public void when_use_bfs_fathest_verticle_is_returned_last()
        {
            var sut = new UndirectedAdjacencyListGraph<int>(
                new[] { 1, 2, 3, 4, 5 },
                new[] {
                    (1, 2),
                    (2, 3),
                    (1, 4),
                    (4, 5)
                });

            IEnumerable<int> trace = Search.BFS(sut, 1);

            Assert.That(trace, Is.AnyOf(
                new[] { 1, 2, 4, 3, 5 },
                new[] { 1, 4, 2, 5, 3 }));
        }

        // 1 - 2 - 3
        //  \
        //   \ 4 - 5
        [Test]
        public void when_use_dfs_closest_verticle_is_returned_last()
        {
            var sut = new UndirectedAdjacencyListGraph<int>(
                new[] { 1, 2, 3, 4, 5 },
                new[] {
                    (1, 2),
                    (2, 3),
                    (1, 4),
                    (4, 5)
                });

            var trace = Search.DFS(sut, 1).ToArray();

            Assert.That(trace, Is.AnyOf(
                new[] { 1, 2, 3, 4, 5 }, 
                new[] { 1, 4, 5, 2, 3} ));
        }

        [Test]
        public void cyctes_does_not_cause_endless_loop()
        {
            var sut = new UndirectedAdjacencyListGraph<int>(
                new[] { 1, 2, 3, 4, 5 },
                new[] {
                    (1, 2),
                    (2, 3),
                    (3, 4),
                    (4, 5),
                    (5, 1)
                });

            var trace = Search.DFS(sut, 1).ToArray();

            Assert.That(trace.Length, Is.EqualTo(5));
        }
    }
}
