using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Lib.Matrix
{
    public static class ArrayTraversals
    {
        public static IList<int[]> TraverseArrayInAntiDiagonalOrder(int[,] a)
        {
            IList<int[]> result = new List<int[]>();
            var rows = a.GetLength(0);
            var cols = a.GetLength(1);

            if (rows != cols)
                throw new NotSupportedException($"This method works only if the rows and columns are same. Rows = {rows}, Columns = {cols}.");

            //Console.WriteLine("[");
            for (int i = 0; i < cols; i++)
            {
                var resultRow = new int[i + 1];
                //Console.Write("[");
                for (int j = 0, k = i; k > -1; k--, j++)
                {
                    //Console.Write("{0}", a[j, k]);
                    resultRow[j] = a[j, k];

                    //if (k - 1 > -1)
                    //    Console.Write(",");
                }
                //Console.WriteLine("]");
                result.Add(resultRow);
            }

            for (int i = 1; i < rows; i++)
            {
                var resultRow = new int[rows - i];
                //Console.Write("[");
                for (int j = i, k = cols - 1; j < rows; k--, j++)
                {
                    //Console.Write("{0}", a[j, k]);

                    //if (j + 1 < rows)
                    //    Console.Write(",");
                    resultRow[j - i] = a[j, k];
                }
                //Console.WriteLine("]");
                result.Add(resultRow);
            }
            //Console.WriteLine("]");

            return result;
        }
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
