using Algorithms.Lib.Sort.Model;

namespace Algorithms.Lib.Sort
{
    public static class SelectionSort
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

            for (int i = 0; i < input.Length; i++)
            {
                iterations++;
                var indexOfIthMinOrMaxElement = i;
                for (int j = i + 1; j < input.Length; j++)
                {
                    iterations++;
                    if (!AreInExpectedOrder(input[indexOfIthMinOrMaxElement], input[j]))
                    {
                        indexOfIthMinOrMaxElement = j;
                    }
                }

                if (indexOfIthMinOrMaxElement != i)
                {
                    var temp = input[i];
                    input[i] = input[indexOfIthMinOrMaxElement];
                    input[indexOfIthMinOrMaxElement] = temp;
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
