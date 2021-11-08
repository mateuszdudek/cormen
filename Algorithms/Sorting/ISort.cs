using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    public interface ISort<T> where T : IComparable<T>
    {
        public string Name { get { return this.GetType().Name; } }
        public void Sort(List<T> toSort);
    }
}
