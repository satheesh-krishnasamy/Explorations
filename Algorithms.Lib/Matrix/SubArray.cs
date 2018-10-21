using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    public static class SubArray
    {
        public static void FindMaxSumOfContiguousSubArray(int[] a)
        {
            int subArraySize = a.Length - 1,
                highestSumSubArrayStartIndex = 0,
                highestSumSubArrayEndIndex = 0;
            long subArrayHighestSum = 0;

            for (int currSubArraySize = subArraySize; currSubArraySize > 0 && currSubArraySize < a.Length; currSubArraySize--)
            {
                for (int j = 0; j + currSubArraySize < a.Length; j++)
                {
                    var currSubArraySum = GetSum(a, j, j + currSubArraySize - 1);
                    if (currSubArraySum > subArrayHighestSum)
                    {
                        subArrayHighestSum = currSubArraySum;
                        highestSumSubArrayStartIndex = j;
                        highestSumSubArrayEndIndex = j + currSubArraySize - 1;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine($"Highest sum: {subArrayHighestSum}");
            Console.Write("Array is ");
            for (int i = highestSumSubArrayStartIndex; i <= highestSumSubArrayEndIndex; i++)
            {
                Console.Write(a[i].ToString() + ", ");
            }
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
