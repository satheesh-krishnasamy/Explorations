using Algorithms.Lib.Matrix;
using Algorithms.Lib.Sort;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AlgorithmsAndDatastructures
{
    class Program
    {
        static void Main(string[] args)
        {

            IList<DemoScreenDisplay> demos = new List<DemoScreenDisplay>
            {
                new DemoScreenDisplay("Selection sort (numbers)", DemoSelectionSortOnNumbers),
                new DemoScreenDisplay("Selection sort (number strings without type cast)", DemoSelectionSortOnStringNumbers),
                new DemoScreenDisplay("Bubble sort (numbers)", DemoBubbleSort),
                new DemoScreenDisplay("Find subarray with highest sum", DemoHighestSumSubArray),
                new DemoScreenDisplay("Matrix Transformation", DemoMatrixTransformation),
                new DemoScreenDisplay("Matrix Traversal In Spiral Order", DemoMatrixTraversalInSpiralOrder),
                new DemoScreenDisplay("Matrix Traversal In Anti-Diagonal Order", DemoMatrixTraversalInAntiDiagonalOrder)
            };

            int option = -1;
            while (option != 0)
            {
                PrintMenu(demos);
                var optionText = Console.ReadLine();
                if (Int32.TryParse(optionText, out option))
                {
                    if (option > -1 && option < demos.Count)
                    {
                        if (option == 0)
                            break;

                        var demoSelected = demos[option - 1];
                        Console.WriteLine($"Selected option is {option} -- {demoSelected.DisplayText}...");
                        demoSelected.DemoMethod();
                        Console.WriteLine();
                        Console.WriteLine("Press any key to show menu...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine($"Enter only 0-{demos.Count}.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    option = -1;
                    Console.WriteLine($"Enter only 0-{demos.Count}.");
                    Console.ReadKey();
                }
            }
        }

        private static void PrintMenu(IList<DemoScreenDisplay> demos)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine($"0. Exit.");
            for (int i = 0; i < demos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {demos[i].DisplayText}.");
            }
        }

        private static void DemoBubbleSort()
        {
            var inputArray = new int[] { 100, 15, 20, 5, 0, 101 };
            Print(inputArray, "Before sorting: ");
            BubbleSort.Sort(inputArray, true);
            Print(inputArray, "After Bubble sorting: ");
        }

        private static void DemoHighestSumSubArray()
        {
            //var inputArray = new int[] { 100, 15, 20, -5, 0, 101 };
            var inputArray = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Print(inputArray, "All elements in the array: ");
            SubArray.FindMaxSumOfContiguousSubArray(inputArray);
        }

        private static void DemoSelectionSortOnNumbers()
        {
            var inputArray = new int[] { 100, 15, 20, 5, 0, 101 };
            Print(inputArray, "Before sorting: ");
            SelectionSort.Sort(inputArray, true);
            Print(inputArray, "After selection sorting: ");
        }

        private static void DemoMatrixTransformation()
        {
            //int[,] source = new int[,] {
            //        {10, 20, 30, 40},
            //        {40, 50, 60, 70},
            //        {80, 90, 100, 110},
            //        {120, 130, 140, 150}
            //    };
            int[,] source = new int[,] {
                    {10, 20},
                    {40, 50}
                };

            Print(source, "Before Transformation");
            MatrixTransformations.Transform90DegreeInPlace(source);
            Print(source, "After Transformation");
        }

        private static void DemoMatrixTraversalInSpiralOrder()
        {
            int[,] source = new int[,] {
                    {10, 20, 30, 40},
                    {40, 50, 60, 70},
                    {80, 90, 100, 110},
                    {120, 130, 140, 150}
                };
            //int[,] source = new int[,] {
            //        {10, 20},
            //        {40, 50}
            //    };



            Print(source, "Original matrix");
            var result = ArrayTraversals.TraverseArrayInSpiralOrder(source);
            Console.ForegroundColor = ConsoleColor.Green;
            Print(result, "Matrix in spiral order");
        }


        private static void DemoMatrixTraversalInAntiDiagonalOrder()
        {
            //int[,] source = new int[,] {
            //        {10, 20, 30, 40},
            //        {40, 50, 60, 70},
            //        {80, 90, 100, 110},
            //        {120, 130, 140, 150}
            //    };

            int[,] source = new int[,]
            {
                { 1,2,3},
                { 4,5,6},
                { 7,8,9}
            };

            Print(source, "Original matrix");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Anti-diagonal traversal..");
            var result = ArrayTraversals.TraverseArrayInAntiDiagonalOrder(source);
            foreach (var row in result)
                Print(row, "");
        }

        private static void DemoSelectionSortOnStringNumbers()
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

            for (int i = 0; i < nums.Length; i++)
            {
                Console.Write("{0, 4}", nums[i]);
                if (i + 1 < nums.Length)
                    Console.Write(",");
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

    internal class DemoScreenDisplay
    {
        public string DisplayText;
        public Action DemoMethod;

        public DemoScreenDisplay(string displayText, Action demoMethod)
        {
            this.DisplayText = displayText;
            this.DemoMethod = demoMethod;
        }
    }
}

