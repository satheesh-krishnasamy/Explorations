using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    public static class MatrixComparer
    {
        public static bool AreRowsSame<T>(T[,] source, T[,] target, int rowIndexToCompare)
        {
            var numberOfColumns = source.GetLength(1);

            for (var i = 0; i < numberOfColumns; i++)
            {
                if (target[rowIndexToCompare, i] == null && source[rowIndexToCompare, i] != null)
                    return false;

                if (target[rowIndexToCompare, i] != null && source[rowIndexToCompare, i] == null)
                    return false;

                if (!source[rowIndexToCompare, i].Equals(target[rowIndexToCompare, i]))
                    return false;
            }

            return true;
        }

        public static bool AreSame<T>(T[,] source, T[,] target)
        {
            // rows must be equal
            if (source.GetLength(0) != target.GetLength(0))
                return false;

            // columns must be equal
            if (source.GetLength(1) != target.GetLength(1))
                return false;

            var rowsCount = source.GetLength(0);

            for (var i = 0; i < rowsCount; i++)
            {
                if (!AreRowsSame(source, target, i))
                    return false;
            }

            return true;
        }

        public static bool AreSame<T>(T[] source, T[] target)
        {
            // rows must be equal
            if (source.GetLength(0) != target.GetLength(0))
                return false;

            var elementCount = source.GetLength(0);

            for (var i = 0; i < elementCount; i++)
            {
                if (source == null && target != null)
                    return false;
                else if (source != null && target == null)
                    return false;
                else if (source == null && target == null)
                    continue;
                if (!source[i].Equals(target[i]))
                    return false;
            }

            return true;
        }
    }
}
