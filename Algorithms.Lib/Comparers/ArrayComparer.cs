using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Comparers
{
    public class ArrayComparer<T>
    {
        private readonly IEqualityComparer<T> comparer;

        public ArrayComparer(IEqualityComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public ArrayComparer()
        {
            this.comparer = new ObjectEqualityComparer<T>();
        }

        public bool AreArraySame(T[] source, T[] target)
        {
            if (source.Length != target.Length)
                return false;

            for (int i = 0; i < source.Length; i++)
            {
                if (!this.comparer.Equals(source[i], target[i]))
                    return false;
            }

            return true;
        }
    }

    public class ObjectEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            if (x != null && y == null)
                return false;
            else if (x == null && y != null)
                return false;
            else if (!object.Equals(x, y))
                return false;

            return true;
        }

        public int GetHashCode(T obj)
        {
            if (obj == null)
                return 0;

            return obj.GetHashCode();
        }
    }
}
