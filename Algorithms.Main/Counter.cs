using System.Threading;

namespace AlgorithmsTests
{
    public class Counter
    {
        private int _value;
        public int Value { get => _value; }
        public void Increment() => Interlocked.Increment(ref _value);
        public void Reset() => Interlocked.Exchange(ref _value, 0);
    }
}
