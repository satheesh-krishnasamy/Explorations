using Algorithms.Lib.Matrix;
using Algorithms.Lib.Sort;
using System;

namespace AlgorithmsAndDatastructures
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoSelectionSort();
            Console.ReadKey();
            Console.Clear();
            DemoMatrixTransformation();
            Console.ReadKey();
            Console.Clear();
        }

        private static void DemoMatrixTransformation()
        {
            int[,] source = new int[,] {
                    {10, 20, 30, 40},
                    {40, 50, 60, 70},
                    {80, 90, 100, 110},
                    {120, 130, 140, 150}
                };

            Print(source, "Before Transformation");
            MatrixTransformations.Transform90DegreeInPlace(source);
            Print(source, "After Transformation");
        }

        private static void DemoSelectionSort()
        {
            var numberStrings = new string[] { "-1.1", "-2.2", "-1000", "10.100", "-1.0", "10.1", "10.0001", "10.5", "11", "100", "9" };
            var numbers = new double[] { -1.1, -2.2, -1000, 10.100, -1.0, 10.1, 10.0001, 10.5, 11, 100, 9 };

            SortNumberUtil sortUtil = new SortNumberUtil();

            Print(numberStrings, "Number strings before sort:");
            sortUtil.SelectionSortAsNumbers(numberStrings, true);
            Print(numberStrings, "Number strings after sort [ASC]:");
            sortUtil.SelectionSortAsNumbers(numberStrings, false);
            Print(numberStrings, "Number strings after sort [DESC]:");

            Print(numbers, "Numbers before sort:");
            sortUtil.SelectionSort(ref numbers, true);
            Print(numberStrings, "Numbers after sort [ASC]:");
            sortUtil.SelectionSort(ref numbers, false);
            Print(numbers, "Numbers after sort [DESC]:");
        }

        private static void Print<T>(T[] nums, string headline)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 10));

            Console.WriteLine(headline);

            foreach (var s in nums)
            {
                Console.WriteLine(s);
            }
        }

        private static void Print<T>(T[,] nums, string headline)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 10));
            Console.WriteLine(headline);

            var rows = nums.GetLength(0);
            var cols = nums.GetLength(1);


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0, 3}", nums[i, j]);
                }
                Console.Write(Environment.NewLine);
            }
        }
    }
}
