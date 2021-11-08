using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class LinqSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            foreach (var row in toSort.OrderBy(a => a))
            {
            }
        }
    }
}
