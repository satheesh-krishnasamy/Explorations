using System;

namespace Algorithms.Lib.Matrix
{
    /// <summary>
    /// Class provides methods for matrix transformation
    /// </summary>
    public static class MatrixTransformations
    {
        /// <summary>
        /// Transform the matrix 90 degree in place.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <exception cref="NotSupportedException">Not supported. This method work only when the rows/columns are same in number.</exception>
        public static void Transform90DegreeInPlace<T>(T[,] matrix)
        {
            const int FIRST_DIMENSION = 0;
            const int SECOND_DIMENSION = 1;

            var rowsCount = matrix.GetLength(FIRST_DIMENSION);
            var columnsCount = matrix.GetLength(SECOND_DIMENSION);

            // this method works only on the matrix having same number or rows and columns
            if (rowsCount != columnsCount)
                throw new NotSupportedException($"The matrix should have same number of rows and columns. Current Rows = {columnsCount} and columns = {columnsCount}.");

            for (int columnToTranspose = columnsCount - 1; columnToTranspose >= 0; columnToTranspose--)
            {
                TransformInternal(matrix, columnToTranspose);
            }
        }

        private static void TransformInternal<T>(T[,] matrix, int columnIndexToTranspose)
        {
            // rows and columns count are same
            var totalRowsInWholeMatrix = matrix.GetLength(0);
            var totalColsInWholeMatrix = matrix.GetLength(1);


            var rowIndex = 0;
            var currentSubMatrixTargetColumnIndex = columnIndexToTranspose;

            /* Exchange the {columnIndexToTranspose + 1} number of  elements in the first row 
             * with the elements in the target column
             * */
            for (int col = 0, row = currentSubMatrixTargetColumnIndex; col != currentSubMatrixTargetColumnIndex; col++, row--)
            {
                var element = matrix[0, col];
                matrix[0, col] = matrix[row, currentSubMatrixTargetColumnIndex];
                matrix[row, currentSubMatrixTargetColumnIndex] = element;
            }
            // At the end of the above for loop the target column has elements ordered in reverse than expected

            /* Re-order the {columnIndexToTranspose + 1} of elements in the 
             * target column bottom-up or upside-down
             * */
            for (int rowSource = rowIndex, rowTarget = currentSubMatrixTargetColumnIndex;
                rowSource < rowTarget;
                rowSource++, rowTarget--)
            {
                var element = matrix[rowTarget, currentSubMatrixTargetColumnIndex];
                matrix[rowTarget, currentSubMatrixTargetColumnIndex] = matrix[rowSource, currentSubMatrixTargetColumnIndex];
                matrix[rowSource, currentSubMatrixTargetColumnIndex] = element;
            }

            /* The {columnIndexToTranspose + 1} of elements from left to right 
             * in the first row in the matrix now in the expected order.
             * But this row must be moved down to the {columnIndexToTranspose}th Row.
             * All other rows below the first row must be brought one row above.
             */
            for (int c = 0; c < currentSubMatrixTargetColumnIndex; c++)
            {
                int r = 0;
                var temp = matrix[r, c];
                for (; r < currentSubMatrixTargetColumnIndex; r++)
                {
                    matrix[r, c] = matrix[r + 1, c];
                }

                matrix[r, c] = temp;
            }

        }
    }
}
