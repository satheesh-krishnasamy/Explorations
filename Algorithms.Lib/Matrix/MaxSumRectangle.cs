//using Algorithms.Lib.Matrix.Model;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Algorithms.Lib.Matrix
//{
//    public class MaxSumRectangle
//    {
//        public static Tuple<int, IList<Tuple<int, int, int>>> FindMaxSumRectangle1(int[,] a)
//        {
//            int rows = a.GetLength(0);
//            int cols = a.GetLength(1);

//            var maxRowSum = 0;
//            var maxRectangleInRow = new List<Tuple<int, int>>();
//            var maxRectangle = new List<Tuple<int, int, int>>(); // top-left, top-right, bottom-left indexes; bottom-right can be derived from (bottom-left, top-right)

//            var maxRectangleSum = 0;


//            for (int i = 0; i < rows; i++, maxRowSum = 0)
//            {
//                var tempRowSum = 0;
//                int prevValue = 0;

//                for (int j = 0, tempColStartIndex = 0; j < cols; j++)
//                {
//                    /* if the current element in the row,column is ZERO then check for previous
//                     * range of 1's
//                     * */
//                    if (a[i, j] == 0)
//                    {
//                        if (prevValue == 1)
//                        {
//                            if (tempRowSum > maxRowSum)
//                            {
//                                maxRectangleInRow.Clear();
//                                // j-1 should give us the end index of the range being considered, since prevValue is set to 1. This will not give us -1 as index.
//                                maxRectangleInRow.Add(new Tuple<int, int>(tempColStartIndex, j - 1));
//                            }
//                            else if (tempRowSum == maxRowSum)
//                            {
//                                // we found another rectangle that has the same sum of the previous rectangle/range in the row.
//                                // j-1 should give us the end index of the range being considered, since prevValue is set to 1. This will not give us -1 as index.
//                                maxRectangleInRow.Add(new Tuple<int, int>(tempColStartIndex, j - 1));
//                            }
//                        }
//                    }
//                    else // == 1
//                    {
//                        // Sum the 1 in the current row
//                        tempRowSum += a[i, j];

//                        /* if previouos value in the column is 0 and if it is the first 1 in the row 
//                         * then keep the range start index in a variable.
//                         * */
//                        if (prevValue == 0)
//                        {
//                            tempColStartIndex = j;
//                        }
//                    }

//                    prevValue = a[i, j];
//                }

//                if (maxRowSum > 0)
//                {
//                    if (maxRectangleInRow.Count == 0)
//                    {
//                        // all the columns in the row has 1s; hence take the whole row.
//                        maxRectangleInRow.Add(new Tuple<int, int>(0, cols - 1));
//                    }

//                    // add the current row sum into tempMaxRectangleSum
//                    var tempMaxRectangleSum = maxRowSum;
//                    foreach (var range in maxRectangleInRow)
//                    {
//                        var breakAll = false;
//                        var tempCurrRowSumInRectangle = 0;
//                        // Since we already added the current row sum into tempMaxRectangleSum, start with next row.
//                        for (int r = i + 1; r < rows; r++)
//                        {
//                            for (int c = range.Item1; c < range.Item2; c++)
//                            {
//                                // as see as we encounter the 0 then terminate the sum calc.
//                                if (a[r, c] == 0)
//                                {
//                                    breakAll = true;
//                                }
//                                else // == 1
//                                {
//                                    tempCurrRowSumInRectangle += a[r, c];
//                                }
//                            }

//                            if (breakAll)
//                                break;
//                            else
//                            {
//                                // if current row has 0 in it then ignore the current row sum
//                                tempMaxRectangleSum += tempCurrRowSumInRectangle;
//                            }
//                        }

//                        if (tempMaxRectangleSum > maxRectangleSum)
//                        {
//                            maxRectangle.Clear();
//                            maxRectangle.Add(new Tuple<int, int, int>(i, range.Item1, range.Item2));
//                        }
//                        else if (tempMaxRectangleSum == maxRectangleSum)
//                        {
//                            maxRectangle.Add(new Tuple<int, int, int>(i, range.Item1, range.Item2));
//                        }
//                    }
//                }
//            }


//            return new Tuple<int, IList<Tuple<int, int, int>>>(maxRectangleSum, maxRectangle);

//        }

//        public static Tuple<int, IList<Rectangle>> FindMaxSumRectangles(int[,] a)
//        {
//            int maxSum = 0;
//            IList<Rectangle> result = new List<Rectangle>();
//            int rows = a.GetLength(0);
//            int cols = a.GetLength(1);
//            int[] rowSums = new int[rows];
//            int[] colSums = new int[cols];

//            /* Calculate the maximum sum of adjacent  ONEs in each row and column.
//             * Time complexity = O(N) where N = number of elements in the array.
//             * Space complexity = O((No.of Rows + 1) + (2 * No.of Columns)) 
//             *          = Storage required for saving the rowwise and columnwise sums + 
//             *          temporary variables to store the sum of rows ( = 1) and columns
//             *          (= No.of Columns)
//             * */
//            CalculateRowwiseAndColumnwiseSums(a, rows, cols, rowSums, colSums, ref maxSum);


//            FindMaxSumRectangleInColumns(a, cols, colSums, ref maxSum, result);

//            return new Tuple<int, IList<Rectangle>>(maxSum, result);

//        }

//        private static void CalculateRowwiseAndColumnwiseSums(
//            int[,] a,
//            int rowsCount,
//            int colsCount,
//            int[] rowSums,
//            int[] colSums,
//            ref int maxSum)
//        {
//            int[] tempColSums = new int[colsCount];

//            for (int i = 0; i < rowsCount; i++)
//            {
//                int currentGroupRowSum = 0;
//                for (int j = 0; j < colsCount; j++)
//                {
//                    if (a[i, j] == 0)
//                    {
//                        if (currentGroupRowSum > rowSums[i])
//                        {
//                            rowSums[i] = currentGroupRowSum;
//                            if (rowSums[i] > maxSum)
//                            {
//                                maxSum = rowSums[i];
//                            }
//                        }
//                        currentGroupRowSum = 0;

//                        if (tempColSums[j] > colSums[j])
//                        {
//                            colSums[j] = tempColSums[j];
//                            if (colSums[j] > maxSum)
//                            {
//                                maxSum = colSums[j];
//                            }
//                        }
//                        tempColSums[j] = 0;
//                    }
//                    else // 1
//                    {
//                        currentGroupRowSum += a[i, j];
//                        tempColSums[j] += a[i, j];

//                        // if it is last row then
//                        if (i + 1 >= rowsCount)
//                        {
//                            if (tempColSums[j] > colSums[j])
//                            {
//                                colSums[j] = tempColSums[j];
//                            }

//                            if (colSums[j] > maxSum)
//                            {
//                                maxSum = colSums[j];
//                            }
//                        }
//                    }
//                }

//                // if there is no 0 at the last column of the row
//                if (currentGroupRowSum > rowSums[i])
//                {
//                    rowSums[i] = currentGroupRowSum;
//                }
//            }
//        }


//        private static void FindMaxSumRectangleInColumns(int[,] a,
//            int colsCount,
//            int[] colSums,
//            ref int maxSum,
//            IList<Rectangle> result)
//        {
//            IList<Tuple<int, int>> maxSumColIndexes = new List<Tuple<int, int>>();
//            var maxSumOfColRange = 0;

//            for (int i = 0; i < colsCount; i++)
//            {
//                int minSumInColumnSums = colSums[i];
//                if (minSumInColumnSums == 0)
//                {
//                    continue;
//                }

//                for (int j = 0; j < colsCount; j++)
//                {
//                    if (colSums[j] < minSumInColumnSums)
//                    {
//                        minSumInColumnSums = colSums[j];
//                    }

//                    var tempPredictedSumIfColumnsJoined = minSumInColumnSums * (j + 1);

//                    if (tempPredictedSumIfColumnsJoined >= maxSum)
//                    {
//                        var rectangles = FindRectanglesInColumns(
//                                a,
//                                minSumInColumnSums,
//                                tempPredictedSumIfColumnsJoined,
//                                a.GetLength(0),
//                                i,
//                                j
//                            );

//                        if (rectangles != null)
//                        {
//                            //maxSum = tempPredictedSumIfColumnsJoined;

//                            if (tempPredictedSumIfColumnsJoined > maxSum)
//                            {
//                                result.Clear();
//                            }

//                            foreach (var rect in rectangles)
//                                result.Add(rect);
//                        }
//                    }
//                }
//            }
//        }

//        private static IList<Rectangle> FindRectanglesInColumns(
//            int[,] a,
//            int expectedSumPerRow,
//            int predictedMaxSumOfRectangle,
//            int rows,
//            int startColIndex,
//            int endColIndex
//            )
//        {
//            if (predictedMaxSumOfRectangle < 1)
//                return null;

//            IList<Rectangle> result = new List<Rectangle>();
//            bool isNewRectangle = true;
//            int tempSumOfRectangle = 0;

//            Rectangle rect = new Rectangle();


//            for (int i = 0; i < rows; i++)
//            {
//                var sumOfColRangeInCurrentRow = 0;
//                for (int j = startColIndex; j <= endColIndex; j++)
//                {
//                    if (a[i, j] == 0)
//                        break;
//                    sumOfColRangeInCurrentRow++;
//                }

//                if (sumOfColRangeInCurrentRow == expectedSumPerRow)
//                {
//                    tempSumOfRectangle += sumOfColRangeInCurrentRow;

//                    if (isNewRectangle)
//                    {
//                        rect.RowStartIndex = i;
//                        rect.ColumnStartIndex = startColIndex;
//                        rect.ColumnEndIndex = endColIndex;

//                        isNewRectangle = false;
//                    }
//                    else
//                    {
//                        rect.RowEndIndex = i;
//                    }
//                }
//                else
//                {
//                    if (tempSumOfRectangle > predictedMaxSumOfRectangle)
//                    {
//                        result.Clear();
//                        result.Add(rect);
//                    }
//                    else if (tempSumOfRectangle == predictedMaxSumOfRectangle)
//                    {
//                        result.Add(rect);
//                    }

//                    isNewRectangle = true;
//                    tempSumOfRectangle = 0;
//                    rect = new Rectangle();
//                }
//            }

//            if (!isNewRectangle)
//            {
//                if (tempSumOfRectangle > predictedMaxSumOfRectangle)
//                {
//                    result.Clear();
//                }
//                result.Add(rect);
//            }

//            return result;
//        }



//        //private int SumRectangle(int[,] a, int topLeft, int topRight, int bottomLeft)
//        //{
//        //    int sum = 0;
//        //    for (int i = topLeft; i < bottomLeft; i++)
//        //    {
//        //        for (int j = topLeft; j < topRight; j++)
//        //        {
//        //            sum += a[i, j];
//        //        }
//        //    }
//        //    return sum;
//        //}
//    }
//}
