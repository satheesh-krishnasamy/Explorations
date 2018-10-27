using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    /// <summary>
    /// Class implements array traversal methods
    /// </summary>
    public static class ArrayTraversals
    {
        /// <summary>
        /// Traverses the array in anti diagonal order.
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>Traversed array elements</returns>
        public static IList<int[]> TraverseArrayInAntiDiagonalOrder(int[,] a)
        {
            IList<int[]> result = new List<int[]>();
            var rows = a.GetLength(0);
            var cols = a.GetLength(1);

            //Console.WriteLine("[");
            for (int currentColIndexInspected = 0;
                currentColIndexInspected < cols;
                currentColIndexInspected++)
            {
                int[] resultRow;

                if (currentColIndexInspected + 1 < rows)
                    resultRow = new int[currentColIndexInspected + 1];
                else
                    resultRow = new int[rows];

                //Console.Write("[");
                for (int rowIndexBeingVisited = 0, k = currentColIndexInspected;
                    k > -1 && rowIndexBeingVisited < rows;
                    k--, rowIndexBeingVisited++)
                {
                    //Console.Write("{0}", a[j, k]);
                    resultRow[rowIndexBeingVisited] = a[rowIndexBeingVisited, k];

                    //if (k - 1 > -1)
                    //    Console.Write(",");
                }
                //Console.WriteLine("]");
                result.Add(resultRow);
            }

            for (int currentRowIndexBeingVisited = 1;
                currentRowIndexBeingVisited < rows;
                currentRowIndexBeingVisited++)
            {
                // To save the space, go with list (expandable array). The number of elements are not well known in advance
                var resultRow = new List<int>();
                //Console.Write("[");
                for (int j = currentRowIndexBeingVisited, k = cols - 1;
                    j < rows && k > -1;
                    k--, j++)
                {
                    //Console.Write("{0}", a[j, k]);

                    //if (j + 1 < rows)
                    //    Console.Write(",");
                    resultRow.Add(a[j, k]);
                }
                //Console.WriteLine("]");
                // Convert and add the array
                result.Add(resultRow.ToArray());
            }
            //Console.WriteLine("]");

            return result;
        }

        /// <summary>
        /// Traverses the array in spiral order.
        /// </summary>
        /// <param name="a">Input array</param>
        /// <returns>Array traversed in Spiral order</returns>
        public static int[] TraverseArrayInSpiralOrder(int[,] a)
        {
            var rows = a.GetLength(0);
            var cols = a.GetLength(1);
            int totalElements = rows * cols;
            int[] result = new int[totalElements];

            /* rsi = row start index
             * csi = column start index
             * rei = row end index
             * cei = column end index
             * 
             * initialize these values with the corner indexes of the current array
             * */

            int rsi = 0,
                csi = 0,
                rei = rows - 1,
                cei = cols - 1;

            /* walk the array elements one by one,
             * either in forward (1 = left to right or top to bottom) direction or backward (-1 = move right to left, bottom to up) direction.
             * we walk the array elements forward by one step right hand side intitally
             * */
            int walkByStep = 1;

            ArraySide completedSide = ArraySide.None;

            // first traverse by row
            bool isRowTraversed = true;

            for (int i = 0, j = 0, elementIndex = 0; elementIndex < totalElements; elementIndex++)
            {
                result[elementIndex] = a[i, j];

                if (isRowTraversed)
                {
                    // row traversal has not yet completed.
                    j += walkByStep; // keep walking in the direction

                    if (j < csi || j > cei) // if row ends
                    {
                        isRowTraversed = false;
                        completedSide = ((ArraySide)((int)completedSide % 4) + 1);

                        if (completedSide == ArraySide.Top)
                        {
                            rsi++;
                            i = rsi;
                            j = cei;
                            walkByStep = 1;
                        }
                        else // (completedSide == ArraySide.Bottom)
                        {
                            rei--;
                            i = rei;
                            j = csi;
                            walkByStep = -1;
                        }
                    }// end of if row ends
                }// end of isRowTraversed.
                else
                {
                    // column traversal is not yet completed
                    i += walkByStep;

                    // column is traversed.
                    if (i < rsi || i > rei)
                    {
                        // column has traversed completely.

                        isRowTraversed = true;//redirect to row
                        completedSide = ((ArraySide)((int)completedSide % 4) + 1);
                        if (completedSide == ArraySide.Right)
                        {
                            cei--;
                            j = cei;
                            i = rei;
                            walkByStep = -1;
                        }
                        else //(completedSide == ArraySide.Left)
                        {
                            csi++;
                            j = csi;
                            i = rsi;
                            walkByStep = 1;
                        }
                    }
                }
            }

            return result;
        }

        private enum ArraySide
        {
            None = 0,
            Top = 1,
            Right = 2,
            Bottom = 3,
            Left = 4
        }
    }


}
