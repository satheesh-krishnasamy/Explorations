using Algorithms.Lib.Matrix.Model;
using System;

namespace Algorithms.Lib.Matrix
{
    /// <summary>
    /// Class provides methods that work with subarray of an array.
    /// </summary>
    public static class SubArray
    {
        public static SubArraySumResult FindMaxSumOfContiguousSubArray(int[] a)
        {
            int subArraySize = a.Length - 1;

            SubArraySumResult result = new SubArraySumResult();
            if (a.Length == 1)
            {
                result.Sum = a[0];
                result.SubArrayIndexes.Add(new Tuple<int, int>(0, 0));
            }


            for (int currSubArraySize = subArraySize; currSubArraySize > 0 && currSubArraySize < a.Length; currSubArraySize--)
            {
                for (int j = 0; (j + currSubArraySize - 1) < a.Length; j++)
                {
                    var currSubArraySum = GetSum(a, j, j + currSubArraySize - 1);
                    if (currSubArraySum > result.Sum)
                    {
                        result.Sum = currSubArraySum;
                        result.SubArrayIndexes.Clear();
                        result.SubArrayIndexes.Add(new Tuple<int, int>(j, j + currSubArraySize - 1));
                    }
                    else if (currSubArraySum == result.Sum)
                    {
                        result.SubArrayIndexes.Add(new Tuple<int, int>(j, j + currSubArraySize - 1));
                    }
                }
            }

            return result;
        }

        private static long GetSum(int[] array, int startIndex, int endIndex)
        {
            long sum = 0;
            for (int i = startIndex; i <= endIndex; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
