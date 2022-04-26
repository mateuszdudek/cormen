using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.DataStructures
{
    class Matrix : List<List<int>>
    {
        private int _size;

        public static Matrix FromNaive(List<List<int>> input)
        {
            Matrix m = new Matrix();
            m.AddRange(input.Select(r => new List<int>(r)));
            return m;
        }

        public static Matrix FromList(List<int> list)
        {
            Matrix m = new Matrix();
            m._size = (int)Math.Sqrt(list.Count);

            for (int i = 0; i < list.Count; ++i)
            {
                if (i % m._size == 0) m.Add(new List<int>());
                m[i / m._size].Add(list[i]);
            }

            return m;
        }

        public bool IsMagicSquare()
        {
            for (int i = 0; i < _size; ++i)
            {
                if (this[0][i] + this[1][i] + this[2][i] != 15) return false;
                if (this[i][0] + this[i][1] + this[i][2] != 15) return false;
            }

            if (this[0][0] + this[1][1] + this[2][2] != 15) return false;
            if (this[0][2] + this[1][1] + this[2][0] != 15) return false;

            return true;
        }

        public int Difference(Matrix m)
        {
            int diff = 0;
            for (int i = 0; i < this._size; ++i)
            {
                for (int j = 0; j < this._size; ++j)
                {
                    diff += Math.Abs(this[i][j] - m[i][j]);
                }
            }
            return diff;
        }
    }

}
