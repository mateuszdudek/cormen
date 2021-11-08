using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Sorting
{
    public class CsSort<T> : ISort<T> where T : IComparable<T>
    {
        public void Sort(List<T> toSort)
        {
            toSort.Sort();
        }
    }
}
