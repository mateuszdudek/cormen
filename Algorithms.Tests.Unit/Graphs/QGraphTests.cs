using Algorithms.Graphs;
using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.Tests.Unit.Graphs
{
    public class QGraphTests
    {
        [Test]
        public void Case1()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA")
            };

            Assert.That(solution.HasConnection(edges, 1, "AAA", "BBB"), Is.EqualTo(true));
        }

        [Test]
        public void Case2()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA")
            };

            Assert.That(solution.HasConnection(edges, 1, "AAA", "CCC"), Is.EqualTo(false));
        }

        [Test]
        public void Case3()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA")
            };

            Assert.That(solution.HasConnection(edges, 2, "AAA", "CCC"), Is.EqualTo(true));
        }

        [Test]
        public void Case4()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA")
            };

            Assert.That(solution.HasConnection(edges, 4, "AAA", "CCC"), Is.EqualTo(true));
        }

        [Test]
        public void Case5()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA")
            };

            Assert.That(solution.HasConnection(edges, 3, "AAA", "CCC"), Is.EqualTo(false));
        }

        [Test]
        public void Case6()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA"),
                ("CCC", "DDD")
            };

            Assert.That(solution.HasConnection(edges, 3, "AAA", "DDD"), Is.EqualTo(true));
        }

        [Test]
        public void Case7()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA"),
                ("CCC", "DDD")
            };

            Assert.That(solution.HasConnection(edges, 5, "AAA", "DDD"), Is.EqualTo(true));
        }

        [Test]
        public void Case8()
        {
            var solution = new QSolution();
            var edges = new List<(string from, string to)>
            {
                ("AAA", "BBB"),
                ("AAA", "BBB"),
                ("BBB", "CCC"),
                ("BBB", "AAA"),
                ("CCC", "DDD")
            };

            Assert.That(solution.HasConnection(edges, 4, "AAA", "DDD"), Is.EqualTo(false));
        }
    }
}
