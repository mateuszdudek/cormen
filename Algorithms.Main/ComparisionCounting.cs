using System;

namespace AlgorithmsTests
{
    public class ComparisionCounting<T>
        : IComparable<ComparisionCounting<T>>, IEquatable<ComparisionCounting<T>>
        where T : IComparable<T>, IEquatable<T>
    {
        public T Obj { get; }
        private Counter _comparisions;

        public ComparisionCounting(T obj, Counter comparisionCounter)
        {
            Obj = obj;
            _comparisions = comparisionCounter;
        }

        public static implicit operator ComparisionCounting<T>(T obj)
        {
            return new ComparisionCounting<T>(obj, new Counter());
        }

        public int CompareTo(ComparisionCounting<T> other)
        {
            _comparisions.Increment();
            return Obj.CompareTo(other.Obj);
        }

        public bool Equals(ComparisionCounting<T> other)
        {
            return Obj.Equals(other);
        }
    }
}
