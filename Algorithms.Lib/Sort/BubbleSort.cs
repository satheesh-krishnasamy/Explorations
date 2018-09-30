using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Lib.Sort.Model;

namespace Algorithms.Lib.Sort
{
    public static class BubbleSort
    {
        public static int Sort(int[] input, bool isAscending)
        {
            int iterations = 0;
            var maxIterations = input.Length - 1;
            CheckExpectedOrder AreInExpectedOrder;
            if (isAscending)
                AreInExpectedOrder = AscendingComparison;
            else
                AreInExpectedOrder = DescendingComparison;

            for (int i = 0; i < maxIterations; i++)
            {
                iterations++;
                var noOfElementsToCompare = maxIterations - i;
                for (int j = 0; j < noOfElementsToCompare; j++)
                {
                    iterations++;
                    if (!AreInExpectedOrder(input[j], input[j + 1]))
                    {
                        var temp = input[j];
                        input[j] = input[j + 1];
                        input[j + 1] = temp;
                    }
                }
            }
            return iterations;
        }

        private static bool AscendingComparison(int number1, int number2)
        {
            return number1 < number2;
        }

        private static bool DescendingComparison(int number1, int number2)
        {
            return number1 > number2;
        }
    }
}
