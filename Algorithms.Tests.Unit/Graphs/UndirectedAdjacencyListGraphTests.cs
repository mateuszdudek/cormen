using Algorithms.Graph;
using NUnit.Framework;

namespace Algorithm.Tests.Unit.Graphs
{
    public class UndirectedAdjacencyListGraphTests
    {
        [Test]
        public void when_graph_is_created_then_contains_vertices_and_edges()
        {
            var sut = new UndirectedAdjacencyListGraph<int>(
                new[] { 1, 2, 3, 4 }, 
                new[] { 
                    (1, 2), 
                    (2, 3) 
                });

            Assert.That(sut.ContainsKey(1));
            Assert.That(sut.ContainsKey(2));
            Assert.That(sut.ContainsKey(3));
            Assert.That(sut.ContainsKey(4));

            Assert.That(sut[1].Contains(2));
            Assert.That(sut[2].Contains(1));
            Assert.That(sut[2].Contains(3));
            Assert.That(sut[3].Contains(2));

            Assert.That(sut[4], Is.Empty);
        }
    }
}
