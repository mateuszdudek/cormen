using System;
using System.Diagnostics.CodeAnalysis;

namespace Algorithm.Tests.Unit.Sorting
{
    public class ComparisionCounting<T>
        : IComparable<ComparisionCounting<T>>, IEquatable<ComparisionCounting<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        public T Obj { get; }
        public int Comparisions { get; private set; }

        public ComparisionCounting(T obj)
        {
            Obj = obj;
            Comparisions = 0;
        }

        public static implicit operator ComparisionCounting<T>(T obj)
        {
            return new ComparisionCounting<T>(obj);
        }

        public int CompareTo([NotNull] ComparisionCounting<T> other)
        {
            ++Comparisions;
            return Obj.CompareTo(other.Obj);
        }

        public bool Equals(ComparisionCounting<T> other)
        {
            return Obj.Equals(other);
        }
    }
}
