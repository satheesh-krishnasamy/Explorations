using Algorithms.Lib.Matrix.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    /// <summary>
    /// Methods on Matrix
    /// </summary>
    public static class MatrixOperations
    {
        /// <summary>
        /// Finds the maximum sum rectangle with contiguous elements except the given element.
        /// </summary>
        /// <param name="a">Input array.</param>
        /// <param name="elementToExclude">The element to exclude.</param>
        /// <returns>
        /// Rectangle object 
        /// (contains the indexes marking top-left, top-right, bottom-left, bottom-right corners of the rectangle) if the max sum rectangle found;
        /// Null otherwise.
        /// Note: This method will ignore the rectangle row/column if it contains the element that was asked to exclude.
        /// </returns>
        /// <remarks>This method will ignore the rectangle row/column if it contains the element that was asked to exclude.</remarks>
        /// <seealso cref="ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithmCustom(int[], int)"/>
        public static Rectangle FindMaxSumRectangleWithContiguousElementsExcept(int[,] a, int elementToExclude)
        {
            int cols = a.GetLength(1),
                rows = a.GetLength(0);
            bool rectangleFound = false;

            Rectangle result = new Rectangle();

            for (int leftPointer = 0; leftPointer < cols; leftPointer++)
            {
                int[] colSumArray = new int[rows];
                bool[] AreZerosExistsInRow = new bool[rows];

                for (int rightPointer = leftPointer; rightPointer < cols; rightPointer++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        if (a[i, rightPointer] == elementToExclude)
                        {
                            AreZerosExistsInRow[i] = true;
                            // if the total till previous column is > 0.. but we have azero in the current row/column. Hence ignore the previous total.
                            colSumArray[i] = 0;
                        }
                        else if (!AreZerosExistsInRow[i])
                        {
                            colSumArray[i] += a[i, rightPointer];
                        }
                    }

                    var maxSumSubArray = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithmCustom(colSumArray, elementToExclude);

                    if (maxSumSubArray.Sum > result.Sum)
                    {
                        result.Sum = maxSumSubArray.Sum;
                        result.ColumnStartIndex = leftPointer;
                        result.ColumnEndIndex = rightPointer;
                        result.RowStartIndex = maxSumSubArray.SubArrayIndexes[0].Item1;
                        result.RowEndIndex = maxSumSubArray.SubArrayIndexes[0].Item2;
                        rectangleFound = true;
                    }
                }
            }

            if (rectangleFound)
                return result;
            else
                return null;
        }

        /// <summary>
        /// Finds the maximum sum rectangle.
        /// </summary>
        /// <param name="a">Input array.</param>
        /// <returns>Rectangle object 
        /// (contains the indexes marking top-left, top-right, bottom-left, bottom-right corners of the rectangle) if the max sum rectangle found;
        /// Null otherwise.
        /// </returns>
        /// <seealso cref="ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(int[])"/>
        public static Rectangle FindMaxSumRectangle(int[,] a)
        {
            int cols = a.GetLength(1),
                rows = a.GetLength(0);
            bool rectangleFound = false;

            Rectangle result = new Rectangle();

            for (int leftPointer = 0; leftPointer < cols; leftPointer++)
            {
                /* reset the array that stores the sum of elements in the rows 
                 * (and presents columns from left pointer to right pointer)
                 * */
                int[] colSumArray = new int[rows];

                for (int rightPointer = leftPointer; rightPointer < cols; rightPointer++)
                {
                    for (int i = 0; i < rows; i++)
                    {
                        colSumArray[i] += a[i, rightPointer];
                    }

                    var maxSumSubArray = default(SubArraySumResult);

                    maxSumSubArray = ArrayOperations.FindMaxSumSubArrayByKadanesAlgorithm(colSumArray);

                    if (maxSumSubArray.Sum > result.Sum)
                    {
                        result.Sum = maxSumSubArray.Sum;
                        result.ColumnStartIndex = leftPointer;
                        result.ColumnEndIndex = rightPointer;
                        result.RowStartIndex = maxSumSubArray.SubArrayIndexes[0].Item1;
                        result.RowEndIndex = maxSumSubArray.SubArrayIndexes[0].Item2;
                        rectangleFound = true;
                    }
                }
            }

            if (rectangleFound)
                return result;
            else
                return null;

        }
    }
}
